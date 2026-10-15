

using DwarfBlackjack.Classes;
using DwarfBlackjack.Views;
using Microsoft.Maui.Layouts;
using System.ComponentModel;

namespace DwarfBlackjack.Views;

//PlayPage bestämmer vad som ska visas på skärmen under spelets gång @author Calle Nilsson
public partial class PlayPage : ContentPage
{
    private int dealerPoints = 0;
    private const double CardAspectRatio = 168.0 / 240.0; //bildstorlek på korten
    private const double CardSpacingRatio = 0.6; //kort överlappar varandra 40%

    private BlackjackGame blackjackGame;

    public PlayPage()
	{
		InitializeComponent();
        blackjackGame = new BlackjackGame();
        PlayerCards.SizeChanged += OnPlayerCardsSizeChanged;
        DealerCards.SizeChanged += OnDealerCardsSizeChanged;

        Loaded += OnPageLoaded;
    }

    private void OnPlayerCardsSizeChanged(object? sender, EventArgs e)
    {
        PositionCards(PlayerCards);
    }
    private void OnDealerCardsSizeChanged(object? sender, EventArgs e)
    {
        PositionCards(DealerCards);
    }

    private async void OnPageLoaded(object? sender, EventArgs e)
    {
        await GiveInitialCards();
        
    }
    private async Task GiveInitialCards()
    {
        await PlayerHit();
        await DealerHit();
        await PlayerHit();
        await DealerHit();
        CheckInitialGameState();
    }
    private async Task RenderPlayerCard(string cardText)
    {
        var card = new Views.CardContentView(cardText);

        PlayerCards.Children.Add(card);
        PositionCards(PlayerCards);
        
        await card.AnimateCardIn(Spelplan.Height);
        await card.FlipAsync();

        UpdatePlayerScore();
    }

    private async Task RenderDealerCard(string cardText)
    {
        var card = new Views.CardContentView(cardText);
        // Göm dealers andra kort
        if (DealerCards.Children.Count == 1)
        {
            card.IsHidden = true;
        }

        DealerCards.Children.Add(card);
        PositionCards(DealerCards);
        await card.AnimateCardIn(Spelplan.Height);
        await card.FlipAsync();

        if (!card.IsHidden)
        {
            UpdateDealerScore();
        }
    }
    /* Positonerar varje kort så att de överlappar varandra 40% */
    private void PositionCards(AbsoluteLayout container)
    {
        int count = container.Children.Count;
        
        double cardHeight = container.Height * 0.8;
        double cardWidth = cardHeight * CardAspectRatio;
        // Avståndet mellan kortens vänstra kanter.
        // Eftersom spacing är mindre än kortets bredd kommer korten att överlappa.
        double spacing = cardWidth * CardSpacingRatio;
        // Den totala bredden som alla kort tillsammans tar upp.
        double totalWidth = cardWidth + (count - 1) * spacing;
        // X-positionen för det första kortet så att hela raden
        // med kort hamnar centrerad i containern.
        double startX = (container.Width - totalWidth) / 2;
        double y = (container.Height - cardHeight) / 2;
        
        for (int i = 0; i < count; i++)
        {
            var card = (View)container.Children[i];
            //Varje nytt kort flyttas åt höger med samma spacing
            double x = startX + i * spacing;
            
            Rect rect = new Rect(x, y, cardWidth, cardHeight);
            AbsoluteLayout.SetLayoutBounds(card, rect);
            AbsoluteLayout.SetLayoutFlags(card, AbsoluteLayoutFlags.None);
        }
    }
    
    private async void OnHitClicked(object sender, EventArgs e)
    {
        GameStatus.Text = "Your turn";
        await PlayerHit();
    }

    private async void OnStandClicked(object sender, EventArgs e)
    {
        GameStatus.Text = "Dealer's turn";

        // Vänd det dolda kortet
        await ShowDealerCard();
        //Hit sålänge dealer behöver kort
        while (blackjackGame.DealerNeedsCard())
        {
            await DealerHit();

        }
        
    }

    private async Task PlayerHit()
    {
        string imageSource = blackjackGame.PlayerHit();
        await RenderPlayerCard(imageSource);
         
    }

    private async Task DealerHit()
    {
        string imageSource = blackjackGame.DealerHit();
        await RenderDealerCard(imageSource);
        
    }

    private void UpdatePlayerScore()
    {
        PlayerScore.Text = $"{blackjackGame.GetPlayerScore()}";
    }

    private void UpdateDealerScore()
    {
        //dealerPoints = blackjackGame.GetDealerScore();
        DealerScore.Text = $"{blackjackGame.GetDealerScore()}";
    }

    private async Task ShowDealerCard()
    {
        var card = (CardContentView)DealerCards.Children[1];

        card.IsHidden = false;

        await card.FlipAsync();

        UpdateDealerScore();
    }
    private void CheckInitialGameState()
    {
        
    }

}
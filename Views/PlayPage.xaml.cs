

using DwarfBlackjack.Classes;
using DwarfBlackjack.Views;
using Microsoft.Maui.Layouts;
using System.ComponentModel;

namespace DwarfBlackjack.Views;

public partial class PlayPage : ContentPage
{
    private int playerScore = 0;
    private int dealerScore = 0;
    private int hiddenDealerScore = 0;
    private const double CardAspectRatio = 168.0 / 240.0; //bildstorlek på korten
    private const double CardSpacingRatio = 0.6; //kort överlappar varandra 40%

    

    private BlackjackGame blackjackGame = new BlackjackGame();

    public PlayPage()
	{
		InitializeComponent();

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
    }
    private async Task GivePlayerCard(string cardText)
    {
        var card = new Views.CardContentView(cardText);

        PlayerCards.Children.Add(card);
        PositionCards(PlayerCards);
        
        await card.AnimateCardIn(Spelplan.Height);
        await card.FlipAsync();

        UpdatePlayerScore();
    }

    private async Task GiveDealerCard(string cardText)
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
    private void PositionCards(AbsoluteLayout container)
    {
        int count = container.Children.Count;
        /*if (count == 0 || container.Width <= 0 || container.Height <= 0)
            return;*/
        double cardHeight = container.Height * 0.8;
        double cardWidth = cardHeight * CardAspectRatio;

        double spacing = cardWidth * CardSpacingRatio;
        double totalWidth = cardWidth + (count - 1) * spacing;
        double startX = (container.Width - totalWidth) / 2;
        double y = (container.Height - cardHeight) / 2;
        
        for (int i = 0; i < count; i++)
        {
            
            var card = (View)container.Children[i];
            double x = startX + i * spacing;
            // Add the card at its final layout position
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
        await PlayerHit();
    }

    private async Task PlayerHit()
    {
        Card card = blackjackGame.PlayerHit();
        await GivePlayerCard(card.ImageSource);
         
    }

    private async Task DealerHit()
    {
        Card card = blackjackGame.DealerHit();
        await GiveDealerCard(card.ImageSource);
        
    }

    private void UpdatePlayerScore()
    {
        playerScore = blackjackGame.GetPlayerScore();
        PlayerScore.Text = $"{playerScore}";
    }

    private void UpdateDealerScore()
    {
        dealerScore = blackjackGame.GetDealerScore();
        DealerScore.Text = $"{dealerScore}";
    }

    

    
}
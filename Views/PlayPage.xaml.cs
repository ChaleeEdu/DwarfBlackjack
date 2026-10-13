

using DwarfBlackjack.Classes;
using DwarfBlackjack.Views;
using Microsoft.Maui.Layouts;
using System.ComponentModel;

namespace DwarfBlackjack.Views;

public partial class PlayPage : ContentPage
{
    
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
        GiveInitialCards();
        
    }
    private async Task GiveInitialCards()
    {
        
        await GivePlayerCard("card_hearts_02.png");

        await Task.Delay(300);

        
        await GiveDealerCard("card_spades_08.png");

        await Task.Delay(300);

        
        await GivePlayerCard("card_hearts_k.png");

        await Task.Delay(300);

       
        await GiveDealerCard("card_spades_q.png");

        await Task.Delay(300);
        
    }
    private async Task GivePlayerCard(string cardText)
    {
        var card = new Views.CardContentView(cardText);

        PlayerCards.Children.Add(card);
        PositionCards(PlayerCards);

        await card.AnimateCardIn(
            Spelplan.Height
        );
        await card.FlipAsync();
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
        System.Diagnostics.Debug.WriteLine($"Container: {container.Width} x {container.Height}" +
            $"Card: {cardWidth} x {cardHeight} TotalWidth: {totalWidth}");
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
        

        await GivePlayerCard("card_spades_k.png");
    }

    private async void OnStandClicked(object sender, EventArgs e)
    {
        
        GameStatus.Text = "Dealer's turn";
        
        await GivePlayerCard("card_diamonds_04.png");
    }

    

    
}
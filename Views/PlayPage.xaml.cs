using DwarfBlackjack.Classes;
using Microsoft.Maui.Layouts;

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
        SetButtonsEnabled(false);
        await PlayerHit();
        await DealerHit();
        await PlayerHit();
        await DealerHit();
        await CheckPlayerHand();
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
        await Task.Yield();

        SetButtonsEnabled(false);
        //GameStatus.Text = "Your turn";
        await PlayerHit();
        await CheckPlayerHand();
        
    }

    private async void OnStandClicked(object sender, EventArgs e)
    {
        await Task.Yield();

        SetButtonsEnabled(false);
        GameStatus.Text = "Dealer's turn";

        DealerTurn();
        
        
    }

    
    private async void OnAgainClicked(object sender, EventArgs e)
    {
        await Task.Yield();
        //blackjackGame.PlayAgain();

        PlayerCards.Children.Clear();
        DealerCards.Children.Clear();

        PlayerScore.Text = "0";
        DealerScore.Text = "0";

        HideButtons(false);
        SetButtonsEnabled(true);

        await GiveInitialCards();


    }

    private void OnQuitClicked(object sender, EventArgs e)
    {
        Application.Current?.Quit();
    }

    private async Task PlayerHit()
    {
        string imageSource = blackjackGame.PlayerHit();
        
        var card = new Views.CardContentView(imageSource);

        PlayerCards.Children.Add(card);
        PositionCards(PlayerCards);

        await card.AnimateCardIn(Spelplan.Height);
        await card.FlipAsync();

        UpdatePlayerScore();

        //await CheckPlayerHand();
        
         
    }

    

    private async Task DealerHit()
    {
        string imageSource = blackjackGame.DealerHit();
        //await RenderDealerCard(imageSource);
        var card = new Views.CardContentView(imageSource);
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
    private async void DealerTurn()
    {
        // Vänd det dolda kortet
        await ShowDealerCard();
        if (blackjackGame.DealerHasBlackjack())
        {
            GameStatus.Text = "Dealer has Blackjack!";
            return;
        }

        while (blackjackGame.DealerNeedsCard())
        {
            await DealerHit();
            await Task.Delay(500);

        }
        ShowWinner();
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
    private async Task CheckPlayerHand()
    {
        if (blackjackGame.PlayerHasBlackjack())
        {
            await ShowDealerCard();

            if (blackjackGame.DealerHasBlackjack())
            {
                GameStatus.Text = "Both have Blackjack! Dealer wins!";
            }
            else
            {
                GameStatus.Text = "Blackjack! You win!";
            }
            HideButtons(true);
            return;
        }
        

        else if (blackjackGame.IsBust())
        {
            GameStatus.Text = "Bust! Dealer wins!";
            await ShowDealerCard();
            HideButtons(true);
            return;
        }
        else if (blackjackGame.Has21())
        {

            GameStatus.Text = "Dealer's turn";

            DealerTurn();
            return;
        }
        else
            SetButtonsEnabled(true);

        
    }

    private void ShowWinner()
    {
        string winner = blackjackGame.CheckWinner();

        if (winner == "Player")
        {
            GameStatus.Text = "You win!";
        }
        else if (winner == "Dealer")
        {
            GameStatus.Text = "Dealer wins!";
        }
        else
        {
            GameStatus.Text = "Push!";
        }
        HideButtons(true);
    }

    private void SetButtonsEnabled(bool state)
    {
        HitButton.IsEnabled = state;
        StandButton.IsEnabled = state;
    }
    private void HideButtons(bool state)
    {
        HitButton.IsVisible = !state;
        StandButton.IsVisible = !state;
        AgainButton.IsVisible = state;
        QuitButton.IsVisible = state;
    }


}


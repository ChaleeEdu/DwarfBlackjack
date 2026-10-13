using DwarfBlackjack.Classes;
using Microsoft.Maui.Layouts;

namespace DwarfBlackjack.Views;

public partial class CardContentView : ContentView
{

    public bool IsFlipped { get; set; }
    public bool Animated {  get; set; }

    public bool IsHidden {  get; set; }
    bool isFlipping = false;
	public CardContentView(string cardSource)
	{
		InitializeComponent();
        IsFlipped = false;
        Animated = false;
        IsHidden = false;
        this.CardFront.Source = cardSource;
      
    }

    public async Task AnimateCardIn(double startY)
    {
        
        TranslationY = -startY;
        
        await Task.WhenAll(this.TranslateToAsync(0, 0, 600, Easing.Linear), this.RotateToAsync(360, 600));

        Animated = true;
    }
    //flippa kort baksida till framsida
    public async Task FlipAsync()
    {
        if (IsHidden)
            return;
        if (isFlipping)
            return;
        isFlipping = true;
        try
        {

            await this.RotateYToAsync(90, 150, Easing.CubicIn);
            IsFlipped = true;

            CardFront.IsVisible = true;
            CardBack.IsVisible = false;

            
            await this.RotateYToAsync(0, 150, Easing.CubicOut);
        }
        finally
        {
            isFlipping = false;
        }

    }
    
}
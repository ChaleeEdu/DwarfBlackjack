namespace DwarfBlackjack.Views;

public class PlayPage : ContentPage
{
	public PlayPage()
	{
		int playerValue = 0;
		int dealerValue = 0; //Hur gömmer vi andra kortet?
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}
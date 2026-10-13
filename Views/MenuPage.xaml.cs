
namespace DwarfBlackjack.Views;

public partial class MenuPage : ContentPage
{
    //int count = 0;
    

    public MenuPage()
	{
		InitializeComponent();

        
    }
    private async void OnPlayClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PlayPage));
    }


}
using DwarfBlackjack.Classes;

namespace DwarfBlackjack
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        Deck deck = new Deck();

        public MainPage()
        {
            InitializeComponent();
            deck.Shuffle();


        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
      
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}

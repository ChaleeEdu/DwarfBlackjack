using DwarfBlackjack.Views;

namespace DwarfBlackjack
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PlayPage), typeof(PlayPage));
        }
    }
}

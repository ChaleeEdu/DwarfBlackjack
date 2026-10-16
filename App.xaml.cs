using Microsoft.Extensions.DependencyInjection;

namespace DwarfBlackjack
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        /*protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }*/
        protected override Window CreateWindow(IActivationState? activationState)
        {
            const int newWidth = 480;
            const int newHeight = 800;

            return new Window(new AppShell())
            {
                Width = newWidth,
                Height = newHeight,
                X = 20, // Optional: position from left
                Y = 20 // Optional: position from top
            };
        }
    }
}
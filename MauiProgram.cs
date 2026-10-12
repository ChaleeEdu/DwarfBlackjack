using Microsoft.Extensions.Logging;

namespace DwarfBlackjack
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("PixelifySans-Regular.ttf", "PixelifySansRegular");
                    fonts.AddFont("PixelifySans-Semibold.ttf", "PixelifySansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

﻿using Microsoft.Extensions.Logging;
using Microsoft.Maui.Maps;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Maps;

namespace MapsDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiMaps()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG || WINDOWS
        builder.Logging.AddDebug();
        builder.UseMauiCommunityToolkitMaps("AmO8YdGUtzObHvwdz_m1zwuL_ZbHYYZYu2S0F6lR80Gz3VTkoKFAt254DJT1LUeZ");
#endif  


        return builder.Build();
    }
}
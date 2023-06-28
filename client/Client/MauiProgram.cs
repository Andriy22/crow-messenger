﻿using Material.Components.Maui.Extensions;
using Microsoft.Extensions.Logging;

namespace Client;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder
           .UseMaterialComponents(new List<string>
           {
                "OpenSans-Regular.ttf",
				"OpenSans-SemiBold.ttf",
           });

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

﻿using Capsium;
using Capsium.Foundation.ICs.IOExpanders;
using Capsium.Foundation.Leds;

public class CapsiumApp : App<Windows>
{
    RgbLed rgbLed;

    public override Task Initialize()
    {
        Console.WriteLine("Creating Outputs");

        var expander = new Ft232h();

        rgbLed = new RgbLed(
            expander.Pins.C2,
            expander.Pins.C1,
            expander.Pins.C0);

        return Task.CompletedTask;
    }

    public override async Task Run()
    {
        while (true)
        {
            Resolver.Log.Info("Going through each color...");
            for (int i = 0; i < (int)RgbLedColors.count; i++)
            {
                rgbLed.SetColor((RgbLedColors)i);
                await Task.Delay(500);
            }

            await Task.Delay(1000);

            Resolver.Log.Info("Blinking through each color (on 500ms / off 500ms)...");
            for (int i = 0; i < (int)RgbLedColors.count; i++)
            {
                await rgbLed.StartBlink((RgbLedColors)i);
                await Task.Delay(3000);
                await rgbLed.StopAnimation();
                rgbLed.IsOn = false;
            }

            await Task.Delay(1000);

            Resolver.Log.Info("Blinking through each color (on 1s / off 1s)...");
            for (int i = 0; i < (int)RgbLedColors.count; i++)
            {
                await rgbLed.StartBlink((RgbLedColors)i, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
                await Task.Delay(3000);
                await rgbLed.StopAnimation();
                rgbLed.IsOn = false;
            }

            await Task.Delay(1000);
        }
    }

    public static async Task Main(string[] args)
    {
        await CapsiumOS.Start(args);
    }
}
﻿using Capsium;
using Capsium.Foundation.Displays.Lcd;
using Capsium.Foundation.ICs.IOExpanders;

public class CapsiumApp : App<Windows>
{
    private CharacterDisplay? display;

    public override Task Initialize()
    {
        Console.WriteLine("Creating Outputs");

        var expander = new Ft232h();

        display = new CharacterDisplay
            (
                pinRS: expander.Pins.C5,
                pinE: expander.Pins.C4,
                pinD4: expander.Pins.C3,
                pinD5: expander.Pins.C2,
                pinD6: expander.Pins.C1,
                pinD7: expander.Pins.C0,
                rows: 4, columns: 20
            );

        return Task.CompletedTask;
    }

    void UpdateCountdown()
    {
        var today = DateTime.Now;

        display?.WriteLine($"{today.ToString("MMMM dd, yyyy")}", 2);
        display?.WriteLine($"{today.ToString("hh:mm:ss tt")}", 3);
    }

    public override Task Run()
    {
        display?.WriteLine($"Wilderness Labs", 0);
        display?.WriteLine($"Capsium.Windows ", 1);

        while (true)
        {
            UpdateCountdown();
            Thread.Sleep(1000);
        }
    }

    public static async Task Main(string[] args)
    {
        await CapsiumOS.Start(args);
    }
}
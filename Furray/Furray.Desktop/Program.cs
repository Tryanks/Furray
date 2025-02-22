using Avalonia;
using Avalonia.ReactiveUI;
using Furray.Desktop.Common;

namespace Furray.Desktop;

internal class Program
{
    public static EventWaitHandle ProgramStarted;

    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        OnStartup(args);

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    private static void OnStartup(string[]? Args)
    {
        if (Utils.IsWindows())
        {
            var exePathKey = Utils.GetMd5(Utils.GetExePath());
            var rebootas = (Args ?? Array.Empty<string>()).Any(t => t == Global.RebootAs);
            ProgramStarted = new EventWaitHandle(false, EventResetMode.AutoReset, exePathKey, out var bCreatedNew);
            if (!rebootas && !bCreatedNew)
            {
                ProgramStarted.Set();
                Environment.Exit(0);
            }
        }
        else
        {
            _ = new Mutex(true, "Furray", out var bOnlyOneInstance);
            if (!bOnlyOneInstance)
            {
                Environment.Exit(0);
            }
        }
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            //.WithInterFont()
            .WithFontByDefault()
            .LogToTrace()
            .UseReactiveUI()
            .With(new MacOSPlatformOptions { ShowInDock = false });
    }
}

using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Furray.Desktop.Converters;

public class DelayColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        int.TryParse(value?.ToString(), out var delay);

        if (delay <= 0)
        {
            return new SolidColorBrush(Colors.Red);
        }

        if (delay <= 500)
        {
            return new SolidColorBrush(Colors.Green);
        }

        return new SolidColorBrush(Colors.IndianRed);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}

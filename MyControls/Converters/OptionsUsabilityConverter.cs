using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Converters;

[ValueConversion(typeof(string[]), typeof(string))]
public class OptionsUsabilityConverter : IValueConverter
{
    /// <summary>
    /// このRadioButtonに対応するOptionを返すコンバータ
    /// </summary>
    /// <param name="value">各RadioButtonのOption配列</param>
    /// <param name="targetType"></param>
    /// <param name="parameter">RadioButtonの位置</param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            // Bindingされている値（各RadioButtonのOption）
            var options = (string[]) value;

            // xaml上から指定された値（RadioButtonの位置情報）
            var positionValue = int.Parse((string)parameter);

            // このRadioButtonに対応するOptionが存在する場合はそのOptionを返す
            if(positionValue < options.Length)
            {
                return options[positionValue];
            }
            // 存在しない場合は空文字を返す
            else
            {
                return string.Empty;
            }
        }
        catch(Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e);
            return DependencyProperty.UnsetValue;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

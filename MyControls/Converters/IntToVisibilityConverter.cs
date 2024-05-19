using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Converters;

[ValueConversion(typeof(int), typeof(Visibility))]
public class IntToVisibilityConverter : IValueConverter
{
    /// <summary>
    /// 使用しないRadioButtonを非表示にするためのコンバータ
    /// </summary>
    /// <param name="value">使用するRadioButtonの数</param>
    /// <param name="targetType"></param>
    /// <param name="parameter">RadioButtonの位置</param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            // Bindingされている値（使用するRadioButtonの数）
            var visibleCount = (int)value;

            // xaml上から指定された値（RadioButtonの位置情報）
            var positionValue = int.Parse((string)parameter);

            // RadioButtonの位置が使用範囲内の場合のみ表示とする
            if(positionValue < visibleCount)
            {
                return Visibility.Visible;
            }
            else
            {
                // 非表示とし、余白は作らない
                return Visibility.Collapsed;
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

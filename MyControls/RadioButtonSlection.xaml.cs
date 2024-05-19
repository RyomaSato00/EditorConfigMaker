using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyControls;

/// <summary>
/// Interaction logic for RadioButtonSlection.xaml
/// </summary>
public partial class RadioButtonSlection : UserControl
{
    // 初期化処理
    public RadioButtonSlection()
    {
        InitializeComponent();

        // RadioButtonをグルーピングする
        var guid = Guid.NewGuid().ToString();
        Button0.GroupName = guid;
        Button1.GroupName = guid;
        Button2.GroupName = guid;
        Button3.GroupName = guid;
        Button4.GroupName = guid;
    }

    /// <summary> 選択中の項目のインデックス（初期値：-1 ※0にすると初回にUIが更新されないことがある） </summary>
    [Bindable(true)]
    public int SelectedIndex
    {
        get { return (int)GetValue(SelectedIndexProperty); }
        set { SetValue(SelectedIndexProperty, value); }
    }
    public static readonly DependencyProperty SelectedIndexProperty =
        DependencyProperty.Register(nameof(SelectedIndex), typeof(int), typeof(RadioButtonSlection), new PropertyMetadata(-1, OnSelectedIndexChanged));

    private static void OnSelectedIndexChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        // イベント呼び出し元がRadioButtonSelectionではない場合は処理を終了
        if (sender is not RadioButtonSlection radioButtonSelection) return;

        // 選択中のインデックスを取得
        var selectedIndex = (int)e.NewValue;

        // RadioButtonの選択状態をリセット
        radioButtonSelection.Button0.IsChecked = false;
        radioButtonSelection.Button1.IsChecked = false;
        radioButtonSelection.Button2.IsChecked = false;
        radioButtonSelection.Button3.IsChecked = false;
        radioButtonSelection.Button4.IsChecked = false;

        // 選択中のインデックスに応じてRadioButtonの選択状態を変更
        switch (selectedIndex)
        {
            case 0:
                radioButtonSelection.Button0.IsChecked = true;
                break;
            case 1:
                radioButtonSelection.Button1.IsChecked = true;
                break;
            case 2:
                radioButtonSelection.Button2.IsChecked = true;
                break;
            case 3:
                radioButtonSelection.Button3.IsChecked = true;
                break;
            case 4:
                radioButtonSelection.Button4.IsChecked = true;
                break;
            default:
                break;
        }
    }

    /// <summary> 変数値選択肢 </summary>
    [Bindable(true)]
    public string[] Options
    {
        get { return (string[])GetValue(OptionsProperty); }
        set { SetValue(OptionsProperty, value); }
    }
    public static readonly DependencyProperty OptionsProperty =
        DependencyProperty.Register(nameof(Options), typeof(string[]), typeof(RadioButtonSlection), new PropertyMetadata(new string[5]));

    /// <summary> 各選択肢の内容説明文 </summary>
    [Bindable(true)]
    public string[] OptionDescriptions
    {
        get { return (string[])GetValue(OptionDescriptionsProperty); }
        set { SetValue(OptionDescriptionsProperty, value); }
    }
    public static readonly DependencyProperty OptionDescriptionsProperty =
        DependencyProperty.Register(nameof(OptionDescriptions), typeof(string[]), typeof(RadioButtonSlection), new PropertyMetadata(new string[5]));

    /// <summary> RadioButtonをいくつ使用するか（初期値：0） </summary>
    [Bindable(true)]
    public int SelectionCount
    {
        get { return (int)GetValue(SelectionCountProperty);}
        set {SetValue(SelectionCountProperty, value);}
    }
    public static readonly DependencyProperty SelectionCountProperty =
        DependencyProperty.Register(nameof(SelectionCount), typeof(int), typeof(RadioButtonSlection), new PropertyMetadata(0));

    private void Button0_Checked(object sender, RoutedEventArgs e)
    {
        SelectedIndex = 0;
    }

    private void Button1_Checked(object sender, RoutedEventArgs e)
    {
        SelectedIndex = 1;
    }

    private void Button2_Checked(object sender, RoutedEventArgs e)
    {
        SelectedIndex = 2;
    }

    private void Button3_Checked(object sender, RoutedEventArgs e)
    {
        SelectedIndex = 3;
    }

    private void Button4_Checked(object sender, RoutedEventArgs e)
    {
        SelectedIndex = 4;
    }
}


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

using EdtCfg.APP.ViewModels;

namespace EdtCfg.APP.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _mainWindowViewModel;

    public MainWindow()
    {
        // UI初期化
        InitializeComponent();

        // ViewModel初期化
        _mainWindowViewModel = new MainWindowViewModel();

        // ViewとViewModelの紐づけ
        DataContext = _mainWindowViewModel;

        // ウィンドウを閉じるときにViewModelを破棄する
        Closing += (_, _) => _mainWindowViewModel.Dispose();
    }
}

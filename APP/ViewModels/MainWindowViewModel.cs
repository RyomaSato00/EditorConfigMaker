using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using EdtCfg.Models;

namespace EdtCfg.APP.ViewModels;

internal partial class MainWindowViewModel : ObservableObject, IDisposable
{
    // 初期化処理
    public MainWindowViewModel()
    {

    }

    // 終了処理
    public void Dispose()
    {
        
    }

    [ObservableProperty] private Branch[] _configParameters = Parameters.Tree;

    /// <summary> メッセージテキスト </summary>
    [ObservableProperty] private string _message = string.Empty;

    /// <summary>
    /// 処理実行コマンド
    /// </summary>
    [RelayCommand] private void Run()
    {
        // ダイアログボックスから出力先を取得

        // .editorconfigファイルを生成

        // 「生成した.editorconfigファイルを表示しますか？」
    }
}

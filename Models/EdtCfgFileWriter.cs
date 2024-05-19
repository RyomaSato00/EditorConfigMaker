using System.Text;

namespace EdtCfg.Models;

public class EdtCfgFileWriter : IDisposable
{
    /// <summary> 使用する改行コード </summary>
    public static readonly string NewLine = "\r\n";

    /// <summary> ファイルストリーム </summary>
    private readonly FileStream _fileStream;

    /// <summary> ファイル書き込み </summary>
    private readonly StreamWriter _streamWriter;

    // 初期化処理
    public EdtCfgFileWriter(string filePath)
    {
        // ファイルが存在する場合
        if(File.Exists(filePath))
        {
            // ファイルを開く（上書きするように設定）
            _fileStream = File.Open(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);

            // ファイルをutf-8（※BOMは含まないこと）で書き込むためのStreamWriterを作成
            _streamWriter = new StreamWriter(_fileStream, new UTF8Encoding(false));
        }
        // ファイルが存在しない場合
        else
        {
            // ファイルの親ディレクトリを取得
            var parent = Path.GetDirectoryName(filePath);

            // 親ディレクトリが存在しなければ作成する
            if(parent is not null && Directory.Exists(parent))
            {
                Directory.CreateDirectory(parent);
            }

            // ファイルを新規作成
            _fileStream = File.Create(filePath);

            // ファイルをutf-8（※BOMは含まないこと）で書き込むためのStreamWriterを作成
            _streamWriter = new StreamWriter(_fileStream, new UTF8Encoding(false));
        }

        // rootを書き込んでおく
        _streamWriter.Write($"root = true{NewLine}");
        WriteNewLine();
    }

    // 破棄処理
    public void Dispose()
    {
        // バッファに書き込むデータが残っていれば、ここで書き込む
        _streamWriter?.Flush();
        _streamWriter?.Dispose();
        _fileStream?.Dispose();
    }


    /// <summary>
    /// 各設定項目を書き込む
    /// </summary>
    /// <param name="parameters">各種設定項目</param>
    public void WriteParams(IEnumerable<ISingleParam> parameters)
    {
        // 各設定項目を書き込む
        foreach(var param in parameters)
        {
            _streamWriter.Write($"{param.Name} = {param.Value}{NewLine}");
        }
    }

    /// <summary>
    /// コメントを書き込む
    /// </summary>
    /// <param name="comments">コメント</param>
    public void WriteComments(string comments)
    {
        _streamWriter.Write($"# {comments}{NewLine}");
    }

    /// <summary>
    /// セクションを書き込む
    /// </summary>
    /// <param name="section">セクション</param>
    public void WriteSection(string section)
    {
        _streamWriter.Write($"[{section}]{NewLine}");
    }

    /// <summary>
    /// 空行を書き込む
    /// </summary>
    public void WriteNewLine()
    {
        _streamWriter.Write(NewLine);
    }
}

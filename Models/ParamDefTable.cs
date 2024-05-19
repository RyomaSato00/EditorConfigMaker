namespace EdtCfg.Models;

public static class ParamDefTable
{
    public static readonly StringStyleParamDef indent_style = new()
    {
        Name = "indent_style",
        Description = "インデントに「スペース」「タブ」どちらを使うか決めます。",
        Options = ["space", "tab"],
        OptionDescriptions = ["スペース", "タブ"],
    };

    public static readonly StringStyleParamDef end_of_line = new()
    {
        Name = "end_of_line",
        Description = "改行コードを決定します。",
        Options = ["lf", "cr", "crlf"],
        OptionDescriptions = ["", "", ""],
    };

    public static readonly StringStyleParamDef trim_trailing_whitespace = new()
    {
        Name = "trim_trailing_whitespace",
        Description = "trueを設定すると、ファイルの保存時に行末（改行文字より前）の空白文字を削除します。",
        Options = ["true", "false"],
        OptionDescriptions = ["", ""],
    };

    public static readonly StringStyleParamDef insert_final_newline = new()
    {
        Name = "insert_final_newline",
        Description = "trueを設定すると、ファイルの保存時において末尾に空行が１行追加されます。",
        Options = ["true", "false"],
        OptionDescriptions = ["", ""],
    };
}

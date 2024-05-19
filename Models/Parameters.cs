namespace EdtCfg.Models;

public class Parameters
{
    private static readonly ParameterDefine cpp_indent_braces = new()
    {
        Name = "cpp_indent_braces",
        Description = "中かっこのインデント",
        Options = ["true", "false"],
        OptionCount = 2,
        SelectedIndex = 0,
    };

    public static Branch[] Tree =>
    [
        new Branch{Name="General"},
        new Branch{Name="Advanced"},
        new Branch{Name="Code Cleanup"},
        new Branch{Name="File Extension"},
        new Branch{Name="C++", Children=
        [
            new Branch{Define=cpp_indent_braces, Name=cpp_indent_braces.Name},
        ]},
    ];
}

public record Branch
{
    /// <summary> この要素の名前 </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary> この要素に対応する定義 </summary>
    public ParameterDefine Define { get; init; } = new();

    /// <summary> 子要素がある場合はその子要素、ない場合はnull </summary>
    public Branch[]? Children { get; init; } = null;
}

public record ParameterDefine
{
    /// <summary> 変数名 </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary> 変数説明 </summary>
    public string Description { get; init; } = string.Empty;

    /// <summary> 変数値の選択肢（初期値は string.Empty × 5 の配列） </summary>
    public string[] Options { get; init; } = Enumerable.Repeat<string>(string.Empty, 5).ToArray();

    /// <summary> 各変数値の説明（初期値は string.Empty × 5 の配列） </summary>
    public string[] OptionDescriptions { get; init; } = Enumerable.Repeat<string>(string.Empty, 5).ToArray();

    /// <summary> 選択肢の数 </summary>
    public int OptionCount { get; init; } = 0;

    /// <summary> 選択肢の中で選択されているものに対応するインデックス </summary>
    public int SelectedIndex { get; init; } = 0;
}

namespace EdtCfg.Models;

/// <summary>
/// 設定値がstring型の場合の各種定義
/// </summary>
/// <value></value>
public record StringStyleParamDef
{
    /// <summary> 設定項目名 </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary> 設定項目説明 </summary>
    public string Description { get; init; } = string.Empty;

    /// <summary> 設定項目の選択肢 </summary>
    public IReadOnlyList<string> Options { get; init; } = [];

    /// <summary> 各選択肢の説明 </summary>
    public IReadOnlyList<string> OptionDescriptions { get; init; } = [];

    /// <summary> 選択肢の数 </summary>
    public int OptionCount => Options.Count;
}

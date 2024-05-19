namespace EdtCfg.Models;

/// <summary>
/// 設定値がstring型の場合の各種情報
/// </summary>
public class StringStyleParam : ISingleParam
{
    /// <summary> 設定項目各種定義 </summary>
    public StringStyleParamDef Define { get; init; } = new();

    /// <summary> 設定項目名 </summary>
    public string Name => Define.Name;

    /// <summary> 設定値 </summary>
    public string Value { get; set; } = string.Empty;
}

namespace EdtCfg.Models;

public interface ISingleParam
{
    /// <summary> パラメータ名 </summary>
    public string Name { get; }

    /// <summary> パラメータの値 </summary>
    public string Value { get; }
}

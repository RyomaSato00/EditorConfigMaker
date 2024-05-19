using EdtCfg.Models;

namespace EdtCfg.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        StringStyleParam[] parameters =
        [
            new StringStyleParam
            {
                Define = ParamDefTable.end_of_line,
                Value = "crlf"
            },
            new StringStyleParam
            {
                Define = ParamDefTable.indent_style,
                Value = "space"
            },
            new StringStyleParam
            {
                Define = ParamDefTable.insert_final_newline,
                Value = "true"
            },
            new StringStyleParam
            {
                Define = ParamDefTable.trim_trailing_whitespace,
                Value = "true"
            },
        ];

        using (var writer = new EdtCfgFileWriter(@"C:\Users\Ryoma\Downloads\.editorconfig"))
        {
            writer.WriteSection("*cpp");
            writer.WriteParams(parameters);
        }

        Assert.True(File.Exists(@"C:\Users\Ryoma\Downloads\.editorconfig"));
    }
}

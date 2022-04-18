namespace DotNetTests;

[Nest.ElasticsearchType(IdProperty = nameof(Ico))]
public class MyData
{
    public string Ico { get; set; }
    public string Jmeno { get; set; }
    [Nest.Date]
    public DateTime LastSaved { get; set; }
}
using System.Text.Json.Nodes;
using static ParseDontValidate.Parser;
using static ParseDontValidate.Processor;

string[] filenames = ["./command1.json", "./command2.json", "./command3.json", "./command4.json"];

foreach (var filename in filenames)
{
    var text = File.ReadAllText(filename);
    var json = JsonNode.Parse(text);
    var command = Parse(json);
    var result = Process(command);
    Console.WriteLine(result);
}

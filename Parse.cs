using System.Text.Json.Nodes;
using ParseDontValidate.Model;

namespace ParseDontValidate;

public static class Parser
{
    public static ICommand Parse(JsonNode? json) => json?["command"]?.ToString() switch
    {
        "TrimMessage" => new TrimMessage(
            json["message"]?.ToString() ?? "",
            int.Parse(json["maxLength"]?.ToString() ?? "")
            ),
        "GetCurrentTime" => new GetCurrentTime(),
        "GenerateRandomNumber" => new GenerateRandomNumber(
            int.Parse(json["min"]?.ToString() ?? ""),
            int.Parse(json["max"]?.ToString() ?? "")
            ),
        _ => new Invalid()
    };
}
using ParseDontValidate.Model;

namespace ParseDontValidate;

public static class Processor
{
    private static readonly Random Random = new();

    public static string Process(ICommand command) => command switch
    {
        TrimMessage a => TrimMessage(a),
        GetCurrentTime a => GetCurrentTime(a),
        GenerateRandomNumber a => GenerateRandomNumber(a),
        _ => ReportUnknownCommand()
    };
    
    private static string TrimMessage(TrimMessage command) =>
        command.Message.Length > command.MaxLength
            ? command.Message[..command.MaxLength] + "…"
            : command.Message;
    
    private static string GetCurrentTime(GetCurrentTime command) =>
        $"The current time is {DateTime.Now.ToShortTimeString()}.";

    private static string GenerateRandomNumber(GenerateRandomNumber command) =>
        $"Your random number is {Random.Next(command.Min, command.Max)}.";

    private static string ReportUnknownCommand() => "I don't know what to do now.";
}
public class GameStartResult
{
    public int GameId { get; set; }

    public Dictionary<string, int> PlayerScores { get; set; } = new();
}
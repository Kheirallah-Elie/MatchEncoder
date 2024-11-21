using System.ComponentModel.DataAnnotations.Schema;

[Table("MatchPlayer")]
public class MatchPlayer
{
    public int MatchId { get; set; }
    public Match? Match { get; set; }

    public int PlayerId { get; set; }
    public Player? Player { get; set; }
}

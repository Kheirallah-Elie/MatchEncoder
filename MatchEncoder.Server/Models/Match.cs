using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Match")]
public class Match
{
    public int Id { get; set; }
    public int MatchNumber { get; set; }
    public string? EventName { get; set; }
    public DateTime MatchDateTime { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public int? NumberOfQuarterTime { get; set; }
    public int? DurationOfTimeout { get; set; }

    // Foreign keys
    public int TeamAId { get; set; }
    public Team? TeamA { get; set; }
    public int TeamBId { get; set; }
    public Team? TeamB { get; set; }

    public ICollection<MatchPlayer>? MatchPlayers { get; set; }
    public ICollection<Event>? Events { get; set; } // Navigation for events
}

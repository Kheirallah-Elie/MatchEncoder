namespace MatchEncoder.Server.DTO
{
    public class MatchCreateDto
    {
        public string EventName { get; set; }
        public DateTime MatchDateTime { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int TeamAId { get; set; }
        public int TeamBId { get; set; }
        public string TeamBname { get; set; }
        public List<int> SelectedTeamAPlayers { get; set; }
        public List<int> SelectedTeamBPlayers { get; set; }
        public int? NumberOfQuarterTime { get; set; }
        public int? DurationOfTimeout { get; set; }
    }

}

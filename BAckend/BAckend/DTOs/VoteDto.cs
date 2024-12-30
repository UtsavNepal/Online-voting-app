namespace OnlineVotingApp.API.DTOs
{
    public class VoteDto
    {
        public int CandidateId { get; set; }
        public int VoteCount { get; set; }
        public string Party { get; set; }
    }
}

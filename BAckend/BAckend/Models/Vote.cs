
using System;

namespace OnlineVotingApp.API.Models
{
    public class Vote
    {
        public int VoteId { get; set; }
        public int CandidateId { get; set; }
        public int VoteCount { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Party { get; set; }

        // Navigation Property to Candidate
        public Candidate Candidate { get; set; }
    }
}

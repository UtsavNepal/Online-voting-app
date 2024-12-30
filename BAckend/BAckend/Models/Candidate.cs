using System.Collections.Generic;

namespace OnlineVotingApp.API.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}

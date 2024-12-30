using OnlineVotingApp.API.Models;
using System.Threading.Tasks;

namespace OnlineVotingApp.API.Repositories
{
    public interface IVoteRepository
    {
        Task<Vote> GetVoteByCandidateIdAsync(int candidateId);
        Task AddVoteAsync(Vote vote);
        Task UpdateVoteAsync(Vote vote);
    }
}

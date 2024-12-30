using OnlineVotingApp.API.DTOs;
using System.Threading.Tasks;

namespace OnlineVotingApp.API.Services
{
    public interface IVoteService
    {
        Task AddOrUpdateVoteAsync(VoteDto voteDto);
        Task<VoteDto> GetVotesByCandidateIdAsync(int candidateId);
    }
}

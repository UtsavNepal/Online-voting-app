using OnlineVotingApp.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineVotingApp.API.Repositories
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetAllCandidatesAsync();
        Task<Candidate> GetCandidateByIdAsync(int id);
        Task AddCandidateAsync(Candidate candidate);
        Task DeleteCandidateAsync(int id);
    }
}

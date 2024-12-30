using OnlineVotingApp.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineVotingApp.API.Services
{
    public interface ICandidateService
    {
        Task<IEnumerable<CandidateDto>> GetAllCandidatesAsync();
        Task AddCandidateAsync(CandidateDto candidateDto);
        Task RemoveCandidateAsync(int candidateId);

    }
}

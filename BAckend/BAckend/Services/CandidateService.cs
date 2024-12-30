using OnlineVotingApp.API.DTOs;
using OnlineVotingApp.API.Models;
using OnlineVotingApp.API.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVotingApp.API.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<IEnumerable<CandidateDto>> GetAllCandidatesAsync()
        {
            var candidates = await _candidateRepository.GetAllCandidatesAsync();
            return candidates.Select(c => new CandidateDto
            {
                CandidateId = c.Id,
                Name = c.Name,
                Party = c.Party
            });
        }

        public async Task AddCandidateAsync(CandidateDto candidateDto)
        {
            var candidate = new Candidate
            {
                Name = candidateDto.Name,
                Party = candidateDto.Party 
            };
            if (string.IsNullOrWhiteSpace(candidateDto.Party))
            {
                throw new ArgumentException("Party cannot be null or empty.");
            }

            await _candidateRepository.AddCandidateAsync(candidate);
        }

        public async Task RemoveCandidateAsync(int candidateId)
        {
            var candidate = await _candidateRepository.GetCandidateByIdAsync(candidateId);
            if (candidate != null)
            {
                await _candidateRepository.DeleteCandidateAsync(candidateId);
            }
        }

    }
}

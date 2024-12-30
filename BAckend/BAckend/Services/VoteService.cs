using OnlineVotingApp.API.DTOs;
using OnlineVotingApp.API.Models;
using OnlineVotingApp.API.Repositories;
using System;
using System.Threading.Tasks;

namespace OnlineVotingApp.API.Services
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;
        private readonly ICandidateRepository _candidateRepository;

        public VoteService(IVoteRepository voteRepository, ICandidateRepository candidateRepository)
        {
            _voteRepository = voteRepository;
            _candidateRepository = candidateRepository;
        }

        public async Task AddOrUpdateVoteAsync(VoteDto voteDto)
        {
            var candidate = await _candidateRepository.GetCandidateByIdAsync(voteDto.CandidateId);
            if (candidate == null)
            {
                throw new KeyNotFoundException("Candidate not found.");
            }

            var vote = await _voteRepository.GetVoteByCandidateIdAsync(voteDto.CandidateId);
            if (vote == null)
            {
                vote = new Vote
                {
                    CandidateId = voteDto.CandidateId,
                    VoteCount = voteDto.VoteCount,
                    LastUpdated = DateTime.Now
                };

                await _voteRepository.AddVoteAsync(vote);
            }
            else
            {
                vote.VoteCount = voteDto.VoteCount;
                vote.LastUpdated = DateTime.Now;

                await _voteRepository.UpdateVoteAsync(vote);
            }
        }

        public async Task<VoteDto> GetVotesByCandidateIdAsync(int candidateId)
        {
            var vote = await _voteRepository.GetVoteByCandidateIdAsync(candidateId);
            if (vote == null)
            {
                return null;
            }

            return new VoteDto
            {
                CandidateId = vote.CandidateId,
                VoteCount = vote.VoteCount,
                Party = vote.Party
            };
        }
    }
}

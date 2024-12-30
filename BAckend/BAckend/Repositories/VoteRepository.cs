using Microsoft.EntityFrameworkCore;
using OnlineVotingApp.API.Data;
using OnlineVotingApp.API.Models;
using System.Threading.Tasks;

namespace OnlineVotingApp.API.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private readonly ApplicationDbContext _context;

        public VoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Vote> GetVoteByCandidateIdAsync(int candidateId)
        {
            return await _context.Votes
                .Include(v => v.Candidate)
                .FirstOrDefaultAsync(v => v.CandidateId == candidateId);
        }

        public async Task AddVoteAsync(Vote vote)
        {
            await _context.Votes.AddAsync(vote);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVoteAsync(Vote vote)
        {
            _context.Votes.Update(vote);
            await _context.SaveChangesAsync();
        }
    }
}

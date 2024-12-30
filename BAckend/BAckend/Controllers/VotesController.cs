using Microsoft.AspNetCore.Mvc;
using OnlineVotingApp.API.DTOs;
using OnlineVotingApp.API.Services;
using System.Threading.Tasks;

namespace OnlineVotingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly IVoteService _voteService;

        public VotesController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpGet("{candidateId}")]
        public async Task<IActionResult> GetVotesByCandidateId(int candidateId)
        {
            var vote = await _voteService.GetVotesByCandidateIdAsync(candidateId);
            if (vote == null)
            {
                return NotFound("No votes found for the given candidate.");
            }

            return Ok(vote);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateVote([FromBody] VoteDto voteDto)
        {
            try
            {
                await _voteService.AddOrUpdateVoteAsync(voteDto);
                return Ok("Vote recorded successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

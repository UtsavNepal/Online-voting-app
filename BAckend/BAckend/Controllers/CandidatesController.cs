using Microsoft.AspNetCore.Mvc;
using OnlineVotingApp.API.DTOs;
using OnlineVotingApp.API.Services;
using System.Threading.Tasks;

namespace OnlineVotingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            var candidates = await _candidateService.GetAllCandidatesAsync();
            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidate([FromBody] CandidateDto candidateDto)
        {
            await _candidateService.AddCandidateAsync(candidateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCandidate(int id)
        {
            await _candidateService.RemoveCandidateAsync(id);
            return NoContent();
        }
    }
}

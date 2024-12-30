using Microsoft.AspNetCore.Mvc;
using Online_Voting.DTos;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Online_Voting.Controllers
{
    public class VoteController : Controller
    {
        private readonly HttpClient _httpClient;

        public VoteController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            List<CandidateDto> candidates = new List<CandidateDto>();

            try
            {
                // Call the backend API to get the list of candidates
                var response = await _httpClient.GetAsync("https://localhost:5001/api/Candidates");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    candidates = JsonSerializer.Deserialize<List<CandidateDto>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                else
                {
                    // Handle API errors
                    ViewBag.ErrorMessage = "Failed to fetch candidates from the backend.";
                }
            }
            catch
            {
                // Handle HTTP or connection errors
                ViewBag.ErrorMessage = "An error occurred while connecting to the backend.";
            }

            return View(candidates);
        }
    }
}

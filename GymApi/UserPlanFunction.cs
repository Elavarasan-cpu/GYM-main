using GymApi.Data;
using GymApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GymApi
{
    public class UserPlanFunction
    {
        private readonly ILogger<UserPlanFunction> _logger;
        private readonly AppDbContext _context;

        public UserPlanFunction(AppDbContext context,ILogger<UserPlanFunction> logger)
        {
            _context = context;
            _logger = logger;
        }

        [Function("CreateUserPlan")]
        public async Task<IActionResult> CreateUserPlan(
    [HttpTrigger(AuthorizationLevel.Function, "post", Route = "userplans")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var userPlan = JsonConvert.DeserializeObject<UserPlan>(requestBody);

            if (userPlan == null || userPlan.UserId == 0 || userPlan.StartDate == default || userPlan.EndDate == default)
            {
                return new BadRequestObjectResult("Invalid data. UserId, StartDate, and EndDate are required.");
            }

            _context.UserPlans.Add(userPlan);
            await _context.SaveChangesAsync();

            return new OkObjectResult(userPlan);
        }

        [Function("GetUserPlans")]
        public async Task<IActionResult> GetUserPlans(
    [HttpTrigger(AuthorizationLevel.Function, "get", Route = "userplans/{userId:int}")] HttpRequest req,
    int userId)
        {
            var plans = await _context.UserPlans
                .Where(wl => wl.UserId == userId).ToListAsync();

            if (plans == null)
            {
                return new NotFoundObjectResult($"No plans found for User ID {userId}.");
            }
            return new OkObjectResult(plans);
        }

        [Function("UpdateUserPlan")]
        public async Task<IActionResult> UpdateUserPlan(
    [HttpTrigger(AuthorizationLevel.Function, "put", Route = "userplans/{id:int}")] HttpRequest req,
    int id)
        {
            // Find existing UserPlan by ID
            var existingPlan = await _context.UserPlans.FindAsync(id);
            if (existingPlan == null)
            {
                return new NotFoundObjectResult($"UserPlan with ID {id} not found.");
            }

            // Read and parse request body
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updatedData = JsonConvert.DeserializeObject<UserPlan>(requestBody);

            if (updatedData == null)
            {
                return new BadRequestObjectResult("Invalid JSON data.");
            }

            // Update fields
            if (!string.IsNullOrEmpty(updatedData.Plan))
                existingPlan.Plan = updatedData.Plan;

            if (updatedData.StartDate != default)
                existingPlan.StartDate = updatedData.StartDate;

            if (updatedData.EndDate != default)
                existingPlan.EndDate = updatedData.EndDate;

            existingPlan.ModifiedDate = DateTime.UtcNow;

            // Save changes
            await _context.SaveChangesAsync();

            return new OkObjectResult(existingPlan);
        }

    }
}

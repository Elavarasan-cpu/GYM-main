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
    public class Userweightlogs
    {
        private readonly ILogger<Userweightlogs> _logger;
        private readonly AppDbContext _context;
        public Userweightlogs(AppDbContext context, ILogger<Userweightlogs> logger)
        {
            _context = context;
            _logger = logger;
        }

        [Function("CreateUserWeightLog")]
        public async Task<IActionResult> CreateUserWeightLog(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "userweightlogs")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var weightLog = JsonConvert.DeserializeObject<UserWeightLog>(requestBody);

            if (weightLog == null || weightLog.UserId == 0 || weightLog.InWeight <= 0 || weightLog.OutWeight <= 0)
            {
                return new BadRequestObjectResult("Invalid data. UserId, InWeight, and OutWeight are required.");
            }

            weightLog.Date = weightLog.Date == default ? DateTime.UtcNow.Date : weightLog.Date;
            weightLog.CreatedDate = DateTime.UtcNow;

            _context.UserWeightLogs.Add(weightLog);
            await _context.SaveChangesAsync();

            return new OkObjectResult(weightLog);
        }

        [Function("GetUserWeightLogs")]
        public async Task<IActionResult> GetUserWeightLogs(
    [HttpTrigger(AuthorizationLevel.Function, "get", Route = "userweightlogs/{userId:int}")] HttpRequest req,
    int userId)
        {
            var weightLogs = await _context.UserWeightLogs
                .Where(wl => wl.UserId == userId)
                .OrderByDescending(wl => wl.Date)
                .ToListAsync();

            if (weightLogs.Count == 0)
            {
                return new NotFoundObjectResult($"No weight logs found for User ID {userId}.");
            }

            return new OkObjectResult(weightLogs);
        }


    }
}

using GymApi.Data;
using GymApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GymApi
{
    public class UserFunctions
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UserFunctions> _logger;

        public UserFunctions(AppDbContext context, ILogger<UserFunctions> logger)
        {
            _context = context;
            _logger = logger;
        }

        [Function("CreateUser")]
        public async Task<IActionResult> CreateUser(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "users")] HttpRequestData req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var user = JsonConvert.DeserializeObject<User>(requestBody);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new OkObjectResult(user);
        }

        [Function("GetUsers")]
        public async Task<IActionResult> GetUsers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users")] HttpRequestData req)
        {
            var users = await _context.Users.ToListAsync();
            return new OkObjectResult(users);
        }

        [Function("GetUserById")]
        public async Task<IActionResult> GetUserById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users/{id}")] HttpRequestData req, int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return new NotFoundResult();
            return new OkObjectResult(user);
        }

        [Function("validateUser")]
        public async Task<IActionResult> validateUser(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "validate/users")] HttpRequestData req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
           var user = JsonConvert.DeserializeObject <userpassword>(requestBody);
            var result = await _context.Users.Where(x=>x.Name==user.userName && x.Password==user.password).FirstOrDefaultAsync();
         
             return new OkObjectResult(result);
        }

        [Function("UpdateUser")]
        public async Task<IActionResult> UpdateUser(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "users/{id}")] HttpRequestData req, int id)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updatedUser = JsonConvert.DeserializeObject<User>(requestBody);
            var user = await _context.Users.FindAsync(id);

            if (user == null) return new NotFoundResult();

            user.Name = updatedUser.Name;
            user.Age = updatedUser.Age;
            user.Gender = updatedUser.Gender;
            user.MobileNo = updatedUser.MobileNo;
            user.Address = updatedUser.Address;
            user.Weight = updatedUser.Weight;
            user.Height = updatedUser.Height;
            user.Role = updatedUser.Role;
            user.Branch = updatedUser.Branch;
            user.ModifiedBy=updatedUser.ModifiedBy;

            await _context.SaveChangesAsync();
            return new OkObjectResult(user);
        }

        [Function("DeleteUser")]
        public async Task<IActionResult> DeleteUser(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "users/{id}")] HttpRequestData req, int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return new NotFoundResult();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}

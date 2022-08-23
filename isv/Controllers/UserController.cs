using isv.Database;
using isv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace isv.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        ApplicationContext context;
        public UserController(ApplicationContext context)
        {
            this.context = context;
        }
        

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(ApiRequest request)
        {
            try
            {
                //var DeleteCities = context.Cities;
                //context.Cities.RemoveRange(DeleteCities);
                //var DeleteUsers = context.Users;
                //context.Users.RemoveRange(DeleteUsers);
                await Task.Run(() => context.Cities.AddRangeAsync(request.Cities));
                await Task.Run(() => context.Users.AddRangeAsync(request.Users));
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {

            }

            return Ok();
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            try
            {
                var result = context.Users.SingleOrDefault(u => u.UserId == user.UserId);
                if(result != null)
                {
                    result.Name = $"{user.Name} -> Updated {DateTime.Now}";
                   await context.SaveChangesAsync();
                }
                return Ok(result.Name);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }

        [HttpPost("DeleteAll")]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                context.Cities.RemoveRange(context.Cities);
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();
                return Ok("Everything Deleted");
            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(User user)
        {
            try { 
            var DeleteRange = context.Users.Where(u => u.UserId != user.UserId);
            context.Users.RemoveRange(DeleteRange);
            context.SaveChanges();
                return Ok("User Deleted");
            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }

           

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try { 
            var result = from usr in context.Users join cyt in context.Cities  on usr.CityId equals cyt.CityId
                         select new { 
                         UserId = usr.UserId,
                         Name = usr.Name,
                         CityName = cyt.CityName
                         };
                return Ok(result);
            }

            catch (Exception ex)
            {

            }
            return BadRequest();
        }
    }
}
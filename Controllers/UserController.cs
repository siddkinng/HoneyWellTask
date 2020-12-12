using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserHoneyWell.Models;

namespace UserHoneyWell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TestContext _context;

        public UserController(TestContext testContext)
        {
            _context = testContext;
        }

        [HttpPost]
        public async Task<ActionResult<Users>> PostUser([FromBody]Users users)
        {
            //validating if email is valid 
            bool isEmail = Regex.IsMatch(users.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            try
            {
                if (!string.IsNullOrWhiteSpace(users.UserName) && !string.IsNullOrWhiteSpace(users.Email) && isEmail==true)
                {
                    _context.USERS.Add(users);
                }
                else
                {
                    return BadRequest();
                }

                await _context.SaveChangesAsync(); //saving changes to db 
            }
            catch (DbUpdateException)
            {
               //handle exception
            }

            return CreatedAtAction("UserCreated", new { id = users.Userid }, users);
        }

    }

}

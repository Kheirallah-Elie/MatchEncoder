using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;


namespace MatchEncoder.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                var createdUser = await _userService.CreateAsync(user);
                return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            if (id != user.Id) return BadRequest("User ID mismatch.");

            var existingUser = await _userService.GetByIdAsync(id);
            if (existingUser == null) return NotFound();

            var updatedUser = await _userService.UpdateAsync(user);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _userService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User loginUser)
        {
            var user = await _userService.AuthenticateAsync(loginUser.Name, loginUser.Password);
            if (user == null) return Unauthorized("Invalid username or password.");
            return Ok(user);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {

            await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginUser)
        {
            if (loginUser == null)
            {
                return BadRequest("Invalid client request");
            }

            // Authenticate user using the user service (validate user credentials)
            var user = await _userService.AuthenticateAsync(loginUser.Name, loginUser.Password);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            // Returning a dummy token (just a static string for now)
            var dummyToken = "dummy-jwt-token-for-now";

            // Respond with the dummy token
            return Ok(new { token = dummyToken });
        }
    }

}

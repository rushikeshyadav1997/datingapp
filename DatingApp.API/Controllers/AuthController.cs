using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
            _repo = repo;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterforDto userRegisterforDto)
        {
            //validate request
            userRegisterforDto.Username = userRegisterforDto.Username.ToLower();
            if (await _repo.UserExists(userRegisterforDto.Username))
                return BadRequest("Username is Already Taken");
            var userToCreate = new user
            {
                Username = userRegisterforDto.Username
            };
            var createdUser = await _repo.Register(userToCreate, userRegisterforDto.Password);
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginforDto userLoginforDto)
        {
            var UserfromRepo = await _repo.Login(userLoginforDto.Username, userLoginforDto.Password);
            if (UserfromRepo == null)
                return Unauthorized();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier ,UserfromRepo.id.ToString()),
                new Claim(ClaimTypes.Name , UserfromRepo.Username)

            };
            var Key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var user=_mapper.Map<UserforListDto>(UserfromRepo);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user
            });


        }
    }
}
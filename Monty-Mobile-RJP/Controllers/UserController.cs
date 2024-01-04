using Application.Commands;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.DTO.Base;
using Infrastructure.DTO.UserDTO;
using Infrastructure.Repository.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Monty_Mobile_RJP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public UserController(ILogger<UserController> logger, IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }


        [HttpPost,Route("Register")]
        public async Task<BaseResponseDTO<string>> Register(RegisterDTO user)
        {
            BaseResponseDTO<string> response = new();
            RegisterCommand command = new(user);
            response = await _mediator.Send(command);
            return response;
        }

        [HttpPost,Route("Login")]
        public async Task<BaseResponseDTO<string>> Login(LoginDTO model)
        {
            BaseResponseDTO<string> response = new();
            
            var secretKey = _configuration.GetSection("AppSettings:Token").Value;
            LoginCommand loginCommand = new(model, secretKey);
            response = await _mediator.Send(loginCommand);
            return response;
        }


    }
}

using Application.Commands;
using Domain.Entities;
using Infrastructure.DTO.Base;
using Infrastructure.Helper;
using Infrastructure.Repository.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsHandler
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, BaseResponseDTO<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RegisterCommandHandler> _logger;

        public RegisterCommandHandler(IUnitOfWork unitOfWork, ILogger<RegisterCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<BaseResponseDTO<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            BaseResponseDTO<string> response = new();
            Security.CreatePasswordHash(request.user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new Domain.Entities.User
            {
                FirstName = request.user.FirstName,
                LastName = request.user.LastName,
                Username = request.user.Username,
                Email = request.user.Email,
                PhoneNumber = request.user.PhoneNumber,
                Password = Convert.ToBase64String(passwordHash),
                Salt = Convert.ToBase64String(passwordSalt)
            };
            try
            {
                await _unitOfWork.UserRepository.Add(user);
                _unitOfWork.Save();
                response.data = user.Id.ToString();
                response.statusCode = Domain.Enums.StatusCode.Created;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.InnerException?.ToString());
                response.statusCode = Domain.Enums.StatusCode.BadRequest;
                response.errorMessage = ex.Message;
            }
            return response;
        }
    }
}

using Application.Commands;
using Infrastructure.DTO.Base;
using Infrastructure.Helper;
using Infrastructure.IServices;
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
    public class LoginCommandHandler : IRequestHandler<LoginCommand, BaseResponseDTO<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LoginCommandHandler> _logger;
        private readonly ITokenManager _tokenManager;

        public LoginCommandHandler(IUnitOfWork unitOfWork, ILogger<LoginCommandHandler> logger, ITokenManager tokenManager)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _tokenManager = tokenManager;
        }

        public async Task<BaseResponseDTO<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            BaseResponseDTO<string> response = new();
            try
            {
                var user = await _unitOfWork.UserRepository.GetUserByUsername(request.model.Username);
                
                if (!string.IsNullOrEmpty(user.Email))
                {
                    bool isPasswordVerified = Security.VerifyPasswordHash(request.model.Password, Convert.FromBase64String(user.Password), Convert.FromBase64String(user.Salt));
                    if (!isPasswordVerified)
                    {
                        response.statusCode = Domain.Enums.StatusCode.BadRequest;
                    }
                    response.data = _tokenManager.CreateToken(user, request.model.RememberMe, request.secretKey, user.isAdmin);
                }
                else
                {
                    response.statusCode = Domain.Enums.StatusCode.BadRequest;
                    response.errorMessage = "Username Invalid";
                }
            }
            catch (Exception ex)
            {
                response.statusCode = Domain.Enums.StatusCode.BadRequest;
                response.errorMessage = ex.Message;
                _logger.LogError(ex.Message);
                _logger.LogError(ex.InnerException?.ToString());
            }
            return response;
        }
    }
}

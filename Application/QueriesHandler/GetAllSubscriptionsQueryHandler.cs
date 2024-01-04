using Application.Queries;
using Domain.Entities;
using Infrastructure.DTO.Base;
using Infrastructure.DTO.SubscriptionDTO;
using Infrastructure.IServices;
using Infrastructure.Repository.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueriesHandler
{
    public class GetAllSubscriptionsQueryHandler : IRequestHandler<GetAllSubscriptionsQuery, BaseResponseDTO<List<GetAllSubscriptionsDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAllSubscriptionsQueryHandler> _logger;
        private readonly ITokenManager _tokenManager;
        public GetAllSubscriptionsQueryHandler(IUnitOfWork unitOfWork, ILogger<GetAllSubscriptionsQueryHandler> logger,ITokenManager tokenManager)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _tokenManager = tokenManager;
        }

        public async Task<BaseResponseDTO<List<GetAllSubscriptionsDTO>>> Handle(GetAllSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            BaseResponseDTO<List<GetAllSubscriptionsDTO>> response = new();
            try
            {
                long userId = Convert.ToInt64(_tokenManager.GetClaimValueFromToken(request.Request, "userId"));
                if (userId >= 0)
                {
                        var subscriptions = await _unitOfWork.SubscriptionRepository.GetAllSubscriptions(userId);
                        response.data = subscriptions;
                        response.statusCode = Domain.Enums.StatusCode.Success;
                    
                    response.statusCode = Domain.Enums.StatusCode.Success;
                }
            }
            catch (Exception ex)
            {
                response.errorMessage = ex.Message;
                response.statusCode = Domain.Enums.StatusCode.BadRequest;
            }
            return response;
        }
    }
}

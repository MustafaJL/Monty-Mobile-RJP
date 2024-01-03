using Application.Commands;
using Domain.Entities;
using Infrastructure.DTO.Base;
using Infrastructure.IServices;
using Infrastructure.Repository.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsHandler
{
    public class SubscripeToMobileDataPlanCommandHandler : IRequestHandler<SubscripeToMobileDataPlanCommand, BaseResponseDTO<string>>
    {
        private readonly ITokenManager _tokenManager;
        private readonly IUnitOfWork _unitOfWork;

        public SubscripeToMobileDataPlanCommandHandler(ITokenManager tokenManager, IUnitOfWork unitOfWork)
        {
            _tokenManager = tokenManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseDTO<string>> Handle(SubscripeToMobileDataPlanCommand request, CancellationToken cancellationToken)
        {
            BaseResponseDTO<string> response = new();
            try
            {
                long userId = Convert.ToInt64(_tokenManager.GetClaimValueFromToken(request.Request, "userId"));
                MobileDataPlan mobileDataPlan = await _unitOfWork.MobileDataPlanRepository.GetById(request.model.mobileDataPlanId);
                if (request.model.mobileDataPlanId >= 0 && userId >= 0)
                {
                    Subscription subscription = new Subscription
                    {
                        UserId = userId,
                        MobileDataPlanId = request.model.mobileDataPlanId,
                        Cost = mobileDataPlan.PricePerMonth * request.model.numberOfMonths,
                        StartDate = DateTime.UtcNow.AddHours(2),
                        EndDate = DateTime.UtcNow.AddHours(2).AddMonths(request.model.numberOfMonths)
                    };

                    await _unitOfWork.SubscriptionRepository.Add(subscription);
                    _unitOfWork.Save();

                    response.data = Convert.ToString(subscription.Id);
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

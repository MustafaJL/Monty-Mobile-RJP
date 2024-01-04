using Application.Commands;
using Application.Queries;
using Domain.Entities;
using Infrastructure.DTO.Base;
using Infrastructure.DTO.SubscriptionDTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monty_Mobile_RJP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost, Route("SubscripeToMobileDataPlan"),Authorize(Roles = "User")]
        public async Task<BaseResponseDTO<string>> SubscripeToMobileDataPlan(SubscripeToMobileDataPlan model)
        {
            BaseResponseDTO<string> response = new();
            SubscripeToMobileDataPlanCommand command = new(model,Request);
            response = await _mediator.Send(command);
            return response;
        }

        [HttpGet,Route("GetAllSubscriptions"),Authorize(Roles = "User")]
        public async Task<BaseResponseDTO<List<GetAllSubscriptionsDTO>>> GetAllSubscriptions()
        {
            BaseResponseDTO<List<GetAllSubscriptionsDTO>> response = new();
            GetAllSubscriptionsQuery getAllSubscriptionsQuery = new(Request);
            response = await _mediator.Send(getAllSubscriptionsQuery);
            return response;
        }
    }
}

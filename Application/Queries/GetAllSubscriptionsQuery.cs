using Infrastructure.DTO.Base;
using Infrastructure.DTO.SubscriptionDTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public record GetAllSubscriptionsQuery(HttpRequest Request) : IRequest<BaseResponseDTO<List<GetAllSubscriptionsDTO>>>;
}

﻿using Infrastructure.DTO.Base;
using Infrastructure.DTO.SubscriptionDTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public record SubscripeToMobileDataPlanCommand(SubscripeToMobileDataPlan model, HttpRequest Request) : IRequest<BaseResponseDTO<string>>;
}

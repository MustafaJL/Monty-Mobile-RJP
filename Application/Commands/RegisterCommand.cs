using Domain.Entities;
using Infrastructure.DTO.Base;
using Infrastructure.DTO.UserDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public record RegisterCommand(RegisterDTO user) : IRequest<BaseResponseDTO<string>>;
}

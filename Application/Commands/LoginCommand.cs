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
    public record LoginCommand(LoginDTO model, string secretKey) : IRequest<BaseResponseDTO<string>>;
}

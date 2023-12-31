using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.Base
{
    public class BaseResponseDTO<T>
    {
        public StatusCode statusCode { get; set; } = StatusCode.Success;
        public string errorMessage { get; set; } = string.Empty;
        public T? data { get; set; }
    }
}

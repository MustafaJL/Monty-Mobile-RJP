using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum StatusCode
    {
        Success = 200,
        Created = 201,
        BadRequest = 400,
        InternalServerError = 500,
        UnAuthorized = 401
    }
}

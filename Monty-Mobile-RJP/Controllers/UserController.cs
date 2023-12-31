using Domain.Entities;
using Infrastructure.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monty_Mobile_RJP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IUnitOfWork unitOfWork;
        public UserController(ILogger<UserController> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IEnumerable
            <SubscriptionType>> Index()
        {
              
              return await this.unitOfWork.SubscriptionTypeRepository.GetAll();
        }
    }
}

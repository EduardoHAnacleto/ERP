using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : BaseController<Delivery, DeliveryDto>
    {
        public DeliveryController(IGenericRepository<Delivery> repository, IUnitOfWork unitOfWork)
    : base(repository, unitOfWork) { }
    }
}

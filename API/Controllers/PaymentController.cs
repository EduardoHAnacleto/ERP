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
    public class PaymentController : BaseController<Payment, PaymentDto>
    {
        public PaymentController(IGenericRepository<Payment> repository, IUnitOfWork unitOfWork)
    : base(repository, unitOfWork) { }
    }
}

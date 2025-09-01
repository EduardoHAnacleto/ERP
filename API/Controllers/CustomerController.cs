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
    public class CustomerController : BaseController<Customer, CustomerDto>
    {
        public CustomerController(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork) { }
    }
}
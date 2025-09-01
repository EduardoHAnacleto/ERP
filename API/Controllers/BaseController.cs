using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TEntity, TDto> : ControllerBase
       where TEntity : BaseEntity, new()
       where TDto : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        protected BaseController(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        [HttpGet("{id:guid}")]
        public virtual async Task<ActionResult<TDto>> GetById(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();

            var dto = MapToDto(entity);
            return Ok(dto);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(TDto dto)
        {
            var entity = MapToEntity(dto);
            //entity.Id = Guid.NewGuid();

            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
        }

        [HttpPut("{id:guid}")]
        public virtual async Task<ActionResult> Update(Guid id, TDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            UpdateEntity(existing, dto);
            await _repository.UpdateAsync(existing);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        // 🔹 Métodos abstratos para mapear DTO <-> Entidade
        protected abstract TDto MapToDto(TEntity entity);
        protected abstract TEntity MapToEntity(TDto dto);
        protected abstract void UpdateEntity(TEntity entity, TDto dto);
    }
}

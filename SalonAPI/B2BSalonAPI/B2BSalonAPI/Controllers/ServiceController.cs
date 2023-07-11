using B2BSalonAPI.Models;
using B2BSalonAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2BSalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly RepositoryContext _context;
        private IRepositoryWrapper _repository;
        public ServiceController(RepositoryContext context, IRepositoryWrapper repository)
        {
            _context = context;
            _repository = repository;
        }
        [HttpGet]
        [Route("GetByBranch")]
        public async Task<IActionResult> GetByBranch(Guid BranchId)
        {
            var data = await (from s in _context.Services
                              join c in _context.Categories on s.CategoryId equals c.CategoryId
                              join b in _context.Branches on s.BranchId equals b.BranchId
                              join bs in _context.Businesses on b.BusinessId equals bs.BusinessId
                              select new
                              {
                                  s.ServiceId,
                                  s.ServiceName,
                                  s.Status,
                                  s.Description,
                                  s.Price,
                                  s.DurationHours,
                                  s.DurationMinutes,
                                  c.CategoryId,
                                  c.CategoryName,
                                  b.BranchId,
                                  bs.BusinessName,
                                  bs.BusinessId,
                              }).Where(s => s.BranchId == BranchId).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpGet]
        [Route("Search")]
        public IActionResult Search()
        {
            var data = _context.Services.Select(x => x.ServiceName).Distinct();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpGet]
        [Route("GetActiveByBranch/{BranchId}")]
        public async Task<IActionResult> GetActiveByBranch(Guid BranchId)
        {
            var data = await (from s in _context.Services
                              join c in _context.Categories on s.CategoryId equals c.CategoryId
                              join b in _context.Branches on s.BranchId equals b.BranchId
                              join bs in _context.Businesses on b.BusinessId equals bs.BusinessId
                              select new
                              {
                                  s.ServiceId,
                                  s.ServiceName,
                                  s.Status,
                                  s.Description,
                                  s.Price,
                                  s.DurationHours,
                                  s.DurationMinutes,
                                  c.CategoryId,
                                  c.CategoryName,
                                  b.BranchId,
                                  bs.BusinessName,
                                  bs.BusinessId,
                              }).Where(s => s.Status == true && s.BranchId== BranchId).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(Service model)
        {
            try
            {
                model.ServiceId = Guid.NewGuid();
                model.CreatedDate = DateTime.UtcNow;
                model.UpdatedDate = DateTime.UtcNow;
                _repository.Service.CreateRecord(model);
                _repository.Save();
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Record Created Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Service model)
        {
            try
            {
                var data = _repository.Service.GetDataById(model.ServiceId);
                if (data == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Record not exists!" });
                }
                else
                {
                    model.UpdatedDate = DateTime.UtcNow;
                    _repository.Service.UpdateRecord(data);
                    _repository.Save();
                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Record Updated Successfully" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var data = await _context.Services.FindAsync(id);
                if (data == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Record not exists!" });
                }
                else
                {
                    _context.Services.Remove(data);
                    await _context.SaveChangesAsync();
                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Error", Message = "Record Deleted!" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
    }
}

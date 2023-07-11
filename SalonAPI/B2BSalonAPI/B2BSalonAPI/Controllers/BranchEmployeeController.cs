using B2BSalonAPI.Models;
using B2BSalonAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2BSalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchEmployeeController : ControllerBase
    {
        private readonly RepositoryContext _context;
        private IRepositoryWrapper _repository;
        public BranchEmployeeController(RepositoryContext context, IRepositoryWrapper repository)
        {
            _context = context;
            _repository = repository;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var data = await (from p in _context.BranchEmployees
                              select new
                              {
                                  p.BranchEmployeeId,
                                  p.Name,
                                  p.Email,
                                  p.Designation,
                                  p.Mobile,
                                  p.BranchId
                              }).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpGet]
        [Route("GetByBranch")]
        public async Task<IActionResult> GetByBranch(Guid BranchId)
        {
            var data = await (from p in _context.BranchEmployees
                              select new
                              {
                                  p.BranchEmployeeId,
                                  p.Name,
                                  p.Email,
                                  p.Designation,
                                  p.Mobile,
                                  p.BranchId
                              }).Where(p => p.BranchId == BranchId).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(BranchEmployee model)
        {
            try
            {
                model.BranchEmployeeId = Guid.NewGuid();
                _repository.BranchEmployee.CreateRecord(model);
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
        public IActionResult Update(BranchEmployee model)
        {
            try
            {
                var data = _repository.BranchEmployee.GetDataById(model.BranchEmployeeId);
                if (data == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Record not exists!" });
                }
                else
                {
                    _repository.BranchEmployee.UpdateRecord(data);
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
                var data = await _context.BranchEmployees.FindAsync(id);
                if (data == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Record not exists!" });
                }
                else
                {
                    _context.BranchEmployees.Remove(data);
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


using B2BSalonAPI.Configuration;
using B2BSalonAPI.Models;
using B2BSalonAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2BSalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessTypeController : ControllerBase
    {
        private readonly RepositoryContext _context;
        private IRepositoryWrapper _repository;
        GlobalData common = new GlobalData();
        public BusinessTypeController(RepositoryContext context, IRepositoryWrapper repository)
        {
            _context = context;
            _repository = repository;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<BusinessType>>> Get()
        {
            var data = await _context.BusinessTypes.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpGet]
        [Route("GetByStatus")]
        public async Task<ActionResult<IEnumerable<BusinessType>>> GetByStatus()
        {
            var data = await _context.BusinessTypes.Where(c => c.Status == true).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(BusinessType model)
        {
            try
            {
                model.BusinessTypeId = Guid.NewGuid();
                model.CreatedDate = DateTime.UtcNow;
                model.UpdatedDate = DateTime.UtcNow;
                model.BusinessTypeURL = common.urlreplace(model.BusinessTypeName);
                _context.Add(model);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Record Created Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(BusinessType model)
        {
            try
            {
                var businessType = await _context.BusinessTypes.FindAsync(model.BusinessTypeId);
                if (businessType == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Record not exists!" });
                }
                else
                {
                    model.UpdatedDate = DateTime.UtcNow;
                    _context.Entry(model).Property(x => x.CreatedDate).IsModified = false;
                    _context.Entry(model).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
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
                var businessType = await _context.BusinessTypes.FindAsync(id);
                if (businessType == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Record not exists!" });
                }
                else
                {
                    _context.BusinessTypes.Remove(businessType);
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

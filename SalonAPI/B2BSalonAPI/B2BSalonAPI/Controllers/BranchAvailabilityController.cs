using B2BSalonAPI.Models;
using B2BSalonAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2BSalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchAvailabilityController : ControllerBase
    {
        private readonly RepositoryContext _context;
        private IRepositoryWrapper _repository;
        public BranchAvailabilityController(RepositoryContext context, IRepositoryWrapper repository)
        {
            _context = context;
            _repository = repository;
        }
        [HttpGet]
        [Route("GetByBranch")]
        public async Task<IActionResult> GetByBranch(Guid BranchId)
        {
            var data = await (from p in _context.BranchAvailabilities
                              select new
                              {
                                  p.Monday,
                                  p.Tuesday,
                                  p.Wednesday,
                                  p.Thursday,
                                  p.Friday,
                                  p.Saturday,
                                  p.Sunday,
                                  p.MondayOpeningTime,
                                  p.TuesdayOpeningTime,
                                  p.WednesdayOpeningTime,
                                  p.ThursdayOpeningTime,
                                  p.FridayOpeningTime,
                                  p.SaturdayOpeningTime,
                                  p.SundayOpeningTime,
                                  p.MondayClosingTime,
                                  p.TuesdayClosingTime,
                                  p.WednesdayClosingTime,
                                  p.ThursdayClosingTime,
                                  p.FridayClosingTime, p.SaturdayClosingTime,p.SundayClosingTime,
                                  p.BranchId
                              }).Where(p => p.BranchId == BranchId).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(BranchAvailability model)
        {
            try
            {
                model.BranchAvailabilityId = Guid.NewGuid();
                _repository.BranchAvailability.CreateRecord(model);
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
        public IActionResult Update(BranchAvailability model)
        {
            try
            {
                var data = _repository.BranchAvailability.GetDataById(model.BranchAvailabilityId);
                if (data == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Record not exists!" });
                }
                else
                {
                    _repository.BranchAvailability.UpdateRecord(data);
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
                var data = await _context.BranchAvailabilities.FindAsync(id);
                if (data == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Record not exists!" });
                }
                else
                {
                    _context.BranchAvailabilities.Remove(data);
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



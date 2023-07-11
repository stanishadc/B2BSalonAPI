using B2BSalonAPI.Models;
using B2BSalonAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace B2BSalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionDataController : ControllerBase
    {
        private readonly RepositoryContext _context;
        private IRepositoryWrapper _repository;
        public SubscriptionDataController(RepositoryContext context, IRepositoryWrapper repository)
        {
            _context = context;
            _repository = repository;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var data = await (from p in _context.SubscriptionDatas
                              select new
                              {
                                  p.SubscriptionTypeId,
                                  p.SubscriptionText
                              }).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(SubscriptionData model)
        {
            try
            {
                model.SubscriptionDataId = Guid.NewGuid();
                _repository.SubscriptionData.CreateRecord(model);
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
        public IActionResult Update(SubscriptionType model)
        {
            try
            {
                var data = _repository.SubscriptionType.GetDataById(model.SubscriptionTypeId);
                if (data == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Record not exists!" });
                }
                else
                {
                    data = model;
                    _repository.SubscriptionType.UpdateRecord(data);
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
                var data = await _context.SubscriptionDatas.FindAsync(id);
                if (data == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Record not exists!" });
                }
                else
                {
                    _context.SubscriptionDatas.Remove(data);
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
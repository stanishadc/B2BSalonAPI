using B2BSalonAPI.Configuration;
using B2BSalonAPI.Models;
using B2BSalonAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2BSalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly RepositoryContext _context;
        private IRepositoryWrapper _repository;
        GlobalData common = new GlobalData();
        public CategoryController(RepositoryContext context, IRepositoryWrapper repository)
        {
            _context = context;
            _repository = repository;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var data = await (from p in _context.Categories
                                      select new
                                      {
                                          p.CategoryId,
                                          p.CategoryName,
                                          p.Status,
                                          ImageSrc= string.Format("{0}://{1}{2}/Category/{3}", Request.Scheme, Request.Host, Request.PathBase, p.ImageName),
                                      }).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpGet]
        [Route("GetTop")]
        public async Task<IActionResult> GetTop()
        {
            var data = await (from p in _context.Categories
                              select new
                              {
                                  p.CategoryId,
                                  p.CategoryName,
                                  p.Status,
                                  ImageSrc = string.Format("{0}://{1}{2}/Category/{3}", Request.Scheme, Request.Host, Request.PathBase, p.ImageName),
                              }).Where(p => p.Status == true).Take(6).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpGet]
        [Route("GetByStatus")]
        public async Task<IActionResult> GetByStatus()
        {
            var data = await (from p in _context.Categories
                              select new
                              {
                                  p.CategoryId,
                                  p.CategoryName,
                                  p.Status,
                                  ImageSrc = string.Format("{0}://{1}{2}/Category/{3}", Request.Scheme, Request.Host, Request.PathBase, p.ImageName),
                              }).Where(p => p.Status == true).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(Category model)
        {
            try
            {
                model.CategoryId = Guid.NewGuid();
                model.CreatedDate = DateTime.UtcNow;
                model.UpdatedDate = DateTime.UtcNow;
                model.Categoryurl = common.urlreplace(model.CategoryName);
                _repository.Category.CreateRecord(model);
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
        public IActionResult Update(Category model)
        {
            try
            {
                var data = _repository.Category.GetDataById(model.CategoryId);
                if (data == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Record not exists!" });
                }
                else
                {
                    model.UpdatedDate = DateTime.UtcNow;
                    _repository.Category.UpdateRecord(data);
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
                var categoryType = await _context.Categories.FindAsync(id);
                if (categoryType == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Record not exists!" });
                }
                else
                {
                    _context.Categories.Remove(categoryType);
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


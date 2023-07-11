using B2BSalonAPI.Models;
using B2BSalonAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System.Linq;

namespace B2BSalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly RepositoryContext _context;
        private IRepositoryWrapper _repository;
        public BranchController(RepositoryContext context, IRepositoryWrapper repository)
        {
            _context = context;
            _repository = repository;
        }
        [HttpGet]
        [Route("GetActiveBranches")]
        public async Task<IActionResult> GetActiveBranches()
        {
            var data = await (from b in _context.Branches
                              join bs in _context.Businesses on b.BusinessId equals bs.BusinessId
                              join bt in _context.BusinessTypes on b.BusinessTypeId equals bt.BusinessTypeId
                              join bi in _context.BranchImages on b.BranchId equals bi.BranchId
                              select new
                              {
                                  b.BranchId,
                                  b.About,
                                  b.Country,
                                  b.Status,
                                  b.Address,
                                  b.City,
                                  b.Rating,
                                  b.BranchUrl,
                                  b.Currency,
                                  b.GoogleMapURL,
                                  b.Landline,
                                  b.Location,
                                  b.Latitude, b.Longitude,
                                  b.TotalRatings,
                                  b.ZipCode,
                                  bs.BusinessName,
                                  bs.BusinessId,
                                  bt.BusinessTypeId,
                                  bt.BusinessTypeName,
                                  bt.BusinessTypeURL,
                                  ImageSrc = string.Format("{0}://{1}{2}/SalonImages/{3}", Request.Scheme, Request.Host, Request.PathBase, bi.ImageName),
                              }).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpGet]
        [Route("GetTopActiveBranches")]
        public async Task<IActionResult> GetTopActiveBranches()
        {
            var data = await (from b in _context.Branches
                              join bs in _context.Businesses on b.BusinessId equals bs.BusinessId
                              join bt in _context.BusinessTypes on b.BusinessTypeId equals bt.BusinessTypeId
                              join bi in _context.BranchImages on b.BranchId equals bi.BranchId
                              select new
                              {
                                  b.BranchId,
                                  b.About,
                                  b.Country,
                                  b.Status,
                                  b.Address,
                                  b.City,
                                  b.Rating,
                                  b.BranchUrl,
                                  b.Currency,
                                  b.GoogleMapURL,
                                  b.Landline,
                                  b.Location,
                                  b.Latitude,
                                  b.Longitude,
                                  b.TotalRatings,
                                  b.ZipCode,
                                  bs.BusinessName,
                                  bs.BusinessId,
                                  bt.BusinessTypeId,
                                  bt.BusinessTypeName,
                                  bt.BusinessTypeURL,
                                  ImageSrc = string.Format("{0}://{1}{2}/SalonImages/{3}", Request.Scheme, Request.Host, Request.PathBase, bi.ImageName),
                              }).Take(9).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpGet]
        [Route("SearchBranches")]
        public async Task<IActionResult> SearchBranches(string? Category, string? Service,string? Location)
        {
            var data = await (from b in _context.Branches
                              join bs in _context.Businesses on b.BusinessId equals bs.BusinessId
                              join bt in _context.BusinessTypes on b.BusinessTypeId equals bt.BusinessTypeId
                              join bi in _context.BranchImages on b.BranchId equals bi.BranchId
                              join s in _context.Services on b.BranchId equals s.BranchId
                              join c in _context.Categories on s.CategoryId equals c.CategoryId                              
                              select new
                              {
                                  b.BranchId,
                                  b.About,
                                  b.Country,
                                  b.Status,
                                  b.Address,
                                  b.City,
                                  b.Rating,
                                  b.BranchUrl,
                                  b.Currency,
                                  b.GoogleMapURL,
                                  b.Landline,
                                  b.Location,
                                  b.Latitude,
                                  b.Longitude,
                                  b.TotalRatings,
                                  b.ZipCode,
                                  bs.BusinessName,
                                  bs.BusinessId,
                                  bt.BusinessTypeId,
                                  bt.BusinessTypeName,
                                  bt.BusinessTypeURL,
                                  s.ServiceName,
                                  s.ServiceId,
                                  c.CategoryId,
                                  c.CategoryName,
                                  ImageSrc = string.Format("{0}://{1}{2}/SalonImages/{3}", Request.Scheme, Request.Host, Request.PathBase, bi.ImageName),
                              }).ToListAsync();
            if (!string.IsNullOrEmpty(Location))
            {
                data = data.Where(d => d.Location == Location).ToList();
            }
            if (!string.IsNullOrEmpty(Service))
            {
                data = data.Where(d => d.ServiceName.Contains(Service)).ToList();
            }
            if (!string.IsNullOrEmpty(Category))
            {
                data = data.Where(d => d.CategoryName.Contains(Category)).ToList();
            }
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
        [HttpGet]
        [Route("Locations")]
        public IActionResult Locations()
        {
            var data = _context.Branches.Select(x => x.Location).Distinct();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }        
        [HttpGet]
        [Route("GetById/{BranchId}")]
        public async Task<IActionResult> GetById(Guid BranchId)
        {
            string OpeningHours = "9:00";
            string ClosingHours = "20:00";
            string OpeningStatus = "Open Now";
            var data = await (from b in _context.Branches
                              join bs in _context.Businesses on b.BusinessId equals bs.BusinessId
                              join bt in _context.BusinessTypes on b.BusinessTypeId equals bt.BusinessTypeId
                              join bi in _context.BranchImages on b.BranchId equals bi.BranchId
                              select new
                              {
                                  b.BranchId,
                                  b.About,
                                  b.Country,
                                  b.Status,
                                  b.Address,
                                  b.City,
                                  b.Rating,
                                  b.BranchUrl,
                                  b.Currency,
                                  b.GoogleMapURL,
                                  b.Landline,
                                  b.Location,
                                  b.Latitude,
                                  b.Longitude,
                                  b.TotalRatings,
                                  b.ZipCode,
                                  bs.BusinessName,
                                  bs.BusinessId,
                                  bt.BusinessTypeId,
                                  bt.BusinessTypeName,
                                  bt.BusinessTypeURL,
                                  OpeningHours, ClosingHours,OpeningStatus,
                                  ImageSrc = string.Format("{0}://{1}{2}/SalonImages/{3}", Request.Scheme, Request.Host, Request.PathBase, bi.ImageName),
                              }).Where(b => b.BranchId == BranchId).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Data = data });
        }
    }
}

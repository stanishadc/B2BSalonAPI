using B2BSalonAPI.Configuration;
using B2BSalonAPI.DTO;
using B2BSalonAPI.Models;
using B2BSalonAPI.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace B2BSalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly RepositoryContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IRepositoryWrapper _repository;
        GlobalData common = new GlobalData();
        public BusinessController(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, RepositoryContext context, IWebHostEnvironment webHostEnvironment, IRepositoryWrapper repository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _repository = repository;
        }
        [HttpPost]
        [Route("register-business")]
        public async Task<IActionResult> RegisterBusiness([FromBody] BusinessDTO model)
        {
            #region Business user creation
            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
            {
                model.Id = userExists.Id;
                //return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Email already exists!" });
            }
            else
            {
                User user = new()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Email,
                    PhoneNumber = model.MobileNo,
                    FullName = model.ContactName,
                    OTP = common.GenerateOTP(),
                    OTPExpire = DateTime.UtcNow.AddHours(2)
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    if (result.Errors != null)
                    {
                        var error = result.Errors.FirstOrDefault();
                        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = error?.Description });
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
                }
                if (!await _roleManager.RoleExistsAsync(UserRoles.Business))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Business));
                }
                await _userManager.AddToRoleAsync(user, UserRoles.Business);
                model.Id = user.Id;
            }
            #endregion

            #region Register Business Details
            Business business = new Business();
            business.BusinessId = Guid.NewGuid();
            business.BusinessName = model.BusinessName;
            await _context.Businesses.AddAsync(business);
            await _context.SaveChangesAsync();
            #endregion

            #region Register Branch Details
            Branch branch = new Branch();
            branch.BranchId = Guid.NewGuid();
            branch.BusinessId = business.BusinessId;
            branch.Email = model.Email;
            branch.MobileNo = model.MobileNo;
            branch.Address = model.Address;
            branch.GoogleMapURL = model.GoogleMapURL;
            branch.CreatedDate = DateTime.UtcNow;
            branch.UpdatedDate = DateTime.UtcNow;
            branch.Id = model.Id;
            branch.About = model.About;
            branch.BranchType = BranchTypes.Main;
            branch.Location = model.Location;
            string businessname = common.urlreplace(model.BusinessName);
            string location = common.urlreplace(model.Location);

            branch.BranchUrl = businessname + "-" + location;
            branch.BusinessTypeId = model.BusinessTypeId;
            branch.City = model.City;
            branch.Country = model.Country;

            branch.ContactName = model.ContactName;
            branch.Currency = Currencies.NAIRA;
            branch.Landline = model.Landline;
            branch.Latitude = model.Latitude;
            branch.Longitude = model.Longitude;
            branch.Rating = 0;
            branch.TotalRatings = 0;
            branch.Status = BusinessStatus.Pending;
            branch.ZipCode = model.ZipCode;
            await _context.Branches.AddAsync(branch);
            await _context.SaveChangesAsync();
            #endregion

            #region Register Branch Timings
            BranchAvailability branchAvailability = new BranchAvailability();
            branchAvailability.BranchAvailabilityId = Guid.NewGuid();
            branchAvailability.BranchId = branch.BranchId;
            branchAvailability.Monday = true;
            branchAvailability.Tuesday = true;
            branchAvailability.Wednesday = true;
            branchAvailability.Thursday = true;
            branchAvailability.Friday = true;
            branchAvailability.Saturday = true;
            branchAvailability.Sunday = false;
            branchAvailability.MondayOpeningTime = "9:00";
            branchAvailability.TuesdayOpeningTime = "9:00";
            branchAvailability.WednesdayOpeningTime = "9:00";
            branchAvailability.ThursdayOpeningTime = "9:00";
            branchAvailability.FridayOpeningTime = "9:00";
            branchAvailability.SaturdayOpeningTime = "9:00";
            branchAvailability.SundayOpeningTime = "9:00";
            branchAvailability.MondayClosingTime = "20:00";
            branchAvailability.TuesdayClosingTime = "20:00";
            branchAvailability.WednesdayClosingTime = "20:00";
            branchAvailability.ThursdayClosingTime = "20:00";
            branchAvailability.FridayClosingTime = "20:00";
            branchAvailability.SaturdayClosingTime = "20:00";
            branchAvailability.SundayClosingTime = "20:00";
            await _context.BranchAvailabilities.AddAsync(branchAvailability);
            await _context.SaveChangesAsync();
            #endregion

            #region Branch Employee
            BranchEmployee branchEmployee = new BranchEmployee();
            branchEmployee.Name = model.ContactName;
            branchEmployee.BranchEmployeeId = Guid.NewGuid();
            branchEmployee.Email = model.Email;
            branchEmployee.Mobile = model.MobileNo;
            branchEmployee.Designation = "Owner";
            branchEmployee.BranchId = branch.BranchId;
            await _context.BranchEmployees.AddAsync(branchEmployee);
            await _context.SaveChangesAsync();
            #endregion

            #region Branch Image
            BranchImage branchImage = new BranchImage();
            branchImage.BranchImageId = Guid.NewGuid();
            branchImage.BranchId = branch.BranchId;
            branchImage.CreatedDate = DateTime.Now;
            branchImage.UpdatedDate = DateTime.Now;
            branchImage.Status = true;
            branchImage.ImageName = "Hair_Salon212606139.jpg";
            if (branchImage.ImageFile != null)
            {
                branchImage.ImageName = await common.SaveImage(branchImage.ImageFile, _webHostEnvironment);
            }
            await _context.BranchImages.AddAsync(branchImage);
            await _context.SaveChangesAsync();
            #endregion

            return Ok(new Response { Status = "Success", Message = "Business Registered Successfully!" });
        }
    }
}

using LiveMedTest.ApplicationServices;
using LiveMedTest.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiveMedTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCountryController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserCountryController(IUserAppService userAppService) 
        { 
            _userAppService= userAppService;
        }


        [HttpGet]
        public async Task<IEnumerable<UserCountry>> GetUserCompany() {
            var result = await _userAppService.GetUserCountries();
            return result; 
        
        }
    }
}

using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.WebApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace ICS.WebApp.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly DomainContext _domainContext;
        private readonly SystemContext _systemContext;

        public AccountController(
            IUserRepository userRepository,
            IProfileRepository profileRepository,
            IEmployeeRepository employeeRepository,
            DomainContext domainContext,
            SystemContext systemContext)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _employeeRepository = employeeRepository;
            _domainContext = domainContext;
            _systemContext = systemContext;
        }

        [HttpGet]
        [Authorize]
        [Route("details")]
        public  async Task<AccountDetailsDto> GetDetailsAsync()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;

            var userId = Guid.Parse(identityClaims.FindFirst("UserId").Value);

            var profileId = await _userRepository.GetProfileId(userId).ConfigureAwait(false);
            var employeeId = await _userRepository.GetEmployeeId(userId).ConfigureAwait(false);

            var model = new AccountDetailsDto()
            {
                ProfileId = $"{profileId}",
                EmployeeId = $"{employeeId}"
            };

            return model;
        }

        // POST api/account/register
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IHttpActionResult> Register([FromBody] RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = _userRepository.Create(model.UserName, model.Password);
            _systemContext.SaveChanges();

            var newEmployee = _employeeRepository.Create(newUser.Id);
            var newProfile = await _profileRepository.CreateAsync(newUser).ConfigureAwait(false);
            newUser.SetProfile(newProfile);

            _systemContext.SaveChanges();
            _domainContext.SaveChanges();

            /*
            var identityResult = new IdentityResult();

            if (!identityResult.Succeeded)
            {
                return GetErrorResult(identityResult);
            }
            */

            return Ok();
        }

        #region Helpers

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        #endregion
    }
}

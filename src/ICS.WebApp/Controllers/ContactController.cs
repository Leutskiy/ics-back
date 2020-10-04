﻿using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Models;
using ICS.Shared;
using ICS.WebApplication.Commands.Read;
using ICS.WebApplication.Commands.Read.Contracts;
using ICS.WebApplication.Commands.Read.Results;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace ICS.WebApp.Controllers
{
    /// <summary>
    /// Контроллер контактных данных по сотруднику
    /// </summary>
    [Authorize]
    [RoutePrefix("api/v1/contact")]
    public class ContactController : ApiController
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeWriteCommand _employeeWriteCommand;
        private readonly IReadCommand<EmployeeResult> _employeeReadCommand;

        public ContactController(
            IEmployeeRepository employeeRepository,
            EmployeeWriteCommand employeeWriteCommand,
            IReadCommand<EmployeeResult> employeeReadCommand)
        {
            Contract.Argument.IsNotNull(employeeRepository, nameof(employeeRepository));
            Contract.Argument.IsNotNull(employeeWriteCommand, nameof(employeeWriteCommand));
            Contract.Argument.IsNotNull(employeeReadCommand, nameof(employeeReadCommand));

            _employeeRepository = employeeRepository;
            _employeeWriteCommand = employeeWriteCommand;
            _employeeReadCommand = employeeReadCommand;
        }

        /*[HttpGet]
        [Route]
        public async Task<EmployeeResult> GetAsync()
        {
            var employeeId = await GetEmployeeIdAsync().ConfigureAwait(false);

            return await _employeeReadCommand.ExecuteAsync(employeeId).ConfigureAwait(false);
        }*/

        [HttpPost]
        [Route("{contactId:guid}")]
        public async Task<Guid> AddOrUpdateAsync(Guid contactId, ContactDto createdContactData)
        {
            Contract.Argument.IsNotNull(createdContactData, nameof(createdContactData));

            var employeeId = await GetEmployeeIdAsync().ConfigureAwait(false);
            return await _employeeWriteCommand.AddOrUpdateContactAsync(employeeId, createdContactData).ConfigureAwait(false);
        }

        private async Task<Guid> GetEmployeeIdAsync()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identityClaims.FindFirst("UserId").Value);
            var employee = await _employeeRepository.GetByUserIdAsync(userId).ConfigureAwait(false);

            return employee.Id;
        }
    }
}
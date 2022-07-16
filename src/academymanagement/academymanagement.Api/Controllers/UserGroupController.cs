using academymanagement.Application.Interfaces;
using academymanagement.Domain.Entities;
using academymanagement.Domain.Messages.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace academymanagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupApp _userGroupApp;

        public UserGroupController(IUserGroupApp userGroupApp)
        {
            _userGroupApp = userGroupApp;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserGroup>> FindById(int id)
        {
            var result = await _userGroupApp.FindByIdAsync(id);

            if (result?.Data == null)
                return NotFound();

            return Ok(result?.Data);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserGroup>> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var result = await _userGroupApp.FindByIdAsync(id);

            if (result?.Data == null)
                return NotFound();

            var response = await _userGroupApp.DeleteAsync(result.Data);

            if (!response.Succeeded)
                return this.UnprocessableEntity(result);

            return Ok();

        }
    }
}

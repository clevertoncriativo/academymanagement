using academymanagement.Application.Interfaces;
using academymanagement.Domain.Entities;
using academymanagement.Domain.Messages;
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
    public class UserController : ControllerBase
    {
        private readonly IUserApp _userApp;

        public UserController(IUserApp userApp)
        {
            _userApp = userApp;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> FindById(int id)
        {
            var result = await _userApp.FindByIdAsync(id);

            if (result?.Model == null)
                return NotFound();

            return Ok(result?.Model);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseMessage<User>>> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var result = await _userApp.FindByIdAsync(id);

            if (result?.Model == null)
                return NotFound();

            var response = await _userApp.DeleteAsync(result.Model);

            if (!response.Succeeded)
                return this.UnprocessableEntity(result);

            return Ok();

        }

        [HttpPost("user")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseMessage<User>>> PostAsync([FromBody] User user)
        {
            var result = await _userApp.SaveAsync(user);

            if (!result.Succeeded)
                return this.UnprocessableEntity(result);

            return CreatedAtAction(nameof(FindById), new { id = result?.Model?.Id }, result?.Model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseMessage<User>>> Put(int id, [FromBody] User user)
        {
            if (id == 0)
                return BadRequest();

            var _user = await _userApp.FindByIdAsync(id);

            if (!_user.Succeeded)
                return this.UnprocessableEntity(_user);

            user.Id = id;

            var result = await _userApp.SaveAsync(user);

            if (!result.Succeeded || result.Model == null)
                return this.UnprocessableEntity(result);

            return CreatedAtAction(nameof(FindById), new { id = result.Model.Id }, result.Model);
        }
    }
}

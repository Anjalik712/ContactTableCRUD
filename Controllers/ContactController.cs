﻿using ContactProject.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var result = await _mediator.Send(new GetAllContactsQuery());
            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditContact(int id,[FromBody] EditContactCommand command)
        { 
            var result= await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _mediator.Send(new DeleteContactCommand(id));
            return Ok(result);
        }
    }
}

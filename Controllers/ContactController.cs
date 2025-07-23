using ContactProject.Requests;
using Core.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactProject.Controllers;

/// <summary>
/// Defines the controller for the contact APIs
/// </summary>

public class ContactController : BaseApiController
{
    private readonly IMediator _mediator;
    public ContactController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gets the contacts
    /// </summary>
    /// <returns></returns>
    [HttpGet("contacts")]
    public async Task<IActionResult> GetContacts()
    {
        var result = await _mediator.Send(new GetAllContactsQuery());
        return Ok(result);

    }

    /// <summary>
    /// Adds a contact
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("contacts")]
    public async Task<IActionResult> AddContact(AddContactCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Update a contact
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("contacts/{id}")]
    public async Task<IActionResult> EditContact(int id,[FromBody] EditContactCommand command)
    { 
        var result= await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Delete a contact
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("contacts/{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        var result = await _mediator.Send(new DeleteContactCommand(id));
        return Ok(result);
    }
}

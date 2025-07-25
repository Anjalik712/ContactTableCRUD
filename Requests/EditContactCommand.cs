using ContactProject.Data;
using ContactProject.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactProject.Requests;

/// <summary>
/// CQRS Command class to create contact
/// </summary>
public record EditContactCommand() : IRequest<bool>
{
    /// <summary>
    /// Gets or sets the Id.
    /// </summary>
    /// <value>
    /// The first Id.
    /// </value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    /// <value>
    /// The first name.
    /// </value>
    public required string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the middle name.
    /// </summary>
    /// <value>
    /// The middle name.
    /// </value>
    public string? MiddleName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    /// <value>
    /// The last name.
    /// </value>
    public string? LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the age.
    /// </summary>
    /// <value>
    /// The first age.
    /// </value>
    public int Age { get; set; }
   
    /// <summary>
    /// Gets or sets the date of birth.
    /// </summary>
    /// <value>
    /// The date of birth.
    /// </value>
    public DateOnly DOB { get; set; }
}

/// <summary>
/// CQRS Command Handler to edit a contact
/// </summary>
public class EditContactCommandHandler : IRequestHandler<EditContactCommand, bool>
{
    /// <summary>
    /// The application db context
    /// </summary>
    private readonly ContactDbContext _context;

    public EditContactCommandHandler(ContactDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Handles the specified request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> Handle(EditContactCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the contact record from the database using the given ID
        var contact = await _context.Contact.FirstOrDefaultAsync(x => x.Id == request.Id);
        
        //If contact exits, update its fields
        if (contact != null) 
        { 
            contact.FirstName = request.FirstName;
            contact.MiddleName = request.MiddleName;
            contact.LastName = request.LastName;
            contact.Age = request.Age;
            contact.DOB = request.DOB;

            // Set audit fields
            contact.ModifiedBy = "Anjali";
            contact.ModifiedDate = DateTime.UtcNow;

            // Save the changes and return true if at least one row is affected 
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
        else
        {
            // Return false if the contact with the given ID does not exist
            return false;
        }
    }
}

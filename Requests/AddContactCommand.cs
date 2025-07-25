using MediatR;
using ContactProject.Entities;
using ContactProject.Data;

namespace ContactProject.Requests;

/// <summary>
/// CQRS Command class to create contact
/// </summary>
public record AddContactCommand() : IRequest<Contact>
{
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
    /// The age.
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
/// CQRS Command Handler to add a contact
/// </summary>
public class AddContactCommandHandler : IRequestHandler<AddContactCommand, Contact>
{
    /// <summary>
    /// The application db context
    /// </summary>
    private readonly ContactDbContext _context;

    public AddContactCommandHandler(ContactDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Contact> Handle(AddContactCommand request, CancellationToken cancellationToken)
    {
        // Create a new Contact object and populate its properties from the request
        var contact = new Contact
        {
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            LastName = request.LastName,
            Age = request.Age,
            DOB = request.DOB,

            // Set audit fields
            CreatedBy = "Anjali", // Hardcoded creator name
            CreatedDate = DateTime.UtcNow, //set current date as created date
        };

        // Add the new contact to the DbContext
        _context.Contact.Add(contact);

        // Save the changes asynchronously to the database
        await _context.SaveChangesAsync(cancellationToken);

        // Return the created contact entity
        return contact; 
    }

}

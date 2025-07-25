using ContactProject.Data;
using MediatR;

namespace ContactProject.Requests;

/// <summary>
/// CQRS Command class to delete contact
/// </summary>
public record DeleteContactCommand(int Id) : IRequest<bool>
{
}

/// <summary>
/// CQRS Command Handler to delete a contact
/// </summary>
public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, bool>
{
    /// <summary>
    /// The application db context
    /// </summary>
    private readonly ContactDbContext _context;

    public DeleteContactCommandHandler(ContactDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Handles the specified request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        // Find the contact entity by ID
        var contact = await _context.Contact.FindAsync(request.Id);

        // If the contact exists, remove it from the DbContext
        if (contact != null)
        {
            _context.Contact.Remove(contact);

            // Save changes and return true if at least one row was affected
            return await _context.SaveChangesAsync() > 0;
        }

        // Return false if contact not found
        return false;
    }
}

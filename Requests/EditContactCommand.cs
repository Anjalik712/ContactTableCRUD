using ContactProject.Data;
using ContactProject.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactProject.Requests
{
    public record EditContactCommand() : IRequest<bool>
    {
        public int Id { get; set; }
        public required string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateOnly DOB { get; set; }
    }
    public class EditContactCommandHandler : IRequestHandler<EditContactCommand, bool>
    {
        private readonly ContactDbContext _context;

        public EditContactCommandHandler(ContactDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(EditContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contact.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (contact != null) 
            { 
                contact.FirstName = request.FirstName;
                contact.MiddleName = request.MiddleName;
                contact.LastName = request.LastName;
                contact.Age = request.Age;
                contact.DOB = request.DOB;
                contact.ModifiedBy = "Anjali";
                contact.ModifiedDate = DateTime.UtcNow;
                return await _context.SaveChangesAsync(cancellationToken)>0;
            }
            else
            {
                return false;
            }
        }
    }
}

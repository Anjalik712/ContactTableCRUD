using MediatR;
using ContactProject.Entities;
using ContactProject.Data;

namespace ContactProject.Requests
{
    public record AddContactCommand() : IRequest<Contact>
    {
        public required string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateOnly DOB { get; set; }
    }
    public class AddContactCommandHandler : IRequestHandler<AddContactCommand, Contact>
    {
        private readonly ContactDbContext _context;

        public AddContactCommandHandler(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<Contact> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Age = request.Age,
                DOB = request.DOB,
                CreatedBy = "Anjali",
                CreatedDate = DateTime.UtcNow,
            };
            _context.Contact.Add(contact);
            await _context.SaveChangesAsync(cancellationToken);
            return contact; 
        }
    
    }

}

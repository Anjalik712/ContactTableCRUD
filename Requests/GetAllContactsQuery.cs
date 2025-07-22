using ContactProject.Data;
using ContactProject.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactProject.Requests
{
    public class GetAllContactsQuery : IRequest<List<Contact>>
    {
        
    }
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<Contact>>
    {
        private readonly ContactDbContext _context;

        public GetAllContactsQueryHandler(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            // Call the PostgreSQL function
            var contacts = await _context.Contact
                .FromSqlRaw("SELECT * FROM get_all_contacts()")
                .ToListAsync(cancellationToken);

            return contacts;
        }
    }
}

using ContactProject.Data;
using MediatR;

namespace ContactProject.Requests
{
    public record DeleteContactCommand(int Id) : IRequest<bool>
    {
    }
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, bool>
    {
        private readonly ContactDbContext _context;

        public DeleteContactCommandHandler(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contact.FindAsync(request.Id);
            if (contact != null)
            {
                _context.Contact.Remove(contact);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}

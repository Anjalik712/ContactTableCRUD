using ContactProject.Data;
using ContactProject.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactProject.Requests;

/// <summary>
/// Represents a query to get a list of all contacts
/// </summary>
public class GetAllContactsQuery : IRequest<List<Contact>>
{
    
}

/// <summary>
/// Handle the specified query
/// </summary>
public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<Contact>>
{
    /// <summary>
    /// The application db context
    /// </summary>
    private readonly ContactDbContext _context;

    public GetAllContactsQueryHandler(ContactDbContext context)
    {
        _context = context;
    }

    public async Task<List<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        // Define parameters for the PostgreSQL function
        var parameters = new[]
        {       
            new Npgsql.NpgsqlParameter("filters", NpgsqlTypes.NpgsqlDbType.Jsonb) { Value = "{}" }, // No filters applied
            new Npgsql.NpgsqlParameter("orderby", NpgsqlTypes.NpgsqlDbType.Jsonb) { Value = "{}" }, // No ordering
            new Npgsql.NpgsqlParameter("take", NpgsqlTypes.NpgsqlDbType.Integer) { Value = 10 }, // Take first 10 results
            new Npgsql.NpgsqlParameter("skip", NpgsqlTypes.NpgsqlDbType.Integer) { Value = 0 },  // Skip 0 rows
        };
        // Call the PostgreSQL function
        var contacts = await _context.Contact
            .FromSqlRaw("SELECT * FROM get_all_contacts(@filters, @orderby, @take, @skip)", parameters)
            .ToListAsync(cancellationToken);

        return contacts;
    }
}

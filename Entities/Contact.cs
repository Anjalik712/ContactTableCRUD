using System.ComponentModel.DataAnnotations;

namespace ContactProject.Entities;

/// <summary>
/// Entity class for Contact
/// </summary>
public class Contact
{
    /// <summary>
    /// The Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets firstName of the contact
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets middleName of the contact
    /// </summary>
    public string? MiddleName { get; set; }

    /// <summary>
    /// Gets or sets lastName of the contact
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets age of the contact
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Gets or sets dateOfBirth of the contact
    /// </summary>
    public DateOnly DOB { get; set; }

    /// <summary>
    /// Gets or sets the created By of the contact
    /// </summary>
    /// <value>
    /// The created by.
    /// </value>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the created date of the contact
    /// </summary>
    /// <value>
    /// The created date.
    /// </value>
    public DateTime? CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the modified By of the contact
    /// </summary>
    /// <value>
    /// The modified by.
    /// </value>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Gets or sets the modified date of the contact
    /// </summary>
    /// <value>
    /// The modified date.
    /// </value>
    public DateTime? ModifiedDate { get; set; }
}

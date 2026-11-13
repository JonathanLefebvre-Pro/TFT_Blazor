using System.ComponentModel.DataAnnotations;

namespace MovieWebApi.Domain.Entities;

public class PersonDto
{
    [Required]
    public required string FirstName { get; init; }

    [Required]
    public required string LastName { get; init; }
}

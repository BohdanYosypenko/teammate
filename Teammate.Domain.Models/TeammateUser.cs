namespace Teammate.Domain.Models
{
  public class TeammateUser
  {
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public byte? Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? City { get; set; }
  }
}

namespace Teammate.Data.Entities;

public class TeammateUserEntity : IBaseEntity
{
  public int Id { get; set; }
  public string AccountFID { get; set; }
  public string? FirstName { get; set; }

  public string? SecondName { get; set; }

  public byte? Gender { get; set; }

  public DateTime DateOfBirth { get; set; }

  public string? City { get; set; }

  public AccountUser AccountUser { get; set; }
  public List<MessageEntity> SendedMessages { get; set; }
  public List<MessageEntity> ReceivedMessages { get; set; }
  public List<SportLookupEntity> SportLookups { get; set; }

}

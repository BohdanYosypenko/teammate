namespace Teammate.Data.Entities;

public class MessageEntity : IBaseEntity
{
  public int Id { get; set; }
  public int SenderFID { get; set; }
  public int RecipientFID { get; set; }
  public string MessageText { get; set; }
  public int LinkedMessageFID { get; set; }
  public DateTime SendTime { get; set; }

  public TeammateUserEntity SenderUser { get; set; }
  public TeammateUserEntity RecipientUser { get; set; }
}

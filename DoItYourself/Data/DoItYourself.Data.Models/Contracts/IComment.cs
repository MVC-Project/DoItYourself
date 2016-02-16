namespace DoItYourself.Data.Models.Contracts
{
    public interface IComment
    {
        string Content { get; set; }

        string UserId { get; set; }

        User User { get; set; }
    }
}

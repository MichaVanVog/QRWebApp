namespace Telegram
{
    public interface ITextSender
    {
        Task SendTextAsync(string text);
    }
}
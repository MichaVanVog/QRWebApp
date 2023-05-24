namespace Telegram
{
    public class TextSender : ITextSender
    {
        public async Task SendTextAsync(string text)
        {
            var client = new HttpClient();
            var chatId = "-784748922";
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.telegram.org/bot5147578144:AAFh8OLiaDjWjJPQ3CbRg2sQgpatYwNyMF8/sendMessage?chat_id={chatId}&text={text}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
using QRWebApp.Services;
using Quartz;

namespace QRWebApp.Jobs
{
    public class TelegramMessageSender : IJob
    {
        private readonly IDaysCountFromDb daysCountFromDb;

        public TelegramMessageSender(IDaysCountFromDb daysCountFromDb)
        {
            this.daysCountFromDb = daysCountFromDb;
        }

        public Task Execute(IJobExecutionContext context)
        {
            daysCountFromDb.Get30Days();
            daysCountFromDb.Get7Days();
            daysCountFromDb.Get0Days();
            return Task.FromResult(true);
        }
    }
}

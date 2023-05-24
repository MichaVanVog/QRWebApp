namespace QRWebApp.Services
{
    public interface IDaysCountFromDb
    {
        public void Get30Days();
        public void Get7Days();
        public void Get0Days();
    }
}
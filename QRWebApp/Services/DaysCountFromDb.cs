using QR.Db;
using Telegram;

namespace QRWebApp.Services
{
    public class DaysCountFromDb : IDaysCountFromDb
    {
        private readonly IProductsInDbRepository productsInDbRepository;
        private readonly ITextSender textSender;

        public DaysCountFromDb(IProductsInDbRepository productsInDbRepository, ITextSender textSender)
        {
            this.productsInDbRepository = productsInDbRepository;
            this.textSender = textSender;
        }

        public void Get30Days()
        {
            var productAndDateText = "";
            var dateBefore30Days = DateTime.Now.AddDays(-31);
            var products = productsInDbRepository.GetAll();
            foreach (var product in products)
            {
                var productDate = product.ExpireDate.AddDays(-31);
                if (productDate == DateOnly.FromDateTime(dateBefore30Days))
                {
                    if (product.ProductionDate != product.ExpireDate)
                    {
                        productAndDateText = product.Name + " с датой изготовления " + product.ProductionDate.ToString() + ", осталось 30 дней";
                        textSender.SendTextAsync(productAndDateText);
                    }
                    else
                    {
                        productAndDateText = product.Name + " со сроком годности " + product.ProductionDate.ToString() + ", осталось 30 дней";
                        textSender.SendTextAsync(productAndDateText);
                    }
                }
            }
        }

        public void Get7Days()
        {
            var productAndDateText = "";
            var dateBefore7Days = DateTime.Now.AddDays(-8);
            var products = productsInDbRepository.GetAll();
            foreach (var product in products)
            {
                var productDate = product.ExpireDate.AddDays(-8);
                if (productDate == DateOnly.FromDateTime(dateBefore7Days))
                {
                    if (product.ProductionDate != product.ExpireDate)
                    {
                        productAndDateText = product.Name + " с датой изготовления " + product.ProductionDate.ToString() + ", осталось 7 дней";
                        textSender.SendTextAsync(productAndDateText);
                    }
                    else
                    {
                        productAndDateText = product.Name + " со сроком годности " + product.ProductionDate.ToString() + ", осталось 7 дней";
                        textSender.SendTextAsync(productAndDateText);
                    }
                }
            }
        }

        public void Get0Days()
        {
            var productAndDateText = "";
            var dateBefore0Days = DateTime.Now;
            var products = productsInDbRepository.GetAll();
            foreach (var product in products)
            {
                var productDate = product.ExpireDate;
                if (productDate == DateOnly.FromDateTime(dateBefore0Days))
                {
                    if (product.ProductionDate != product.ExpireDate)
                    {
                        productAndDateText = product.Name + " с датой изготовления " + product.ProductionDate.ToString() + ", снять с продажи";
                        textSender.SendTextAsync(productAndDateText);
                    }
                    else
                    {
                        productAndDateText = product.Name + " со сроком годности " + product.ProductionDate.ToString() + ", снять с продажи";
                        textSender.SendTextAsync(productAndDateText);
                    }
                }
            }
        }
    }
}

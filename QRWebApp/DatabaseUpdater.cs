//using QR.Db;

//namespace QRWebApp
//{
//    public class DatabaseUpdater
//    {
//        private readonly IProductsInDbRepository productsRepository;

//        public DatabaseUpdater(IProductsInDbRepository productsRepository)
//        {
//            this.productsRepository = productsRepository;
//        }

//        public async void Update()
//        {
//            using (var client = new HttpClient())
//            {
//                var request = new HttpRequestMessage(HttpMethod.Get, "https://beercow.quickresto.ru/platform/online/api/list?moduleName=warehouse.nomenclature.dish&className=ru.edgex.quickresto.modules.warehouse.nomenclature.dish.Dish");
//                request.Headers.Add("Authorization", "Basic YmVlcmNvdzpiMG5IY1UyZQ==");
//                var content = new StringContent(string.Empty);
//                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
//                request.Content = content;
//                var response = await client.SendAsync(request);
//                response.EnsureSuccessStatusCode();
//                var myJsonResponse = await response.Content.ReadAsStringAsync();
//                productsRepository.AddProducts(JsonConvert.DeserializeObject<List<Product>>(myJsonResponse));
//            }
//            }
//        }
//}

using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using RobloxShop.Repository;
using RobloxShop.Repository.Interfaces;
using RobloxShop.Services;
using RobloxShop.Services.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Utils
{
    public static class DependencyResolver
    {

        private static readonly ServiceProvider _serviceProvider;

        private static readonly string _dbConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config/DBConfig.json");

        static DependencyResolver()
        {
            string jsonConfig = File.ReadAllText(_dbConfigPath);

            JObject jObject = JObject.Parse(jsonConfig);

            string connectionString = jObject["ConnectionStrings"]["POSTGRE"].Value<string>();

            ShopContext.ConnectionString = connectionString;

            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<ICheckPositionRepository, CheckPositionRepository>();
            services.AddSingleton<ICheckRepository, CheckRepository>();
            services.AddSingleton<IPaymentProviderRepository, PaymentProviderRepository>();
            services.AddSingleton<IPaymentRepository, PaymentRepository>();
            services.AddSingleton<IProductCartItemRepository, ProductCartItemRepository>();
            services.AddSingleton<IProductCartRepository, ProductCartRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IPromocodeRepository, PromocodeRepository>();
            services.AddSingleton<ITagRepository, TagRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IWarehouseStockRepository, WarehouseStockRepository>();
            services.AddSingleton<IWarehouseRepository, WarehouseRepository>();

            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<ICheckPositionService, CheckPositionService>();
            services.AddSingleton<ICheckService, CheckService>();
            services.AddSingleton<IPaymentProviderService, PaymentProviderService>();
            services.AddSingleton<IPaymentService, PaymentService>();
            services.AddSingleton<IProductCartItemService, ProductCartItemService>();
            services.AddSingleton<IProductCartService, ProductCartService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IPromocodeService, PromocodeService>();
            services.AddSingleton<ITagService, TagService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IWarehouseService, WarehouseService>();
            services.AddSingleton<IWarehouseStockService, WarehouseStockService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }

    }
}

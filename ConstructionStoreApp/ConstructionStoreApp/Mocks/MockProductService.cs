using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionStoreApp.ViewModels;
using Xamarin.Forms;

namespace ConstructionStoreApp.Services.Mocks
{
    public class MockProductService : IProductService
    {
        public async Task<IEnumerable<Product>> GetFurnitureHardwareProducts()
        {
            await Task.Delay(100); // Імітація затримки

            return new List<Product>
            {
                new Product
                {
                    Id = "1",
                    Name = "Ручка меблева ALFA",
                    Price = 75.50m,
                    ImageUrl = "Images/handle_alfa",
                    StockQuantity = 15,
                    Description = "Преміум ручка з нержавіючої сталі"
                },
                new Product
                {
                    Id = "2",
                    Name = "Петля рояльна",
                    Price = 12.80m,
                    ImageUrl = "Images/hinge_royal",
                    StockQuantity = 0,
                    Description = "Класичні меблеві петлі"
                },
                new Product
                {
                    Id = "3",
                    Name = "Напрямна для шухляди",
                    Price = 45.20m,
                    ImageUrl = "Images/drawer_rail",
                    StockQuantity = 8,
                    Description = "Телескопічна напрямна 400мм"
                },
                new Product
                {
                    Id = "4",
                    Name = "Стільниця кухонна",
                    Price = 1200.00m,
                    ImageUrl = "Images/kitchen_countertop",
                    StockQuantity = 3,
                    Description = "Дубова стільниця товщиною 40мм"
                },
                new Product
                {
                    Id = "5",
                    Name = "Ніжка меблева",
                    Price = 85.75m,
                    ImageUrl = "Images/furniture_leg",
                    StockQuantity = 22,
                    Description = "Хромована ніжка висотою 70см"
                },
                new Product
                {
                    Id = "6",
                    Name = "Фасад MDF",
                    Price = 320.40m,
                    ImageUrl = "Images/mdf_front",
                    StockQuantity = 5,
                    Description = "Фасад з MDF з плівкою ПВХ"
                },
                new Product
                {
                    Id = "7",
                    Name = "Меблевий щит",
                    Price = 180.90m,
                    ImageUrl = "Images/panel_board",
                    StockQuantity = 12,
                    Description = "Сосновий щит 2000x600x18мм"
                },
                new Product
                {
                    Id = "8",
                    Name = "Кріплення для полиць",
                    Price = 8.50m,
                    ImageUrl = "Images/shelf_bracket",
                    StockQuantity = 0,
                    Description = "Металічні кронштейни для полиць"
                }
            };
        }
    }
}
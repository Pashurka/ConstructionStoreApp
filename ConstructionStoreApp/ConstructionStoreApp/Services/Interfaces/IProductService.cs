using ConstructionStoreApp.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductService
{
    Task<IEnumerable<Product>> GetFurnitureHardwareProducts();
}
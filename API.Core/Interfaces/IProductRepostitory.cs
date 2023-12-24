using API.Core.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IProductRepostitory
    {
        Task<Product> GetProductByIdAsync(int id);

        /// <summary>
        /// Tüm ürünleri listeler
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<Product>> GetProductAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

        Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync();
    }
}

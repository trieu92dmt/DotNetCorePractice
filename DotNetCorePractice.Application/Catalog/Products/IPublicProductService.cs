using DotNetCorePractice.ViewModels.Catalog.Products;
using DotNetCorePractice.ViewModels.Catalog.Products.Public;
using DotNetCorePractice.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCorePractice.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public Task<PagedResult<ProductViewModel>> GetAllByCateogryId(GetProductPagingRequest request);
        public Task<List<ProductViewModel>> GetAll();
    }
}

using DotNetCorePractice.ViewModels.Catalog.ProductImages;
using DotNetCorePractice.ViewModels.Catalog.Products;
using DotNetCorePractice.ViewModels.Catalog.Products.Manage;
using DotNetCorePractice.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCorePractice.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
        Task<ProductViewModel> GetById(int productId, string languageId);
        Task<ProductImageViewModel> GetImageById(int imageId);
        Task<int> AddImage(int productId, ProductImageCreateRequest request);
        Task<int> RemoveImage(int productId, int imageId);
        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);
    }
}

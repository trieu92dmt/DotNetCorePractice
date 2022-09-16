using DotNetCorePractice.ViewModels.Catalog.Categories;
using DotNetCorePractice.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCorePractice.Application.Catalog.Categories
{
    public interface IManageCategoryService
    {
        Task<int> Create(CategoryCreateRequest request);
        Task<int> Update(CategoryUpdateRequest request);
        Task<int> Delete(int categoryId);
        Task<CategoryViewModel> GetById(int categoryId, int languageId);
        Task<PagedResult<PagingRequestBase>> GetAllPaging();
    }
}

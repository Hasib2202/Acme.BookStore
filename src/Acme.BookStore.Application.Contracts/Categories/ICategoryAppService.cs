using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Categories
{
    public interface ICategoryAppService
    {
        Task<CategoryDto> GetAsync(Guid id);

        Task<PagedResultDto<CategoryDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input);

        Task<CategoryDto> UpdateAsync(Guid id, CreateUpdateCategoryDto input);

        Task DeleteAsync(Guid id);
    }
}

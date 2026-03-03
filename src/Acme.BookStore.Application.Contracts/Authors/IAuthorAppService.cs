using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Authors
{
    public interface IAuthorAppService
    {
        Task<AuthorDto> GetAsync(Guid id);

        Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<AuthorDto> CreateAsync(CreateUpdateAuthorDto input);

        Task<AuthorDto> UpdateAsync(Guid id, CreateUpdateAuthorDto input);

        Task DeleteAsync(Guid id);
    }
}

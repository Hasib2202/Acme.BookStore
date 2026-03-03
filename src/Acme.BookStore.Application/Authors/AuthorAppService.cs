using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Acme.BookStore.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Volo.Abp;

namespace Acme.BookStore.Authors;

[Authorize(BookStorePermissions.Authors.Default)]
public class AuthorAppService : ApplicationService, IAuthorAppService
{
    private readonly IRepository<Author, Guid> _repository;

    public AuthorAppService(IRepository<Author, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<AuthorDto> GetAsync(Guid id)
    {
        var author = await _repository.GetAsync(id);
        return ObjectMapper.Map<Author, AuthorDto>(author);
    }

    public async Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var queryable = await _repository.GetQueryableAsync();

        var totalCount = await AsyncExecuter.CountAsync(queryable);

        var authors = await AsyncExecuter.ToListAsync(
            queryable
                .OrderBy(input.Sorting.IsNullOrWhiteSpace() ? "Name" : input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
        );

        return new PagedResultDto<AuthorDto>(
            totalCount,
            ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors)
        );
    }

    [Authorize(BookStorePermissions.Authors.Create)]
    public async Task<AuthorDto> CreateAsync(CreateUpdateAuthorDto input)
    {
        var author = ObjectMapper.Map<CreateUpdateAuthorDto, Author>(input);
        await _repository.InsertAsync(author);

        return ObjectMapper.Map<Author, AuthorDto>(author);
    }

    [Authorize(BookStorePermissions.Authors.Edit)]
    public async Task<AuthorDto> UpdateAsync(Guid id, CreateUpdateAuthorDto input)
    {
        var author = await _repository.GetAsync(id);

        ObjectMapper.Map(input, author);

        await _repository.UpdateAsync(author);

        return ObjectMapper.Map<Author, AuthorDto>(author);
    }

    [Authorize(BookStorePermissions.Authors.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        var author = await _repository.GetAsync(id);

        if (author.Books?.Any() == true)
        {
            throw new UserFriendlyException("Cannot delete author with existing books.");
        }

        await _repository.DeleteAsync(author);
    }
}
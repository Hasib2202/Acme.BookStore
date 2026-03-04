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

namespace Acme.BookStore.Categories;

[Authorize(BookStorePermissions.Authors.Default)]
public class CategoryAppService : ApplicationService, ICategoryAppService
{
    private readonly IRepository<Category, Guid> _repository;

    public CategoryAppService(IRepository<Category, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<CategoryDto> GetAsync(Guid id)
    {
        var category = await _repository.GetAsync(id);
        return ObjectMapper.Map<Category, CategoryDto>(category);
    }

    public async Task<PagedResultDto<CategoryDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var queryable = await _repository.GetQueryableAsync();

        var totalCount = await AsyncExecuter.CountAsync(queryable);

        var categories = await AsyncExecuter.ToListAsync(
            queryable
                .OrderBy(input.Sorting.IsNullOrWhiteSpace() ? "Name" : input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
        );

        return new PagedResultDto<CategoryDto>(
            totalCount,
            ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories)
        );
    }

    [Authorize(BookStorePermissions.Authors.Create)]
    public async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
    {
        var category = ObjectMapper.Map<CreateUpdateCategoryDto, Category>(input);
        await _repository.InsertAsync(category);

        return ObjectMapper.Map<Category, CategoryDto>(category);
    }

    [Authorize(BookStorePermissions.Authors.Edit)]
    public async Task<CategoryDto> UpdateAsync(Guid id, CreateUpdateCategoryDto input)
    {
        var category = await _repository.GetAsync(id);

        ObjectMapper.Map(input, category);

        await _repository.UpdateAsync(category);

        return ObjectMapper.Map<Category, CategoryDto>(category);
    }

    [Authorize(BookStorePermissions.Authors.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}


using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using Acme.BookStore.Books;

namespace Acme.BookStore;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class BookStoreBookToBookDtoMapper : MapperBase<Book, BookDto>
{
    [MapProperty(nameof(Book.Author.Name), nameof(BookDto.AuthorName))]
    public override partial BookDto Map(Book source);

    [MapProperty(nameof(Book.Author.Name), nameof(BookDto.AuthorName))]
    public override partial void Map(Book source, BookDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class BookStoreCreateUpdateBookDtoToBookMapper : MapperBase<CreateUpdateBookDto, Book>
{
    public override partial Book Map(CreateUpdateBookDto source);

    public override partial void Map(CreateUpdateBookDto source, Book destination);
}

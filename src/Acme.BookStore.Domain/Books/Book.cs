using Acme.BookStore.Authors;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Books;

public class Book : AuditedAggregateRoot<Guid>
{
    public string Name { get; set; }

    public BookType Type { get; set; }

    public DateTime PublishDate { get; set; }

    public float Price { get; set; }

    // 🔹 Foreign Key
    public Guid AuthorId { get; set; }

    // 🔹 Navigation Property
    public Author? Author { get; set; }
}
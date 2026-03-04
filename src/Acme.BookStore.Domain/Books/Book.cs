using Acme.BookStore.Authors;
using Acme.BookStore.Categories;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Books;

public class Book : AuditedAggregateRoot<Guid>
{
    public string Name { get; set; }

    public DateTime PublishDate { get; set; }

    public float Price { get; set; }

    // 🔹 Foreign Key
    public Guid AuthorId { get; set; }

    // 🔹 Navigation Property
    public Author? Author { get; set; }

    // 🔹 Foreign Key for Category
    public Guid CategoryId { get; set; }

    // 🔹 Navigation Property for Category
    public Category? Category { get; set; }
}
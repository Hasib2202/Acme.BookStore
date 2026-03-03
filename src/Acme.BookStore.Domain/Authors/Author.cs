using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Authors;

public class Author : AuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public DateOnly DateOfBirth { get; set; }

    // 🔹 Navigation
    public ICollection<Book> Books { get; set; }

}
using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Authors
{
    public class AuthorDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Bio { get; set; }

        public DateOnly DateOfBirth { get; set; }
    }
}

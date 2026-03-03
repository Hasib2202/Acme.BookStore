using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.BookStore.Authors
{
    public class CreateUpdateAuthorDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Bio { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }
    }
}

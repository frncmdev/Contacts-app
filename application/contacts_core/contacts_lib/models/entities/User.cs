using System;
using System.Collections.Generic;

namespace contacts_lib.models.entities;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }

    public DateTime LastLogin { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Book> Books { get; } = new List<Book>();
}

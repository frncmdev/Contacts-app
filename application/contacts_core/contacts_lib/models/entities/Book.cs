using System;
using System.Collections.Generic;

namespace contacts_lib.models.entities;

public partial class Book
{
    public string BookId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string BookName { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }

    public virtual ICollection<BookLine> BookLines { get; } = new List<BookLine>();

    public virtual User User { get; set; } = null!;
}

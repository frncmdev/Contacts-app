using System;
using System.Collections.Generic;

namespace contacts_lib.models.entities;

public partial class Contact
{
    public int ContactId { get; set; }

    public string ContactName { get; set; } = null!;

    public string? ContactPhone { get; set; }

    public string? ContactEmail { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }

    public virtual ICollection<BookLine> BookLines { get; } = new List<BookLine>();
}

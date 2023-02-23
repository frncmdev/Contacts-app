using System;
using System.Collections.Generic;

namespace contacts_lib.models.entities;

public partial class BookLine
{
    public int LineId { get; set; }

    public int ContactId { get; set; }

    public string BookId { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;

    public virtual Contact Contact { get; set; } = null!;
}

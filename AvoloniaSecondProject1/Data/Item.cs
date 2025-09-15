using System;
using System.Collections.Generic;

namespace AvoloniaSecondProject1.Data;

public partial class Item
{
    public int IdItem { get; set; }

    public string? ItemName { get; set; }

    public string? Description { get; set; }

    public string? Cost { get; set; }

    public virtual ICollection<Bascket> Basckets { get; set; } = new List<Bascket>();
}

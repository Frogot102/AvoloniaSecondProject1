using System;
using System.Collections.Generic;

namespace AvoloniaSecondProject1.Data;

public partial class Bascket
{
    public int IdBacket { get; set; }

    public int? IdItem { get; set; }

    public int? IdUser { get; set; }

    public string? Count { get; set; }

    public virtual Item? IdItemNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}

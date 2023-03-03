using System;
using System.Collections.Generic;

namespace MyFirst2.Models;

public partial class Phone
{
    public int Id { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int OwnerId { get; set; }
}

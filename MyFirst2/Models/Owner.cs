using System;
using System.Collections.Generic;

namespace MyFirst2.Models;

public partial class Owner
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime BirtDay { get; set; }
}

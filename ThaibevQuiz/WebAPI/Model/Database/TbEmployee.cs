using System;
using System.Collections.Generic;

namespace WebAPI.Model.Database;

public partial class TbEmployee
{
    public string EmpCode { get; set; } = null!;

    public string? EmpName { get; set; }

    public string? EmpSurName { get; set; }

    public string? ComName { get; set; }

    public string? PermisstionType { get; set; }

    public string? IsActive { get; set; }
}

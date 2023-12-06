using System;
using System.Collections.Generic;

namespace WebAPI.Model.Database;

public partial class TbPost
{
    public int PostId { get; set; }

    public string? Postimage { get; set; }

    public DateTime? PostDate { get; set; }

    public string? PostBy { get; set; }

    public virtual ICollection<TbComment> TbComments { get; set; } = new List<TbComment>();
}

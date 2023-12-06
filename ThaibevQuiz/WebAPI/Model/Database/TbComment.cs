using System;
using System.Collections.Generic;

namespace WebAPI.Model.Database;

public partial class TbComment
{
    public int CommentId { get; set; }

    public string? Comment { get; set; }

    public int PostId { get; set; }

    public string? CommentBy { get; set; }

    public virtual TbPost Post { get; set; } = null!;
}

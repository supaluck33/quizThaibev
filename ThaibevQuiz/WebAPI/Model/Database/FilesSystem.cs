using System;
using System.Collections.Generic;

namespace WebAPI.Model.Database;

public partial class FilesSystem
{
    public int Rowno { get; set; }

    public int? FileNo { get; set; }

    public string? FileName { get; set; }

    public DateTime? UploadDate { get; set; }
}

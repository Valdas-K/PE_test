using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblFile
{
    public int FileId { get; set; }

    public string FileType { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public int FileSize { get; set; }

    public string FileBody { get; set; } = null!;

    public DateTime AddTime { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<TblMenuFile> TblMenuFiles { get; set; } = new List<TblMenuFile>();

    public virtual ICollection<TblSoftware> TblSoftwares { get; set; } = new List<TblSoftware>();

    public virtual TblUser User { get; set; } = null!;
}

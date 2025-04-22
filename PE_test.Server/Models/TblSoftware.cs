using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblSoftware
{
    public int SoftwareId { get; set; }

    public DateTime DateCreated { get; set; }

    public string Description { get; set; } = null!;

    public int FileId { get; set; }

    public virtual TblFile File { get; set; } = null!;

    public virtual ICollection<TblDevice> TblDevices { get; set; } = new List<TblDevice>();
}

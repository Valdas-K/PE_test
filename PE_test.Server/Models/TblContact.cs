using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblContact
{
    public int ContactId { get; set; }

    public string Caption { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneNo { get; set; }

    public virtual ICollection<TblObject> TblObjects { get; set; } = new List<TblObject>();
}

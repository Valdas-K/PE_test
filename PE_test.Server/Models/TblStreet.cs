using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblStreet
{
    public int StreetId { get; set; }

    public string Caption { get; set; } = null!;

    public virtual ICollection<TblClient> TblClients { get; set; } = new List<TblClient>();

    public virtual ICollection<TblObject> TblObjects { get; set; } = new List<TblObject>();
}

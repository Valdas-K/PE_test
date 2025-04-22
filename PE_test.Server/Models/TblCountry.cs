using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblCountry
{
    public int CountryId { get; set; }

    public string Caption { get; set; } = null!;

    public virtual ICollection<TblClient> TblClients { get; set; } = new List<TblClient>();

    public virtual ICollection<TblObject> TblObjects { get; set; } = new List<TblObject>();
}

using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblLocation
{
    public int LocationId { get; set; }

    public int CountryId { get; set; }

    public int? ParentLocationId { get; set; }

    public string Caption { get; set; } = null!;

    public byte? LocationTypeId { get; set; }

    public virtual ICollection<TblLocation> InverseParentLocation { get; set; } = new List<TblLocation>();

    public virtual TblLocationType? LocationType { get; set; }

    public virtual TblLocation? ParentLocation { get; set; }

    public virtual ICollection<TblClient> TblClients { get; set; } = new List<TblClient>();

    public virtual ICollection<TblObject> TblObjects { get; set; } = new List<TblObject>();
}

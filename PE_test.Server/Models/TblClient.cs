using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblClient
{
    public int ClientId { get; set; }

    public string Caption { get; set; } = null!;

    public int CountryId { get; set; }

    public int LocationId { get; set; }

    public int? StreetId { get; set; }

    public string StNo { get; set; } = null!;

    public string StLt { get; set; } = null!;

    public string PostCode { get; set; } = null!;

    public string ContactPerson { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Web { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public bool IsBlocked { get; set; }

    public string ClientCode { get; set; } = null!;

    public virtual TblCountry Country { get; set; } = null!;

    public virtual TblLocation Location { get; set; } = null!;

    public virtual TblStreet? Street { get; set; }

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}

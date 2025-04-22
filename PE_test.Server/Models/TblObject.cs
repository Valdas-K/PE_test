using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblObject
{
    public int ObjectId { get; set; }

    public int CountryId { get; set; }

    public int? LocationId { get; set; }

    public int? StreetId { get; set; }

    public string? StNo { get; set; }

    public string? StLt { get; set; }

    public string? RegistrationNo { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public string Description { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public byte ObjectStateId { get; set; }

    public string? StreetAddress { get; set; }

    public int? SupervisorContactId { get; set; }

    public int ObjectPriorityId { get; set; }

    public int ObjectComplexityId { get; set; }

    public DateTime? CertifiedFrom { get; set; }

    public DateTime? CertifiedUntil { get; set; }

    public string? CertNumber { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual TblCountry Country { get; set; } = null!;

    public virtual TblLocation? Location { get; set; }

    public virtual TblObjectComplexity ObjectComplexity { get; set; } = null!;

    public virtual TblObjectPriority ObjectPriority { get; set; } = null!;

    public virtual TblObjectState ObjectState { get; set; } = null!;

    public virtual TblStreet? Street { get; set; }

    public virtual TblContact? SupervisorContact { get; set; }

    public virtual ICollection<TblDevice> TblDevices { get; set; } = new List<TblDevice>();
}

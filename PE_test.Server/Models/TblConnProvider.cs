using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblConnProvider
{
    public int ConnProviderId { get; set; }

    public string Caption { get; set; } = null!;

    public int ConnTypeiD { get; set; }

    public int? EventsConnServerId { get; set; }

    public string? Smscenter { get; set; }

    public string? Apnaddress { get; set; }

    public string? Apnuser { get; set; }

    public string? Apnpassword { get; set; }

    public string? SubnetMask { get; set; }

    public string? Gateway { get; set; }

    public string? Dns { get; set; }

    public virtual TblConnType ConnType { get; set; } = null!;

    public virtual TblConnServer? EventsConnServer { get; set; }

    public virtual ICollection<TblCommunicationCard> TblCommunicationCards { get; set; } = new List<TblCommunicationCard>();
}

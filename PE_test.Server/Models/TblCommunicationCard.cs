using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblCommunicationCard
{
    public int CommCardId { get; set; }

    public int ConnProviderId { get; set; }

    public DateTime ValidityStart { get; set; }

    public DateTime ValidityEnd { get; set; }

    public string? PhoneNo { get; set; }

    public string? CardNo { get; set; }

    public string? Pukcode { get; set; }

    public string? Puk2 { get; set; }

    public string? Pincode { get; set; }

    public string? Pin2 { get; set; }

    public string? Ipaddress { get; set; }

    public int? AccessPort { get; set; }

    public int? HelloPort { get; set; }

    public bool DefaultAccessPort { get; set; }

    public bool ActiveHello { get; set; }

    public bool DefaultHelloLocalPort { get; set; }

    public bool DefaultHelloRemotePort { get; set; }

    public bool ActiveTelnet { get; set; }

    public virtual TblConnProvider ConnProvider { get; set; } = null!;

    public virtual ICollection<TblDevice> TblDevices { get; set; } = new List<TblDevice>();
}

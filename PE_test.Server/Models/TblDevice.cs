using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblDevice
{
    public int DeviceId { get; set; }

    public int ObjectId { get; set; }

    public int DeviceTypeId { get; set; }

    public int? CommCardId { get; set; }

    public int? SerialNo { get; set; }

    public int Identifier { get; set; }

    public int No { get; set; }

    public string Description { get; set; } = null!;

    public int? SoftwareId { get; set; }

    public int? MenuId { get; set; }

    public int ConnCheckTime { get; set; }

    public byte ConnectionStatus { get; set; }

    public DateTime? ConnectionChanged { get; set; }

    public bool RaiseConnEvent { get; set; }

    public byte PowerStatus { get; set; }

    public bool IsProgrammable { get; set; }

    public int LastRequestId { get; set; }

    public DateTime? SyncServerTime { get; set; }

    public DateTime? SyncDeviceTime { get; set; }

    public bool IsDeleted { get; set; }

    public short MemorySram { get; set; }

    public short MemoryFlash { get; set; }

    public byte RequestPriorityId { get; set; }

    public bool UseConnLimit { get; set; }

    public short ConnLimitKb { get; set; }

    public DateTime? SyncRequestTime { get; set; }

    public int? RequestPassword { get; set; }

    public virtual TblCommunicationCard? CommCard { get; set; }

    public virtual TblDeviceType DeviceType { get; set; } = null!;

    public virtual TblMemoryType MemoryFlashNavigation { get; set; } = null!;

    public virtual TblMemoryType MemorySramNavigation { get; set; } = null!;

    public virtual TblMenuFile? Menu { get; set; }

    public virtual TblObject Object { get; set; } = null!;

    public virtual TblRequestPriority RequestPriority { get; set; } = null!;

    public virtual TblSoftware? Software { get; set; }

    public virtual ICollection<TblDeviceComponent> TblDeviceComponents { get; set; } = new List<TblDeviceComponent>();

    public virtual ICollection<TblModulesInDevice> TblModulesInDevices { get; set; } = new List<TblModulesInDevice>();
}

using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public int ClientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int LanguageId { get; set; }

    public string PhoneNo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public bool IsBlocked { get; set; }

    public bool IsMobileEnabled { get; set; }

    public string Position { get; set; } = null!;

    public string Organization { get; set; } = null!;

    public bool AlarmSndOff { get; set; }

    public string? LastWebUrl { get; set; }

    public Guid Guid { get; set; }

    public string? PinCode { get; set; }

    public int LoginFailCount { get; set; }

    public Guid? UniqueLink { get; set; }

    public string? UserSesionId { get; set; }

    public virtual TblClient Client { get; set; } = null!;

    public virtual TblLanguage Language { get; set; } = null!;

    public virtual ICollection<TblFile> TblFiles { get; set; } = new List<TblFile>();

    public virtual ICollection<TblModulesInDevice> TblModulesInDevices { get; set; } = new List<TblModulesInDevice>();
}

using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblLanguage
{
    public int LanguageId { get; set; }

    public string Caption { get; set; } = null!;

    public bool IsDefault { get; set; }

    public bool IsDeleted { get; set; }

    public string? CultureName { get; set; }

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}

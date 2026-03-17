using System;
using System.Collections.Generic;

namespace AuthRBAC_MVC.Models;

public partial class LoginLog
{
    public int LogId { get; set; }

    public int? UserId { get; set; }

    public DateTime? LoginTime { get; set; }

    public DateTime? LogoutTime { get; set; }

    public string? Ipaddress { get; set; }

    public virtual User? User { get; set; }
}

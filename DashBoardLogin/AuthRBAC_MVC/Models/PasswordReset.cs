using System;
using System.Collections.Generic;

namespace AuthRBAC_MVC.Models;

public partial class PasswordReset
{
    public int ResetId { get; set; }

    public int? UserId { get; set; }

    public string? ResetToken { get; set; }

    public DateTime? ExpiryTime { get; set; }

    public virtual User? User { get; set; }
}

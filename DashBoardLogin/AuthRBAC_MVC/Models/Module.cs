using System;
using System.Collections.Generic;

namespace AuthRBAC_MVC.Models;

public partial class Module
{
    public int ModuleId { get; set; }

    public string? ModuleName { get; set; }

    public string? ControllerName { get; set; }

    public string? ActionName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<RoleModule> RoleModules { get; set; } = new List<RoleModule>();
}

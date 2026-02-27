using System;
using System.Collections.Generic;

namespace ScoreDbMVC.Models;

public partial class Project
{
    public int Id { get; set; }

    public int? RollNumber { get; set; }

    public string? Name { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employees? Employee { get; set; }
}

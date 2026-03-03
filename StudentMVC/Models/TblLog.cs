using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentPortalMvc.Models;

[Table("tblLog")]
public partial class TblLog
{
    public int StudentId { get; set; }

    [Key]
    public int LogId { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? Info { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("TblLogs")]
    public virtual Student Student { get; set; } = null!;
}

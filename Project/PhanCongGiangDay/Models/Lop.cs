using System;
using System.Collections.Generic;

namespace PhanCongGiangDay.Models;

public partial class Lop
{
    public string MaLop { get; set; } = null!;

    public string MaKhoaDt { get; set; } = null!;

    public string? TenLop { get; set; }

    public int? SoSv { get; set; }

    public virtual ICollection<LopHocPhan> LopHocPhans { get; set; } = new List<LopHocPhan>();

    public virtual KhoaDt MaKhoaDtNavigation { get; set; } = null!;
}

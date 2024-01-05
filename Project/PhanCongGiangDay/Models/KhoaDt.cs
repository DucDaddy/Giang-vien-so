using System;
using System.Collections.Generic;

namespace PhanCongGiangDay.Models;

public partial class KhoaDt
{
    public string MaKhoaDt { get; set; } = null!;

    public string MaNganh { get; set; } = null!;

    public string? TenKhoaDt { get; set; }

    public int? NamNhap { get; set; }

    public int? SoNamDt { get; set; }

    public virtual ICollection<HocPhan> HocPhans { get; set; } = new List<HocPhan>();

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();

    public virtual Nganh MaNganhNavigation { get; set; } = null!;
}

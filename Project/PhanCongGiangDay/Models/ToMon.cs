using System;
using System.Collections.Generic;

namespace PhanCongGiangDay.Models;

public partial class ToMon
{
    public string MaToMon { get; set; } = null!;

    public string MaKhoa { get; set; } = null!;

    public string? TenToMon { get; set; }

    public int? SoGv { get; set; }

    public virtual ICollection<HocPhan> HocPhans { get; set; } = new List<HocPhan>();

    public virtual Khoa MaKhoaNavigation { get; set; } = null!;

    public virtual ICollection<ThongTinGv> ThongTinGvs { get; set; } = new List<ThongTinGv>();
}

using System;
using System.Collections.Generic;

namespace PhanCongGiangDay.Models;

public partial class LopHocPhan
{
    public string MaLopHp { get; set; } = null!;

    public string MaHocPhan { get; set; } = null!;

    public string? MaGv { get; set; }

    public string? TenLopHp { get; set; }

    public int? SiSo { get; set; }

    public int? SoDk { get; set; }

    public string MaLop { get; set; } = null!;

    public virtual ICollection<GiaiDoan> GiaiDoans { get; set; } = new List<GiaiDoan>();

    public virtual ThongTinGv? MaGvNavigation { get; set; }

    public virtual HocPhan MaHocPhanNavigation { get; set; } = null!;

    public virtual Lop MaLopNavigation { get; set; } = null!;
}

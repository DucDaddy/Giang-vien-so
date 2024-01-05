using System;
using System.Collections.Generic;

namespace PhanCongGiangDay.Models;

public partial class ThongTinGv
{
    public string MaGv { get; set; } = null!;

    public string MaToMon { get; set; } = null!;

    public string? HoGv { get; set; }

    public string? TenGv { get; set; }

    public DateTime? NgaySinh { get; set; }

    public bool? GioiTinh { get; set; }

    public string? DienThoai { get; set; }

    public string? ChucVu { get; set; }

    public string? TenDayDu { get; set; }

    public string? Anh { get; set; }

    public virtual ICollection<LopHocPhan> LopHocPhans { get; set; } = new List<LopHocPhan>();

    public virtual ToMon MaToMonNavigation { get; set; } = null!;
}

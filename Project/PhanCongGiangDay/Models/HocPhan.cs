using System;
using System.Collections.Generic;

namespace PhanCongGiangDay.Models;

public partial class HocPhan
{
    public string MaHocPhan { get; set; } = null!;

    public string MaToMon { get; set; } = null!;

    public string MaKhoaDt { get; set; } = null!;

    public string? TenHocPhan { get; set; }

    public int? SoTinChi { get; set; }

    public int? LyThuyet { get; set; }

    public int? ThaoLuan { get; set; }

    public int? ThietKeMonHoc { get; set; }

    public int? BaiTapLon { get; set; }

    public int? ThiNghiem { get; set; }

    public int? ThucHanh { get; set; }

    public int? TuHoc { get; set; }

    public virtual ICollection<LopHocPhan> LopHocPhans { get; set; } = new List<LopHocPhan>();

    public virtual KhoaDt MaKhoaDtNavigation { get; set; } = null!;

    public virtual ToMon MaToMonNavigation { get; set; } = null!;
}

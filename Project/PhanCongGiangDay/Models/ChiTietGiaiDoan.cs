using System;
using System.Collections.Generic;

namespace PhanCongGiangDay.Models;

public partial class ChiTietGiaiDoan
{
    public string MaCtgd { get; set; } = null!;

    public string MaGiaiDoan { get; set; } = null!;

    public string MaPhong { get; set; } = null!;

    public int? Thu { get; set; }

    public int? Tiet { get; set; }

    public virtual GiaiDoan MaGiaiDoanNavigation { get; set; } = null!;

    public virtual PhongHoc MaPhongNavigation { get; set; } = null!;
}

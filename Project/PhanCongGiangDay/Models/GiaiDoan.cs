using System;
using System.Collections.Generic;

namespace PhanCongGiangDay.Models;

public partial class GiaiDoan
{
    public string MaGiaiDoan { get; set; } = null!;

    public string MaLopHp { get; set; } = null!;

    public string? TenGiaiDoan { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public virtual ICollection<ChiTietGiaiDoan> ChiTietGiaiDoans { get; set; } = new List<ChiTietGiaiDoan>();

    public virtual LopHocPhan MaLopHpNavigation { get; set; } = null!;
}

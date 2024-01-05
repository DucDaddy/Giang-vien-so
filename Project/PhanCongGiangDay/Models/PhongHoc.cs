using System;
using System.Collections.Generic;

namespace PhanCongGiangDay.Models;

public partial class PhongHoc
{
    public string MaPhong { get; set; } = null!;

    public string? TenPhong { get; set; }

    public string? DiaDiem { get; set; }

    public virtual ICollection<ChiTietGiaiDoan> ChiTietGiaiDoans { get; set; } = new List<ChiTietGiaiDoan>();
}

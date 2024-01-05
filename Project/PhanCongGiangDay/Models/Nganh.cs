using System;
using System.Collections.Generic;

namespace PhanCongGiangDay.Models;

public partial class Nganh
{
    public string MaNganh { get; set; } = null!;

    public string MaKhoa { get; set; } = null!;

    public string? TenNganh { get; set; }

    public virtual ICollection<KhoaDt> KhoaDts { get; set; } = new List<KhoaDt>();
}

using System;
using System.Collections.Generic;

namespace PhanCongGiangDay.Models;

public partial class Khoa
{
    public string MaKhoa { get; set; } = null!;

    public string? TenKhoa { get; set; }

    public virtual ICollection<ToMon> ToMons { get; set; } = new List<ToMon>();
}

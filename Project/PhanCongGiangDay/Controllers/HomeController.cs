using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using OfficeOpenXml;
using PhanCongGiangDay.Models;
using System.Diagnostics;
using System.Globalization;
using System.Security.Policy;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace PhanCongGiangDay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        QlgiangDayContext db = new QlgiangDayContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult HomePage()
        {
            DateTime ngay = DateTime.Now;
            ThoiGian.ngay = ngay.Day;
            ThoiGian.thang = ngay.Month;
            ThoiGian.nam = ngay.Year;
            return View();
        }

        //Action chọn file excel
        public IActionResult Index()
        {
            return View();
        }

        //Xử lý file excel được chọn
        [HttpPost]
        public IActionResult ProcessExcel(IFormFile excelFile, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                ModelState.AddModelError("excelFile", "Please select an Excel file.");
                return View("Index");
            }

            if (ImportData(excelFile, hostingEnvironment))
            {
                return RedirectToAction("LopHocPhans", "Home");
            }
            return View("Index");
        }

        //Chi tiết đọc file Excel
        private bool ImportData(IFormFile excelFile, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            var result = false;
            try
            {
                //Xóa dữ liệu học kì cũ để chèn học kì mới vô
                db.ChiTietGiaiDoans.RemoveRange(db.ChiTietGiaiDoans);
                db.GiaiDoans.RemoveRange(db.GiaiDoans);
                db.LopHocPhans.RemoveRange(db.LopHocPhans);
                db.SaveChanges();
                //Thêm license cho EPPLUS
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                //sao chep file vao wwwroot (tránh tình trạng lỗi vặt khi chạy)
                string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{excelFile.FileName}";
                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    excelFile.CopyTo(fileStream);
                    fileStream.Flush();
                }
                //lay du lieu
                string path = $"{hostingEnvironment.WebRootPath}\\files\\{excelFile.FileName}";
                var package = new ExcelPackage(new System.IO.FileInfo(path));

                //Hàng chạy đầu tiên để lấy dữ liệu
                int row = 8;

                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                //chạy vòng while để đọc đến cuối danh sách, nếu giá trị hàng ở cột B (TT lớp HP theo dsach) rỗng thì thoát khỏi vòng lặp
                while (worksheet.Cells["B" + row.ToString()].Value != null)
                {
                    //Xử lí xuống hàng tiếp theo đối với ô merge
                    var currentCell = worksheet.Cells[row, 2];
                    int nextRow = row;

                    // Kiểm tra xem ô hiện tại có được merge hay không và tính toán số lượng hàng cần bỏ qua   
                    if (currentCell.Merge)
                    {
                        // Lấy danh sách các MergeCells trong Worksheet
                        var mergeCells = worksheet.MergedCells;

                        // Tìm MergeCell chứa ô hiện tại
                        foreach (var merge in mergeCells)
                        {
                            var range = new ExcelAddress(merge);
                            if (range.Start.Row == row && range.Start.Column == 2)
                            {
                                nextRow = range.End.Row + 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        nextRow = row + 1;
                    }



                    //kiem tra xem cos phai khoa 61 hay khong và lớp đó có thuộc khoa cntt hay không
                    if (worksheet.Cells["AA" + row.ToString()].Value.ToString() == "K61" && worksheet.Cells["Z" + row.ToString()].Value.ToString().Contains("Công nghệ") == true)
                    {


                        string temp = "";
                        //Lấy thông tin của lớp học phần
                        string maHocPhan = worksheet.Cells["C" + row.ToString()].Value.ToString();
                        string tenLopHP = worksheet.Cells["E" + row.ToString()].Value.ToString();
                        string siSo = worksheet.Cells["F" + row.ToString()].Value.ToString();
                        string soDK = worksheet.Cells["G" + row.ToString()].Value.ToString();

                        //Database đang theo quy tắc 1 lớp học phần chỉ chứa 1 lớp -> Chỉ lấy lớp đầu tiên của cột lớp (sẽ cải tiến thêm với những lớp HP có nhiều lớp học)
                        string lop = "";
                        temp = worksheet.Cells["Z" + row.ToString()].Value.ToString();

                        if (temp.Contains("TTV"))
                        {
                            lop = temp.Substring(12, 3);
                        }
                        else
                        {
                            lop = temp[20].ToString();
                        }
                        //Sinh mã cho lớp học phần ( = mã học phần + kiểu học + lớp)
                        string maLopHP = maHocPhan + worksheet.Cells["H" + row.ToString()].Value.ToString() + lop;

                        //Phân công ngẫu nhiên giảng viên (thử nghiệm -> Tương lai: sẽ liên kết bảng GV với Học Phần để chọn ra những học phần GV có thể đảm nhiệm từ đó phân công tự động bước đầu)

                        List<ThongTinGv> lstGVs = db.ThongTinGvs.Where(x => x.MaToMon == "MHT").ToList();
                        List<GiaiDoan> lstGiaiDoans = db.GiaiDoans.Where(x => x.MaLopHp == maLopHP).ToList();
                        string maGV = "";
                        bool hopLe = true;
                        while (maGV == "")
                        {
                            hopLe = true;
                            Random rnd = new Random();
                            int randomNumber = rnd.Next(0, lstGVs.Count - 1);
                            string maGVTemp = lstGVs[randomNumber].MaGv;
                            List<LopHocPhan> lstLopHps = db.LopHocPhans.Where(x => x.MaGv == maGVTemp).ToList();
                            if (lstLopHps.Count == 0)
                            {
                                hopLe = true;
                            }
                            else
                            {
                                List<GiaiDoan> lstGiaiDoans1 = new List<GiaiDoan>();
                                List<GiaiDoan> lst1 = db.GiaiDoans.ToList();
                                foreach (var item in lst1)
                                {
                                    foreach (var item1 in lstLopHps)
                                    {
                                        if (item.MaLopHp == item1.MaLopHp)
                                        {
                                            lstGiaiDoans1.Add(item);
                                        }
                                    }
                                }
                                foreach (var giaiDoan in lstGiaiDoans)
                                {
                                    foreach (var giaiDoan1 in lstGiaiDoans1)
                                    {
                                        if (giaiDoan.NgayKetThuc < giaiDoan1.NgayBatDau || giaiDoan.NgayBatDau > giaiDoan1.NgayKetThuc)
                                        {
                                            hopLe = true;
                                        }
                                        else
                                        {
                                            List<ChiTietGiaiDoan> lstCTGD = db.ChiTietGiaiDoans.Where(x => x.MaGiaiDoan == giaiDoan.MaGiaiDoan).ToList();
                                            List<ChiTietGiaiDoan> lstCTGD1 = db.ChiTietGiaiDoans.Where(x => x.MaGiaiDoan == giaiDoan1.MaGiaiDoan).ToList();
                                            if (lstCTGD.Count > 0 && lstCTGD1.Count > 0)
                                            {
                                                foreach (var ctgd in lstCTGD)
                                                {
                                                    foreach (var ctgd1 in lstCTGD1)
                                                    {
                                                        if (ctgd.Thu == ctgd1.Thu && Math.Abs((decimal)(ctgd.Tiet - ctgd1.Tiet)) <= 2)
                                                        {
                                                            hopLe = false;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                hopLe = true;
                                            }
                                        }
                                    }
                                }
                            }
                            if (hopLe == true)
                            {
                                maGV = maGVTemp;
                                break;
                            }
                        }


                        var lopHocPhan = new LopHocPhan
                        {
                            MaLopHp = maLopHP,
                            MaHocPhan = maHocPhan,
                            MaGv = maGV,
                            TenLopHp = tenLopHP,
                            SiSo = int.Parse(siSo),
                            SoDk = int.Parse(soDK),
                            MaLop = "CNTT" + lop + "K61"
                        };

                        db.LopHocPhans.Add(lopHocPhan);
                        db.SaveChanges();

                        //Lấy thông tin của các giai đoạn
                        int r = row, count = 1;
                        for (int i = r; i <= nextRow - 1; i++)
                        {
                            //Xử lí xuống hàng tiếp theo đối với ô merge
                            var currentCell1 = worksheet.Cells[i, 10];
                            int nextRow1 = i;

                            // Kiểm tra xem ô hiện tại có được merge hay không và tính toán số lượng hàng cần bỏ qua   
                            if (currentCell1.Merge)
                            {
                                // Lấy danh sách các MergeCells trong Worksheet
                                var mergeCells1 = worksheet.MergedCells;

                                // Tìm MergeCell chứa ô hiện tại
                                foreach (var merge in mergeCells1)
                                {
                                    var range = new ExcelAddress(merge);
                                    if (range.Start.Row == i && range.Start.Column == 10)
                                    {
                                        nextRow1 = range.End.Row;
                                        break;
                                    }
                                }
                            }

                            string maGiaiDoan = maLopHP + count.ToString();
                            string tenGiaiDoan = "Giai doan " + count.ToString();
                            //Lấy ngày bắt đầu và ngày kết thúc của giai đoạn
                            temp = worksheet.Cells["J" + i.ToString()].Value.ToString();
                            string input = temp.Substring(0, temp.Length - 3);
                            string[] splitInput = input.Split('-');

                            DateTimeFormatInfo dateFormat = new DateTimeFormatInfo();
                            dateFormat.ShortDatePattern = "dd/MM/yyyy";

                            DateTime ngayBatDau = DateTime.ParseExact(splitInput[0] + "/20" + temp.Substring(12, 2), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            DateTime ngayKetThuc = DateTime.ParseExact(splitInput[1] + "/20" + temp.Substring(12, 2), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                            var giaiDoan = new GiaiDoan
                            {
                                MaGiaiDoan = maGiaiDoan,
                                MaLopHp = maLopHP,
                                TenGiaiDoan = tenGiaiDoan,
                                NgayBatDau = ngayBatDau,
                                NgayKetThuc = ngayKetThuc,
                            };
                            db.GiaiDoans.Add(giaiDoan);
                            db.SaveChanges();

                            //Lấy thông tin của các chi tiết giai đoạn
                            int count1 = 1;
                            for (int k = i; k <= nextRow1; k++)     //k là các dòng chi tiết giai đoạn cần lấy
                            {
                                for (char j = 'L'; j <= 'V'; j++)
                                {
                                    if (worksheet.Cells[j.ToString() + k.ToString()].Value != null)
                                    {
                                        string maChiTietGiaiDoan = maGiaiDoan + count1.ToString();
                                        string tiet = worksheet.Cells[j.ToString() + k.ToString()].Value.ToString().Split(",")[0]; //Vì trường UTC đang tổ chức theo ca nên chỉ lấy giá trị tiết đầu tiên đại diện cho ca
                                        string maPhong = worksheet.Cells[Convert.ToChar(Convert.ToInt32(j) + 1).ToString() + k.ToString()].Value.ToString().Replace("-", "");
                                        string thu = "";
                                        switch (j)
                                        {
                                            case 'L':
                                                thu = "2";
                                                break;
                                            case 'N':
                                                thu = "3";
                                                break;
                                            case 'P':
                                                thu = "4";
                                                break;
                                            case 'R':
                                                thu = "5";
                                                break;
                                            case 'T':
                                                thu = "6";
                                                break;
                                            case 'V':
                                                thu = "7";
                                                break;
                                        }

                                        var chiTietGiaiDoan = new ChiTietGiaiDoan
                                        {
                                            MaCtgd = maChiTietGiaiDoan,
                                            MaGiaiDoan = maGiaiDoan,
                                            MaPhong = maPhong,
                                            Thu = int.Parse(thu),
                                            Tiet = int.Parse(tiet),
                                        };

                                        db.ChiTietGiaiDoans.Add(chiTietGiaiDoan);
                                        db.SaveChanges();

                                        count1++;
                                    }
                                    j++;
                                }
                            }
                            count++;

                            i = nextRow1;

                        }


                    }

                    row = nextRow;
                }
                result = true;

            }
            catch
            {

            }
            return result;
        }


        public IActionResult LopHocPhans()
        {
            var lopHocPhans = db.LopHocPhans.ToList();
            return View(lopHocPhans);
        }

        public IActionResult Update(string maLopHp)
        {
            var lopHocPhan = db.LopHocPhans.FirstOrDefault(x => x.MaLopHp == maLopHp);
            return View(lopHocPhan);
        }

        [HttpPost]
        public IActionResult PhanCong(LopHocPhan l)
        {

            var lopHocPhan = db.LopHocPhans.SingleOrDefault(x => x.MaLopHp == l.MaLopHp);
            
            //Xét xem có bị trùng lịch với các lớp học phần đã được phân công chưa
            if (lopHocPhan != null)
            {
                List<ThongTinGv> lstGVs = db.ThongTinGvs.Where(x => x.MaToMon == "MHT").ToList();
                List<GiaiDoan> lstGiaiDoans = db.GiaiDoans.Where(x => x.MaLopHp == l.MaLopHp).ToList();
                string maGV = l.MaGv;
                bool hopLe = true;

                hopLe = true;
                List<LopHocPhan> lstLopHps = db.LopHocPhans.Where(x => x.MaGv == l.MaGv).ToList();
                if (lstLopHps.Count == 0)
                {
                    hopLe = true;
                }
                else
                {
                    List<GiaiDoan> lstGiaiDoans1 = new List<GiaiDoan>();
                    List<GiaiDoan> lst1 = db.GiaiDoans.ToList();
                    foreach (var item in lst1)
                    {
                        foreach (var item1 in lstLopHps)
                        {
                            if (item.MaLopHp == item1.MaLopHp)
                            {
                                lstGiaiDoans1.Add(item);
                            }
                        }
                    }
                    foreach (var giaiDoan in lstGiaiDoans)
                    {
                        foreach (var giaiDoan1 in lstGiaiDoans1)
                        {
                            if (giaiDoan.NgayKetThuc < giaiDoan1.NgayBatDau || giaiDoan.NgayBatDau > giaiDoan1.NgayKetThuc)
                            {
                                hopLe = true;
                            }
                            else
                            {
                                List<ChiTietGiaiDoan> lstCTGD = db.ChiTietGiaiDoans.Where(x => x.MaGiaiDoan == giaiDoan.MaGiaiDoan).ToList();
                                List<ChiTietGiaiDoan> lstCTGD1 = db.ChiTietGiaiDoans.Where(x => x.MaGiaiDoan == giaiDoan1.MaGiaiDoan).ToList();
                                if (lstCTGD.Count > 0 && lstCTGD1.Count > 0)
                                {
                                    foreach (var ctgd in lstCTGD)
                                    {
                                        foreach (var ctgd1 in lstCTGD1)
                                        {
                                            if (ctgd.Thu == ctgd1.Thu && Math.Abs((decimal)(ctgd.Tiet - ctgd1.Tiet)) <= 2)
                                            {
                                                hopLe = false;
                                                TempData["msg"] = "Không phân công được vì trùng lịch!";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    hopLe = true;
                                }
                            }
                        }
                    }

                }
                if (hopLe == true)
                {
                    TempData["msg"] = "Phân công giảng viên thành công!";
                    lopHocPhan.MaGv = l.MaGv;

                    db.SaveChanges();
                }
                else
                {
                    TempData["msg"] = "Không phân công được vì trùng lịch!";
                }
            }

            return RedirectToAction("LopHocPhans", "Home");
        }

        //Thời khóa biểu toàn khóa
        public IActionResult LichDay()
        {
            

            List<ChiTietLichDay> lst = new List<ChiTietLichDay>();
            List<GiaiDoan> lstGiaiDoan = db.GiaiDoans.ToList();
            foreach (var giaidoan in lstGiaiDoan)
            {
                LopHocPhan lhp = db.LopHocPhans.FirstOrDefault(x => x.MaLopHp == giaidoan.MaLopHp);
                DateTime current = new DateTime(ThoiGian.nam, ThoiGian.thang, ThoiGian.ngay, 12, 0, 0);

                if ((current.CompareTo(giaidoan.NgayBatDau)>0 && current.CompareTo(giaidoan.NgayKetThuc)< 0) || current.CompareTo(giaidoan.NgayBatDau) == 0 || current.CompareTo(giaidoan.NgayKetThuc) == 0)
                {
                    List<ChiTietGiaiDoan> lstCTGD = db.ChiTietGiaiDoans.Where(x => x.MaGiaiDoan == giaidoan.MaGiaiDoan).ToList();
                    if (lstCTGD.Count > 0)
                    {
                        foreach (var ctgd in lstCTGD)
                        {
                            if (ctgd.Thu == (int)current.DayOfWeek + 1)
                            {
                                var lichday = new ChiTietLichDay
                                {
                                    GiangVien = db.ThongTinGvs.FirstOrDefault(x => x.MaGv == lhp.MaGv).TenDayDu,
                                    TenLopHP = lhp.TenLopHp,
                                    Lop = db.Lops.FirstOrDefault(x => x.MaLop == lhp.MaLop).TenLop,
                                    DiaDiem = ctgd.MaPhong,
                                    Tiet = ctgd.Tiet.GetValueOrDefault()
                                };
                                lst.Add(lichday);
                            }
                        }
                    }
                }
            }
            return View(lst);
        }

        //Thời khóa biểu cá nhân
        [HttpPost]
        public IActionResult LichDayCaNhan(string maGV, int ngay, int thang, int nam)
        {
            List<ChiTietLichDay> lst = new List<ChiTietLichDay>();
            if (maGV != "null")
            {
                List<GiaiDoan> lstGiaiDoan = db.GiaiDoans.ToList();
                foreach (var giaidoan in lstGiaiDoan)
                {
                    LopHocPhan lhp = db.LopHocPhans.FirstOrDefault(x => x.MaLopHp == giaidoan.MaLopHp);
                    if (lhp.MaGv == maGV)
                    {
                        DateTime current = new DateTime(ThoiGian.nam, ThoiGian.thang, ThoiGian.ngay, 12, 0, 0);
                        if ((current.CompareTo(giaidoan.NgayBatDau) > 0 && current.CompareTo(giaidoan.NgayKetThuc) < 0) || current.CompareTo(giaidoan.NgayBatDau) == 0 || current.CompareTo(giaidoan.NgayKetThuc) == 0)
                        {
                            List<ChiTietGiaiDoan> lstCTGD = db.ChiTietGiaiDoans.Where(x => x.MaGiaiDoan == giaidoan.MaGiaiDoan).ToList();
                            if (lstCTGD.Count > 0)
                            {
                                foreach (var ctgd in lstCTGD)
                                {
                                    if (ctgd.Thu == (int)current.DayOfWeek + 1)
                                    {
                                        var lichday = new ChiTietLichDay
                                        {
                                            GiangVien = db.ThongTinGvs.FirstOrDefault(x => x.MaGv == lhp.MaGv).TenDayDu,
                                            TenLopHP = lhp.TenLopHp,
                                            Lop = db.Lops.FirstOrDefault(x => x.MaLop == lhp.MaLop).TenLop,
                                            DiaDiem = ctgd.MaPhong,
                                            Tiet = ctgd.Tiet.GetValueOrDefault()
                                        };
                                        lst.Add(lichday);
                                    }
                                }
                            }
                        }
                    }
                }
                return View("LichDay", lst);
            }
            else
            {
                return RedirectToAction("LichDay", "Home");
            }
            
        }

        //Xử lý lịch dạy theo ngày được chọn
        public IActionResult LichDayTheoNgay()
        {
            DateTime ngay = DateTime.ParseExact(Request.Form["ngay"], "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            //TempData["ngay"] = ngay.Day;
            //TempData["thang"] = ngay.Month;
            //TempData["nam"] = ngay.Year;
            //TempData["thu"] = (int)ngay.DayOfWeek + 1;

            ThoiGian.ngay = ngay.Day;
            ThoiGian.thang = ngay.Month;
            ThoiGian.nam = ngay.Year ;

            return RedirectToAction("LichDay");
        }

        
        public IActionResult GiaiDoans()
        {
            var giaiDoans = db.GiaiDoans.ToList();
            return View(giaiDoans);
        }

        public IActionResult ChiTietGiaiDoans()
        {
            var chiTietGiaiDoans = db.ChiTietGiaiDoans.ToList();
            return View(chiTietGiaiDoans);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
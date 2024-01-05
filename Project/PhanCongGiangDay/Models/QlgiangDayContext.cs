using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PhanCongGiangDay.Models;

public partial class QlgiangDayContext : DbContext
{
    public QlgiangDayContext()
    {
    }

    public QlgiangDayContext(DbContextOptions<QlgiangDayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietGiaiDoan> ChiTietGiaiDoans { get; set; }

    public virtual DbSet<GiaiDoan> GiaiDoans { get; set; }

    public virtual DbSet<HocPhan> HocPhans { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<KhoaDt> KhoaDts { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<LopHocPhan> LopHocPhans { get; set; }

    public virtual DbSet<Nganh> Nganhs { get; set; }

    public virtual DbSet<PhongHoc> PhongHocs { get; set; }

    public virtual DbSet<ThongTinGv> ThongTinGvs { get; set; }

    public virtual DbSet<ToMon> ToMons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DUCDADDY\\SQLEXPRESS;Initial Catalog=QLGiangDay;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietGiaiDoan>(entity =>
        {
            entity.HasKey(e => e.MaCtgd).HasName("pk_chitietgiaidoan");

            entity.ToTable("ChiTietGiaiDoan");

            entity.Property(e => e.MaCtgd)
                .HasMaxLength(20)
                .HasColumnName("MaCTGD");
            entity.Property(e => e.MaGiaiDoan).HasMaxLength(20);
            entity.Property(e => e.MaPhong).HasMaxLength(20);

            entity.HasOne(d => d.MaGiaiDoanNavigation).WithMany(p => p.ChiTietGiaiDoans)
                .HasForeignKey(d => d.MaGiaiDoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_chitietgiaidoan_giaidoan");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.ChiTietGiaiDoans)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_chitietgiaidoan_phonghoc");
        });

        modelBuilder.Entity<GiaiDoan>(entity =>
        {
            entity.HasKey(e => e.MaGiaiDoan).HasName("pk_giaidoan");

            entity.ToTable("GiaiDoan");

            entity.Property(e => e.MaGiaiDoan).HasMaxLength(20);
            entity.Property(e => e.MaLopHp)
                .HasMaxLength(20)
                .HasColumnName("MaLopHP");
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            entity.Property(e => e.TenGiaiDoan).HasMaxLength(20);

            entity.HasOne(d => d.MaLopHpNavigation).WithMany(p => p.GiaiDoans)
                .HasForeignKey(d => d.MaLopHp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_giaidoan_lophocphan");
        });

        modelBuilder.Entity<HocPhan>(entity =>
        {
            entity.HasKey(e => e.MaHocPhan).HasName("pk_hocphan");

            entity.ToTable("HocPhan");

            entity.Property(e => e.MaHocPhan).HasMaxLength(20);
            entity.Property(e => e.MaKhoaDt)
                .HasMaxLength(20)
                .HasColumnName("MaKhoaDT");
            entity.Property(e => e.MaToMon).HasMaxLength(20);
            entity.Property(e => e.TenHocPhan).HasMaxLength(50);

            entity.HasOne(d => d.MaKhoaDtNavigation).WithMany(p => p.HocPhans)
                .HasForeignKey(d => d.MaKhoaDt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hocphan_khoadt");

            entity.HasOne(d => d.MaToMonNavigation).WithMany(p => p.HocPhans)
                .HasForeignKey(d => d.MaToMon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hocphan_tomon");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.MaKhoa).HasName("pk_khoa");

            entity.ToTable("Khoa");

            entity.Property(e => e.MaKhoa).HasMaxLength(20);
            entity.Property(e => e.TenKhoa).HasMaxLength(50);
        });

        modelBuilder.Entity<KhoaDt>(entity =>
        {
            entity.HasKey(e => e.MaKhoaDt).HasName("pk_khoadt");

            entity.ToTable("KhoaDT");

            entity.Property(e => e.MaKhoaDt)
                .HasMaxLength(20)
                .HasColumnName("MaKhoaDT");
            entity.Property(e => e.MaNganh).HasMaxLength(20);
            entity.Property(e => e.SoNamDt).HasColumnName("SoNamDT");
            entity.Property(e => e.TenKhoaDt)
                .HasMaxLength(30)
                .HasColumnName("TenKhoaDT");

            entity.HasOne(d => d.MaNganhNavigation).WithMany(p => p.KhoaDts)
                .HasForeignKey(d => d.MaNganh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_khoadt_nganh");
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.MaLop).HasName("pk_lop");

            entity.ToTable("Lop");

            entity.Property(e => e.MaLop).HasMaxLength(20);
            entity.Property(e => e.MaKhoaDt)
                .HasMaxLength(20)
                .HasColumnName("MaKhoaDT");
            entity.Property(e => e.SoSv).HasColumnName("SoSV");
            entity.Property(e => e.TenLop).HasMaxLength(30);

            entity.HasOne(d => d.MaKhoaDtNavigation).WithMany(p => p.Lops)
                .HasForeignKey(d => d.MaKhoaDt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_lop_khoadt");
        });

        modelBuilder.Entity<LopHocPhan>(entity =>
        {
            entity.HasKey(e => e.MaLopHp).HasName("pk_lophocphan");

            entity.ToTable("LopHocPhan");

            entity.Property(e => e.MaLopHp)
                .HasMaxLength(20)
                .HasColumnName("MaLopHP");
            entity.Property(e => e.MaGv)
                .HasMaxLength(20)
                .HasColumnName("MaGV");
            entity.Property(e => e.MaHocPhan).HasMaxLength(20);
            entity.Property(e => e.MaLop).HasMaxLength(20);
            entity.Property(e => e.SoDk).HasColumnName("SoDK");
            entity.Property(e => e.TenLopHp)
                .HasMaxLength(50)
                .HasColumnName("TenLopHP");

            entity.HasOne(d => d.MaGvNavigation).WithMany(p => p.LopHocPhans)
                .HasForeignKey(d => d.MaGv)
                .HasConstraintName("fk_lophocphan_thongtingv");

            entity.HasOne(d => d.MaHocPhanNavigation).WithMany(p => p.LopHocPhans)
                .HasForeignKey(d => d.MaHocPhan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_lophocphan_hocphan");

            entity.HasOne(d => d.MaLopNavigation).WithMany(p => p.LopHocPhans)
                .HasForeignKey(d => d.MaLop)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_lophocphan_lop");
        });

        modelBuilder.Entity<Nganh>(entity =>
        {
            entity.HasKey(e => e.MaNganh).HasName("pk_nganh");

            entity.ToTable("Nganh");

            entity.Property(e => e.MaNganh).HasMaxLength(20);
            entity.Property(e => e.MaKhoa).HasMaxLength(20);
            entity.Property(e => e.TenNganh).HasMaxLength(50);
        });

        modelBuilder.Entity<PhongHoc>(entity =>
        {
            entity.HasKey(e => e.MaPhong).HasName("pk_phonghoc");

            entity.ToTable("PhongHoc");

            entity.Property(e => e.MaPhong).HasMaxLength(20);
            entity.Property(e => e.DiaDiem).HasMaxLength(20);
            entity.Property(e => e.TenPhong).HasMaxLength(20);
        });

        modelBuilder.Entity<ThongTinGv>(entity =>
        {
            entity.HasKey(e => e.MaGv).HasName("pk_thongtingv");

            entity.ToTable("ThongTinGV", tb => tb.HasTrigger("trg_ThongTinGV"));

            entity.Property(e => e.MaGv)
                .HasMaxLength(20)
                .HasColumnName("MaGV");
            entity.Property(e => e.Anh).HasMaxLength(30);
            entity.Property(e => e.ChucVu).HasMaxLength(30);
            entity.Property(e => e.DienThoai).HasMaxLength(20);
            entity.Property(e => e.HoGv)
                .HasMaxLength(20)
                .HasColumnName("HoGV");
            entity.Property(e => e.MaToMon).HasMaxLength(20);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.TenDayDu).HasMaxLength(50);
            entity.Property(e => e.TenGv)
                .HasMaxLength(20)
                .HasColumnName("TenGV");

            entity.HasOne(d => d.MaToMonNavigation).WithMany(p => p.ThongTinGvs)
                .HasForeignKey(d => d.MaToMon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_thongtingv_tomon");
        });

        modelBuilder.Entity<ToMon>(entity =>
        {
            entity.HasKey(e => e.MaToMon).HasName("pk_tomon");

            entity.ToTable("ToMon");

            entity.Property(e => e.MaToMon).HasMaxLength(20);
            entity.Property(e => e.MaKhoa).HasMaxLength(20);
            entity.Property(e => e.SoGv).HasColumnName("SoGV");
            entity.Property(e => e.TenToMon).HasMaxLength(50);

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.ToMons)
                .HasForeignKey(d => d.MaKhoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tomon_khoa");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

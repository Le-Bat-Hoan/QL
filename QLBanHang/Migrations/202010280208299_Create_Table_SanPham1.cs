namespace QLBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_SanPham1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HoaDon", "LoaiSP_MaLoaiSP", "dbo.LoaiSP");
            DropForeignKey("dbo.HoaDon", "MaNV", "dbo.Nhanvien");
            DropIndex("dbo.HoaDon", new[] { "LoaiSP_MaLoaiSP" });
            AddForeignKey("dbo.HoaDon", "MaNV", "dbo.Nhanvien", "MaNV", cascadeDelete: true);
            DropColumn("dbo.HoaDon", "LoaiSP_MaLoaiSP");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HoaDon", "LoaiSP_MaLoaiSP", c => c.Int());
            DropForeignKey("dbo.HoaDon", "MaNV", "dbo.Nhanvien");
            CreateIndex("dbo.HoaDon", "LoaiSP_MaLoaiSP");
            AddForeignKey("dbo.HoaDon", "MaNV", "dbo.Nhanvien", "MaNV");
            AddForeignKey("dbo.HoaDon", "LoaiSP_MaLoaiSP", "dbo.LoaiSP", "MaLoaiSP");
        }
    }
}

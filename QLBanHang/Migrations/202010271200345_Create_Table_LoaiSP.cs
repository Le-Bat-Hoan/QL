namespace QLBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_LoaiSP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.String(nullable: false, maxLength: 4),
                        TenKH = c.String(maxLength: 30),
                        DiaChi = c.String(maxLength: 30),
                        DienThoai = c.String(maxLength: 7),
                        Fax = c.String(maxLength: 12),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.LoaiSP",
                c => new
                    {
                        MaLoaiSP = c.Int(nullable: false),
                        TenLoaiSP = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.MaLoaiSP);
            
            AddColumn("dbo.HoaDon", "LoaiSP_MaLoaiSP", c => c.Int());
            CreateIndex("dbo.CTHD", "MaHD");
            CreateIndex("dbo.HoaDon", "MaKH");
            CreateIndex("dbo.HoaDon", "LoaiSP_MaLoaiSP");
            AddForeignKey("dbo.CTHD", "MaHD", "dbo.HoaDon", "MaHD", cascadeDelete: true);
            AddForeignKey("dbo.HoaDon", "MaKH", "dbo.KhachHang", "MaKH", cascadeDelete: true);
            AddForeignKey("dbo.HoaDon", "LoaiSP_MaLoaiSP", "dbo.LoaiSP", "MaLoaiSP");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDon", "LoaiSP_MaLoaiSP", "dbo.LoaiSP");
            DropForeignKey("dbo.HoaDon", "MaKH", "dbo.KhachHang");
            DropForeignKey("dbo.CTHD", "MaHD", "dbo.HoaDon");
            DropIndex("dbo.HoaDon", new[] { "LoaiSP_MaLoaiSP" });
            DropIndex("dbo.HoaDon", new[] { "MaKH" });
            DropIndex("dbo.CTHD", new[] { "MaHD" });
            DropColumn("dbo.HoaDon", "LoaiSP_MaLoaiSP");
            DropTable("dbo.LoaiSP");
            DropTable("dbo.KhachHang");
        }
    }
}

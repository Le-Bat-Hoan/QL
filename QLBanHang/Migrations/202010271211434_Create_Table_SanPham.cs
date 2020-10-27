namespace QLBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_SanPham : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSP = c.String(nullable: false, maxLength: 4),
                        TenSP = c.String(maxLength: 20),
                        Donvitinh = c.String(maxLength: 8),
                        Dongia = c.Double(),
                        MaLoaiSP = c.Int(),
                        HinhSP = c.String(),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.LoaiSP", t => t.MaLoaiSP, cascadeDelete: true)
                .Index(t => t.MaLoaiSP);
            
            CreateIndex("dbo.CTHD", "MaSP");
            AddForeignKey("dbo.CTHD", "MaSP", "dbo.SanPham", "MaSP", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPham", "MaLoaiSP", "dbo.LoaiSP");
            DropForeignKey("dbo.CTHD", "MaSP", "dbo.SanPham");
            DropIndex("dbo.SanPham", new[] { "MaLoaiSP" });
            DropIndex("dbo.CTHD", new[] { "MaSP" });
            DropTable("dbo.SanPham");
        }
    }
}

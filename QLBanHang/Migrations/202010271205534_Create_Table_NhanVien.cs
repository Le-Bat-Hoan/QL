namespace QLBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_NhanVien : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nhanvien",
                c => new
                    {
                        MaNV = c.Int(nullable: false, identity: true),
                        HoNV = c.String(maxLength: 50),
                        Ten = c.String(maxLength: 50),
                        Diachi = c.String(maxLength: 50),
                        Dienthoai = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaNV);
            
            CreateIndex("dbo.HoaDon", "MaNV");
            AddForeignKey("dbo.HoaDon", "MaNV", "dbo.Nhanvien", "MaNV");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDon", "MaNV", "dbo.Nhanvien");
            DropIndex("dbo.HoaDon", new[] { "MaNV" });
            DropTable("dbo.Nhanvien");
        }
    }
}

namespace QLBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_HoaDon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 5),
                        MaKH = c.String(maxLength: 4),
                        MaNV = c.Int(),
                        NgayLapHD = c.DateTime(nullable: false),
                        NgayGiaoHang = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaHD);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HoaDon");
        }
    }
}

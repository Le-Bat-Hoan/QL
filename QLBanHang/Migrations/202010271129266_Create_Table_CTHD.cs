namespace QLBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_CTHD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CTHD",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 5),
                        MaSP = c.String(nullable: false, maxLength: 4),
                        Soluong = c.Short(),
                        DongiaBan = c.Single(),
                        Giamgia = c.Single(),
                    })
                .PrimaryKey(t => new { t.MaHD, t.MaSP });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CTHD");
        }
    }
}

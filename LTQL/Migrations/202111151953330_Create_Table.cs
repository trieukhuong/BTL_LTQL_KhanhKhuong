namespace LTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiDoans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ma_cd = c.String(nullable: false),
                        Ten_cd = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoanViens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ma_dv = c.String(nullable: false),
                        Ten_dv = c.String(nullable: false),
                        Ngay_sinh = c.DateTime(nullable: false),
                        Que_quan = c.String(nullable: false),
                        Dan_toc = c.String(nullable: false),
                        Ngay_vao_doan = c.DateTime(nullable: false),
                        ChiDoan_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChiDoans", t => t.ChiDoan_Id, cascadeDelete: true)
                .Index(t => t.ChiDoan_Id);
            
            CreateTable(
                "dbo.XepLoais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Năm_hoc = c.Int(nullable: false),
                        Nhan_xet = c.String(nullable: false),
                        Xep_loai = c.String(nullable: false),
                        DoanVien_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoanViens", t => t.DoanVien_Id, cascadeDelete: true)
                .Index(t => t.DoanVien_Id);
            
            CreateTable(
                "dbo.HoatDongs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ma_hd = c.String(nullable: false),
                        Ten_hd = c.String(nullable: false),
                        Thoi_gian = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.XepLoais", "DoanVien_Id", "dbo.DoanViens");
            DropForeignKey("dbo.DoanViens", "ChiDoan_Id", "dbo.ChiDoans");
            DropIndex("dbo.XepLoais", new[] { "DoanVien_Id" });
            DropIndex("dbo.DoanViens", new[] { "ChiDoan_Id" });
            DropTable("dbo.HoatDongs");
            DropTable("dbo.XepLoais");
            DropTable("dbo.DoanViens");
            DropTable("dbo.ChiDoans");
        }
    }
}

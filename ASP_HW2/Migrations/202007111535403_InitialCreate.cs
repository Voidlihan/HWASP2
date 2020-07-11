namespace ASP_HW2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.Double(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(maxLength: 10),
                        Mark = c.Double(nullable: false),
                        Course_Id = c.Int(),
                        Subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Room = c.Int(nullable: false),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Students", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "Subject_Id" });
            DropIndex("dbo.Students", new[] { "Course_Id" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}

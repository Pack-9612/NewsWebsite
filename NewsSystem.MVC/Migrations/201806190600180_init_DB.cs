namespace NewsSystem.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "User.AnonymousUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "News.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 1000),
                        IsAnonymous = c.Boolean(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        AnonumousUserId = c.Int(),
                        AnonymousUserName = c.String(),
                        AnonymousUser_Id = c.Int(),
                        User_Id = c.Int(),
                        Article_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("User.AnonymousUsers", t => t.AnonymousUser_Id)
                .ForeignKey("User.Users", t => t.User_Id)
                .ForeignKey("News.Articles", t => t.Article_Id)
                .Index(t => t.AnonymousUser_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "News.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(nullable: false, maxLength: 120),
                        MainImgUrl = c.String(maxLength: 500),
                        ThumbnailImgUrl = c.String(maxLength: 500),
                        EntryDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        CalendarDate = c.DateTime(),
                        JSONContent = c.String(),
                        CategoryName = c.String(),
                        SumShares = c.Int(nullable: false),
                        Category_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("News.Categories", t => t.Category_Id)
                .ForeignKey("User.Users", t => t.User_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "News.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        CretorId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("User.Users", t => t.CretorId, cascadeDelete: true)
                .Index(t => t.CretorId);
            
            CreateTable(
                "User.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        phone = c.Int(nullable: false),
                        Gender = c.String(),
                        ProfilePicPath = c.String(),
                        UserEnable = c.Boolean(nullable: false),
                        LastLogOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Event.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(nullable: false, maxLength: 120),
                        BeginTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        Address = c.String(maxLength: 240),
                        Name = c.String(maxLength: 60),
                        CreatorId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("User.Users", t => t.CreatorId, cascadeDelete: true)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "Event.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        MainImgUrl = c.String(maxLength: 500),
                        ThumbnailImgUrl = c.String(maxLength: 500),
                        AuthorId = c.Int(nullable: false),
                        BrochureId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        CalendarDate = c.DateTime(),
                        JSONContent = c.String(),
                        CategoryName = c.String(),
                        SumShares = c.Int(nullable: false),
                        SumViews = c.Int(nullable: false),
                        MainUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Event.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("User.Users", t => t.AuthorId)
                .ForeignKey("User.Users", t => t.MainUser_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.AuthorId)
                .Index(t => t.MainUser_Id);
            
            CreateTable(
                "Media.Media",
                c => new
                    {
                        MediaId = c.Int(nullable: false, identity: true),
                        FilePath = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        SocialNetwork_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.MediaId)
                .ForeignKey("dbo.SocialNetworks", t => t.SocialNetwork_Id)
                .ForeignKey("User.Users", t => t.User_Id)
                .Index(t => t.SocialNetwork_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "Media.MediaLibrary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LibraryName = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialNetworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SnName = c.String(),
                        SnUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        CretorId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("User.Users", t => t.CretorId, cascadeDelete: true)
                .Index(t => t.CretorId);
            
            CreateTable(
                "news.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        CretorId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("User.Users", t => t.CretorId, cascadeDelete: true)
                .Index(t => t.CretorId);
            
            CreateTable(
                "User.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ParentId = c.Int(),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.MediaFileArticles",
                c => new
                    {
                        MediaFile_Id = c.Int(nullable: false),
                        Article_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MediaFile_Id, t.Article_Id })
                .ForeignKey("Media.Media", t => t.MediaFile_Id)
                .ForeignKey("News.Articles", t => t.Article_Id)
                .Index(t => t.MediaFile_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.MediaFileEvents",
                c => new
                    {
                        MediaFile_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MediaFile_Id, t.Event_Id })
                .ForeignKey("Media.Media", t => t.MediaFile_Id)
                .ForeignKey("Event.Events", t => t.Event_Id)
                .Index(t => t.MediaFile_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.MediaLibraryMediaFiles",
                c => new
                    {
                        MediaLibrary_Id = c.Int(nullable: false),
                        MediaFile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MediaLibrary_Id, t.MediaFile_Id })
                .ForeignKey("Media.MediaLibrary", t => t.MediaLibrary_Id)
                .ForeignKey("Media.Media", t => t.MediaFile_Id)
                .Index(t => t.MediaLibrary_Id)
                .Index(t => t.MediaFile_Id);
            
            CreateTable(
                "dbo.EventTagEvents",
                c => new
                    {
                        EventTag_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventTag_Id, t.Event_Id })
                .ForeignKey("dbo.EventTags", t => t.EventTag_Id)
                .ForeignKey("Event.Events", t => t.Event_Id)
                .Index(t => t.EventTag_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.NewsTagArticles",
                c => new
                    {
                        NewsTag_Id = c.Int(nullable: false),
                        Article_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NewsTag_Id, t.Article_Id })
                .ForeignKey("news.Tags", t => t.NewsTag_Id)
                .ForeignKey("News.Articles", t => t.Article_Id)
                .Index(t => t.NewsTag_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.RoleMainUsers",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        MainUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.MainUser_Id })
                .ForeignKey("User.Roles", t => t.Role_Id)
                .ForeignKey("User.Users", t => t.MainUser_Id)
                .Index(t => t.Role_Id)
                .Index(t => t.MainUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "ParentId", "dbo.Menus");
            DropForeignKey("News.Comments", "Article_Id", "News.Articles");
            DropForeignKey("dbo.RoleMainUsers", "MainUser_Id", "User.Users");
            DropForeignKey("dbo.RoleMainUsers", "Role_Id", "User.Roles");
            DropForeignKey("news.Tags", "CretorId", "User.Users");
            DropForeignKey("dbo.NewsTagArticles", "Article_Id", "News.Articles");
            DropForeignKey("dbo.NewsTagArticles", "NewsTag_Id", "news.Tags");
            DropForeignKey("News.Categories", "CretorId", "User.Users");
            DropForeignKey("Event.Events", "MainUser_Id", "User.Users");
            DropForeignKey("Event.Categories", "CreatorId", "User.Users");
            DropForeignKey("Event.Events", "AuthorId", "User.Users");
            DropForeignKey("dbo.EventTags", "CretorId", "User.Users");
            DropForeignKey("dbo.EventTagEvents", "Event_Id", "Event.Events");
            DropForeignKey("dbo.EventTagEvents", "EventTag_Id", "dbo.EventTags");
            DropForeignKey("Media.Media", "User_Id", "User.Users");
            DropForeignKey("Media.Media", "SocialNetwork_Id", "dbo.SocialNetworks");
            DropForeignKey("dbo.MediaLibraryMediaFiles", "MediaFile_Id", "Media.Media");
            DropForeignKey("dbo.MediaLibraryMediaFiles", "MediaLibrary_Id", "Media.MediaLibrary");
            DropForeignKey("dbo.MediaFileEvents", "Event_Id", "Event.Events");
            DropForeignKey("dbo.MediaFileEvents", "MediaFile_Id", "Media.Media");
            DropForeignKey("dbo.MediaFileArticles", "Article_Id", "News.Articles");
            DropForeignKey("dbo.MediaFileArticles", "MediaFile_Id", "Media.Media");
            DropForeignKey("Event.Events", "CategoryId", "Event.Categories");
            DropForeignKey("News.Comments", "User_Id", "User.Users");
            DropForeignKey("News.Articles", "User_Id", "User.Users");
            DropForeignKey("News.Articles", "Category_Id", "News.Categories");
            DropForeignKey("News.Comments", "AnonymousUser_Id", "User.AnonymousUsers");
            DropIndex("dbo.RoleMainUsers", new[] { "MainUser_Id" });
            DropIndex("dbo.RoleMainUsers", new[] { "Role_Id" });
            DropIndex("dbo.NewsTagArticles", new[] { "Article_Id" });
            DropIndex("dbo.NewsTagArticles", new[] { "NewsTag_Id" });
            DropIndex("dbo.EventTagEvents", new[] { "Event_Id" });
            DropIndex("dbo.EventTagEvents", new[] { "EventTag_Id" });
            DropIndex("dbo.MediaLibraryMediaFiles", new[] { "MediaFile_Id" });
            DropIndex("dbo.MediaLibraryMediaFiles", new[] { "MediaLibrary_Id" });
            DropIndex("dbo.MediaFileEvents", new[] { "Event_Id" });
            DropIndex("dbo.MediaFileEvents", new[] { "MediaFile_Id" });
            DropIndex("dbo.MediaFileArticles", new[] { "Article_Id" });
            DropIndex("dbo.MediaFileArticles", new[] { "MediaFile_Id" });
            DropIndex("dbo.Menus", new[] { "ParentId" });
            DropIndex("news.Tags", new[] { "CretorId" });
            DropIndex("dbo.EventTags", new[] { "CretorId" });
            DropIndex("Media.Media", new[] { "User_Id" });
            DropIndex("Media.Media", new[] { "SocialNetwork_Id" });
            DropIndex("Event.Events", new[] { "MainUser_Id" });
            DropIndex("Event.Events", new[] { "AuthorId" });
            DropIndex("Event.Events", new[] { "CategoryId" });
            DropIndex("Event.Categories", new[] { "CreatorId" });
            DropIndex("News.Categories", new[] { "CretorId" });
            DropIndex("News.Articles", new[] { "User_Id" });
            DropIndex("News.Articles", new[] { "Category_Id" });
            DropIndex("News.Comments", new[] { "Article_Id" });
            DropIndex("News.Comments", new[] { "User_Id" });
            DropIndex("News.Comments", new[] { "AnonymousUser_Id" });
            DropTable("dbo.RoleMainUsers");
            DropTable("dbo.NewsTagArticles");
            DropTable("dbo.EventTagEvents");
            DropTable("dbo.MediaLibraryMediaFiles");
            DropTable("dbo.MediaFileEvents");
            DropTable("dbo.MediaFileArticles");
            DropTable("dbo.Menus");
            DropTable("User.Roles");
            DropTable("news.Tags");
            DropTable("dbo.EventTags");
            DropTable("dbo.SocialNetworks");
            DropTable("Media.MediaLibrary");
            DropTable("Media.Media");
            DropTable("Event.Events");
            DropTable("Event.Categories");
            DropTable("User.Users");
            DropTable("News.Categories");
            DropTable("News.Articles");
            DropTable("News.Comments");
            DropTable("User.AnonymousUsers");
        }
    }
}

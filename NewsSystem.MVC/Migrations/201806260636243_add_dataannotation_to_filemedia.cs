namespace NewsSystem.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_dataannotation_to_filemedia : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "News.NewsTags", newName: "Tags");
            MoveTable(name: "Event.EventTags", newSchema: "dbo");
            AlterColumn("User.Users", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("User.Users", "LastName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("User.Users", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("User.Users", "FirstName", c => c.String(nullable: false, maxLength: 50));
            MoveTable(name: "dbo.EventTags", newSchema: "Event");
            RenameTable(name: "News.Tags", newName: "NewsTags");
        }
    }
}

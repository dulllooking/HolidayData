namespace HolidayData_ClassDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editLimite : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HolidayInfoes", "Date", c => c.DateTime());
            AlterColumn("dbo.HolidayInfoes", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.HolidayInfoes", "IsHoliday", c => c.Boolean());
            AlterColumn("dbo.HolidayInfoes", "HolidayCatalog", c => c.String(maxLength: 50));
            AlterColumn("dbo.HolidayInfoes", "Description", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HolidayInfoes", "Description", c => c.String());
            AlterColumn("dbo.HolidayInfoes", "HolidayCatalog", c => c.String());
            AlterColumn("dbo.HolidayInfoes", "IsHoliday", c => c.Boolean(nullable: false));
            AlterColumn("dbo.HolidayInfoes", "Name", c => c.String());
            AlterColumn("dbo.HolidayInfoes", "Date", c => c.DateTime(nullable: false));
        }
    }
}

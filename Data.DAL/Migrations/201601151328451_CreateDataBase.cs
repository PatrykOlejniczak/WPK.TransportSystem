namespace Data.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerOption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Option = c.String(nullable: false),
                        NumberOfVotes = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        QuestionnaireId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questionnaire", t => t.QuestionnaireId)
                .Index(t => t.QuestionnaireId);
            
            CreateTable(
                "dbo.Questionnaire",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        SecondName = c.String(),
                        LastName = c.String(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        Country = c.String(),
                        PostalCode = c.String(),
                        AreaCode = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        File = c.Binary(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        NewsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.NewsId)
                .Index(t => t.NewsId);
            
            CreateTable(
                "dbo.UserAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        HashPassword = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.BoostAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Code = c.String(nullable: false),
                        GeneratedDateTime = c.DateTime(nullable: false),
                        DateOfBoost = c.DateTime(),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        HashPassword = c.String(nullable: false),
                        AccountBallance = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseTicket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfPurchase = c.DateTime(nullable: false),
                        DeviceId = c.String(),
                        FirstNameTicketOwner = c.String(),
                        LastNameTicketOwner = c.String(),
                        DocumentIdentificationNumber = c.String(),
                        TicketId = c.Int(nullable: false),
                        DiscountId = c.Int(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discount", t => t.DiscountId)
                .ForeignKey("dbo.Ticket", t => t.TicketId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.TicketId)
                .Index(t => t.DiscountId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Discount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Percent = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Duration_Days = c.Int(nullable: false),
                        Duration_Hours = c.Int(nullable: false),
                        Duration_Minutes = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        TicketTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TicketType", t => t.TicketTypeId)
                .Index(t => t.TicketTypeId);
            
            CreateTable(
                "dbo.TicketType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BusStopOnLine",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Direction = c.Boolean(nullable: false),
                        NumberStopOnLine = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        LineId = c.Int(nullable: false),
                        BusStopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusStop", t => t.BusStopId)
                .ForeignKey("dbo.Line", t => t.LineId)
                .Index(t => t.LineId)
                .Index(t => t.BusStopId);
            
            CreateTable(
                "dbo.BusStop",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        BusStopTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusStopType", t => t.BusStopTypeId)
                .Index(t => t.BusStopTypeId);
            
            CreateTable(
                "dbo.BusStopType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DistanceBetweenStops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TravelTime = c.Time(nullable: false, precision: 7),
                        DistanceInKilometers = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        FirstBusStopId = c.Int(nullable: false),
                        SecondBusStopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusStop", t => t.FirstBusStopId)
                .ForeignKey("dbo.BusStop", t => t.SecondBusStopId)
                .Index(t => t.FirstBusStopId)
                .Index(t => t.SecondBusStopId);
            
            CreateTable(
                "dbo.Line",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Timetable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartureTime = c.Time(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        BusStopOnLineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusStopOnLine", t => t.BusStopOnLineId)
                .Index(t => t.BusStopOnLineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Timetable", "BusStopOnLineId", "dbo.BusStopOnLine");
            DropForeignKey("dbo.BusStopOnLine", "LineId", "dbo.Line");
            DropForeignKey("dbo.BusStopOnLine", "BusStopId", "dbo.BusStop");
            DropForeignKey("dbo.DistanceBetweenStops", "SecondBusStopId", "dbo.BusStop");
            DropForeignKey("dbo.DistanceBetweenStops", "FirstBusStopId", "dbo.BusStop");
            DropForeignKey("dbo.BusStop", "BusStopTypeId", "dbo.BusStopType");
            DropForeignKey("dbo.BoostAccount", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.PurchaseTicket", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.PurchaseTicket", "TicketId", "dbo.Ticket");
            DropForeignKey("dbo.Ticket", "TicketTypeId", "dbo.TicketType");
            DropForeignKey("dbo.PurchaseTicket", "DiscountId", "dbo.Discount");
            DropForeignKey("dbo.AnswerOption", "QuestionnaireId", "dbo.Questionnaire");
            DropForeignKey("dbo.UserAccount", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Questionnaire", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.News", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Photo", "NewsId", "dbo.News");
            DropIndex("dbo.Timetable", new[] { "BusStopOnLineId" });
            DropIndex("dbo.DistanceBetweenStops", new[] { "SecondBusStopId" });
            DropIndex("dbo.DistanceBetweenStops", new[] { "FirstBusStopId" });
            DropIndex("dbo.BusStop", new[] { "BusStopTypeId" });
            DropIndex("dbo.BusStopOnLine", new[] { "BusStopId" });
            DropIndex("dbo.BusStopOnLine", new[] { "LineId" });
            DropIndex("dbo.Ticket", new[] { "TicketTypeId" });
            DropIndex("dbo.PurchaseTicket", new[] { "CustomerId" });
            DropIndex("dbo.PurchaseTicket", new[] { "DiscountId" });
            DropIndex("dbo.PurchaseTicket", new[] { "TicketId" });
            DropIndex("dbo.BoostAccount", new[] { "CustomerId" });
            DropIndex("dbo.UserAccount", new[] { "EmployeeId" });
            DropIndex("dbo.Photo", new[] { "NewsId" });
            DropIndex("dbo.News", new[] { "EmployeeId" });
            DropIndex("dbo.Questionnaire", new[] { "EmployeeId" });
            DropIndex("dbo.AnswerOption", new[] { "QuestionnaireId" });
            DropTable("dbo.Timetable");
            DropTable("dbo.Line");
            DropTable("dbo.DistanceBetweenStops");
            DropTable("dbo.BusStopType");
            DropTable("dbo.BusStop");
            DropTable("dbo.BusStopOnLine");
            DropTable("dbo.TicketType");
            DropTable("dbo.Ticket");
            DropTable("dbo.Discount");
            DropTable("dbo.PurchaseTicket");
            DropTable("dbo.Customer");
            DropTable("dbo.BoostAccount");
            DropTable("dbo.UserAccount");
            DropTable("dbo.Photo");
            DropTable("dbo.News");
            DropTable("dbo.Employee");
            DropTable("dbo.Questionnaire");
            DropTable("dbo.AnswerOption");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT [dbo].[Employees] ON 

                INSERT [dbo].[Employees] ([Id], [Name], [Patronymic], [Surname]) VALUES (6, N'Carl', N'Brown', N'Sidney')
                INSERT [dbo].[Employees] ([Id], [Name], [Patronymic], [Surname]) VALUES (7, N'Jeremy', N'Ipsum', N'Lorem')
                INSERT [dbo].[Employees] ([Id], [Name], [Patronymic], [Surname]) VALUES (8, N'Mike', N'Fon', N'Von')
                INSERT [dbo].[Employees] ([Id], [Name], [Patronymic], [Surname]) VALUES (9, N'John', N'Middle', N'Smith')
                INSERT [dbo].[Employees] ([Id], [Name], [Patronymic], [Surname]) VALUES (10, N'Umbra', N'', N'Gin')
                INSERT [dbo].[Employees] ([Id], [Name], [Patronymic], [Surname]) VALUES (11, N'George', N'', N'Vash')
                INSERT [dbo].[Employees] ([Id], [Name], [Patronymic], [Surname]) VALUES (12, N'Robin', N'', N'Marlo')
                INSERT [dbo].[Employees] ([Id], [Name], [Patronymic], [Surname]) VALUES (13, N'Patrick', N'', N'Kop')
                INSERT [dbo].[Employees] ([Id], [Name], [Patronymic], [Surname]) VALUES (14, N'Hannah', N'', N'Umbra')
                INSERT [dbo].[Employees] ([Id], [Name], [Patronymic], [Surname]) VALUES (15, N'Marle', N'', N'Mart')
                INSERT [dbo].[Employees] ([Id], [Name], [Patronymic], [Surname]) VALUES (16, N'Leo', N'', N'Part')
                INSERT [dbo].[Employees] ([Id], [Name], [Patronymic], [Surname]) VALUES (18, N'Loliop', N'', N'Jinj')
                SET IDENTITY_INSERT [dbo].[Employees] OFF
                SET IDENTITY_INSERT [dbo].[Items] ON 

                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (572, N'PC404', 100, 6)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (573, N'PC401', 23, 6)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (574, N'PC201', 200, 7)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (575, N'PC200', 944, 7)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (576, N'PC401', 150, 7)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (577, N'PC500', 500, 8)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (578, N'Keys', 15, 10)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (579, N'Server', 2500, 10)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (585, N'Pen', 1, 12)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (586, N'Server', 2500, 13)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (587, N'PC404', 400, 13)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (588, N'PC400', 600, 14)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (589, N'Car', 5000, 15)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (590, N'Keys', 20, 16)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (591, N'Mice', 5.33, 11)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (592, N'Keyboard', 10, 11)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (593, N'PC404', 400, 11)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (594, N'Flash Drive', 30, 11)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (595, N'PC300', 440, 11)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (597, N'Keys', 20, 18)
                INSERT [dbo].[Items] ([Id], [Name], [Cost], [EmployeeId]) VALUES (598, N'PC203', 200, 18)
                SET IDENTITY_INSERT [dbo].[Items] OFF
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

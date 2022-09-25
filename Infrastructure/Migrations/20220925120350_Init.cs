using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distributor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdInformation_DocumentType = table.Column<int>(type: "int", nullable: false),
                    IdInformation_DocumentSeria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdInformation_DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdInformation_ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdInformation_ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdInformation_IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdInformation_Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactInformation_ContactType = table.Column<int>(type: "int", nullable: false),
                    ContactInformation_CotactInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AddressType = table.Column<int>(type: "int", nullable: false),
                    Address_FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HierarchyLevel = table.Column<int>(type: "int", nullable: false),
                    Recommendedby = table.Column<int>(type: "int", nullable: true),
                    Recomendations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastChangeDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeleteAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondaryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastChangeDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeleteAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistributorId = table.Column<int>(type: "int", nullable: false),
                    DistributorSecondaryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    SecondaryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastChangeDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeleteAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Distributor_FirstName",
                table: "Distributor",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Distributor_LastName",
                table: "Distributor",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_SaleDate",
                table: "Transaction",
                column: "SaleDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Distributor");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}

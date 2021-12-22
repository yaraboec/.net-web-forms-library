using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationalPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalPrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MethodPublications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodPublications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookNames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BookTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookNames_BookTypes_BookTypeId",
                        column: x => x.BookTypeId,
                        principalTable: "BookTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicationPlanTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationPlanTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicationPlanTables_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicationPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Course = table.Column<int>(nullable: false),
                    BookNameId = table.Column<Guid>(nullable: false),
                    SpecialityId = table.Column<Guid>(nullable: false),
                    DisciplineId = table.Column<Guid>(nullable: true),
                    Pages = table.Column<int>(nullable: true),
                    Overhead = table.Column<int>(nullable: true),
                    LanguageId = table.Column<Guid>(nullable: false),
                    MethodPublicationId = table.Column<Guid>(nullable: false),
                    WillPublish = table.Column<bool>(nullable: false),
                    PublicationPlanTableId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicationPlans_BookNames_BookNameId",
                        column: x => x.BookNameId,
                        principalTable: "BookNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationPlans_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PublicationPlans_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationPlans_MethodPublications_MethodPublicationId",
                        column: x => x.MethodPublicationId,
                        principalTable: "MethodPublications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationPlans_PublicationPlanTables_PublicationPlanTableId",
                        column: x => x.PublicationPlanTableId,
                        principalTable: "PublicationPlanTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationPlans_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorPlan",
                columns: table => new
                {
                    BookAuthorId = table.Column<Guid>(nullable: false),
                    PublicationPlanId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPlan", x => new { x.BookAuthorId, x.PublicationPlanId });
                    table.ForeignKey(
                        name: "FK_AuthorPlan_BookAuthors_BookAuthorId",
                        column: x => x.BookAuthorId,
                        principalTable: "BookAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorPlan_PublicationPlans_PublicationPlanId",
                        column: x => x.PublicationPlanId,
                        principalTable: "PublicationPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramPlan",
                columns: table => new
                {
                    EducationalProgramId = table.Column<Guid>(nullable: false),
                    PublicationPlanId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramPlan", x => new { x.EducationalProgramId, x.PublicationPlanId });
                    table.ForeignKey(
                        name: "FK_ProgramPlan_EducationalPrograms_EducationalProgramId",
                        column: x => x.EducationalProgramId,
                        principalTable: "EducationalPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramPlan_PublicationPlans_PublicationPlanId",
                        column: x => x.PublicationPlanId,
                        principalTable: "PublicationPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPlan_PublicationPlanId",
                table: "AuthorPlan",
                column: "PublicationPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_BookNames_BookTypeId",
                table: "BookNames",
                column: "BookTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramPlan_PublicationPlanId",
                table: "ProgramPlan",
                column: "PublicationPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationPlans_BookNameId",
                table: "PublicationPlans",
                column: "BookNameId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationPlans_DisciplineId",
                table: "PublicationPlans",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationPlans_LanguageId",
                table: "PublicationPlans",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationPlans_MethodPublicationId",
                table: "PublicationPlans",
                column: "MethodPublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationPlans_PublicationPlanTableId",
                table: "PublicationPlans",
                column: "PublicationPlanTableId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationPlans_SpecialityId",
                table: "PublicationPlans",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationPlanTables_UserId",
                table: "PublicationPlanTables",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorPlan");

            migrationBuilder.DropTable(
                name: "ProgramPlan");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "EducationalPrograms");

            migrationBuilder.DropTable(
                name: "PublicationPlans");

            migrationBuilder.DropTable(
                name: "BookNames");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "MethodPublications");

            migrationBuilder.DropTable(
                name: "PublicationPlanTables");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropTable(
                name: "BookTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

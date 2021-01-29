using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin5.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Axes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Axes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(nullable: true),
                    Pv = table.Column<string>(nullable: true),
                    DateEvenement = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cycles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Indicateurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Natures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Natures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdConcerner = table.Column<int>(nullable: false),
                    IdOrganisme = table.Column<int>(nullable: false),
                    TableConcerner = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    Destinataire = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Vu = table.Column<bool>(nullable: false),
                    Priorite = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organismes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organismes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profils",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SousAxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(nullable: true),
                    IdAxe = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SousAxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SousAxes_Axes_IdAxe",
                        column: x => x.IdAxe,
                        principalTable: "Axes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembreCommissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomComplete = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IdCommission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembreCommissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembreCommissions_Commissions_IdCommission",
                        column: x => x.IdCommission,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdProfil = table.Column<int>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    RouteScreen = table.Column<string>(nullable: true),
                    RouteScreenAr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Profils_IdProfil",
                        column: x => x.IdProfil,
                        principalTable: "Profils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Adresse = table.Column<string>(nullable: false),
                    Tel = table.Column<string>(nullable: false),
                    Fix = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Actif = table.Column<bool>(nullable: true),
                    IdOrganisme = table.Column<int>(nullable: false),
                    IdProfil = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Organismes_IdOrganisme",
                        column: x => x.IdOrganisme,
                        principalTable: "Organismes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Profils_IdProfil",
                        column: x => x.IdProfil,
                        principalTable: "Profils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mesures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    IdType = table.Column<int>(nullable: false),
                    IdResponsable = table.Column<int>(nullable: false),
                    IdAxe = table.Column<int>(nullable: false),
                    IdSousAxe = table.Column<int>(nullable: false),
                    IdCycle = table.Column<int>(nullable: false),
                    IdNature = table.Column<int>(nullable: false),
                    ResultatsAttendu = table.Column<string>(nullable: true),
                    ObjectifGlobal = table.Column<string>(nullable: true),
                    ObjectifSpeciaux = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesures_Axes_IdAxe",
                        column: x => x.IdAxe,
                        principalTable: "Axes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mesures_Cycles_IdCycle",
                        column: x => x.IdCycle,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mesures_Natures_IdNature",
                        column: x => x.IdNature,
                        principalTable: "Natures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mesures_Users_IdResponsable",
                        column: x => x.IdResponsable,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mesures_SousAxes_IdSousAxe",
                        column: x => x.IdSousAxe,
                        principalTable: "SousAxes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Activites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Duree = table.Column<string>(nullable: true),
                    IdMesure = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activites_Mesures_IdMesure",
                        column: x => x.IdMesure,
                        principalTable: "Mesures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicateurMesures",
                columns: table => new
                {
                    IdMesure = table.Column<int>(nullable: false),
                    IdIndicateur = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicateurMesures", x => new { x.IdMesure, x.IdIndicateur });
                    table.ForeignKey(
                        name: "FK_IndicateurMesures_Indicateurs_IdIndicateur",
                        column: x => x.IdIndicateur,
                        principalTable: "Indicateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicateurMesures_Mesures_IdMesure",
                        column: x => x.IdMesure,
                        principalTable: "Mesures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicateurMesureValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdMesure = table.Column<int>(nullable: false),
                    IdIndicateur = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicateurMesureValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicateurMesureValues_Indicateurs_IdIndicateur",
                        column: x => x.IdIndicateur,
                        principalTable: "Indicateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicateurMesureValues_Mesures_IdMesure",
                        column: x => x.IdMesure,
                        principalTable: "Mesures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partenariats",
                columns: table => new
                {
                    IdMesure = table.Column<int>(nullable: false),
                    IdOrganisme = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partenariats", x => new { x.IdMesure, x.IdOrganisme });
                    table.ForeignKey(
                        name: "FK_Partenariats_Mesures_IdMesure",
                        column: x => x.IdMesure,
                        principalTable: "Mesures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partenariats_Organismes_IdOrganisme",
                        column: x => x.IdOrganisme,
                        principalTable: "Organismes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Realisations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Situation = table.Column<string>(nullable: true),
                    Annee = table.Column<int>(nullable: false),
                    Taux = table.Column<string>(nullable: true),
                    TauxRealisation = table.Column<double>(nullable: false),
                    Effet = table.Column<string>(nullable: true),
                    IdActivite = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realisations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Realisations_Activites_IdActivite",
                        column: x => x.IdActivite,
                        principalTable: "Activites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Axes",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "الحكامة والديمقراطية" });

            migrationBuilder.InsertData(
                table: "Axes",
                columns: new[] { "Id", "Label" },
                values: new object[] { 2, "الحقوق الاقتصادية والاجتماعية والثقافية والبيئية" });

            migrationBuilder.InsertData(
                table: "Axes",
                columns: new[] { "Id", "Label" },
                values: new object[] { 3, "حماية الحقوق الفئوية والنهوض بها" });

            migrationBuilder.InsertData(
                table: "Axes",
                columns: new[] { "Id", "Label" },
                values: new object[] { 4, "الإطار القانوني والمؤسساتي" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 20, new DateTime(2020, 3, 27, 3, 35, 0, 344, DateTimeKind.Local).AddTicks(1021), "محضر رقم 20", "اللجنة رقم 20" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 19, new DateTime(2020, 10, 27, 19, 43, 26, 841, DateTimeKind.Local).AddTicks(1070), "محضر رقم 19", "اللجنة رقم 19" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 18, new DateTime(2020, 8, 18, 20, 49, 8, 356, DateTimeKind.Local).AddTicks(1611), "محضر رقم 18", "اللجنة رقم 18" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 17, new DateTime(2020, 10, 27, 4, 57, 22, 665, DateTimeKind.Local).AddTicks(9592), "محضر رقم 17", "اللجنة رقم 17" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 16, new DateTime(2020, 4, 13, 9, 23, 19, 291, DateTimeKind.Local).AddTicks(7486), "محضر رقم 16", "اللجنة رقم 16" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 15, new DateTime(2020, 8, 7, 4, 50, 13, 795, DateTimeKind.Local).AddTicks(7445), "محضر رقم 15", "اللجنة رقم 15" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 14, new DateTime(2020, 9, 25, 23, 41, 18, 982, DateTimeKind.Local).AddTicks(9726), "محضر رقم 14", "اللجنة رقم 14" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 13, new DateTime(2021, 1, 14, 12, 4, 21, 54, DateTimeKind.Local).AddTicks(1933), "محضر رقم 13", "اللجنة رقم 13" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 11, new DateTime(2020, 7, 13, 6, 22, 13, 900, DateTimeKind.Local).AddTicks(7887), "محضر رقم 11", "اللجنة رقم 11" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 12, new DateTime(2020, 3, 19, 5, 54, 34, 494, DateTimeKind.Local).AddTicks(5401), "محضر رقم 12", "اللجنة رقم 12" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 9, new DateTime(2020, 8, 31, 19, 40, 54, 971, DateTimeKind.Local).AddTicks(9246), "محضر رقم 9", "اللجنة رقم 9" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 1, new DateTime(2020, 11, 19, 18, 50, 22, 558, DateTimeKind.Local).AddTicks(5295), "محضر رقم 1", "اللجنة رقم 1" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 10, new DateTime(2020, 4, 10, 2, 56, 48, 800, DateTimeKind.Local).AddTicks(1434), "محضر رقم 10", "اللجنة رقم 10" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 3, new DateTime(2020, 11, 21, 9, 5, 46, 472, DateTimeKind.Local).AddTicks(3531), "محضر رقم 3", "اللجنة رقم 3" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 4, new DateTime(2020, 2, 20, 23, 53, 59, 789, DateTimeKind.Local).AddTicks(7897), "محضر رقم 4", "اللجنة رقم 4" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 2, new DateTime(2020, 5, 19, 0, 18, 21, 721, DateTimeKind.Local).AddTicks(1084), "محضر رقم 2", "اللجنة رقم 2" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 6, new DateTime(2020, 10, 3, 21, 59, 30, 824, DateTimeKind.Local).AddTicks(8313), "محضر رقم 6", "اللجنة رقم 6" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 7, new DateTime(2021, 1, 23, 4, 41, 19, 394, DateTimeKind.Local).AddTicks(7403), "محضر رقم 7", "اللجنة رقم 7" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 8, new DateTime(2020, 4, 7, 2, 46, 32, 397, DateTimeKind.Local).AddTicks(5723), "محضر رقم 8", "اللجنة رقم 8" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 5, new DateTime(2020, 10, 23, 16, 31, 28, 478, DateTimeKind.Local).AddTicks(3917), "محضر رقم 5", "اللجنة رقم 5" });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "2018 - 2021" });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Label" },
                values: new object[] { 2, "2022 - 2025" });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Label" },
                values: new object[] { 3, "2026 - 2030" });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Label" },
                values: new object[] { 4, "2030 - 2035" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 5, "تنصيب رئيس واعضاء الهيئة ", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 6, "عدد عمليات التشاور العمومي", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 4, "النشر في الجريدة الرسمية", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 3, "إرتفاع نسب التمثيلية", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 2, "التعبير عن الرضا بخصوص تدبير العملية الإنتخابية من قبل عموم المعنيين والملاحظين ", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 1, " إرتفاع نسبة التسجيل والتصويت", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Natures",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "الجانب التشريعي والمؤسساتي" });

            migrationBuilder.InsertData(
                table: "Natures",
                columns: new[] { "Id", "Label" },
                values: new object[] { 2, "التواصل والتحسيس" });

            migrationBuilder.InsertData(
                table: "Natures",
                columns: new[] { "Id", "Label" },
                values: new object[] { 3, "تقوية القدرات" });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 28, null, "المندوبية العامة لإدارة السجون وإعادة الإدماج", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 29, null, "وزارة الدولة المكلفة بحقوق الإنسان", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 30, null, "المجلس الوطني لحقوق الإنسان", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 31, null, "رئاسة النيابة العامة", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 32, null, "المجلس الأعلى للسلطة القضائية", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 33, null, "قطاع التعليم العالي", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 34, null, "وزارة الثقافة والاتصال قطاع الثقافة", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 35, null, "جهة طنجة تطوان الحسيمة", null, 2 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 36, null, "جهة الشرق", null, 2 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 37, null, "جهة فاس مكناس", null, 2 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 38, null, "جهة الرباط سلا القنيطرة", null, 2 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 41, null, "جهة مراكش آسفي", null, 2 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 40, null, "جهة الدار البيضاء سطات", null, 2 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 27, null, "الدرك الملكي", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 42, null, "جهة درعة تافيلالت", null, 2 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 43, null, "جهة سوس ماسة", null, 2 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 44, null, "جهة كلميم واد نون", null, 2 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 45, null, "جهة العيون الساقية الحمراء", null, 2 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 46, null, "جهة الداخلة وادي الذهب", null, 2 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 47, null, "مؤسسة-1", null, 3 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 48, null, "مؤسسة-2", null, 3 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 49, null, "مؤسسة-3", null, 3 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 50, null, "مؤسسة-4", null, 3 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 39, null, "جهة بني ملال خنيفرة", null, 2 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 26, null, "وزارة الصحة", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 9, null, "وزارة الأسرة والتضامن والمساواة والتنمية الاجتماعية", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 24, null, "وزارة إصلاح الإدارة والوظيفة العمومية وجميع الإدارات", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 1, null, "وزارة الدولة المكلفة بحقوق الإنسان", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 2, null, "وزارة العدل", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 3, null, "المجلس الأعلى للسلطة القضائية ", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 4, null, "المجلس الوطني لحقوق الإنسان", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 5, null, "الهيئات السياسية ", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 6, null, "جمعيات المجتمع المدني", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 7, null, "وزارة الداخلية", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 8, null, "الجمعيات الترابية", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 25, null, "الهيئة المركزية للوقاية من الرشوة", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 11, null, " الوزارة المنتدبة المكلفة بالعلاقات مع البرلمان والمجتمع المدني", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 12, null, "وزارة التربية الوطنية والتكوين المهني والتعليم العالي والبحث العلمي", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 10, null, "رئاسة الحكومة", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 14, null, "وزارة الشباب والرياضة", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 15, null, "وزارة الاقتصاد والمالية", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 16, null, "هيئة المناصفة ومكافحة جميع أشكال التمييز", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 17, null, "الوزارة المنتدبة لدى رئيس الحكومة المكلفة بإصلاح الإدارة وبالوظيفة العمومية", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 18, null, "وزارة إعداد التراب الوطني والتعمير والإسكان وسياسة المدينة", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 19, null, "وزارة الثقافة والاتصال", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 20, null, "البرلمان", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 21, null, "الهيئة الوطنية للنزاهة والوقاية  من الرشوة ومحاربتها", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 22, null, "الوزارة المنتدبة لدى رئيس الحكومة المكلفة بالشؤون العامة والحكامة", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 23, null, " وزارة الصناعة والاستثمار والتجارة والاقتصاد الرقمي", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 13, null, " وزارة التربية الوطنية والتكوين المهني  والتعليم العالي  والبحث العلمي قطاع التربية الوطنية", null, 1 });

            migrationBuilder.InsertData(
                table: "Profils",
                columns: new[] { "Id", "Label" },
                values: new object[] { 4, "لجنة التتبع" });

            migrationBuilder.InsertData(
                table: "Profils",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "مدير" });

            migrationBuilder.InsertData(
                table: "Profils",
                columns: new[] { "Id", "Label" },
                values: new object[] { 2, "مشرف" });

            migrationBuilder.InsertData(
                table: "Profils",
                columns: new[] { "Id", "Label" },
                values: new object[] { 3, "لجنة الوطنية" });

            migrationBuilder.InsertData(
                table: "Profils",
                columns: new[] { "Id", "Label" },
                values: new object[] { 5, "المخاطب الرئيسي" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 19, "Maeva86@yahoo.fr", 19, "Mathéo Roussel" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 17, "Maelys49@hotmail.fr", 17, "Laura Bourgeois" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 16, "Maxence20@yahoo.fr", 16, "Carla Lecomte" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 15, "Maxence_Riviere@yahoo.fr", 15, "Ambre Marchal" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 14, "Lina46@hotmail.fr", 14, "Nicolas Collet" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 13, "Julie21@hotmail.fr", 13, "Maxime Paris" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 12, "Julien.Rousseau7@hotmail.fr", 12, "Clémence Hubert" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 1, "Maxence28@yahoo.fr", 1, "Noémie Giraud" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 2, "Matteo.Cousin56@hotmail.fr", 2, "Maxime Dupuy" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 3, "Mohamed.Olivier84@hotmail.fr", 3, "Louise Girard" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 4, "Ethan87@hotmail.fr", 4, "Juliette Laine" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 5, "Clement.Charles@yahoo.fr", 5, "Ethan Nicolas" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 6, "Mathis_Collet48@gmail.com", 6, "Maeva Andre" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 7, "Laura.Moulin@yahoo.fr", 7, "Chloé David" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 8, "Lou.Adam@hotmail.fr", 8, "Mélissa Giraud" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 9, "Enzo.Richard@yahoo.fr", 9, "Elisa Charpentier" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 18, "Noemie24@hotmail.fr", 18, "Alice Laurent" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 10, "Emilie69@hotmail.fr", 10, "Romain Leclercq" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 11, "Raphael38@gmail.com", 11, "Valentin Philippe" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 20, "Leo18@hotmail.fr", 20, "Nathan Durand" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 10, "Modification", 2, "mesure-executif", "mesure-executif" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 7, "Consultation", 5, "suivi-indicateur", "rapport-qualitative" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 6, "Consultation", 5, "rapport-qualitative", "rapport-qualitative" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 5, "Consultation", 5, "rapport-litteraire", "rapport-litteraire" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 4, "Modification", 5, "suivi", "suivi" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 3, "Consultation", 5, "mesure-programme", "mesure-programme" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 2, "Consultation", 5, "mesure-region", "mesure-region" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 1, "Consultation", 5, "mesure-executif", "mesure-executif" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 9, "Modification", 4, "commission", "commission" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 16, "Modification", 2, "commission", "commission" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 15, "Modification", 2, "rapport-qualitative", "rapport-qualitative" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 14, "Modification", 2, "rapport-litteraire", "rapport-litteraire" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 13, "Modification", 2, "suivi", "suivi" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 12, "Modification", 2, "mesure-programme", "mesure-programme" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 11, "Modification", 2, "mesure-region", "mesure-region" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 17, "Modification", 2, "suivi-indicateur", "suivi-indicateur" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 8, "Modification", 3, "commission", "commission" });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 1, 1, "المشاركة السياسية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 25, 4, " حفظ الأرشيف وصيانته " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 26, 4, "الحقوق والحريات والآليات المؤسساتية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 2, 1, "المساواة والمناصفة وتكافؤ الفرص " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 3, 1, " الحكامة الترابية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 4, 1, "الحكامة الإدارية والنزاهة والشفافية ومكافحة الفساد " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 5, 1, "الحكامة الأمنية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 7, 1, " مكافحة الإفلات من العقاب" });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 8, 2, " جودة المنظومة الوطنية للتربية والتكوين والبحث العلمي " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 9, 2, "الحقوق الثقافية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 10, 2, " الولوج إلى الخدمات الصحية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 11, 2, " الشغل وتكريس المساواة " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 12, 2, " السياسة السكنية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 13, 2, "السياسة البيئية المندمجة " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 6, 1, " حريات الاجتماع والتجمع والتظاهر السلمي وتأسيس الجمعيات " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 15, 3, " الأبعاد المؤسساتية والتشريعية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 16, 3, " حقوق الطفل " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 17, 3, "حقوق الشباب " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 14, 2, " المقاولة وحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 23, 4, "حريات التعبير والإعلام والصحافة والحق في المعلومة " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 18, 3, " حقوق الأشخاص في وضعية إعاقة " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 19, 3, " حقوق الأشخاص المسنين " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 24, 4, "حماية التراث الثقافي " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 20, 3, "حقوق المهاجرين واللاجئين " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 21, 4, " الحماية القانونية والقضائية لحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 22, 4, " الحماية القانونية والمؤسساتية لحقوق المرأة " });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 35, true, "taza", "user-regions-35@panddh.com", "05 ## ## ## ##", 35, 5, "user-regions-35", "123", "mohamed", "06 ## ## ## ##", "user-regions-35" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 34, true, "taza", "user-34@panddh.com", "05 ## ## ## ##", 34, 5, "user-34", "123", "mohamed", "06 ## ## ## ##", "user-34" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 33, true, "taza", "user-33@panddh.com", "05 ## ## ## ##", 33, 5, "user-33", "123", "mohamed", "06 ## ## ## ##", "user-33" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 32, true, "taza", "user-32@panddh.com", "05 ## ## ## ##", 32, 5, "user-32", "123", "mohamed", "06 ## ## ## ##", "user-32" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 30, true, "taza", "user-30@panddh.com", "05 ## ## ## ##", 30, 5, "user-30", "123", "mohamed", "06 ## ## ## ##", "user-30" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 29, true, "taza", "user-29@panddh.com", "05 ## ## ## ##", 29, 5, "user-29", "123", "mohamed", "06 ## ## ## ##", "user-29" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 28, true, "taza", "user-28@panddh.com", "05 ## ## ## ##", 28, 5, "user-28", "123", "mohamed", "06 ## ## ## ##", "user-28" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 27, true, "taza", "user-27@panddh.com", "05 ## ## ## ##", 27, 5, "user-27", "123", "mohamed", "06 ## ## ## ##", "user-27" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 31, true, "taza", "user-31@panddh.com", "05 ## ## ## ##", 31, 5, "user-31", "123", "mohamed", "06 ## ## ## ##", "user-31" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 36, true, "taza", "user-regions-36@panddh.com", "05 ## ## ## ##", 36, 5, "user-regions-36", "123", "mohamed", "06 ## ## ## ##", "user-regions-36" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 41, true, "taza", "user-regions-41@panddh.com", "05 ## ## ## ##", 41, 5, "user-regions-41", "123", "mohamed", "06 ## ## ## ##", "user-regions-41" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 38, true, "taza", "user-regions-38@panddh.com", "05 ## ## ## ##", 38, 5, "user-regions-38", "123", "mohamed", "06 ## ## ## ##", "user-regions-38" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 39, true, "taza", "user-regions-39@panddh.com", "05 ## ## ## ##", 39, 5, "user-regions-39", "123", "mohamed", "06 ## ## ## ##", "user-regions-39" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 40, true, "taza", "user-regions-40@panddh.com", "05 ## ## ## ##", 40, 5, "user-regions-40", "123", "mohamed", "06 ## ## ## ##", "user-regions-40" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 42, true, "taza", "user-regions-42@panddh.com", "05 ## ## ## ##", 42, 5, "user-regions-42", "123", "mohamed", "06 ## ## ## ##", "user-regions-42" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 43, true, "taza", "user-regions-43@panddh.com", "05 ## ## ## ##", 43, 5, "user-regions-43", "123", "mohamed", "06 ## ## ## ##", "user-regions-43" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 26, true, "taza", "user-26@panddh.com", "05 ## ## ## ##", 26, 5, "user-26", "123", "mohamed", "06 ## ## ## ##", "user-26" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 44, true, "taza", "user-regions-44@panddh.com", "05 ## ## ## ##", 44, 5, "user-regions-44", "123", "mohamed", "06 ## ## ## ##", "user-regions-44" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 48, true, "taza", "user-societe-48@panddh.com", "05 ## ## ## ##", 48, 5, "user-societe-48", "123", "mohamed", "06 ## ## ## ##", "user-societe-48" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 45, true, "taza", "user-regions-45@panddh.com", "05 ## ## ## ##", 45, 5, "user-regions-45", "123", "mohamed", "06 ## ## ## ##", "user-regions-45" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 46, true, "taza", "user-regions-46@panddh.com", "05 ## ## ## ##", 46, 5, "user-regions-46", "123", "mohamed", "06 ## ## ## ##", "user-regions-46" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 47, true, "taza", "user-societe-47@panddh.com", "05 ## ## ## ##", 47, 5, "user-societe-47", "123", "mohamed", "06 ## ## ## ##", "user-societe-47" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 37, true, "taza", "user-regions-37@panddh.com", "05 ## ## ## ##", 37, 5, "user-regions-37", "123", "mohamed", "06 ## ## ## ##", "user-regions-37" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 25, true, "taza", "user-25@panddh.com", "05 ## ## ## ##", 25, 5, "user-25", "123", "mohamed", "06 ## ## ## ##", "user-25" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 13, true, "taza", "user-13@panddh.com", "05 ## ## ## ##", 13, 5, "user-13", "123", "mohamed", "06 ## ## ## ##", "user-13" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 23, true, "taza", "user-23@panddh.com", "05 ## ## ## ##", 23, 5, "user-23", "123", "mohamed", "06 ## ## ## ##", "user-23" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 1, true, "Temara", "admin@panddh.com", "05 ## ## ## ##", 1, 1, "admin", "123", "panddh", "06 ## ## ## ##", "panddh" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 2, true, "Temara", "mehdi@angular.io", "05 ## ## ## ##", 2, 2, "mehdi", "123", "mehdi", "06 ## ## ## ##", "mehdi" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 49, true, "taza", "user-societe-49@panddh.com", "05 ## ## ## ##", 49, 5, "user-societe-49", "123", "mohamed", "06 ## ## ## ##", "user-societe-49" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 4, true, "Temara", "soufiane@angular.io", "05 ## ## ## ##", 4, 3, "soufiane", "123", "soufiane", "06 ## ## ## ##", "soufiane" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 3, true, "Temara", "ahmed@angular.io", "05 ## ## ## ##", 3, 4, "ahmed", "123", "ahmed", "06 ## ## ## ##", "ahmed" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 5, true, "taza", "user-5@panddh.com", "05 ## ## ## ##", 5, 5, "user-5", "123", "mohamed", "06 ## ## ## ##", "user-5" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 6, true, "taza", "user-6@panddh.com", "05 ## ## ## ##", 6, 5, "user-6", "123", "mohamed", "06 ## ## ## ##", "user-6" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 7, true, "taza", "user-7@panddh.com", "05 ## ## ## ##", 7, 5, "user-7", "123", "mohamed", "06 ## ## ## ##", "user-7" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 8, true, "taza", "user-8@panddh.com", "05 ## ## ## ##", 8, 5, "user-8", "123", "mohamed", "06 ## ## ## ##", "user-8" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 9, true, "taza", "user-9@panddh.com", "05 ## ## ## ##", 9, 5, "user-9", "123", "mohamed", "06 ## ## ## ##", "user-9" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 24, true, "taza", "user-24@panddh.com", "05 ## ## ## ##", 24, 5, "user-24", "123", "mohamed", "06 ## ## ## ##", "user-24" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 10, true, "taza", "user-10@panddh.com", "05 ## ## ## ##", 10, 5, "user-10", "123", "mohamed", "06 ## ## ## ##", "user-10" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 12, true, "taza", "user-12@panddh.com", "05 ## ## ## ##", 12, 5, "user-12", "123", "mohamed", "06 ## ## ## ##", "user-12" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 14, true, "taza", "user-14@panddh.com", "05 ## ## ## ##", 14, 5, "user-14", "123", "mohamed", "06 ## ## ## ##", "user-14" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 15, true, "taza", "user-15@panddh.com", "05 ## ## ## ##", 15, 5, "user-15", "123", "mohamed", "06 ## ## ## ##", "user-15" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 16, true, "taza", "user-16@panddh.com", "05 ## ## ## ##", 16, 5, "user-16", "123", "mohamed", "06 ## ## ## ##", "user-16" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 17, true, "taza", "user-17@panddh.com", "05 ## ## ## ##", 17, 5, "user-17", "123", "mohamed", "06 ## ## ## ##", "user-17" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 18, true, "taza", "user-18@panddh.com", "05 ## ## ## ##", 18, 5, "user-18", "123", "mohamed", "06 ## ## ## ##", "user-18" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 19, true, "taza", "user-19@panddh.com", "05 ## ## ## ##", 19, 5, "user-19", "123", "mohamed", "06 ## ## ## ##", "user-19" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 20, true, "taza", "user-20@panddh.com", "05 ## ## ## ##", 20, 5, "user-20", "123", "mohamed", "06 ## ## ## ##", "user-20" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 21, true, "taza", "user-21@panddh.com", "05 ## ## ## ##", 21, 5, "user-21", "123", "mohamed", "06 ## ## ## ##", "user-21" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 22, true, "taza", "user-22@panddh.com", "05 ## ## ## ##", 22, 5, "user-22", "123", "mohamed", "06 ## ## ## ##", "user-22" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 11, true, "taza", "user-11@panddh.com", "05 ## ## ## ##", 11, 5, "user-11", "123", "mohamed", "06 ## ## ## ##", "user-11" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 50, true, "taza", "user-societe-50@panddh.com", "05 ## ## ## ##", 50, 5, "user-societe-50", "123", "mohamed", "06 ## ## ## ##", "user-societe-50" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 22, "22", 1, 1, 1, 1, 3, 1, " إدماج البعد الثقافي في التنظيم الجهوي على مستوى وسائل الإعلام والبرامج التربوية والتظاهرات الثقافية والفنية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 125, "125", 2, 2, 3, 29, 9, 2, "وضع برامج تواصلية للجمهور الواسع تستهدف التعريف والتحسيس بالحقوق الثقافية واللغوية ومختلف إبداعاتها", null, null, "بيئة مشجعة للنهوض بالحقوق الثقافية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 101, "101", 2, 1, 1, 29, 9, 2, "تقوية مكانة اللغة العربية في البحث العلمي والتقني الجامعي والأكاديمي", null, null, "برامج داعمة لتعزيز مكانة اللغة العربية في الجامعة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 100, "100", 2, 1, 1, 29, 9, 1, "تعزيز استعمال اللغة العربية في المرافق العمومية وباقي مناحي الحياة العامة", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 45, "45", 1, 1, 1, 29, 5, 2, "مراجعة المقتضيات القانونية بما يسمح بمرافقة الدفاع للشخص المعتقل بمجرد وضعه تحت الحراسة النظرية لدى الضابطة القضائية، ومواصلة ملاءمة الإطار التشريعي المنظم للبحث التمهيدي والحراسة النظرية والتفتيش وكافة الإجراءات الضبطية وملاءمتها مع المعايير الدولية ذات الصلة.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 38, "38", 1, 2, 1, 29, 4, 2, " تعميم الخدمات العمومية الإلكترونية في أفق الوصول إلى تحقيق الإدارة الرقمية الشاملة. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 28, "28", 1, 2, 1, 29, 4, 2, " الإسراع بالمصادقة على المقتضيات القانونية المؤطرة لتجريم الإثراء غير المشروع.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 429, "429", 4, 2, 1, 28, 26, 1, "مواصلة جهود تخليق العدالة.", null, null, "دينامية داعمة لتخليق العدالة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 396, "396", 4, 2, 1, 28, 22, 1, "تعزيز البرامج الخاصة بالقضاء على الفقر والتهميش والإقصاء الاجتماعي في أوساط النساء.", null, null, "البرامج الخاصة بالقضاء على الفقر والتهميش والإقصاء الاجتماعي في أوساط النساء معززة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 395, "395", 4, 1, 1, 28, 22, 1, " وضع الآليات الكفيلة بضمان ولوج النساء لمجال المقاولة.", null, null, "أليات كفيلة بتيسير ولوج النساء للمقاولة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 339, "339", 3, 2, 1, 28, 19, 1, "تشجيع النهوض بطب الشيخوخة في وزارة الصحة وإحداث شعب للتكوين الطبي المتخصص في هذا المجال.", null, null, "منظومة داعمة لطب الشيخوخة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 319, "319", 3, 2, 1, 28, 18, 2, " البحث في سبل إشراك القطاع الخاص في إدماج الأشخاص في وضعية إعاقة في سوق الشغل.", null, null, "آلية مشتركة مساعدة على إدماج الأشخاص في وضعية إعاقة في سوق الشغل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 170, "170", 2, 2, 1, 28, 12, 1, " إسراع وتيرة إنجاز برامج القضاء على السكن غير اللائق.", null, null, "برامج مساهمة في القضاء على السكن غير اللائق" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 151, "151", 2, 2, 1, 28, 11, 2, " مواصلة الحوار المجتمعي بشأن الانضمام إلى اتفاقية منظمة العمل الدولية رقم 87 بشأن الحرية النقابية وحماية حق التنظيم النقابي. ", null, null, "حوارمجتمعيواسع. " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 135, "135", 2, 1, 1, 28, 10, 2, " ضمان حقوق المصابين بالأمراض المتنقلة جنسيا وحمايتهم من كل أشكال التمييز أو الإقصاء أو الوصم.", null, null, "برامج داعمة لحقوق المصابين بالأمراض المتنقلة جنسيا" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 124, "124", 2, 1, 1, 28, 9, 1, "وضع ميثاق وطني في مجال التنوع الثقافي موجه إلى كافة المتدخلين والفاعلين.", null, null, "ميثاق وطني في مجال التنوع الثقافي معتمد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 23, "23", 1, 2, 1, 28, 3, 1, " تقوية خدمات القرب وإلزامية تقييم السياسات العمومية وإحداث جهاز مؤسساتي متخصص في هذا المجال.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 434, "434", 4, 2, 3, 27, 26, 1, " تعزيز إدماج مرجعية حقوق الإنسان والتربية على المواطنة ضمن برامج التكوين بالمعهد العالي للقضاء.", null, null, "قدرات متطورة في مجال التكوين القضائي التخصصي; برامج مساهمة في توسيع المعارف وتعزيز القدرات في مجال حقوق الإنسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 427, "427", 4, 1, 1, 27, 26, 2, "الرفع من جودة الأحكام.", null, null, "آلية داعمة للرفع من جودة الاحكام" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 414, "414", 4, 2, 1, 27, 24, 1, " مراجعة النصوص المتعلقة بالتراث الثقافي.", null, null, "إطار قانوني معزز" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 407, "407", 4, 1, 1, 27, 23, 1, "التنصيص على مبدأ المناصفة في دفاتر تحملات شركات الاتصال السمعي البصري.", null, null, "بيئة إعلامية معززة لمبدأ المناصفة في الفضاء السمعي البصري " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 402, "402", 4, 2, 1, 27, 23, 2, "  التعجيل بإصدار القانون المتعلق بالحق في الحصول على المعلومات، انسجاما مع الدستور والاتفاقيات الدولية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 397, "397", 4, 2, 3, 27, 22, 2, "توثيق ونشر الاجتهاد القضائي في مجال حماية حقوق المرأة كمصدر من مصادر التشريع.", null, null, "دينامية داعمة لترصيد الاجتهاد القضائي في مجال حماية حقوق المرأة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 382, "382", 4, 1, 1, 27, 22, 1, " تعزيز حماية النساء ضد العنف على مستوى التشريع والسياسة الجنائية الوطنية.", null, null, "إطار قانوني داعم لحماية النساء ضحايا العنف" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 368, "368", 4, 1, 1, 27, 21, 1, "إحداث مرصد وطني للإجرام.", null, null, "آلية مؤسساتية مساعدة على تتبع تطور ظاهرة الإجرام" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 352, "352", 3, 1, 1, 27, 20, 2, "تفعيل الآليات الكفيلة بتتبع أوضاع السجناء المغاربة الذين يقضون عقوبتهم السجنية بالخارج ضمانا لحقوقهم واعتناء بأوضاعهم. ", null, null, "آليات داعمة لحماية حقوق السجناء المغاربة بالخارج" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 341, "341", 3, 1, 3, 27, 19, 1, "تعزيز قدرات العاملين العموميين والمؤسساتيين لإدماج حاجيات الأشخاص المسنين في السياسات العمومية", null, null, "قدرات معززة لإدماج حاجيات الأشخاص المسنين في السياسات العمومية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 321, "321", 3, 1, 1, 27, 18, 1, " تعميم ولوج الأشخاص في وضعية إعاقة إلى الخدمات الثقافية من خلال اعتماد الوسائل التقنية الحديثة سواء في المؤسسات التعليمية أو المكتبات والمركبات الثقافية والبنيات الرياضية.", null, null, "فضاءات مساعدة على ولوج الأشخاص في وضعية إعاقة إلى الخدمات الثقافية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 278, "278", 3, 2, 3, 27, 16, 1, "مواصلة برامج وأنشطة التدريب والتكوين المستمر على اتفاقية الأمم المتحدة لحقوق الطفل والبروتوكولات الملحقة بها.", null, null, "قدرات الفاعلين متطورة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 266, "266", 3, 1, 1, 27, 16, 2, " اتخاذ تدابير خاصة بحماية الأطفال المتخلى عنهم والعناية ببنيات استقبالهم وتبسيط مسطرة التكفل بهم.", null, null, "بنيات مؤسساتية كفيلة بحماية الأطفال المتخلى عنهم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 160, "160", 2, 2, 1, 29, 11, 1, " تقوية هيئة مفتشي الشغل.", null, null, "هيئة مفتشي الشغل معززة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 267, "267", 3, 2, 1, 29, 16, 2, " العمل على تطوير شراكات مع دول الاستقبال لحماية الأطفال المغاربة من الاستغلال إعمالا لمصلحتهم الفضلى.", null, null, "الشراكات مع دول الاستقبال لحماية الأطفال المغاربة من الاستغلال مطورة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 296, "296", 3, 1, 1, 29, 18, 1, " المصادقة على معاهدة مراكش لتيسير النفاذ إلى المصنفات المنشورة لفائدة الأشخاص المكفوفين أو معاقي البصر أو ذوي إعاقات أخرى في قراءة المطبوعات لسنة 2013.", null, null, "المصادقة على المعاهدة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 300, "300", 3, 2, 1, 29, 18, 2, " دعم عمل آلية التنسيق الحكومية ذات الصلة بالمجال.", null, null, "آلية مؤسساتية داعمة لتنفيذ الاستراتيجية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 241, "241", 3, 2, 1, 31, 16, 2, " الإسراع بإصدار القانون المتعلق بشروط فتح وتدبير مؤسسات الرعاية الاجتماعية والنصوص القانونية والتنظيمية ذات الصلة.", null, null, " إطار قانوني داعم تجويد خدمات مؤسسات الرعاية الاجتماعية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 230, "230", 3, 1, 1, 31, 15, 1, "الرفع من الاعتمادات المخصصة للنهوض بالحقوق الفئوية في الميزانية العامة.", null, null, "اعتمادات مالية مساهمة في النهوض بالحقوق الفئوية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 198, "198", 2, 2, 1, 31, 13, 2, " تقنين الزراعات المستهلكة للمياه خاصة بالمناطق الهشة.", null, null, "برامج داعمةلتكريس تدبير يحافظ على الموارد المائية المحدودة ويضمن استدامتها" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 149, "149", 2, 2, 1, 31, 11, 1, " استكمال مسطرة المصادقة على اتفاقية منظمة العمل الدولية رقم 102 المتعلقة بالمعايير الدنيا للضمان الاجتماعي.", null, null, "المصادقة على تفاقية منظمةا لعمل الدولية رقم 102 المتعلقة بالمعاييرالدنيا للضمان الاجتماعي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 147, "147", 2, 2, 3, 31, 10, 2, "القيام بحملات للتوعية داخل المستشفيات والمراكز والمستوصفات الصحية (ملصقات ومنشورات وأشرطة سمعية بصرية...) من أجل توعية المواطنات والمواطنين بحقوقهم وواجباتهم باللغات المتداولة.", null, null, "مبادرات مساهمة في النهوض بثقافة الحق والواجب                  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 141, "141", 2, 2, 1, 31, 10, 2, " دعم الخطة المتعلقة بتوفير الأدوية الأساسية الاستعجالية وتلك المتعلقة بالأمراض المزمنة.", null, null, "خطة داعمة لضمان تموين مستمر بالأدوية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 116, "116", 2, 2, 1, 31, 9, 2, " توسيع شبكة المراكز والمركبات الثقافية لتشمل عموم المناطق الحضرية والقروية.", null, null, "مركبات ثقافية جهوية ومحلية مساهمة في الإشعاع الثقافي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 112, "112", 2, 1, 1, 31, 9, 1, "تعزيز الشراكات بين المؤسسات الثقافية العمومية والقطاع الخاص ومنظمات الشباب والمجتمع المدني.", null, null, "شراكات داعمة لإبداعات الشباب " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 93, "93", 2, 1, 1, 31, 8, 1, "  اعتماد آلية المساعدة الاجتماعية في الوسط المدرسي", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 89, "89", 1, 2, 1, 31, 8, 1, "   إيجاد آليات لربط مخرجات المنظومة التربوية بالحاجيات الاقتصادية والاجتماعية والثقافية وبأهداف الخطط التنموية", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 84, "84", 1, 1, 1, 31, 8, 2, " مراجعة المناهج والمقررات الدراسية وملاءمتها مع مبادئ وقيم الدستور وأحكامه والاتفاقيات الدولية ذات الصلة. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 81, "81", 1, 1, 3, 31, 7, 1, "تعزيز برامج التدريب والتكوين والتوعية بقيم حقوق الإنسان وآليات حمايتها والنهوض بها الموجهة للقضاة وللمكلفين بإنفاذ القوانين وموظفي السجون", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 17, "17", 1, 1, 1, 31, 2, 1, " تجويد عمل آليات الحوار والتشاور الكفيلة بإعمال المساواة وتكافؤ الفرص على نحو أفضل في كافة دوائر اتخاذ القرار في القطاعات العمومية الوطنية والمحلية والقطاع الخاص والمنظمات غير الحكومية. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 412, "412", 4, 2, 1, 30, 24, 2, " التشجيع على الانضمام إلى الاتفاقيات الدولية المتعلقة بحماية التراث الثقافي والمحافظة عليه.", null, null, "تعزيز الممارسة الاتفاقية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 244, "244", 3, 1, 1, 27, 16, 1, " تطوير وتفعيل المقتضيات القانونية الخاصة بتجريم الاستغلال الجنسي للأطفال والاتجار بهم مع تشديد العقوبات على الجناة.", null, null, "إطار قانوني داعم    لحماية حقوق الطفل " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 277, "277", 3, 2, 3, 30, 16, 2, " الإبداع في أشكال وصيغ الأدوات البيداغوجية حول التربية الجنسية وفق مقاربة وقائية تراعي أعمار ومستوى نضج الأطفال والمخاطر التي قد تهددهم.", null, null, " بيئة داعمة للتربية الجنسية بالوسط المدرسي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 215, "215", 2, 2, 3, 30, 14, 2, " تعزيز المشاركة الوطنية في اللقاءات الدولية والجهوية المتعلقة بالمقاولة وحقوق الإنسان.", null, null, "دينامية داعمة لترصيد وتملك وتبادل الخبرات والممارسات الفضلى في مجال المقاولة وحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 199, "199", 2, 2, 1, 30, 13, 1, " تيسير الولوج إلى المعلومة البيئية وتأمين مشاركة المواطنات والمواطنين في إعداد المشاريع والبرامج ذات الصلة بالبيئة والمشاركة في اتخاذ القرار.", null, null, "إطار مؤسساتي ضامن للحق في المعلومة ومؤمن للمشاركة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 156, "156", 2, 2, 1, 30, 11, 2, " إعداد برامج لدعم وتنشيط المقاولات الصغرى والمتوسطة والتعاونيات ووضع شباك داخل الجماعات الترابية للتعريف بالمقاولات خصوصا النسائية منها.", null, null, "برامج داعمة للمقاولات الصغرى           والمتوسطة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 155, "155", 2, 1, 1, 30, 11, 2, " إعمال مبدأ الشفافية وتكافؤ الفرص في التشغيل ووضع آليات ومساطر إدارية تنظم الإعلان عن المناصب الشاغرة في جميع القطاعات وفي مرافق الإدارة العمومية ضمانا للشفافية.", null, null, "الشفافية   وتكافؤ الفرص في التوظيف معززة  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 118, "118", 2, 1, 1, 30, 9, 2, " وضع برامج تيسر مشاركة وتمتع الأشخاص المسنين وفي وضعية إعاقة بالحقوق الثقافية.", null, null, "بيئة داعمة لتمتع الأشخاص المسنين      وفي وضعية إعاقة بالحقوق الثقافية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 90, "90", 2, 1, 1, 30, 8, 1, "  مأسسة وتعميم الدعم المادي المقدم للمتمدرسين المعوزين والأطفال في وضعية إعاقة", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 75, "75", 1, 1, 1, 30, 7, 2, "حماية المشتكين والمبلغين والشهود والمدافعين عن حقوق الإنسان من أي سوء معاملة ومن أي ترهيب بسبب شكاويهم أو شهاداتهم أمام السلطات العمومية والقضائية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 63, "63", 1, 2, 1, 30, 6, 2, "مواصلة ملاءمة الإطار القانوني المتعلق بحريات الاجتماع وتأسيس الجمعيات مع المعايير الدولية لحقوق الإنسان في نطاق الدستور وأحكامه.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 33, "33", 1, 2, 1, 30, 4, 2, "تفعيل مختلف أشكال الرقابة البرلمانية والإدارية والقضائية في مكافحة الفساد.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 31, "31", 1, 2, 1, 30, 4, 1, "  استكمال الإجراءات التشريعية المتعلقة بإصدار مشروع القانون رقم 13.31 المتعلق بالحق في الوصول إلى المعلومات.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 30, "30", 1, 2, 1, 30, 4, 1, "الإسراع بوضع المقتضيات التنظيمية الخاصة بالتدابير المتعلقة بالوقاية من الفساد. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 7, "7", 1, 2, 3, 30, 1, 1, "تعزيز دور وسائل الإعلام في مجال التوعية والاتصال والحوار العمومي بشأن المشاركة السياسية.", null, null, "برامج داعمة للمشاركة السياسية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 422, "422", 4, 2, 3, 29, 25, 1, " تحسيس مصالح الإدارات العمومية بأهمية إيداع أرشيفها بانتظام لدى مصالح أرشيف المغرب طبقا للنصوص الجاري بها العمل.", null, null, "مصالح الإدارات العمومية منخرطة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 343, "343", 3, 1, 1, 29, 20, 2, " مواصلة التفكير في سبل تفعيل مقتضيات الدستور ذات الصلة بحقوق مغاربة العالم.", null, null, "تصورات حول تفعيل مقتضيات الدستور ذات الصلة بحقوق مغاربة العالم مبلورة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 246, "246", 3, 1, 1, 30, 16, 1, "تبسيط المساطر المتعلقة بتسجيل الأطفال في سجلات الحالة المدنية. ", null, null, "إطار قانوني داعم لتعزيز حق الطفل في الهوية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 252, "252", 3, 1, 1, 31, 16, 2, "إيلاء أهمية قصوى للبرامج الاجتماعية المساهمة في النهوض بوضعية الفتاة وخاصة في مجالات التعليم والتكوين والوصول إلى الموارد.", null, null, "برامج داعمة للنهوض بوضعية الفتاة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 243, "243", 3, 1, 1, 27, 16, 2, " مواصلة الحوار المجتمعي حول مراجعة المادة 20 من مدونة الأسرة المتعلقة بالإذن بزواج القاصر.", null, null, "حوار مجتمعي منظم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 210, "210", 2, 2, 3, 27, 13, 2, " تكوين القضاة والشرطة القضائية والبيئية في مجال الحقوق البيئية.", null, null, "قدرات متطورة في مجال التكوين القضائي التخصصي   " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 232, "232", 3, 1, 1, 24, 15, 2, "مراجعة الإطار القانوني المتعلق بالإحسان العمومي.           ", null, null, "إطار قانوني داعم لتجويد مبادرات الإحسان العمومي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 231, "231", 3, 2, 1, 24, 15, 2, " اعتماد الحكامة الجيدة في تتبع تنفيذ البرامج والاستراتيجيات الخاصة بالفئات في وضعية هشاشة. ", null, null, "آليات داعمة لضمان الحكامة الجيدة في تتبع البرامج الخاصة بالفئات في وضعية هشاشة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 226, "226", 3, 1, 1, 24, 15, 2, " اعتماد معايير الجودة في التدبير وفي خدمات التكفل بمؤسسات الرعاية الاجتماعية من أجل ضمان الحقوق الفئوية. ", null, null, "مؤسسات للرعاية الاجتماعية معتمدة لمعايير الجودة في التدبير وخدمات التكفل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 175, "175", 2, 1, 1, 24, 12, 2, " حصر الاستفادة من برنامج السكن الاجتماعي في ذوي الدخل المحدود بالصرامة اللازمة", null, null, "آليات داعمة لتعزيز الحكامة في تنفيذ برامج السكن الاجتماعي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 164, "164", 2, 1, 3, 24, 11, 1, " وضع برامج لتكوين قضاة متخصصين في قانون الشغل.", null, null, "برامج داعمة للتخصص القضائي في قانون الشغل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 115, "115", 2, 2, 1, 24, 9, 2, "تعزيز القواعد المنظمة للسكن اللائق بإحداث مرافق تعزز الحياة والإبداع الثقافيين.", null, null, "برامج سكنية معززة للحياة الثقافية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 428, "428", 4, 2, 1, 23, 26, 2, "مواصلة تحسين الخدمات القضائية.", null, null, "إجراءات معززة للخدمات القضائية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 423, "423", 4, 1, 3, 23, 25, 2, "تقوية قدرات مؤسسة أرشيف المغرب المادية والبشرية حتى تتمكن من الاضطلاع بالمهام المنوطة بها.", null, null, "قدرات مؤسسة أرشيف المغرب معززة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 371, "371", 4, 1, 1, 23, 21, 1, " وضع ميثاق النجاعة القضائية للتدبير الجيد للجلسات وآجال البت وتصفية المخلف والتواصل مع المواطنين والاستماع إلى شكاياتهم وغيرها من الإجراءات المماثلة.", null, null, "آليات داعمة لتجويد خدمات العدالة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 370, "370", 4, 1, 1, 23, 21, 1, "عقد شراكات وعلاقات تعاون مع مؤسسات وطنية ودولية تعنى بحقوق الإنسان للمساهمة في تأطير وتكوين القضاة والمحامين في مجال تملك ثقافة حقوق الإنسان فكرا وسلوكا وعملا.", null, null, "شراكات وبرامج داعمة لتملك ثقافة حقوق الإنسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 304, "304", 3, 1, 1, 23, 18, 2, " تعزيز التمدرس بالقسم الدراسي العادي مع توفير الترتيبات التيسيرية اللازمة وتوسيع شبكة الأقسام المدمجة لتشمل المستوى الإعدادي والثانوي وجعل المراكز المتخصصة جزء من المنظومة التعليمية الوطنية.", null, null, "تضاعف عدد الممدرسين من الأطفال في وضعية إعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 295, "295", 3, 2, 3, 23, 17, 2, "تعزيز برامج محو الأمية في أفق القضاء عليها وتأهيل الشباب.", null, null, "تقليص المعدل العام للأمية إلى20 % سنة 2021" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 284, "284", 3, 2, 1, 23, 17, 2, " تعزيز نقط ارتكاز خاصة بالشباب في القطاعات والمؤسسات المعنية مركزيا ومحليا.", null, null, "بيئة إدارية داعمة للتنسيق بين القطاعات" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 211, "211", 2, 1, 3, 23, 14, 1, " إعداد واعتماد خطة عمل وطنية في مجال المقاولة وحقوق الإنسان بإشراك كافة الفاعلين المعنيين (قطاعات حكومية والبرلمان والقطاع الخاص والنقابات وهيئات الحكامة والديمقراطية التشاركية وحقوق الإنسان ومنظمات المجتمع المدني...).", null, null, "خطة معتمدة في مجال المقاولة وحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 159, "159", 2, 1, 1, 23, 11, 1, " تقوية آلية التعويض عن فقدان الشغل.", null, null, "إطار قانوني داعم لحماية العمال      والأجراء عند فقدان الشغل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 82, "82", 1, 2, 1, 23, 8, 1, "تفعيل الرؤية الاستراتيجية لإصلاح التعليم 2015-2030 من أجل مدرسة الجودة والارتقاء، وإصدار القانون الإطار الخاص بها", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 29, "29", 1, 1, 1, 23, 4, 2, "الإسراع بوضع ميثاق للمرافق العمومية يتضمن قواعد الحكامة الإدارية الجيدة.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 424, "424", 4, 2, 3, 22, 25, 1, "النهوض بالموارد البشرية المعنية بمعالجة وبحفظ وتنظيم الأرشيف باعتماد برامج منتظمة خاصة بالتكوين والتكوين المستمر موجهة لفائدة المهنيين.", null, null, "الموارد البشرية بمؤسسة أرشيف المغرب مكونة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 386, "386", 4, 1, 1, 22, 22, 1, "  تعزيز الضمانات القانونية المتعلقة بتجريم التحرش الجنسي.", null, null, "إطار قانوني داعم لحماية النساء ضحايا العنف" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 364, "364", 4, 2, 1, 22, 21, 1, "الإسراع بإخراج المقتضيات القانونية الناظمة للعقوبات البديلة بهدف الحد من إشكالات الاعتقال الاحتياطي والاكتظاظ في السجون.", null, null, "مقتضيات قانونية داعمة لتجويد خدمات المؤسسة السجنية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 330, "330", 3, 2, 1, 22, 19, 2, " حماية حقوق وكرامة الأشخاص المسنين بتجويد معايير وخدمات التكفل على مستوى البنيات والموارد البشرية.", null, null, "بنيات مهيكلة وفق معايير الجودة، مؤهلة لصيانة حقوق وكرامة الأشخاص المسنين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 255, "255", 3, 2, 1, 22, 16, 2, " تعزيز الولوج الآمن للأطفال إلى وسائل الإعلام والاتصال المعتمدة على التكنولوجية الحديثة عبر وضع برامج خاصة وحمايتهم من كافة أشكال الاستغلال.", null, null, "بيئة داعمة لولوج الأطفال الآمن   لوسائل الإعلام والاتصال المعتمدة على التكنولوجيا الحديثة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 238, "238", 3, 1, 1, 22, 16, 2, " مواصلة تقوية الإطار القانوني المتعلق بحماية الأطفال وضمان فعاليته.", null, null, "إطار قانوني داعم لحماية حقوق  الأطفال" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 204, "204", 2, 2, 1, 22, 13, 2, " تشجيع التدريس والبحث العلمي في الجامعة ومعاهد التكوين ومراكز البحث العلمي حول البيئة والتنمية المستدامة.", null, null, "مبادرات داعمة للتدريس والبحث العلمي في مجال البيئة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 152, "152", 2, 2, 1, 22, 11, 2, "تشجيع وتقوية أدوار لجان الحوار والمصالحة الإقليمية والوطنية.", null, null, "اللجان الإقليمية للبحث والمصالحة مفعلة على مستوى العمالات والأقاليم." });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 110, "110", 2, 2, 1, 22, 9, 2, "تشجيع البحث الجامعي على مواصلة الجهود حول تاريخ المغرب المتعدد بعمقه الديني وبمكوناته البشرية والثقافية والمحلية", null, null, "برامج داعمة للبحث الجامعي حول تاريخ المغرب المتعدد بعمقه الديني وبمكوناته البشرية والثقافية والمحلية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 62, "62", 1, 2, 3, 22, 5, 1, " تقوية الخبرة الفنية فيما يخص عمل لجان تقصي الحقائق البرلمانية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 56, "56", 1, 1, 3, 22, 5, 1, " وضع خطط للإعلام والتواصل مع المواطنات والمواطنين ومهنيي الإعلام بخصوص الحالة الأمنية من خلال تقارير وبلاغات وندوات صحفية ومنشورات.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 18, "18", 1, 1, 3, 22, 2, 1, " وضع برامج فعالة للتوعية والتحسيس والتربية على قيم ومبادئ المساواة وتكافؤ الفرص والمناصفة لفائدة أطر وموظفي الإدارات والمؤسسات العمومية والجماعات الترابية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 240, "240", 3, 1, 1, 24, 16, 1, " مراجعة قانون الكفالة بما يتلاءم ومقتضيات الدستور.", null, null, "إطار تشريعي   وتنظيمي معتمد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 289, "289", 3, 1, 3, 24, 17, 1, " الرفع من عدد البرامج المعدة من الشباب والموجهة إليهم في دفاتر تحملات الشركات العمومية للاتصال السمعي البصري.", null, null, "برامج إعلامية محفزة على مشاركة الشباب " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 298, "298", 3, 1, 1, 24, 18, 1, "  الإسراع بإصدار النصوص التنظيمية المنصوص عليها في القانون الإطار المتعلق بحماية حقوق الأشخاص في وضعية إعاقة والنهوض بها.", null, null, "مقتضيات تنظيمية داعمة لتفعيل القانون الإطار" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 311, "311", 3, 1, 1, 24, 18, 2, " توفير الوسائل التيسيرية لولوج الأشخاص في وضعية إعاقة إلى منظومة العدالة.", null, null, "بنيات منظومة العدالة مساعدة على ولوجها" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 166, "166", 2, 2, 1, 27, 12, 2, " تعزيز المنظومة القانونية المتعلقة بالسكن والتعمير وملاءمتها مع متطلبات حقوق الإنسان.", null, null, "إطار قانوني داعم للحق في السكن" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 161, "161", 2, 1, 1, 27, 11, 2, "وضع برامج وخطط كفيلة بتأهيل التكوين المهني وجعله يساهم بفعالية في تقليص معدلات البطالة. ", null, null, "برامج داعمة للنهوض بالتكوين المهني كرافعة للتشغيل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 106, "106", 2, 2, 1, 27, 9, 2, "تعزيز وسائل التظلم والانتصاف المتعلقة بالتمييز في مجال الحقوق الثقافية", null, null, "سائل التظلم والانتصاف المتعلقة بالتمييز في مجال الحقوق معززة جهويا ومركزيا" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 66, "66", 1, 2, 1, 27, 6, 2, "تبسيط المساطر المتعلقة بالتصريح بالتجمعات العمومية من أجل تعزيز وضمان ممارسة الحريات العامة من طرف مختلف مكونات المجتمع (جمعيات، نقابات) والعمل على ضمان التطبيق السليم للمساطر المعمول بها في هذا المجال.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 42, "42", 1, 1, 3, 27, 4, 2, "وضع سياسة إعلامية وخطط تواصلية لبلوغ أهداف الاستراتيجية الوطنية لمكافحة الفساد وفق مقاربة تتأسس على سيادة القانون واحترام حقوق الإنسان.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 10, "10", 1, 1, 3, 27, 1, 2, " وضع برامج لتربية الأطفال على قيم المواطنة في الوسط التربوي ودعم برلمان الطفل وكافة أشكال تفعيل حقوق المشاركة لدى الأطفال.", null, null, "برامج داعمة لقيم المواطنة ومشاركة الأطفال " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 385, "385", 4, 1, 1, 26, 22, 2, " تفعيل النصوص التنظيمية الخاصة بتنفيذ القانون المتعلق بتحديد شروط التشغيل والشغل الخاص بالعمال المنزليين.", null, null, "المقتضيات القانونية للقانون رقم 19.12 مفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 326, "326", 3, 1, 3, 26, 18, 2, " تطوير التكوين الأساسي والمستمر في مجال الإعاقة خصوصا في ميدان التربية والتكوين المهني والصحة ولاسيما ما يتعلق ببعض أنواع الإعاقة كالتوحد.", null, null, "برامج داعمة للنهوض بالتكوين الأساسي والمستمر في مجال الإعاقة في ميدان التربية والتكوين المهني" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 320, "320", 3, 1, 1, 26, 18, 1, " دعم وتشجيع مبادرات المجتمع المدني العامل في مجال الإعاقة.", null, null, "مجتمع مدني متفاعل في مجال الإعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 318, "318", 3, 1, 1, 26, 18, 1, " توحيد لغة الإشارة ووضع معايير لها.", null, null, "إطار معياري معد ومعتمد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 276, "276", 3, 2, 3, 26, 16, 2, " تقوية برامج الوقاية الموجهة للأطفال في وضعية صعبة ولأسرهم.", null, null, "برامج معززة لحماية الأطفال في وضعية صعبة ولأسرهم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 236, "236", 3, 2, 1, 26, 16, 2, " تفعيل المجلس الاستشاري للأسرة والطفولة وإصدار النصوص التشريعية والتنظيمية المتعلقة به.", null, null, "المجلس الاستشاري للأسرة والطفولة مفعل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 222, "222", 3, 2, 1, 26, 15, 2, " دعم الآليات والتدابير الكفيلة ببلورة وتيسير تتبع وتقييم السياسات العمومية والبرامج التي تستهدف الحماية والنهوض بالحقوق الفئوية.", null, null, "آليات كفيلة بتطوير نجاعة البرامج الخاصة بالحقوق الفئوية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 212, "212", 2, 2, 3, 26, 14, 1, "-212- تحفيز المقاولات على وضع ميثاق داخلي عام للسلوك في مجال حقوق الإنسان.", null, null, "بيئة داعمة للنهوض بحقوق الإنسان داخل المقاولة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 228, "228", 3, 2, 1, 27, 15, 1, " وضع أنظمة معلوماتية لتتبع الحقوق الفئوية.", null, null, "أنظمة معلوماتية مساعدة على تتبع الحقوق الفئوية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 99, "99", 2, 1, 1, 26, 9, 1, "  تنمية الأشكال والآليات والوسائل الكفيلة بالحفاظ على التنوع الثقافي وتطويره في السياسات العمومية والاستراتيجيات والمخططات والبرامج الوطنية التي تقتضي إعمال الحقوق الثقافية بما فيها الحق في المشاركة الثقافية ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 12, "12", 1, 1, 3, 26, 1, 1, " وضع برامج تدريبية وتكوينية فعالة تستهدف تطوير مهارات التواصل والرفع بمستوى الثقافة الحقوقية والسياسية في نطاق الدستور والتزامات المملكة المغربية في مجال حقوق الإنسان.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 431, "431", 4, 1, 1, 25, 26, 2, " تفعيل المقتضيات الدستورية المتعلقة بتقوية الدور الرقابي للبرلمان على الحكومة والمؤسسات التابعة للدولة من خلال لجن التقصي وغيرها من الآليات المتوفرة.", null, null, "إطار قانوني داعم للدور الرقابي للبرلمان على الحكومة والمؤسسات التابعة للدولة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 411, "411", 4, 2, 3, 25, 23, 2, "إدماج قيم حقوق الإنسان في برامج التكوين والتدريب الموجهة لمهنيي الإعلام والاتصال", null, null, "برامج التكوين والتدريب معززة بقيم حقوق الانسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 410, "410", 4, 2, 3, 25, 23, 2, "تعزيز برامج التوعية والتحسيس بشأن مكتسبات وتحديات ممارسة حريات التعبير والإعلام والصحافة والحق في المعلومة", null, null, "عدد البرامج والشراكات والدعامات المنجزة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 359, "359", 3, 2, 3, 25, 20, 1, " إعداد برامج للتكوين والتكوين المستمر تستحضر البعد الحقوقي وتستهدف الجمعيات التي تعمل مع المغاربة في الخارج والمهاجرين بالمغرب.", null, null, "قدرات فعاليات المجتمع المدني معززة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 301, "301", 3, 2, 1, 25, 18, 1, " إحداث مركز وطني للرصد والتوثيق والبحث في مجال الإعاقة.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 273, "273", 3, 2, 3, 25, 16, 2, " إشاعة ثقافة حقوق الطفل داخل مؤسسات الرعاية الاجتماعية المستقبلة للأطفال.", null, null, "ثقافة حقوق الطفل مشاعة داخل مؤسسات الرعاية الاجتماعية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 203, "203", 2, 1, 1, 25, 13, 2, " تيسير ولوج المواطنات المواطنين إلى القضاء عند التعرض للأضرار البيئية لأجل تحقيق عدالة بيئية.", null, null, "معرفة مساعدة على تيسير الحق في العدالة البيئية  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 138, "138", 2, 2, 1, 25, 10, 1, " إحداث خلايا تساعد الأطر الصحية على التواصل مع المرضى المتحدثين بالأمازيغية والحسانية.", null, null, "بنيات داعمة للتواصل مع المرضى المتحدثين باللغة الأمازيغية والحسانية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 133, "133", 2, 1, 1, 25, 10, 1, " النهوض بصحة الأم والمواليد الجدد والعناية بطب التوليد.", null, null, "برامج صحية معززة لصحة الأم والطفل والمواليد الجدد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 78, "78", 1, 1, 1, 25, 7, 1, " إحالة نتائج تحريات الآلية الوطنية للوقاية من التعذيب على القضاء.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 60, "60", 1, 1, 3, 25, 5, 2, "تعميم تدريس مادة حقوق الإنسان وأحكام القانون الدولي الإنساني ضمن برامج التكوين الأساسي والمستمر الخاص بالموظفين المكلفين بتنفيذ القانون.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 25, "25", 1, 2, 1, 25, 3, 1, "--", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 11, "11", 1, 2, 3, 25, 1, 2, " إحداث فضاءات لإثراء مشاركة اليافعين والشباب في الوسط التربوي والهيئات التمثيلية.", null, null, "برامج ومبادرات داعمة لمشاركة الشباب واليافعين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 68, "68", 1, 1, 1, 26, 6, 2, "تعزيز الشراكة بين مؤسسات الدولة والجمعيات والرفع من مستوى حكامتها.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 5, "5", 1, 2, 1, 22, 1, 2, "تكريس مبدأ التشاور العمومي في إعداد السياسات العمومية وتنفيذها وتقييمها، وكذا تفعيل دور الجمعيات المهتمة بقضايا الشأن العام والمنظمات غير الحكومية في المساهمة في إعداد القرارات والمشاريع لدى المؤسسات المنتخبة والسلطات العمومية وتفعيلها وتقييمها.", null, null, "مقتضيات قانونية تعزز المشاركة المواطنة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 265, "265", 3, 2, 1, 31, 16, 2, "اتخاذ تدابير خاصة بحماية الأطفال المهاجرين غير المرافقين وبولوجهم إلى الخدمات الأساسية لا سيما تلك المتعلقة بالصحة والتربية والتعليم.", null, null, "برامج داعمة لحماية الأطفال المهاجرين غير المرافقين " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 351, "351", 3, 2, 1, 31, 20, 2, "مواصلة المجهودات المبذولة للرقي بالبرامج الموجهة لفائدة مغاربة العالم والاستجابة لانتظاراتهم الثقافية واللغوية والدينية والتربوية في بلدان الاستقبال وتعزيز التواصل بينهم وبين بلدهم الأصلي.", null, null, "برامج متنوعة تستجيب لإنتظارات مغاربة العالم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 534, "Code : {id - 1}", 4, 1, 3, 47, 20, 3, "534 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 534", "بعد الأهداف الخاصة : 534", "بعد النتائج المرتقبة : 534" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 533, "Code : {id - 1}", 3, 3, 1, 47, 4, 1, "533 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 533", "بعد الأهداف الخاصة : 533", "بعد النتائج المرتقبة : 533" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 529, "Code : {id - 1}", 2, 1, 1, 47, 9, 1, "529 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 529", "بعد الأهداف الخاصة : 529", "بعد النتائج المرتقبة : 529" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 525, "Code : {id - 1}", 1, 3, 1, 47, 12, 1, "525 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 525", "بعد الأهداف الخاصة : 525", "بعد النتائج المرتقبة : 525" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 523, "Code : {id - 1}", 1, 2, 1, 47, 17, 1, "523 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 523", "بعد الأهداف الخاصة : 523", "بعد النتائج المرتقبة : 523" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 513, "Code : {id - 1}", 4, 2, 1, 47, 3, 1, "513 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 513", "بعد الأهداف الخاصة : 513", "بعد النتائج المرتقبة : 513" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 512, "Code : {id - 1}", 3, 2, 1, 47, 9, 3, "512 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 512", "بعد الأهداف الخاصة : 512", "بعد النتائج المرتقبة : 512" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 507, "Code : {id - 1}", 4, 3, 2, 47, 24, 1, "507 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 507", "بعد الأهداف الخاصة : 507", "بعد النتائج المرتقبة : 507" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 503, "Code : {id - 1}", 2, 2, 1, 47, 17, 1, "503 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 503", "بعد الأهداف الخاصة : 503", "بعد النتائج المرتقبة : 503" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 501, "Code : {id - 1}", 4, 1, 2, 47, 20, 3, "501 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 501", "بعد الأهداف الخاصة : 501", "بعد النتائج المرتقبة : 501" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 499, "Code : {id - 1}", 2, 2, 1, 47, 26, 3, "499 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 499", "بعد الأهداف الخاصة : 499", "بعد النتائج المرتقبة : 499" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 496, "Code : {id - 1}", 2, 1, 2, 47, 1, 3, "496 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 496", "بعد الأهداف الخاصة : 496", "بعد النتائج المرتقبة : 496" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 488, "Code : {id - 1}", 2, 3, 2, 47, 24, 2, "488 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 488", "بعد الأهداف الخاصة : 488", "بعد النتائج المرتقبة : 488" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 487, "Code : {id - 1}", 3, 1, 2, 47, 15, 1, "487 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 487", "بعد الأهداف الخاصة : 487", "بعد النتائج المرتقبة : 487" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 468, "Code : {id - 1}", 3, 2, 3, 46, 10, 2, "468 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 468", "بعد الأهداف الخاصة : 468", "بعد النتائج المرتقبة : 468" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 457, "Code : {id - 1}", 3, 3, 2, 46, 2, 2, "457 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 457", "بعد الأهداف الخاصة : 457", "بعد النتائج المرتقبة : 457" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 451, "Code : {id - 1}", 3, 2, 1, 46, 7, 1, "451 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 451", "بعد الأهداف الخاصة : 451", "بعد النتائج المرتقبة : 451" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 464, "Code : {id - 1}", 1, 1, 3, 45, 16, 1, "464 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 464", "بعد الأهداف الخاصة : 464", "بعد النتائج المرتقبة : 464" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 455, "Code : {id - 1}", 1, 2, 1, 45, 25, 1, "455 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 455", "بعد الأهداف الخاصة : 455", "بعد النتائج المرتقبة : 455" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 449, "Code : {id - 1}", 1, 3, 1, 45, 2, 1, "449 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 449", "بعد الأهداف الخاصة : 449", "بعد النتائج المرتقبة : 449" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 444, "Code : {id - 1}", 3, 1, 3, 45, 9, 3, "444 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 444", "بعد الأهداف الخاصة : 444", "بعد النتائج المرتقبة : 444" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 483, "Code : {id - 1}", 1, 1, 1, 44, 10, 1, "483 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 483", "بعد الأهداف الخاصة : 483", "بعد النتائج المرتقبة : 483" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 480, "Code : {id - 1}", 1, 3, 1, 44, 3, 2, "480 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 480", "بعد الأهداف الخاصة : 480", "بعد النتائج المرتقبة : 480" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 479, "Code : {id - 1}", 2, 2, 3, 44, 19, 2, "479 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 479", "بعد الأهداف الخاصة : 479", "بعد النتائج المرتقبة : 479" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 461, "Code : {id - 1}", 2, 2, 3, 44, 8, 3, "461 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 461", "بعد الأهداف الخاصة : 461", "بعد النتائج المرتقبة : 461" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 450, "Code : {id - 1}", 1, 2, 3, 44, 2, 1, "450 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 450", "بعد الأهداف الخاصة : 450", "بعد النتائج المرتقبة : 450" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 482, "Code : {id - 1}", 3, 3, 2, 43, 16, 1, "482 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 482", "بعد الأهداف الخاصة : 482", "بعد النتائج المرتقبة : 482" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 476, "Code : {id - 1}", 2, 2, 1, 43, 21, 1, "476 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 476", "بعد الأهداف الخاصة : 476", "بعد النتائج المرتقبة : 476" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 472, "Code : {id - 1}", 2, 3, 3, 43, 23, 2, "472 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 472", "بعد الأهداف الخاصة : 472", "بعد النتائج المرتقبة : 472" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 490, "Code : {id - 1}", 4, 3, 2, 48, 1, 3, "490 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 490", "بعد الأهداف الخاصة : 490", "بعد النتائج المرتقبة : 490" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 494, "Code : {id - 1}", 3, 3, 2, 48, 10, 2, "494 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 494", "بعد الأهداف الخاصة : 494", "بعد النتائج المرتقبة : 494" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 497, "Code : {id - 1}", 2, 1, 1, 48, 12, 3, "497 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 497", "بعد الأهداف الخاصة : 497", "بعد النتائج المرتقبة : 497" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 509, "Code : {id - 1}", 3, 1, 3, 48, 22, 1, "509 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 509", "بعد الأهداف الخاصة : 509", "بعد النتائج المرتقبة : 509" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 531, "Code : {id - 1}", 3, 2, 3, 50, 21, 3, "531 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 531", "بعد الأهداف الخاصة : 531", "بعد النتائج المرتقبة : 531" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 530, "Code : {id - 1}", 3, 3, 2, 50, 9, 2, "530 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 530", "بعد الأهداف الخاصة : 530", "بعد النتائج المرتقبة : 530" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 521, "Code : {id - 1}", 2, 3, 3, 50, 9, 3, "521 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 521", "بعد الأهداف الخاصة : 521", "بعد النتائج المرتقبة : 521" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 515, "Code : {id - 1}", 4, 2, 1, 50, 1, 2, "515 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 515", "بعد الأهداف الخاصة : 515", "بعد النتائج المرتقبة : 515" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 514, "Code : {id - 1}", 2, 3, 3, 50, 6, 3, "514 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 514", "بعد الأهداف الخاصة : 514", "بعد النتائج المرتقبة : 514" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 506, "Code : {id - 1}", 3, 2, 3, 50, 8, 2, "506 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 506", "بعد الأهداف الخاصة : 506", "بعد النتائج المرتقبة : 506" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 505, "Code : {id - 1}", 3, 1, 1, 50, 25, 2, "505 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 505", "بعد الأهداف الخاصة : 505", "بعد النتائج المرتقبة : 505" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 504, "Code : {id - 1}", 2, 3, 2, 50, 14, 3, "504 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 504", "بعد الأهداف الخاصة : 504", "بعد النتائج المرتقبة : 504" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 502, "Code : {id - 1}", 3, 2, 2, 50, 8, 2, "502 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 502", "بعد الأهداف الخاصة : 502", "بعد النتائج المرتقبة : 502" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 500, "Code : {id - 1}", 4, 2, 1, 50, 2, 3, "500 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 500", "بعد الأهداف الخاصة : 500", "بعد النتائج المرتقبة : 500" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 498, "Code : {id - 1}", 2, 1, 2, 50, 11, 3, "498 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 498", "بعد الأهداف الخاصة : 498", "بعد النتائج المرتقبة : 498" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 493, "Code : {id - 1}", 3, 3, 3, 50, 17, 3, "493 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 493", "بعد الأهداف الخاصة : 493", "بعد النتائج المرتقبة : 493" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 489, "Code : {id - 1}", 1, 2, 2, 50, 25, 3, "489 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 489", "بعد الأهداف الخاصة : 489", "بعد النتائج المرتقبة : 489" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 535, "Code : {id - 1}", 3, 2, 1, 49, 18, 3, "535 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 535", "بعد الأهداف الخاصة : 535", "بعد النتائج المرتقبة : 535" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 466, "Code : {id - 1}", 4, 1, 1, 43, 21, 3, "466 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 466", "بعد الأهداف الخاصة : 466", "بعد النتائج المرتقبة : 466" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 527, "Code : {id - 1}", 4, 3, 1, 49, 22, 1, "527 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 527", "بعد الأهداف الخاصة : 527", "بعد النتائج المرتقبة : 527" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 520, "Code : {id - 1}", 3, 3, 3, 49, 1, 3, "520 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 520", "بعد الأهداف الخاصة : 520", "بعد النتائج المرتقبة : 520" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 519, "Code : {id - 1}", 4, 2, 2, 49, 11, 3, "519 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 519", "بعد الأهداف الخاصة : 519", "بعد النتائج المرتقبة : 519" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 518, "Code : {id - 1}", 4, 2, 1, 49, 6, 3, "518 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 518", "بعد الأهداف الخاصة : 518", "بعد النتائج المرتقبة : 518" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 517, "Code : {id - 1}", 4, 3, 2, 49, 23, 2, "517 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 517", "بعد الأهداف الخاصة : 517", "بعد النتائج المرتقبة : 517" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 516, "Code : {id - 1}", 4, 3, 2, 49, 20, 2, "516 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 516", "بعد الأهداف الخاصة : 516", "بعد النتائج المرتقبة : 516" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 508, "Code : {id - 1}", 3, 3, 2, 49, 18, 1, "508 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 508", "بعد الأهداف الخاصة : 508", "بعد النتائج المرتقبة : 508" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 495, "Code : {id - 1}", 1, 3, 3, 49, 16, 2, "495 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 495", "بعد الأهداف الخاصة : 495", "بعد النتائج المرتقبة : 495" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 492, "Code : {id - 1}", 3, 2, 3, 49, 26, 3, "492 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 492", "بعد الأهداف الخاصة : 492", "بعد النتائج المرتقبة : 492" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 491, "Code : {id - 1}", 2, 3, 1, 49, 1, 2, "491 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 491", "بعد الأهداف الخاصة : 491", "بعد النتائج المرتقبة : 491" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 528, "Code : {id - 1}", 1, 1, 2, 48, 4, 3, "528 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 528", "بعد الأهداف الخاصة : 528", "بعد النتائج المرتقبة : 528" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 524, "Code : {id - 1}", 1, 1, 1, 48, 23, 3, "524 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 524", "بعد الأهداف الخاصة : 524", "بعد النتائج المرتقبة : 524" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 522, "Code : {id - 1}", 1, 2, 3, 48, 12, 2, "522 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 522", "بعد الأهداف الخاصة : 522", "بعد النتائج المرتقبة : 522" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 511, "Code : {id - 1}", 3, 2, 3, 48, 10, 3, "511 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 511", "بعد الأهداف الخاصة : 511", "بعد النتائج المرتقبة : 511" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 510, "Code : {id - 1}", 2, 1, 1, 48, 12, 3, "510 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 510", "بعد الأهداف الخاصة : 510", "بعد النتائج المرتقبة : 510" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 526, "Code : {id - 1}", 4, 1, 3, 49, 4, 3, "526 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 526", "بعد الأهداف الخاصة : 526", "بعد النتائج المرتقبة : 526" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 275, "275", 3, 2, 3, 31, 16, 2, "مواصلة تعزيز برامج وأنشطة حقوق المشاركة لدى الأطفال.", null, null, "بيئة مشجعة على مشاركة الأطفال" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 465, "Code : {id - 1}", 3, 3, 3, 43, 26, 2, "465 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 465", "بعد الأهداف الخاصة : 465", "بعد النتائج المرتقبة : 465" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 481, "Code : {id - 1}", 2, 2, 1, 42, 10, 1, "481 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 481", "بعد الأهداف الخاصة : 481", "بعد النتائج المرتقبة : 481" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 309, "309", 3, 2, 1, 33, 18, 2, "النهوض بالولوجية الشاملة سواء على المستوى العمراني والمعماري ووسائل النقل والاتصال.", null, null, "ولوجيات كفيلة بالمساهمة في تحسين ظروف عيش الأشخاص في وضعية إعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 181, "181", 2, 2, 3, 33, 12, 2, " وضع برامج تدريب وتكوين في مجالات التمتع بالحق في السكن اللائق والمصاحبة الاجتماعية الموجهة للفئات ذات الدخل المحدود وغير القار.", null, null, "برامج داعمة للتحسيس بالحق في السكن" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 174, "174", 2, 1, 1, 33, 12, 1, "تنفيذ أولويات السكن الاجتماعي بمضاعفة العرض في مجال المنتوجات السكنية الملائمة لحاجيات وإمكانيات الفئات المحدودة الدخل في إطار مشروع تطوير المنتوج السكني البديل في أفق 2021.", null, null, "عرض سكني مستجيب لحاجيات الفئات المحدودة الدخل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 167, "167", 2, 2, 1, 33, 12, 2, "وضع مقتضيات قانونية وتنظيمية تخص المعايير الدنيا المطبقة على السكن الاجتماعي من حيث المواصفات العمرانية والمناطق الخضراء والسلامة الأمنية والولوجيات.", null, null, "منظومة قانونية داعمة للسكن الاجتماعي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 140, "140", 2, 1, 1, 33, 10, 1, " دعم عمل الفرق الطبية المتنقلة في إطار تقريب الخدمات الصحية وتيسيرها.", null, null, "آليات داعمة لتقريب الخدمات الصحية وتيسيرها" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 64, "64", 1, 2, 1, 33, 6, 2, "مراجعة القوانين المنظمة للحريات العامة لضمان انسجامها مع الدستور من حيث القواعد القانونية الجوهرية والإجراءات الخاصة بفض التجمعات العمومية والتجمهر والتظاهر وذلك في إطار احترام المعايير الدولية والقواعد الديمقراطية المتعارف عليها.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 57, "57", 1, 2, 3, 33, 5, 1, "تبسيط وتيسير وتعميم نشر المذكرات والدوريات المتعلقة بحقوق الإنسان المعمول بها في المؤسسات الأمنية على كافة موظفيها المكلفين بتنفيذ القانون.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 34, "34", 1, 2, 1, 33, 4, 2, " تفعيل أدوار مؤسسات الحكامة والديمقراطية التشاركية في اقتراح التدابير ذات الأثر المباشر على مكافحة الفساد ودعم عملها في كل ما يخص نشر قيم النزاهة والشفافية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 420, "420", 4, 2, 1, 32, 25, 1, " رصد مصادر الأرشيف الخاصة بالمغرب والموجودة خارج الوطن ومواصلة استرجاعها ومعالجتها وحفظها وتيسير الاطلاع عليها من قبل المهتمين. ", null, null, "الأرصدة الوثائقية المتعلقة بالمغرب والموجودة بالخارج مرصودة ومعالجة وميسرة للاطلاع" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 419, "419", 4, 2, 1, 32, 25, 2, "وضع تصور لتدبير الأرشيف في إطار الجهوية المتقدمة.", null, null, "خطة وطنية لتنظيم الأرشيفات الترابية معتمدة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 389, "389", 4, 2, 1, 32, 22, 1, " تعزيز آليات الرصد والتتبع لحماية النساء ضحايا العنف وطنيا جهويا ومحليا.", null, null, "آليات فعالة لحماية النساء ضحايا العنف" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 379, "379", 4, 1, 1, 32, 22, 1, " تفعيل الهيئة المكلفة بالمناصفة ومكافحة جميع أشكال التمييز.", null, null, "هيئة المناصفة ومكافحة جميع أشكال التمييز مفعلة." });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 345, "345", 3, 1, 1, 32, 20, 2, " وضع المقتضيات التنظيمية الخاصة بقانون مكافحة الاتجار بالبشر.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 294, "294", 3, 1, 3, 32, 17, 2, " تعزيز المقررات المدرسية والجامعية بمصوغات بيداغوجية تعنى بحقوق الانسان وبالتربية على المواطنة.", null, null, "بيئة تربوية داعمة لترسيخ ثقافة حقوق الإنسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 286, "286", 3, 1, 1, 32, 17, 1, " إعداد وتعميم تقارير دورية حول الشباب.", null, null, "تقارير مساعدة على تتبع وضعية الشباب" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 285, "285", 3, 1, 1, 32, 17, 1, " وضع برامج استعجالية لفائدة فئات الشباب الأكثر هشاشة (في وضعية إعاقة أو إقصاء...).", null, null, "برامج مساعدة على إدماج الشباب الأكثر هشاشة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 268, "268", 3, 1, 1, 32, 16, 1, "وضع آليات ترابية مندمجة لحماية الطفولة تضمن التنسيق واليقظة من حيث الإشعار والتبليغ وتتبع الخدمات الموجهة للأطفال ضحايا العنف.", null, null, "آليات ترابية مندمجة لحماية الطفولة مفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 260, "260", 3, 2, 1, 32, 16, 2, "وضع تصنيفات ودفاتر تحملات خاصة بأصناف مؤسسات الرعاية الاجتماعية المستقبلة للأطفال في حاجة للحماية.", null, null, "مؤسسات الرعاية الاجتماعية المستقبلة للأطفال مصنفة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 216, "216", 2, 1, 3, 32, 14, 2, " تعزيز الوعي بموضوع المقاولة وحقوق الإنسان من خلال تنظيم لقاءات وطنية وجهوية بمشاركة الأطراف المعنية. ", null, null, "برامج داعمة للنهوض بمجال المقاولة وحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 208, "208", 2, 2, 3, 32, 13, 1, " النهوض بثقافة حماية البيئة عبر التربية والتكوين والتكوين المستمر والتحسيس.", null, null, "برامج داعمة للنهوض بالثقافة البيئية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 190, "190", 2, 2, 1, 32, 13, 1, " النظر في تجميع القوانين القطاعية ذات الصلة بالبيئة في إطار مدونة واضحة ومحينة لأجل تعزيز الانسجام بينها وتسهيل الولوج إلى مضامينها من طرف الهيئات التي تسهر على تطبيقها ومن طرف المواطنات والمواطنين.", null, null, "مصنفات مساهمة في الولوج إلى القوانين ذات الصلة بالبيئة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 183, "183", 2, 1, 3, 32, 12, 1, " وضع برامج تدريب وتكوين المنشطين في ميدان المصاحبة الاجتماعية للمشاريع السكنية. ", null, null, "موارد بشرية مؤهلة، داعمة للمصاحبة الاجتماعية  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 169, "169", 2, 2, 1, 32, 12, 2, " تفعيل القانون للحد من التجاوزات في ميدان التعمير والإسكان وزجر المخالفات وضمان سلامة البناء في الوسطين الحضري والقروي.", null, null, "منظومة قانونية داعمة للحد من التجاوزات في ميدان التعمير والإسكان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 127, "127", 2, 2, 1, 32, 10, 2, " الإسراع بالمصادقة على مشروع القانون المتعلق بمكافحة الاضطرابات العقلية وبحماية حقوق الأشخاص المصابين بها.", null, null, "إطار قانوني داعم لحماية الأشخاص المصابين بالاضطرابات العقلية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 96, "96", 2, 1, 1, 32, 9, 1, "  إرساء استراتيجية ثقافية وطنية", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 92, "92", 2, 2, 1, 32, 8, 1, "  تفعيل مجالس التدبير وتعزيز أدوارها باعتبارها أداة لتحقيق تدبير تشاركي للشأن التعليمي", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 83, "83", 1, 2, 1, 32, 8, 2, "تفعيل مقتضيات القانون رقم 00-04 المتعلق بإلزامية التعليم.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 53, "53", 1, 1, 1, 32, 5, 2, "العمل على تأمين تغذية الأشخاص الموضوعين رهن الحراسة النظرية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 363, "363", 4, 2, 1, 31, 21, 1, "الإسراع باعتماد قانون جديد منظم للسجون بما يضمن أنسنة المؤسسات السجنية وتحسين ظروف إقامة النزلاء وتغذيتهم وحماية باقي حقوقهم.", null, null, "إطار قانوني داعم لأنسنة المؤسسات السجنية  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 323, "323", 3, 1, 1, 33, 18, 2, " تسهيل الولوج لإعادة تأهيل الأشخاص في وضعية إعاقة من خلال إحداث وتجهيز مراكز الترويض في مختلف الجهات والنهوض بأنظمة التكوين الطبي وشبه الطبي مصادق عليها ومستجيبة لمجموع الحاجيات.", null, null, "بنيات داعمة لإعادة تأهيل الأشخاص في وضعية إعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 367, "367", 4, 2, 1, 33, 21, 1, "مواصلة الحوار المجتمعي حول تعديل المادة 53 من مدونة الأسرة لأجل كفالة الحماية الفعلية للزوج أو الزوجة من طرف النيابة العامة عند الإرجاع إلى بيت الزوجية.", null, null, "حوار مجتمعي منظم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 405, "405", 4, 2, 1, 33, 23, 1, " تعزيز الأخلاقيات المهنية في الممارسة الإعلامية.", null, null, "بيئة داعمة لممارسة إعلامية وفق الضوابط المهنية  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 443, "Code : {id - 1}", 4, 1, 3, 35, 4, 1, "443 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 443", "بعد الأهداف الخاصة : 443", "بعد النتائج المرتقبة : 443" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 459, "Code : {id - 1}", 3, 2, 3, 42, 26, 3, "459 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 459", "بعد الأهداف الخاصة : 459", "بعد النتائج المرتقبة : 459" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 454, "Code : {id - 1}", 2, 1, 3, 42, 17, 2, "454 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 454", "بعد الأهداف الخاصة : 454", "بعد النتائج المرتقبة : 454" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 452, "Code : {id - 1}", 2, 1, 3, 42, 4, 3, "452 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 452", "بعد الأهداف الخاصة : 452", "بعد النتائج المرتقبة : 452" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 445, "Code : {id - 1}", 3, 3, 2, 42, 14, 1, "445 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 445", "بعد الأهداف الخاصة : 445", "بعد النتائج المرتقبة : 445" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 485, "Code : {id - 1}", 1, 1, 3, 41, 15, 2, "485 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 485", "بعد الأهداف الخاصة : 485", "بعد النتائج المرتقبة : 485" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 477, "Code : {id - 1}", 4, 1, 3, 41, 9, 1, "477 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 477", "بعد الأهداف الخاصة : 477", "بعد النتائج المرتقبة : 477" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 469, "Code : {id - 1}", 3, 2, 1, 41, 18, 3, "469 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 469", "بعد الأهداف الخاصة : 469", "بعد النتائج المرتقبة : 469" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 463, "Code : {id - 1}", 4, 3, 1, 41, 24, 2, "463 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 463", "بعد الأهداف الخاصة : 463", "بعد النتائج المرتقبة : 463" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 460, "Code : {id - 1}", 4, 1, 3, 41, 19, 2, "460 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 460", "بعد الأهداف الخاصة : 460", "بعد النتائج المرتقبة : 460" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 442, "Code : {id - 1}", 3, 1, 3, 41, 14, 2, "442 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 442", "بعد الأهداف الخاصة : 442", "بعد النتائج المرتقبة : 442" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 436, "Code : {id - 1}", 3, 2, 2, 41, 23, 3, "436 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 436", "بعد الأهداف الخاصة : 436", "بعد النتائج المرتقبة : 436" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 437, "Code : {id - 1}", 4, 3, 3, 39, 23, 3, "437 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 437", "بعد الأهداف الخاصة : 437", "بعد النتائج المرتقبة : 437" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 484, "Code : {id - 1}", 4, 1, 2, 38, 16, 2, "484 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 484", "بعد الأهداف الخاصة : 484", "بعد النتائج المرتقبة : 484" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 470, "Code : {id - 1}", 3, 3, 3, 38, 15, 2, "470 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 470", "بعد الأهداف الخاصة : 470", "بعد النتائج المرتقبة : 470" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 438, "Code : {id - 1}", 2, 2, 3, 43, 25, 3, "438 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 438", "بعد الأهداف الخاصة : 438", "بعد النتائج المرتقبة : 438" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 467, "Code : {id - 1}", 3, 1, 2, 38, 24, 1, "467 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 467", "بعد الأهداف الخاصة : 467", "بعد النتائج المرتقبة : 467" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 440, "Code : {id - 1}", 4, 1, 2, 38, 19, 1, "440 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 440", "بعد الأهداف الخاصة : 440", "بعد النتائج المرتقبة : 440" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 473, "Code : {id - 1}", 3, 3, 1, 37, 21, 2, "473 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 473", "بعد الأهداف الخاصة : 473", "بعد النتائج المرتقبة : 473" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 448, "Code : {id - 1}", 1, 1, 3, 37, 14, 1, "448 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 448", "بعد الأهداف الخاصة : 448", "بعد النتائج المرتقبة : 448" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 447, "Code : {id - 1}", 1, 2, 1, 37, 15, 1, "447 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 447", "بعد الأهداف الخاصة : 447", "بعد النتائج المرتقبة : 447" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 441, "Code : {id - 1}", 3, 2, 3, 37, 16, 1, "441 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 441", "بعد الأهداف الخاصة : 441", "بعد النتائج المرتقبة : 441" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 471, "Code : {id - 1}", 2, 1, 1, 36, 4, 2, "471 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 471", "بعد الأهداف الخاصة : 471", "بعد النتائج المرتقبة : 471" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 462, "Code : {id - 1}", 4, 3, 1, 36, 25, 1, "462 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 462", "بعد الأهداف الخاصة : 462", "بعد النتائج المرتقبة : 462" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 458, "Code : {id - 1}", 4, 2, 2, 36, 9, 2, "458 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 458", "بعد الأهداف الخاصة : 458", "بعد النتائج المرتقبة : 458" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 439, "Code : {id - 1}", 2, 3, 1, 36, 6, 3, "439 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 439", "بعد الأهداف الخاصة : 439", "بعد النتائج المرتقبة : 439" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 478, "Code : {id - 1}", 4, 1, 2, 35, 24, 2, "478 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 478", "بعد الأهداف الخاصة : 478", "بعد النتائج المرتقبة : 478" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 475, "Code : {id - 1}", 1, 1, 3, 35, 19, 1, "475 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 475", "بعد الأهداف الخاصة : 475", "بعد النتائج المرتقبة : 475" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 474, "Code : {id - 1}", 1, 1, 1, 35, 17, 1, "474 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 474", "بعد الأهداف الخاصة : 474", "بعد النتائج المرتقبة : 474" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 456, "Code : {id - 1}", 4, 2, 2, 35, 9, 2, "456 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 456", "بعد الأهداف الخاصة : 456", "بعد النتائج المرتقبة : 456" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 446, "Code : {id - 1}", 1, 3, 2, 35, 10, 3, "446 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 446", "بعد الأهداف الخاصة : 446", "بعد النتائج المرتقبة : 446" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 453, "Code : {id - 1}", 2, 1, 1, 38, 11, 2, "453 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 453", "بعد الأهداف الخاصة : 453", "بعد النتائج المرتقبة : 453" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 532, "Code : {id - 1}", 1, 2, 3, 50, 9, 3, "532 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 532", "بعد الأهداف الخاصة : 532", "بعد النتائج المرتقبة : 532" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 426, "426", 4, 1, 1, 21, 26, 2, "  تسهيل ولوج المتقاضين إلى المحاكم وتيسير التواصل اللغوي في عملها.", null, null, "آليات داعمة لتيسير الولوج لخدمات العدالة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 269, "269", 3, 2, 1, 21, 16, 1, "تفعيل ميثاق السياحة المستدامة من أجل وضع برامج وقائية لحماية الأطفال من الأشخاص الذين يستغلون السياحة لأسباب جنسية.", null, null, "آليات داعمة لحماية الأطفال من الاستغلال الجنسي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 185, "185", 2, 1, 1, 8, 13, 1, " مراجعة النصوص التشريعية والتنظيمية مع المعايير ذات الصلة بالجودة البيئية الجاري بها العمل لاسيما التشريع المتعلق بالماء والطاقات المتجددة والتنوع البيولوجي ومحاربة تلوث الهواء والتغييرات المناخية وتدبير وتثمين النفايات والتقييم البيئي واستصلاح البيئة ووضع تدابير لردع وزجر المخالفات البيئية. ", null, null, "إطار قانوني متلائم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 123, "123", 2, 2, 1, 8, 9, 1, "تمكين الشباب من المساهمة الفاعلة في تدبير الحياة الثقافية والتحفيز على الولوج إليها", null, null, "مناخ داعم لمبادرات الشباب في المجال الثقافي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 119, "119", 2, 2, 1, 8, 9, 1, " إحداث متاحف موضوعاتية جهوية تبرز تراث كل منطقة وخصوصياتها الثقافية والفنية.", null, null, "بنيات حاضنة للتنوع الثقافي والتراثي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 111, "111", 2, 2, 1, 8, 9, 1, "مواصلة تثمين الرموز الوطنية المغربية من خلال إطلاق أسمائها على المؤسسات والشوارع والساحات العمومية حفظا لها في ذاكرة الأجيال.", null, null, "فضاءات ومؤسسات عامة مساعدة على حفظ الذاكرة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 103, "103", 2, 1, 1, 8, 9, 2, "الإدماج العرضاني للحقوق اللغوية والثقافية الأمازيغية في برامج التربية والتكوين وفي المحيط المدرسي والجامعي", null, null, "بيئة تربوية مساعدة على إدماج الحقوق اللغوية والثقافية الأمازيغية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 74, "74", 1, 2, 1, 8, 7, 1, "تعزيز المقتضيات القانونية المتعلقة بجبر ضرر ضحايا انتهاكات حقوق الإنسان.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 69, "69", 1, 1, 1, 8, 6, 1, "تيسير حريات الاجتماع والتجمهر والتظاهر السلمي من حيث تحديد الأماكن المخصصة لها والقيام بالوساطة والتفاوض.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 61, "61", 1, 1, 3, 8, 5, 2, " تعزيز برامج تكوين المكلفين بإنفاذ القانون في مجال استعمال القوة وتدبير فضاء الاحتجاج.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 41, "41", 1, 1, 1, 8, 4, 1, " تقوية الحوار العمومي حول منجز مؤسسات الرقابة والحكامة.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 394, "394", 4, 2, 1, 7, 22, 2, "إدماج بعد النوع الاجتماعي في السياسات والميزانيات ووضع آليات للمتابعة والتقييم.", null, null, "آليات داعمة لإدماج بعد النوع في السياسات والميزانيات" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 376, "376", 4, 1, 3, 7, 21, 1, "ترصيد التواصل بين مهنيي ومساعدي العدالة والعمل على مأسسته على نحو أفضل.", null, null, "آلية داعمة للتواصل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 372, "372", 4, 2, 1, 7, 21, 1, " تعزيز دور القضاء الإداري في ترسيخ دولة القانون وتكريس مبدأ سمو القانون واحترام حقوق الإنسان.", null, null, "إطار مؤسساتي معزز للقضاء الإداري" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 347, "347", 3, 2, 1, 7, 20, 1, " وضع اتفاقيات ثنائية مع البلدان الأصلية للمهاجرين المقيمين بالمغرب للتمتع بالحقوق الاجتماعية والاقتصادية والثقافية.", null, null, "اتفاقيات ثنائية مع الدول الأصلية للمهاجرين بالمغرب مبرمة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 344, "344", 3, 2, 1, 7, 20, 2, " مواصلة تحيين الإطار التشريعي والمؤسساتي المتعلق بالهجرة واللجوء.", null, null, "الإطار التشريعي والمؤسساتي المتعلق بالهجرة واللجوء معزز ومحين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 293, "293", 3, 2, 3, 7, 17, 2, "تعزيز مواكبة الشباب ودعمهم في مجالات الادماج الاقتصادي والمهني والاجتماعي.", null, null, "آليات داعمة لقدرات الشباب على الاندماج الاقتصادي والمهني والاجتماعي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 282, "282", 3, 1, 1, 7, 17, 1, "مراجعة القوانين التنظيمية للجماعات الترابية بكيفية تمكن الشباب من المساهمة الفعالة في تدبير الشأن المحلي.", null, null, "إطار قانوني تنظيمي داعم لمساهمة الشباب في تدبير الشأن المحلي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 225, "225", 3, 1, 1, 7, 15, 2, "إدماج العمل التطوعي الاجتماعي في الوسطين التربوي والجامعي.", null, null, "دينامية داعمة لترسيخ العمل التطوعي في الوسطين التربوي والجامعي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 219, "219", 2, 2, 3, 7, 14, 2, "تشجيع التدريس والبحث العلمي في الجامعة ومعاهد التكوين ومراكز البحث العلمي حول المقاولة وحقوق الإنسان", null, null, "برامج داعمة للتدريس والبحث الجامعي حول المقاولة وحقوق الإنسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 217, "217", 2, 1, 3, 7, 14, 2, " تشجيع تبادل التجارب والممارسات الفضلى بين المقاولات في مجال احترام حقوق الإنسان في المقاولة.", null, null, "مبادرات داعمة لترسيخ الممارسات الفضلى في مجال المقاولة وحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 194, "194", 2, 2, 1, 7, 13, 2, " إعداد مخطط وطني في مجال مكافحة التغيرات المناخية ووضع سياسة وطنية لمكافحة الاحتباس الحراري وتعبئة جميع الفاعلين في مجال مكافحة تغير المناخ.", null, null, "مبادرات داعمة لمكافحة التغيرات المناخية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 188, "188", 2, 1, 1, 7, 13, 2, "مراجعة اختصاصات وتنظيم المجلس الوطني للبيئة بهدف وضع الهياكل والمؤسسات والآليات والمساطر اللازمة للحكامة البيئية الجيدة وتحقيق التنمية المستدامة طبقا لمبادئ وأهداف القانون الإطار بمثابة ميثاق وطني للبيئة والتنمية المستدامة. ", null, null, "التأطير القانوني للمجالات البيئية معزز" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 187, "187", 2, 2, 1, 7, 13, 2, " الإسراع بإصدار المرسوم المتعلق بإحداث نظام وطني لجرد الغازات الدفيئة تطبيقا لمقتضيات الاتفاقية الإطارية للأمم المتحدة المتعلق بتغير المناخ.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 87, "87", 1, 1, 1, 7, 8, 2, "   إدماج المقاربة الحقوقية في جميع الأنشطة التربوية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 71, "71", 1, 1, 1, 7, 7, 1, "مواصلة تجريم كل الأفعال التي تمثل انتهاكا جسيما لحقوق الإنسان وفقا لأحكام الدستور.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 59, "59", 1, 2, 3, 7, 5, 2, "إعداد ونشر دلائل ودعائم ديداكتيكية لتوعية وتحسيس المسؤولين وأعوان الأمن بقواعد الحكامة الجيدة على المستوى الأمني واحترام حقوق الإنسان.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 49, "49", 1, 2, 1, 7, 5, 2, "إلزام المنظومة التعميرية والأمنية بنصب كاميرات يكون بإمكانها المساعدة على مكافحة الجريمة وحماية الأشخاص والممتلكات.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 32, "32", 1, 2, 1, 7, 4, 2, " اعتماد المقاربة التشاركية عند إعداد المقترحات المتعلقة بمجالات مكافحة الفساد. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 4, "4", 1, 2, 1, 7, 1, 1, "الإسراع بتفعيل هيئة المناصفة ومكافحة جميع أشكال التمييز. ", null, null, "هيئة المناصفة ومكافحة جميع أشكال التمييز مفعلة." });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 398, "398", 4, 1, 3, 6, 22, 1, "نشر الممارسات الفضلى المتعلقة بتطبيق مدونة الأسرة على مستوى عمل كتابة الضبط ومراكز الاستقبال.", null, null, "دينامية داعمة للتطبيق الناجع لمدونة الأسرة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 270, "270", 3, 1, 1, 8, 16, 2, "إدماج الجماعات الترابية لانشغالات الأطفال في مخططات التنمية المحلية على مستوى التشخيص وتحديد الحاجيات والتخطيط والتنفيذ.", null, null, "مخططات للتنمية المحلية داعمة للنهوض بأوضاع الطفولة  من الاستغلال مطورة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 279, "279", 3, 2, 1, 8, 17, 1, " تفعيل المجلس الاستشاري للشباب والعمل الجمعوي وإصدار النصوص التشريعية والتنظيمية المتعلقة به.", null, null, "المجلس الاستشاري للشباب والعمل الجمعوي مفعل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 315, "315", 3, 1, 1, 8, 18, 2, " إحداث مؤسسات اجتماعية تعنى بإيواء الأشخاص في وضعية إعاقة المتخلى عنهم.", null, null, "بنيات داعمة للتكفل بالأشخاص في وضعية إعاقة المتخلى عنهم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 316, "316", 3, 2, 1, 8, 18, 2, " تقوية موارد وخدمات صندوق دعم التماسك الاجتماعي الموجهة للأشخاص في وضعية إعاقة. ", null, null, "خدمات الصندوق مستجيبة لحاجيات الفئة المستفيدة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 365, "365", 4, 2, 1, 10, 21, 1, "مواصلة الحوار المجتمعي حول الانضمام إلى البروتوكول الاختياري الثاني الملحق بالعهد الدولي الخاص بالحقوق المدنية والسياسية المتعلق بإلغاء عقوبة الاعدام. ", null, null, "حوار مجتمعي منظم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 362, "362", 4, 2, 1, 10, 21, 2, "الإسراع باعتماد مشروعي القانون الجنائي وقانون المسطرة الجنائية.", null, null, "منظومة جنائية معتمدة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 355, "355", 3, 1, 3, 10, 20, 1, " النهوض بإبداعات وابتكارات الباحثين المغاربة المقيمين بالخارج.", null, null, "إبداعات وابتكارات الباحثين المغاربة المقيمين بالخارج مثمنة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 306, "306", 3, 1, 1, 10, 18, 1, "الإسراع بتحديد وإعمال النسبة المائوية للأشخاص في وضعية إعاقة الواجب تشغيلهم في إطار تعاقدي بين الدولة ومقاولات القطاع الخاص.", null, null, " إطار تعاقدي محفز لتشغيل الأشخاص في وضعية إعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 272, "272", 3, 2, 1, 10, 16, 1, "تعزيز إجراءات حماية محيط المؤسسات التعليمية لحماية الأطفال واليافعين من أخطار المخدرات ومروجيها.", null, null, "إجراءات أمنية معززة لحماية     الأطفال واليافعين من أخطار المخدرات ومروجيها" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 256, "256", 3, 1, 1, 10, 16, 2, " تفعيل دورية وزارة الداخلية المتعلقة باختيار الأسماء الشخصية. ", null, null, "آليات ميسرة لإعمال الدورية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 248, "248", 3, 2, 1, 10, 16, 1, " تفعيل منشور رئيس الحكومة حول الحملة الوطنية لتسجيل الأطفال غير المسجلين في الحالة المدنية بشكل دوري ومستمر.", null, null, "آليات داعمة لحماية الأطفال في هويتهم المدنية وحقوقهم الأساسية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 192, "192", 2, 2, 1, 10, 13, 1, " تخصيص تحفيزات مالية وتقنية لدعم المشاريع في مجال البيئة والتنمية المستدامة.", null, null, "موارد مالية مساهمة في دعم المشاريع الصديقة للبيئة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 94, "94", 2, 1, 1, 10, 8, 1, "  تيسير شروط ولوج التعليم العالي وتقوية وتثمين البحث العلمي والرفع من الميزانية المخصصة له", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 425, "425", 4, 1, 1, 9, 26, 1, "  تأهيل الهياكل القضائية والإدارية بما يكرس النجاعة القضائية الضامنة للأجل المعقول. ", null, null, "آليات مؤسساتية داعمة للنجاعة القضائية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 417, "417", 4, 1, 1, 9, 24, 1, " تعزيز تأهيل القصور والقصبات والحفاظ عليها.", null, null, "التراث العمراني مرمم ومحافظ عليه" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 415, "415", 4, 1, 3, 9, 24, 2, " جرد التراث الثقافي وتوثيقه وتصنيفه.", null, null, " تراث ثقافي موثق ومصنف" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 392, "392", 4, 1, 1, 9, 22, 2, " التفعيل الحازم لمقتضيات قانون الاتجار بالبشر المتعلقة بحماية الأطفال والنساء الضحايا.", null, null, "إجراءات داعمة لحماية الأطفال والنساء ضحايا الاتجار بالبشر " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 388, "388", 4, 1, 1, 9, 22, 1, " صيانة الكرامة الإنسانية للمرأة في وسائل الإعلام، ووضع تدابير زجرية في حالة انتهاكها. ", null, null, "إجراءات داعمة لصيانة كرامة المرأة في وسائل الاعلام" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 366, "366", 4, 1, 1, 6, 21, 1, " مواصلة الحوار المجتمعي بشأن المصادقة على النظام الأساسي للمحكمة الجنائية الدولية.", null, null, "حوار مجتمعي منظم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 360, "360", 4, 1, 1, 9, 21, 1, " مواصلة الانضمام والتفاعل مع الأنظمة الدولية والإقليمية لحقوق الإنسان.", null, null, "ممارسة اتفاقية في مجال حقوق الإنسان معززة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 292, "292", 3, 2, 3, 9, 17, 1, " وضع برامج لتعزيز قدرات المتدخلين في السياسة الوطنية المندمجة للشباب.", null, null, "قدرات متطورة لتفعيل السياسة الوطنية المندمجة للشباب" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 251, "251", 3, 1, 1, 9, 16, 1, " مواصلة ودعم الجهود الرامية إلى الحد من تزويج القاصرات. ", null, null, "بيئة مساعدة على الحد من تزويج القاصرات " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 247, "247", 3, 2, 1, 9, 16, 2, "نقل جميع الاختصاصات المخولة للجنة العليا للحالة المدنية في موضوع الأسماء العائلية إلى القضاء.", null, null, "آليات وسبل إعمال الحق في الهوية معززة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 234, "234", 3, 2, 3, 9, 15, 1, " تعزيز قدرات مختلف الفاعلين المعنيين، حكوميين وغير حكوميين، في مجال الحقوق الفئوية.", null, null, "برامج للتكوين والتكوين المستمر داعمة لتعزيز القدرات في مجال الحقوق الفئوية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 223, "223", 3, 1, 1, 9, 15, 2, "مواصلة إدماج ثقافة حقوق الإنسان ذات الصلة بالحقوق الفئوية في برامج المعهد العالي للقضاء والمهن القضائية.", null, null, "قدرات متطورة في مجال التكوين القضائي التخصصي   " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 201, "201", 2, 2, 1, 9, 13, 2, "  الإسراع بتنفيذ المخطط الوطني لتطهير السائل لا سيما بالعالم القروي.", null, null, "مخطط وطني منجز" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 168, "168", 2, 1, 1, 9, 12, 1, " الإسراع بإصدار مشاريع القوانين ذات الصلة بالتعمير وفق منظور يتوخى التنمية البشرية المستدامة ويراعي التنوع المجالي والخصوصيات المحلية والهوية المعمارية لمختلف الأقاليم.", null, null, "منظومة قانونية للتعمير داعمةللتنمية المستدامة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 136, "136", 2, 1, 1, 9, 10, 2, " مواصلة تحسين جودة الخدمات وتوسيع التغطية لتشمل باقي الفئات الأخرى وضمان التوزيع العادل للموارد على كافة التراب الوطني. ", null, null, "برامج داعمة لتعميم وتجويد الخدمات الصحية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 132, "132", 2, 1, 1, 9, 10, 2, "  تأهيل أقسام المستعجلات لتعزيز الخدمات المتعلقة بالحالات الطارئة والخطيرة.", null, null, "برامج داعمة لتعزيز كفاءات القطاع الصحي/ أقسام المستعجلات مؤهلة لتقديم خدمات ذات جودة وتغطي الحاجيات" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 52, "52", 1, 1, 1, 9, 5, 2, "تجهيز أماكن الحرمان من الحرية بوسائل التوثيق السمعية البصرية لتوثيق تصريحات المستجوبين من طرف الشرطة القضائية ووضعها رهن إشارة القضاء.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 3, "3", 1, 1, 1, 9, 1, 2, "الإسراع بإحداث مرصد وطني مستقل يساهم في تحليل تطورات المشاركة السياسية والانتقال الديمقراطي.", null, null, "آلية مؤسساتية مساعدة على تتبع تحليل وفهم تطورات المشاركة السياسية والانتقال الديمقراطي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 413, "413", 4, 2, 1, 8, 24, 1, "وضع النصوص التطبيقية للقانون المنظم لحماية التراث الثقافي.", null, null, "نصوص تنظيمية داعمة لحماية التراث الثقافي." });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 406, "406", 4, 1, 1, 8, 23, 1, " النهوض بمعاهد التكوين في مجال الإعلام.", null, null, "منظومة وطنية للتكوين في مجال الإعلام مستجيبة لحاجيات القطاع من الكفاءات كما وكيفا  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 387, "387", 4, 2, 1, 8, 22, 1, " مواصلة الحوار المجتمعي حول بعض مقتضيات مدونة الأسرة، ويتعلق الأمر بإعادة صياغة المادة 49 بما يضمن استيعاب مفهوم الكد والسعاية ومراجعة المادة 175 بإقرار عدم سقوط الحضانة عن الأم رغم زواجها وتعديل المادتين 236 و238 من أجل كفالة المساواة بين الأب والأم في الولاية على الأبناء.", null, null, "حوار مجتمعي منظم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 327, "327", 3, 2, 3, 9, 18, 1, " تعزيز دور المجتمع المدني في النهوض بحقوق الأشخاص في وضعية إعاقة. ", null, null, "مبادرات مثمنة وداعمة لأدوار المجتمع المدني في مجال النهوض بحقوق الأشخاص في وضعية إعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 2, "2", 1, 2, 1, 11, 1, 2, "الرفع من مستوى مشاركة النساء في المجالس التمثيلية.", null, null, "بيئة داعمة للرفع من مشاركة النساء" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 361, "361", 4, 1, 1, 6, 21, 2, " مواصلة الانخراط في اتفاقيات مجلس أوروبا المفتوحة للبلدان غير الأعضاء.", null, null, "ممارسة اتفاقية في مجال حقوق الإنسان معززة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 307, "307", 3, 1, 1, 6, 18, 2, "وضع برامج لدعم وتشجيع التشغيل الذاتي للأشخاص في وضعية إعاقة.", null, null, "برامج دعم وتشجيع التشغيل الذاتي للأشخاص في وضعية إعاقة مفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 163, "163", 2, 2, 3, 3, 11, 1, "تنظيم دورات تدريبية لفائدة موظفي وأطر وزارة الشغل والأطر النقابية ومناديب المستخدمين وأرباب العمل بغية إشاعة ثقافة حقوق الإنسان في ميدان التشغيل.", null, null, "الرفع من قدرات أطر وزارة الشغل والإدماج المهني والأطر النقابية ومناديب المستخدمين وأرباب العمل في مجال حقوق الانسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 144, "144", 2, 1, 1, 3, 10, 2, " تطوير سبل التعاون والتنسيق بين القطاع العام والخاص بما يؤمن تجويد الخدمات الصحية والولوج العادل والمتكافئ إليها. ", null, null, "شراكات مساهمة في الارتقاء بالمنظومة الصحية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 121, "121", 2, 1, 1, 3, 9, 2, " تشجيع وتثمين الدراسات البحثية في مجال التأصيل للتنوع الثقافي والحفاظ على الذاكرة والثقافة الشعبية وسائر الإبداعات المماثلة.", null, null, "مناخ مشجع على البحث " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 77, "77", 1, 1, 1, 3, 7, 1, "إحالة نتائج البحث المتوصل إليها في إطار الطب الشرعي بخصوص حالات ادعاء التعذيب على النيابة العامة للتقرير فيها مالم تكن قد أمرت بها.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 16, "16", 1, 2, 1, 3, 2, 1, "تفعيل مقاربة النوع في كافة المجالس المنتخبة وطنيا وجهويا ومحليا.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 421, "421", 4, 1, 3, 4, 25, 1, "تحسيس وتعبئة الخواص الذين بحوزتهم أرشيفات تراثية لإيداعها لدى مؤسسة أرشيف المغرب.", null, null, "دينامية مشجعة على تفاعل الخواص" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 383, "383", 4, 1, 1, 4, 22, 2, "الإسراع بإصدار القانون المتعلق بمحاربة العنف ضد النساء.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 334, "334", 3, 2, 1, 4, 19, 2, " تشجيع كل المبادرات العمومية والجمعوية الداعمة والحاضنة لرفاه الأشخاص المسنين ومشاركتهم.", null, null, "مبادرات عمومية داعمة لرفاه الأشخاص المسنين ومشاركتهم " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 186, "186", 2, 1, 1, 4, 13, 2, " الإسراع بإصدار القانون المتعلق بالحصول على الموارد الجينية والتقاسم العادل والمنصف للمنافع الناشئة عن استخدامها إعمالا للاتفاقية المتعلقة بالتنوع البيولوجي وبروتوكول ناغويا.", null, null, "إطار قانوني معتمد وفق المعايير الدولية ذات الصلة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 105, "105", 2, 2, 1, 4, 9, 2, "استثمار وحفظ الرصيد الحضاري العبري المغربي في إغناء التنوع الثقافي والتطور المجتمعي", null, null, "مبادرات داعمة للتنوع الثقافي والتطور الاجتماعي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 91, "91", 2, 2, 1, 4, 8, 1, "  إيجاد آليات إدارية تحفز المدرسين على المشاركة الفعالة في المشاريع المدرسية والتربوية وتسمح بتوسيع مشاركة التلاميذ فيها", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 46, "46", 1, 1, 1, 4, 5, 1, "مراجعة المقتضيات القانونية بما يضمن إلزامية إجراء الخبرة الطبية في حالة ادعاء التعرض للتعذيب واعتبار المحاضر المنجزة باطلة في حالة رفض إجراءها بعد طلبها من طرف المتهم أو دفاعه. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 287, "287", 3, 2, 1, 2, 17, 1, " دعم الجمعيات التي تعنى بالشباب وبالترافع عن قضاياهم.", null, null, " قدرات متطورة في مجال الترافع " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 253, "253", 3, 1, 1, 2, 16, 1, " العمل على ضمان المساواة بين الرجل والمرأة في التمتع بالجنسية المغربية إعمالا للمصلحة الفضلى للطفل.", null, null, "إطار قانوني ضامن للمصلحة الفضلى للأطفال والأسرة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 209, "209", 2, 2, 3, 2, 13, 2, " تعزيز برامج دعم القدرات في مجال البيئة والتنمية المستدامة.", null, null, "برامج مساعدة على رفع القدرات في مجال البيئة والتنمية المستدامة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 51, "51", 1, 1, 1, 2, 5, 2, "-51-التوثيق السمعي البصري للتدخلات الأمنية لفض التجمعات العمومية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 40, "40", 1, 2, 1, 2, 4, 2, " وضع معايير مرجعية قابلة للتتبع وقياس مظاهر الفساد.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 37, "37", 1, 2, 1, 2, 4, 2, " تقوية الآليات المكلفة بتعزيز النزاهة والشفافية بالخبرة المطلوبة والدعم الفني اللازم.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 24, "24", 1, 2, 1, 2, 3, 2, " مواصلة دعم الجهات بمناسبة وضع التصاميم الجهوية المقترحة لإعداد التراب.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 403, "403", 4, 2, 1, 1, 23, 1, "إصدار القرار الخاص بتحديد كيفيات سير وتنظيم مراحل انتخاب أعضاء المجلس الوطني للصحافة.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 356, "356", 3, 1, 3, 1, 20, 1, " تعميم ونشر التقارير الوطنية عن الهجرة وبأوضاع المهاجرين.", null, null, "التقارير الوطنية عن الهجرة وأوضاع المهاجرين معممة ومنشورة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 354, "354", 3, 1, 3, 1, 20, 1, " تقوية نقط التواصل بالسفارات والقنصليات وتيسير الخدمات لفائدة المغاربة المقيمين بالخارج.", null, null, "الخدمات المقدمة من طرف نقط التواصل بالسفارات والقنصليات ميسرة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 329, "329", 3, 2, 1, 1, 19, 2, " إحداث نظام أساسي لمهن المساعدة الاجتماعية لرعاية المسنين.", null, null, "مهن المساعدة الاجتماعية مقننة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 283, "283", 3, 2, 1, 1, 17, 1, "تقوية آليات التنسيق عبر القطاعية الخاصة بالشباب.", null, null, "سياسة وطنية للشباب معتمدة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 264, "264", 3, 2, 1, 1, 16, 1, " دعم عمل اللجنة بين الوزارية المكلفة بتتبع السياسات والبرامج في مجال النهوض بحقوق الطفل وحمايتها.", null, null, "آلية مؤسساتية داعمة لتنفيذ السياسات والبرامج في مجال النهوض بحقوق الطفل وحمايتها " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 245, "245", 3, 2, 1, 1, 16, 1, " وضع مؤشرات التتبع والتقييم في مجال حماية الأطفال من سوء المعاملة ومن كل أشكال الاستغلال والعنف.", null, null, " منظومة المؤشرات الخاصة بتتبع وضعية حماية الأطفال وتقييمها معتمدة ومفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 202, "202", 2, 1, 1, 1, 13, 1, " تعزيز آليات التنسيق بين القطاعات المعنية بالبيئة والتنمية المستدامة.", null, null, "آليات مؤسساتية داعمة لتنسيق تنفيذ برامج التنمية المستدامة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 172, "172", 2, 2, 1, 1, 12, 2, " الإسراع باعتماد المرسوم المتعلق بتحديد النفوذ الترابي للوكالات الحضرية، طبقا للتقسيم الترابي الجديد.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 55, "55", 1, 1, 1, 1, 5, 2, "تقوية أداء المؤسسة البرلمانية في مجال التقصي حول انتهاكات حقوق الإنسان مع إخضاع الأجهزة الأمنية للرقابة البرلمانية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 178, "178", 2, 2, 1, 3, 12, 2, " جعل التدابير الجبائية التحفيزية لفائدة المنعشين العقاريين المنخرطين في إنجاز مشاريع السكن الاجتماعي تتلاءم وتوفير العرض السكني اللائق لمختلف فئات المجتمع.", null, null, "تدابير تحفيزية داعمة لتكثيف العرض السكني" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 179, "179", 2, 2, 1, 3, 12, 2, " تضمين دفاتر التحملات للمعايير الدنيا المطبقة على السكن الاجتماعي المحددة بصفة قانونية أو تنظيمية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 221, "221", 3, 1, 1, 3, 15, 2, " تكثيف البرامج التي تستهدف الفئات الهشة خاصة في وضعية التشرد، وضمان خدمات المواكبة والاستماع والتكفل والادماج الاقتصادي والاجتماعي والأسري.", null, null, "برامج داعمة للفئات الهشة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 290, "290", 3, 1, 3, 3, 17, 2, " تعزيز دور الشباب في الحوارات الوطنية والجهوية المتعلقة بتدبير الشأن العام والنهوض بأوضاعهم.", null, null, "برامج داعمة لمشاركة الشباب في تدبير الشأن العام وتقييم السياسات العمومية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 235, "235", 3, 1, 3, 6, 15, 2, " تأهيل وتعزيز قدرات جمعية الهلال الأحمر المغربي والجمعيات الوطنية الأخرى المعنية بالفئات الاجتماعية في وضعية هشاشة.", null, null, "برنامج داعم لقدرات جمعيات المجتمع المدني" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 182, "182", 2, 2, 3, 6, 12, 1, "إعداد مواد مرجعية بيداغوجية حول ثقافة حقوق الإنسان وقيمتها الدستورية موجهة لطلبة الدراسات العليا في مجال الهندسة المعمارية.", null, null, "آليات داعمة لإدماج ثقافة حقوق الإنسان في منهاج التكوين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 122, "122", 2, 1, 1, 6, 9, 2, "تشجيع إحداث محطات إعلامية جهوية", null, null, "محطات جهوية متفاعلة مع محيطها" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 114, "114", 2, 1, 1, 6, 9, 1, "تشجيع مبادرات الشباب والمجتمع المدني فيما يخص التربية الثقافية والإنتاج الثقافي ودعم المشاريع المحفزة على الإبداع", null, null, "مناخ داعم لمبادرات الشباب في المجال الثقافي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 14, "14", 1, 1, 1, 6, 2, 1, " تفعيل مقتضيات القانون التنظيمي لقانون المالية المتعلق بالإدماج العرضاني لمقاربة النوع في السياسات العمومية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 13, "13", 1, 1, 3, 6, 1, 2, " وضع برامج تكوينية على المواطنة وحقوق الإنسان وسيادة القانون لفائدة المنتخبين وموظفي الجماعات الترابية والمجتمع المدني.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 435, "435", 4, 1, 3, 5, 26, 2, " وضع برامج للتكوين المستمر وتبادل الخبرات والممارسات الفضلى بشأن إدماج حقوق الإنسان في الاجتهاد القضائي، تفاعلا مع التزامات المغرب في مجال حقوق الإنسان وأحكام الدستور.", null, null, "آليات داعمة لاستحضار بعد حقوق الإنسان في الاحكام القضائية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 430, "430", 4, 1, 1, 5, 26, 2, " وضع سياسة فعالة تضمن تنفيذ الأحكام الصادرة ضد كافة مؤسسات الدولة والخواص.", null, null, "سياسة داعمة لتنفيذ الاحكام القضائية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 401, "401", 4, 2, 3, 5, 22, 2, "مواصلة برامج التدريب وتطوير القدرات في مجال التكوين والتكوين المستمر على حقوق النساء لفائدة القضاة ومساعدي العدالة.", null, null, "برامج مساعدة على تقوية القدرات في مجال حقوق النساء" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 357, "357", 3, 1, 3, 5, 20, 2, " تعزيز البرامج الإعلامية الموجهة إلى المهاجرين.", null, null, "بيئة إعلامية داعمة لحقوق المهاجرين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 350, "350", 3, 1, 1, 5, 20, 2, " وضع آلية وطنية للرصد ومتابعة تطور الهجرة من وإلى المغرب وقياس آثارها المجتمعية والاقتصادية والثقافية.", null, null, "مرصد متخصص في متابعة تطور الهجرة محدث" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 325, "325", 3, 2, 3, 5, 18, 2, "تمكين الأشخاص في وضعية إعاقة من خدمات الإعلام والتواصل عن طريق إدماج لغة الإشارة في البرامج الإعلامية.", null, null, "بيئة داعمة لولوج   الأشخاص في وضعية إعاقة للخدمات الإعلامية  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 303, "303", 3, 2, 1, 5, 18, 1, " إدماج التربية على الاختلاف في المناهج المدرسية للمساهمة في تغيير المواقف والتمثلات في أوساط الأطفال والشباب.", null, null, "كتب مدرسية معززة للتعايش وقبول الاختلاف" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 262, "262", 3, 1, 1, 5, 16, 1, " الرفع من مستوى آليات تتبع أوضاع الأطفال المتكفل بهم.", null, null, "آليات داعمة لحماية حقوق الأطفال في وضعية كفالة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 333, "333", 3, 2, 1, 6, 19, 2, " دعم وتشجيع مبادرات المجتمع المدني والقطاع الخاص لإحداث نوادي وفضاءات الترفيه الموجهة للأشخاص المسنين.", null, null, "دينامية داعمة لمبادرات المجتمع المدني والقطاع الخاص في مجال الترفيه لفائدة الأشخاص المسنين " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 259, "259", 3, 1, 1, 5, 16, 1, " اعتماد معايير الجودة في خدمات التكفل بمؤسسات الرعاية الاجتماعية للأطفال.", null, null, "توفر مؤسسات الرعاية الاجتماعية على خدمات ذات جودة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 176, "176", 2, 1, 1, 5, 12, 2, " مضاعفة الإمكانيات المالية لصناديق الضمان الموجهة للشرائح الاجتماعية ذات الدخل المحدود والضعيف وغير القار لتمكينها من ولوج القروض السكنية في ظروف ملائمة.", null, null, "آلية مالية داعمة لتمكين الشرائح الاجتماعية ذات الدخل المحدود والضعيف والقار من ولوج السكن" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 150, "150", 2, 1, 1, 5, 11, 2, " النظر في المصادقة على اتفاقية منظمة العمل الدولية رقم 118 التي تهم المساواة في معاملة مواطني البلد والذين ليسوا من مواطني البلد في مجال الضمان الاجتماعي.", null, null, "بلورة تصور " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 145, "145", 2, 1, 1, 5, 10, 1, " تشجيع وتحفيز طلبة الطب على التخصص في الطب الشرعي والطب النفسي والوظيفي وتوفير المناصب المالية اللازمة.", null, null, "تحفيزات مساعدة على تقليص الخصاص" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 126, "126", 2, 1, 3, 5, 9, 1, "وضع برامج متخصصة بمساعدة المختصين في المهن الثقافية للنهوض بقدرات المنظمات غير الحكومية والجماعات الترابية وسائر المؤسسات العاملة في مجال الحقوق الثقافية", null, null, "برامج داعمة لقدرات مختلف الفاعلين في مجال الحقوق الثقافية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 113, "113", 2, 1, 1, 5, 9, 1, "إحداث فضاءات للحوار والتشاور الدائمين بين منظمات المجتمع المدني والشباب على صعيد الجماعات الترابية فيما يخص الإنتاج الثقافي والأنشطة الداعمة للحياة الثقافية", null, null, "جماعات ترابية داعمة لمبادرات الشباب والمجتمع المدني في المجال الثقافي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 102, "102", 2, 1, 1, 5, 9, 1, "تعزيز مكانة اللغة والثقافة الأمازيغية في المجالات الثقافية والإدارية والقضائية وباقي مناحي الحياة العامة.", null, null, "ديناميات داعمة لتعزيز مكانة اللغة والثقافة الأمازيغية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 79, "79", 1, 1, 1, 5, 7, 1, " تشجيع إمكانيات التظلم الإداري والقضائي صونا لمبدأ عدم الإفلات من العقاب وضمانا لوصول الضحايا إلى سبل الانتصاف المناسبة.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 76, "76", 1, 1, 1, 5, 7, 2, " وضع إطار تشريعي وتنظيمي مستقل لمأسسة الطب الشرعي.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 47, "47", 1, 1, 1, 5, 5, 1, "الإسراع بإصدار قانون يتعلق بالتحقق من هوية الأشخاص بواسطة البصمات الجينية. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 36, "36", 1, 1, 1, 5, 4, 2, "تعزيز المشاريع والإجراءات الرامية إلى مكافحة الفساد وتعزيز الحكامة الإدارية والنزاهة والشفافية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 418, "418", 4, 2, 1, 3, 25, 1, " مراجعة قانون الأرشيف طبقا للممارسات الفضلى المعمول بها في هذا المجال مع استكمال إصدار المراسيم التطبيقية لقانون الأرشيف.", null, null, "إطار قانوني داعم لثقافة الأرشيف " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 408, "408", 4, 2, 1, 3, 23, 1, "تقوية المقتضيات القانونية المتعلقة بالاعتداء على الملكية الفكرية لتتلاءم مع الدستور.", null, null, "مقتضيات قانونية داعمة لحماية الملكية الفكرية  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 391, "391", 4, 1, 1, 3, 22, 1, " إدماج مقاربة النوع الاجتماعي في البرامج الاقتصادية الداعمة لإحداث المقاولات.", null, null, "آليات كفيلة بإدماج مقاربة النوع" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 342, "342", 3, 2, 3, 3, 19, 1, "تعزيز العمل المؤسسي للجمعيات التي تعنى بأوضاع الأشخاص المسنين", null, null, "العمل الجمعوي معزز في مجال النهوض بأوضاع الأشخاص المسنين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 229, "229", 3, 2, 1, 5, 15, 2, " وضع الجماعات الترابية لبرامج في مجال الحقوق الفئوية.", null, null, "برامج داعمة للنهوض بالحقوق الفئوية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 328, "328", 3, 2, 1, 21, 19, 2, " وضع إطار استراتيجي للنهوض بحقوق الأشخاص المسنين وحمايتها.", null, null, "إطار استراتيجي معد ومعتمد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 8, "8", 1, 2, 3, 11, 1, 1, "إطلاق برامج تواصلية لتعزيز الديمقراطية التشاركية.", null, null, "بيئة داعمة ومحفزة للديمقراطية التشاركية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 43, "43", 1, 2, 3, 11, 4, 1, "توثيق ونشر الممارسات الفضلى في مجال مكافحة للفساد.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 72, "72", 1, 2, 1, 19, 7, 1, "تكريس مبدأ عدم الإفلات من العقاب في السياسة الجنائية وفي سائر التدابير العمومية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 48, "48", 1, 1, 1, 19, 5, 2, "استحضار البعد الأمني في وضع خطط التهيئة الحضرية وتصميم التجمعات السكنية الجديدة والأحياء بضواحي المدن بشكل يضمن أمن المواطنات والمواطنين.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 44, "44", 1, 2, 3, 19, 4, 2, "وضع برامج للتدريب والتكوين والتكوين المستمر لفائدة مختلف الفاعلين والمتدخلين في مجالات مكافحة الفساد وتعزيز النزاهة والشفافية وإشاعة أخلاقياتها.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 416, "416", 4, 1, 1, 18, 24, 1, "تأهيل آليات الحفاظ على التراث الثقافي المغربي بكل مكوناته وأبعاده المادية والرمزية والمحافظة عليها.", null, null, "آليات الحفاظ على التراث الثقافي المغربي مؤهلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 377, "377", 4, 1, 3, 18, 21, 1, "وضع برامج للتدريب والتكوين المستمر على سيادة القانون واحترام حقوق الإنسان تتأسس على الدستور والرصيد الثري للاجتهاد القضائي المغربي والممارسات الفضلى ذات الصلة لفائدة مكونات العدالة ومساعديها.", null, null, "برامج للتكوين داعمة لتمكين الجهاز القضائي من ثقافة حقوق الانسان  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 346, "346", 3, 2, 1, 18, 20, 1, " مواصلة تطوير الاتفاقيات الخاصة بالحماية الاجتماعية المبرمة بين المغرب ودول الاستقبال وفق مقاربة حقوق الإنسان.", null, null, "الإطار الاتفاقي الثنائي في مجال الحماية الاجتماعية معزز وفق مقاربة حقوق الانسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 299, "299", 3, 2, 1, 18, 18, 1, " الإسراع بإحداث الآلية الوطنية لحماية حقوق الأشخاص في وضعية إعاقة وفقا لمقتضيات اتفاقية حقوق الأشخاص ذوي الإعاقة.", null, null, "الآلية الوطنية لحماية حقوق الأشخاص في وضعية إعاقة مفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 257, "257", 3, 2, 1, 18, 16, 2, "مواصلة الجهود الرامية إلى الحد من ظاهرة تشغيل الأطفال.", null, null, "الجهود الرامية إلى الحد من ظاهرة تشغيل الأطفال متواصلة ومعززة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 58, "58", 1, 1, 3, 18, 5, 1, "تقوية بنيات ووسائل وقنوات التواصل بين المؤسسات الأمنية والمواطنين (حسن الاستقبال والتوجيه وتقديم الإرشادات).", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 404, "404", 4, 2, 1, 17, 23, 2, " الإسراع بوضع ميثاق أخلاقيات مهنة الصحافة والإعلام بما في ذلك الصحافة الإلكترونية.", null, null, "ميثاق أخلاقيات مهنة الصحافة والإعلام معتمد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 375, "375", 4, 2, 3, 17, 21, 1, "توثيق ونشر الأعمال البحثية المعززة لرصيد ثقافة حقوق الإنسان المنجزة بمناسبة الآراء والأعمال الاستشارية من قبل مؤسسات الديمقراطية التشاركية.", null, null, "برامج معززة لرصيد ثقافة حقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 374, "374", 4, 1, 3, 17, 21, 2, " وضع برنامج خاص بجمع وتصنيف وتقديم ونشر الاجتهادات القضائية الجنائية والإدارية المعززة لإعمال المعايير الدولية لحقوق الإنسان.", null, null, "منظومة داعمة لتثمين الاجتهادات القضائية واستثمارها" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 369, "369", 4, 1, 1, 17, 21, 1, "إحداث بنك وطني للبصمات الجينية.", null, null, "آلية داعمة للنجاعة الأمنية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 348, "348", 3, 1, 1, 17, 20, 2, "ضمان حماية النساء المغربيات المهاجرات وتعزيز الجهود الحكومية ذات الصلة.", null, null, "آلية لتعزيز حماية النساء المغربيات المهاجرات محدثة ومفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 337, "337", 3, 1, 1, 17, 19, 2, "دعم الأسر التي تحتضن أفرادا مسنين في وضعية صعبة.", null, null, "إطار داعم لخدمات التكفل بالأفراد المسنين في وضعية صعبة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 291, "291", 3, 1, 3, 17, 17, 1, " وضع قاعدة معلومات خاصة بالشباب. ", null, null, "قاعدة معلومات مساعدة على التخطيط     والبرمجة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 281, "281", 3, 2, 1, 17, 17, 2, "مراجعة القانون التنظيمي للأحزاب بكيفية تمكن الشباب من المساهمة الفعالة في تدبير الشأن الحزبي. ", null, null, "مقتضيات قانونية داعمة للمشاركة السياسية للشباب" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 220, "220", 3, 1, 1, 17, 15, 1, " إصدار القانون المتعلق بشروط فتح وإحداث وتدبير مؤسسات الرعاية الاجتماعية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 171, "171", 2, 1, 1, 17, 12, 2, " إسراع وتيرة إنجاز برامج القضاء على أحياء الصفيح للسعي إلى معالجة وضعيات 50 % من الأسر التي تعيش² في دور الصفيح في أفق 2021.", null, null, "برامج مساهمة في القضاء على أحياء الصفيح  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 157, "157", 2, 2, 1, 17, 11, 2, " تشجيع المشاريع المذرة للدخل.", null, null, "برامج داعمة للمقاولات الصغرى  والمتوسطة / أنشطة داعمة لتحسين الدخل والإدماج الاقتصادي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 88, "88", 1, 1, 1, 17, 8, 1, "  بلورة سياسة لغوية تضمن العدالة اللغوية وتأخذ بعين الاعتبار حاجيات التلاميذ وتراعي الخصوصيات اللغوية والثقافية للأقاليم والجهات", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 399, "399", 4, 1, 3, 16, 22, 1, "توسيع شبكة الفضاءات متعددة الاختصاصات والوظائف الموجهة للنساء وتعزيزها وتقويتها.", null, null, "نسيج مؤسساتي داعم ومنصف للنساء" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 349, "349", 3, 1, 1, 16, 20, 1, "حماية حقوق الأطفال المغاربة المهاجرين غير المرفقين في دول الاستقبال.", null, null, "برامج متخصصة مع جمعيات ومنظمات في مجال حماية حقوق الأطفال مبلورة ومنفذة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 340, "340", 3, 1, 3, 16, 19, 1, "تعزيز البرامج الإعلامية الموجهة للمسنين", null, null, "برامج إعلامية مواكبة لحاجيات المسنين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 305, "305", 3, 1, 1, 16, 18, 2, "النهوض بالحق في الشغل للأشخاص في وضعية إعاقة من خلال تطبيق نسب التوظيف القانونية. ", null, null, "آليات ضامنة لتطبيق النسب القانونية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 297, "297", 3, 2, 1, 16, 18, 2, "ملاءمة التشريع الوطني مع مقتضيات الاتفاقية الدولية للأشخاص في وضعية إعاقة، لا سيما ما يتعلق بالأهلية القانونية.", null, null, "إطار قانوني ملائم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 274, "274", 3, 1, 3, 16, 16, 2, " التحسيس والتوعية بخطورة العقاب البدني والعنف في الوسط التربوي كبيئة آمنة.", null, null, "برامج مساعدة على الحد من العنف في الوسط التربوي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 258, "258", 3, 2, 1, 16, 16, 2, " تشجيع ودعم الأسر التي يوجد أطفالها في وضعية صعبة لتفادي الرعاية المؤسساتية.", null, null, "تراجع ظاهرة إيداع الأطفال بمؤسسات الرعاية الاجتماعية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 227, "227", 3, 2, 1, 16, 15, 1, "تجميع ونشر القوانين والتشريعات المتعلقة بالفئات المعنية والتعريف بمقتضياتها.", null, null, "مصنفات منجزة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 86, "86", 1, 2, 1, 19, 8, 1, "  اعتماد تدابير تحفيزية لتعميم تمدرس الفتيات في جميع المستويات التعليمية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 143, "143", 2, 2, 1, 19, 10, 1, " ضمان التنسيق الفعال بين مختلف الإدارات الصحية على الصعيد الوطني وبين المستشفيات والمراكز الصحية، وإحداث آليات التتبع والمراقبة وتقييم الأداء وجودة الخدمات وفعاليتها.", null, null, ".آليات مساعدة على التنسيق والتتبع والمراقبة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 148, "148", 2, 1, 3, 19, 10, 1, "تعزيز البرامج السمعية البصرية المتعلقة بالحق في الصحة", null, null, "برامج سمعية بصرية داعمة للحق في الصحة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 158, "158", 2, 2, 1, 19, 11, 1, "تعزيز الخدمات الاجتماعية الموجهة إلى العمال والأجراء.", null, null, "ارتفاع عدد المقاولات المحدثة للخدمات الاجتماعية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 193, "193", 2, 2, 1, 21, 13, 1, " تعزيز الجهود الرامية إلى تحسين التقييم الاستراتيجي البيئي.", null, null, "إطار مرجعي وطني للتقييم الاستراتيجي البيئي معزز" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 131, "131", 2, 2, 1, 21, 10, 2, " دعم الموارد البشرية الطبية وشبه الطبية والإدارية ومواصلة تعزيز الكفاءات عن طريق التكوين والتكوين المستمر.", null, null, "برامج داعمة لتعزيز كفاءات القطاع الصحي   " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 130, "130", 2, 2, 1, 21, 10, 1, " مواصلة توفير الموارد البشرية اللازمة من حيث عدد الأطر الطبية وشبه الطبية وتخصصاتها وتأمين توزيعها العادل على المجال الترابي وفق منظور يراعي حاجيات وخصوصيات كل منطقة.", null, null, "مواردبشريةكفيلةبتأمينالحاجياتمنالخدماتالصحية." });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 129, "129", 2, 1, 1, 21, 10, 1, " دعم ولوج الفئات الأكثر هشاشة للخدمات الصحية.", null, null, "برامج داعمة لتعميم الخدمات الصحية." });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 128, "128", 2, 1, 1, 21, 10, 1, "ضمان العدالة المجالية في الميدان الصحي من خلال خريطة صحية عادلة تغطي مكونات التراب الوطني.", null, null, "خريطة صحية داعمة للعدالة المجالية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 67, "67", 1, 1, 1, 21, 6, 2, "كفالة احترام المقتضيات القانونية المتعلقة بوصل إيداع ملفات تأسيس الجمعيات.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 54, "54", 1, 2, 1, 21, 5, 2, "دعم المؤسسات الأمنية بالموارد البشرية والمالية والتقنية اللازمة.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 338, "338", 3, 1, 1, 20, 19, 1, "ضمان التغطية الصحية الإجبارية للأشخاص المسنين غير المستفيدين منها ", null, null, "تغطية صحية شاملة لجميع الأشخاص المسنين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 332, "332", 3, 2, 1, 20, 19, 2, "حث الجماعات الترابية على إدماج احتياجات الأشخاص المسنين في برامج تفعيل مخططات التنمية.", null, null, "مخططات للتنمية المحلية داعمة للنهوض بأوضاع الأشخاص المسنين  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 288, "288", 3, 1, 3, 20, 17, 2, "تقوية مشاركة الشباب في خدمات الإعلام والتواصل. ", null, null, "آليات داعمة لتمكين الشباب من التواصل والولوج إلى المعلومة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 218, "218", 2, 1, 3, 20, 14, 2, "وضع برامج تكوينية في مجال حقوق الإنسان في المقاولة لفائدة كل المتدخلين وأصحاب المصلحة (مسؤولو المقاولة والأطر النقابية والفاعلون المدنيون والقضاة والمحامون ومفتشو الشغل).", null, null, "برامج تكوينية مساعدة على الرفع من مستوى الوعي بحقوق الإنسان في المقاولة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 214, "214", 2, 1, 3, 20, 14, 1, " النهوض بدور المقاولة في مجال تقييم أثر أنشطتها على حقوق الانسان.", null, null, "آليات داعمة للنهوض بحقوق الإنسان داخل المقاولة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 162, "162", 2, 2, 3, 20, 11, 1, "وضع برامج للتوعية والتحسيس بمقتضيات مدونة الشغل لفائدة العمال.", null, null, "برامج داعمةلاحترام مقتضيات مدونة الشغل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 153, "153", 2, 1, 1, 20, 11, 1, " اعتماد المساواة وتكافؤ الفرص في برامج التكوين والتأهيل والإدماج في سوق الشغل.", null, null, "المساواة وتكافؤ الفرص فئويا ومجاليا مفعلة في برامج التكوين والتأهيل والإدماج في سوق الشغل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 224, "224", 3, 1, 1, 16, 15, 2, "إدماج ثقافة حقوق الإنسان ذات الصلة في مؤسسات التكوين الأساسي والمستمر للعاملين في مجال حماية الحقوق الفئوية.", null, null, "إطار مرجعي وبرامج داعمة لإدماج ثقافة حقوق الإنسان في التكوين الأساسي والمستمر  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 142, "142", 2, 1, 1, 20, 10, 2, "تخليق المرفق الصحي وعقلنة طرق تدبير الأدوية والمستلزمات الطبية داخل المستشفيات.", null, null, "آليات مساعدة على التدبير المعقلن وداعمة لتخليق المرفق الصحي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 137, "137", 2, 1, 1, 20, 10, 1, " دعم التحصيل والتحليل الممنهج والشمولي للمعطيات والمعلومات حسب النوع الاجتماعي في مجال الصحة وخصوصا ما تعلق بالأمراض المتنقلة جنسيا والعنف. ", null, null, " نظاممعلوماتي مندمج معد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 73, "73", 1, 2, 1, 20, 7, 1, "تيسير التقاضي للضحايا من خلال توفير المساعدة القانونية والقضائية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 26, "26", 1, 1, 1, 20, 3, 2, "الإسراع بوضع ميثاق اللاتمركز الإداري في إطار تنزيل الجهوية المتقدمة وتكريس الحكامة الترابية", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 20, "20", 1, 1, 1, 20, 3, 2, "-20- تسريع إصدار قانون خاص بإعداد التراب الوطني. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 15, "15", 1, 1, 1, 20, 2, 1, " الإسراع بتفعيل هيئة المناصفة ومكافحة جميع أشكال التمييز كمدخل أساسي من مداخل تقوية قيم المساواة والإنصاف الموجهة للسياسات العمومية والاستراتيجيات والمخططات والبرامج الوطنية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 9, "9", 1, 1, 3, 20, 1, 2, "دعم وتشجيع البرامج والأنشطة المتعلقة بالتنشئة السياسية والاجتماعية الهادفة إلى نشر قيم الديمقراطية والمساواة والتعدد والاختلاف والتسامح والعيش المشترك وعدم التمييز ونبذ الكراهية والعنف والتطرف.", null, null, "مجتمع داعم لقيم الديمقراطية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 400, "400", 4, 1, 3, 19, 22, 1, "محاربة الصور النمطية والتمييزية ضد النساء في وسائل الإعلام وفي البرامج والمقررات المدرسية.", null, null, "بيئة داعمة لمكافحة الصور النمطية والتمييزية ضد النساء" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 390, "390", 4, 2, 1, 19, 22, 1, " مواصلة تفعيل مقتضيات صندوق التكافل العائلي وتبسيط مساطره.", null, null, "مقتضيات داعمة لتوسيع دائرة المستفيدين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 381, "381", 4, 2, 1, 19, 22, 2, " تعزيز الخطة الحكومية للمساواة في أفق المناصفة إكرام 2", null, null, "الإعمال الناجع لخطة إكرام 2" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 317, "317", 3, 1, 1, 19, 18, 1, " وضع نظام جديد لتقييم الإعاقة يتلاءم والمفهوم الطبي والنفسي والاجتماعي المعتمد بموجب الاتفاقية الدولية لحقوق الأشخاص ذوي الإعاقة.", null, null, "نظام جديد لتقييم الإعاقة معتمد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 314, "314", 3, 1, 1, 19, 18, 1, "تقنين وتأهيل خدمات مؤسسات الرعاية الاجتماعية.  ", null, null, "  توفر مؤسسات الرعاية الاجتماعية على خدمات ذات جودة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 271, "271", 3, 2, 1, 19, 16, 2, "تفعيل آليات المراقبة التربوية والبيداغوجية واللوجيستيكية بالأماكن التي تخصص لتعليم وتربية الأطفال.", null, null, "آليات معززة للمراقبة التربوية والبيداغوجية واللوجيستيكية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 250, "250", 3, 2, 1, 19, 16, 1, " تعزيز حقوق الأطفال في المشاركة في إعداد وتتبع تفعيل السياسات والبرامج والمشاريع الوطنية.", null, null, "بيئة مشجعة على مشاركة الأطفال" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 173, "173", 2, 1, 1, 19, 12, 2, " التأهيل الحضري للأحياء غير القانونية لتحسين ظروف السكان القاطنين بها.", null, null, "برامج للتأهيل الحضري داعمة لتحسين ظروف عيش الساكنة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 139, "139", 2, 1, 1, 20, 10, 2, " النهوض بالصحة النفسية والعقلية ومواصلة مأسستها وتعميم خدماتها.", null, null, "بنيات داعمة للنهوض بالصحةالنفسيةوالعقلية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 19, "19", 1, 1, 3, 11, 2, 2, " تعزيز دور وسائل الإعلام في نشر قيم ومبادئ المساواة والمناصفة وتكافؤ الفرص ومحاربة التمييز.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 207, "207", 2, 1, 3, 16, 13, 2, " إدماج البعد البيئي في البرامج والمقررات الدراسية وفي الأنشطة التربوية بالوسط المدرسي.", null, null, "مناهج ومقرراتدراسية معززة للتربية البيئية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 191, "191", 2, 1, 1, 16, 13, 2, " دعم الصندوق الوطني للبيئة والتنمية المستدامة.", null, null, "آلية مساهمة في دعم المشاريع البيئية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 117, "117", 2, 1, 1, 13, 9, 1, " تعميم المكتبات ومراكز التنشيط الثقافي والمسرحي والفني في المناطق التي تفتقر للبنيات التحتية الثقافية.", null, null, "بنيات مشجعة على الحياة الثقافية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 109, "109", 2, 2, 1, 13, 9, 2, "تشجيع إحداث محطات إذاعية تستخدم اللغات المتداولة وتلبي حاجيات المواطنين على مستوى الإعلام والتثقيف والتوعية والترفيه.", null, null, "محطات جهوية متفاعلة مع محيطها" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 85, "85", 1, 1, 1, 13, 8, 1, "--", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 35, "35", 1, 1, 1, 13, 4, 1, " تعزيز الالتقائية بين البرامج والمبادرات الأفقية والقطاعية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 21, "21", 1, 2, 1, 13, 3, 2, "-21- تنفيذ توصيات المجلس الأعلى لإعداد التراب الوطني واللجن المنبثقة عنه.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 6, "6", 1, 1, 3, 13, 1, 1, "  إغناء وإثراء الحوار العمومي الخاص بالمشاركة السياسية من خلال برامج تسهل وتضمن ولوج مختلف الفاعلين (أحزاب سياسية، نقابات، جمعيات...) للخدمات الإعلامية العمومية لتعزيز مساهمتهم في تأطير المواطنات والمواطنين وتطوير التعددية والحكامة السياسية.", null, null, "فضاء سمعي بصري داعم للمشاركة السياسية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 336, "336", 3, 1, 1, 12, 19, 1, " وضع مؤشرات وأنظمة معلوماتية لتتبع أوضاع الأشخاص المسنين لاسيما الموجودين في أوضاع صعبة محليا جهويا ووطنيا.", null, null, "منظومة معلوماتية ومؤشرات للتتبع مبلورة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 310, "310", 3, 2, 1, 12, 18, 2, " اعتماد مقاربة التنمية الدامجة بشكل عرضاني في كل البرامج والسياسات المرتبطة بمجال الإعاقة.", null, null, "مقاربة التنمية الدامجة مفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 233, "233", 3, 2, 3, 12, 15, 2, "تشجيع ودعم المبادرات التحسيسية الهادفة إلى حماية الفئات الاجتماعية في وضعية هشاشة", null, null, "برامج داعمة لحماية الفئات الاجتماعية في وضعية هشاشة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 189, "189", 2, 1, 1, 12, 13, 1, " تغطية المجالات البيئية غير المشمولة بالتشريع البيئي والتنمية المستدامة بغية استكمال التأطير القانوني لمختلف هذه المجالات. ", null, null, "إطار تشريعي معزز" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 154, "154", 2, 1, 1, 12, 11, 1, " تعزيز دور الآليات الاستباقية للتقليص من النزاعات في مجال الشغل.", null, null, "قدرات جهاز تفتيش الشغل في مجال التدخل الإستباقي معززة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 134, "134", 2, 2, 1, 12, 10, 2, " تعزيز مبدأي المساواة وعدم التمييز في التعامل مع المرضى داخل المؤسسات الاستشفائية. ", null, null, "بيئة صحية تكفل الولوج المتساوي للخدمات الصحية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 98, "98", 2, 2, 1, 12, 9, 2, "  الإسراع بإصدار القانون التنظيمي المتعلق بالمجلس الوطني للغات والثقافة المغربية", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 1, "1", 1, 2, 1, 12, 1, 1, "التفعيل الأمثل للقوانين المنظمة للانتخابات الوطنية والمحلية لتقوية النزاهة والحكامة الرشيدة والشفافية", null, null, "بيئة داعمة للنزاهة والشفافية والحكامة الانتخابية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 433, "433", 4, 2, 3, 11, 26, 2, "تأهيل الموارد البشرية لإدارة العدالة وهيئات وجمعيات المهن القانونية من خلال وضع برامج في مجال التكوين والتكوين المستمر وتقويم الأداء.", null, null, "قدرات الموارد البشرية لمنظومة العدالة معززة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 432, "432", 4, 2, 3, 11, 26, 1, "إشاعة ثقافة حقوق الإنسان وتنميتها في أوساط العدالة.", null, null, "شراكات وبرامج داعمة لتملك ثقافة حقوق الإنسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 373, "373", 4, 2, 1, 11, 21, 2, "الإسراع بوضع منظومة مندمجة لمعالجة الشكايات المتعلقة بحقوق المرتفقين.", null, null, "منظومة مندمجة لمعالجة الشكايات مفعلة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 324, "324", 3, 2, 3, 11, 18, 1, "تعزيز دور الإعلام في تطوير حملات للوقاية من الإعاقة وبرامج مكافحة التمييز والوصم تجاه الأشخاص ذوي الإعاقة.", null, null, " إعلام داعم لمكافحة التمييز والوصم تجاه الأشخاص ذوي الإعاقة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 312, "312", 3, 1, 1, 11, 18, 1, " تفعيل المخطط الوطني للصحة والإعاقة.", null, null, "مخطط وطني للصحة والإعاقة      مفعل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 308, "308", 3, 2, 1, 11, 18, 2, "تفعيل وتقوية آليات الإدماج المهني للأشخاص في وضعية إعاقة في أنظمة التكوين المهني والتشغيل الذاتي واستخدام آليات التمييز الإيجابي والنهوض بمراكز العمل المحمية.", null, null, "آليات داعمة للإدماج المهني للأشخاص في وضعية إعاقة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 213, "213", 2, 1, 3, 11, 14, 2, "إدماج بعد احترام حقوق الإنسان في المقاولة على مستوى القانون والممارسة والنهوض بأدوار المقاولة المتعلقة بحقوق الانسان وقيم المواطنة.", null, null, "بيئة داعمة للنهوض بحقوق الإنسان داخل المقاولة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 206, "206", 2, 2, 3, 11, 13, 2, "تنظيم حملات تحسيسية بمتطلبات ترشيد وعقلنة تدبير الموارد الطبيعية وحماية البيئة عبر وسائل الإعلام المكتوبة والمسموعة والمرئية والإلكترونية.", null, null, "برامج إعلامية داعمة لحماية البيئة  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 205, "205", 2, 1, 3, 11, 13, 1, " إعمال مضامين الميثاق الوطني للإعلام والبيئة والتنمية المستدامة.", null, null, "الميثاق الوطني للإعلام والبيئة والتنمية المستدامة مفعل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 196, "196", 2, 2, 1, 11, 13, 1, " تفعيل سياسة القرب في مجال تدبير البيئة وتسريع وتيرة تنفيذها.", null, null, "إطار مؤسساتي داعم لسياسة القرب" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 108, "108", 2, 1, 1, 11, 9, 2, "مراجعة دفاتر تحملات شركات الاتصال السمعي البصري بما يسمح بتعزيز حصة البث بالأمازيغية", null, null, "إطار تنظيمي معزز لحصة البث باللغة الأمازيغية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 97, "97", 2, 2, 1, 11, 9, 1, "  الإسراع بإصدار القانون التنظيمي المتعلق بإعمال الطابع الرسمي للغة الأمازيغية", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 95, "95", 2, 1, 3, 11, 8, 1, "  تقوية قيم التسامح والعيش المشترك واحترام حقوق الإنسان ونبذ الكراهية والعنف والتطرف في المناهج التربوية وفي الفضاء المدرسي.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 65, "65", 1, 2, 1, 11, 6, 1, " تدقيق القواعد والإجراءات القانونية المتعلقة بمختلف أشكال وأصناف التظاهر (الوقفة، التجمع، التظاهر في الشارع العمومي، مسار التظاهرات...) من حيث السير والجولان والتوقيت.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 50, "50", 1, 1, 1, 11, 5, 1, "مراعاة الضرورة والتناسب أثناء استعمال القوة في فض التجمعات العمومية وفي التجمهرات والتظاهرات السلمية. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 180, "180", 2, 2, 2, 13, 12, 2, "وضع سياسة إعلامية تيسر التواصل الموجه في مجال تمتع الفئات الاجتماعية من الحق في السكن اللائق. ", null, null, "برامج إعلامية لتعزيز التواصل حول الحق في السكن اللائق" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 200, "200", 2, 2, 1, 13, 13, 2, " دعم البرنامج الوطني لتدبير وتثمين النفايات.", null, null, "البرنامج الوطني لتدبير وتثمين النفاياتمدعم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 237, "237", 3, 1, 1, 13, 16, 1, " الإسراع بإحداث وتفعيل الآلية الوطنية للتظلم الخاصة بالأطفال ضحايا انتهاكات حقوق الطفل.", null, null, "الآلية الوطنية للتظلم الخاصة بالأطفال ضحايا انتهاكات حقوق الطفل مفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 242, "242", 3, 1, 1, 13, 16, 1, " تفعيل المقتضيات القانونية ذات الصلة بالأطفال في المرحلة الانتقالية في القانون المتعلق بتشغيل العمال المنزليين.", null, null, "مناخ داعم لاحترام القانون المتعلق بتشغيل العاملات والعمال المنزليين " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 177, "177", 2, 1, 1, 16, 12, 1, "تفعيل القانون المتعلق بالمباني الآيلة للسقوط وتنظيم عمليات التجديد الحضري ووضع برامج متكاملة لمعالجة السكن المهدد بالانهيار لتشمل مجموع التراب الوطني.", null, null, "إطار مؤسساتي وتنظيمي داعم لمعالجة إشكالية السكن المهدد بالانهيار" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 120, "120", 2, 1, 1, 16, 9, 2, " ترميم وصيانة المواقع الأثرية والصخرية وتأمين حراستها حفاظا على التراث الثقافي الوطني وتعزيز آليات حمايته من الإتلاف والحفاظ على الذاكرة في بعديها الوطني والمحلي.", null, null, "منظومة حافظة للمواقع الأثرية والصخرية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 107, "107", 2, 1, 1, 16, 9, 1, "مواصلة تعزيز القناة التلفزية الأمازيغية وتمكينها من الموارد البشرية والكفاءات اللازمة للبث المتواصل", null, null, "بث متواصل للقناة التلفزية الأمازيغية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 104, "104", 2, 1, 1, 16, 9, 1, "تعزيز مكانة الثقافة والموروث الحساني في النموذج التنموي الخاص بالأقاليم الجنوبية وضمن التطور المجتمعي الوطني", null, null, "برامج معززة لمكانة الموروث الثقافي الحساني في النموذج التنموي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 27, "27", 1, 1, 1, 16, 4, 2, " تقوية الإطار القانوني والتنظيمي لتعزيز النزاهة والشفافية من خلال ملاءمته مع الاتفاقيات الدولية لمكافحة الفساد كما صادقت عليها المملكة المغربية ليشمل ما يتعلق بالتنسيق وآليات التحري والوصول إلى المعلومات والتنفيذ الفعال والتتبع والإشراف.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 393, "393", 4, 2, 1, 15, 22, 2, " تعزيز دور الجماعات الترابية في توفير بيئة آمنة تحمي الأطفال والنساء من كل أشكال العنف.", null, null, "بيئة آمنة تحمي الأطفال والنساء من كل أشكال العنف" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 358, "358", 3, 1, 3, 15, 20, 1, "مواصلة دعم وتعزيز قدرات فعاليات المجتمع المدني التي تهتم ميدانيا بأوضاع المهاجرين سواء في المغرب أو في بلدان الاستقبال.", null, null, "قدرات فعاليات المجتمع المدني معززة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 335, "335", 3, 1, 1, 15, 19, 1, " التفكير في سبل تثمين خبرات ومهارات الأشخاص المسنين بوصفها جزءا من الرصيد الثقافي والقيمي للرأسمال اللامادي.", null, null, "بيئة داعمة لتثمين خبرات ومهارات الأشخاص المسنين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 322, "322", 3, 2, 1, 15, 18, 2, " دعم دور القطاع الخاص للمساهمة في مسلسل الإدماج الاجتماعي للأشخاص في وضعية إعاقة. ", null, null, "قطاع خاص منخرط في الإدماج الاجتماعي للأشخاص في وضعية إعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 302, "302", 3, 2, 1, 15, 18, 2, " تفعيل مقتضيات الرافعة الرابعة من الرؤية الاستراتيجية لإصلاح التربية والتعليم 2015-2030 من أجل مدرسة الانصاف والجودة والارتقاء لفائدة الأشخاص في وضعية إعاقة أو في وضعيات خاصة.", null, null, "مؤسسة تعليمية دامجة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 280, "280", 3, 1, 1, 15, 17, 1, " وضع تدابير تشريعية وتنظيمية في مجال حماية الجمهور الناشئ ضد المخاطر المترتبة عن الاستعمال السيئ لوسائل التواصل المعتمدة على التكنولوجيات الحديثة. ", null, null, "إطار قانوني داعم لحماية الجمهور الناشئ  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 263, "263", 3, 2, 1, 15, 16, 2, " تفعيل البرنامج التنفيذي للسياسة العمومية المندمجة لحماية الطفولة بالمغرب محليا وجهويا.", null, null, "تدابير البرنامج الوطني للسياسة العمومية المندمجة لحماية الطفولة منفذة جهويا ومحليا" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 261, "261", 3, 2, 1, 15, 16, 2, " تنظيم وتتبع أوضاع كفالة الأطفال خارج المغرب.", null, null, "آليات مساعدة على تتبع أوضاع كفالة الأطفال خارج المغرب  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 249, "249", 3, 1, 1, 15, 16, 2, " تعزيز وتقوية المساعدة الاجتماعية والقانونية للأطفال ضحايا الاعتداء والعنف والاستغلال أو في تماس مع القانون.", null, null, "المساعدة الاجتماعية والقانونية للأطفال ضحايا العنف والاستغلال معززة وشاملة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 195, "195", 2, 2, 1, 16, 13, 1, "تأمين مشاركة ومساهمة مختلف الفاعلين وخاصة منظمات المجتمع المدني والهيئات السياسية والنقابية والإعلامية في النهوض بالثقافة البيئية ومختلف البرامج البيئية.", null, null, "برامج داعمة للنهوض بالثقافة البيئية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 239, "239", 3, 2, 1, 15, 16, 1, " الإسراع بالمصادقة على مشروع قانون متعلق بمراكز حماية الطفولة.", null, null, "إطار قانوني مساعد على تجويد خدمات مراكز حماية الطفولة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 70, "70", 1, 2, 1, 15, 6, 1, "تعزيز آليات الوساطة والتوفيق والتدخل الاستباقي المؤسساتي والمدني لتفادي حالات التوتر والحيلولة دون وقوع انتهاكات.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 39, "39", 1, 1, 1, 15, 4, 1, " تعزيز طرق وأشكال التبليغ عن حالات الفساد، بما في ذلك وضع خط أخضر وتيسير تقديم الشكايات.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 409, "409", 4, 2, 1, 14, 23, 2, " تعزيز دور المكتب المغربي لحقوق المؤلفين ومراجعة قانونه ليصبح مؤسسة عمومية.", null, null, "إطار قانوني داعم لحقوق المؤلف" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 384, "384", 4, 1, 1, 14, 22, 1, "مواصلة ترصيد المكتسبات المعرفية المتعلقة بالكد والسعاية في التشريع والعمل القضائي.", null, null, "دينامية داعمة لترصيد الاجتهادات العلمية/الفقهية والقضائية المتعلقة بالكد والسعاية  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 331, "331", 3, 2, 1, 14, 19, 1, "تحفيز البحث العلمي والدراسات الجامعية حول أوضاع الأشخاص المسنين وآثار الشيخوخة في مختلف المستويات الديمغرافية والاقتصادية والاجتماعية.", null, null, "بيئة داعمة للبحث العلمي حول أوضاع الأشخاص المسنين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 197, "197", 2, 2, 1, 14, 13, 2, "تطوير تدبير المجال الغابوي بالشكل الذي يوفر حماية شاملة للمحميات ولحقوق السكان ونشاطهم الزراعي والفلاحي.", null, null, "ديناميات معززة للحماية القانونية للمجال الغابوي  وداعمة لتنمية مستدامة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 184, "184", 2, 1, 1, 14, 13, 1, " ملاءمة الإطار القانوني الوطني مع الاتفاقيات الدولية المتعلقة بحماية البيئة والتنمية المستدامة.", null, null, "إطار قانوني وطنيمتلائم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 165, "165", 2, 2, 1, 14, 12, 2, "إرساء استراتيجية وطنية شمولية ومندمجة في مجال السكن.", null, null, "استراتيجية وطنية معتمدة داعمة للحق في السكن   " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 80, "80", 1, 2, 3, 14, 7, 1, "إعمال الحق في الوصول إلى المعلومة واستلامها ونشرها بما يضمن تفعيل مبدأ عدم الإفلات من العقاب", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 380, "380", 4, 2, 1, 13, 22, 1, " البحث في سبل مبادرات الحكومة وهيئات الديمقراطية التشاركية لتنظيم حوارات عمومية حول رصيد إعمال مدونة الأسرة على مستوى الاجتهاد القضائي والتطور المجتمعي.", null, null, "ديناميات داعمة لتطوير مدونة الأسرة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 378, "378", 4, 1, 3, 13, 21, 2, "تعزيز برامج التكوين الأساسي والتكوين المستمر في المعاهد والمراكز المعنية بالمكلفين بإنفاذ القانون.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 353, "353", 3, 2, 3, 13, 20, 1, " مواصلة التنسيق والالتقائية بين كافة المتدخلين في مجال الهجرة وتعزيز دور اللجنة بين الوزارية لمغاربة العالم وشؤون الهجرة في هذا المجال. ", null, null, "أداء اللجنة بين الوزارية معزز وفعال" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 313, "313", 3, 2, 1, 13, 18, 1, "الإسراع بتفعيل نظام الدعم الاجتماعي والتشجيع والمساندة لفائدة الأشخاص في وضعية إعاقة المنصوص عليه في المادة 6 من القانون الإطار رقم 97.13 المتعلق بحماية حقوق الاشخاص في وضعية إعاقة والنهوض بها.", null, null, "نظام الدعم الاجتماعي مشجع على النهوض بوضعية الأشخاص في وضعية إعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 254, "254", 3, 2, 1, 13, 16, 2, " حماية حقوق الأطفال في وسائل الإعلام بما في ذلك وسائل الاتصال الحديثة والنهوض بالتربية عليها.", null, null, "بيئة إعلامية داعمة لحقوق الطفل " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 146, "146", 2, 2, 1, 15, 10, 2, " مواصلة تعزيز الخدمات المتعلقة بمعالجة الشكايات والتظلمات والاقتراحات من طرف المرتفقين على الصعيد الجهوي، واعتماد استمارات توضع رهن إشارة المرتفقين لقياس مستوى رضاهم عن الخدمات. ", null, null, "منظومة داعمة لتحسين مستوى الخدمات" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 536, "Code : {id - 1}", 3, 1, 3, 50, 8, 1, "536 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 536", "بعد الأهداف الخاصة : 536", "بعد النتائج المرتقبة : 536" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 102, "[\"2025\", \"2026\", \"2027\"]", 536, "101 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 99, "[\"2021\", \"2022\", \"2023\"]", 471, "98 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 87, "[\"2028\", \"2029\", \"2030\"]", 462, "86 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 65, "[\"2028\", \"2029\", \"2030\"]", 462, "64 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 64, "[\"2028\", \"2029\", \"2030\"]", 458, "63 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 97, "[\"2028\", \"2029\", \"2030\"]", 439, "96 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 13, "[\"2022\", \"2023\", \"2024\"]", 50, "12 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 77, "[\"2021\", \"2022\", \"2023\"]", 439, "76 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 88, "[\"2022\", \"2023\", \"2024\"]", 478, "87 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 78, "[\"2022\", \"2023\", \"2024\"]", 478, "77 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 61, "[\"2022\", \"2023\", \"2024\"]", 478, "60 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 68, "[\"2019\", \"2020\", \"2021\"]", 475, "67 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 98, "[\"2028\", \"2029\", \"2030\"]", 474, "97 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 85, "[\"2018\", \"2019\", \"2020\"]", 456, "84 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 60, "[\"2023\", \"2024\", \"2025\"]", 456, "59 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 100, "[\"2027\", \"2028\", \"2029\"]", 446, "99 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 89, "[\"2020\", \"2021\", \"2022\"]", 447, "88 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 84, "[\"2021\", \"2022\", \"2023\"]", 446, "83 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 81, "[\"2018\", \"2019\", \"2020\"]", 448, "80 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 56, "[\"2020\", \"2021\", \"2022\"]", 440, "55 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 75, "[\"2022\", \"2023\", \"2024\"]", 438, "74 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 58, "[\"2020\", \"2021\", \"2022\"]", 459, "57 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 92, "[\"2018\", \"2019\", \"2020\"]", 477, "91 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 86, "[\"2018\", \"2019\", \"2020\"]", 460, "85 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 47, "[\"2027\", \"2028\", \"2029\"]", 247, "46 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 67, "[\"2027\", \"2028\", \"2029\"]", 460, "66 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 57, "[\"2026\", \"2027\", \"2028\"]", 442, "56 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 69, "[\"2022\", \"2023\", \"2024\"]", 436, "68 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 20, "[\"2027\", \"2028\", \"2029\"]", 192, "19 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 76, "[\"2024\", \"2025\", \"2026\"]", 437, "75 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 70, "[\"2022\", \"2023\", \"2024\"]", 484, "69 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 11, "[\"2028\", \"2029\", \"2030\"]", 306, "10 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 63, "[\"2027\", \"2028\", \"2029\"]", 484, "62 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 74, "[\"2026\", \"2027\", \"2028\"]", 470, "73 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 73, "[\"2024\", \"2025\", \"2026\"]", 453, "72 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 54, "[\"2026\", \"2027\", \"2028\"]", 440, "53 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 94, "[\"2025\", \"2026\", \"2027\"]", 472, "93 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 62, "[\"2028\", \"2029\", \"2030\"]", 446, "61 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 10, "[\"2027\", \"2028\", \"2029\"]", 6, "9 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 42, "[\"2028\", \"2029\", \"2030\"]", 257, "41 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 12, "[\"2027\", \"2028\", \"2029\"]", 377, "11 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 44, "[\"2025\", \"2026\", \"2027\"]", 23, "43 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 45, "[\"2028\", \"2029\", \"2030\"]", 314, "44 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 50, "[\"2023\", \"2024\", \"2025\"]", 317, "49 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 29, "[\"2022\", \"2023\", \"2024\"]", 390, "28 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 48, "[\"2024\", \"2025\", \"2026\"]", 26, "47 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 37, "[\"2018\", \"2019\", \"2020\"]", 161, "36 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 31, "[\"2029\", \"2030\", \"2031\"]", 162, "30 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 1, "[\"2024\", \"2025\", \"2026\"]", 66, "0 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 49, "[\"2021\", \"2022\", \"2023\"]", 318, "48 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 41, "[\"2018\", \"2019\", \"2020\"]", 203, "40 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 21, "[\"2023\", \"2024\", \"2025\"]", 60, "20 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 16, "[\"2022\", \"2023\", \"2024\"]", 25, "15 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 129, "[\"2022\", \"2023\", \"2024\"]", 532, "128 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 33, "[\"2018\", \"2019\", \"2020\"]", 404, "32 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 3, "[\"2022\", \"2023\", \"2024\"]", 167, "2 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 24, "[\"2018\", \"2019\", \"2020\"]", 429, "23 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 40, "[\"2020\", \"2021\", \"2022\"]", 340, "39 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 14, "[\"2023\", \"2024\", \"2025\"]", 420, "13 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 43, "[\"2028\", \"2029\", \"2030\"]", 294, "42 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 15, "[\"2019\", \"2020\", \"2021\"]", 190, "14 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 5, "[\"2027\", \"2028\", \"2029\"]", 190, "4 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 22, "[\"2018\", \"2019\", \"2020\"]", 237, "21 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 23, "[\"2025\", \"2026\", \"2027\"]", 242, "22 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 19, "[\"2021\", \"2022\", \"2023\"]", 313, "18 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 46, "[\"2023\", \"2024\", \"2025\"]", 165, "45 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 25, "[\"2018\", \"2019\", \"2020\"]", 246, "24 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 8, "[\"2018\", \"2019\", \"2020\"]", 261, "7 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 26, "[\"2024\", \"2025\", \"2026\"]", 302, "25 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 34, "[\"2028\", \"2029\", \"2030\"]", 335, "33 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 9, "[\"2022\", \"2023\", \"2024\"]", 358, "8 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 2, "[\"2027\", \"2028\", \"2029\"]", 107, "1 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 30, "[\"2028\", \"2029\", \"2030\"]", 107, "29 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 17, "[\"2018\", \"2019\", \"2020\"]", 374, "16 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 53, "[\"2020\", \"2021\", \"2022\"]", 482, "52 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 4, "[\"2022\", \"2023\", \"2024\"]", 1, "3 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 82, "[\"2020\", \"2021\", \"2022\"]", 482, "81 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 106, "[\"2025\", \"2026\", \"2027\"]", 495, "105 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 142, "[\"2027\", \"2028\", \"2029\"]", 521, "141 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 144, "[\"2027\", \"2028\", \"2029\"]", 491, "143 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 137, "[\"2025\", \"2026\", \"2027\"]", 491, "136 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 36, "[\"2021\", \"2022\", \"2023\"]", 283, "35 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 136, "[\"2022\", \"2023\", \"2024\"]", 491, "135 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 7, "[\"2025\", \"2026\", \"2027\"]", 221, "6 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 127, "[\"2026\", \"2027\", \"2028\"]", 504, "126 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 121, "[\"2021\", \"2022\", \"2023\"]", 531, "120 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 126, "[\"2024\", \"2025\", \"2026\"]", 528, "125 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 32, "[\"2028\", \"2029\", \"2030\"]", 145, "31 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 114, "[\"2025\", \"2026\", \"2027\"]", 528, "113 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 143, "[\"2018\", \"2019\", \"2020\"]", 524, "142 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 118, "[\"2022\", \"2023\", \"2024\"]", 524, "117 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 120, "[\"2027\", \"2028\", \"2029\"]", 530, "119 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 109, "[\"2020\", \"2021\", \"2022\"]", 508, "108 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 128, "[\"2024\", \"2025\", \"2026\"]", 508, "127 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 146, "[\"2022\", \"2023\", \"2024\"]", 516, "145 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 141, "[\"2018\", \"2019\", \"2020\"]", 506, "140 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 135, "[\"2021\", \"2022\", \"2023\"]", 500, "134 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 145, "[\"2029\", \"2030\", \"2031\"]", 535, "144 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 125, "[\"2018\", \"2019\", \"2020\"]", 535, "124 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 35, "[\"2029\", \"2030\", \"2031\"]", 91, "34 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 134, "[\"2026\", \"2027\", \"2028\"]", 519, "133 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 115, "[\"2025\", \"2026\", \"2027\"]", 519, "114 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 6, "[\"2029\", \"2030\", \"2031\"]", 421, "5 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 105, "[\"2026\", \"2027\", \"2028\"]", 514, "104 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 116, "[\"2024\", \"2025\", \"2026\"]", 514, "115 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 139, "[\"2024\", \"2025\", \"2026\"]", 515, "138 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 107, "[\"2019\", \"2020\", \"2021\"]", 521, "106 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 150, "[\"2024\", \"2025\", \"2026\"]", 517, "149 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 111, "[\"2025\", \"2026\", \"2027\"]", 517, "110 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 66, "[\"2022\", \"2023\", \"2024\"]", 482, "65 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 104, "[\"2019\", \"2020\", \"2021\"]", 524, "103 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 108, "[\"2018\", \"2019\", \"2020\"]", 532, "107 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 103, "[\"2029\", \"2030\", \"2031\"]", 491, "102 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 113, "[\"2018\", \"2019\", \"2020\"]", 511, "112 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 123, "[\"2026\", \"2027\", \"2028\"]", 496, "122 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 27, "[\"2023\", \"2024\", \"2025\"]", 13, "26 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 132, "[\"2019\", \"2020\", \"2021\"]", 487, "131 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 72, "[\"2025\", \"2026\", \"2027\"]", 468, "71 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 90, "[\"2026\", \"2027\", \"2028\"]", 457, "89 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 83, "[\"2028\", \"2029\", \"2030\"]", 451, "82 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 96, "[\"2022\", \"2023\", \"2024\"]", 464, "95 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 93, "[\"2029\", \"2030\", \"2031\"]", 455, "92 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 18, "[\"2024\", \"2025\", \"2026\"]", 347, "17 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 131, "[\"2023\", \"2024\", \"2025\"]", 501, "130 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 59, "[\"2023\", \"2024\", \"2025\"]", 449, "58 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 55, "[\"2023\", \"2024\", \"2025\"]", 449, "54 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 91, "[\"2021\", \"2022\", \"2023\"]", 444, "90 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 52, "[\"2018\", \"2019\", \"2020\"]", 480, "51 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 79, "[\"2022\", \"2023\", \"2024\"]", 479, "78 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 71, "[\"2029\", \"2030\", \"2031\"]", 461, "70 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 95, "[\"2019\", \"2020\", \"2021\"]", 450, "94 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 39, "[\"2025\", \"2026\", \"2027\"]", 111, "38 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 80, "[\"2019\", \"2020\", \"2021\"]", 450, "79 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 51, "[\"2026\", \"2027\", \"2028\"]", 450, "50 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 28, "[\"2029\", \"2030\", \"2031\"]", 372, "27 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 117, "[\"2023\", \"2024\", \"2025\"]", 512, "116 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 149, "[\"2027\", \"2028\", \"2029\"]", 488, "148 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 147, "[\"2019\", \"2020\", \"2021\"]", 502, "146 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 38, "[\"2024\", \"2025\", \"2026\"]", 307, "37 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 133, "[\"2029\", \"2030\", \"2031\"]", 490, "132 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 119, "[\"2024\", \"2025\", \"2026\"]", 490, "118 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 148, "[\"2022\", \"2023\", \"2024\"]", 534, "147 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 140, "[\"2018\", \"2019\", \"2020\"]", 529, "139 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 110, "[\"2029\", \"2030\", \"2031\"]", 509, "109 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 138, "[\"2020\", \"2021\", \"2022\"]", 525, "137 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 112, "[\"2019\", \"2020\", \"2021\"]", 523, "111 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 122, "[\"2018\", \"2019\", \"2020\"]", 513, "121 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 124, "[\"2023\", \"2024\", \"2025\"]", 497, "123 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 101, "[\"2018\", \"2019\", \"2020\"]", 511, "100 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 130, "[\"2029\", \"2030\", \"2031\"]", 512, "129 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 149, new DateTime(2020, 11, 23, 12, 58, 27, 498, DateTimeKind.Local).AddTicks(620), 3, 243, "23" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 95, new DateTime(2020, 6, 27, 3, 58, 32, 559, DateTimeKind.Local).AddTicks(6570), 4, 226, "80" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 96, new DateTime(2020, 8, 8, 17, 25, 5, 115, DateTimeKind.Local).AddTicks(3008), 4, 210, "23" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 185, new DateTime(2020, 9, 27, 22, 14, 28, 236, DateTimeKind.Local).AddTicks(167), 4, 266, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 126, new DateTime(2020, 3, 25, 7, 12, 33, 606, DateTimeKind.Local).AddTicks(8808), 6, 231, "69" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 11, new DateTime(2020, 8, 28, 18, 11, 36, 563, DateTimeKind.Local).AddTicks(6896), 6, 278, "29" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 66, new DateTime(2020, 12, 30, 1, 53, 53, 691, DateTimeKind.Local).AddTicks(3478), 6, 164, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 71, new DateTime(2020, 4, 17, 1, 57, 32, 12, DateTimeKind.Local).AddTicks(3927), 4, 341, "65" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 46, new DateTime(2020, 4, 7, 1, 59, 36, 494, DateTimeKind.Local).AddTicks(1959), 6, 397, "99" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 176, new DateTime(2020, 10, 9, 15, 32, 57, 852, DateTimeKind.Local).AddTicks(80), 3, 240, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 8, new DateTime(2020, 12, 4, 5, 30, 1, 346, DateTimeKind.Local).AddTicks(6251), 6, 243, "71" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 29, new DateTime(2020, 10, 8, 7, 33, 41, 756, DateTimeKind.Local).AddTicks(2290), 6, 228, "67" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 130, new DateTime(2020, 11, 6, 1, 36, 9, 397, DateTimeKind.Local).AddTicks(598), 5, 428, "48" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 81, new DateTime(2020, 5, 5, 23, 31, 37, 282, DateTimeKind.Local).AddTicks(2847), 4, 243, "65" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 44, new DateTime(2020, 12, 11, 18, 18, 37, 234, DateTimeKind.Local).AddTicks(7937), 3, 161, "85" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 143, new DateTime(2020, 5, 23, 1, 4, 46, 895, DateTimeKind.Local).AddTicks(9440), 1, 161, "29" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 18, new DateTime(2020, 2, 12, 22, 8, 58, 110, DateTimeKind.Local).AddTicks(8307), 1, 431, "41" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 102, new DateTime(2020, 4, 7, 20, 29, 33, 201, DateTimeKind.Local).AddTicks(4398), 4, 301, "34" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 145, new DateTime(2020, 5, 31, 21, 27, 27, 177, DateTimeKind.Local).AddTicks(7704), 6, 68, "43" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 110, new DateTime(2020, 9, 10, 21, 56, 31, 464, DateTimeKind.Local).AddTicks(253), 5, 99, "81" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 50, new DateTime(2021, 1, 6, 12, 53, 22, 860, DateTimeKind.Local).AddTicks(8891), 2, 236, "92" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 67, new DateTime(2020, 8, 25, 18, 58, 28, 276, DateTimeKind.Local).AddTicks(2614), 6, 236, "52" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 17, new DateTime(2020, 6, 1, 5, 1, 57, 777, DateTimeKind.Local).AddTicks(4821), 3, 166, "84" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 188, new DateTime(2020, 5, 10, 8, 10, 25, 923, DateTimeKind.Local).AddTicks(1923), 6, 273, "22" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 166, new DateTime(2020, 12, 14, 5, 58, 29, 137, DateTimeKind.Local).AddTicks(3226), 5, 133, "30" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 116, new DateTime(2020, 11, 30, 6, 15, 10, 742, DateTimeKind.Local).AddTicks(5923), 1, 133, "71" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 124, new DateTime(2020, 12, 22, 17, 36, 1, 738, DateTimeKind.Local).AddTicks(9775), 2, 326, "17" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 162, new DateTime(2020, 8, 5, 7, 8, 50, 436, DateTimeKind.Local).AddTicks(534), 3, 42, "72" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 27, new DateTime(2020, 5, 10, 6, 37, 14, 863, DateTimeKind.Local).AddTicks(5943), 3, 11, "14" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 6, new DateTime(2020, 7, 23, 23, 37, 56, 576, DateTimeKind.Local).AddTicks(9888), 4, 359, "94" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 94, new DateTime(2020, 3, 15, 8, 58, 36, 179, DateTimeKind.Local).AddTicks(1723), 1, 318, "78" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 23, new DateTime(2020, 8, 6, 20, 24, 28, 730, DateTimeKind.Local).AddTicks(6309), 3, 411, "15" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 195, new DateTime(2020, 7, 18, 20, 35, 42, 804, DateTimeKind.Local).AddTicks(7461), 3, 156, "97" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 152, new DateTime(2020, 3, 22, 8, 37, 32, 869, DateTimeKind.Local).AddTicks(6289), 3, 407, "11" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 120, new DateTime(2021, 1, 5, 7, 52, 9, 931, DateTimeKind.Local).AddTicks(3091), 5, 230, "40" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 39, new DateTime(2020, 10, 17, 5, 35, 54, 86, DateTimeKind.Local).AddTicks(518), 3, 241, "34" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 128, new DateTime(2020, 6, 27, 1, 44, 18, 379, DateTimeKind.Local).AddTicks(8030), 3, 241, "76" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 85, new DateTime(2020, 11, 4, 2, 51, 32, 978, DateTimeKind.Local).AddTicks(1584), 2, 363, "70" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 117, new DateTime(2020, 6, 12, 10, 30, 3, 195, DateTimeKind.Local).AddTicks(4400), 1, 92, "88" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 200, new DateTime(2020, 3, 17, 22, 52, 42, 747, DateTimeKind.Local).AddTicks(4910), 6, 92, "100" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 190, new DateTime(2020, 7, 13, 17, 31, 49, 386, DateTimeKind.Local).AddTicks(2122), 5, 127, "50" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 75, new DateTime(2020, 8, 5, 14, 41, 53, 434, DateTimeKind.Local).AddTicks(7918), 2, 169, "70" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 22, new DateTime(2020, 5, 18, 9, 31, 36, 26, DateTimeKind.Local).AddTicks(8130), 5, 230, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 119, new DateTime(2020, 4, 5, 12, 58, 43, 206, DateTimeKind.Local).AddTicks(5264), 5, 169, "57" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 30, new DateTime(2020, 6, 30, 3, 57, 10, 819, DateTimeKind.Local).AddTicks(7261), 4, 183, "61" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 93, new DateTime(2021, 1, 3, 6, 39, 59, 629, DateTimeKind.Local).AddTicks(4680), 3, 190, "92" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 87, new DateTime(2020, 5, 10, 8, 4, 29, 408, DateTimeKind.Local).AddTicks(2882), 3, 420, "62" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 32, new DateTime(2020, 6, 27, 13, 7, 32, 42, DateTimeKind.Local).AddTicks(3225), 6, 34, "100" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 10, new DateTime(2020, 12, 17, 13, 39, 20, 887, DateTimeKind.Local).AddTicks(7734), 4, 140, "48" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 115, new DateTime(2020, 7, 13, 4, 39, 0, 714, DateTimeKind.Local).AddTicks(998), 5, 174, "98" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 194, new DateTime(2020, 3, 11, 7, 27, 17, 866, DateTimeKind.Local).AddTicks(158), 6, 367, "41" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 121, new DateTime(2020, 3, 11, 16, 40, 44, 848, DateTimeKind.Local).AddTicks(9806), 3, 295, "22" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 163, new DateTime(2020, 6, 5, 4, 32, 32, 525, DateTimeKind.Local).AddTicks(3382), 3, 169, "68" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 3, new DateTime(2020, 2, 16, 11, 20, 24, 479, DateTimeKind.Local).AddTicks(8383), 1, 17, "68" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 82, new DateTime(2021, 1, 28, 3, 55, 47, 465, DateTimeKind.Local).AddTicks(6017), 1, 412, "31" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 40, new DateTime(2020, 12, 3, 19, 42, 11, 728, DateTimeKind.Local).AddTicks(1363), 3, 412, "15" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 47, new DateTime(2021, 1, 25, 14, 57, 1, 517, DateTimeKind.Local).AddTicks(5353), 1, 414, "66" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 142, new DateTime(2020, 10, 20, 17, 46, 47, 333, DateTimeKind.Local).AddTicks(9070), 2, 427, "47" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 2, new DateTime(2020, 10, 25, 3, 45, 10, 58, DateTimeKind.Local).AddTicks(5176), 1, 23, "65" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 187, new DateTime(2021, 1, 26, 0, 20, 0, 918, DateTimeKind.Local).AddTicks(1559), 2, 124, "69" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 69, new DateTime(2020, 3, 13, 16, 48, 43, 741, DateTimeKind.Local).AddTicks(4145), 3, 151, "66" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 192, new DateTime(2020, 8, 23, 20, 24, 36, 620, DateTimeKind.Local).AddTicks(5499), 3, 319, "100" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 97, new DateTime(2020, 6, 25, 14, 13, 27, 4, DateTimeKind.Local).AddTicks(8998), 3, 429, "94" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 193, new DateTime(2020, 10, 30, 23, 23, 27, 28, DateTimeKind.Local).AddTicks(8985), 1, 38, "14" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 111, new DateTime(2020, 3, 29, 22, 20, 46, 129, DateTimeKind.Local).AddTicks(7628), 1, 100, "30" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 13, new DateTime(2020, 3, 14, 11, 41, 26, 399, DateTimeKind.Local).AddTicks(4879), 3, 125, "47" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 59, new DateTime(2020, 3, 15, 10, 33, 45, 983, DateTimeKind.Local).AddTicks(8112), 3, 125, "63" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 138, new DateTime(2020, 6, 2, 14, 2, 4, 46, DateTimeKind.Local).AddTicks(3427), 1, 160, "21" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 43, new DateTime(2020, 12, 21, 4, 0, 10, 548, DateTimeKind.Local).AddTicks(6246), 5, 296, "95" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 133, new DateTime(2020, 8, 10, 14, 39, 26, 810, DateTimeKind.Local).AddTicks(4010), 3, 300, "43" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 114, new DateTime(2020, 10, 25, 17, 21, 44, 418, DateTimeKind.Local).AddTicks(5015), 1, 343, "25" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 4, new DateTime(2020, 5, 28, 22, 7, 29, 555, DateTimeKind.Local).AddTicks(6884), 6, 422, "78" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 70, new DateTime(2020, 6, 6, 15, 1, 9, 881, DateTimeKind.Local).AddTicks(1450), 3, 75, "37" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 129, new DateTime(2020, 2, 23, 9, 22, 38, 581, DateTimeKind.Local).AddTicks(3674), 6, 156, "89" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 139, new DateTime(2020, 10, 12, 16, 21, 40, 815, DateTimeKind.Local).AddTicks(1532), 3, 277, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 106, new DateTime(2020, 6, 26, 8, 23, 30, 386, DateTimeKind.Local).AddTicks(3285), 5, 407, "68" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 186, new DateTime(2020, 5, 7, 13, 13, 37, 916, DateTimeKind.Local).AddTicks(3792), 6, 386, "64" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 180, new DateTime(2020, 11, 6, 1, 40, 39, 518, DateTimeKind.Local).AddTicks(4674), 1, 364, "31" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 31, new DateTime(2020, 6, 14, 11, 51, 38, 272, DateTimeKind.Local).AddTicks(4920), 1, 195, "75" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 105, new DateTime(2020, 4, 29, 4, 4, 14, 67, DateTimeKind.Local).AddTicks(2395), 2, 35, "23" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 41, new DateTime(2021, 1, 2, 11, 33, 58, 549, DateTimeKind.Local).AddTicks(4123), 3, 200, "80" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 51, new DateTime(2020, 3, 24, 2, 15, 46, 778, DateTimeKind.Local).AddTicks(6941), 1, 200, "44" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 15, new DateTime(2020, 11, 25, 2, 22, 59, 585, DateTimeKind.Local).AddTicks(7613), 6, 237, "58" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 60, new DateTime(2020, 5, 13, 18, 30, 56, 528, DateTimeKind.Local).AddTicks(6316), 1, 242, "65" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 137, new DateTime(2020, 3, 27, 7, 20, 48, 446, DateTimeKind.Local).AddTicks(8444), 3, 254, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 72, new DateTime(2020, 3, 16, 2, 49, 33, 900, DateTimeKind.Local).AddTicks(6711), 1, 313, "46" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 135, new DateTime(2020, 6, 9, 3, 40, 21, 86, DateTimeKind.Local).AddTicks(7595), 2, 313, "22" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 61, new DateTime(2020, 11, 17, 1, 4, 25, 393, DateTimeKind.Local).AddTicks(9081), 4, 378, "45" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 134, new DateTime(2020, 3, 27, 15, 39, 5, 485, DateTimeKind.Local).AddTicks(4194), 1, 80, "58" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 169, new DateTime(2020, 8, 16, 18, 58, 8, 793, DateTimeKind.Local).AddTicks(5668), 6, 80, "61" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 65, new DateTime(2020, 10, 22, 6, 20, 53, 558, DateTimeKind.Local).AddTicks(2346), 4, 197, "12" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 197, new DateTime(2020, 10, 24, 13, 29, 22, 915, DateTimeKind.Local).AddTicks(1565), 6, 197, "77" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 89, new DateTime(2020, 12, 22, 23, 11, 15, 34, DateTimeKind.Local).AddTicks(3572), 1, 409, "94" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 123, new DateTime(2020, 7, 17, 23, 11, 41, 540, DateTimeKind.Local).AddTicks(5100), 2, 217, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 125, new DateTime(2020, 10, 29, 1, 46, 8, 324, DateTimeKind.Local).AddTicks(2480), 1, 194, "66" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 62, new DateTime(2020, 11, 7, 3, 54, 24, 900, DateTimeKind.Local).AddTicks(6099), 2, 194, "23" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 158, new DateTime(2020, 11, 13, 22, 59, 56, 206, DateTimeKind.Local).AddTicks(7776), 4, 274, "10" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 42, new DateTime(2020, 2, 27, 21, 6, 29, 412, DateTimeKind.Local).AddTicks(3933), 1, 274, "61" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 155, new DateTime(2020, 10, 24, 2, 3, 29, 85, DateTimeKind.Local).AddTicks(2499), 5, 234, "85" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 183, new DateTime(2020, 7, 28, 20, 13, 51, 741, DateTimeKind.Local).AddTicks(3277), 4, 177, "73" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 26, new DateTime(2020, 12, 8, 5, 55, 26, 468, DateTimeKind.Local).AddTicks(9107), 4, 177, "100" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 49, new DateTime(2020, 10, 14, 6, 59, 32, 742, DateTimeKind.Local).AddTicks(3571), 1, 107, "66" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 98, new DateTime(2020, 4, 24, 18, 39, 57, 868, DateTimeKind.Local).AddTicks(6447), 6, 386, "97" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 83, new DateTime(2020, 3, 18, 9, 48, 22, 947, DateTimeKind.Local).AddTicks(1616), 4, 32, "54" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 52, new DateTime(2021, 1, 9, 3, 38, 54, 679, DateTimeKind.Local).AddTicks(8252), 2, 87, "34" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 156, new DateTime(2020, 12, 12, 15, 0, 29, 247, DateTimeKind.Local).AddTicks(3279), 4, 188, "30" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 57, new DateTime(2020, 9, 16, 16, 54, 55, 819, DateTimeKind.Local).AddTicks(183), 6, 358, "88" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 178, new DateTime(2020, 3, 7, 14, 2, 19, 158, DateTimeKind.Local).AddTicks(7532), 3, 146, "93" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 48, new DateTime(2021, 1, 26, 6, 4, 15, 501, DateTimeKind.Local).AddTicks(8492), 6, 146, "94" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 56, new DateTime(2020, 5, 3, 11, 28, 31, 848, DateTimeKind.Local).AddTicks(3880), 4, 194, "63" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 132, new DateTime(2020, 12, 5, 10, 34, 1, 364, DateTimeKind.Local).AddTicks(4963), 6, 49, "65" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 144, new DateTime(2020, 8, 19, 9, 34, 28, 957, DateTimeKind.Local).AddTicks(5589), 5, 282, "75" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 16, new DateTime(2020, 12, 25, 0, 59, 6, 472, DateTimeKind.Local).AddTicks(4433), 6, 293, "74" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 165, new DateTime(2020, 5, 3, 4, 49, 24, 313, DateTimeKind.Local).AddTicks(3328), 3, 293, "50" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 84, new DateTime(2021, 1, 5, 6, 59, 40, 404, DateTimeKind.Local).AddTicks(6370), 5, 316, "96" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 157, new DateTime(2020, 10, 18, 9, 43, 42, 445, DateTimeKind.Local).AddTicks(6856), 2, 387, "21" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 33, new DateTime(2020, 11, 27, 13, 56, 46, 138, DateTimeKind.Local).AddTicks(1896), 2, 413, "81" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 14, new DateTime(2020, 7, 19, 6, 56, 33, 583, DateTimeKind.Local).AddTicks(5219), 3, 52, "42" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 5, new DateTime(2020, 5, 19, 7, 12, 41, 732, DateTimeKind.Local).AddTicks(832), 2, 201, "56" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 19, new DateTime(2020, 2, 16, 19, 24, 10, 912, DateTimeKind.Local).AddTicks(8757), 3, 362, "15" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 118, new DateTime(2020, 9, 19, 10, 35, 20, 302, DateTimeKind.Local).AddTicks(5916), 1, 119, "56" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 196, new DateTime(2020, 7, 28, 14, 19, 7, 959, DateTimeKind.Local).AddTicks(1157), 1, 355, "72" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 76, new DateTime(2020, 9, 8, 22, 59, 6, 589, DateTimeKind.Local).AddTicks(1831), 5, 306, "82" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 53, new DateTime(2020, 4, 27, 0, 41, 42, 245, DateTimeKind.Local).AddTicks(7189), 1, 272, "55" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 150, new DateTime(2020, 10, 5, 4, 14, 44, 728, DateTimeKind.Local).AddTicks(315), 6, 192, "24" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 159, new DateTime(2020, 3, 8, 5, 29, 9, 902, DateTimeKind.Local).AddTicks(8889), 1, 360, "66" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 175, new DateTime(2020, 12, 1, 0, 43, 7, 202, DateTimeKind.Local).AddTicks(8119), 6, 327, "89" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 36, new DateTime(2020, 7, 19, 6, 53, 12, 37, DateTimeKind.Local).AddTicks(9645), 2, 327, "39" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 161, new DateTime(2020, 8, 16, 0, 26, 24, 473, DateTimeKind.Local).AddTicks(6295), 6, 306, "20" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 140, new DateTime(2020, 4, 21, 16, 14, 41, 608, DateTimeKind.Local).AddTicks(2536), 5, 305, "77" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 108, new DateTime(2020, 7, 2, 6, 55, 24, 141, DateTimeKind.Local).AddTicks(7340), 2, 61, "86" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 131, new DateTime(2020, 2, 16, 2, 14, 25, 146, DateTimeKind.Local).AddTicks(8294), 2, 95, "22" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 45, new DateTime(2021, 1, 11, 17, 14, 10, 961, DateTimeKind.Local).AddTicks(4558), 2, 344, "55" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 146, new DateTime(2020, 7, 15, 17, 32, 4, 990, DateTimeKind.Local).AddTicks(3923), 5, 347, "81" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 7, new DateTime(2020, 5, 3, 20, 37, 9, 301, DateTimeKind.Local).AddTicks(9635), 6, 372, "41" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 88, new DateTime(2020, 1, 30, 18, 51, 55, 610, DateTimeKind.Local).AddTicks(1150), 4, 372, "71" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 179, new DateTime(2020, 6, 2, 4, 46, 34, 813, DateTimeKind.Local).AddTicks(7090), 6, 134, "31" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 174, new DateTime(2020, 2, 8, 6, 42, 37, 268, DateTimeKind.Local).AddTicks(4440), 6, 1, "61" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 164, new DateTime(2020, 8, 29, 1, 55, 51, 434, DateTimeKind.Local).AddTicks(9458), 6, 50, "90" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 184, new DateTime(2020, 12, 24, 21, 7, 48, 42, DateTimeKind.Local).AddTicks(7051), 6, 394, "92" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 109, new DateTime(2020, 8, 21, 22, 15, 35, 197, DateTimeKind.Local).AddTicks(4319), 4, 308, "62" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 191, new DateTime(2020, 5, 2, 14, 3, 53, 358, DateTimeKind.Local).AddTicks(5240), 1, 206, "77" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 55, new DateTime(2020, 8, 3, 21, 28, 23, 28, DateTimeKind.Local).AddTicks(8455), 6, 206, "21" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 168, new DateTime(2020, 12, 28, 10, 4, 39, 432, DateTimeKind.Local).AddTicks(7527), 1, 196, "48" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 92, new DateTime(2020, 7, 19, 19, 5, 34, 270, DateTimeKind.Local).AddTicks(6116), 6, 108, "41" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 91, new DateTime(2020, 12, 10, 5, 0, 16, 667, DateTimeKind.Local).AddTicks(1072), 2, 108, "68" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 122, new DateTime(2020, 6, 13, 3, 10, 1, 380, DateTimeKind.Local).AddTicks(3545), 6, 324, "81" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 12, new DateTime(2020, 2, 6, 7, 55, 34, 818, DateTimeKind.Local).AddTicks(4698), 2, 88, "39" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 107, new DateTime(2020, 12, 8, 20, 9, 1, 923, DateTimeKind.Local).AddTicks(6680), 1, 201, "36" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 68, new DateTime(2020, 9, 27, 15, 14, 26, 471, DateTimeKind.Local).AddTicks(1919), 3, 186, "98" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 35, new DateTime(2021, 1, 2, 12, 18, 1, 613, DateTimeKind.Local).AddTicks(1703), 2, 163, "24" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 100, new DateTime(2020, 12, 22, 19, 55, 31, 703, DateTimeKind.Local).AddTicks(4797), 6, 15, "85" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 73, new DateTime(2020, 2, 29, 19, 44, 12, 417, DateTimeKind.Local).AddTicks(7251), 5, 356, "48" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 1, new DateTime(2020, 9, 9, 13, 49, 56, 303, DateTimeKind.Local).AddTicks(1563), 3, 20, "42" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 148, new DateTime(2021, 1, 22, 11, 59, 12, 678, DateTimeKind.Local).AddTicks(7179), 2, 20, "22" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 24, new DateTime(2020, 4, 24, 21, 21, 31, 698, DateTimeKind.Local).AddTicks(9903), 2, 421, "50" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 58, new DateTime(2020, 7, 17, 21, 39, 52, 736, DateTimeKind.Local).AddTicks(5914), 4, 383, "63" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 25, new DateTime(2020, 5, 12, 18, 48, 14, 438, DateTimeKind.Local).AddTicks(3112), 1, 73, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 28, new DateTime(2021, 1, 16, 2, 8, 47, 412, DateTimeKind.Local).AddTicks(7931), 3, 162, "31" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 141, new DateTime(2020, 12, 12, 10, 21, 38, 845, DateTimeKind.Local).AddTicks(6105), 2, 214, "40" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 177, new DateTime(2020, 12, 7, 5, 51, 14, 587, DateTimeKind.Local).AddTicks(1547), 4, 5, "52" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 90, new DateTime(2021, 1, 3, 10, 42, 30, 373, DateTimeKind.Local).AddTicks(4837), 1, 46, "50" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 151, new DateTime(2020, 9, 28, 18, 16, 36, 998, DateTimeKind.Local).AddTicks(4713), 6, 18, "53" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 170, new DateTime(2020, 8, 15, 21, 13, 35, 358, DateTimeKind.Local).AddTicks(1016), 5, 218, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 189, new DateTime(2020, 6, 25, 10, 12, 26, 247, DateTimeKind.Local).AddTicks(3603), 4, 332, "39" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 86, new DateTime(2021, 1, 1, 12, 56, 6, 596, DateTimeKind.Local).AddTicks(1105), 5, 338, "17" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 99, new DateTime(2020, 7, 14, 2, 4, 45, 217, DateTimeKind.Local).AddTicks(6070), 4, 338, "100" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 80, new DateTime(2020, 7, 19, 10, 25, 36, 146, DateTimeKind.Local).AddTicks(2748), 3, 128, "43" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 20, new DateTime(2020, 6, 13, 6, 40, 15, 891, DateTimeKind.Local).AddTicks(575), 4, 129, "38" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 104, new DateTime(2020, 5, 5, 17, 49, 2, 757, DateTimeKind.Local).AddTicks(1918), 6, 130, "63" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 160, new DateTime(2020, 3, 18, 23, 16, 34, 260, DateTimeKind.Local).AddTicks(5076), 3, 130, "65" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 147, new DateTime(2020, 4, 15, 18, 47, 6, 94, DateTimeKind.Local).AddTicks(8074), 5, 131, "85" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 74, new DateTime(2020, 2, 11, 15, 8, 2, 799, DateTimeKind.Local).AddTicks(6860), 3, 46, "40" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 136, new DateTime(2020, 12, 7, 19, 56, 50, 644, DateTimeKind.Local).AddTicks(1499), 5, 221, "17" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 103, new DateTime(2020, 7, 5, 9, 53, 18, 811, DateTimeKind.Local).AddTicks(7811), 1, 163, "63" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 9, new DateTime(2020, 6, 20, 23, 24, 5, 77, DateTimeKind.Local).AddTicks(9378), 2, 58, "91" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 171, new DateTime(2020, 11, 18, 9, 17, 0, 780, DateTimeKind.Local).AddTicks(4637), 4, 220, "91" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 181, new DateTime(2020, 11, 1, 1, 6, 48, 635, DateTimeKind.Local).AddTicks(544), 6, 364, "20" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 113, new DateTime(2020, 3, 20, 8, 47, 9, 415, DateTimeKind.Local).AddTicks(435), 2, 435, "52" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 127, new DateTime(2021, 1, 22, 18, 40, 57, 494, DateTimeKind.Local).AddTicks(9960), 1, 325, "53" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 153, new DateTime(2020, 5, 15, 2, 14, 10, 132, DateTimeKind.Local).AddTicks(8292), 4, 291, "22" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 182, new DateTime(2020, 10, 4, 16, 51, 40, 445, DateTimeKind.Local).AddTicks(5456), 3, 374, "17" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 63, new DateTime(2020, 6, 30, 22, 6, 0, 88, DateTimeKind.Local).AddTicks(5816), 1, 330, "84" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 167, new DateTime(2020, 10, 18, 20, 38, 38, 970, DateTimeKind.Local).AddTicks(348), 6, 255, "90" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 198, new DateTime(2020, 4, 4, 19, 26, 37, 951, DateTimeKind.Local).AddTicks(643), 2, 238, "83" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 21, new DateTime(2020, 11, 24, 7, 7, 23, 982, DateTimeKind.Local).AddTicks(3280), 3, 238, "51" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 172, new DateTime(2020, 2, 24, 15, 27, 1, 707, DateTimeKind.Local).AddTicks(1683), 3, 390, "18" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 34, new DateTime(2020, 3, 13, 19, 7, 52, 280, DateTimeKind.Local).AddTicks(5652), 4, 204, "30" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 101, new DateTime(2020, 8, 24, 18, 16, 21, 758, DateTimeKind.Local).AddTicks(4413), 1, 5, "36" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 38, new DateTime(2020, 6, 8, 16, 15, 48, 746, DateTimeKind.Local).AddTicks(8152), 1, 264, "41" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 64, new DateTime(2020, 3, 6, 15, 25, 14, 606, DateTimeKind.Local).AddTicks(2806), 3, 58, "66" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 78, new DateTime(2021, 1, 4, 14, 28, 11, 598, DateTimeKind.Local).AddTicks(2514), 5, 346, "76" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 54, new DateTime(2020, 7, 22, 7, 3, 42, 797, DateTimeKind.Local).AddTicks(7300), 1, 377, "32" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 79, new DateTime(2020, 5, 3, 18, 34, 55, 308, DateTimeKind.Local).AddTicks(4269), 3, 150, "54" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 154, new DateTime(2020, 5, 11, 13, 12, 17, 933, DateTimeKind.Local).AddTicks(7914), 1, 145, "98" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 112, new DateTime(2020, 2, 26, 13, 6, 49, 947, DateTimeKind.Local).AddTicks(5196), 3, 113, "52" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 173, new DateTime(2020, 2, 14, 17, 30, 51, 158, DateTimeKind.Local).AddTicks(8877), 2, 72, "30" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 77, new DateTime(2020, 5, 10, 18, 56, 51, 301, DateTimeKind.Local).AddTicks(9734), 3, 55, "31" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 199, new DateTime(2020, 5, 4, 18, 57, 42, 398, DateTimeKind.Local).AddTicks(1356), 4, 62, "88" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 37, new DateTime(2021, 1, 7, 10, 36, 20, 567, DateTimeKind.Local).AddTicks(2), 1, 56, "97" });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 22, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 41, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 24, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 24, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 3, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 37, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 14, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 40, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 13, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 13, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 32, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 32, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 49, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 49, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 47, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 47, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 36, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 36, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 16, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 16, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 14, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 46, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 41, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 46, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 40, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 37, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 29, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 35, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 28, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 28, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 23, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 23, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 44, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 44, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 48, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 48, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 9, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 9, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 15, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 15, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 20, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 20, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 26, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 26, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 42, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 29, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 11, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 11, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 25, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 25, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 18, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 38, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 18, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 5, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 12, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 12, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 10, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 10, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 42, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 5, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 2, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 38, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 45, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 8, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 8, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 19, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 19, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 43, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 43, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 50, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 50, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 6, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 34, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 34, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 21, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 21, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 35, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 7, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 30, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 30, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 31, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 31, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 45, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 33, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 27, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 27, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 39, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 39, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 17, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 17, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 33, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 22, 6 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 23, 2027, "22 التأثير لهدا الإنجاز", 36, "22 بعد الإنجازات لبعض الأنشطة ", "22 وضعية التنفيد لهدا الإنجاز", "22 معدل الإنجاز لهدا الإنجاز", 40.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 192, 2022, "191 التأثير لهدا الإنجاز", 55, "191 بعد الإنجازات لبعض الأنشطة ", "191 وضعية التنفيد لهدا الإنجاز", "191 معدل الإنجاز لهدا الإنجاز", 62.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 214, 2026, "213 التأثير لهدا الإنجاز", 55, "213 بعد الإنجازات لبعض الأنشطة ", "213 وضعية التنفيد لهدا الإنجاز", "213 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 219, 2029, "218 التأثير لهدا الإنجاز", 59, "218 بعد الإنجازات لبعض الأنشطة ", "218 وضعية التنفيد لهدا الإنجاز", "218 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 210, 2019, "209 التأثير لهدا الإنجاز", 93, "209 بعد الإنجازات لبعض الأنشطة ", "209 وضعية التنفيد لهدا الإنجاز", "209 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 175, 2018, "174 التأثير لهدا الإنجاز", 96, "174 بعد الإنجازات لبعض الأنشطة ", "174 وضعية التنفيد لهدا الإنجاز", "174 معدل الإنجاز لهدا الإنجاز", 29.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 155, 2027, "154 التأثير لهدا الإنجاز", 83, "154 بعد الإنجازات لبعض الأنشطة ", "154 وضعية التنفيد لهدا الإنجاز", "154 معدل الإنجاز لهدا الإنجاز", 72.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 189, 2027, "188 التأثير لهدا الإنجاز", 72, "188 بعد الإنجازات لبعض الأنشطة ", "188 وضعية التنفيد لهدا الإنجاز", "188 معدل الإنجاز لهدا الإنجاز", 33.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 227, 2022, "226 التأثير لهدا الإنجاز", 132, "226 بعد الإنجازات لبعض الأنشطة ", "226 وضعية التنفيد لهدا الإنجاز", "226 معدل الإنجاز لهدا الإنجاز", 94.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 232, 2025, "231 التأثير لهدا الإنجاز", 132, "231 بعد الإنجازات لبعض الأنشطة ", "231 وضعية التنفيد لهدا الإنجاز", "231 معدل الإنجاز لهدا الإنجاز", 20.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 233, 2024, "232 التأثير لهدا الإنجاز", 132, "232 بعد الإنجازات لبعض الأنشطة ", "232 وضعية التنفيد لهدا الإنجاز", "232 معدل الإنجاز لهدا الإنجاز", 3.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 195, 2027, "194 التأثير لهدا الإنجاز", 91, "194 بعد الإنجازات لبعض الأنشطة ", "194 وضعية التنفيد لهدا الإنجاز", "194 معدل الإنجاز لهدا الإنجاز", 49.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 287, 2029, "286 التأثير لهدا الإنجاز", 132, "286 بعد الإنجازات لبعض الأنشطة ", "286 وضعية التنفيد لهدا الإنجاز", "286 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 251, 2024, "250 التأثير لهدا الإنجاز", 123, "250 بعد الإنجازات لبعض الأنشطة ", "250 وضعية التنفيد لهدا الإنجاز", "250 معدل الإنجاز لهدا الإنجاز", 1.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 267, 2023, "266 التأثير لهدا الإنجاز", 131, "266 بعد الإنجازات لبعض الأنشطة ", "266 وضعية التنفيد لهدا الإنجاز", "266 معدل الإنجاز لهدا الإنجاز", 73.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 230, 2019, "229 التأثير لهدا الإنجاز", 117, "229 بعد الإنجازات لبعض الأنشطة ", "229 وضعية التنفيد لهدا الإنجاز", "229 معدل الإنجاز لهدا الإنجاز", 42.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 281, 2023, "280 التأثير لهدا الإنجاز", 117, "280 بعد الإنجازات لبعض الأنشطة ", "280 وضعية التنفيد لهدا الإنجاز", "280 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 226, 2028, "225 التأثير لهدا الإنجاز", 130, "225 بعد الإنجازات لبعض الأنشطة ", "225 وضعية التنفيد لهدا الإنجاز", "225 معدل الإنجاز لهدا الإنجاز", 87.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 260, 2020, "259 التأثير لهدا الإنجاز", 130, "259 بعد الإنجازات لبعض الأنشطة ", "259 وضعية التنفيد لهدا الإنجاز", "259 معدل الإنجاز لهدا الإنجاز", 46.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 269, 2028, "268 التأثير لهدا الإنجاز", 130, "268 بعد الإنجازات لبعض الأنشطة ", "268 وضعية التنفيد لهدا الإنجاز", "268 معدل الإنجاز لهدا الإنجاز", 46.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 277, 2027, "276 التأثير لهدا الإنجاز", 130, "276 بعد الإنجازات لبعض الأنشطة ", "276 وضعية التنفيد لهدا الإنجاز", "276 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 290, 2029, "289 التأثير لهدا الإنجاز", 130, "289 بعد الإنجازات لبعض الأنشطة ", "289 وضعية التنفيد لهدا الإنجاز", "289 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 280, 2018, "279 التأثير لهدا الإنجاز", 138, "279 بعد الإنجازات لبعض الأنشطة ", "279 وضعية التنفيد لهدا الإنجاز", "279 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 236, 2029, "235 التأثير لهدا الإنجاز", 123, "235 بعد الإنجازات لبعض الأنشطة ", "235 وضعية التنفيد لهدا الإنجاز", "235 معدل الإنجاز لهدا الإنجاز", 83.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 234, 2028, "233 التأثير لهدا الإنجاز", 140, "233 بعد الإنجازات لبعض الأنشطة ", "233 وضعية التنفيد لهدا الإنجاز", "233 معدل الإنجاز لهدا الإنجاز", 66.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 176, 2020, "175 التأثير لهدا الإنجاز", 52, "175 بعد الإنجازات لبعض الأنشطة ", "175 وضعية التنفيد لهدا الإنجاز", "175 معدل الإنجاز لهدا الإنجاز", 26.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 217, 2027, "216 التأثير لهدا الإنجاز", 71, "216 بعد الإنجازات لبعض الأنشطة ", "216 وضعية التنفيد لهدا الإنجاز", "216 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 208, 2029, "207 التأثير لهدا الإنجاز", 63, "207 بعد الإنجازات لبعض الأنشطة ", "207 وضعية التنفيد لهدا الإنجاز", "207 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 211, 2019, "210 التأثير لهدا الإنجاز", 70, "210 بعد الإنجازات لبعض الأنشطة ", "210 وضعية التنفيد لهدا الإنجاز", "210 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 170, 2025, "169 التأثير لهدا الإنجاز", 76, "169 بعد الإنجازات لبعض الأنشطة ", "169 وضعية التنفيد لهدا الإنجاز", "169 معدل الإنجاز لهدا الإنجاز", 15.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 164, 2020, "163 التأثير لهدا الإنجاز", 69, "163 بعد الإنجازات لبعض الأنشطة ", "163 وضعية التنفيد لهدا الإنجاز", "163 معدل الإنجاز لهدا الإنجاز", 96.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 203, 2028, "202 التأثير لهدا الإنجاز", 69, "202 بعد الإنجازات لبعض الأنشطة ", "202 وضعية التنفيد لهدا الإنجاز", "202 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 216, 2023, "215 التأثير لهدا الإنجاز", 69, "215 بعد الإنجازات لبعض الأنشطة ", "215 وضعية التنفيد لهدا الإنجاز", "215 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 158, 2024, "157 التأثير لهدا الإنجاز", 67, "157 بعد الإنجازات لبعض الأنشطة ", "157 وضعية التنفيد لهدا الإنجاز", "157 معدل الإنجاز لهدا الإنجاز", 59.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 167, 2018, "166 التأثير لهدا الإنجاز", 86, "166 بعد الإنجازات لبعض الأنشطة ", "166 وضعية التنفيد لهدا الإنجاز", "166 معدل الإنجاز لهدا الإنجاز", 4.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 159, 2027, "158 التأثير لهدا الإنجاز", 92, "158 بعد الإنجازات لبعض الأنشطة ", "158 وضعية التنفيد لهدا الإنجاز", "158 معدل الإنجاز لهدا الإنجاز", 36.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 206, 2019, "205 التأثير لهدا الإنجاز", 58, "205 بعد الإنجازات لبعض الأنشطة ", "205 وضعية التنفيد لهدا الإنجاز", "205 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 160, 2028, "159 التأثير لهدا الإنجاز", 79, "159 بعد الإنجازات لبعض الأنشطة ", "159 وضعية التنفيد لهدا الإنجاز", "159 معدل الإنجاز لهدا الإنجاز", 23.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 212, 2027, "211 التأثير لهدا الإنجاز", 58, "211 بعد الإنجازات لبعض الأنشطة ", "211 وضعية التنفيد لهدا الإنجاز", "211 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 215, 2021, "214 التأثير لهدا الإنجاز", 94, "214 بعد الإنجازات لبعض الأنشطة ", "214 وضعية التنفيد لهدا الإنجاز", "214 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 196, 2029, "195 التأثير لهدا الإنجاز", 53, "195 بعد الإنجازات لبعض الأنشطة ", "195 وضعية التنفيد لهدا الإنجاز", "195 معدل الإنجاز لهدا الإنجاز", 19.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 198, 2027, "197 التأثير لهدا الإنجاز", 66, "197 بعد الإنجازات لبعض الأنشطة ", "197 وضعية التنفيد لهدا الإنجاز", "197 معدل الإنجاز لهدا الإنجاز", 35.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 154, 2018, "153 التأثير لهدا الإنجاز", 82, "153 بعد الإنجازات لبعض الأنشطة ", "153 وضعية التنفيد لهدا الإنجاز", "153 معدل الإنجاز لهدا الإنجاز", 15.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 157, 2024, "156 التأثير لهدا الإنجاز", 80, "156 بعد الإنجازات لبعض الأنشطة ", "156 وضعية التنفيد لهدا الإنجاز", "156 معدل الإنجاز لهدا الإنجاز", 86.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 202, 2026, "201 التأثير لهدا الإنجاز", 80, "201 بعد الإنجازات لبعض الأنشطة ", "201 وضعية التنفيد لهدا الإنجاز", "201 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 218, 2029, "217 التأثير لهدا الإنجاز", 80, "217 بعد الإنجازات لبعض الأنشطة ", "217 وضعية التنفيد لهدا الإنجاز", "217 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 188, 2028, "187 التأثير لهدا الإنجاز", 95, "187 بعد الإنجازات لبعض الأنشطة ", "187 وضعية التنفيد لهدا الإنجاز", "187 معدل الإنجاز لهدا الإنجاز", 59.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 191, 2026, "190 التأثير لهدا الإنجاز", 71, "190 بعد الإنجازات لبعض الأنشطة ", "190 وضعية التنفيد لهدا الإنجاز", "190 معدل الإنجاز لهدا الإنجاز", 9.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 207, 2024, "206 التأثير لهدا الإنجاز", 71, "206 بعد الإنجازات لبعض الأنشطة ", "206 وضعية التنفيد لهدا الإنجاز", "206 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 169, 2022, "168 التأثير لهدا الإنجاز", 94, "168 بعد الإنجازات لبعض الأنشطة ", "168 وضعية التنفيد لهدا الإنجاز", "168 معدل الإنجاز لهدا الإنجاز", 19.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 242, 2018, "241 التأثير لهدا الإنجاز", 140, "241 بعد الإنجازات لبعض الأنشطة ", "241 وضعية التنفيد لهدا الإنجاز", "241 معدل الإنجاز لهدا الإنجاز", 56.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 247, 2019, "246 التأثير لهدا الإنجاز", 148, "246 بعد الإنجازات لبعض الأنشطة ", "246 وضعية التنفيد لهدا الإنجاز", "246 معدل الإنجاز لهدا الإنجاز", 24.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 246, 2028, "245 التأثير لهدا الإنجاز", 101, "245 بعد الإنجازات لبعض الأنشطة ", "245 وضعية التنفيد لهدا الإنجاز", "245 معدل الإنجاز لهدا الإنجاز", 52.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 238, 2022, "237 التأثير لهدا الإنجاز", 134, "237 بعد الإنجازات لبعض الأنشطة ", "237 وضعية التنفيد لهدا الإنجاز", "237 معدل الإنجاز لهدا الإنجاز", 79.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 231, 2021, "230 التأثير لهدا الإنجاز", 125, "230 بعد الإنجازات لبعض الأنشطة ", "230 وضعية التنفيد لهدا الإنجاز", "230 معدل الإنجاز لهدا الإنجاز", 89.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 252, 2028, "251 التأثير لهدا الإنجاز", 125, "251 بعد الإنجازات لبعض الأنشطة ", "251 وضعية التنفيد لهدا الإنجاز", "251 معدل الإنجاز لهدا الإنجاز", 94.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 285, 2024, "284 التأثير لهدا الإنجاز", 125, "284 بعد الإنجازات لبعض الأنشطة ", "284 وضعية التنفيد لهدا الإنجاز", "284 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 264, 2027, "263 التأثير لهدا الإنجاز", 145, "263 بعد الإنجازات لبعض الأنشطة ", "263 وضعية التنفيد لهدا الإنجاز", "263 معدل الإنجاز لهدا الإنجاز", 56.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 283, 2029, "282 التأثير لهدا الإنجاز", 145, "282 بعد الإنجازات لبعض الأنشطة ", "282 وضعية التنفيد لهدا الإنجاز", "282 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 254, 2023, "253 التأثير لهدا الإنجاز", 147, "253 بعد الإنجازات لبعض الأنشطة ", "253 وضعية التنفيد لهدا الإنجاز", "253 معدل الإنجاز لهدا الإنجاز", 93.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 263, 2022, "262 التأثير لهدا الإنجاز", 127, "262 بعد الإنجازات لبعض الأنشطة ", "262 وضعية التنفيد لهدا الإنجاز", "262 معدل الإنجاز لهدا الإنجاز", 9.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 239, 2027, "238 التأثير لهدا الإنجاز", 105, "238 بعد الإنجازات لبعض الأنشطة ", "238 وضعية التنفيد لهدا الإنجاز", "238 معدل الإنجاز لهدا الإنجاز", 44.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 249, 2025, "248 التأثير لهدا الإنجاز", 105, "248 بعد الإنجازات لبعض الأنشطة ", "248 وضعية التنفيد لهدا الإنجاز", "248 معدل الإنجاز لهدا الإنجاز", 96.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 265, 2020, "264 التأثير لهدا الإنجاز", 115, "264 بعد الإنجازات لبعض الأنشطة ", "264 وضعية التنفيد لهدا الإنجاز", "264 معدل الإنجاز لهدا الإنجاز", 69.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 261, 2026, "260 التأثير لهدا الإنجاز", 105, "260 بعد الإنجازات لبعض الأنشطة ", "260 وضعية التنفيد لهدا الإنجاز", "260 معدل الإنجاز لهدا الإنجاز", 23.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 228, 2020, "227 التأثير لهدا الإنجاز", 116, "227 بعد الإنجازات لبعض الأنشطة ", "227 وضعية التنفيد لهدا الإنجاز", "227 معدل الإنجاز لهدا الإنجاز", 41.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 256, 2028, "255 التأثير لهدا الإنجاز", 116, "255 بعد الإنجازات لبعض الأنشطة ", "255 وضعية التنفيد لهدا الإنجاز", "255 معدل الإنجاز لهدا الإنجاز", 37.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 262, 2022, "261 التأثير لهدا الإنجاز", 116, "261 بعد الإنجازات لبعض الأنشطة ", "261 وضعية التنفيد لهدا الإنجاز", "261 معدل الإنجاز لهدا الإنجاز", 94.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 286, 2026, "285 التأثير لهدا الإنجاز", 116, "285 بعد الإنجازات لبعض الأنشطة ", "285 وضعية التنفيد لهدا الإنجاز", "285 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 250, 2027, "249 التأثير لهدا الإنجاز", 139, "249 بعد الإنجازات لبعض الأنشطة ", "249 وضعية التنفيد لهدا الإنجاز", "249 معدل الإنجاز لهدا الإنجاز", 82.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 225, 2024, "224 التأثير لهدا الإنجاز", 107, "224 بعد الإنجازات لبعض الأنشطة ", "224 وضعية التنفيد لهدا الإنجاز", "224 معدل الإنجاز لهدا الإنجاز", 35.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 255, 2021, "254 التأثير لهدا الإنجاز", 142, "254 بعد الإنجازات لبعض الأنشطة ", "254 وضعية التنفيد لهدا الإنجاز", "254 معدل الإنجاز لهدا الإنجاز", 78.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 268, 2027, "267 التأثير لهدا الإنجاز", 142, "267 بعد الإنجازات لبعض الأنشطة ", "267 وضعية التنفيد لهدا الإنجاز", "267 معدل الإنجاز لهدا الإنجاز", 41.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 223, 2021, "222 التأثير لهدا الإنجاز", 120, "222 بعد الإنجازات لبعض الأنشطة ", "222 وضعية التنفيد لهدا الإنجاز", "222 معدل الإنجاز لهدا الإنجاز", 93.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 243, 2018, "242 التأثير لهدا الإنجاز", 108, "242 بعد الإنجازات لبعض الأنشطة ", "242 وضعية التنفيد لهدا الإنجاز", "242 معدل الإنجاز لهدا الإنجاز", 90.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 222, 2027, "221 التأثير لهدا الإنجاز", 116, "221 بعد الإنجازات لبعض الأنشطة ", "221 وضعية التنفيد لهدا الإنجاز", "221 معدل الإنجاز لهدا الإنجاز", 52.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 245, 2029, "244 التأثير لهدا الإنجاز", 115, "244 بعد الإنجازات لبعض الأنشطة ", "244 وضعية التنفيد لهدا الإنجاز", "244 معدل الإنجاز لهدا الإنجاز", 48.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 235, 2026, "234 التأثير لهدا الإنجاز", 111, "234 بعد الإنجازات لبعض الأنشطة ", "234 وضعية التنفيد لهدا الإنجاز", "234 معدل الإنجاز لهدا الإنجاز", 40.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 289, 2026, "288 التأثير لهدا الإنجاز", 146, "288 بعد الإنجازات لبعض الأنشطة ", "288 وضعية التنفيد لهدا الإنجاز", "288 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 272, 2020, "271 التأثير لهدا الإنجاز", 113, "271 بعد الإنجازات لبعض الأنشطة ", "271 وضعية التنفيد لهدا الإنجاز", "271 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 284, 2027, "283 التأثير لهدا الإنجاز", 113, "283 بعد الإنجازات لبعض الأنشطة ", "283 وضعية التنفيد لهدا الإنجاز", "283 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 229, 2020, "228 التأثير لهدا الإنجاز", 118, "228 بعد الإنجازات لبعض الأنشطة ", "228 وضعية التنفيد لهدا الإنجاز", "228 معدل الإنجاز لهدا الإنجاز", 78.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 258, 2018, "257 التأثير لهدا الإنجاز", 118, "257 بعد الإنجازات لبعض الأنشطة ", "257 وضعية التنفيد لهدا الإنجاز", "257 معدل الإنجاز لهدا الإنجاز", 42.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 259, 2027, "258 التأثير لهدا الإنجاز", 118, "258 بعد الإنجازات لبعض الأنشطة ", "258 وضعية التنفيد لهدا الإنجاز", "258 معدل الإنجاز لهدا الإنجاز", 4.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 221, 2025, "220 التأثير لهدا الإنجاز", 143, "220 بعد الإنجازات لبعض الأنشطة ", "220 وضعية التنفيد لهدا الإنجاز", "220 معدل الإنجاز لهدا الإنجاز", 50.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 244, 2023, "243 التأثير لهدا الإنجاز", 143, "243 بعد الإنجازات لبعض الأنشطة ", "243 وضعية التنفيد لهدا الإنجاز", "243 معدل الإنجاز لهدا الإنجاز", 32.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 253, 2021, "252 التأثير لهدا الإنجاز", 143, "252 بعد الإنجازات لبعض الأنشطة ", "252 وضعية التنفيد لهدا الإنجاز", "252 معدل الإنجاز لهدا الإنجاز", 63.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 248, 2028, "247 التأثير لهدا الإنجاز", 114, "247 بعد الإنجازات لبعض الأنشطة ", "247 وضعية التنفيد لهدا الإنجاز", "247 معدل الإنجاز لهدا الإنجاز", 81.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 276, 2023, "275 التأثير لهدا الإنجاز", 114, "275 بعد الإنجازات لبعض الأنشطة ", "275 وضعية التنفيد لهدا الإنجاز", "275 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 224, 2028, "223 التأثير لهدا الإنجاز", 126, "223 بعد الإنجازات لبعض الأنشطة ", "223 وضعية التنفيد لهدا الإنجاز", "223 معدل الإنجاز لهدا الإنجاز", 67.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 241, 2029, "240 التأثير لهدا الإنجاز", 126, "240 بعد الإنجازات لبعض الأنشطة ", "240 وضعية التنفيد لهدا الإنجاز", "240 معدل الإنجاز لهدا الإنجاز", 18.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 275, 2028, "274 التأثير لهدا الإنجاز", 126, "274 بعد الإنجازات لبعض الأنشطة ", "274 وضعية التنفيد لهدا الإنجاز", "274 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 288, 2026, "287 التأثير لهدا الإنجاز", 126, "287 بعد الإنجازات لبعض الأنشطة ", "287 وضعية التنفيد لهدا الإنجاز", "287 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 271, 2019, "270 التأثير لهدا الإنجاز", 103, "270 بعد الإنجازات لبعض الأنشطة ", "270 وضعية التنفيد لهدا الإنجاز", "270 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 237, 2021, "236 التأثير لهدا الإنجاز", 136, "236 بعد الإنجازات لبعض الأنشطة ", "236 وضعية التنفيد لهدا الإنجاز", "236 معدل الإنجاز لهدا الإنجاز", 14.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 273, 2026, "272 التأثير لهدا الإنجاز", 136, "272 بعد الإنجازات لبعض الأنشطة ", "272 وضعية التنفيد لهدا الإنجاز", "272 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 240, 2024, "239 التأثير لهدا الإنجاز", 137, "239 بعد الإنجازات لبعض الأنشطة ", "239 وضعية التنفيد لهدا الإنجاز", "239 معدل الإنجاز لهدا الإنجاز", 58.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 279, 2028, "278 التأثير لهدا الإنجاز", 137, "278 بعد الإنجازات لبعض الأنشطة ", "278 وضعية التنفيد لهدا الإنجاز", "278 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 282, 2027, "281 التأثير لهدا الإنجاز", 137, "281 بعد الإنجازات لبعض الأنشطة ", "281 وضعية التنفيد لهدا الإنجاز", "281 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 257, 2022, "256 التأثير لهدا الإنجاز", 146, "256 بعد الإنجازات لبعض الأنشطة ", "256 وضعية التنفيد لهدا الإنجاز", "256 معدل الإنجاز لهدا الإنجاز", 98.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 270, 2019, "269 التأثير لهدا الإنجاز", 146, "269 بعد الإنجازات لبعض الأنشطة ", "269 وضعية التنفيد لهدا الإنجاز", "269 معدل الإنجاز لهدا الإنجاز", 10.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 274, 2028, "273 التأثير لهدا الإنجاز", 146, "273 بعد الإنجازات لبعض الأنشطة ", "273 وضعية التنفيد لهدا الإنجاز", "273 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 165, 2021, "164 التأثير لهدا الإنجاز", 63, "164 بعد الإنجازات لبعض الأنشطة ", "164 وضعية التنفيد لهدا الإنجاز", "164 معدل الإنجاز لهدا الإنجاز", 55.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 197, 2023, "196 التأثير لهدا الإنجاز", 74, "196 بعد الإنجازات لبعض الأنشطة ", "196 وضعية التنفيد لهدا الإنجاز", "196 معدل الإنجاز لهدا الإنجاز", 68.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 173, 2018, "172 التأثير لهدا الإنجاز", 74, "172 بعد الإنجازات لبعض الأنشطة ", "172 وضعية التنفيد لهدا الإنجاز", "172 معدل الإنجاز لهدا الإنجاز", 92.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 220, 2025, "219 التأثير لهدا الإنجاز", 73, "219 بعد الإنجازات لبعض الأنشطة ", "219 وضعية التنفيد لهدا الإنجاز", "219 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 24, 2019, "23 التأثير لهدا الإنجاز", 22, "23 بعد الإنجازات لبعض الأنشطة ", "23 وضعية التنفيد لهدا الإنجاز", "23 معدل الإنجاز لهدا الإنجاز", 63.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 5, 2028, "4 التأثير لهدا الإنجاز", 23, "4 بعد الإنجازات لبعض الأنشطة ", "4 وضعية التنفيد لهدا الإنجاز", "4 معدل الإنجاز لهدا الإنجاز", 11.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 58, 2024, "57 التأثير لهدا الإنجاز", 23, "57 بعد الإنجازات لبعض الأنشطة ", "57 وضعية التنفيد لهدا الإنجاز", "57 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 33, 2021, "32 التأثير لهدا الإنجاز", 19, "32 بعد الإنجازات لبعض الأنشطة ", "32 وضعية التنفيد لهدا الإنجاز", "32 معدل الإنجاز لهدا الإنجاز", 7.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 1, 2023, "0 التأثير لهدا الإنجاز", 46, "0 بعد الإنجازات لبعض الأنشطة ", "0 وضعية التنفيد لهدا الإنجاز", "0 معدل الإنجاز لهدا الإنجاز", 78.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 21, 2024, "20 التأثير لهدا الإنجاز", 46, "20 بعد الإنجازات لبعض الأنشطة ", "20 وضعية التنفيد لهدا الإنجاز", "20 معدل الإنجاز لهدا الإنجاز", 95.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 55, 2026, "54 التأثير لهدا الإنجاز", 46, "54 بعد الإنجازات لبعض الأنشطة ", "54 وضعية التنفيد لهدا الإنجاز", "54 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 52, 2029, "51 التأثير لهدا الإنجاز", 8, "51 بعد الإنجازات لبعض الأنشطة ", "51 وضعية التنفيد لهدا الإنجاز", "51 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 26, 2018, "25 التأثير لهدا الإنجاز", 26, "25 بعد الإنجازات لبعض الأنشطة ", "25 وضعية التنفيد لهدا الإنجاز", "25 معدل الإنجاز لهدا الإنجاز", 70.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 67, 2021, "66 التأثير لهدا الإنجاز", 34, "66 بعد الإنجازات لبعض الأنشطة ", "66 وضعية التنفيد لهدا الإنجاز", "66 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 6, 2019, "5 التأثير لهدا الإنجاز", 22, "5 بعد الإنجازات لبعض الأنشطة ", "5 وضعية التنفيد لهدا الإنجاز", "5 معدل الإنجاز لهدا الإنجاز", 48.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 16, 2024, "15 التأثير لهدا الإنجاز", 2, "15 بعد الإنجازات لبعض الأنشطة ", "15 وضعية التنفيد لهدا الإنجاز", "15 معدل الإنجاز لهدا الإنجاز", 74.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 8, 2025, "7 التأثير لهدا الإنجاز", 17, "7 بعد الإنجازات لبعض الأنشطة ", "7 وضعية التنفيد لهدا الإنجاز", "7 معدل الإنجاز لهدا الإنجاز", 68.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 18, 2022, "17 التأثير لهدا الإنجاز", 17, "17 بعد الإنجازات لبعض الأنشطة ", "17 وضعية التنفيد لهدا الإنجاز", "17 معدل الإنجاز لهدا الإنجاز", 9.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 34, 2027, "33 التأثير لهدا الإنجاز", 17, "33 بعد الإنجازات لبعض الأنشطة ", "33 وضعية التنفيد لهدا الإنجاز", "33 معدل الإنجاز لهدا الإنجاز", 75.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 51, 2029, "50 التأثير لهدا الإنجاز", 42, "50 بعد الإنجازات لبعض الأنشطة ", "50 وضعية التنفيد لهدا الإنجاز", "50 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 69, 2026, "68 التأثير لهدا الإنجاز", 50, "68 بعد الإنجازات لبعض الأنشطة ", "68 وضعية التنفيد لهدا الإنجاز", "68 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 49, 2024, "48 التأثير لهدا الإنجاز", 29, "48 بعد الإنجازات لبعض الأنشطة ", "48 وضعية التنفيد لهدا الإنجاز", "48 معدل الإنجاز لهدا الإنجاز", 59.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 59, 2023, "58 التأثير لهدا الإنجاز", 48, "58 بعد الإنجازات لبعض الأنشطة ", "58 وضعية التنفيد لهدا الإنجاز", "58 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 60, 2028, "59 التأثير لهدا الإنجاز", 48, "59 بعد الإنجازات لبعض الأنشطة ", "59 وضعية التنفيد لهدا الإنجاز", "59 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 68, 2020, "67 التأثير لهدا الإنجاز", 48, "67 بعد الإنجازات لبعض الأنشطة ", "67 وضعية التنفيد لهدا الإنجاز", "67 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 30, 2026, "29 التأثير لهدا الإنجاز", 31, "29 بعد الإنجازات لبعض الأنشطة ", "29 وضعية التنفيد لهدا الإنجاز", "29 معدل الإنجاز لهدا الإنجاز", 10.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 48, 2026, "47 التأثير لهدا الإنجاز", 40, "47 بعد الإنجازات لبعض الأنشطة ", "47 وضعية التنفيد لهدا الإنجاز", "47 معدل الإنجاز لهدا الإنجاز", 9.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 54, 2018, "53 التأثير لهدا الإنجاز", 10, "53 بعد الإنجازات لبعض الأنشطة ", "53 وضعية التنفيد لهدا الإنجاز", "53 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 14, 2025, "13 التأثير لهدا الإنجاز", 10, "13 بعد الإنجازات لبعض الأنشطة ", "13 وضعية التنفيد لهدا الإنجاز", "13 معدل الإنجاز لهدا الإنجاز", 50.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 27, 2020, "26 التأثير لهدا الإنجاز", 4, "26 بعد الإنجازات لبعض الأنشطة ", "26 وضعية التنفيد لهدا الإنجاز", "26 معدل الإنجاز لهدا الإنجاز", 35.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 42, 2019, "41 التأثير لهدا الإنجاز", 36, "41 بعد الإنجازات لبعض الأنشطة ", "41 وضعية التنفيد لهدا الإنجاز", "41 معدل الإنجاز لهدا الإنجاز", 98.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 46, 2026, "45 التأثير لهدا الإنجاز", 36, "45 بعد الإنجازات لبعض الأنشطة ", "45 وضعية التنفيد لهدا الإنجاز", "45 معدل الإنجاز لهدا الإنجاز", 64.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 13, 2023, "12 التأثير لهدا الإنجاز", 6, "12 بعد الإنجازات لبعض الأنشطة ", "12 وضعية التنفيد لهدا الإنجاز", "12 معدل الإنجاز لهدا الإنجاز", 6.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 15, 2029, "14 التأثير لهدا الإنجاز", 6, "14 بعد الإنجازات لبعض الأنشطة ", "14 وضعية التنفيد لهدا الإنجاز", "14 معدل الإنجاز لهدا الإنجاز", 18.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 56, 2028, "55 التأثير لهدا الإنجاز", 6, "55 بعد الإنجازات لبعض الأنشطة ", "55 وضعية التنفيد لهدا الإنجاز", "55 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 3, 2020, "2 التأثير لهدا الإنجاز", 7, "2 بعد الإنجازات لبعض الأنشطة ", "2 وضعية التنفيد لهدا الإنجاز", "2 معدل الإنجاز لهدا الإنجاز", 63.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 63, 2025, "62 التأثير لهدا الإنجاز", 7, "62 بعد الإنجازات لبعض الأنشطة ", "62 وضعية التنفيد لهدا الإنجاز", "62 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 35, 2021, "34 التأثير لهدا الإنجاز", 32, "34 بعد الإنجازات لبعض الأنشطة ", "34 وضعية التنفيد لهدا الإنجاز", "34 معدل الإنجاز لهدا الإنجاز", 71.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 44, 2020, "43 التأثير لهدا الإنجاز", 32, "43 بعد الإنجازات لبعض الأنشطة ", "43 وضعية التنفيد لهدا الإنجاز", "43 معدل الإنجاز لهدا الإنجاز", 78.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 53, 2029, "52 التأثير لهدا الإنجاز", 32, "52 بعد الإنجازات لبعض الأنشطة ", "52 وضعية التنفيد لهدا الإنجاز", "52 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 64, 2018, "63 التأثير لهدا الإنجاز", 27, "63 بعد الإنجازات لبعض الأنشطة ", "63 وضعية التنفيد لهدا الإنجاز", "63 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 20, 2024, "19 التأثير لهدا الإنجاز", 38, "19 بعد الإنجازات لبعض الأنشطة ", "19 وضعية التنفيد لهدا الإنجاز", "19 معدل الإنجاز لهدا الإنجاز", 84.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 36, 2018, "35 التأثير لهدا الإنجاز", 38, "35 بعد الإنجازات لبعض الأنشطة ", "35 وضعية التنفيد لهدا الإنجاز", "35 معدل الإنجاز لهدا الإنجاز", 6.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 32, 2022, "31 التأثير لهدا الإنجاز", 28, "31 بعد الإنجازات لبعض الأنشطة ", "31 وضعية التنفيد لهدا الإنجاز", "31 معدل الإنجاز لهدا الإنجاز", 11.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 39, 2026, "38 التأثير لهدا الإنجاز", 28, "38 بعد الإنجازات لبعض الأنشطة ", "38 وضعية التنفيد لهدا الإنجاز", "38 معدل الإنجاز لهدا الإنجاز", 55.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 47, 2028, "46 التأثير لهدا الإنجاز", 28, "46 بعد الإنجازات لبعض الأنشطة ", "46 وضعية التنفيد لهدا الإنجاز", "46 معدل الإنجاز لهدا الإنجاز", 71.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 50, 2026, "49 التأثير لهدا الإنجاز", 28, "49 بعد الإنجازات لبعض الأنشطة ", "49 وضعية التنفيد لهدا الإنجاز", "49 معدل الإنجاز لهدا الإنجاز", 67.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 65, 2025, "64 التأثير لهدا الإنجاز", 20, "64 بعد الإنجازات لبعض الأنشطة ", "64 وضعية التنفيد لهدا الإنجاز", "64 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 31, 2020, "30 التأثير لهدا الإنجاز", 11, "30 بعد الإنجازات لبعض الأنشطة ", "30 وضعية التنفيد لهدا الإنجاز", "30 معدل الإنجاز لهدا الإنجاز", 91.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 40, 2023, "39 التأثير لهدا الإنجاز", 11, "39 بعد الإنجازات لبعض الأنشطة ", "39 وضعية التنفيد لهدا الإنجاز", "39 معدل الإنجاز لهدا الإنجاز", 12.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 43, 2020, "42 التأثير لهدا الإنجاز", 11, "42 بعد الإنجازات لبعض الأنشطة ", "42 وضعية التنفيد لهدا الإنجاز", "42 معدل الإنجاز لهدا الإنجاز", 94.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 7, 2029, "6 التأثير لهدا الإنجاز", 13, "6 بعد الإنجازات لبعض الأنشطة ", "6 وضعية التنفيد لهدا الإنجاز", "6 معدل الإنجاز لهدا الإنجاز", 24.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 10, 2021, "9 التأثير لهدا الإنجاز", 13, "9 بعد الإنجازات لبعض الأنشطة ", "9 وضعية التنفيد لهدا الإنجاز", "9 معدل الإنجاز لهدا الإنجاز", 72.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 45, 2019, "44 التأثير لهدا الإنجاز", 31, "44 بعد الإنجازات لبعض الأنشطة ", "44 وضعية التنفيد لهدا الإنجاز", "44 معدل الإنجاز لهدا الإنجاز", 40.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 266, 2018, "265 التأثير لهدا الإنجاز", 102, "265 بعد الإنجازات لبعض الأنشطة ", "265 وضعية التنفيد لهدا الإنجاز", "265 معدل الإنجاز لهدا الإنجاز", 61.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 41, 2027, "40 التأثير لهدا الإنجاز", 16, "40 بعد الإنجازات لبعض الأنشطة ", "40 وضعية التنفيد لهدا الإنجاز", "40 معدل الإنجاز لهدا الإنجاز", 13.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 62, 2025, "61 التأثير لهدا الإنجاز", 21, "61 بعد الإنجازات لبعض الأنشطة ", "61 وضعية التنفيد لهدا الإنجاز", "61 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 204, 2021, "203 التأثير لهدا الإنجاز", 85, "203 بعد الإنجازات لبعض الأنشطة ", "203 وضعية التنفيد لهدا الإنجاز", "203 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 161, 2027, "160 التأثير لهدا الإنجاز", 78, "160 بعد الإنجازات لبعض الأنشطة ", "160 وضعية التنفيد لهدا الإنجاز", "160 معدل الإنجاز لهدا الإنجاز", 46.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 166, 2024, "165 التأثير لهدا الإنجاز", 78, "165 بعد الإنجازات لبعض الأنشطة ", "165 وضعية التنفيد لهدا الإنجاز", "165 معدل الإنجاز لهدا الإنجاز", 65.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 168, 2019, "167 التأثير لهدا الإنجاز", 78, "167 بعد الإنجازات لبعض الأنشطة ", "167 وضعية التنفيد لهدا الإنجاز", "167 معدل الإنجاز لهدا الإنجاز", 48.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 174, 2020, "173 التأثير لهدا الإنجاز", 78, "173 بعد الإنجازات لبعض الأنشطة ", "173 وضعية التنفيد لهدا الإنجاز", "173 معدل الإنجاز لهدا الإنجاز", 29.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 185, 2019, "184 التأثير لهدا الإنجاز", 88, "184 بعد الإنجازات لبعض الأنشطة ", "184 وضعية التنفيد لهدا الإنجاز", "184 معدل الإنجاز لهدا الإنجاز", 81.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 156, 2019, "155 التأثير لهدا الإنجاز", 77, "155 بعد الإنجازات لبعض الأنشطة ", "155 وضعية التنفيد لهدا الإنجاز", "155 معدل الإنجاز لهدا الإنجاز", 23.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 163, 2028, "162 التأثير لهدا الإنجاز", 77, "162 بعد الإنجازات لبعض الأنشطة ", "162 وضعية التنفيد لهدا الإنجاز", "162 معدل الإنجاز لهدا الإنجاز", 68.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 181, 2024, "180 التأثير لهدا الإنجاز", 77, "180 بعد الإنجازات لبعض الأنشطة ", "180 وضعية التنفيد لهدا الإنجاز", "180 معدل الإنجاز لهدا الإنجاز", 21.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 187, 2025, "186 التأثير لهدا الإنجاز", 97, "186 بعد الإنجازات لبعض الأنشطة ", "186 وضعية التنفيد لهدا الإنجاز", "186 معدل الإنجاز لهدا الإنجاز", 20.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 201, 2020, "200 التأثير لهدا الإنجاز", 85, "200 بعد الإنجازات لبعض الأنشطة ", "200 وضعية التنفيد لهدا الإنجاز", "200 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 213, 2020, "212 التأثير لهدا الإنجاز", 97, "212 بعد الإنجازات لبعض الأنشطة ", "212 وضعية التنفيد لهدا الإنجاز", "212 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 183, 2029, "182 التأثير لهدا الإنجاز", 64, "182 بعد الإنجازات لبعض الأنشطة ", "182 وضعية التنفيد لهدا الإنجاز", "182 معدل الإنجاز لهدا الإنجاز", 57.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 200, 2025, "199 التأثير لهدا الإنجاز", 64, "199 بعد الإنجازات لبعض الأنشطة ", "199 وضعية التنفيد لهدا الإنجاز", "199 معدل الإنجاز لهدا الإنجاز", 20.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 184, 2024, "183 التأثير لهدا الإنجاز", 87, "183 بعد الإنجازات لبعض الأنشطة ", "183 وضعية التنفيد لهدا الإنجاز", "183 معدل الإنجاز لهدا الإنجاز", 44.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 179, 2028, "178 التأثير لهدا الإنجاز", 99, "178 بعد الإنجازات لبعض الأنشطة ", "178 وضعية التنفيد لهدا الإنجاز", "178 معدل الإنجاز لهدا الإنجاز", 61.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 199, 2019, "198 التأثير لهدا الإنجاز", 81, "198 بعد الإنجازات لبعض الأنشطة ", "198 وضعية التنفيد لهدا الإنجاز", "198 معدل الإنجاز لهدا الإنجاز", 74.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 180, 2029, "179 التأثير لهدا الإنجاز", 54, "179 بعد الإنجازات لبعض الأنشطة ", "179 وضعية التنفيد لهدا الإنجاز", "179 معدل الإنجاز لهدا الإنجاز", 51.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 209, 2018, "208 التأثير لهدا الإنجاز", 56, "208 بعد الإنجازات لبعض الأنشطة ", "208 وضعية التنفيد لهدا الإنجاز", "208 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 152, 2029, "151 التأثير لهدا الإنجاز", 73, "151 بعد الإنجازات لبعض الأنشطة ", "151 وضعية التنفيد لهدا الإنجاز", "151 معدل الإنجاز لهدا الإنجاز", 87.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 162, 2028, "161 التأثير لهدا الإنجاز", 73, "161 بعد الإنجازات لبعض الأنشطة ", "161 وضعية التنفيد لهدا الإنجاز", "161 معدل الإنجاز لهدا الإنجاز", 26.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 171, 2025, "170 التأثير لهدا الإنجاز", 73, "170 بعد الإنجازات لبعض الأنشطة ", "170 وضعية التنفيد لهدا الإنجاز", "170 معدل الإنجاز لهدا الإنجاز", 29.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 153, 2019, "152 التأثير لهدا الإنجاز", 64, "152 بعد الإنجازات لبعض الأنشطة ", "152 وضعية التنفيد لهدا الإنجاز", "152 معدل الإنجاز لهدا الإنجاز", 67.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 194, 2020, "193 التأثير لهدا الإنجاز", 85, "193 بعد الإنجازات لبعض الأنشطة ", "193 وضعية التنفيد لهدا الإنجاز", "193 معدل الإنجاز لهدا الإنجاز", 28.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 193, 2018, "192 التأثير لهدا الإنجاز", 85, "192 بعد الإنجازات لبعض الأنشطة ", "192 وضعية التنفيد لهدا الإنجاز", "192 معدل الإنجاز لهدا الإنجاز", 99.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 177, 2018, "176 التأثير لهدا الإنجاز", 85, "176 بعد الإنجازات لبعض الأنشطة ", "176 وضعية التنفيد لهدا الإنجاز", "176 معدل الإنجاز لهدا الإنجاز", 26.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 4, 2027, "3 التأثير لهدا الإنجاز", 41, "3 بعد الإنجازات لبعض الأنشطة ", "3 وضعية التنفيد لهدا الإنجاز", "3 معدل الإنجاز لهدا الإنجاز", 85.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 9, 2028, "8 التأثير لهدا الإنجاز", 49, "8 بعد الإنجازات لبعض الأنشطة ", "8 وضعية التنفيد لهدا الإنجاز", "8 معدل الإنجاز لهدا الإنجاز", 80.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 70, 2022, "69 التأثير لهدا الإنجاز", 49, "69 بعد الإنجازات لبعض الأنشطة ", "69 وضعية التنفيد لهدا الإنجاز", "69 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 11, 2029, "10 التأثير لهدا الإنجاز", 1, "10 بعد الإنجازات لبعض الأنشطة ", "10 وضعية التنفيد لهدا الإنجاز", "10 معدل الإنجاز لهدا الإنجاز", 55.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 25, 2021, "24 التأثير لهدا الإنجاز", 37, "24 بعد الإنجازات لبعض الأنشطة ", "24 وضعية التنفيد لهدا الإنجاز", "24 معدل الإنجاز لهدا الإنجاز", 33.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 2, 2027, "1 التأثير لهدا الإنجاز", 24, "1 بعد الإنجازات لبعض الأنشطة ", "1 وضعية التنفيد لهدا الإنجاز", "1 معدل الإنجاز لهدا الإنجاز", 56.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 17, 2028, "16 التأثير لهدا الإنجاز", 24, "16 بعد الإنجازات لبعض الأنشطة ", "16 وضعية التنفيد لهدا الإنجاز", "16 معدل الإنجاز لهدا الإنجاز", 26.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 28, 2029, "27 التأثير لهدا الإنجاز", 24, "27 بعد الإنجازات لبعض الأنشطة ", "27 وضعية التنفيد لهدا الإنجاز", "27 معدل الإنجاز لهدا الإنجاز", 41.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 29, 2027, "28 التأثير لهدا الإنجاز", 24, "28 بعد الإنجازات لبعض الأنشطة ", "28 وضعية التنفيد لهدا الإنجاز", "28 معدل الإنجاز لهدا الإنجاز", 60.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 38, 2025, "37 التأثير لهدا الإنجاز", 25, "37 بعد الإنجازات لبعض الأنشطة ", "37 وضعية التنفيد لهدا الإنجاز", "37 معدل الإنجاز لهدا الإنجاز", 35.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 66, 2019, "65 التأثير لهدا الإنجاز", 25, "65 بعد الإنجازات لبعض الأنشطة ", "65 وضعية التنفيد لهدا الإنجاز", "65 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 19, 2022, "18 التأثير لهدا الإنجاز", 5, "18 بعد الإنجازات لبعض الأنشطة ", "18 وضعية التنفيد لهدا الإنجاز", "18 معدل الإنجاز لهدا الإنجاز", 79.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 37, 2025, "36 التأثير لهدا الإنجاز", 5, "36 بعد الإنجازات لبعض الأنشطة ", "36 وضعية التنفيد لهدا الإنجاز", "36 معدل الإنجاز لهدا الإنجاز", 31.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 22, 2028, "21 التأثير لهدا الإنجاز", 15, "21 بعد الإنجازات لبعض الأنشطة ", "21 وضعية التنفيد لهدا الإنجاز", "21 معدل الإنجاز لهدا الإنجاز", 81.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 61, 2028, "60 التأثير لهدا الإنجاز", 43, "60 بعد الإنجازات لبعض الأنشطة ", "60 وضعية التنفيد لهدا الإنجاز", "60 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 12, 2023, "11 التأثير لهدا الإنجاز", 14, "11 بعد الإنجازات لبعض الأنشطة ", "11 وضعية التنفيد لهدا الإنجاز", "11 معدل الإنجاز لهدا الإنجاز", 39.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 182, 2018, "181 التأثير لهدا الإنجاز", 84, "181 بعد الإنجازات لبعض الأنشطة ", "181 وضعية التنفيد لهدا الإنجاز", "181 معدل الإنجاز لهدا الإنجاز", 60.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 190, 2021, "189 التأثير لهدا الإنجاز", 84, "189 بعد الإنجازات لبعض الأنشطة ", "189 وضعية التنفيد لهدا الإنجاز", "189 معدل الإنجاز لهدا الإنجاز", 82.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 205, 2020, "204 التأثير لهدا الإنجاز", 84, "204 بعد الإنجازات لبعض الأنشطة ", "204 وضعية التنفيد لهدا الإنجاز", "204 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 151, 2026, "150 التأثير لهدا الإنجاز", 100, "150 بعد الإنجازات لبعض الأنشطة ", "150 وضعية التنفيد لهدا الإنجاز", "150 معدل الإنجاز لهدا الإنجاز", 46.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 178, 2021, "177 التأثير لهدا الإنجاز", 60, "177 بعد الإنجازات لبعض الأنشطة ", "177 وضعية التنفيد لهدا الإنجاز", "177 معدل الإنجاز لهدا الإنجاز", 86.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 186, 2020, "185 التأثير لهدا الإنجاز", 60, "185 بعد الإنجازات لبعض الأنشطة ", "185 وضعية التنفيد لهدا الإنجاز", "185 معدل الإنجاز لهدا الإنجاز", 15.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 172, 2026, "171 التأثير لهدا الإنجاز", 85, "171 بعد الإنجازات لبعض الأنشطة ", "171 وضعية التنفيد لهدا الإنجاز", "171 معدل الإنجاز لهدا الإنجاز", 29.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 57, 2024, "56 التأثير لهدا الإنجاز", 21, "56 بعد الإنجازات لبعض الأنشطة ", "56 وضعية التنفيد لهدا الإنجاز", "56 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 278, 2023, "277 التأثير لهدا الإنجاز", 102, "277 بعد الإنجازات لبعض الأنشطة ", "277 وضعية التنفيد لهدا الإنجاز", "277 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Activites_IdMesure",
                table: "Activites",
                column: "IdMesure");

            migrationBuilder.CreateIndex(
                name: "IX_IndicateurMesures_IdIndicateur",
                table: "IndicateurMesures",
                column: "IdIndicateur");

            migrationBuilder.CreateIndex(
                name: "IX_IndicateurMesureValues_IdIndicateur",
                table: "IndicateurMesureValues",
                column: "IdIndicateur");

            migrationBuilder.CreateIndex(
                name: "IX_IndicateurMesureValues_IdMesure",
                table: "IndicateurMesureValues",
                column: "IdMesure");

            migrationBuilder.CreateIndex(
                name: "IX_MembreCommissions_IdCommission",
                table: "MembreCommissions",
                column: "IdCommission");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_IdAxe",
                table: "Mesures",
                column: "IdAxe");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_IdCycle",
                table: "Mesures",
                column: "IdCycle");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_IdNature",
                table: "Mesures",
                column: "IdNature");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_IdResponsable",
                table: "Mesures",
                column: "IdResponsable");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_IdSousAxe",
                table: "Mesures",
                column: "IdSousAxe");

            migrationBuilder.CreateIndex(
                name: "IX_Partenariats_IdOrganisme",
                table: "Partenariats",
                column: "IdOrganisme");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_IdProfil",
                table: "Permissions",
                column: "IdProfil");

            migrationBuilder.CreateIndex(
                name: "IX_Realisations_IdActivite",
                table: "Realisations",
                column: "IdActivite");

            migrationBuilder.CreateIndex(
                name: "IX_SousAxes_IdAxe",
                table: "SousAxes",
                column: "IdAxe");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdOrganisme",
                table: "Users",
                column: "IdOrganisme");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdProfil",
                table: "Users",
                column: "IdProfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndicateurMesures");

            migrationBuilder.DropTable(
                name: "IndicateurMesureValues");

            migrationBuilder.DropTable(
                name: "MembreCommissions");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Partenariats");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Realisations");

            migrationBuilder.DropTable(
                name: "Indicateurs");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropTable(
                name: "Activites");

            migrationBuilder.DropTable(
                name: "Mesures");

            migrationBuilder.DropTable(
                name: "Cycles");

            migrationBuilder.DropTable(
                name: "Natures");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SousAxes");

            migrationBuilder.DropTable(
                name: "Organismes");

            migrationBuilder.DropTable(
                name: "Profils");

            migrationBuilder.DropTable(
                name: "Axes");
        }
    }
}

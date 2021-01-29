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
                values: new object[] { 19, new DateTime(2020, 5, 17, 16, 41, 22, 829, DateTimeKind.Local).AddTicks(6377), "محضر رقم 19", "اللجنة رقم 19" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 18, new DateTime(2021, 1, 21, 20, 18, 11, 979, DateTimeKind.Local).AddTicks(7212), "محضر رقم 18", "اللجنة رقم 18" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 17, new DateTime(2020, 4, 23, 11, 11, 56, 636, DateTimeKind.Local).AddTicks(7810), "محضر رقم 17", "اللجنة رقم 17" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 16, new DateTime(2020, 2, 22, 4, 50, 24, 350, DateTimeKind.Local).AddTicks(5993), "محضر رقم 16", "اللجنة رقم 16" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 15, new DateTime(2020, 12, 3, 17, 36, 13, 841, DateTimeKind.Local).AddTicks(7625), "محضر رقم 15", "اللجنة رقم 15" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 14, new DateTime(2021, 1, 8, 13, 44, 43, 724, DateTimeKind.Local).AddTicks(4594), "محضر رقم 14", "اللجنة رقم 14" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 13, new DateTime(2020, 5, 23, 2, 48, 7, 251, DateTimeKind.Local).AddTicks(1853), "محضر رقم 13", "اللجنة رقم 13" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 12, new DateTime(2020, 12, 13, 8, 45, 54, 211, DateTimeKind.Local).AddTicks(6434), "محضر رقم 12", "اللجنة رقم 12" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 11, new DateTime(2020, 12, 16, 5, 5, 20, 589, DateTimeKind.Local).AddTicks(6331), "محضر رقم 11", "اللجنة رقم 11" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 9, new DateTime(2020, 2, 7, 14, 22, 49, 746, DateTimeKind.Local).AddTicks(8226), "محضر رقم 9", "اللجنة رقم 9" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 20, new DateTime(2020, 8, 19, 21, 4, 32, 947, DateTimeKind.Local).AddTicks(966), "محضر رقم 20", "اللجنة رقم 20" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 8, new DateTime(2020, 11, 28, 11, 21, 30, 244, DateTimeKind.Local).AddTicks(1709), "محضر رقم 8", "اللجنة رقم 8" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 7, new DateTime(2020, 4, 6, 2, 45, 36, 625, DateTimeKind.Local).AddTicks(459), "محضر رقم 7", "اللجنة رقم 7" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 6, new DateTime(2020, 10, 3, 19, 24, 47, 798, DateTimeKind.Local).AddTicks(9903), "محضر رقم 6", "اللجنة رقم 6" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 5, new DateTime(2020, 9, 20, 20, 28, 43, 416, DateTimeKind.Local).AddTicks(3689), "محضر رقم 5", "اللجنة رقم 5" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 4, new DateTime(2020, 4, 28, 6, 37, 42, 109, DateTimeKind.Local).AddTicks(7693), "محضر رقم 4", "اللجنة رقم 4" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 3, new DateTime(2020, 2, 23, 12, 49, 5, 223, DateTimeKind.Local).AddTicks(3949), "محضر رقم 3", "اللجنة رقم 3" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 2, new DateTime(2020, 8, 7, 2, 19, 8, 410, DateTimeKind.Local).AddTicks(2439), "محضر رقم 2", "اللجنة رقم 2" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 1, new DateTime(2020, 12, 9, 5, 29, 38, 787, DateTimeKind.Local).AddTicks(8860), "محضر رقم 1", "اللجنة رقم 1" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 10, new DateTime(2020, 10, 30, 5, 12, 50, 801, DateTimeKind.Local).AddTicks(316), "محضر رقم 10", "اللجنة رقم 10" });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Label" },
                values: new object[] { 4, "2030 - 2035" });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Label" },
                values: new object[] { 3, "2026 - 2030" });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "2018 - 2021" });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Label" },
                values: new object[] { 2, "2022 - 2025" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 1, " إرتفاع نسبة التسجيل والتصويت", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 2, "التعبير عن الرضا بخصوص تدبير العملية الإنتخابية من قبل عموم المعنيين والملاحظين ", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 3, "إرتفاع نسب التمثيلية", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 4, "النشر في الجريدة الرسمية", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 5, "تنصيب رئيس واعضاء الهيئة ", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[] { 6, "عدد عمليات التشاور العمومي", "غير معروف" });

            migrationBuilder.InsertData(
                table: "Natures",
                columns: new[] { "Id", "Label" },
                values: new object[] { 2, "التواصل والتحسيس" });

            migrationBuilder.InsertData(
                table: "Natures",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "الجانب التشريعي والمؤسساتي" });

            migrationBuilder.InsertData(
                table: "Natures",
                columns: new[] { "Id", "Label" },
                values: new object[] { 3, "تقوية القدرات" });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 24, null, "وزارة إصلاح الإدارة والوظيفة العمومية وجميع الإدارات", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 23, null, " وزارة الصناعة والاستثمار والتجارة والاقتصاد الرقمي", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 22, null, "الوزارة المنتدبة لدى رئيس الحكومة المكلفة بالشؤون العامة والحكامة", null, 1 });

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
                values: new object[] { 25, null, "الهيئة المركزية للوقاية من الرشوة", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 21, null, "الهيئة الوطنية للنزاهة والوقاية  من الرشوة ومحاربتها", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 26, null, "وزارة الصحة", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 32, null, "المجلس الأعلى للسلطة القضائية", null, 1 });

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
                values: new object[] { 33, null, "قطاع التعليم العالي", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 34, null, "وزارة الثقافة والاتصال قطاع الثقافة", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 27, null, "الدرك الملكي", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 18, null, "وزارة إعداد التراب الوطني والتعمير والإسكان وسياسة المدينة", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 1, null, "وزارة الدولة المكلفة بحقوق الإنسان", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 16, null, "هيئة المناصفة ومكافحة جميع أشكال التمييز", null, 1 });

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
                values: new object[] { 17, null, "الوزارة المنتدبة لدى رئيس الحكومة المكلفة بإصلاح الإدارة وبالوظيفة العمومية", null, 1 });

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
                values: new object[] { 6, null, "جمعيات المجتمع المدني", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 10, null, "رئاسة الحكومة", null, 1 });

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
                values: new object[] { 13, null, " وزارة التربية الوطنية والتكوين المهني  والتعليم العالي  والبحث العلمي قطاع التربية الوطنية", null, 1 });

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
                values: new object[] { 9, null, "وزارة الأسرة والتضامن والمساواة والتنمية الاجتماعية", null, 1 });

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
                values: new object[] { 19, "Evan.Jean@yahoo.fr", 19, "Mael Dubois" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 17, "Antoine.Lefebvre82@yahoo.fr", 17, "Juliette Julien" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 16, "Lola.Durand15@yahoo.fr", 16, "Mélissa Masson" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 15, "Nathan_Arnaud8@gmail.com", 15, "Jules Chevalier" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 14, "Noemie21@hotmail.fr", 14, "Océane Hubert" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 13, "Maeva34@hotmail.fr", 13, "Sarah Renault" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 12, "Pierre_Breton@yahoo.fr", 12, "Ines Lecomte" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 1, "Melissa_Dupuis31@hotmail.fr", 1, "Lola Denis" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 2, "Theo_Roussel30@yahoo.fr", 2, "Raphaël Robin" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 3, "Jules.Meyer@hotmail.fr", 3, "Pierre Andre" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 4, "Kylian_Laurent@hotmail.fr", 4, "Lucas Rousseau" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 5, "Lola_Vincent93@gmail.com", 5, "Ines Meunier" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 6, "Benjamin_Simon@yahoo.fr", 6, "Tom Renaud" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 7, "Evan_Leroux@hotmail.fr", 7, "Thomas Collet" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 8, "Ethan_Robert92@gmail.com", 8, "Raphaël Perez" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 9, "Alexandre89@hotmail.fr", 9, "Noah Julien" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 18, "Antoine_Guerin@hotmail.fr", 18, "Mattéo Royer" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 10, "Marie30@hotmail.fr", 10, "Marie Fabre" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 11, "Lisa87@gmail.com", 11, "Maëlys Paul" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 20, "Sacha.Jacquet@gmail.com", 20, "Nicolas Colin" });

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
                values: new object[] { 17, "Modification", 2, "suivi-indicateur", "suivi-indicateur" });

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
                values: new object[] { 8, "Modification", 3, "commission", "commission" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[] { 11, "Modification", 2, "mesure-region", "mesure-region" });

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
                values: new object[] { 6, 1, " حريات الاجتماع والتجمع والتظاهر السلمي وتأسيس الجمعيات " });

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
                values: new object[] { 9, 2, "الحقوق الثقافية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 15, 3, " الأبعاد المؤسساتية والتشريعية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 24, 4, "حماية التراث الثقافي " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 23, 4, "حريات التعبير والإعلام والصحافة والحق في المعلومة " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 14, 2, " المقاولة وحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 21, 4, " الحماية القانونية والقضائية لحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 20, 3, "حقوق المهاجرين واللاجئين " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 19, 3, " حقوق الأشخاص المسنين " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 18, 3, " حقوق الأشخاص في وضعية إعاقة " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 22, 4, " الحماية القانونية والمؤسساتية لحقوق المرأة " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 17, 3, "حقوق الشباب " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 16, 3, " حقوق الطفل " });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 28, true, "taza", "user-28@panddh.com", "05 ## ## ## ##", 28, 5, "user-28", "123", "mohamed", "06 ## ## ## ##", "user-28" });

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
                values: new object[] { 23, true, "taza", "user-23@panddh.com", "05 ## ## ## ##", 23, 5, "user-23", "123", "mohamed", "06 ## ## ## ##", "user-23" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 24, true, "taza", "user-24@panddh.com", "05 ## ## ## ##", 24, 5, "user-24", "123", "mohamed", "06 ## ## ## ##", "user-24" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 26, true, "taza", "user-26@panddh.com", "05 ## ## ## ##", 26, 5, "user-26", "123", "mohamed", "06 ## ## ## ##", "user-26" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 32, true, "taza", "user-32@panddh.com", "05 ## ## ## ##", 32, 5, "user-32", "123", "mohamed", "06 ## ## ## ##", "user-32" });

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
                values: new object[] { 30, true, "taza", "user-30@panddh.com", "05 ## ## ## ##", 30, 5, "user-30", "123", "mohamed", "06 ## ## ## ##", "user-30" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 29, true, "taza", "user-29@panddh.com", "05 ## ## ## ##", 29, 5, "user-29", "123", "mohamed", "06 ## ## ## ##", "user-29" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 18, true, "taza", "user-18@panddh.com", "05 ## ## ## ##", 18, 5, "user-18", "123", "mohamed", "06 ## ## ## ##", "user-18" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 25, true, "taza", "user-25@panddh.com", "05 ## ## ## ##", 25, 5, "user-25", "123", "mohamed", "06 ## ## ## ##", "user-25" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 17, true, "taza", "user-17@panddh.com", "05 ## ## ## ##", 17, 5, "user-17", "123", "mohamed", "06 ## ## ## ##", "user-17" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 5, true, "taza", "user-5@panddh.com", "05 ## ## ## ##", 5, 5, "user-5", "123", "mohamed", "06 ## ## ## ##", "user-5" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 15, true, "taza", "user-15@panddh.com", "05 ## ## ## ##", 15, 5, "user-15", "123", "mohamed", "06 ## ## ## ##", "user-15" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 1, true, "Temara", "admin@panddh.com", "05 ## ## ## ##", 1, 1, "admin", "123", "panddh", "06 ## ## ## ##", "panddh" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 33, true, "taza", "user-33@panddh.com", "05 ## ## ## ##", 33, 5, "user-33", "123", "mohamed", "06 ## ## ## ##", "user-33" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 2, true, "Temara", "mehdi@angular.io", "05 ## ## ## ##", 2, 2, "mehdi", "123", "mehdi", "06 ## ## ## ##", "mehdi" });

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
                values: new object[] { 6, true, "taza", "user-6@panddh.com", "05 ## ## ## ##", 6, 5, "user-6", "123", "mohamed", "06 ## ## ## ##", "user-6" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 16, true, "taza", "user-16@panddh.com", "05 ## ## ## ##", 16, 5, "user-16", "123", "mohamed", "06 ## ## ## ##", "user-16" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 7, true, "taza", "user-7@panddh.com", "05 ## ## ## ##", 7, 5, "user-7", "123", "mohamed", "06 ## ## ## ##", "user-7" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 9, true, "taza", "user-9@panddh.com", "05 ## ## ## ##", 9, 5, "user-9", "123", "mohamed", "06 ## ## ## ##", "user-9" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 10, true, "taza", "user-10@panddh.com", "05 ## ## ## ##", 10, 5, "user-10", "123", "mohamed", "06 ## ## ## ##", "user-10" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 11, true, "taza", "user-11@panddh.com", "05 ## ## ## ##", 11, 5, "user-11", "123", "mohamed", "06 ## ## ## ##", "user-11" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 12, true, "taza", "user-12@panddh.com", "05 ## ## ## ##", 12, 5, "user-12", "123", "mohamed", "06 ## ## ## ##", "user-12" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 13, true, "taza", "user-13@panddh.com", "05 ## ## ## ##", 13, 5, "user-13", "123", "mohamed", "06 ## ## ## ##", "user-13" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 14, true, "taza", "user-14@panddh.com", "05 ## ## ## ##", 14, 5, "user-14", "123", "mohamed", "06 ## ## ## ##", "user-14" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 8, true, "taza", "user-8@panddh.com", "05 ## ## ## ##", 8, 5, "user-8", "123", "mohamed", "06 ## ## ## ##", "user-8" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 34, true, "taza", "user-34@panddh.com", "05 ## ## ## ##", 34, 5, "user-34", "123", "mohamed", "06 ## ## ## ##", "user-34" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 3, "3", 1, 1, 1, 1, 1, 1, "الإسراع بإحداث مرصد وطني مستقل يساهم في تحليل تطورات المشاركة السياسية والانتقال الديمقراطي.", null, null, "آلية مؤسساتية مساعدة على تتبع تحليل وفهم تطورات المشاركة السياسية والانتقال الديمقراطي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 296, "296", 3, 2, 1, 23, 18, 2, " المصادقة على معاهدة مراكش لتيسير النفاذ إلى المصنفات المنشورة لفائدة الأشخاص المكفوفين أو معاقي البصر أو ذوي إعاقات أخرى في قراءة المطبوعات لسنة 2013.", null, null, "المصادقة على المعاهدة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 257, "257", 3, 1, 1, 23, 16, 1, "مواصلة الجهود الرامية إلى الحد من ظاهرة تشغيل الأطفال.", null, null, "الجهود الرامية إلى الحد من ظاهرة تشغيل الأطفال متواصلة ومعززة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 154, "154", 2, 2, 1, 23, 11, 1, " تعزيز دور الآليات الاستباقية للتقليص من النزاعات في مجال الشغل.", null, null, "قدرات جهاز تفتيش الشغل في مجال التدخل الإستباقي معززة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 90, "90", 2, 1, 1, 23, 8, 1, "  مأسسة وتعميم الدعم المادي المقدم للمتمدرسين المعوزين والأطفال في وضعية إعاقة", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 88, "88", 1, 1, 1, 23, 8, 2, "  بلورة سياسة لغوية تضمن العدالة اللغوية وتأخذ بعين الاعتبار حاجيات التلاميذ وتراعي الخصوصيات اللغوية والثقافية للأقاليم والجهات", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 48, "48", 1, 1, 1, 23, 5, 1, "استحضار البعد الأمني في وضع خطط التهيئة الحضرية وتصميم التجمعات السكنية الجديدة والأحياء بضواحي المدن بشكل يضمن أمن المواطنات والمواطنين.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 428, "428", 4, 2, 1, 22, 26, 1, "مواصلة تحسين الخدمات القضائية.", null, null, "إجراءات معززة للخدمات القضائية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 274, "274", 3, 2, 3, 22, 16, 1, " التحسيس والتوعية بخطورة العقاب البدني والعنف في الوسط التربوي كبيئة آمنة.", null, null, "برامج مساعدة على الحد من العنف في الوسط التربوي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 260, "260", 3, 1, 1, 22, 16, 1, "وضع تصنيفات ودفاتر تحملات خاصة بأصناف مؤسسات الرعاية الاجتماعية المستقبلة للأطفال في حاجة للحماية.", null, null, "مؤسسات الرعاية الاجتماعية المستقبلة للأطفال مصنفة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 250, "250", 3, 2, 1, 22, 16, 2, " تعزيز حقوق الأطفال في المشاركة في إعداد وتتبع تفعيل السياسات والبرامج والمشاريع الوطنية.", null, null, "بيئة مشجعة على مشاركة الأطفال" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 147, "147", 2, 1, 3, 22, 10, 2, "القيام بحملات للتوعية داخل المستشفيات والمراكز والمستوصفات الصحية (ملصقات ومنشورات وأشرطة سمعية بصرية...) من أجل توعية المواطنات والمواطنين بحقوقهم وواجباتهم باللغات المتداولة.", null, null, "مبادرات مساهمة في النهوض بثقافة الحق والواجب                  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 122, "122", 2, 2, 1, 22, 9, 2, "تشجيع إحداث محطات إعلامية جهوية", null, null, "محطات جهوية متفاعلة مع محيطها" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 84, "84", 1, 2, 1, 22, 8, 2, " مراجعة المناهج والمقررات الدراسية وملاءمتها مع مبادئ وقيم الدستور وأحكامه والاتفاقيات الدولية ذات الصلة. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 71, "71", 1, 1, 1, 22, 7, 2, "مواصلة تجريم كل الأفعال التي تمثل انتهاكا جسيما لحقوق الإنسان وفقا لأحكام الدستور.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 417, "417", 4, 2, 1, 21, 24, 1, " تعزيز تأهيل القصور والقصبات والحفاظ عليها.", null, null, "التراث العمراني مرمم ومحافظ عليه" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 407, "407", 4, 2, 1, 21, 23, 2, "التنصيص على مبدأ المناصفة في دفاتر تحملات شركات الاتصال السمعي البصري.", null, null, "بيئة إعلامية معززة لمبدأ المناصفة في الفضاء السمعي البصري " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 295, "295", 3, 2, 3, 21, 17, 1, "تعزيز برامج محو الأمية في أفق القضاء عليها وتأهيل الشباب.", null, null, "تقليص المعدل العام للأمية إلى20 % سنة 2021" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 258, "258", 3, 1, 1, 21, 16, 2, " تشجيع ودعم الأسر التي يوجد أطفالها في وضعية صعبة لتفادي الرعاية المؤسساتية.", null, null, "تراجع ظاهرة إيداع الأطفال بمؤسسات الرعاية الاجتماعية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 254, "254", 3, 2, 1, 21, 16, 2, " حماية حقوق الأطفال في وسائل الإعلام بما في ذلك وسائل الاتصال الحديثة والنهوض بالتربية عليها.", null, null, "بيئة إعلامية داعمة لحقوق الطفل " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 226, "226", 3, 2, 1, 21, 15, 2, " اعتماد معايير الجودة في التدبير وفي خدمات التكفل بمؤسسات الرعاية الاجتماعية من أجل ضمان الحقوق الفئوية. ", null, null, "مؤسسات للرعاية الاجتماعية معتمدة لمعايير الجودة في التدبير وخدمات التكفل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 198, "198", 2, 2, 1, 21, 13, 2, " تقنين الزراعات المستهلكة للمياه خاصة بالمناطق الهشة.", null, null, "برامج داعمةلتكريس تدبير يحافظ على الموارد المائية المحدودة ويضمن استدامتها" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 162, "162", 2, 1, 3, 21, 11, 2, "وضع برامج للتوعية والتحسيس بمقتضيات مدونة الشغل لفائدة العمال.", null, null, "برامج داعمةلاحترام مقتضيات مدونة الشغل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 137, "137", 2, 2, 1, 21, 10, 1, " دعم التحصيل والتحليل الممنهج والشمولي للمعطيات والمعلومات حسب النوع الاجتماعي في مجال الصحة وخصوصا ما تعلق بالأمراض المتنقلة جنسيا والعنف. ", null, null, " نظاممعلوماتي مندمج معد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 322, "322", 3, 2, 1, 23, 18, 1, " دعم دور القطاع الخاص للمساهمة في مسلسل الإدماج الاجتماعي للأشخاص في وضعية إعاقة. ", null, null, "قطاع خاص منخرط في الإدماج الاجتماعي للأشخاص في وضعية إعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 60, "60", 1, 1, 3, 21, 5, 1, "تعميم تدريس مادة حقوق الإنسان وأحكام القانون الدولي الإنساني ضمن برامج التكوين الأساسي والمستمر الخاص بالموظفين المكلفين بتنفيذ القانون.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 327, "327", 3, 1, 3, 23, 18, 2, " تعزيز دور المجتمع المدني في النهوض بحقوق الأشخاص في وضعية إعاقة. ", null, null, "مبادرات مثمنة وداعمة لأدوار المجتمع المدني في مجال النهوض بحقوق الأشخاص في وضعية إعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 360, "360", 4, 1, 1, 23, 21, 1, " مواصلة الانضمام والتفاعل مع الأنظمة الدولية والإقليمية لحقوق الإنسان.", null, null, "ممارسة اتفاقية في مجال حقوق الإنسان معززة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 301, "301", 3, 2, 1, 25, 18, 1, " إحداث مركز وطني للرصد والتوثيق والبحث في مجال الإعاقة.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 231, "231", 3, 2, 1, 25, 15, 2, " اعتماد الحكامة الجيدة في تتبع تنفيذ البرامج والاستراتيجيات الخاصة بالفئات في وضعية هشاشة. ", null, null, "آليات داعمة لضمان الحكامة الجيدة في تتبع البرامج الخاصة بالفئات في وضعية هشاشة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 172, "172", 2, 2, 1, 25, 12, 1, " الإسراع باعتماد المرسوم المتعلق بتحديد النفوذ الترابي للوكالات الحضرية، طبقا للتقسيم الترابي الجديد.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 81, "81", 1, 1, 3, 25, 7, 2, "تعزيز برامج التدريب والتكوين والتوعية بقيم حقوق الإنسان وآليات حمايتها والنهوض بها الموجهة للقضاة وللمكلفين بإنفاذ القوانين وموظفي السجون", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 55, "55", 1, 1, 1, 25, 5, 1, "تقوية أداء المؤسسة البرلمانية في مجال التقصي حول انتهاكات حقوق الإنسان مع إخضاع الأجهزة الأمنية للرقابة البرلمانية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 35, "35", 1, 2, 1, 25, 4, 2, " تعزيز الالتقائية بين البرامج والمبادرات الأفقية والقطاعية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 29, "29", 1, 1, 1, 25, 4, 1, "الإسراع بوضع ميثاق للمرافق العمومية يتضمن قواعد الحكامة الإدارية الجيدة.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 25, "25", 1, 1, 1, 25, 3, 1, "--", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 17, "17", 1, 1, 1, 25, 2, 1, " تجويد عمل آليات الحوار والتشاور الكفيلة بإعمال المساواة وتكافؤ الفرص على نحو أفضل في كافة دوائر اتخاذ القرار في القطاعات العمومية الوطنية والمحلية والقطاع الخاص والمنظمات غير الحكومية. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 424, "424", 4, 1, 3, 24, 25, 1, "النهوض بالموارد البشرية المعنية بمعالجة وبحفظ وتنظيم الأرشيف باعتماد برامج منتظمة خاصة بالتكوين والتكوين المستمر موجهة لفائدة المهنيين.", null, null, "الموارد البشرية بمؤسسة أرشيف المغرب مكونة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 403, "403", 4, 1, 1, 24, 23, 1, "إصدار القرار الخاص بتحديد كيفيات سير وتنظيم مراحل انتخاب أعضاء المجلس الوطني للصحافة.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 324, "324", 3, 2, 3, 24, 18, 2, "تعزيز دور الإعلام في تطوير حملات للوقاية من الإعاقة وبرامج مكافحة التمييز والوصم تجاه الأشخاص ذوي الإعاقة.", null, null, " إعلام داعم لمكافحة التمييز والوصم تجاه الأشخاص ذوي الإعاقة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 289, "289", 3, 2, 3, 24, 17, 2, " الرفع من عدد البرامج المعدة من الشباب والموجهة إليهم في دفاتر تحملات الشركات العمومية للاتصال السمعي البصري.", null, null, "برامج إعلامية محفزة على مشاركة الشباب " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 234, "234", 3, 1, 3, 24, 15, 1, " تعزيز قدرات مختلف الفاعلين المعنيين، حكوميين وغير حكوميين، في مجال الحقوق الفئوية.", null, null, "برامج للتكوين والتكوين المستمر داعمة لتعزيز القدرات في مجال الحقوق الفئوية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 213, "213", 2, 1, 3, 24, 14, 1, "إدماج بعد احترام حقوق الإنسان في المقاولة على مستوى القانون والممارسة والنهوض بأدوار المقاولة المتعلقة بحقوق الانسان وقيم المواطنة.", null, null, "بيئة داعمة للنهوض بحقوق الإنسان داخل المقاولة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 204, "204", 2, 2, 1, 24, 13, 1, " تشجيع التدريس والبحث العلمي في الجامعة ومعاهد التكوين ومراكز البحث العلمي حول البيئة والتنمية المستدامة.", null, null, "مبادرات داعمة للتدريس والبحث العلمي في مجال البيئة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 188, "188", 2, 2, 1, 24, 13, 1, "مراجعة اختصاصات وتنظيم المجلس الوطني للبيئة بهدف وضع الهياكل والمؤسسات والآليات والمساطر اللازمة للحكامة البيئية الجيدة وتحقيق التنمية المستدامة طبقا لمبادئ وأهداف القانون الإطار بمثابة ميثاق وطني للبيئة والتنمية المستدامة. ", null, null, "التأطير القانوني للمجالات البيئية معزز" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 145, "145", 2, 2, 1, 24, 10, 2, " تشجيع وتحفيز طلبة الطب على التخصص في الطب الشرعي والطب النفسي والوظيفي وتوفير المناصب المالية اللازمة.", null, null, "تحفيزات مساعدة على تقليص الخصاص" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 125, "125", 2, 2, 3, 24, 9, 1, "وضع برامج تواصلية للجمهور الواسع تستهدف التعريف والتحسيس بالحقوق الثقافية واللغوية ومختلف إبداعاتها", null, null, "بيئة مشجعة للنهوض بالحقوق الثقافية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 92, "92", 2, 1, 1, 24, 8, 2, "  تفعيل مجالس التدبير وتعزيز أدوارها باعتبارها أداة لتحقيق تدبير تشاركي للشأن التعليمي", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 23, "23", 1, 2, 1, 24, 3, 1, " تقوية خدمات القرب وإلزامية تقييم السياسات العمومية وإحداث جهاز مؤسساتي متخصص في هذا المجال.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 22, "22", 1, 1, 1, 24, 3, 1, " إدماج البعد الثقافي في التنظيم الجهوي على مستوى وسائل الإعلام والبرامج التربوية والتظاهرات الثقافية والفنية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 391, "391", 4, 1, 1, 23, 22, 2, " إدماج مقاربة النوع الاجتماعي في البرامج الاقتصادية الداعمة لإحداث المقاولات.", null, null, "آليات كفيلة بإدماج مقاربة النوع" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 333, "333", 3, 1, 1, 23, 19, 2, " دعم وتشجيع مبادرات المجتمع المدني والقطاع الخاص لإحداث نوادي وفضاءات الترفيه الموجهة للأشخاص المسنين.", null, null, "دينامية داعمة لمبادرات المجتمع المدني والقطاع الخاص في مجال الترفيه لفائدة الأشخاص المسنين " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 40, "40", 1, 2, 1, 21, 4, 1, " وضع معايير مرجعية قابلة للتتبع وقياس مظاهر الفساد.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 432, "432", 4, 1, 3, 20, 26, 1, "إشاعة ثقافة حقوق الإنسان وتنميتها في أوساط العدالة.", null, null, "شراكات وبرامج داعمة لتملك ثقافة حقوق الإنسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 376, "376", 4, 1, 3, 20, 21, 2, "ترصيد التواصل بين مهنيي ومساعدي العدالة والعمل على مأسسته على نحو أفضل.", null, null, "آلية داعمة للتواصل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 105, "105", 2, 1, 1, 19, 9, 1, "استثمار وحفظ الرصيد الحضاري العبري المغربي في إغناء التنوع الثقافي والتطور المجتمعي", null, null, "مبادرات داعمة للتنوع الثقافي والتطور الاجتماعي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 21, "21", 1, 1, 1, 19, 3, 2, "-21- تنفيذ توصيات المجلس الأعلى لإعداد التراب الوطني واللجن المنبثقة عنه.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 387, "387", 4, 1, 1, 18, 22, 2, " مواصلة الحوار المجتمعي حول بعض مقتضيات مدونة الأسرة، ويتعلق الأمر بإعادة صياغة المادة 49 بما يضمن استيعاب مفهوم الكد والسعاية ومراجعة المادة 175 بإقرار عدم سقوط الحضانة عن الأم رغم زواجها وتعديل المادتين 236 و238 من أجل كفالة المساواة بين الأب والأم في الولاية على الأبناء.", null, null, "حوار مجتمعي منظم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 366, "366", 4, 2, 1, 18, 21, 1, " مواصلة الحوار المجتمعي بشأن المصادقة على النظام الأساسي للمحكمة الجنائية الدولية.", null, null, "حوار مجتمعي منظم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 313, "313", 3, 1, 1, 18, 18, 1, "الإسراع بتفعيل نظام الدعم الاجتماعي والتشجيع والمساندة لفائدة الأشخاص في وضعية إعاقة المنصوص عليه في المادة 6 من القانون الإطار رقم 97.13 المتعلق بحماية حقوق الاشخاص في وضعية إعاقة والنهوض بها.", null, null, "نظام الدعم الاجتماعي مشجع على النهوض بوضعية الأشخاص في وضعية إعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 216, "216", 2, 2, 3, 18, 14, 2, " تعزيز الوعي بموضوع المقاولة وحقوق الإنسان من خلال تنظيم لقاءات وطنية وجهوية بمشاركة الأطراف المعنية. ", null, null, "برامج داعمة للنهوض بمجال المقاولة وحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 189, "189", 2, 1, 1, 18, 13, 1, " تغطية المجالات البيئية غير المشمولة بالتشريع البيئي والتنمية المستدامة بغية استكمال التأطير القانوني لمختلف هذه المجالات. ", null, null, "إطار تشريعي معزز" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 167, "167", 2, 2, 1, 18, 12, 1, "وضع مقتضيات قانونية وتنظيمية تخص المعايير الدنيا المطبقة على السكن الاجتماعي من حيث المواصفات العمرانية والمناطق الخضراء والسلامة الأمنية والولوجيات.", null, null, "منظومة قانونية داعمة للسكن الاجتماعي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 134, "134", 2, 2, 1, 18, 10, 1, " تعزيز مبدأي المساواة وعدم التمييز في التعامل مع المرضى داخل المؤسسات الاستشفائية. ", null, null, "بيئة صحية تكفل الولوج المتساوي للخدمات الصحية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 121, "121", 2, 2, 1, 18, 9, 2, " تشجيع وتثمين الدراسات البحثية في مجال التأصيل للتنوع الثقافي والحفاظ على الذاكرة والثقافة الشعبية وسائر الإبداعات المماثلة.", null, null, "مناخ مشجع على البحث " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 67, "67", 1, 2, 1, 18, 6, 2, "كفالة احترام المقتضيات القانونية المتعلقة بوصل إيداع ملفات تأسيس الجمعيات.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 410, "410", 4, 1, 3, 17, 23, 1, "تعزيز برامج التوعية والتحسيس بشأن مكتسبات وتحديات ممارسة حريات التعبير والإعلام والصحافة والحق في المعلومة", null, null, "عدد البرامج والشراكات والدعامات المنجزة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 393, "393", 4, 1, 1, 17, 22, 2, " تعزيز دور الجماعات الترابية في توفير بيئة آمنة تحمي الأطفال والنساء من كل أشكال العنف.", null, null, "بيئة آمنة تحمي الأطفال والنساء من كل أشكال العنف" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 369, "369", 4, 2, 1, 17, 21, 1, "إحداث بنك وطني للبصمات الجينية.", null, null, "آلية داعمة للنجاعة الأمنية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 266, "266", 3, 2, 1, 17, 16, 2, " اتخاذ تدابير خاصة بحماية الأطفال المتخلى عنهم والعناية ببنيات استقبالهم وتبسيط مسطرة التكفل بهم.", null, null, "بنيات مؤسساتية كفيلة بحماية الأطفال المتخلى عنهم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 259, "259", 3, 2, 1, 17, 16, 2, " اعتماد معايير الجودة في خدمات التكفل بمؤسسات الرعاية الاجتماعية للأطفال.", null, null, "توفر مؤسسات الرعاية الاجتماعية على خدمات ذات جودة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 243, "243", 3, 2, 1, 17, 16, 2, " مواصلة الحوار المجتمعي حول مراجعة المادة 20 من مدونة الأسرة المتعلقة بالإذن بزواج القاصر.", null, null, "حوار مجتمعي منظم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 207, "207", 2, 1, 3, 17, 13, 2, " إدماج البعد البيئي في البرامج والمقررات الدراسية وفي الأنشطة التربوية بالوسط المدرسي.", null, null, "مناهج ومقرراتدراسية معززة للتربية البيئية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 171, "171", 2, 1, 1, 17, 12, 1, " إسراع وتيرة إنجاز برامج القضاء على أحياء الصفيح للسعي إلى معالجة وضعيات 50 % من الأسر التي تعيش² في دور الصفيح في أفق 2021.", null, null, "برامج مساهمة في القضاء على أحياء الصفيح  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 165, "165", 2, 2, 1, 17, 12, 2, "إرساء استراتيجية وطنية شمولية ومندمجة في مجال السكن.", null, null, "استراتيجية وطنية معتمدة داعمة للحق في السكن   " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 127, "127", 2, 1, 1, 17, 10, 2, " الإسراع بالمصادقة على مشروع القانون المتعلق بمكافحة الاضطرابات العقلية وبحماية حقوق الأشخاص المصابين بها.", null, null, "إطار قانوني داعم لحماية الأشخاص المصابين بالاضطرابات العقلية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 80, "80", 1, 2, 3, 17, 7, 1, "إعمال الحق في الوصول إلى المعلومة واستلامها ونشرها بما يضمن تفعيل مبدأ عدم الإفلات من العقاب", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 63, "63", 1, 1, 1, 17, 6, 1, "مواصلة ملاءمة الإطار القانوني المتعلق بحريات الاجتماع وتأسيس الجمعيات مع المعايير الدولية لحقوق الإنسان في نطاق الدستور وأحكامه.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 111, "111", 2, 1, 1, 19, 9, 2, "مواصلة تثمين الرموز الوطنية المغربية من خلال إطلاق أسمائها على المؤسسات والشوارع والساحات العمومية حفظا لها في ذاكرة الأجيال.", null, null, "فضاءات ومؤسسات عامة مساعدة على حفظ الذاكرة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 136, "136", 2, 2, 1, 19, 10, 2, " مواصلة تحسين جودة الخدمات وتوسيع التغطية لتشمل باقي الفئات الأخرى وضمان التوزيع العادل للموارد على كافة التراب الوطني. ", null, null, "برامج داعمة لتعميم وتجويد الخدمات الصحية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 183, "183", 2, 1, 3, 19, 12, 2, " وضع برامج تدريب وتكوين المنشطين في ميدان المصاحبة الاجتماعية للمشاريع السكنية. ", null, null, "موارد بشرية مؤهلة، داعمة للمصاحبة الاجتماعية  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 241, "241", 3, 2, 1, 19, 16, 1, " الإسراع بإصدار القانون المتعلق بشروط فتح وتدبير مؤسسات الرعاية الاجتماعية والنصوص القانونية والتنظيمية ذات الصلة.", null, null, " إطار قانوني داعم تجويد خدمات مؤسسات الرعاية الاجتماعية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 362, "362", 4, 2, 1, 20, 21, 1, "الإسراع باعتماد مشروعي القانون الجنائي وقانون المسطرة الجنائية.", null, null, "منظومة جنائية معتمدة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 358, "358", 3, 2, 3, 20, 20, 1, "مواصلة دعم وتعزيز قدرات فعاليات المجتمع المدني التي تهتم ميدانيا بأوضاع المهاجرين سواء في المغرب أو في بلدان الاستقبال.", null, null, "قدرات فعاليات المجتمع المدني معززة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 292, "292", 3, 1, 3, 20, 17, 1, " وضع برامج لتعزيز قدرات المتدخلين في السياسة الوطنية المندمجة للشباب.", null, null, "قدرات متطورة لتفعيل السياسة الوطنية المندمجة للشباب" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 275, "275", 3, 2, 3, 20, 16, 2, "مواصلة تعزيز برامج وأنشطة حقوق المشاركة لدى الأطفال.", null, null, "بيئة مشجعة على مشاركة الأطفال" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 255, "255", 3, 2, 1, 20, 16, 2, " تعزيز الولوج الآمن للأطفال إلى وسائل الإعلام والاتصال المعتمدة على التكنولوجية الحديثة عبر وضع برامج خاصة وحمايتهم من كافة أشكال الاستغلال.", null, null, "بيئة داعمة لولوج الأطفال الآمن   لوسائل الإعلام والاتصال المعتمدة على التكنولوجيا الحديثة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 251, "251", 3, 1, 1, 20, 16, 2, " مواصلة ودعم الجهود الرامية إلى الحد من تزويج القاصرات. ", null, null, "بيئة مساعدة على الحد من تزويج القاصرات " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 227, "227", 3, 1, 1, 20, 15, 2, "تجميع ونشر القوانين والتشريعات المتعلقة بالفئات المعنية والتعريف بمقتضياتها.", null, null, "مصنفات منجزة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 214, "214", 2, 2, 3, 20, 14, 1, " النهوض بدور المقاولة في مجال تقييم أثر أنشطتها على حقوق الانسان.", null, null, "آليات داعمة للنهوض بحقوق الإنسان داخل المقاولة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 200, "200", 2, 1, 1, 20, 13, 1, " دعم البرنامج الوطني لتدبير وتثمين النفايات.", null, null, "البرنامج الوطني لتدبير وتثمين النفاياتمدعم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 184, "184", 2, 2, 1, 20, 13, 2, " ملاءمة الإطار القانوني الوطني مع الاتفاقيات الدولية المتعلقة بحماية البيئة والتنمية المستدامة.", null, null, "إطار قانوني وطنيمتلائم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 114, "114", 2, 1, 1, 20, 9, 1, "تشجيع مبادرات الشباب والمجتمع المدني فيما يخص التربية الثقافية والإنتاج الثقافي ودعم المشاريع المحفزة على الإبداع", null, null, "مناخ داعم لمبادرات الشباب في المجال الثقافي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 338, "338", 3, 2, 1, 25, 19, 2, "ضمان التغطية الصحية الإجبارية للأشخاص المسنين غير المستفيدين منها ", null, null, "تغطية صحية شاملة لجميع الأشخاص المسنين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 49, "49", 1, 2, 1, 20, 5, 1, "إلزام المنظومة التعميرية والأمنية بنصب كاميرات يكون بإمكانها المساعدة على مكافحة الجريمة وحماية الأشخاص والممتلكات.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 37, "37", 1, 1, 1, 20, 4, 2, " تقوية الآليات المكلفة بتعزيز النزاهة والشفافية بالخبرة المطلوبة والدعم الفني اللازم.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 30, "30", 1, 2, 1, 20, 4, 2, "الإسراع بوضع المقتضيات التنظيمية الخاصة بالتدابير المتعلقة بالوقاية من الفساد. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 27, "27", 1, 2, 1, 20, 4, 2, " تقوية الإطار القانوني والتنظيمي لتعزيز النزاهة والشفافية من خلال ملاءمته مع الاتفاقيات الدولية لمكافحة الفساد كما صادقت عليها المملكة المغربية ليشمل ما يتعلق بالتنسيق وآليات التحري والوصول إلى المعلومات والتنفيذ الفعال والتتبع والإشراف.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 16, "16", 1, 2, 1, 20, 2, 2, "تفعيل مقاربة النوع في كافة المجالس المنتخبة وطنيا وجهويا ومحليا.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 418, "418", 4, 1, 1, 19, 25, 1, " مراجعة قانون الأرشيف طبقا للممارسات الفضلى المعمول بها في هذا المجال مع استكمال إصدار المراسيم التطبيقية لقانون الأرشيف.", null, null, "إطار قانوني داعم لثقافة الأرشيف " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 398, "398", 4, 1, 3, 19, 22, 2, "نشر الممارسات الفضلى المتعلقة بتطبيق مدونة الأسرة على مستوى عمل كتابة الضبط ومراكز الاستقبال.", null, null, "دينامية داعمة للتطبيق الناجع لمدونة الأسرة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 374, "374", 4, 1, 3, 19, 21, 2, " وضع برنامج خاص بجمع وتصنيف وتقديم ونشر الاجتهادات القضائية الجنائية والإدارية المعززة لإعمال المعايير الدولية لحقوق الإنسان.", null, null, "منظومة داعمة لتثمين الاجتهادات القضائية واستثمارها" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 348, "348", 3, 2, 1, 19, 20, 2, "ضمان حماية النساء المغربيات المهاجرات وتعزيز الجهود الحكومية ذات الصلة.", null, null, "آلية لتعزيز حماية النساء المغربيات المهاجرات محدثة ومفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 341, "341", 3, 2, 3, 19, 19, 2, "تعزيز قدرات العاملين العموميين والمؤسساتيين لإدماج حاجيات الأشخاص المسنين في السياسات العمومية", null, null, "قدرات معززة لإدماج حاجيات الأشخاص المسنين في السياسات العمومية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 306, "306", 3, 1, 1, 19, 18, 1, "الإسراع بتحديد وإعمال النسبة المائوية للأشخاص في وضعية إعاقة الواجب تشغيلهم في إطار تعاقدي بين الدولة ومقاولات القطاع الخاص.", null, null, " إطار تعاقدي محفز لتشغيل الأشخاص في وضعية إعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 277, "277", 3, 1, 3, 19, 16, 2, " الإبداع في أشكال وصيغ الأدوات البيداغوجية حول التربية الجنسية وفق مقاربة وقائية تراعي أعمار ومستوى نضج الأطفال والمخاطر التي قد تهددهم.", null, null, " بيئة داعمة للتربية الجنسية بالوسط المدرسي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 38, "38", 1, 2, 1, 20, 4, 1, " تعميم الخدمات العمومية الإلكترونية في أفق الوصول إلى تحقيق الإدارة الرقمية الشاملة. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 28, "28", 1, 2, 1, 17, 4, 2, " الإسراع بالمصادقة على المقتضيات القانونية المؤطرة لتجريم الإثراء غير المشروع.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 372, "372", 4, 1, 1, 25, 21, 2, " تعزيز دور القضاء الإداري في ترسيخ دولة القانون وتكريس مبدأ سمو القانون واحترام حقوق الإنسان.", null, null, "إطار مؤسساتي معزز للقضاء الإداري" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 411, "411", 4, 2, 3, 25, 23, 2, "إدماج قيم حقوق الإنسان في برامج التكوين والتدريب الموجهة لمهنيي الإعلام والاتصال", null, null, "برامج التكوين والتدريب معززة بقيم حقوق الانسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 173, "173", 2, 2, 1, 31, 12, 1, " التأهيل الحضري للأحياء غير القانونية لتحسين ظروف السكان القاطنين بها.", null, null, "برامج للتأهيل الحضري داعمة لتحسين ظروف عيش الساكنة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 107, "107", 2, 2, 1, 31, 9, 2, "مواصلة تعزيز القناة التلفزية الأمازيغية وتمكينها من الموارد البشرية والكفاءات اللازمة للبث المتواصل", null, null, "بث متواصل للقناة التلفزية الأمازيغية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 99, "99", 2, 2, 1, 31, 9, 1, "  تنمية الأشكال والآليات والوسائل الكفيلة بالحفاظ على التنوع الثقافي وتطويره في السياسات العمومية والاستراتيجيات والمخططات والبرامج الوطنية التي تقتضي إعمال الحقوق الثقافية بما فيها الحق في المشاركة الثقافية ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 425, "425", 4, 2, 1, 30, 26, 1, "  تأهيل الهياكل القضائية والإدارية بما يكرس النجاعة القضائية الضامنة للأجل المعقول. ", null, null, "آليات مؤسساتية داعمة للنجاعة القضائية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 370, "370", 4, 1, 1, 30, 21, 1, "عقد شراكات وعلاقات تعاون مع مؤسسات وطنية ودولية تعنى بحقوق الإنسان للمساهمة في تأطير وتكوين القضاة والمحامين في مجال تملك ثقافة حقوق الإنسان فكرا وسلوكا وعملا.", null, null, "شراكات وبرامج داعمة لتملك ثقافة حقوق الإنسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 367, "367", 4, 2, 1, 30, 21, 1, "مواصلة الحوار المجتمعي حول تعديل المادة 53 من مدونة الأسرة لأجل كفالة الحماية الفعلية للزوج أو الزوجة من طرف النيابة العامة عند الإرجاع إلى بيت الزوجية.", null, null, "حوار مجتمعي منظم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 365, "365", 4, 1, 1, 30, 21, 1, "مواصلة الحوار المجتمعي حول الانضمام إلى البروتوكول الاختياري الثاني الملحق بالعهد الدولي الخاص بالحقوق المدنية والسياسية المتعلق بإلغاء عقوبة الاعدام. ", null, null, "حوار مجتمعي منظم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 343, "343", 3, 1, 1, 30, 20, 2, " مواصلة التفكير في سبل تفعيل مقتضيات الدستور ذات الصلة بحقوق مغاربة العالم.", null, null, "تصورات حول تفعيل مقتضيات الدستور ذات الصلة بحقوق مغاربة العالم مبلورة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 319, "319", 3, 1, 1, 30, 18, 1, " البحث في سبل إشراك القطاع الخاص في إدماج الأشخاص في وضعية إعاقة في سوق الشغل.", null, null, "آلية مشتركة مساعدة على إدماج الأشخاص في وضعية إعاقة في سوق الشغل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 309, "309", 3, 2, 1, 30, 18, 1, "النهوض بالولوجية الشاملة سواء على المستوى العمراني والمعماري ووسائل النقل والاتصال.", null, null, "ولوجيات كفيلة بالمساهمة في تحسين ظروف عيش الأشخاص في وضعية إعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 284, "284", 3, 2, 1, 30, 17, 2, " تعزيز نقط ارتكاز خاصة بالشباب في القطاعات والمؤسسات المعنية مركزيا ومحليا.", null, null, "بيئة إدارية داعمة للتنسيق بين القطاعات" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 271, "271", 3, 2, 1, 30, 16, 2, "تفعيل آليات المراقبة التربوية والبيداغوجية واللوجيستيكية بالأماكن التي تخصص لتعليم وتربية الأطفال.", null, null, "آليات معززة للمراقبة التربوية والبيداغوجية واللوجيستيكية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 199, "199", 2, 1, 1, 30, 13, 1, " تيسير الولوج إلى المعلومة البيئية وتأمين مشاركة المواطنات والمواطنين في إعداد المشاريع والبرامج ذات الصلة بالبيئة والمشاركة في اتخاذ القرار.", null, null, "إطار مؤسساتي ضامن للحق في المعلومة ومؤمن للمشاركة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 179, "179", 2, 2, 1, 30, 12, 1, " تضمين دفاتر التحملات للمعايير الدنيا المطبقة على السكن الاجتماعي المحددة بصفة قانونية أو تنظيمية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 178, "178", 2, 2, 1, 30, 12, 2, " جعل التدابير الجبائية التحفيزية لفائدة المنعشين العقاريين المنخرطين في إنجاز مشاريع السكن الاجتماعي تتلاءم وتوفير العرض السكني اللائق لمختلف فئات المجتمع.", null, null, "تدابير تحفيزية داعمة لتكثيف العرض السكني" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 177, "177", 2, 2, 1, 30, 12, 1, "تفعيل القانون المتعلق بالمباني الآيلة للسقوط وتنظيم عمليات التجديد الحضري ووضع برامج متكاملة لمعالجة السكن المهدد بالانهيار لتشمل مجموع التراب الوطني.", null, null, "إطار مؤسساتي وتنظيمي داعم لمعالجة إشكالية السكن المهدد بالانهيار" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 104, "104", 2, 2, 1, 30, 9, 1, "تعزيز مكانة الثقافة والموروث الحساني في النموذج التنموي الخاص بالأقاليم الجنوبية وضمن التطور المجتمعي الوطني", null, null, "برامج معززة لمكانة الموروث الثقافي الحساني في النموذج التنموي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 100, "100", 2, 2, 1, 30, 9, 1, "تعزيز استعمال اللغة العربية في المرافق العمومية وباقي مناحي الحياة العامة", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 98, "98", 2, 2, 1, 30, 9, 2, "  الإسراع بإصدار القانون التنظيمي المتعلق بالمجلس الوطني للغات والثقافة المغربية", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 95, "95", 2, 2, 3, 30, 8, 1, "  تقوية قيم التسامح والعيش المشترك واحترام حقوق الإنسان ونبذ الكراهية والعنف والتطرف في المناهج التربوية وفي الفضاء المدرسي.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 91, "91", 2, 1, 1, 30, 8, 1, "  إيجاد آليات إدارية تحفز المدرسين على المشاركة الفعالة في المشاريع المدرسية والتربوية وتسمح بتوسيع مشاركة التلاميذ فيها", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 62, "62", 1, 2, 3, 30, 5, 2, " تقوية الخبرة الفنية فيما يخص عمل لجان تقصي الحقائق البرلمانية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 57, "57", 1, 1, 3, 30, 5, 1, "تبسيط وتيسير وتعميم نشر المذكرات والدوريات المتعلقة بحقوق الإنسان المعمول بها في المؤسسات الأمنية على كافة موظفيها المكلفين بتنفيذ القانون.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 180, "180", 2, 1, 2, 31, 12, 2, "وضع سياسة إعلامية تيسر التواصل الموجه في مجال تمتع الفئات الاجتماعية من الحق في السكن اللائق. ", null, null, "برامج إعلامية لتعزيز التواصل حول الحق في السكن اللائق" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 19, "19", 1, 2, 3, 30, 2, 2, " تعزيز دور وسائل الإعلام في نشر قيم ومبادئ المساواة والمناصفة وتكافؤ الفرص ومحاربة التمييز.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 192, "192", 2, 1, 1, 31, 13, 2, " تخصيص تحفيزات مالية وتقنية لدعم المشاريع في مجال البيئة والتنمية المستدامة.", null, null, "موارد مالية مساهمة في دعم المشاريع الصديقة للبيئة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 288, "288", 3, 1, 3, 31, 17, 1, "تقوية مشاركة الشباب في خدمات الإعلام والتواصل. ", null, null, "آليات داعمة لتمكين الشباب من التواصل والولوج إلى المعلومة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 401, "401", 4, 1, 3, 33, 22, 1, "مواصلة برامج التدريب وتطوير القدرات في مجال التكوين والتكوين المستمر على حقوق النساء لفائدة القضاة ومساعدي العدالة.", null, null, "برامج مساعدة على تقوية القدرات في مجال حقوق النساء" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 363, "363", 4, 1, 1, 33, 21, 1, "الإسراع باعتماد قانون جديد منظم للسجون بما يضمن أنسنة المؤسسات السجنية وتحسين ظروف إقامة النزلاء وتغذيتهم وحماية باقي حقوقهم.", null, null, "إطار قانوني داعم لأنسنة المؤسسات السجنية  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 349, "349", 3, 2, 1, 33, 20, 1, "حماية حقوق الأطفال المغاربة المهاجرين غير المرفقين في دول الاستقبال.", null, null, "برامج متخصصة مع جمعيات ومنظمات في مجال حماية حقوق الأطفال مبلورة ومنفذة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 317, "317", 3, 1, 1, 33, 18, 1, " وضع نظام جديد لتقييم الإعاقة يتلاءم والمفهوم الطبي والنفسي والاجتماعي المعتمد بموجب الاتفاقية الدولية لحقوق الأشخاص ذوي الإعاقة.", null, null, "نظام جديد لتقييم الإعاقة معتمد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 304, "304", 3, 2, 1, 33, 18, 2, " تعزيز التمدرس بالقسم الدراسي العادي مع توفير الترتيبات التيسيرية اللازمة وتوسيع شبكة الأقسام المدمجة لتشمل المستوى الإعدادي والثانوي وجعل المراكز المتخصصة جزء من المنظومة التعليمية الوطنية.", null, null, "تضاعف عدد الممدرسين من الأطفال في وضعية إعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 297, "297", 3, 2, 1, 33, 18, 2, "ملاءمة التشريع الوطني مع مقتضيات الاتفاقية الدولية للأشخاص في وضعية إعاقة، لا سيما ما يتعلق بالأهلية القانونية.", null, null, "إطار قانوني ملائم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 240, "240", 3, 1, 1, 33, 16, 1, " مراجعة قانون الكفالة بما يتلاءم ومقتضيات الدستور.", null, null, "إطار تشريعي   وتنظيمي معتمد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 237, "237", 3, 1, 1, 33, 16, 2, " الإسراع بإحداث وتفعيل الآلية الوطنية للتظلم الخاصة بالأطفال ضحايا انتهاكات حقوق الطفل.", null, null, "الآلية الوطنية للتظلم الخاصة بالأطفال ضحايا انتهاكات حقوق الطفل مفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 181, "181", 2, 2, 3, 33, 12, 1, " وضع برامج تدريب وتكوين في مجالات التمتع بالحق في السكن اللائق والمصاحبة الاجتماعية الموجهة للفئات ذات الدخل المحدود وغير القار.", null, null, "برامج داعمة للتحسيس بالحق في السكن" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 175, "175", 2, 2, 1, 33, 12, 1, " حصر الاستفادة من برنامج السكن الاجتماعي في ذوي الدخل المحدود بالصرامة اللازمة", null, null, "آليات داعمة لتعزيز الحكامة في تنفيذ برامج السكن الاجتماعي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 66, "66", 1, 1, 1, 33, 6, 1, "تبسيط المساطر المتعلقة بالتصريح بالتجمعات العمومية من أجل تعزيز وضمان ممارسة الحريات العامة من طرف مختلف مكونات المجتمع (جمعيات، نقابات) والعمل على ضمان التطبيق السليم للمساطر المعمول بها في هذا المجال.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 65, "65", 1, 1, 1, 33, 6, 1, " تدقيق القواعد والإجراءات القانونية المتعلقة بمختلف أشكال وأصناف التظاهر (الوقفة، التجمع، التظاهر في الشارع العمومي، مسار التظاهرات...) من حيث السير والجولان والتوقيت.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 11, "11", 1, 1, 3, 33, 1, 2, " إحداث فضاءات لإثراء مشاركة اليافعين والشباب في الوسط التربوي والهيئات التمثيلية.", null, null, "برامج ومبادرات داعمة لمشاركة الشباب واليافعين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 426, "426", 4, 2, 1, 32, 26, 1, "  تسهيل ولوج المتقاضين إلى المحاكم وتيسير التواصل اللغوي في عملها.", null, null, "آليات داعمة لتيسير الولوج لخدمات العدالة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 422, "422", 4, 1, 3, 32, 25, 1, " تحسيس مصالح الإدارات العمومية بأهمية إيداع أرشيفها بانتظام لدى مصالح أرشيف المغرب طبقا للنصوص الجاري بها العمل.", null, null, "مصالح الإدارات العمومية منخرطة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 384, "384", 4, 1, 1, 32, 22, 1, "مواصلة ترصيد المكتسبات المعرفية المتعلقة بالكد والسعاية في التشريع والعمل القضائي.", null, null, "دينامية داعمة لترصيد الاجتهادات العلمية/الفقهية والقضائية المتعلقة بالكد والسعاية  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 357, "357", 3, 2, 3, 32, 20, 2, " تعزيز البرامج الإعلامية الموجهة إلى المهاجرين.", null, null, "بيئة إعلامية داعمة لحقوق المهاجرين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 351, "351", 3, 1, 1, 32, 20, 2, "مواصلة المجهودات المبذولة للرقي بالبرامج الموجهة لفائدة مغاربة العالم والاستجابة لانتظاراتهم الثقافية واللغوية والدينية والتربوية في بلدان الاستقبال وتعزيز التواصل بينهم وبين بلدهم الأصلي.", null, null, "برامج متنوعة تستجيب لإنتظارات مغاربة العالم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 310, "310", 3, 2, 1, 32, 18, 2, " اعتماد مقاربة التنمية الدامجة بشكل عرضاني في كل البرامج والسياسات المرتبطة بمجال الإعاقة.", null, null, "مقاربة التنمية الدامجة مفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 193, "193", 2, 2, 1, 32, 13, 1, " تعزيز الجهود الرامية إلى تحسين التقييم الاستراتيجي البيئي.", null, null, "إطار مرجعي وطني للتقييم الاستراتيجي البيئي معزز" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 160, "160", 2, 2, 1, 32, 11, 2, " تقوية هيئة مفتشي الشغل.", null, null, "هيئة مفتشي الشغل معززة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 101, "101", 2, 1, 1, 32, 9, 2, "تقوية مكانة اللغة العربية في البحث العلمي والتقني الجامعي والأكاديمي", null, null, "برامج داعمة لتعزيز مكانة اللغة العربية في الجامعة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 53, "53", 1, 2, 1, 32, 5, 1, "العمل على تأمين تغذية الأشخاص الموضوعين رهن الحراسة النظرية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 208, "208", 2, 2, 3, 31, 13, 1, " النهوض بثقافة حماية البيئة عبر التربية والتكوين والتكوين المستمر والتحسيس.", null, null, "برامج داعمة للنهوض بالثقافة البيئية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 10, "10", 1, 1, 3, 30, 1, 1, " وضع برامج لتربية الأطفال على قيم المواطنة في الوسط التربوي ودعم برلمان الطفل وكافة أشكال تفعيل حقوق المشاركة لدى الأطفال.", null, null, "برامج داعمة لقيم المواطنة ومشاركة الأطفال " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 420, "420", 4, 1, 1, 29, 25, 2, " رصد مصادر الأرشيف الخاصة بالمغرب والموجودة خارج الوطن ومواصلة استرجاعها ومعالجتها وحفظها وتيسير الاطلاع عليها من قبل المهتمين. ", null, null, "الأرصدة الوثائقية المتعلقة بالمغرب والموجودة بالخارج مرصودة ومعالجة وميسرة للاطلاع" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 381, "381", 4, 2, 1, 29, 22, 1, " تعزيز الخطة الحكومية للمساواة في أفق المناصفة إكرام 2", null, null, "الإعمال الناجع لخطة إكرام 2" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 337, "337", 3, 1, 1, 27, 19, 1, "دعم الأسر التي تحتضن أفرادا مسنين في وضعية صعبة.", null, null, "إطار داعم لخدمات التكفل بالأفراد المسنين في وضعية صعبة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 330, "330", 3, 2, 1, 27, 19, 2, " حماية حقوق وكرامة الأشخاص المسنين بتجويد معايير وخدمات التكفل على مستوى البنيات والموارد البشرية.", null, null, "بنيات مهيكلة وفق معايير الجودة، مؤهلة لصيانة حقوق وكرامة الأشخاص المسنين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 305, "305", 3, 1, 1, 27, 18, 1, "النهوض بالحق في الشغل للأشخاص في وضعية إعاقة من خلال تطبيق نسب التوظيف القانونية. ", null, null, "آليات ضامنة لتطبيق النسب القانونية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 300, "300", 3, 1, 1, 27, 18, 1, " دعم عمل آلية التنسيق الحكومية ذات الصلة بالمجال.", null, null, "آلية مؤسساتية داعمة لتنفيذ الاستراتيجية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 280, "280", 3, 2, 1, 27, 17, 1, " وضع تدابير تشريعية وتنظيمية في مجال حماية الجمهور الناشئ ضد المخاطر المترتبة عن الاستعمال السيئ لوسائل التواصل المعتمدة على التكنولوجيات الحديثة. ", null, null, "إطار قانوني داعم لحماية الجمهور الناشئ  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 261, "261", 3, 1, 1, 27, 16, 2, " تنظيم وتتبع أوضاع كفالة الأطفال خارج المغرب.", null, null, "آليات مساعدة على تتبع أوضاع كفالة الأطفال خارج المغرب  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 210, "210", 2, 2, 3, 27, 13, 2, " تكوين القضاة والشرطة القضائية والبيئية في مجال الحقوق البيئية.", null, null, "قدرات متطورة في مجال التكوين القضائي التخصصي   " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 112, "112", 2, 2, 1, 27, 9, 2, "تعزيز الشراكات بين المؤسسات الثقافية العمومية والقطاع الخاص ومنظمات الشباب والمجتمع المدني.", null, null, "شراكات داعمة لإبداعات الشباب " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 82, "82", 1, 1, 1, 27, 8, 1, "تفعيل الرؤية الاستراتيجية لإصلاح التعليم 2015-2030 من أجل مدرسة الجودة والارتقاء، وإصدار القانون الإطار الخاص بها", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 41, "41", 1, 1, 1, 27, 4, 2, " تقوية الحوار العمومي حول منجز مؤسسات الرقابة والحكامة.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 433, "433", 4, 2, 3, 26, 26, 1, "تأهيل الموارد البشرية لإدارة العدالة وهيئات وجمعيات المهن القانونية من خلال وضع برامج في مجال التكوين والتكوين المستمر وتقويم الأداء.", null, null, "قدرات الموارد البشرية لمنظومة العدالة معززة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 431, "431", 4, 2, 1, 26, 26, 2, " تفعيل المقتضيات الدستورية المتعلقة بتقوية الدور الرقابي للبرلمان على الحكومة والمؤسسات التابعة للدولة من خلال لجن التقصي وغيرها من الآليات المتوفرة.", null, null, "إطار قانوني داعم للدور الرقابي للبرلمان على الحكومة والمؤسسات التابعة للدولة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 430, "430", 4, 1, 1, 26, 26, 1, " وضع سياسة فعالة تضمن تنفيذ الأحكام الصادرة ضد كافة مؤسسات الدولة والخواص.", null, null, "سياسة داعمة لتنفيذ الاحكام القضائية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 409, "409", 4, 2, 1, 26, 23, 1, " تعزيز دور المكتب المغربي لحقوق المؤلفين ومراجعة قانونه ليصبح مؤسسة عمومية.", null, null, "إطار قانوني داعم لحقوق المؤلف" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 346, "346", 3, 2, 1, 26, 20, 1, " مواصلة تطوير الاتفاقيات الخاصة بالحماية الاجتماعية المبرمة بين المغرب ودول الاستقبال وفق مقاربة حقوق الإنسان.", null, null, "الإطار الاتفاقي الثنائي في مجال الحماية الاجتماعية معزز وفق مقاربة حقوق الانسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 267, "267", 3, 2, 1, 26, 16, 2, " العمل على تطوير شراكات مع دول الاستقبال لحماية الأطفال المغاربة من الاستغلال إعمالا لمصلحتهم الفضلى.", null, null, "الشراكات مع دول الاستقبال لحماية الأطفال المغاربة من الاستغلال مطورة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 220, "220", 3, 1, 1, 26, 15, 1, " إصدار القانون المتعلق بشروط فتح وإحداث وتدبير مؤسسات الرعاية الاجتماعية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 217, "217", 2, 2, 3, 26, 14, 1, " تشجيع تبادل التجارب والممارسات الفضلى بين المقاولات في مجال احترام حقوق الإنسان في المقاولة.", null, null, "مبادرات داعمة لترسيخ الممارسات الفضلى في مجال المقاولة وحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 202, "202", 2, 2, 1, 26, 13, 1, " تعزيز آليات التنسيق بين القطاعات المعنية بالبيئة والتنمية المستدامة.", null, null, "آليات مؤسساتية داعمة لتنسيق تنفيذ برامج التنمية المستدامة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 187, "187", 2, 2, 1, 26, 13, 2, " الإسراع بإصدار المرسوم المتعلق بإحداث نظام وطني لجرد الغازات الدفيئة تطبيقا لمقتضيات الاتفاقية الإطارية للأمم المتحدة المتعلق بتغير المناخ.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 157, "157", 2, 2, 1, 26, 11, 2, " تشجيع المشاريع المذرة للدخل.", null, null, "برامج داعمة للمقاولات الصغرى  والمتوسطة / أنشطة داعمة لتحسين الدخل والإدماج الاقتصادي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 115, "115", 2, 2, 1, 26, 9, 2, "تعزيز القواعد المنظمة للسكن اللائق بإحداث مرافق تعزز الحياة والإبداع الثقافيين.", null, null, "برامج سكنية معززة للحياة الثقافية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 68, "68", 1, 1, 1, 26, 6, 1, "تعزيز الشراكة بين مؤسسات الدولة والجمعيات والرفع من مستوى حكامتها.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 361, "361", 4, 1, 1, 27, 21, 1, " مواصلة الانخراط في اتفاقيات مجلس أوروبا المفتوحة للبلدان غير الأعضاء.", null, null, "ممارسة اتفاقية في مجال حقوق الإنسان معززة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 368, "368", 4, 2, 1, 27, 21, 2, "إحداث مرصد وطني للإجرام.", null, null, "آلية مؤسساتية مساعدة على تتبع تطور ظاهرة الإجرام" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 378, "378", 4, 2, 3, 27, 21, 1, "تعزيز برامج التكوين الأساسي والتكوين المستمر في المعاهد والمراكز المعنية بالمكلفين بإنفاذ القانون.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 389, "389", 4, 2, 1, 27, 22, 2, " تعزيز آليات الرصد والتتبع لحماية النساء ضحايا العنف وطنيا جهويا ومحليا.", null, null, "آليات فعالة لحماية النساء ضحايا العنف" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 354, "354", 3, 2, 3, 29, 20, 1, " تقوية نقط التواصل بالسفارات والقنصليات وتيسير الخدمات لفائدة المغاربة المقيمين بالخارج.", null, null, "الخدمات المقدمة من طرف نقط التواصل بالسفارات والقنصليات ميسرة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 245, "245", 3, 1, 1, 29, 16, 2, " وضع مؤشرات التتبع والتقييم في مجال حماية الأطفال من سوء المعاملة ومن كل أشكال الاستغلال والعنف.", null, null, " منظومة المؤشرات الخاصة بتتبع وضعية حماية الأطفال وتقييمها معتمدة ومفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 244, "244", 3, 2, 1, 29, 16, 2, " تطوير وتفعيل المقتضيات القانونية الخاصة بتجريم الاستغلال الجنسي للأطفال والاتجار بهم مع تشديد العقوبات على الجناة.", null, null, "إطار قانوني داعم    لحماية حقوق الطفل " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 222, "222", 3, 1, 1, 29, 15, 1, " دعم الآليات والتدابير الكفيلة ببلورة وتيسير تتبع وتقييم السياسات العمومية والبرامج التي تستهدف الحماية والنهوض بالحقوق الفئوية.", null, null, "آليات كفيلة بتطوير نجاعة البرامج الخاصة بالحقوق الفئوية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 158, "158", 2, 2, 1, 29, 11, 1, "تعزيز الخدمات الاجتماعية الموجهة إلى العمال والأجراء.", null, null, "ارتفاع عدد المقاولات المحدثة للخدمات الاجتماعية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 152, "152", 2, 2, 1, 29, 11, 1, "تشجيع وتقوية أدوار لجان الحوار والمصالحة الإقليمية والوطنية.", null, null, "اللجان الإقليمية للبحث والمصالحة مفعلة على مستوى العمالات والأقاليم." });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 150, "150", 2, 2, 1, 29, 11, 2, " النظر في المصادقة على اتفاقية منظمة العمل الدولية رقم 118 التي تهم المساواة في معاملة مواطني البلد والذين ليسوا من مواطني البلد في مجال الضمان الاجتماعي.", null, null, "بلورة تصور " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 149, "149", 2, 1, 1, 29, 11, 1, " استكمال مسطرة المصادقة على اتفاقية منظمة العمل الدولية رقم 102 المتعلقة بالمعايير الدنيا للضمان الاجتماعي.", null, null, "المصادقة على تفاقية منظمةا لعمل الدولية رقم 102 المتعلقة بالمعاييرالدنيا للضمان الاجتماعي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 116, "116", 2, 2, 1, 29, 9, 1, " توسيع شبكة المراكز والمركبات الثقافية لتشمل عموم المناطق الحضرية والقروية.", null, null, "مركبات ثقافية جهوية ومحلية مساهمة في الإشعاع الثقافي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 51, "51", 1, 1, 1, 29, 5, 1, "-51-التوثيق السمعي البصري للتدخلات الأمنية لفض التجمعات العمومية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 7, "7", 1, 1, 3, 29, 1, 2, "تعزيز دور وسائل الإعلام في مجال التوعية والاتصال والحوار العمومي بشأن المشاركة السياسية.", null, null, "برامج داعمة للمشاركة السياسية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 404, "404", 4, 2, 1, 25, 23, 1, " الإسراع بوضع ميثاق أخلاقيات مهنة الصحافة والإعلام بما في ذلك الصحافة الإلكترونية.", null, null, "ميثاق أخلاقيات مهنة الصحافة والإعلام معتمد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 434, "434", 4, 2, 3, 28, 26, 2, " تعزيز إدماج مرجعية حقوق الإنسان والتربية على المواطنة ضمن برامج التكوين بالمعهد العالي للقضاء.", null, null, "قدرات متطورة في مجال التكوين القضائي التخصصي; برامج مساهمة في توسيع المعارف وتعزيز القدرات في مجال حقوق الإنسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 390, "390", 4, 2, 1, 28, 22, 2, " مواصلة تفعيل مقتضيات صندوق التكافل العائلي وتبسيط مساطره.", null, null, "مقتضيات داعمة لتوسيع دائرة المستفيدين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 388, "388", 4, 2, 1, 28, 22, 2, " صيانة الكرامة الإنسانية للمرأة في وسائل الإعلام، ووضع تدابير زجرية في حالة انتهاكها. ", null, null, "إجراءات داعمة لصيانة كرامة المرأة في وسائل الاعلام" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 328, "328", 3, 2, 1, 28, 19, 2, " وضع إطار استراتيجي للنهوض بحقوق الأشخاص المسنين وحمايتها.", null, null, "إطار استراتيجي معد ومعتمد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 320, "320", 3, 1, 1, 28, 18, 2, " دعم وتشجيع مبادرات المجتمع المدني العامل في مجال الإعاقة.", null, null, "مجتمع مدني متفاعل في مجال الإعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 299, "299", 3, 1, 1, 28, 18, 1, " الإسراع بإحداث الآلية الوطنية لحماية حقوق الأشخاص في وضعية إعاقة وفقا لمقتضيات اتفاقية حقوق الأشخاص ذوي الإعاقة.", null, null, "الآلية الوطنية لحماية حقوق الأشخاص في وضعية إعاقة مفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 168, "168", 2, 2, 1, 28, 12, 2, " الإسراع بإصدار مشاريع القوانين ذات الصلة بالتعمير وفق منظور يتوخى التنمية البشرية المستدامة ويراعي التنوع المجالي والخصوصيات المحلية والهوية المعمارية لمختلف الأقاليم.", null, null, "منظومة قانونية للتعمير داعمةللتنمية المستدامة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 159, "159", 2, 1, 1, 28, 11, 2, " تقوية آلية التعويض عن فقدان الشغل.", null, null, "إطار قانوني داعم لحماية العمال      والأجراء عند فقدان الشغل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 131, "131", 2, 2, 1, 28, 10, 2, " دعم الموارد البشرية الطبية وشبه الطبية والإدارية ومواصلة تعزيز الكفاءات عن طريق التكوين والتكوين المستمر.", null, null, "برامج داعمة لتعزيز كفاءات القطاع الصحي   " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 102, "102", 2, 1, 1, 28, 9, 1, "تعزيز مكانة اللغة والثقافة الأمازيغية في المجالات الثقافية والإدارية والقضائية وباقي مناحي الحياة العامة.", null, null, "ديناميات داعمة لتعزيز مكانة اللغة والثقافة الأمازيغية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 93, "93", 2, 1, 1, 28, 8, 1, "  اعتماد آلية المساعدة الاجتماعية في الوسط المدرسي", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 54, "54", 1, 2, 1, 28, 5, 2, "دعم المؤسسات الأمنية بالموارد البشرية والمالية والتقنية اللازمة.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 415, "415", 4, 1, 3, 28, 24, 2, " جرد التراث الثقافي وتوثيقه وتصنيفه.", null, null, " تراث ثقافي موثق ومصنف" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 413, "413", 4, 2, 1, 33, 24, 1, "وضع النصوص التطبيقية للقانون المنظم لحماية التراث الثقافي.", null, null, "نصوص تنظيمية داعمة لحماية التراث الثقافي." });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 9, "9", 1, 1, 3, 17, 1, 2, "دعم وتشجيع البرامج والأنشطة المتعلقة بالتنشئة السياسية والاجتماعية الهادفة إلى نشر قيم الديمقراطية والمساواة والتعدد والاختلاف والتسامح والعيش المشترك وعدم التمييز ونبذ الكراهية والعنف والتطرف.", null, null, "مجتمع داعم لقيم الديمقراطية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 396, "396", 4, 1, 1, 16, 22, 1, "تعزيز البرامج الخاصة بالقضاء على الفقر والتهميش والإقصاء الاجتماعي في أوساط النساء.", null, null, "البرامج الخاصة بالقضاء على الفقر والتهميش والإقصاء الاجتماعي في أوساط النساء معززة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 256, "256", 3, 1, 1, 6, 16, 1, " تفعيل دورية وزارة الداخلية المتعلقة باختيار الأسماء الشخصية. ", null, null, "آليات ميسرة لإعمال الدورية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 203, "203", 2, 1, 1, 6, 13, 1, " تيسير ولوج المواطنات المواطنين إلى القضاء عند التعرض للأضرار البيئية لأجل تحقيق عدالة بيئية.", null, null, "معرفة مساعدة على تيسير الحق في العدالة البيئية  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 186, "186", 2, 1, 1, 6, 13, 1, " الإسراع بإصدار القانون المتعلق بالحصول على الموارد الجينية والتقاسم العادل والمنصف للمنافع الناشئة عن استخدامها إعمالا للاتفاقية المتعلقة بالتنوع البيولوجي وبروتوكول ناغويا.", null, null, "إطار قانوني معتمد وفق المعايير الدولية ذات الصلة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 142, "142", 2, 1, 1, 6, 10, 1, "تخليق المرفق الصحي وعقلنة طرق تدبير الأدوية والمستلزمات الطبية داخل المستشفيات.", null, null, "آليات مساعدة على التدبير المعقلن وداعمة لتخليق المرفق الصحي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 124, "124", 2, 2, 1, 6, 9, 2, "وضع ميثاق وطني في مجال التنوع الثقافي موجه إلى كافة المتدخلين والفاعلين.", null, null, "ميثاق وطني في مجال التنوع الثقافي معتمد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 94, "94", 2, 1, 1, 6, 8, 1, "  تيسير شروط ولوج التعليم العالي وتقوية وتثمين البحث العلمي والرفع من الميزانية المخصصة له", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 74, "74", 1, 2, 1, 6, 7, 2, "تعزيز المقتضيات القانونية المتعلقة بجبر ضرر ضحايا انتهاكات حقوق الإنسان.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 39, "39", 1, 2, 1, 6, 4, 2, " تعزيز طرق وأشكال التبليغ عن حالات الفساد، بما في ذلك وضع خط أخضر وتيسير تقديم الشكايات.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 34, "34", 1, 2, 1, 6, 4, 2, " تفعيل أدوار مؤسسات الحكامة والديمقراطية التشاركية في اقتراح التدابير ذات الأثر المباشر على مكافحة الفساد ودعم عملها في كل ما يخص نشر قيم النزاهة والشفافية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 5, "5", 1, 1, 1, 6, 1, 1, "تكريس مبدأ التشاور العمومي في إعداد السياسات العمومية وتنفيذها وتقييمها، وكذا تفعيل دور الجمعيات المهتمة بقضايا الشأن العام والمنظمات غير الحكومية في المساهمة في إعداد القرارات والمشاريع لدى المؤسسات المنتخبة والسلطات العمومية وتفعيلها وتقييمها.", null, null, "مقتضيات قانونية تعزز المشاركة المواطنة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 392, "392", 4, 2, 1, 5, 22, 1, " التفعيل الحازم لمقتضيات قانون الاتجار بالبشر المتعلقة بحماية الأطفال والنساء الضحايا.", null, null, "إجراءات داعمة لحماية الأطفال والنساء ضحايا الاتجار بالبشر " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 386, "386", 4, 2, 1, 5, 22, 1, "  تعزيز الضمانات القانونية المتعلقة بتجريم التحرش الجنسي.", null, null, "إطار قانوني داعم لحماية النساء ضحايا العنف" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 312, "312", 3, 1, 1, 5, 18, 1, " تفعيل المخطط الوطني للصحة والإعاقة.", null, null, "مخطط وطني للصحة والإعاقة      مفعل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 285, "285", 3, 1, 1, 5, 17, 1, " وضع برامج استعجالية لفائدة فئات الشباب الأكثر هشاشة (في وضعية إعاقة أو إقصاء...).", null, null, "برامج مساعدة على إدماج الشباب الأكثر هشاشة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 247, "247", 3, 2, 1, 5, 16, 2, "نقل جميع الاختصاصات المخولة للجنة العليا للحالة المدنية في موضوع الأسماء العائلية إلى القضاء.", null, null, "آليات وسبل إعمال الحق في الهوية معززة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 209, "209", 2, 1, 3, 5, 13, 2, " تعزيز برامج دعم القدرات في مجال البيئة والتنمية المستدامة.", null, null, "برامج مساعدة على رفع القدرات في مجال البيئة والتنمية المستدامة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 195, "195", 2, 2, 1, 5, 13, 1, "تأمين مشاركة ومساهمة مختلف الفاعلين وخاصة منظمات المجتمع المدني والهيئات السياسية والنقابية والإعلامية في النهوض بالثقافة البيئية ومختلف البرامج البيئية.", null, null, "برامج داعمة للنهوض بالثقافة البيئية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 169, "169", 2, 1, 1, 5, 12, 1, " تفعيل القانون للحد من التجاوزات في ميدان التعمير والإسكان وزجر المخالفات وضمان سلامة البناء في الوسطين الحضري والقروي.", null, null, "منظومة قانونية داعمة للحد من التجاوزات في ميدان التعمير والإسكان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 120, "120", 2, 2, 1, 5, 9, 2, " ترميم وصيانة المواقع الأثرية والصخرية وتأمين حراستها حفاظا على التراث الثقافي الوطني وتعزيز آليات حمايته من الإتلاف والحفاظ على الذاكرة في بعديها الوطني والمحلي.", null, null, "منظومة حافظة للمواقع الأثرية والصخرية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 42, "42", 1, 2, 3, 5, 4, 1, "وضع سياسة إعلامية وخطط تواصلية لبلوغ أهداف الاستراتيجية الوطنية لمكافحة الفساد وفق مقاربة تتأسس على سيادة القانون واحترام حقوق الإنسان.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 412, "412", 4, 2, 1, 3, 24, 1, " التشجيع على الانضمام إلى الاتفاقيات الدولية المتعلقة بحماية التراث الثقافي والمحافظة عليه.", null, null, "تعزيز الممارسة الاتفاقية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 377, "377", 4, 2, 3, 3, 21, 2, "وضع برامج للتدريب والتكوين المستمر على سيادة القانون واحترام حقوق الإنسان تتأسس على الدستور والرصيد الثري للاجتهاد القضائي المغربي والممارسات الفضلى ذات الصلة لفائدة مكونات العدالة ومساعديها.", null, null, "برامج للتكوين داعمة لتمكين الجهاز القضائي من ثقافة حقوق الانسان  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 342, "342", 3, 1, 3, 3, 19, 1, "تعزيز العمل المؤسسي للجمعيات التي تعنى بأوضاع الأشخاص المسنين", null, null, "العمل الجمعوي معزز في مجال النهوض بأوضاع الأشخاص المسنين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 269, "269", 3, 1, 1, 6, 16, 2, "تفعيل ميثاق السياحة المستدامة من أجل وضع برامج وقائية لحماية الأطفال من الأشخاص الذين يستغلون السياحة لأسباب جنسية.", null, null, "آليات داعمة لحماية الأطفال من الاستغلال الجنسي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 282, "282", 3, 2, 1, 3, 17, 1, "مراجعة القوانين التنظيمية للجماعات الترابية بكيفية تمكن الشباب من المساهمة الفعالة في تدبير الشأن المحلي.", null, null, "إطار قانوني تنظيمي داعم لمساهمة الشباب في تدبير الشأن المحلي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 323, "323", 3, 2, 1, 6, 18, 2, " تسهيل الولوج لإعادة تأهيل الأشخاص في وضعية إعاقة من خلال إحداث وتجهيز مراكز الترويض في مختلف الجهات والنهوض بأنظمة التكوين الطبي وشبه الطبي مصادق عليها ومستجيبة لمجموع الحاجيات.", null, null, "بنيات داعمة لإعادة تأهيل الأشخاص في وضعية إعاقة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 24, "24", 1, 1, 1, 7, 3, 2, " مواصلة دعم الجهات بمناسبة وضع التصاميم الجهوية المقترحة لإعداد التراب.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 238, "238", 3, 1, 1, 8, 16, 2, " مواصلة تقوية الإطار القانوني المتعلق بحماية الأطفال وضمان فعاليته.", null, null, "إطار قانوني داعم لحماية حقوق  الأطفال" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 228, "228", 3, 1, 1, 8, 15, 2, " وضع أنظمة معلوماتية لتتبع الحقوق الفئوية.", null, null, "أنظمة معلوماتية مساعدة على تتبع الحقوق الفئوية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 215, "215", 2, 1, 3, 8, 14, 1, " تعزيز المشاركة الوطنية في اللقاءات الدولية والجهوية المتعلقة بالمقاولة وحقوق الإنسان.", null, null, "دينامية داعمة لترصيد وتملك وتبادل الخبرات والممارسات الفضلى في مجال المقاولة وحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 206, "206", 2, 2, 3, 8, 13, 2, "تنظيم حملات تحسيسية بمتطلبات ترشيد وعقلنة تدبير الموارد الطبيعية وحماية البيئة عبر وسائل الإعلام المكتوبة والمسموعة والمرئية والإلكترونية.", null, null, "برامج إعلامية داعمة لحماية البيئة  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 185, "185", 2, 1, 1, 8, 13, 1, " مراجعة النصوص التشريعية والتنظيمية مع المعايير ذات الصلة بالجودة البيئية الجاري بها العمل لاسيما التشريع المتعلق بالماء والطاقات المتجددة والتنوع البيولوجي ومحاربة تلوث الهواء والتغييرات المناخية وتدبير وتثمين النفايات والتقييم البيئي واستصلاح البيئة ووضع تدابير لردع وزجر المخالفات البيئية. ", null, null, "إطار قانوني متلائم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 75, "75", 1, 1, 1, 8, 7, 2, "حماية المشتكين والمبلغين والشهود والمدافعين عن حقوق الإنسان من أي سوء معاملة ومن أي ترهيب بسبب شكاويهم أو شهاداتهم أمام السلطات العمومية والقضائية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 64, "64", 1, 1, 1, 8, 6, 1, "مراجعة القوانين المنظمة للحريات العامة لضمان انسجامها مع الدستور من حيث القواعد القانونية الجوهرية والإجراءات الخاصة بفض التجمعات العمومية والتجمهر والتظاهر وذلك في إطار احترام المعايير الدولية والقواعد الديمقراطية المتعارف عليها.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 45, "45", 1, 1, 1, 8, 5, 1, "مراجعة المقتضيات القانونية بما يسمح بمرافقة الدفاع للشخص المعتقل بمجرد وضعه تحت الحراسة النظرية لدى الضابطة القضائية، ومواصلة ملاءمة الإطار التشريعي المنظم للبحث التمهيدي والحراسة النظرية والتفتيش وكافة الإجراءات الضبطية وملاءمتها مع المعايير الدولية ذات الصلة.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 4, "4", 1, 2, 1, 8, 1, 2, "الإسراع بتفعيل هيئة المناصفة ومكافحة جميع أشكال التمييز. ", null, null, "هيئة المناصفة ومكافحة جميع أشكال التمييز مفعلة." });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 429, "429", 4, 2, 1, 7, 26, 2, "مواصلة جهود تخليق العدالة.", null, null, "دينامية داعمة لتخليق العدالة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 414, "414", 4, 2, 1, 7, 24, 2, " مراجعة النصوص المتعلقة بالتراث الثقافي.", null, null, "إطار قانوني معزز" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 406, "406", 4, 2, 1, 7, 23, 1, " النهوض بمعاهد التكوين في مجال الإعلام.", null, null, "منظومة وطنية للتكوين في مجال الإعلام مستجيبة لحاجيات القطاع من الكفاءات كما وكيفا  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 394, "394", 4, 1, 1, 7, 22, 2, "إدماج بعد النوع الاجتماعي في السياسات والميزانيات ووضع آليات للمتابعة والتقييم.", null, null, "آليات داعمة لإدماج بعد النوع في السياسات والميزانيات" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 345, "345", 3, 2, 1, 7, 20, 2, " وضع المقتضيات التنظيمية الخاصة بقانون مكافحة الاتجار بالبشر.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 331, "331", 3, 2, 1, 7, 19, 1, "تحفيز البحث العلمي والدراسات الجامعية حول أوضاع الأشخاص المسنين وآثار الشيخوخة في مختلف المستويات الديمغرافية والاقتصادية والاجتماعية.", null, null, "بيئة داعمة للبحث العلمي حول أوضاع الأشخاص المسنين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 316, "316", 3, 2, 1, 7, 18, 2, " تقوية موارد وخدمات صندوق دعم التماسك الاجتماعي الموجهة للأشخاص في وضعية إعاقة. ", null, null, "خدمات الصندوق مستجيبة لحاجيات الفئة المستفيدة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 294, "294", 3, 2, 3, 7, 17, 2, " تعزيز المقررات المدرسية والجامعية بمصوغات بيداغوجية تعنى بحقوق الانسان وبالتربية على المواطنة.", null, null, "بيئة تربوية داعمة لترسيخ ثقافة حقوق الإنسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 291, "291", 3, 1, 3, 7, 17, 1, " وضع قاعدة معلومات خاصة بالشباب. ", null, null, "قاعدة معلومات مساعدة على التخطيط     والبرمجة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 225, "225", 3, 1, 1, 7, 15, 1, "إدماج العمل التطوعي الاجتماعي في الوسطين التربوي والجامعي.", null, null, "دينامية داعمة لترسيخ العمل التطوعي في الوسطين التربوي والجامعي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 128, "128", 2, 2, 1, 7, 10, 1, "ضمان العدالة المجالية في الميدان الصحي من خلال خريطة صحية عادلة تغطي مكونات التراب الوطني.", null, null, "خريطة صحية داعمة للعدالة المجالية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 87, "87", 1, 2, 1, 7, 8, 2, "   إدماج المقاربة الحقوقية في جميع الأنشطة التربوية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 76, "76", 1, 1, 1, 7, 7, 2, " وضع إطار تشريعي وتنظيمي مستقل لمأسسة الطب الشرعي.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 50, "50", 1, 1, 1, 7, 5, 2, "مراعاة الضرورة والتناسب أثناء استعمال القوة في فض التجمعات العمومية وفي التجمهرات والتظاهرات السلمية. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 6, "6", 1, 2, 3, 7, 1, 2, "  إغناء وإثراء الحوار العمومي الخاص بالمشاركة السياسية من خلال برامج تسهل وتضمن ولوج مختلف الفاعلين (أحزاب سياسية، نقابات، جمعيات...) للخدمات الإعلامية العمومية لتعزيز مساهمتهم في تأطير المواطنات والمواطنين وتطوير التعددية والحكامة السياسية.", null, null, "فضاء سمعي بصري داعم للمشاركة السياسية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 279, "279", 3, 2, 1, 3, 17, 2, " تفعيل المجلس الاستشاري للشباب والعمل الجمعوي وإصدار النصوص التشريعية والتنظيمية المتعلقة به.", null, null, "المجلس الاستشاري للشباب والعمل الجمعوي مفعل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 265, "265", 3, 1, 1, 3, 16, 1, "اتخاذ تدابير خاصة بحماية الأطفال المهاجرين غير المرافقين وبولوجهم إلى الخدمات الأساسية لا سيما تلك المتعلقة بالصحة والتربية والتعليم.", null, null, "برامج داعمة لحماية الأطفال المهاجرين غير المرافقين " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 212, "212", 2, 2, 3, 3, 14, 1, "-212- تحفيز المقاولات على وضع ميثاق داخلي عام للسلوك في مجال حقوق الإنسان.", null, null, "بيئة داعمة للنهوض بحقوق الإنسان داخل المقاولة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 273, "273", 3, 1, 3, 2, 16, 2, " إشاعة ثقافة حقوق الطفل داخل مؤسسات الرعاية الاجتماعية المستقبلة للأطفال.", null, null, "ثقافة حقوق الطفل مشاعة داخل مؤسسات الرعاية الاجتماعية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 233, "233", 3, 2, 3, 2, 15, 1, "تشجيع ودعم المبادرات التحسيسية الهادفة إلى حماية الفئات الاجتماعية في وضعية هشاشة", null, null, "برامج داعمة لحماية الفئات الاجتماعية في وضعية هشاشة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 218, "218", 2, 2, 3, 2, 14, 2, "وضع برامج تكوينية في مجال حقوق الإنسان في المقاولة لفائدة كل المتدخلين وأصحاب المصلحة (مسؤولو المقاولة والأطر النقابية والفاعلون المدنيون والقضاة والمحامون ومفتشو الشغل).", null, null, "برامج تكوينية مساعدة على الرفع من مستوى الوعي بحقوق الإنسان في المقاولة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 176, "176", 2, 1, 1, 2, 12, 1, " مضاعفة الإمكانيات المالية لصناديق الضمان الموجهة للشرائح الاجتماعية ذات الدخل المحدود والضعيف وغير القار لتمكينها من ولوج القروض السكنية في ظروف ملائمة.", null, null, "آلية مالية داعمة لتمكين الشرائح الاجتماعية ذات الدخل المحدود والضعيف والقار من ولوج السكن" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 146, "146", 2, 2, 1, 2, 10, 2, " مواصلة تعزيز الخدمات المتعلقة بمعالجة الشكايات والتظلمات والاقتراحات من طرف المرتفقين على الصعيد الجهوي، واعتماد استمارات توضع رهن إشارة المرتفقين لقياس مستوى رضاهم عن الخدمات. ", null, null, "منظومة داعمة لتحسين مستوى الخدمات" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 97, "97", 2, 2, 1, 2, 9, 1, "  الإسراع بإصدار القانون التنظيمي المتعلق بإعمال الطابع الرسمي للغة الأمازيغية", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 86, "86", 1, 1, 1, 2, 8, 1, "  اعتماد تدابير تحفيزية لتعميم تمدرس الفتيات في جميع المستويات التعليمية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 85, "85", 1, 1, 1, 2, 8, 2, "--", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 79, "79", 1, 1, 1, 2, 7, 1, " تشجيع إمكانيات التظلم الإداري والقضائي صونا لمبدأ عدم الإفلات من العقاب وضمانا لوصول الضحايا إلى سبل الانتصاف المناسبة.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 70, "70", 1, 1, 1, 2, 6, 1, "تعزيز آليات الوساطة والتوفيق والتدخل الاستباقي المؤسساتي والمدني لتفادي حالات التوتر والحيلولة دون وقوع انتهاكات.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 43, "43", 1, 1, 3, 2, 4, 2, "توثيق ونشر الممارسات الفضلى في مجال مكافحة للفساد.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 14, "14", 1, 2, 1, 2, 2, 2, " تفعيل مقتضيات القانون التنظيمي لقانون المالية المتعلق بالإدماج العرضاني لمقاربة النوع في السياسات العمومية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 375, "375", 4, 2, 3, 1, 21, 1, "توثيق ونشر الأعمال البحثية المعززة لرصيد ثقافة حقوق الإنسان المنجزة بمناسبة الآراء والأعمال الاستشارية من قبل مؤسسات الديمقراطية التشاركية.", null, null, "برامج معززة لرصيد ثقافة حقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 364, "364", 4, 2, 1, 1, 21, 2, "الإسراع بإخراج المقتضيات القانونية الناظمة للعقوبات البديلة بهدف الحد من إشكالات الاعتقال الاحتياطي والاكتظاظ في السجون.", null, null, "مقتضيات قانونية داعمة لتجويد خدمات المؤسسة السجنية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 359, "359", 3, 2, 3, 1, 20, 2, " إعداد برامج للتكوين والتكوين المستمر تستحضر البعد الحقوقي وتستهدف الجمعيات التي تعمل مع المغاربة في الخارج والمهاجرين بالمغرب.", null, null, "قدرات فعاليات المجتمع المدني معززة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 329, "329", 3, 1, 1, 1, 19, 2, " إحداث نظام أساسي لمهن المساعدة الاجتماعية لرعاية المسنين.", null, null, "مهن المساعدة الاجتماعية مقننة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 315, "315", 3, 1, 1, 1, 18, 1, " إحداث مؤسسات اجتماعية تعنى بإيواء الأشخاص في وضعية إعاقة المتخلى عنهم.", null, null, "بنيات داعمة للتكفل بالأشخاص في وضعية إعاقة المتخلى عنهم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 308, "308", 3, 2, 1, 1, 18, 1, "تفعيل وتقوية آليات الإدماج المهني للأشخاص في وضعية إعاقة في أنظمة التكوين المهني والتشغيل الذاتي واستخدام آليات التمييز الإيجابي والنهوض بمراكز العمل المحمية.", null, null, "آليات داعمة للإدماج المهني للأشخاص في وضعية إعاقة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 166, "166", 2, 1, 1, 1, 12, 2, " تعزيز المنظومة القانونية المتعلقة بالسكن والتعمير وملاءمتها مع متطلبات حقوق الإنسان.", null, null, "إطار قانوني داعم للحق في السكن" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 163, "163", 2, 1, 3, 1, 11, 2, "تنظيم دورات تدريبية لفائدة موظفي وأطر وزارة الشغل والأطر النقابية ومناديب المستخدمين وأرباب العمل بغية إشاعة ثقافة حقوق الإنسان في ميدان التشغيل.", null, null, "الرفع من قدرات أطر وزارة الشغل والإدماج المهني والأطر النقابية ومناديب المستخدمين وأرباب العمل في مجال حقوق الانسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 144, "144", 2, 1, 1, 1, 10, 1, " تطوير سبل التعاون والتنسيق بين القطاع العام والخاص بما يؤمن تجويد الخدمات الصحية والولوج العادل والمتكافئ إليها. ", null, null, "شراكات مساهمة في الارتقاء بالمنظومة الصحية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 129, "129", 2, 1, 1, 1, 10, 1, " دعم ولوج الفئات الأكثر هشاشة للخدمات الصحية.", null, null, "برامج داعمة لتعميم الخدمات الصحية." });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 126, "126", 2, 1, 3, 1, 9, 1, "وضع برامج متخصصة بمساعدة المختصين في المهن الثقافية للنهوض بقدرات المنظمات غير الحكومية والجماعات الترابية وسائر المؤسسات العاملة في مجال الحقوق الثقافية", null, null, "برامج داعمة لقدرات مختلف الفاعلين في مجال الحقوق الثقافية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 276, "276", 3, 2, 3, 2, 16, 1, " تقوية برامج الوقاية الموجهة للأطفال في وضعية صعبة ولأسرهم.", null, null, "برامج معززة لحماية الأطفال في وضعية صعبة ولأسرهم" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 283, "283", 3, 2, 1, 2, 17, 1, "تقوية آليات التنسيق عبر القطاعية الخاصة بالشباب.", null, null, "سياسة وطنية للشباب معتمدة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 382, "382", 4, 1, 1, 2, 22, 1, " تعزيز حماية النساء ضد العنف على مستوى التشريع والسياسة الجنائية الوطنية.", null, null, "إطار قانوني داعم لحماية النساء ضحايا العنف" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 13, "13", 1, 2, 3, 4, 1, 1, " وضع برامج تكوينية على المواطنة وحقوق الإنسان وسيادة القانون لفائدة المنتخبين وموظفي الجماعات الترابية والمجتمع المدني.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 151, "151", 2, 2, 1, 3, 11, 1, " مواصلة الحوار المجتمعي بشأن الانضمام إلى اتفاقية منظمة العمل الدولية رقم 87 بشأن الحرية النقابية وحماية حق التنظيم النقابي. ", null, null, "حوارمجتمعيواسع. " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 139, "139", 2, 1, 1, 3, 10, 2, " النهوض بالصحة النفسية والعقلية ومواصلة مأسستها وتعميم خدماتها.", null, null, "بنيات داعمة للنهوض بالصحةالنفسيةوالعقلية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 130, "130", 2, 2, 1, 3, 10, 1, " مواصلة توفير الموارد البشرية اللازمة من حيث عدد الأطر الطبية وشبه الطبية وتخصصاتها وتأمين توزيعها العادل على المجال الترابي وفق منظور يراعي حاجيات وخصوصيات كل منطقة.", null, null, "مواردبشريةكفيلةبتأمينالحاجياتمنالخدماتالصحية." });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 103, "103", 2, 2, 1, 3, 9, 2, "الإدماج العرضاني للحقوق اللغوية والثقافية الأمازيغية في برامج التربية والتكوين وفي المحيط المدرسي والجامعي", null, null, "بيئة تربوية مساعدة على إدماج الحقوق اللغوية والثقافية الأمازيغية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 96, "96", 2, 2, 1, 3, 9, 2, "  إرساء استراتيجية ثقافية وطنية", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 69, "69", 1, 2, 1, 3, 6, 1, "تيسير حريات الاجتماع والتجمهر والتظاهر السلمي من حيث تحديد الأماكن المخصصة لها والقيام بالوساطة والتفاوض.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 52, "52", 1, 2, 1, 3, 5, 2, "تجهيز أماكن الحرمان من الحرية بوسائل التوثيق السمعية البصرية لتوثيق تصريحات المستجوبين من طرف الشرطة القضائية ووضعها رهن إشارة القضاء.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 8, "8", 1, 2, 3, 3, 1, 1, "إطلاق برامج تواصلية لتعزيز الديمقراطية التشاركية.", null, null, "بيئة داعمة ومحفزة للديمقراطية التشاركية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 423, "423", 4, 1, 3, 4, 25, 2, "تقوية قدرات مؤسسة أرشيف المغرب المادية والبشرية حتى تتمكن من الاضطلاع بالمهام المنوطة بها.", null, null, "قدرات مؤسسة أرشيف المغرب معززة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 419, "419", 4, 2, 1, 4, 25, 2, "وضع تصور لتدبير الأرشيف في إطار الجهوية المتقدمة.", null, null, "خطة وطنية لتنظيم الأرشيفات الترابية معتمدة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 379, "379", 4, 1, 1, 4, 22, 2, " تفعيل الهيئة المكلفة بالمناصفة ومكافحة جميع أشكال التمييز.", null, null, "هيئة المناصفة ومكافحة جميع أشكال التمييز مفعلة." });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 293, "293", 3, 2, 3, 8, 17, 1, "تعزيز مواكبة الشباب ودعمهم في مجالات الادماج الاقتصادي والمهني والاجتماعي.", null, null, "آليات داعمة لقدرات الشباب على الاندماج الاقتصادي والمهني والاجتماعي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 356, "356", 3, 2, 3, 4, 20, 1, " تعميم ونشر التقارير الوطنية عن الهجرة وبأوضاع المهاجرين.", null, null, "التقارير الوطنية عن الهجرة وأوضاع المهاجرين معممة ومنشورة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 325, "325", 3, 2, 3, 4, 18, 1, "تمكين الأشخاص في وضعية إعاقة من خدمات الإعلام والتواصل عن طريق إدماج لغة الإشارة في البرامج الإعلامية.", null, null, "بيئة داعمة لولوج   الأشخاص في وضعية إعاقة للخدمات الإعلامية  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 278, "278", 3, 2, 3, 4, 16, 1, "مواصلة برامج وأنشطة التدريب والتكوين المستمر على اتفاقية الأمم المتحدة لحقوق الطفل والبروتوكولات الملحقة بها.", null, null, "قدرات الفاعلين متطورة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 248, "248", 3, 1, 1, 4, 16, 2, " تفعيل منشور رئيس الحكومة حول الحملة الوطنية لتسجيل الأطفال غير المسجلين في الحالة المدنية بشكل دوري ومستمر.", null, null, "آليات داعمة لحماية الأطفال في هويتهم المدنية وحقوقهم الأساسية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 230, "230", 3, 1, 1, 4, 15, 1, "الرفع من الاعتمادات المخصصة للنهوض بالحقوق الفئوية في الميزانية العامة.", null, null, "اعتمادات مالية مساهمة في النهوض بالحقوق الفئوية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 201, "201", 2, 1, 1, 4, 13, 2, "  الإسراع بتنفيذ المخطط الوطني لتطهير السائل لا سيما بالعالم القروي.", null, null, "مخطط وطني منجز" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 118, "118", 2, 1, 1, 4, 9, 2, " وضع برامج تيسر مشاركة وتمتع الأشخاص المسنين وفي وضعية إعاقة بالحقوق الثقافية.", null, null, "بيئة داعمة لتمتع الأشخاص المسنين      وفي وضعية إعاقة بالحقوق الثقافية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 117, "117", 2, 1, 1, 4, 9, 1, " تعميم المكتبات ومراكز التنشيط الثقافي والمسرحي والفني في المناطق التي تفتقر للبنيات التحتية الثقافية.", null, null, "بنيات مشجعة على الحياة الثقافية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 110, "110", 2, 1, 1, 4, 9, 1, "تشجيع البحث الجامعي على مواصلة الجهود حول تاريخ المغرب المتعدد بعمقه الديني وبمكوناته البشرية والثقافية والمحلية", null, null, "برامج داعمة للبحث الجامعي حول تاريخ المغرب المتعدد بعمقه الديني وبمكوناته البشرية والثقافية والمحلية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 109, "109", 2, 1, 1, 4, 9, 2, "تشجيع إحداث محطات إذاعية تستخدم اللغات المتداولة وتلبي حاجيات المواطنين على مستوى الإعلام والتثقيف والتوعية والترفيه.", null, null, "محطات جهوية متفاعلة مع محيطها" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 89, "89", 1, 1, 1, 4, 8, 2, "   إيجاد آليات لربط مخرجات المنظومة التربوية بالحاجيات الاقتصادية والاجتماعية والثقافية وبأهداف الخطط التنموية", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 83, "83", 1, 1, 1, 4, 8, 2, "تفعيل مقتضيات القانون رقم 00-04 المتعلق بإلزامية التعليم.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 336, "336", 3, 1, 1, 4, 19, 1, " وضع مؤشرات وأنظمة معلوماتية لتتبع أوضاع الأشخاص المسنين لاسيما الموجودين في أوضاع صعبة محليا جهويا ووطنيا.", null, null, "منظومة معلوماتية ومؤشرات للتتبع مبلورة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 397, "397", 4, 1, 3, 16, 22, 1, "توثيق ونشر الاجتهاد القضائي في مجال حماية حقوق المرأة كمصدر من مصادر التشريع.", null, null, "دينامية داعمة لترصيد الاجتهاد القضائي في مجال حماية حقوق المرأة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 303, "303", 3, 1, 1, 8, 18, 2, " إدماج التربية على الاختلاف في المناهج المدرسية للمساهمة في تغيير المواقف والتمثلات في أوساط الأطفال والشباب.", null, null, "كتب مدرسية معززة للتعايش وقبول الاختلاف" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 332, "332", 3, 1, 1, 8, 19, 2, "حث الجماعات الترابية على إدماج احتياجات الأشخاص المسنين في برامج تفعيل مخططات التنمية.", null, null, "مخططات للتنمية المحلية داعمة للنهوض بأوضاع الأشخاص المسنين  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 373, "373", 4, 2, 1, 13, 21, 1, "الإسراع بوضع منظومة مندمجة لمعالجة الشكايات المتعلقة بحقوق المرتفقين.", null, null, "منظومة مندمجة لمعالجة الشكايات مفعلة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 355, "355", 3, 1, 3, 13, 20, 1, " النهوض بإبداعات وابتكارات الباحثين المغاربة المقيمين بالخارج.", null, null, "إبداعات وابتكارات الباحثين المغاربة المقيمين بالخارج مثمنة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 264, "264", 3, 2, 1, 13, 16, 1, " دعم عمل اللجنة بين الوزارية المكلفة بتتبع السياسات والبرامج في مجال النهوض بحقوق الطفل وحمايتها.", null, null, "آلية مؤسساتية داعمة لتنفيذ السياسات والبرامج في مجال النهوض بحقوق الطفل وحمايتها " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 242, "242", 3, 2, 1, 13, 16, 1, " تفعيل المقتضيات القانونية ذات الصلة بالأطفال في المرحلة الانتقالية في القانون المتعلق بتشغيل العمال المنزليين.", null, null, "مناخ داعم لاحترام القانون المتعلق بتشغيل العاملات والعمال المنزليين " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 229, "229", 3, 1, 1, 13, 15, 1, " وضع الجماعات الترابية لبرامج في مجال الحقوق الفئوية.", null, null, "برامج داعمة للنهوض بالحقوق الفئوية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 219, "219", 2, 2, 3, 13, 14, 1, "تشجيع التدريس والبحث العلمي في الجامعة ومعاهد التكوين ومراكز البحث العلمي حول المقاولة وحقوق الإنسان", null, null, "برامج داعمة للتدريس والبحث الجامعي حول المقاولة وحقوق الإنسان" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 211, "211", 2, 1, 3, 13, 14, 1, " إعداد واعتماد خطة عمل وطنية في مجال المقاولة وحقوق الإنسان بإشراك كافة الفاعلين المعنيين (قطاعات حكومية والبرلمان والقطاع الخاص والنقابات وهيئات الحكامة والديمقراطية التشاركية وحقوق الإنسان ومنظمات المجتمع المدني...).", null, null, "خطة معتمدة في مجال المقاولة وحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 205, "205", 2, 1, 3, 13, 13, 1, " إعمال مضامين الميثاق الوطني للإعلام والبيئة والتنمية المستدامة.", null, null, "الميثاق الوطني للإعلام والبيئة والتنمية المستدامة مفعل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 197, "197", 2, 1, 1, 13, 13, 2, "تطوير تدبير المجال الغابوي بالشكل الذي يوفر حماية شاملة للمحميات ولحقوق السكان ونشاطهم الزراعي والفلاحي.", null, null, "ديناميات معززة للحماية القانونية للمجال الغابوي  وداعمة لتنمية مستدامة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 148, "148", 2, 1, 3, 13, 10, 1, "تعزيز البرامج السمعية البصرية المتعلقة بالحق في الصحة", null, null, "برامج سمعية بصرية داعمة للحق في الصحة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 143, "143", 2, 2, 1, 13, 10, 1, " ضمان التنسيق الفعال بين مختلف الإدارات الصحية على الصعيد الوطني وبين المستشفيات والمراكز الصحية، وإحداث آليات التتبع والمراقبة وتقييم الأداء وجودة الخدمات وفعاليتها.", null, null, ".آليات مساعدة على التنسيق والتتبع والمراقبة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 58, "58", 1, 1, 3, 13, 5, 2, "تقوية بنيات ووسائل وقنوات التواصل بين المؤسسات الأمنية والمواطنين (حسن الاستقبال والتوجيه وتقديم الإرشادات).", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 56, "56", 1, 1, 3, 13, 5, 1, " وضع خطط للإعلام والتواصل مع المواطنات والمواطنين ومهنيي الإعلام بخصوص الحالة الأمنية من خلال تقارير وبلاغات وندوات صحفية ومنشورات.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 400, "400", 4, 1, 3, 12, 22, 1, "محاربة الصور النمطية والتمييزية ضد النساء في وسائل الإعلام وفي البرامج والمقررات المدرسية.", null, null, "بيئة داعمة لمكافحة الصور النمطية والتمييزية ضد النساء" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 326, "326", 3, 2, 3, 12, 18, 1, " تطوير التكوين الأساسي والمستمر في مجال الإعاقة خصوصا في ميدان التربية والتكوين المهني والصحة ولاسيما ما يتعلق ببعض أنواع الإعاقة كالتوحد.", null, null, "برامج داعمة للنهوض بالتكوين الأساسي والمستمر في مجال الإعاقة في ميدان التربية والتكوين المهني" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 262, "262", 3, 2, 1, 12, 16, 2, " الرفع من مستوى آليات تتبع أوضاع الأطفال المتكفل بهم.", null, null, "آليات داعمة لحماية حقوق الأطفال في وضعية كفالة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 252, "252", 3, 2, 1, 12, 16, 1, "إيلاء أهمية قصوى للبرامج الاجتماعية المساهمة في النهوض بوضعية الفتاة وخاصة في مجالات التعليم والتكوين والوصول إلى الموارد.", null, null, "برامج داعمة للنهوض بوضعية الفتاة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 182, "182", 2, 2, 3, 12, 12, 2, "إعداد مواد مرجعية بيداغوجية حول ثقافة حقوق الإنسان وقيمتها الدستورية موجهة لطلبة الدراسات العليا في مجال الهندسة المعمارية.", null, null, "آليات داعمة لإدماج ثقافة حقوق الإنسان في منهاج التكوين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 170, "170", 2, 1, 1, 12, 12, 1, " إسراع وتيرة إنجاز برامج القضاء على السكن غير اللائق.", null, null, "برامج مساهمة في القضاء على السكن غير اللائق" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 161, "161", 2, 2, 1, 12, 11, 1, "وضع برامج وخطط كفيلة بتأهيل التكوين المهني وجعله يساهم بفعالية في تقليص معدلات البطالة. ", null, null, "برامج داعمة للنهوض بالتكوين المهني كرافعة للتشغيل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 123, "123", 2, 1, 1, 12, 9, 1, "تمكين الشباب من المساهمة الفاعلة في تدبير الحياة الثقافية والتحفيز على الولوج إليها", null, null, "مناخ داعم لمبادرات الشباب في المجال الثقافي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 106, "106", 2, 2, 1, 12, 9, 1, "تعزيز وسائل التظلم والانتصاف المتعلقة بالتمييز في مجال الحقوق الثقافية", null, null, "سائل التظلم والانتصاف المتعلقة بالتمييز في مجال الحقوق معززة جهويا ومركزيا" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 78, "78", 1, 1, 1, 12, 7, 1, " إحالة نتائج تحريات الآلية الوطنية للوقاية من التعذيب على القضاء.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 380, "380", 4, 1, 1, 13, 22, 1, " البحث في سبل مبادرات الحكومة وهيئات الديمقراطية التشاركية لتنظيم حوارات عمومية حول رصيد إعمال مدونة الأسرة على مستوى الاجتهاد القضائي والتطور المجتمعي.", null, null, "ديناميات داعمة لتطوير مدونة الأسرة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 44, "44", 1, 1, 3, 12, 4, 1, "وضع برامج للتدريب والتكوين والتكوين المستمر لفائدة مختلف الفاعلين والمتدخلين في مجالات مكافحة الفساد وتعزيز النزاهة والشفافية وإشاعة أخلاقياتها.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 408, "408", 4, 1, 1, 13, 23, 1, "تقوية المقتضيات القانونية المتعلقة بالاعتداء على الملكية الفكرية لتتلاءم مع الدستور.", null, null, "مقتضيات قانونية داعمة لحماية الملكية الفكرية  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 46, "46", 1, 2, 1, 14, 5, 1, "مراجعة المقتضيات القانونية بما يضمن إلزامية إجراء الخبرة الطبية في حالة ادعاء التعرض للتعذيب واعتبار المحاضر المنجزة باطلة في حالة رفض إجراءها بعد طلبها من طرف المتهم أو دفاعه. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 249, "249", 3, 2, 1, 16, 16, 1, " تعزيز وتقوية المساعدة الاجتماعية والقانونية للأطفال ضحايا الاعتداء والعنف والاستغلال أو في تماس مع القانون.", null, null, "المساعدة الاجتماعية والقانونية للأطفال ضحايا العنف والاستغلال معززة وشاملة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 246, "246", 3, 1, 1, 16, 16, 2, "تبسيط المساطر المتعلقة بتسجيل الأطفال في سجلات الحالة المدنية. ", null, null, "إطار قانوني داعم لتعزيز حق الطفل في الهوية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 196, "196", 2, 2, 1, 16, 13, 1, " تفعيل سياسة القرب في مجال تدبير البيئة وتسريع وتيرة تنفيذها.", null, null, "إطار مؤسساتي داعم لسياسة القرب" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 133, "133", 2, 1, 1, 16, 10, 1, " النهوض بصحة الأم والمواليد الجدد والعناية بطب التوليد.", null, null, "برامج صحية معززة لصحة الأم والطفل والمواليد الجدد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 108, "108", 2, 2, 1, 16, 9, 1, "مراجعة دفاتر تحملات شركات الاتصال السمعي البصري بما يسمح بتعزيز حصة البث بالأمازيغية", null, null, "إطار تنظيمي معزز لحصة البث باللغة الأمازيغية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 77, "77", 1, 2, 1, 16, 7, 1, "إحالة نتائج البحث المتوصل إليها في إطار الطب الشرعي بخصوص حالات ادعاء التعذيب على النيابة العامة للتقرير فيها مالم تكن قد أمرت بها.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 32, "32", 1, 1, 1, 16, 4, 2, " اعتماد المقاربة التشاركية عند إعداد المقترحات المتعلقة بمجالات مكافحة الفساد. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 416, "416", 4, 1, 1, 15, 24, 2, "تأهيل آليات الحفاظ على التراث الثقافي المغربي بكل مكوناته وأبعاده المادية والرمزية والمحافظة عليها.", null, null, "آليات الحفاظ على التراث الثقافي المغربي مؤهلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 352, "352", 3, 2, 1, 15, 20, 1, "تفعيل الآليات الكفيلة بتتبع أوضاع السجناء المغاربة الذين يقضون عقوبتهم السجنية بالخارج ضمانا لحقوقهم واعتناء بأوضاعهم. ", null, null, "آليات داعمة لحماية حقوق السجناء المغاربة بالخارج" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 290, "290", 3, 2, 3, 15, 17, 2, " تعزيز دور الشباب في الحوارات الوطنية والجهوية المتعلقة بتدبير الشأن العام والنهوض بأوضاعهم.", null, null, "برامج داعمة لمشاركة الشباب في تدبير الشأن العام وتقييم السياسات العمومية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 287, "287", 3, 2, 1, 15, 17, 2, " دعم الجمعيات التي تعنى بالشباب وبالترافع عن قضاياهم.", null, null, " قدرات متطورة في مجال الترافع " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 268, "268", 3, 1, 1, 15, 16, 1, "وضع آليات ترابية مندمجة لحماية الطفولة تضمن التنسيق واليقظة من حيث الإشعار والتبليغ وتتبع الخدمات الموجهة للأطفال ضحايا العنف.", null, null, "آليات ترابية مندمجة لحماية الطفولة مفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 263, "263", 3, 2, 1, 15, 16, 1, " تفعيل البرنامج التنفيذي للسياسة العمومية المندمجة لحماية الطفولة بالمغرب محليا وجهويا.", null, null, "تدابير البرنامج الوطني للسياسة العمومية المندمجة لحماية الطفولة منفذة جهويا ومحليا" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 236, "236", 3, 1, 1, 15, 16, 1, " تفعيل المجلس الاستشاري للأسرة والطفولة وإصدار النصوص التشريعية والتنظيمية المتعلقة به.", null, null, "المجلس الاستشاري للأسرة والطفولة مفعل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 224, "224", 3, 1, 1, 15, 15, 1, "إدماج ثقافة حقوق الإنسان ذات الصلة في مؤسسات التكوين الأساسي والمستمر للعاملين في مجال حماية الحقوق الفئوية.", null, null, "إطار مرجعي وبرامج داعمة لإدماج ثقافة حقوق الإنسان في التكوين الأساسي والمستمر  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 164, "164", 2, 2, 3, 15, 11, 2, " وضع برامج لتكوين قضاة متخصصين في قانون الشغل.", null, null, "برامج داعمة للتخصص القضائي في قانون الشغل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 26, "26", 1, 1, 1, 15, 3, 2, "الإسراع بوضع ميثاق اللاتمركز الإداري في إطار تنزيل الجهوية المتقدمة وتكريس الحكامة الترابية", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 435, "435", 4, 1, 3, 14, 26, 1, " وضع برامج للتكوين المستمر وتبادل الخبرات والممارسات الفضلى بشأن إدماج حقوق الإنسان في الاجتهاد القضائي، تفاعلا مع التزامات المغرب في مجال حقوق الإنسان وأحكام الدستور.", null, null, "آليات داعمة لاستحضار بعد حقوق الإنسان في الاحكام القضائية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 385, "385", 4, 1, 1, 14, 22, 1, " تفعيل النصوص التنظيمية الخاصة بتنفيذ القانون المتعلق بتحديد شروط التشغيل والشغل الخاص بالعمال المنزليين.", null, null, "المقتضيات القانونية للقانون رقم 19.12 مفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 350, "350", 3, 2, 1, 14, 20, 1, " وضع آلية وطنية للرصد ومتابعة تطور الهجرة من وإلى المغرب وقياس آثارها المجتمعية والاقتصادية والثقافية.", null, null, "مرصد متخصص في متابعة تطور الهجرة محدث" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 272, "272", 3, 1, 1, 14, 16, 2, "تعزيز إجراءات حماية محيط المؤسسات التعليمية لحماية الأطفال واليافعين من أخطار المخدرات ومروجيها.", null, null, "إجراءات أمنية معززة لحماية     الأطفال واليافعين من أخطار المخدرات ومروجيها" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 153, "153", 2, 1, 1, 14, 11, 1, " اعتماد المساواة وتكافؤ الفرص في برامج التكوين والتأهيل والإدماج في سوق الشغل.", null, null, "المساواة وتكافؤ الفرص فئويا ومجاليا مفعلة في برامج التكوين والتأهيل والإدماج في سوق الشغل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 135, "135", 2, 2, 1, 14, 10, 2, " ضمان حقوق المصابين بالأمراض المتنقلة جنسيا وحمايتهم من كل أشكال التمييز أو الإقصاء أو الوصم.", null, null, "برامج داعمة لحقوق المصابين بالأمراض المتنقلة جنسيا" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 33, "33", 1, 2, 1, 14, 4, 1, "تفعيل مختلف أشكال الرقابة البرلمانية والإدارية والقضائية في مكافحة الفساد.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 36, "36", 1, 1, 1, 12, 4, 2, "تعزيز المشاريع والإجراءات الرامية إلى مكافحة الفساد وتعزيز الحكامة الإدارية والنزاهة والشفافية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 1, "1", 1, 1, 1, 12, 1, 2, "التفعيل الأمثل للقوانين المنظمة للانتخابات الوطنية والمحلية لتقوية النزاهة والحكامة الرشيدة والشفافية", null, null, "بيئة داعمة للنزاهة والشفافية والحكامة الانتخابية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 427, "427", 4, 2, 1, 11, 26, 2, "الرفع من جودة الأحكام.", null, null, "آلية داعمة للرفع من جودة الاحكام" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 156, "156", 2, 2, 1, 10, 11, 2, " إعداد برامج لدعم وتنشيط المقاولات الصغرى والمتوسطة والتعاونيات ووضع شباك داخل الجماعات الترابية للتعريف بالمقاولات خصوصا النسائية منها.", null, null, "برامج داعمة للمقاولات الصغرى           والمتوسطة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 119, "119", 2, 2, 1, 10, 9, 2, " إحداث متاحف موضوعاتية جهوية تبرز تراث كل منطقة وخصوصياتها الثقافية والفنية.", null, null, "بنيات حاضنة للتنوع الثقافي والتراثي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 59, "59", 1, 2, 3, 10, 5, 1, "إعداد ونشر دلائل ودعائم ديداكتيكية لتوعية وتحسيس المسؤولين وأعوان الأمن بقواعد الحكامة الجيدة على المستوى الأمني واحترام حقوق الإنسان.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 340, "340", 3, 1, 3, 9, 19, 2, "تعزيز البرامج الإعلامية الموجهة للمسنين", null, null, "برامج إعلامية مواكبة لحاجيات المسنين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 334, "334", 3, 1, 1, 9, 19, 1, " تشجيع كل المبادرات العمومية والجمعوية الداعمة والحاضنة لرفاه الأشخاص المسنين ومشاركتهم.", null, null, "مبادرات عمومية داعمة لرفاه الأشخاص المسنين ومشاركتهم " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 302, "302", 3, 1, 1, 9, 18, 2, " تفعيل مقتضيات الرافعة الرابعة من الرؤية الاستراتيجية لإصلاح التربية والتعليم 2015-2030 من أجل مدرسة الانصاف والجودة والارتقاء لفائدة الأشخاص في وضعية إعاقة أو في وضعيات خاصة.", null, null, "مؤسسة تعليمية دامجة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 298, "298", 3, 2, 1, 9, 18, 2, "  الإسراع بإصدار النصوص التنظيمية المنصوص عليها في القانون الإطار المتعلق بحماية حقوق الأشخاص في وضعية إعاقة والنهوض بها.", null, null, "مقتضيات تنظيمية داعمة لتفعيل القانون الإطار" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 286, "286", 3, 2, 1, 9, 17, 1, " إعداد وتعميم تقارير دورية حول الشباب.", null, null, "تقارير مساعدة على تتبع وضعية الشباب" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 281, "281", 3, 1, 1, 9, 17, 1, "مراجعة القانون التنظيمي للأحزاب بكيفية تمكن الشباب من المساهمة الفعالة في تدبير الشأن الحزبي. ", null, null, "مقتضيات قانونية داعمة للمشاركة السياسية للشباب" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 235, "235", 3, 2, 3, 9, 15, 1, " تأهيل وتعزيز قدرات جمعية الهلال الأحمر المغربي والجمعيات الوطنية الأخرى المعنية بالفئات الاجتماعية في وضعية هشاشة.", null, null, "برنامج داعم لقدرات جمعيات المجتمع المدني" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 194, "194", 2, 1, 1, 9, 13, 2, " إعداد مخطط وطني في مجال مكافحة التغيرات المناخية ووضع سياسة وطنية لمكافحة الاحتباس الحراري وتعبئة جميع الفاعلين في مجال مكافحة تغير المناخ.", null, null, "مبادرات داعمة لمكافحة التغيرات المناخية " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 191, "191", 2, 2, 1, 9, 13, 2, " دعم الصندوق الوطني للبيئة والتنمية المستدامة.", null, null, "آلية مساهمة في دعم المشاريع البيئية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 190, "190", 2, 1, 1, 9, 13, 2, " النظر في تجميع القوانين القطاعية ذات الصلة بالبيئة في إطار مدونة واضحة ومحينة لأجل تعزيز الانسجام بينها وتسهيل الولوج إلى مضامينها من طرف الهيئات التي تسهر على تطبيقها ومن طرف المواطنات والمواطنين.", null, null, "مصنفات مساهمة في الولوج إلى القوانين ذات الصلة بالبيئة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 141, "141", 2, 2, 1, 9, 10, 2, " دعم الخطة المتعلقة بتوفير الأدوية الأساسية الاستعجالية وتلك المتعلقة بالأمراض المزمنة.", null, null, "خطة داعمة لضمان تموين مستمر بالأدوية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 73, "73", 1, 1, 1, 9, 7, 2, "تيسير التقاضي للضحايا من خلال توفير المساعدة القانونية والقضائية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 61, "61", 1, 1, 3, 9, 5, 2, " تعزيز برامج تكوين المكلفين بإنفاذ القانون في مجال استعمال القوة وتدبير فضاء الاحتجاج.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 31, "31", 1, 1, 1, 9, 4, 1, "  استكمال الإجراءات التشريعية المتعلقة بإصدار مشروع القانون رقم 13.31 المتعلق بالحق في الوصول إلى المعلومات.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 18, "18", 1, 1, 3, 9, 2, 1, " وضع برامج فعالة للتوعية والتحسيس والتربية على قيم ومبادئ المساواة وتكافؤ الفرص والمناصفة لفائدة أطر وموظفي الإدارات والمؤسسات العمومية والجماعات الترابية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 12, "12", 1, 1, 3, 9, 1, 2, " وضع برامج تدريبية وتكوينية فعالة تستهدف تطوير مهارات التواصل والرفع بمستوى الثقافة الحقوقية والسياسية في نطاق الدستور والتزامات المملكة المغربية في مجال حقوق الإنسان.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 2, "2", 1, 2, 1, 9, 1, 2, "الرفع من مستوى مشاركة النساء في المجالس التمثيلية.", null, null, "بيئة داعمة للرفع من مشاركة النساء" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 405, "405", 4, 2, 1, 8, 23, 2, " تعزيز الأخلاقيات المهنية في الممارسة الإعلامية.", null, null, "بيئة داعمة لممارسة إعلامية وفق الضوابط المهنية  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 395, "395", 4, 2, 1, 8, 22, 1, " وضع الآليات الكفيلة بضمان ولوج النساء لمجال المقاولة.", null, null, "أليات كفيلة بتيسير ولوج النساء للمقاولة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 339, "339", 3, 2, 1, 8, 19, 1, "تشجيع النهوض بطب الشيخوخة في وزارة الصحة وإحداث شعب للتكوين الطبي المتخصص في هذا المجال.", null, null, "منظومة داعمة لطب الشيخوخة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 174, "174", 2, 2, 1, 10, 12, 2, "تنفيذ أولويات السكن الاجتماعي بمضاعفة العرض في مجال المنتوجات السكنية الملائمة لحاجيات وإمكانيات الفئات المحدودة الدخل في إطار مشروع تطوير المنتوج السكني البديل في أفق 2021.", null, null, "عرض سكني مستجيب لحاجيات الفئات المحدودة الدخل" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 221, "221", 3, 2, 1, 10, 15, 2, " تكثيف البرامج التي تستهدف الفئات الهشة خاصة في وضعية التشرد، وضمان خدمات المواكبة والاستماع والتكفل والادماج الاقتصادي والاجتماعي والأسري.", null, null, "برامج داعمة للفئات الهشة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 232, "232", 3, 2, 1, 10, 15, 2, "مراجعة الإطار القانوني المتعلق بالإحسان العمومي.           ", null, null, "إطار قانوني داعم لتجويد مبادرات الإحسان العمومي" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 239, "239", 3, 1, 1, 10, 16, 1, " الإسراع بالمصادقة على مشروع قانون متعلق بمراكز حماية الطفولة.", null, null, "إطار قانوني مساعد على تجويد خدمات مراكز حماية الطفولة " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 402, "402", 4, 2, 1, 11, 23, 1, "  التعجيل بإصدار القانون المتعلق بالحق في الحصول على المعلومات، انسجاما مع الدستور والاتفاقيات الدولية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 371, "371", 4, 2, 1, 11, 21, 1, " وضع ميثاق النجاعة القضائية للتدبير الجيد للجلسات وآجال البت وتصفية المخلف والتواصل مع المواطنين والاستماع إلى شكاياتهم وغيرها من الإجراءات المماثلة.", null, null, "آليات داعمة لتجويد خدمات العدالة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 353, "353", 3, 2, 3, 11, 20, 2, " مواصلة التنسيق والالتقائية بين كافة المتدخلين في مجال الهجرة وتعزيز دور اللجنة بين الوزارية لمغاربة العالم وشؤون الهجرة في هذا المجال. ", null, null, "أداء اللجنة بين الوزارية معزز وفعال" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 344, "344", 3, 1, 1, 11, 20, 2, " مواصلة تحيين الإطار التشريعي والمؤسساتي المتعلق بالهجرة واللجوء.", null, null, "الإطار التشريعي والمؤسساتي المتعلق بالهجرة واللجوء معزز ومحين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 321, "321", 3, 2, 1, 11, 18, 1, " تعميم ولوج الأشخاص في وضعية إعاقة إلى الخدمات الثقافية من خلال اعتماد الوسائل التقنية الحديثة سواء في المؤسسات التعليمية أو المكتبات والمركبات الثقافية والبنيات الرياضية.", null, null, "فضاءات مساعدة على ولوج الأشخاص في وضعية إعاقة إلى الخدمات الثقافية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 307, "307", 3, 1, 1, 11, 18, 1, "وضع برامج لدعم وتشجيع التشغيل الذاتي للأشخاص في وضعية إعاقة.", null, null, "برامج دعم وتشجيع التشغيل الذاتي للأشخاص في وضعية إعاقة مفعلة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 270, "270", 3, 1, 1, 11, 16, 2, "إدماج الجماعات الترابية لانشغالات الأطفال في مخططات التنمية المحلية على مستوى التشخيص وتحديد الحاجيات والتخطيط والتنفيذ.", null, null, "مخططات للتنمية المحلية داعمة للنهوض بأوضاع الطفولة  من الاستغلال مطورة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 253, "253", 3, 2, 1, 11, 16, 1, " العمل على ضمان المساواة بين الرجل والمرأة في التمتع بالجنسية المغربية إعمالا للمصلحة الفضلى للطفل.", null, null, "إطار قانوني ضامن للمصلحة الفضلى للأطفال والأسرة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 223, "223", 3, 2, 1, 11, 15, 1, "مواصلة إدماج ثقافة حقوق الإنسان ذات الصلة بالحقوق الفئوية في برامج المعهد العالي للقضاء والمهن القضائية.", null, null, "قدرات متطورة في مجال التكوين القضائي التخصصي   " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 155, "155", 2, 1, 1, 11, 11, 1, " إعمال مبدأ الشفافية وتكافؤ الفرص في التشغيل ووضع آليات ومساطر إدارية تنظم الإعلان عن المناصب الشاغرة في جميع القطاعات وفي مرافق الإدارة العمومية ضمانا للشفافية.", null, null, "الشفافية   وتكافؤ الفرص في التوظيف معززة  " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 140, "140", 2, 2, 1, 11, 10, 1, " دعم عمل الفرق الطبية المتنقلة في إطار تقريب الخدمات الصحية وتيسيرها.", null, null, "آليات داعمة لتقريب الخدمات الصحية وتيسيرها" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 311, "311", 3, 1, 1, 8, 18, 2, " توفير الوسائل التيسيرية لولوج الأشخاص في وضعية إعاقة إلى منظومة العدالة.", null, null, "بنيات منظومة العدالة مساعدة على ولوجها" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 138, "138", 2, 2, 1, 11, 10, 1, " إحداث خلايا تساعد الأطر الصحية على التواصل مع المرضى المتحدثين بالأمازيغية والحسانية.", null, null, "بنيات داعمة للتواصل مع المرضى المتحدثين باللغة الأمازيغية والحسانية" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 113, "113", 2, 2, 1, 11, 9, 1, "إحداث فضاءات للحوار والتشاور الدائمين بين منظمات المجتمع المدني والشباب على صعيد الجماعات الترابية فيما يخص الإنتاج الثقافي والأنشطة الداعمة للحياة الثقافية", null, null, "جماعات ترابية داعمة لمبادرات الشباب والمجتمع المدني في المجال الثقافي " });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 72, "72", 1, 1, 1, 11, 7, 1, "تكريس مبدأ عدم الإفلات من العقاب في السياسة الجنائية وفي سائر التدابير العمومية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 47, "47", 1, 2, 1, 11, 5, 2, "الإسراع بإصدار قانون يتعلق بالتحقق من هوية الأشخاص بواسطة البصمات الجينية. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 20, "20", 1, 1, 1, 11, 3, 1, "-20- تسريع إصدار قانون خاص بإعداد التراب الوطني. ", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 15, "15", 1, 1, 1, 11, 2, 2, " الإسراع بتفعيل هيئة المناصفة ومكافحة جميع أشكال التمييز كمدخل أساسي من مداخل تقوية قيم المساواة والإنصاف الموجهة للسياسات العمومية والاستراتيجيات والمخططات والبرامج الوطنية.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 399, "399", 4, 1, 3, 10, 22, 2, "توسيع شبكة الفضاءات متعددة الاختصاصات والوظائف الموجهة للنساء وتعزيزها وتقويتها.", null, null, "نسيج مؤسساتي داعم ومنصف للنساء" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 383, "383", 4, 2, 1, 10, 22, 2, "الإسراع بإصدار القانون المتعلق بمحاربة العنف ضد النساء.", null, null, "" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 347, "347", 3, 2, 1, 10, 20, 2, " وضع اتفاقيات ثنائية مع البلدان الأصلية للمهاجرين المقيمين بالمغرب للتمتع بالحقوق الاجتماعية والاقتصادية والثقافية.", null, null, "اتفاقيات ثنائية مع الدول الأصلية للمهاجرين بالمغرب مبرمة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 335, "335", 3, 2, 1, 10, 19, 1, " التفكير في سبل تثمين خبرات ومهارات الأشخاص المسنين بوصفها جزءا من الرصيد الثقافي والقيمي للرأسمال اللامادي.", null, null, "بيئة داعمة لتثمين خبرات ومهارات الأشخاص المسنين" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 318, "318", 3, 1, 1, 10, 18, 1, " توحيد لغة الإشارة ووضع معايير لها.", null, null, "إطار معياري معد ومعتمد" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 314, "314", 3, 2, 1, 10, 18, 1, "تقنين وتأهيل خدمات مؤسسات الرعاية الاجتماعية.  ", null, null, "  توفر مؤسسات الرعاية الاجتماعية على خدمات ذات جودة" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 132, "132", 2, 1, 1, 11, 10, 1, "  تأهيل أقسام المستعجلات لتعزيز الخدمات المتعلقة بالحالات الطارئة والخطيرة.", null, null, "برامج داعمة لتعزيز كفاءات القطاع الصحي/ أقسام المستعجلات مؤهلة لتقديم خدمات ذات جودة وتغطي الحاجيات" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 421, "421", 4, 1, 3, 33, 25, 2, "تحسيس وتعبئة الخواص الذين بحوزتهم أرشيفات تراثية لإيداعها لدى مؤسسة أرشيف المغرب.", null, null, "دينامية مشجعة على تفاعل الخواص" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 37, "[\"2028\", \"2029\", \"2030\"]", 421, "36 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 47, "[\"2018\", \"2019\", \"2020\"]", 227, "46 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 32, "[\"2018\", \"2019\", \"2020\"]", 292, "31 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 40, "[\"2023\", \"2024\", \"2025\"]", 332, "39 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 1, "[\"2028\", \"2029\", \"2030\"]", 414, "0 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 18, "[\"2024\", \"2025\", \"2026\"]", 322, "17 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 45, "[\"2019\", \"2020\", \"2021\"]", 145, "44 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 49, "[\"2023\", \"2024\", \"2025\"]", 50, "48 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 30, "[\"2018\", \"2019\", \"2020\"]", 17, "29 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 43, "[\"2018\", \"2019\", \"2020\"]", 256, "42 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 4, "[\"2024\", \"2025\", \"2026\"]", 256, "3 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 28, "[\"2022\", \"2023\", \"2024\"]", 74, "27 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 19, "[\"2026\", \"2027\", \"2028\"]", 68, "18 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 16, "[\"2024\", \"2025\", \"2026\"]", 112, "15 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 35, "[\"2028\", \"2029\", \"2030\"]", 169, "34 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 41, "[\"2028\", \"2029\", \"2030\"]", 412, "40 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 14, "[\"2028\", \"2029\", \"2030\"]", 184, "13 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 13, "[\"2023\", \"2024\", \"2025\"]", 49, "12 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 29, "[\"2025\", \"2026\", \"2027\"]", 281, "28 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 46, "[\"2018\", \"2019\", \"2020\"]", 30, "45 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 9, "[\"2018\", \"2019\", \"2020\"]", 197, "8 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 7, "[\"2023\", \"2024\", \"2025\"]", 170, "6 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 10, "[\"2027\", \"2028\", \"2029\"]", 385, "9 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 26, "[\"2020\", \"2021\", \"2022\"]", 402, "25 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 44, "[\"2020\", \"2021\", \"2022\"]", 253, "43 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 17, "[\"2023\", \"2024\", \"2025\"]", 223, "16 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 33, "[\"2020\", \"2021\", \"2022\"]", 138, "32 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 15, "[\"2024\", \"2025\", \"2026\"]", 103, "14 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 22, "[\"2027\", \"2028\", \"2029\"]", 9, "21 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 24, "[\"2021\", \"2022\", \"2023\"]", 399, "23 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 27, "[\"2018\", \"2019\", \"2020\"]", 393, "26 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 5, "[\"2028\", \"2029\", \"2030\"]", 313, "4 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 23, "[\"2029\", \"2030\", \"2031\"]", 314, "22 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 21, "[\"2026\", \"2027\", \"2028\"]", 232, "20 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 39, "[\"2029\", \"2030\", \"2031\"]", 119, "38 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 25, "[\"2025\", \"2026\", \"2027\"]", 27, "24 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 3, "[\"2019\", \"2020\", \"2021\"]", 207, "2 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 31, "[\"2025\", \"2026\", \"2027\"]", 69, "30 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 34, "[\"2018\", \"2019\", \"2020\"]", 429, "33 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 6, "[\"2024\", \"2025\", \"2026\"]", 222, "5 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 12, "[\"2021\", \"2022\", \"2023\"]", 193, "11 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 20, "[\"2024\", \"2025\", \"2026\"]", 375, "19 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 11, "[\"2021\", \"2022\", \"2023\"]", 319, "10 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 38, "[\"2020\", \"2021\", \"2022\"]", 325, "37 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 8, "[\"2019\", \"2020\", \"2021\"]", 79, "7 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 42, "[\"2027\", \"2028\", \"2029\"]", 199, "41 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 36, "[\"2023\", \"2024\", \"2025\"]", 401, "35 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 50, "[\"2027\", \"2028\", \"2029\"]", 273, "49 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 48, "[\"2020\", \"2021\", \"2022\"]", 233, "47 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 2, "[\"2019\", \"2020\", \"2021\"]", 244, "1 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 62, new DateTime(2020, 8, 3, 9, 16, 22, 145, DateTimeKind.Local).AddTicks(2413), 4, 192, "66" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 47, new DateTime(2020, 8, 5, 5, 16, 44, 551, DateTimeKind.Local).AddTicks(6845), 6, 310, "68" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 65, new DateTime(2020, 8, 30, 22, 11, 12, 643, DateTimeKind.Local).AddTicks(2469), 2, 67, "62" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 138, new DateTime(2020, 10, 22, 6, 9, 13, 248, DateTimeKind.Local).AddTicks(4274), 4, 167, "89" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 162, new DateTime(2020, 7, 27, 6, 24, 39, 712, DateTimeKind.Local).AddTicks(3569), 3, 167, "49" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 100, new DateTime(2020, 8, 18, 21, 18, 29, 214, DateTimeKind.Local).AddTicks(4173), 2, 160, "23" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 127, new DateTime(2020, 4, 12, 11, 7, 1, 168, DateTimeKind.Local).AddTicks(2161), 5, 53, "15" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 11, new DateTime(2020, 7, 20, 3, 39, 10, 932, DateTimeKind.Local).AddTicks(6576), 2, 313, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 41, new DateTime(2020, 10, 22, 20, 59, 0, 615, DateTimeKind.Local).AddTicks(3641), 2, 136, "84" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 115, new DateTime(2020, 3, 4, 11, 26, 38, 453, DateTimeKind.Local).AddTicks(4423), 3, 53, "24" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 84, new DateTime(2020, 4, 5, 1, 17, 9, 868, DateTimeKind.Local).AddTicks(5927), 6, 183, "58" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 60, new DateTime(2020, 4, 16, 11, 28, 2, 883, DateTimeKind.Local).AddTicks(8434), 2, 306, "57" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 113, new DateTime(2020, 2, 25, 23, 29, 14, 563, DateTimeKind.Local).AddTicks(965), 3, 369, "62" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 179, new DateTime(2020, 2, 8, 21, 53, 30, 437, DateTimeKind.Local).AddTicks(5759), 3, 398, "59" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 174, new DateTime(2020, 10, 25, 22, 23, 5, 396, DateTimeKind.Local).AddTicks(1247), 1, 288, "86" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 57, new DateTime(2020, 5, 1, 19, 13, 41, 794, DateTimeKind.Local).AddTicks(3541), 5, 418, "36" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 125, new DateTime(2020, 8, 12, 6, 11, 33, 326, DateTimeKind.Local).AddTicks(8067), 1, 418, "88" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 5, new DateTime(2020, 7, 17, 8, 44, 49, 398, DateTimeKind.Local).AddTicks(6771), 6, 208, "66" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 163, new DateTime(2020, 6, 17, 8, 50, 0, 586, DateTimeKind.Local).AddTicks(4023), 5, 107, "28" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 178, new DateTime(2020, 8, 24, 2, 56, 35, 941, DateTimeKind.Local).AddTicks(3995), 5, 30, "24" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 93, new DateTime(2020, 4, 17, 15, 10, 27, 952, DateTimeKind.Local).AddTicks(5234), 3, 306, "65" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 77, new DateTime(2020, 9, 21, 15, 6, 30, 883, DateTimeKind.Local).AddTicks(8836), 4, 384, "40" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 1, new DateTime(2020, 6, 21, 19, 4, 12, 401, DateTimeKind.Local).AddTicks(5460), 1, 243, "67" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 171, new DateTime(2020, 7, 9, 5, 34, 39, 27, DateTimeKind.Local).AddTicks(1226), 5, 205, "67" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 110, new DateTime(2020, 3, 11, 5, 57, 36, 521, DateTimeKind.Local).AddTicks(8501), 2, 229, "62" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 69, new DateTime(2020, 2, 21, 10, 42, 51, 792, DateTimeKind.Local).AddTicks(2507), 5, 264, "10" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 153, new DateTime(2020, 2, 5, 17, 19, 11, 511, DateTimeKind.Local).AddTicks(6341), 2, 153, "91" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 29, new DateTime(2020, 12, 21, 20, 11, 37, 353, DateTimeKind.Local).AddTicks(2953), 5, 297, "34" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 81, new DateTime(2020, 12, 2, 5, 18, 50, 919, DateTimeKind.Local).AddTicks(1745), 5, 272, "78" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 122, new DateTime(2020, 11, 14, 8, 56, 40, 734, DateTimeKind.Local).AddTicks(8312), 2, 401, "87" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 130, new DateTime(2020, 3, 29, 12, 27, 37, 719, DateTimeKind.Local).AddTicks(9770), 5, 350, "82" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 177, new DateTime(2020, 4, 1, 0, 38, 33, 923, DateTimeKind.Local).AddTicks(5939), 2, 240, "47" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 33, new DateTime(2020, 9, 6, 0, 44, 46, 487, DateTimeKind.Local).AddTicks(5416), 5, 435, "70" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 24, new DateTime(2021, 1, 12, 16, 52, 4, 521, DateTimeKind.Local).AddTicks(272), 6, 236, "47" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 133, new DateTime(2020, 10, 8, 13, 37, 51, 709, DateTimeKind.Local).AddTicks(8760), 3, 263, "60" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 121, new DateTime(2020, 8, 3, 10, 19, 1, 477, DateTimeKind.Local).AddTicks(1757), 2, 266, "69" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 31, new DateTime(2020, 12, 3, 10, 51, 26, 113, DateTimeKind.Local).AddTicks(7420), 2, 352, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 76, new DateTime(2021, 1, 13, 7, 50, 29, 497, DateTimeKind.Local).AddTicks(9507), 2, 352, "62" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 17, new DateTime(2020, 4, 25, 20, 22, 57, 855, DateTimeKind.Local).AddTicks(3378), 4, 237, "29" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 137, new DateTime(2020, 10, 17, 19, 0, 51, 51, DateTimeKind.Local).AddTicks(8435), 6, 181, "53" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 118, new DateTime(2020, 3, 14, 17, 36, 31, 471, DateTimeKind.Local).AddTicks(8414), 1, 416, "38" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 114, new DateTime(2020, 9, 3, 4, 32, 49, 232, DateTimeKind.Local).AddTicks(405), 6, 32, "81" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 90, new DateTime(2020, 9, 26, 6, 11, 59, 366, DateTimeKind.Local).AddTicks(6172), 3, 246, "29" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 148, new DateTime(2020, 3, 29, 22, 33, 41, 917, DateTimeKind.Local).AddTicks(2349), 2, 11, "39" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 38, new DateTime(2020, 5, 10, 22, 0, 6, 745, DateTimeKind.Local).AddTicks(5107), 2, 249, "15" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 68, new DateTime(2020, 11, 7, 21, 55, 26, 372, DateTimeKind.Local).AddTicks(5795), 5, 396, "97" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 117, new DateTime(2020, 11, 6, 6, 49, 50, 851, DateTimeKind.Local).AddTicks(5014), 1, 28, "38" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 151, new DateTime(2020, 5, 6, 2, 3, 58, 130, DateTimeKind.Local).AddTicks(7249), 2, 80, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 129, new DateTime(2021, 1, 22, 5, 59, 26, 862, DateTimeKind.Local).AddTicks(6317), 6, 275, "36" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 149, new DateTime(2020, 10, 17, 14, 59, 47, 630, DateTimeKind.Local).AddTicks(199), 3, 240, "33" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 182, new DateTime(2020, 11, 22, 9, 2, 5, 189, DateTimeKind.Local).AddTicks(7546), 2, 425, "41" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 111, new DateTime(2020, 2, 27, 7, 37, 17, 501, DateTimeKind.Local).AddTicks(6427), 1, 60, "76" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 71, new DateTime(2020, 11, 4, 7, 21, 47, 33, DateTimeKind.Local).AddTicks(5852), 5, 60, "99" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 155, new DateTime(2020, 8, 24, 20, 16, 16, 478, DateTimeKind.Local).AddTicks(1487), 2, 35, "60" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 64, new DateTime(2020, 5, 19, 5, 39, 39, 328, DateTimeKind.Local).AddTicks(2959), 4, 55, "94" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 186, new DateTime(2020, 5, 8, 12, 55, 31, 529, DateTimeKind.Local).AddTicks(2396), 4, 98, "57" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 103, new DateTime(2020, 9, 17, 17, 1, 59, 734, DateTimeKind.Local).AddTicks(935), 2, 95, "96" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 172, new DateTime(2020, 6, 28, 23, 37, 49, 720, DateTimeKind.Local).AddTicks(1037), 4, 81, "48" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 56, new DateTime(2020, 5, 30, 20, 44, 23, 272, DateTimeKind.Local).AddTicks(6672), 4, 172, "82" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 9, new DateTime(2020, 4, 19, 16, 16, 18, 473, DateTimeKind.Local).AddTicks(4430), 4, 372, "79" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 12, new DateTime(2020, 5, 28, 8, 36, 49, 734, DateTimeKind.Local).AddTicks(7327), 3, 372, "19" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 175, new DateTime(2020, 5, 15, 11, 10, 42, 774, DateTimeKind.Local).AddTicks(6528), 6, 57, "93" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 167, new DateTime(2020, 1, 29, 17, 37, 58, 626, DateTimeKind.Local).AddTicks(6235), 5, 404, "31" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 18, new DateTime(2020, 3, 1, 1, 42, 59, 474, DateTimeKind.Local).AddTicks(3907), 6, 411, "56" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 124, new DateTime(2020, 5, 27, 12, 52, 29, 118, DateTimeKind.Local).AddTicks(842), 5, 57, "71" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 50, new DateTime(2020, 10, 3, 0, 27, 46, 305, DateTimeKind.Local).AddTicks(3860), 5, 29, "14" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 95, new DateTime(2020, 9, 19, 6, 42, 21, 693, DateTimeKind.Local).AddTicks(7684), 2, 68, "84" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 22, new DateTime(2020, 1, 31, 7, 26, 40, 127, DateTimeKind.Local).AddTicks(3084), 6, 217, "74" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 192, new DateTime(2020, 11, 25, 5, 49, 55, 994, DateTimeKind.Local).AddTicks(9516), 4, 267, "92" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 46, new DateTime(2020, 5, 21, 19, 58, 58, 482, DateTimeKind.Local).AddTicks(2552), 4, 433, "77" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 28, new DateTime(2020, 3, 19, 4, 7, 58, 507, DateTimeKind.Local).AddTicks(9590), 1, 19, "49" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 39, new DateTime(2020, 2, 21, 9, 56, 19, 369, DateTimeKind.Local).AddTicks(4958), 3, 330, "58" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 67, new DateTime(2020, 10, 11, 22, 24, 29, 82, DateTimeKind.Local).AddTicks(3794), 1, 330, "83" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 170, new DateTime(2020, 2, 4, 3, 20, 3, 388, DateTimeKind.Local).AddTicks(3627), 3, 245, "50" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 43, new DateTime(2020, 12, 10, 12, 22, 50, 229, DateTimeKind.Local).AddTicks(397), 1, 337, "23" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 54, new DateTime(2020, 6, 1, 15, 18, 32, 701, DateTimeKind.Local).AddTicks(108), 3, 337, "79" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 49, new DateTime(2020, 10, 11, 19, 28, 25, 176, DateTimeKind.Local).AddTicks(6079), 4, 368, "55" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 200, new DateTime(2020, 4, 17, 13, 20, 53, 948, DateTimeKind.Local).AddTicks(8643), 2, 388, "20" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 72, new DateTime(2020, 12, 24, 2, 35, 24, 521, DateTimeKind.Local).AddTicks(2640), 6, 415, "51" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 55, new DateTime(2020, 8, 1, 1, 30, 4, 734, DateTimeKind.Local).AddTicks(4767), 1, 187, "60" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 88, new DateTime(2020, 8, 5, 19, 48, 48, 749, DateTimeKind.Local).AddTicks(9757), 2, 362, "15" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 79, new DateTime(2020, 3, 31, 7, 35, 18, 716, DateTimeKind.Local).AddTicks(4088), 2, 25, "35" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 61, new DateTime(2021, 1, 5, 8, 49, 9, 400, DateTimeKind.Local).AddTicks(29), 3, 213, "29" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 4, new DateTime(2020, 3, 26, 3, 13, 45, 556, DateTimeKind.Local).AddTicks(3400), 5, 158, "70" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 7, new DateTime(2020, 8, 31, 4, 7, 15, 529, DateTimeKind.Local).AddTicks(9182), 5, 254, "42" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 123, new DateTime(2020, 12, 20, 5, 30, 41, 815, DateTimeKind.Local).AddTicks(9828), 3, 254, "90" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 48, new DateTime(2020, 9, 8, 12, 4, 34, 255, DateTimeKind.Local).AddTicks(8649), 1, 295, "16" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 141, new DateTime(2020, 11, 24, 11, 59, 7, 740, DateTimeKind.Local).AddTicks(8384), 6, 417, "27" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 97, new DateTime(2020, 2, 17, 0, 7, 56, 495, DateTimeKind.Local).AddTicks(8262), 1, 71, "31" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 168, new DateTime(2021, 1, 25, 2, 54, 25, 189, DateTimeKind.Local).AddTicks(2621), 4, 370, "29" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 136, new DateTime(2020, 10, 8, 12, 39, 29, 629, DateTimeKind.Local).AddTicks(4130), 1, 71, "58" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 89, new DateTime(2020, 12, 23, 15, 4, 40, 337, DateTimeKind.Local).AddTicks(3497), 3, 122, "76" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 198, new DateTime(2020, 3, 30, 2, 12, 23, 995, DateTimeKind.Local).AddTicks(2514), 3, 122, "24" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 161, new DateTime(2020, 3, 27, 6, 49, 14, 296, DateTimeKind.Local).AddTicks(8357), 3, 147, "91" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 126, new DateTime(2020, 5, 22, 1, 33, 43, 652, DateTimeKind.Local).AddTicks(2594), 6, 250, "92" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 92, new DateTime(2020, 11, 21, 11, 11, 23, 811, DateTimeKind.Local).AddTicks(5311), 6, 177, "10" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 145, new DateTime(2020, 9, 14, 3, 46, 33, 386, DateTimeKind.Local).AddTicks(4237), 3, 250, "14" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 176, new DateTime(2020, 6, 25, 18, 56, 1, 185, DateTimeKind.Local).AddTicks(7374), 3, 48, "69" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 6, new DateTime(2020, 9, 4, 9, 46, 11, 904, DateTimeKind.Local).AddTicks(6754), 4, 88, "45" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 51, new DateTime(2020, 7, 16, 23, 22, 3, 707, DateTimeKind.Local).AddTicks(3364), 6, 88, "96" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 107, new DateTime(2020, 7, 28, 15, 17, 7, 6, DateTimeKind.Local).AddTicks(4846), 5, 90, "15" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 169, new DateTime(2020, 11, 3, 22, 33, 56, 94, DateTimeKind.Local).AddTicks(7078), 6, 90, "18" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 87, new DateTime(2020, 9, 9, 0, 19, 53, 619, DateTimeKind.Local).AddTicks(4765), 3, 148, "42" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 191, new DateTime(2020, 11, 5, 3, 41, 0, 885, DateTimeKind.Local).AddTicks(9884), 2, 367, "73" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 75, new DateTime(2020, 9, 20, 19, 56, 36, 24, DateTimeKind.Local).AddTicks(5285), 5, 154, "38" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 82, new DateTime(2020, 7, 31, 20, 43, 53, 368, DateTimeKind.Local).AddTicks(1019), 4, 360, "64" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 109, new DateTime(2021, 1, 27, 10, 34, 20, 108, DateTimeKind.Local).AddTicks(6448), 3, 23, "91" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 59, new DateTime(2021, 1, 13, 2, 38, 28, 290, DateTimeKind.Local).AddTicks(8568), 3, 284, "50" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 36, new DateTime(2020, 8, 5, 13, 57, 33, 434, DateTimeKind.Local).AddTicks(2252), 6, 204, "96" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 3, new DateTime(2021, 1, 3, 1, 58, 41, 161, DateTimeKind.Local).AddTicks(9005), 1, 428, "51" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 157, new DateTime(2020, 3, 15, 5, 42, 11, 306, DateTimeKind.Local).AddTicks(4641), 6, 143, "36" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 147, new DateTime(2020, 10, 29, 15, 10, 52, 362, DateTimeKind.Local).AddTicks(2022), 2, 272, "18" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 183, new DateTime(2020, 6, 15, 15, 11, 25, 973, DateTimeKind.Local).AddTicks(5266), 6, 56, "19" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 14, new DateTime(2020, 2, 6, 20, 58, 56, 500, DateTimeKind.Local).AddTicks(2788), 6, 103, "12" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 139, new DateTime(2020, 8, 11, 9, 10, 22, 799, DateTimeKind.Local).AddTicks(1315), 1, 96, "36" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 19, new DateTime(2020, 2, 24, 5, 16, 5, 239, DateTimeKind.Local).AddTicks(9283), 3, 69, "84" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 185, new DateTime(2020, 2, 1, 13, 15, 57, 131, DateTimeKind.Local).AddTicks(817), 1, 52, "10" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 52, new DateTime(2020, 11, 24, 3, 20, 54, 195, DateTimeKind.Local).AddTicks(7775), 6, 73, "50" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 120, new DateTime(2020, 10, 5, 0, 1, 22, 356, DateTimeKind.Local).AddTicks(1413), 1, 141, "81" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 42, new DateTime(2020, 8, 9, 19, 41, 2, 109, DateTimeKind.Local).AddTicks(7385), 1, 190, "99" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 197, new DateTime(2020, 3, 3, 19, 35, 23, 409, DateTimeKind.Local).AddTicks(150), 5, 8, "51" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 180, new DateTime(2020, 10, 15, 6, 48, 40, 531, DateTimeKind.Local).AddTicks(4988), 5, 194, "80" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 187, new DateTime(2020, 11, 2, 15, 37, 15, 870, DateTimeKind.Local).AddTicks(4113), 2, 139, "11" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 2, new DateTime(2020, 12, 10, 14, 10, 22, 101, DateTimeKind.Local).AddTicks(8326), 1, 235, "17" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 106, new DateTime(2020, 10, 22, 7, 28, 26, 289, DateTimeKind.Local).AddTicks(6374), 1, 286, "14" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 101, new DateTime(2020, 9, 15, 16, 26, 36, 243, DateTimeKind.Local).AddTicks(4580), 2, 201, "72" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 156, new DateTime(2020, 4, 2, 10, 47, 49, 362, DateTimeKind.Local).AddTicks(7091), 3, 298, "36" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 44, new DateTime(2020, 2, 27, 7, 46, 41, 260, DateTimeKind.Local).AddTicks(8060), 4, 118, "21" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 25, new DateTime(2020, 9, 27, 3, 33, 26, 29, DateTimeKind.Local).AddTicks(6399), 1, 118, "99" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 8, new DateTime(2020, 2, 20, 4, 21, 41, 704, DateTimeKind.Local).AddTicks(3795), 1, 59, "63" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 98, new DateTime(2020, 4, 11, 13, 18, 1, 837, DateTimeKind.Local).AddTicks(5122), 3, 59, "33" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 132, new DateTime(2020, 11, 23, 1, 29, 35, 444, DateTimeKind.Local).AddTicks(8347), 2, 119, "77" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 134, new DateTime(2020, 6, 8, 3, 47, 1, 534, DateTimeKind.Local).AddTicks(3298), 2, 119, "77" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 35, new DateTime(2020, 4, 6, 23, 1, 24, 828, DateTimeKind.Local).AddTicks(8010), 6, 419, "35" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 112, new DateTime(2020, 3, 18, 10, 47, 19, 806, DateTimeKind.Local).AddTicks(1662), 6, 212, "28" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 63, new DateTime(2020, 2, 21, 11, 53, 24, 646, DateTimeKind.Local).AddTicks(5415), 6, 332, "89" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 102, new DateTime(2020, 12, 24, 18, 30, 9, 829, DateTimeKind.Local).AddTicks(6428), 2, 311, "97" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 83, new DateTime(2020, 7, 24, 8, 50, 43, 725, DateTimeKind.Local).AddTicks(2608), 2, 269, "63" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 86, new DateTime(2020, 7, 10, 12, 7, 47, 960, DateTimeKind.Local).AddTicks(3062), 1, 256, "60" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 135, new DateTime(2020, 11, 11, 10, 57, 16, 68, DateTimeKind.Local).AddTicks(3115), 6, 124, "43" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 116, new DateTime(2020, 5, 12, 9, 3, 44, 698, DateTimeKind.Local).AddTicks(7358), 3, 94, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 131, new DateTime(2020, 8, 13, 23, 1, 22, 370, DateTimeKind.Local).AddTicks(5162), 1, 74, "68" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 27, new DateTime(2020, 4, 4, 11, 19, 18, 587, DateTimeKind.Local).AddTicks(1094), 5, 74, "53" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 94, new DateTime(2020, 7, 23, 12, 21, 35, 765, DateTimeKind.Local).AddTicks(7944), 2, 225, "33" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 58, new DateTime(2020, 6, 29, 6, 20, 35, 41, DateTimeKind.Local).AddTicks(7524), 5, 34, "87" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 128, new DateTime(2020, 2, 2, 19, 13, 17, 138, DateTimeKind.Local).AddTicks(3221), 2, 294, "17" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 13, new DateTime(2020, 6, 9, 20, 47, 46, 414, DateTimeKind.Local).AddTicks(6754), 5, 316, "64" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 15, new DateTime(2020, 3, 23, 9, 25, 52, 833, DateTimeKind.Local).AddTicks(7977), 2, 316, "12" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 30, new DateTime(2020, 6, 26, 13, 40, 51, 896, DateTimeKind.Local).AddTicks(643), 4, 429, "45" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 142, new DateTime(2020, 10, 7, 9, 2, 22, 436, DateTimeKind.Local).AddTicks(3777), 5, 312, "75" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 195, new DateTime(2020, 5, 5, 11, 36, 26, 12, DateTimeKind.Local).AddTicks(3098), 5, 56, "15" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 173, new DateTime(2020, 2, 25, 11, 1, 0, 869, DateTimeKind.Local).AddTicks(1385), 3, 195, "71" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 143, new DateTime(2020, 3, 29, 8, 16, 5, 599, DateTimeKind.Local).AddTicks(2957), 4, 45, "76" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 105, new DateTime(2020, 10, 9, 22, 54, 47, 282, DateTimeKind.Local).AddTicks(1340), 3, 75, "24" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 188, new DateTime(2020, 9, 16, 15, 46, 17, 275, DateTimeKind.Local).AddTicks(7630), 6, 206, "84" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 20, new DateTime(2020, 11, 15, 10, 57, 6, 354, DateTimeKind.Local).AddTicks(9866), 6, 238, "59" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 73, new DateTime(2020, 8, 29, 4, 3, 15, 467, DateTimeKind.Local).AddTicks(5710), 5, 238, "91" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 78, new DateTime(2020, 8, 26, 23, 31, 45, 63, DateTimeKind.Local).AddTicks(3062), 6, 238, "47" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 196, new DateTime(2020, 10, 27, 4, 40, 22, 440, DateTimeKind.Local).AddTicks(9628), 1, 119, "74" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 37, new DateTime(2020, 5, 10, 3, 33, 42, 215, DateTimeKind.Local).AddTicks(5106), 2, 156, "48" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 45, new DateTime(2020, 6, 6, 11, 20, 46, 858, DateTimeKind.Local).AddTicks(3265), 5, 118, "82" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 53, new DateTime(2020, 8, 14, 4, 17, 0, 776, DateTimeKind.Local).AddTicks(1908), 4, 117, "70" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 40, new DateTime(2020, 4, 27, 17, 59, 16, 451, DateTimeKind.Local).AddTicks(2015), 4, 70, "10" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 26, new DateTime(2020, 3, 28, 11, 36, 46, 568, DateTimeKind.Local).AddTicks(1888), 3, 70, "76" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 70, new DateTime(2020, 9, 26, 7, 7, 32, 812, DateTimeKind.Local).AddTicks(6297), 5, 126, "30" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 10, new DateTime(2020, 11, 13, 8, 37, 21, 979, DateTimeKind.Local).AddTicks(559), 4, 144, "73" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 189, new DateTime(2020, 8, 12, 18, 32, 16, 133, DateTimeKind.Local).AddTicks(2369), 4, 72, "51" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 140, new DateTime(2020, 2, 27, 0, 28, 5, 760, DateTimeKind.Local).AddTicks(5612), 3, 140, "47" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 144, new DateTime(2020, 12, 18, 13, 5, 42, 401, DateTimeKind.Local).AddTicks(1283), 4, 140, "71" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 184, new DateTime(2021, 1, 15, 16, 17, 32, 963, DateTimeKind.Local).AddTicks(3169), 5, 232, "89" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 154, new DateTime(2020, 8, 1, 13, 9, 5, 987, DateTimeKind.Local).AddTicks(5461), 1, 176, "28" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 80, new DateTime(2020, 3, 28, 9, 17, 9, 476, DateTimeKind.Local).AddTicks(6281), 6, 315, "54" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 21, new DateTime(2020, 8, 17, 13, 9, 3, 151, DateTimeKind.Local).AddTicks(3974), 5, 253, "72" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 199, new DateTime(2020, 1, 29, 15, 43, 59, 904, DateTimeKind.Local).AddTicks(7519), 5, 182, "23" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 150, new DateTime(2020, 6, 8, 15, 45, 41, 167, DateTimeKind.Local).AddTicks(70), 3, 375, "63" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 119, new DateTime(2020, 7, 24, 3, 1, 3, 859, DateTimeKind.Local).AddTicks(831), 2, 375, "25" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 160, new DateTime(2020, 6, 27, 19, 25, 56, 36, DateTimeKind.Local).AddTicks(5138), 1, 123, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 96, new DateTime(2020, 10, 13, 14, 3, 42, 46, DateTimeKind.Local).AddTicks(9514), 2, 78, "70" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 32, new DateTime(2020, 10, 7, 2, 47, 25, 920, DateTimeKind.Local).AddTicks(3690), 3, 364, "43" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 194, new DateTime(2020, 6, 2, 18, 29, 28, 938, DateTimeKind.Local).AddTicks(2073), 5, 329, "15" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 158, new DateTime(2020, 11, 10, 1, 23, 40, 838, DateTimeKind.Local).AddTicks(7457), 3, 140, "33" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 74, new DateTime(2020, 4, 17, 18, 46, 23, 74, DateTimeKind.Local).AddTicks(7767), 1, 273, "23" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 85, new DateTime(2020, 10, 8, 13, 18, 37, 906, DateTimeKind.Local).AddTicks(8398), 6, 97, "42" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 91, new DateTime(2020, 10, 3, 11, 18, 56, 530, DateTimeKind.Local).AddTicks(9023), 6, 20, "77" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 181, new DateTime(2020, 9, 13, 21, 35, 7, 900, DateTimeKind.Local).AddTicks(835), 4, 110, "60" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 193, new DateTime(2020, 9, 2, 1, 0, 34, 323, DateTimeKind.Local).AddTicks(309), 4, 239, "87" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 146, new DateTime(2020, 2, 15, 21, 42, 42, 42, DateTimeKind.Local).AddTicks(9835), 3, 314, "82" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 16, new DateTime(2020, 3, 10, 15, 21, 25, 482, DateTimeKind.Local).AddTicks(8940), 5, 347, "10" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 164, new DateTime(2020, 5, 11, 8, 37, 56, 238, DateTimeKind.Local).AddTicks(1683), 1, 347, "97" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 165, new DateTime(2021, 1, 23, 13, 8, 28, 213, DateTimeKind.Local).AddTicks(6613), 3, 383, "46" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 190, new DateTime(2020, 10, 24, 2, 37, 42, 177, DateTimeKind.Local).AddTicks(798), 2, 383, "66" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 152, new DateTime(2020, 6, 9, 1, 13, 36, 46, DateTimeKind.Local).AddTicks(492), 1, 399, "96" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 108, new DateTime(2020, 2, 26, 6, 49, 30, 357, DateTimeKind.Local).AddTicks(5470), 4, 400, "23" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 166, new DateTime(2020, 2, 12, 19, 19, 24, 115, DateTimeKind.Local).AddTicks(3242), 1, 326, "39" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 34, new DateTime(2020, 11, 3, 19, 29, 21, 454, DateTimeKind.Local).AddTicks(6772), 2, 382, "14" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 159, new DateTime(2020, 7, 11, 5, 14, 33, 754, DateTimeKind.Local).AddTicks(3998), 3, 326, "27" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 66, new DateTime(2020, 8, 19, 18, 7, 45, 460, DateTimeKind.Local).AddTicks(6316), 5, 276, "19" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 104, new DateTime(2020, 3, 30, 6, 21, 31, 791, DateTimeKind.Local).AddTicks(9978), 6, 262, "24" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 23, new DateTime(2020, 12, 23, 11, 21, 38, 283, DateTimeKind.Local).AddTicks(6762), 5, 252, "14" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 99, new DateTime(2020, 4, 29, 12, 32, 14, 446, DateTimeKind.Local).AddTicks(9814), 1, 315, "33" });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 5, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 39, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 35, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 34, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 39, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 34, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 42, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 41, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 35, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 13, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 13, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 19, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 19, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 10, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 10, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 8, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 41, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 8, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 7, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 43, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 43, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 42, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 14, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 14, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 11, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 11, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 7, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 6, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 48, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 29, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 30, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 27, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 27, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 16, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 16, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 21, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 21, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 15, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 15, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 20, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 20, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 28, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 28, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 9, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 9, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 47, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 47, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 33, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 33, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 46, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 46, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 44, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 44, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 30, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 36, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 26, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 36, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 32, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 32, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 26, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 29, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 37, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 38, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 25, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 25, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 17, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 17, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 24, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 24, 2 });

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
                values: new object[] { 23, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 23, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 22, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 22, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 4, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 45, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 45, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 38, 2 });

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
                values: new object[] { 31, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 31, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 40, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 37, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 40, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 18, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 12, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 12, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 2, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 48, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 18, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 3, 6 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 4, 2025, "3 التأثير لهدا الإنجاز", 20, "3 بعد الإنجازات لبعض الأنشطة ", "3 وضعية التنفيد لهدا الإنجاز", "3 معدل الإنجاز لهدا الإنجاز", 23.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 33, 2028, "32 التأثير لهدا الإنجاز", 9, "32 بعد الإنجازات لبعض الأنشطة ", "32 وضعية التنفيد لهدا الإنجاز", "32 معدل الإنجاز لهدا الإنجاز", 82.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 14, 2026, "13 التأثير لهدا الإنجاز", 10, "13 بعد الإنجازات لبعض الأنشطة ", "13 وضعية التنفيد لهدا الإنجاز", "13 معدل الإنجاز لهدا الإنجاز", 56.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 18, 2028, "17 التأثير لهدا الإنجاز", 10, "17 بعد الإنجازات لبعض الأنشطة ", "17 وضعية التنفيد لهدا الإنجاز", "17 معدل الإنجاز لهدا الإنجاز", 47.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 20, 2023, "19 التأثير لهدا الإنجاز", 10, "19 بعد الإنجازات لبعض الأنشطة ", "19 وضعية التنفيد لهدا الإنجاز", "19 معدل الإنجاز لهدا الإنجاز", 96.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 19, 2024, "18 التأثير لهدا الإنجاز", 22, "18 بعد الإنجازات لبعض الأنشطة ", "18 وضعية التنفيد لهدا الإنجاز", "18 معدل الإنجاز لهدا الإنجاز", 25.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 49, 2019, "48 التأثير لهدا الإنجاز", 22, "48 بعد الإنجازات لبعض الأنشطة ", "48 وضعية التنفيد لهدا الإنجاز", "48 معدل الإنجاز لهدا الإنجاز", 7.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 31, 2020, "30 التأثير لهدا الإنجاز", 27, "30 بعد الإنجازات لبعض الأنشطة ", "30 وضعية التنفيد لهدا الإنجاز", "30 معدل الإنجاز لهدا الإنجاز", 45.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 55, 2022, "54 التأثير لهدا الإنجاز", 27, "54 بعد الإنجازات لبعض الأنشطة ", "54 وضعية التنفيد لهدا الإنجاز", "54 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 54, 2026, "53 التأثير لهدا الإنجاز", 5, "53 بعد الإنجازات لبعض الأنشطة ", "53 وضعية التنفيد لهدا الإنجاز", "53 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 32, 2026, "31 التأثير لهدا الإنجاز", 46, "31 بعد الإنجازات لبعض الأنشطة ", "31 وضعية التنفيد لهدا الإنجاز", "31 معدل الإنجاز لهدا الإنجاز", 30.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 40, 2020, "39 التأثير لهدا الإنجاز", 46, "39 بعد الإنجازات لبعض الأنشطة ", "39 وضعية التنفيد لهدا الإنجاز", "39 معدل الإنجاز لهدا الإنجاز", 53.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 58, 2026, "57 التأثير لهدا الإنجاز", 46, "57 بعد الإنجازات لبعض الأنشطة ", "57 وضعية التنفيد لهدا الإنجاز", "57 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 23, 2029, "22 التأثير لهدا الإنجاز", 13, "22 بعد الإنجازات لبعض الأنشطة ", "22 وضعية التنفيد لهدا الإنجاز", "22 معدل الإنجاز لهدا الإنجاز", 28.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 63, 2024, "62 التأثير لهدا الإنجاز", 13, "62 بعد الإنجازات لبعض الأنشطة ", "62 وضعية التنفيد لهدا الإنجاز", "62 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 46, 2027, "45 التأثير لهدا الإنجاز", 14, "45 بعد الإنجازات لبعض الأنشطة ", "45 وضعية التنفيد لهدا الإنجاز", "45 معدل الإنجاز لهدا الإنجاز", 57.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 52, 2021, "51 التأثير لهدا الإنجاز", 14, "51 بعد الإنجازات لبعض الأنشطة ", "51 وضعية التنفيد لهدا الإنجاز", "51 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 62, 2028, "61 التأثير لهدا الإنجاز", 14, "61 بعد الإنجازات لبعض الأنشطة ", "61 وضعية التنفيد لهدا الإنجاز", "61 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 35, 2024, "34 التأثير لهدا الإنجاز", 42, "34 بعد الإنجازات لبعض الأنشطة ", "34 وضعية التنفيد لهدا الإنجاز", "34 معدل الإنجاز لهدا الإنجاز", 76.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 30, 2021, "29 التأثير لهدا الإنجاز", 42, "29 بعد الإنجازات لبعض الأنشطة ", "29 وضعية التنفيد لهدا الإنجاز", "29 معدل الإنجاز لهدا الإنجاز", 32.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 1, 2026, "0 التأثير لهدا الإنجاز", 2, "0 بعد الإنجازات لبعض الأنشطة ", "0 وضعية التنفيد لهدا الإنجاز", "0 معدل الإنجاز لهدا الإنجاز", 27.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 53, 2026, "52 التأثير لهدا الإنجاز", 6, "52 بعد الإنجازات لبعض الأنشطة ", "52 وضعية التنفيد لهدا الإنجاز", "52 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 15, 2028, "14 التأثير لهدا الإنجاز", 6, "14 بعد الإنجازات لبعض الأنشطة ", "14 وضعية التنفيد لهدا الإنجاز", "14 معدل الإنجاز لهدا الإنجاز", 52.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 64, 2024, "63 التأثير لهدا الإنجاز", 16, "63 بعد الإنجازات لبعض الأنشطة ", "63 وضعية التنفيد لهدا الإنجاز", "63 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 5, 2019, "4 التأثير لهدا الإنجاز", 9, "4 بعد الإنجازات لبعض الأنشطة ", "4 وضعية التنفيد لهدا الإنجاز", "4 معدل الإنجاز لهدا الإنجاز", 32.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 12, 2028, "11 التأثير لهدا الإنجاز", 30, "11 بعد الإنجازات لبعض الأنشطة ", "11 وضعية التنفيد لهدا الإنجاز", "11 معدل الإنجاز لهدا الإنجاز", 7.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 24, 2025, "23 التأثير لهدا الإنجاز", 45, "23 بعد الإنجازات لبعض الأنشطة ", "23 وضعية التنفيد لهدا الإنجاز", "23 معدل الإنجاز لهدا الإنجاز", 74.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 65, 2021, "64 التأثير لهدا الإنجاز", 18, "64 بعد الإنجازات لبعض الأنشطة ", "64 وضعية التنفيد لهدا الإنجاز", "64 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 61, 2027, "60 التأثير لهدا الإنجاز", 18, "60 بعد الإنجازات لبعض الأنشطة ", "60 وضعية التنفيد لهدا الإنجاز", "60 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 38, 2019, "37 التأثير لهدا الإنجاز", 18, "37 بعد الإنجازات لبعض الأنشطة ", "37 وضعية التنفيد لهدا الإنجاز", "37 معدل الإنجاز لهدا الإنجاز", 3.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 29, 2024, "28 التأثير لهدا الإنجاز", 18, "28 بعد الإنجازات لبعض الأنشطة ", "28 وضعية التنفيد لهدا الإنجاز", "28 معدل الإنجاز لهدا الإنجاز", 44.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 39, 2026, "38 التأثير لهدا الإنجاز", 32, "38 بعد الإنجازات لبعض الأنشطة ", "38 وضعية التنفيد لهدا الإنجاز", "38 معدل الإنجاز لهدا الإنجاز", 36.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 60, 2024, "59 التأثير لهدا الإنجاز", 45, "59 بعد الإنجازات لبعض الأنشطة ", "59 وضعية التنفيد لهدا الإنجاز", "59 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 28, 2019, "27 التأثير لهدا الإنجاز", 7, "27 بعد الإنجازات لبعض الأنشطة ", "27 وضعية التنفيد لهدا الإنجاز", "27 معدل الإنجاز لهدا الإنجاز", 4.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 69, 2023, "68 التأثير لهدا الإنجاز", 44, "68 بعد الإنجازات لبعض الأنشطة ", "68 وضعية التنفيد لهدا الإنجاز", "68 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 13, 2029, "12 التأثير لهدا الإنجاز", 44, "12 بعد الإنجازات لبعض الأنشطة ", "12 وضعية التنفيد لهدا الإنجاز", "12 معدل الإنجاز لهدا الإنجاز", 50.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 25, 2027, "24 التأثير لهدا الإنجاز", 4, "24 بعد الإنجازات لبعض الأنشطة ", "24 وضعية التنفيد لهدا الإنجاز", "24 معدل الإنجاز لهدا الإنجاز", 90.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 7, 2025, "6 التأثير لهدا الإنجاز", 4, "6 بعد الإنجازات لبعض الأنشطة ", "6 وضعية التنفيد لهدا الإنجاز", "6 معدل الإنجاز لهدا الإنجاز", 62.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 8, 2023, "7 التأثير لهدا الإنجاز", 28, "7 بعد الإنجازات لبعض الأنشطة ", "7 وضعية التنفيد لهدا الإنجاز", "7 معدل الإنجاز لهدا الإنجاز", 84.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 59, 2029, "58 التأثير لهدا الإنجاز", 15, "58 بعد الإنجازات لبعض الأنشطة ", "58 وضعية التنفيد لهدا الإنجاز", "58 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 42, 2023, "41 التأثير لهدا الإنجاز", 15, "41 بعد الإنجازات لبعض الأنشطة ", "41 وضعية التنفيد لهدا الإنجاز", "41 معدل الإنجاز لهدا الإنجاز", 42.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 2, 2021, "1 التأثير لهدا الإنجاز", 15, "1 بعد الإنجازات لبعض الأنشطة ", "1 وضعية التنفيد لهدا الإنجاز", "1 معدل الإنجاز لهدا الإنجاز", 59.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 9, 2021, "8 التأثير لهدا الإنجاز", 43, "8 بعد الإنجازات لبعض الأنشطة ", "8 وضعية التنفيد لهدا الإنجاز", "8 معدل الإنجاز لهدا الإنجاز", 40.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 43, 2022, "42 التأثير لهدا الإنجاز", 31, "42 بعد الإنجازات لبعض الأنشطة ", "42 وضعية التنفيد لهدا الإنجاز", "42 معدل الإنجاز لهدا الإنجاز", 9.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 44, 2019, "43 التأثير لهدا الإنجاز", 38, "43 بعد الإنجازات لبعض الأنشطة ", "43 وضعية التنفيد لهدا الإنجاز", "43 معدل الإنجاز لهدا الإنجاز", 1.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 50, 2020, "49 التأثير لهدا الإنجاز", 48, "49 بعد الإنجازات لبعض الأنشطة ", "49 وضعية التنفيد لهدا الإنجاز", "49 معدل الإنجاز لهدا الإنجاز", 94.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 41, 2018, "40 التأثير لهدا الإنجاز", 48, "40 بعد الإنجازات لبعض الأنشطة ", "40 وضعية التنفيد لهدا الإنجاز", "40 معدل الإنجاز لهدا الإنجاز", 65.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 66, 2028, "65 التأثير لهدا الإنجاز", 8, "65 بعد الإنجازات لبعض الأنشطة ", "65 وضعية التنفيد لهدا الإنجاز", "65 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 17, 2022, "16 التأثير لهدا الإنجاز", 8, "16 بعد الإنجازات لبعض الأنشطة ", "16 وضعية التنفيد لهدا الإنجاز", "16 معدل الإنجاز لهدا الإنجاز", 58.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 22, 2018, "21 التأثير لهدا الإنجاز", 20, "21 بعد الإنجازات لبعض الأنشطة ", "21 وضعية التنفيد لهدا الإنجاز", "21 معدل الإنجاز لهدا الإنجاز", 34.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 6, 2025, "5 التأثير لهدا الإنجاز", 31, "5 بعد الإنجازات لبعض الأنشطة ", "5 وضعية التنفيد لهدا الإنجاز", "5 معدل الإنجاز لهدا الإنجاز", 39.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 3, 2018, "2 التأثير لهدا الإنجاز", 36, "2 بعد الإنجازات لبعض الأنشطة ", "2 وضعية التنفيد لهدا الإنجاز", "2 معدل الإنجاز لهدا الإنجاز", 5.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 45, 2019, "44 التأثير لهدا الإنجاز", 43, "44 بعد الإنجازات لبعض الأنشطة ", "44 وضعية التنفيد لهدا الإنجاز", "44 معدل الإنجاز لهدا الإنجاز", 73.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 56, 2028, "55 التأثير لهدا الإنجاز", 1, "55 بعد الإنجازات لبعض الأنشطة ", "55 وضعية التنفيد لهدا الإنجاز", "55 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 68, 2028, "67 التأثير لهدا الإنجاز", 17, "67 بعد الإنجازات لبعض الأنشطة ", "67 وضعية التنفيد لهدا الإنجاز", "67 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 47, 2021, "46 التأثير لهدا الإنجاز", 17, "46 بعد الإنجازات لبعض الأنشطة ", "46 وضعية التنفيد لهدا الإنجاز", "46 معدل الإنجاز لهدا الإنجاز", 26.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 26, 2028, "25 التأثير لهدا الإنجاز", 17, "25 بعد الإنجازات لبعض الأنشطة ", "25 وضعية التنفيد لهدا الإنجاز", "25 معدل الإنجاز لهدا الإنجاز", 58.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 21, 2023, "20 التأثير لهدا الإنجاز", 17, "20 بعد الإنجازات لبعض الأنشطة ", "20 وضعية التنفيد لهدا الإنجاز", "20 معدل الإنجاز لهدا الإنجاز", 65.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 67, 2019, "66 التأثير لهدا الإنجاز", 33, "66 بعد الإنجازات لبعض الأنشطة ", "66 وضعية التنفيد لهدا الإنجاز", "66 معدل الإنجاز لهدا الإنجاز", 0.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 48, 2027, "47 التأثير لهدا الإنجاز", 33, "47 بعد الإنجازات لبعض الأنشطة ", "47 وضعية التنفيد لهدا الإنجاز", "47 معدل الإنجاز لهدا الإنجاز", 15.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 57, 2029, "56 التأثير لهدا الإنجاز", 49, "56 بعد الإنجازات لبعض الأنشطة ", "56 وضعية التنفيد لهدا الإنجاز", "56 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 34, 2026, "33 التأثير لهدا الإنجاز", 33, "33 بعد الإنجازات لبعض الأنشطة ", "33 وضعية التنفيد لهدا الإنجاز", "33 معدل الإنجاز لهدا الإنجاز", 77.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 11, 2021, "10 التأثير لهدا الإنجاز", 24, "10 بعد الإنجازات لبعض الأنشطة ", "10 وضعية التنفيد لهدا الإنجاز", "10 معدل الإنجاز لهدا الإنجاز", 83.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 16, 2026, "15 التأثير لهدا الإنجاز", 39, "15 بعد الإنجازات لبعض الأنشطة ", "15 وضعية التنفيد لهدا الإنجاز", "15 معدل الإنجاز لهدا الإنجاز", 92.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 36, 2021, "35 التأثير لهدا الإنجاز", 29, "35 بعد الإنجازات لبعض الأنشطة ", "35 وضعية التنفيد لهدا الإنجاز", "35 معدل الإنجاز لهدا الإنجاز", 10.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 51, 2021, "50 التأثير لهدا الإنجاز", 34, "50 بعد الإنجازات لبعض الأنشطة ", "50 وضعية التنفيد لهدا الإنجاز", "50 معدل الإنجاز لهدا الإنجاز", 100.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 37, 2019, "36 التأثير لهدا الإنجاز", 34, "36 بعد الإنجازات لبعض الأنشطة ", "36 وضعية التنفيد لهدا الإنجاز", "36 معدل الإنجاز لهدا الإنجاز", 67.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 10, 2022, "9 التأثير لهدا الإنجاز", 34, "9 بعد الإنجازات لبعض الأنشطة ", "9 وضعية التنفيد لهدا الإنجاز", "9 معدل الإنجاز لهدا الإنجاز", 71.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 27, 2023, "26 التأثير لهدا الإنجاز", 24, "26 بعد الإنجازات لبعض الأنشطة ", "26 وضعية التنفيد لهدا الإنجاز", "26 معدل الإنجاز لهدا الإنجاز", 61.0 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[] { 70, 2018, "69 التأثير لهدا الإنجاز", 37, "69 بعد الإنجازات لبعض الأنشطة ", "69 وضعية التنفيد لهدا الإنجاز", "69 معدل الإنجاز لهدا الإنجاز", 0.0 });

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

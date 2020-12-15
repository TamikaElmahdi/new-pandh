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
                values: new object[] { 1, "الديمقراطية والحكامة" });

            migrationBuilder.InsertData(
                table: "Axes",
                columns: new[] { "Id", "Label" },
                values: new object[] { 2, "الحقــوق الاقتصاديــة والاجتماعيــة والثقافيــة والبيئيــة" });

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
                values: new object[] { 20, new DateTime(2020, 8, 14, 20, 25, 21, 149, DateTimeKind.Local).AddTicks(6587), "محضر رقم 20", "اللجنة رقم 20" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 19, new DateTime(2020, 8, 21, 1, 6, 10, 886, DateTimeKind.Local).AddTicks(1544), "محضر رقم 19", "اللجنة رقم 19" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 18, new DateTime(2020, 6, 22, 14, 53, 31, 91, DateTimeKind.Local).AddTicks(7605), "محضر رقم 18", "اللجنة رقم 18" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 17, new DateTime(2020, 5, 10, 21, 59, 11, 308, DateTimeKind.Local).AddTicks(1394), "محضر رقم 17", "اللجنة رقم 17" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 16, new DateTime(2020, 8, 3, 9, 37, 58, 213, DateTimeKind.Local).AddTicks(1531), "محضر رقم 16", "اللجنة رقم 16" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 15, new DateTime(2019, 12, 16, 6, 48, 49, 136, DateTimeKind.Local).AddTicks(1517), "محضر رقم 15", "اللجنة رقم 15" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 14, new DateTime(2020, 3, 7, 9, 41, 45, 735, DateTimeKind.Local).AddTicks(8379), "محضر رقم 14", "اللجنة رقم 14" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 13, new DateTime(2020, 4, 9, 3, 5, 53, 300, DateTimeKind.Local).AddTicks(6299), "محضر رقم 13", "اللجنة رقم 13" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 12, new DateTime(2020, 2, 20, 23, 23, 15, 685, DateTimeKind.Local).AddTicks(2064), "محضر رقم 12", "اللجنة رقم 12" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 11, new DateTime(2020, 11, 16, 0, 17, 30, 967, DateTimeKind.Local).AddTicks(2896), "محضر رقم 11", "اللجنة رقم 11" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 9, new DateTime(2020, 10, 18, 9, 51, 29, 342, DateTimeKind.Local).AddTicks(4493), "محضر رقم 9", "اللجنة رقم 9" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 8, new DateTime(2020, 7, 8, 10, 6, 59, 499, DateTimeKind.Local).AddTicks(6254), "محضر رقم 8", "اللجنة رقم 8" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 7, new DateTime(2020, 12, 7, 13, 38, 33, 982, DateTimeKind.Local).AddTicks(2946), "محضر رقم 7", "اللجنة رقم 7" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 6, new DateTime(2020, 4, 11, 2, 55, 12, 214, DateTimeKind.Local).AddTicks(1049), "محضر رقم 6", "اللجنة رقم 6" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 5, new DateTime(2020, 8, 6, 10, 57, 6, 203, DateTimeKind.Local).AddTicks(9379), "محضر رقم 5", "اللجنة رقم 5" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 4, new DateTime(2020, 5, 16, 4, 7, 25, 258, DateTimeKind.Local).AddTicks(8400), "محضر رقم 4", "اللجنة رقم 4" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 3, new DateTime(2020, 6, 2, 7, 27, 40, 239, DateTimeKind.Local).AddTicks(7027), "محضر رقم 3", "اللجنة رقم 3" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 2, new DateTime(2020, 5, 17, 16, 49, 22, 870, DateTimeKind.Local).AddTicks(3515), "محضر رقم 2", "اللجنة رقم 2" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 1, new DateTime(2020, 6, 14, 11, 12, 5, 742, DateTimeKind.Local).AddTicks(2554), "محضر رقم 1", "اللجنة رقم 1" });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[] { 10, new DateTime(2020, 8, 14, 16, 35, 30, 55, DateTimeKind.Local).AddTicks(8379), "محضر رقم 10", "اللجنة رقم 10" });

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
                values: new object[] { 3, "تقوية القدرات" });

            migrationBuilder.InsertData(
                table: "Natures",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "الجانب التشريعي والمؤسساتي" });

            migrationBuilder.InsertData(
                table: "Natures",
                columns: new[] { "Id", "Label" },
                values: new object[] { 2, "التواصل والتحسيس" });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 7, null, "وزارة الداخلية", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 6, null, "جمعيات المجتمع المدني", null, 3 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 5, null, "الهيئات السياسية ", null, 3 });

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
                values: new object[] { 1, null, "وزارة الدولة المكلفة بحقوق الإنسان", null, 1 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 8, null, "الجمعيات الترابية", null, 2 });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[] { 4, null, "المجلس الوطني لحقوق الإنسان", null, 1 });

            migrationBuilder.InsertData(
                table: "Profils",
                columns: new[] { "Id", "Label" },
                values: new object[] { 3, "لجنة الوطنية" });

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
                values: new object[] { 5, "المخاطب الرئيسي" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 12, "Lucie_Morin16@hotmail.fr", 12, "Marie Leclercq" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 18, "Oceane_Royer@yahoo.fr", 18, "Juliette Adam" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 17, "Noa_Renault5@hotmail.fr", 17, "Anaïs Deschamps" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 16, "Mathilde_Petit48@gmail.com", 16, "Raphaël Mathieu" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 15, "Noah_Bertrand@gmail.com", 15, "Maxence Richard" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 14, "Axel_Perrin9@gmail.com", 14, "Manon Pierre" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 13, "Carla64@yahoo.fr", 13, "Zoe Menard" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 1, "Arthur_Garcia@yahoo.fr", 1, "Gabriel Lefebvre" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 2, "Rayan.Boyer@gmail.com", 2, "Ines Deschamps" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 3, "Lea63@gmail.com", 3, "Thomas Chevalier" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 4, "Louna.Royer64@gmail.com", 4, "Tom Lucas" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 5, "Louna.Collet0@hotmail.fr", 5, "Romane Boyer" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 6, "Alicia_Perez@hotmail.fr", 6, "Quentin Marie" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 7, "Axel.Legall8@yahoo.fr", 7, "Justine Riviere" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 8, "Matheo.Leclercq@hotmail.fr", 8, "Mathis Rousseau" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 9, "Louna_Bertrand45@yahoo.fr", 9, "Paul Charles" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 19, "Chloe.Picard@hotmail.fr", 19, "Elisa Vidal" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 10, "Matteo74@yahoo.fr", 10, "Manon Renard" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 20, "Melissa83@yahoo.fr", 20, "Manon Aubert" });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[] { 11, "Chloe48@yahoo.fr", 11, "Clément Lambert" });

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
                values: new object[] { 8, "Modification", 3, "commission", "commission" });

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
                values: new object[] { 10, "Modification", 2, "mesure-executif", "mesure-executif" });

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
                values: new object[] { 9, 2, "الحقوق الثقافية " });

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
                values: new object[] { 14, 2, " المقاولة وحقوق الإنسان " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 10, 2, " الولوج إلى الخدمات الصحية " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 16, 3, " حقوق الطفل " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 25, 4, " حفظ الأرشيف وصيانته " });

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
                values: new object[] { 15, 3, " الأبعاد المؤسساتية والتشريعية " });

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
                values: new object[] { 22, 4, " الحماية القانونية والمؤسساتية لحقوق المرأة " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 18, 3, " حقوق الأشخاص في وضعية إعاقة " });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[] { 17, 3, "حقوق الشباب " });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 1, true, "Temara", "mourabit@angular.io", "05 ## ## ## ##", 1, 1, "mourabit", "123", "mohamed", "06 ## ## ## ##", "mourabit" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 4, true, "Temara", "soufiane@angular.io", "05 ## ## ## ##", 7, 3, "soufiane", "123", "soufiane", "06 ## ## ## ##", "soufiane" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 11, true, "taza", "fakri-11@angular.io", "05 ## ## ## ##", 7, 5, "fakri-11", "123", "mohamed", "06 ## ## ## ##", "fakri-11" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 2, true, "Temara", "mehdi@angular.io", "05 ## ## ## ##", 8, 2, "mehdi", "123", "mehdi", "06 ## ## ## ##", "mehdi" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 5, true, "taza", "fakri-5@angular.io", "05 ## ## ## ##", 1, 5, "fakri-5", "123", "mohamed", "06 ## ## ## ##", "fakri-5" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 6, true, "taza", "fakri-6@angular.io", "05 ## ## ## ##", 2, 5, "fakri-6", "123", "mohamed", "06 ## ## ## ##", "fakri-6" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 7, true, "taza", "fakri-7@angular.io", "05 ## ## ## ##", 3, 5, "fakri-7", "123", "mohamed", "06 ## ## ## ##", "fakri-7" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 8, true, "taza", "fakri-8@angular.io", "05 ## ## ## ##", 4, 5, "fakri-8", "123", "mohamed", "06 ## ## ## ##", "fakri-8" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 9, true, "taza", "fakri-9@angular.io", "05 ## ## ## ##", 5, 5, "fakri-9", "123", "mohamed", "06 ## ## ## ##", "fakri-9" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 10, true, "taza", "fakri-10@angular.io", "05 ## ## ## ##", 6, 5, "fakri-10", "123", "mohamed", "06 ## ## ## ##", "fakri-10" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 3, true, "Temara", "ahmed@angular.io", "05 ## ## ## ##", 5, 4, "ahmed", "123", "ahmed", "06 ## ## ## ##", "ahmed" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[] { 12, true, "taza", "fakri-12@angular.io", "05 ## ## ## ##", 8, 5, "fakri-12", "123", "mohamed", "06 ## ## ## ##", "fakri-12" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 5, "Code : {id - 1}", 3, 1, 2, 5, 10, 3, "5 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 5", "بعد الأهداف الخاصة : 5", "بعد النتائج المرتقبة : 5" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 6, "Code : {id - 1}", 3, 1, 3, 8, 8, 1, "6 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 6", "بعد الأهداف الخاصة : 6", "بعد النتائج المرتقبة : 6" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 13, "Code : {id - 1}", 4, 2, 1, 8, 8, 2, "13 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 13", "بعد الأهداف الخاصة : 13", "بعد النتائج المرتقبة : 13" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 14, "Code : {id - 1}", 1, 3, 1, 8, 7, 2, "14 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 14", "بعد الأهداف الخاصة : 14", "بعد النتائج المرتقبة : 14" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 17, "Code : {id - 1}", 4, 3, 1, 8, 16, 1, "17 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 17", "بعد الأهداف الخاصة : 17", "بعد النتائج المرتقبة : 17" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 38, "Code : {id - 1}", 3, 1, 3, 8, 18, 1, "38 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 38", "بعد الأهداف الخاصة : 38", "بعد النتائج المرتقبة : 38" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 40, "Code : {id - 1}", 4, 1, 2, 8, 2, 2, "40 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 40", "بعد الأهداف الخاصة : 40", "بعد النتائج المرتقبة : 40" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 41, "Code : {id - 1}", 3, 1, 1, 8, 21, 1, "41 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 41", "بعد الأهداف الخاصة : 41", "بعد النتائج المرتقبة : 41" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 48, "Code : {id - 1}", 2, 1, 1, 8, 18, 2, "48 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 48", "بعد الأهداف الخاصة : 48", "بعد النتائج المرتقبة : 48" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 21, "Code : {id - 1}", 1, 3, 1, 9, 4, 3, "21 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 21", "بعد الأهداف الخاصة : 21", "بعد النتائج المرتقبة : 21" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 34, "Code : {id - 1}", 1, 1, 3, 9, 17, 3, "34 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 34", "بعد الأهداف الخاصة : 34", "بعد النتائج المرتقبة : 34" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 47, "Code : {id - 1}", 1, 3, 1, 9, 14, 1, "47 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 47", "بعد الأهداف الخاصة : 47", "بعد النتائج المرتقبة : 47" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 20, "Code : {id - 1}", 2, 1, 2, 10, 25, 3, "20 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 20", "بعد الأهداف الخاصة : 20", "بعد النتائج المرتقبة : 20" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 35, "Code : {id - 1}", 2, 2, 2, 10, 13, 3, "35 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 35", "بعد الأهداف الخاصة : 35", "بعد النتائج المرتقبة : 35" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 1, "Code : {id - 1}", 3, 3, 2, 11, 10, 3, "1 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 1", "بعد الأهداف الخاصة : 1", "بعد النتائج المرتقبة : 1" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 12, "Code : {id - 1}", 1, 1, 3, 11, 9, 2, "12 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 12", "بعد الأهداف الخاصة : 12", "بعد النتائج المرتقبة : 12" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 22, "Code : {id - 1}", 2, 3, 1, 11, 24, 3, "22 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 22", "بعد الأهداف الخاصة : 22", "بعد النتائج المرتقبة : 22" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 23, "Code : {id - 1}", 2, 1, 2, 11, 25, 2, "23 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 23", "بعد الأهداف الخاصة : 23", "بعد النتائج المرتقبة : 23" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 28, "Code : {id - 1}", 2, 3, 2, 11, 16, 1, "28 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 28", "بعد الأهداف الخاصة : 28", "بعد النتائج المرتقبة : 28" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 29, "Code : {id - 1}", 3, 3, 3, 11, 2, 2, "29 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 29", "بعد الأهداف الخاصة : 29", "بعد النتائج المرتقبة : 29" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 15, "Code : {id - 1}", 2, 2, 3, 12, 26, 2, "15 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 15", "بعد الأهداف الخاصة : 15", "بعد النتائج المرتقبة : 15" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 36, "Code : {id - 1}", 1, 3, 1, 12, 23, 3, "36 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 36", "بعد الأهداف الخاصة : 36", "بعد النتائج المرتقبة : 36" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 50, "Code : {id - 1}", 2, 1, 2, 7, 1, 1, "50 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 50", "بعد الأهداف الخاصة : 50", "بعد النتائج المرتقبة : 50" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 37, "Code : {id - 1}", 3, 3, 3, 7, 20, 1, "37 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 37", "بعد الأهداف الخاصة : 37", "بعد النتائج المرتقبة : 37" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 30, "Code : {id - 1}", 2, 3, 3, 7, 26, 3, "30 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 30", "بعد الأهداف الخاصة : 30", "بعد النتائج المرتقبة : 30" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 26, "Code : {id - 1}", 2, 2, 1, 7, 7, 3, "26 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 26", "بعد الأهداف الخاصة : 26", "بعد النتائج المرتقبة : 26" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 11, "Code : {id - 1}", 4, 2, 1, 5, 16, 3, "11 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 11", "بعد الأهداف الخاصة : 11", "بعد النتائج المرتقبة : 11" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 27, "Code : {id - 1}", 3, 1, 1, 5, 25, 3, "27 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 27", "بعد الأهداف الخاصة : 27", "بعد النتائج المرتقبة : 27" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 31, "Code : {id - 1}", 1, 1, 2, 5, 25, 1, "31 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 31", "بعد الأهداف الخاصة : 31", "بعد النتائج المرتقبة : 31" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 32, "Code : {id - 1}", 1, 1, 3, 5, 5, 3, "32 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 32", "بعد الأهداف الخاصة : 32", "بعد النتائج المرتقبة : 32" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 39, "Code : {id - 1}", 4, 1, 2, 5, 1, 2, "39 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 39", "بعد الأهداف الخاصة : 39", "بعد النتائج المرتقبة : 39" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 43, "Code : {id - 1}", 4, 2, 3, 5, 8, 3, "43 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 43", "بعد الأهداف الخاصة : 43", "بعد النتائج المرتقبة : 43" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 46, "Code : {id - 1}", 1, 2, 1, 5, 3, 1, "46 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 46", "بعد الأهداف الخاصة : 46", "بعد النتائج المرتقبة : 46" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 2, "Code : {id - 1}", 1, 2, 2, 6, 19, 2, "2 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 2", "بعد الأهداف الخاصة : 2", "بعد النتائج المرتقبة : 2" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 4, "Code : {id - 1}", 3, 1, 1, 6, 15, 2, "4 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 4", "بعد الأهداف الخاصة : 4", "بعد النتائج المرتقبة : 4" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 8, "Code : {id - 1}", 4, 3, 1, 6, 14, 1, "8 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 8", "بعد الأهداف الخاصة : 8", "بعد النتائج المرتقبة : 8" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 42, "Code : {id - 1}", 1, 2, 1, 12, 4, 3, "42 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 42", "بعد الأهداف الخاصة : 42", "بعد النتائج المرتقبة : 42" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 9, "Code : {id - 1}", 4, 1, 3, 6, 11, 3, "9 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 9", "بعد الأهداف الخاصة : 9", "بعد النتائج المرتقبة : 9" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 25, "Code : {id - 1}", 1, 3, 2, 6, 24, 1, "25 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 25", "بعد الأهداف الخاصة : 25", "بعد النتائج المرتقبة : 25" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 33, "Code : {id - 1}", 1, 2, 2, 6, 18, 3, "33 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 33", "بعد الأهداف الخاصة : 33", "بعد النتائج المرتقبة : 33" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 44, "Code : {id - 1}", 2, 3, 2, 6, 20, 1, "44 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 44", "بعد الأهداف الخاصة : 44", "بعد النتائج المرتقبة : 44" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 49, "Code : {id - 1}", 1, 3, 3, 6, 22, 2, "49 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 49", "بعد الأهداف الخاصة : 49", "بعد النتائج المرتقبة : 49" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 3, "Code : {id - 1}", 2, 1, 3, 7, 24, 1, "3 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 3", "بعد الأهداف الخاصة : 3", "بعد النتائج المرتقبة : 3" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 7, "Code : {id - 1}", 2, 1, 1, 7, 26, 3, "7 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 7", "بعد الأهداف الخاصة : 7", "بعد النتائج المرتقبة : 7" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 10, "Code : {id - 1}", 2, 2, 3, 7, 14, 2, "10 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 10", "بعد الأهداف الخاصة : 10", "بعد النتائج المرتقبة : 10" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 18, "Code : {id - 1}", 4, 1, 2, 7, 3, 1, "18 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 18", "بعد الأهداف الخاصة : 18", "بعد النتائج المرتقبة : 18" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 19, "Code : {id - 1}", 3, 1, 1, 7, 9, 3, "19 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 19", "بعد الأهداف الخاصة : 19", "بعد النتائج المرتقبة : 19" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 24, "Code : {id - 1}", 4, 1, 1, 7, 18, 1, "24 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 24", "بعد الأهداف الخاصة : 24", "بعد النتائج المرتقبة : 24" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 16, "Code : {id - 1}", 4, 1, 1, 6, 14, 2, "16 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 16", "بعد الأهداف الخاصة : 16", "بعد النتائج المرتقبة : 16" });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[] { 45, "Code : {id - 1}", 4, 2, 2, 12, 19, 2, "45 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 45", "بعد الأهداف الخاصة : 45", "بعد النتائج المرتقبة : 45" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 30, "[\"2020\", \"2021\", \"2022\"]", 16, "29 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 11, "[\"2024\", \"2025\", \"2026\"]", 37, "10 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 18, "[\"2019\", \"2020\", \"2021\"]", 37, "17 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 33, "[\"2026\", \"2027\", \"2028\"]", 37, "32 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 41, "[\"2022\", \"2023\", \"2024\"]", 10, "40 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 32, "[\"2026\", \"2027\", \"2028\"]", 10, "31 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 14, "[\"2021\", \"2022\", \"2023\"]", 10, "13 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 17, "[\"2020\", \"2021\", \"2022\"]", 43, "16 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 31, "[\"2020\", \"2021\", \"2022\"]", 43, "30 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 8, "[\"2021\", \"2022\", \"2023\"]", 10, "7 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 5, "[\"2023\", \"2024\", \"2025\"]", 28, "4 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 36, "[\"2025\", \"2026\", \"2027\"]", 17, "35 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 47, "[\"2026\", \"2027\", \"2028\"]", 17, "46 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 50, "[\"2021\", \"2022\", \"2023\"]", 23, "49 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 44, "[\"2022\", \"2023\", \"2024\"]", 36, "43 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 22, "[\"2024\", \"2025\", \"2026\"]", 49, "21 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 46, "[\"2028\", \"2029\", \"2030\"]", 6, "45 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 39, "[\"2019\", \"2020\", \"2021\"]", 12, "38 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 48, "[\"2026\", \"2027\", \"2028\"]", 42, "47 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 10, "[\"2019\", \"2020\", \"2021\"]", 40, "9 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 1, "[\"2023\", \"2024\", \"2025\"]", 6, "0 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 25, "[\"2025\", \"2026\", \"2027\"]", 50, "24 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 43, "[\"2019\", \"2020\", \"2021\"]", 42, "42 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 6, "[\"2018\", \"2019\", \"2020\"]", 42, "5 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 24, "[\"2019\", \"2020\", \"2021\"]", 4, "23 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 37, "[\"2027\", \"2028\", \"2029\"]", 8, "36 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 12, "[\"2020\", \"2021\", \"2022\"]", 8, "11 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 20, "[\"2025\", \"2026\", \"2027\"]", 48, "19 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 7, "[\"2026\", \"2027\", \"2028\"]", 37, "6 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 4, "[\"2018\", \"2019\", \"2020\"]", 32, "3 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 9, "[\"2020\", \"2021\", \"2022\"]", 24, "8 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 15, "[\"2029\", \"2030\", \"2031\"]", 14, "14 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 3, "[\"2027\", \"2028\", \"2029\"]", 26, "2 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 27, "[\"2028\", \"2029\", \"2030\"]", 26, "26 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 23, "[\"2020\", \"2021\", \"2022\"]", 11, "22 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 21, "[\"2026\", \"2027\", \"2028\"]", 35, "20 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 16, "[\"2028\", \"2029\", \"2030\"]", 14, "15 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 29, "[\"2028\", \"2029\", \"2030\"]", 25, "28 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 13, "[\"2023\", \"2024\", \"2025\"]", 25, "12 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 49, "[\"2029\", \"2030\", \"2031\"]", 19, "48 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 19, "[\"2025\", \"2026\", \"2027\"]", 45, "18 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 2, "[\"2025\", \"2026\", \"2027\"]", 34, "1 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 45, "[\"2018\", \"2019\", \"2020\"]", 19, "44 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 35, "[\"2025\", \"2026\", \"2027\"]", 30, "34 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 38, "[\"2019\", \"2020\", \"2021\"]", 45, "37 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 34, "[\"2025\", \"2026\", \"2027\"]", 45, "33 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 28, "[\"2027\", \"2028\", \"2029\"]", 36, "27 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 26, "[\"2019\", \"2020\", \"2021\"]", 1, "25 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 42, "[\"2024\", \"2025\", \"2026\"]", 48, "41 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[] { 40, "[\"2029\", \"2030\", \"2031\"]", 14, "39 بعد الأنشطة لبعض التدابير" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 65, new DateTime(2020, 6, 7, 1, 23, 27, 297, DateTimeKind.Local).AddTicks(1032), 4, 22, "85" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 34, new DateTime(2020, 6, 30, 4, 42, 13, 204, DateTimeKind.Local).AddTicks(1840), 4, 6, "28" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 25, new DateTime(2020, 9, 20, 5, 5, 25, 984, DateTimeKind.Local).AddTicks(6406), 2, 6, "100" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 14, new DateTime(2020, 7, 8, 7, 38, 23, 879, DateTimeKind.Local).AddTicks(6633), 6, 6, "68" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 102, new DateTime(2020, 11, 6, 2, 59, 44, 527, DateTimeKind.Local).AddTicks(7292), 2, 22, "58" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 197, new DateTime(2020, 4, 10, 6, 35, 44, 27, DateTimeKind.Local).AddTicks(5087), 5, 50, "99" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 110, new DateTime(2020, 7, 4, 16, 29, 15, 848, DateTimeKind.Local).AddTicks(3258), 6, 50, "68" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 39, new DateTime(2020, 3, 21, 0, 15, 44, 996, DateTimeKind.Local).AddTicks(8663), 4, 22, "30" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 59, new DateTime(2020, 10, 3, 16, 59, 36, 459, DateTimeKind.Local).AddTicks(5339), 2, 50, "97" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 99, new DateTime(2020, 3, 11, 12, 55, 35, 296, DateTimeKind.Local).AddTicks(7769), 5, 37, "20" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 16, new DateTime(2020, 2, 24, 13, 43, 5, 920, DateTimeKind.Local).AddTicks(9118), 2, 50, "39" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 128, new DateTime(2020, 10, 6, 12, 6, 8, 723, DateTimeKind.Local).AddTicks(1661), 5, 24, "33" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 193, new DateTime(2020, 10, 31, 7, 7, 48, 755, DateTimeKind.Local).AddTicks(5127), 4, 24, "47" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 155, new DateTime(2020, 9, 1, 3, 22, 19, 235, DateTimeKind.Local).AddTicks(1676), 1, 23, "97" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 119, new DateTime(2020, 7, 3, 17, 15, 46, 587, DateTimeKind.Local).AddTicks(3642), 1, 23, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 76, new DateTime(2020, 7, 15, 14, 55, 48, 469, DateTimeKind.Local).AddTicks(4843), 1, 26, "88" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 93, new DateTime(2020, 4, 30, 7, 20, 47, 123, DateTimeKind.Local).AddTicks(9325), 6, 26, "38" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 178, new DateTime(2020, 10, 21, 9, 28, 40, 778, DateTimeKind.Local).AddTicks(1496), 1, 26, "12" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 89, new DateTime(2020, 7, 9, 17, 38, 41, 963, DateTimeKind.Local).AddTicks(1275), 4, 23, "86" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 55, new DateTime(2020, 5, 23, 4, 43, 6, 952, DateTimeKind.Local).AddTicks(9513), 6, 23, "31" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 49, new DateTime(2020, 6, 8, 22, 20, 39, 382, DateTimeKind.Local).AddTicks(5794), 6, 30, "29" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 57, new DateTime(2020, 3, 13, 8, 59, 19, 42, DateTimeKind.Local).AddTicks(6230), 3, 30, "46" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 58, new DateTime(2020, 5, 9, 3, 52, 51, 739, DateTimeKind.Local).AddTicks(2100), 3, 30, "73" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 36, new DateTime(2020, 4, 3, 0, 20, 10, 308, DateTimeKind.Local).AddTicks(5693), 3, 23, "86" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 35, new DateTime(2020, 11, 28, 4, 15, 53, 273, DateTimeKind.Local).AddTicks(3041), 1, 37, "46" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 47, new DateTime(2020, 6, 21, 4, 56, 9, 764, DateTimeKind.Local).AddTicks(6782), 4, 37, "42" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 33, new DateTime(2020, 3, 4, 0, 25, 51, 107, DateTimeKind.Local).AddTicks(9280), 6, 13, "70" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 114, new DateTime(2020, 5, 25, 22, 48, 9, 697, DateTimeKind.Local).AddTicks(4268), 4, 37, "33" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 147, new DateTime(2020, 1, 9, 11, 31, 55, 562, DateTimeKind.Local).AddTicks(5857), 4, 37, "97" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 156, new DateTime(2020, 4, 13, 19, 29, 16, 242, DateTimeKind.Local).AddTicks(7765), 2, 37, "62" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 186, new DateTime(2020, 1, 31, 20, 39, 49, 584, DateTimeKind.Local).AddTicks(90), 2, 37, "92" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 109, new DateTime(2020, 10, 10, 22, 3, 17, 114, DateTimeKind.Local).AddTicks(3235), 1, 45, "69" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 4, new DateTime(2020, 4, 27, 22, 10, 35, 196, DateTimeKind.Local).AddTicks(3227), 2, 50, "58" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 13, new DateTime(2020, 10, 7, 5, 41, 54, 239, DateTimeKind.Local).AddTicks(770), 6, 50, "78" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 30, new DateTime(2020, 8, 5, 6, 16, 2, 583, DateTimeKind.Local).AddTicks(4293), 1, 50, "87" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 56, new DateTime(2020, 8, 8, 14, 44, 18, 369, DateTimeKind.Local).AddTicks(9078), 1, 13, "99" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 194, new DateTime(2020, 6, 5, 22, 41, 7, 960, DateTimeKind.Local).AddTicks(4665), 2, 45, "82" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 168, new DateTime(2020, 8, 7, 14, 49, 45, 178, DateTimeKind.Local).AddTicks(7972), 1, 13, "71" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 38, new DateTime(2020, 12, 8, 5, 23, 30, 152, DateTimeKind.Local).AddTicks(3214), 5, 41, "22" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 43, new DateTime(2019, 12, 21, 3, 43, 2, 728, DateTimeKind.Local).AddTicks(8459), 3, 41, "78" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 83, new DateTime(2020, 1, 19, 5, 22, 26, 396, DateTimeKind.Local).AddTicks(7227), 4, 41, "82" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 96, new DateTime(2020, 11, 20, 20, 9, 50, 449, DateTimeKind.Local).AddTicks(5302), 5, 41, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 123, new DateTime(2020, 4, 6, 23, 19, 40, 757, DateTimeKind.Local).AddTicks(3374), 1, 41, "62" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 144, new DateTime(2020, 6, 3, 4, 0, 4, 200, DateTimeKind.Local).AddTicks(5539), 1, 41, "38" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 198, new DateTime(2020, 5, 13, 17, 24, 52, 375, DateTimeKind.Local).AddTicks(4723), 1, 41, "70" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 22, new DateTime(2020, 4, 5, 3, 23, 37, 824, DateTimeKind.Local).AddTicks(8900), 5, 48, "15" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 103, new DateTime(2020, 8, 21, 5, 9, 48, 343, DateTimeKind.Local).AddTicks(1797), 1, 48, "77" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 95, new DateTime(2020, 8, 18, 8, 42, 36, 968, DateTimeKind.Local).AddTicks(7982), 3, 35, "20" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 81, new DateTime(2020, 7, 14, 17, 6, 2, 989, DateTimeKind.Local).AddTicks(6041), 1, 35, "31" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 60, new DateTime(2020, 5, 13, 16, 18, 2, 492, DateTimeKind.Local).AddTicks(905), 1, 21, "71" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 79, new DateTime(2020, 11, 9, 18, 15, 0, 560, DateTimeKind.Local).AddTicks(7263), 6, 21, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 135, new DateTime(2020, 12, 11, 12, 38, 30, 427, DateTimeKind.Local).AddTicks(5416), 2, 21, "28" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 196, new DateTime(2020, 2, 29, 1, 54, 48, 828, DateTimeKind.Local).AddTicks(6004), 4, 21, "39" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 44, new DateTime(2020, 4, 27, 21, 14, 49, 72, DateTimeKind.Local).AddTicks(8033), 5, 35, "93" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 78, new DateTime(2020, 9, 27, 6, 39, 49, 455, DateTimeKind.Local).AddTicks(4272), 1, 34, "24" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 86, new DateTime(2020, 3, 5, 14, 50, 1, 539, DateTimeKind.Local).AddTicks(5614), 6, 34, "45" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 97, new DateTime(2020, 3, 11, 11, 15, 19, 396, DateTimeKind.Local).AddTicks(7553), 2, 34, "51" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 101, new DateTime(2020, 11, 6, 16, 58, 42, 544, DateTimeKind.Local).AddTicks(3968), 4, 34, "85" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 50, new DateTime(2020, 3, 16, 8, 54, 8, 397, DateTimeKind.Local).AddTicks(4762), 6, 47, "54" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 133, new DateTime(2020, 5, 20, 2, 30, 15, 43, DateTimeKind.Local).AddTicks(1399), 5, 47, "99" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 169, new DateTime(2020, 9, 4, 16, 10, 13, 253, DateTimeKind.Local).AddTicks(8388), 2, 47, "43" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 174, new DateTime(2020, 6, 18, 16, 8, 16, 752, DateTimeKind.Local).AddTicks(3584), 1, 47, "52" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 189, new DateTime(2020, 6, 13, 8, 2, 42, 872, DateTimeKind.Local).AddTicks(9113), 1, 20, "83" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 32, new DateTime(2020, 8, 31, 1, 24, 25, 667, DateTimeKind.Local).AddTicks(7440), 3, 41, "17" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 74, new DateTime(2020, 3, 20, 15, 15, 32, 386, DateTimeKind.Local).AddTicks(4187), 1, 13, "86" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 31, new DateTime(2020, 7, 23, 5, 8, 3, 42, DateTimeKind.Local).AddTicks(7709), 2, 1, "27" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 106, new DateTime(2020, 6, 1, 23, 6, 37, 268, DateTimeKind.Local).AddTicks(6879), 1, 40, "12" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 179, new DateTime(2020, 6, 15, 4, 44, 16, 586, DateTimeKind.Local).AddTicks(8926), 1, 13, "53" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 190, new DateTime(2020, 8, 8, 19, 51, 46, 363, DateTimeKind.Local).AddTicks(2754), 4, 13, "100" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 140, new DateTime(2020, 5, 15, 6, 0, 0, 357, DateTimeKind.Local).AddTicks(8234), 3, 14, "91" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 150, new DateTime(2020, 10, 18, 5, 10, 38, 23, DateTimeKind.Local).AddTicks(6183), 1, 14, "25" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 158, new DateTime(2020, 8, 28, 0, 10, 58, 981, DateTimeKind.Local).AddTicks(6000), 3, 14, "34" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 166, new DateTime(2020, 7, 29, 17, 27, 20, 708, DateTimeKind.Local).AddTicks(816), 3, 14, "31" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 177, new DateTime(2020, 1, 11, 21, 12, 55, 738, DateTimeKind.Local).AddTicks(6764), 1, 14, "37" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 112, new DateTime(2020, 6, 8, 9, 4, 2, 309, DateTimeKind.Local).AddTicks(5237), 2, 12, "10" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 108, new DateTime(2020, 7, 1, 5, 10, 40, 582, DateTimeKind.Local).AddTicks(4860), 6, 12, "88" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 54, new DateTime(2020, 6, 18, 19, 3, 4, 395, DateTimeKind.Local).AddTicks(6589), 6, 17, "87" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 72, new DateTime(2020, 11, 20, 0, 43, 10, 203, DateTimeKind.Local).AddTicks(7148), 4, 17, "98" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 84, new DateTime(2020, 8, 20, 19, 4, 43, 917, DateTimeKind.Local).AddTicks(262), 4, 17, "46" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 104, new DateTime(2020, 3, 24, 19, 3, 3, 79, DateTimeKind.Local).AddTicks(6330), 2, 17, "65" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 107, new DateTime(2020, 10, 7, 6, 10, 37, 177, DateTimeKind.Local).AddTicks(210), 6, 17, "91" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 116, new DateTime(2020, 11, 14, 14, 22, 22, 904, DateTimeKind.Local).AddTicks(4212), 3, 17, "89" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 130, new DateTime(2020, 10, 15, 6, 36, 20, 254, DateTimeKind.Local).AddTicks(8720), 1, 17, "20" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 146, new DateTime(2020, 3, 19, 18, 44, 16, 257, DateTimeKind.Local).AddTicks(7018), 2, 17, "60" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 66, new DateTime(2020, 8, 19, 19, 58, 25, 268, DateTimeKind.Local).AddTicks(8166), 4, 38, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 111, new DateTime(2020, 5, 3, 14, 49, 35, 492, DateTimeKind.Local).AddTicks(6699), 3, 38, "84" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 181, new DateTime(2020, 10, 11, 4, 51, 58, 922, DateTimeKind.Local).AddTicks(4258), 1, 38, "44" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 183, new DateTime(2020, 8, 1, 19, 30, 29, 877, DateTimeKind.Local).AddTicks(7825), 6, 38, "16" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 148, new DateTime(2020, 1, 14, 4, 16, 47, 361, DateTimeKind.Local).AddTicks(1964), 5, 1, "96" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 73, new DateTime(2020, 2, 10, 20, 8, 13, 807, DateTimeKind.Local).AddTicks(2862), 3, 40, "80" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 85, new DateTime(2020, 4, 22, 9, 36, 55, 767, DateTimeKind.Local).AddTicks(6999), 2, 40, "28" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 90, new DateTime(2020, 7, 16, 2, 38, 17, 599, DateTimeKind.Local).AddTicks(19), 3, 40, "58" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 126, new DateTime(2020, 3, 16, 20, 25, 25, 345, DateTimeKind.Local).AddTicks(2442), 5, 40, "97" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 125, new DateTime(2020, 1, 9, 2, 8, 57, 30, DateTimeKind.Local).AddTicks(7593), 5, 24, "39" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 11, new DateTime(2020, 12, 7, 0, 43, 9, 846, DateTimeKind.Local).AddTicks(4504), 3, 20, "16" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 141, new DateTime(2020, 4, 10, 10, 22, 16, 918, DateTimeKind.Local).AddTicks(4213), 1, 9, "79" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 173, new DateTime(2020, 3, 13, 0, 44, 10, 841, DateTimeKind.Local).AddTicks(6479), 1, 2, "71" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 175, new DateTime(2020, 5, 21, 0, 59, 47, 483, DateTimeKind.Local).AddTicks(8823), 5, 11, "66" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 138, new DateTime(2020, 7, 6, 18, 23, 23, 489, DateTimeKind.Local).AddTicks(789), 2, 36, "15" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 75, new DateTime(2020, 6, 2, 22, 19, 22, 412, DateTimeKind.Local).AddTicks(5683), 3, 36, "89" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 63, new DateTime(2020, 11, 11, 11, 53, 43, 81, DateTimeKind.Local).AddTicks(1028), 5, 4, "16" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 200, new DateTime(2020, 7, 26, 6, 51, 32, 449, DateTimeKind.Local).AddTicks(6833), 2, 4, "81" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 53, new DateTime(2020, 10, 21, 14, 12, 19, 339, DateTimeKind.Local).AddTicks(8009), 4, 36, "34" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 92, new DateTime(2020, 2, 27, 4, 24, 58, 848, DateTimeKind.Local).AddTicks(8547), 2, 11, "90" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 124, new DateTime(2020, 7, 23, 11, 6, 19, 695, DateTimeKind.Local).AddTicks(3171), 2, 8, "21" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 164, new DateTime(2020, 11, 5, 15, 8, 45, 754, DateTimeKind.Local).AddTicks(6269), 6, 8, "49" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 17, new DateTime(2020, 3, 9, 20, 58, 35, 24, DateTimeKind.Local).AddTicks(7425), 1, 2, "11" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 42, new DateTime(2020, 8, 6, 22, 29, 0, 325, DateTimeKind.Local).AddTicks(7084), 4, 11, "64" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 113, new DateTime(2020, 3, 22, 19, 49, 54, 488, DateTimeKind.Local).AddTicks(21), 3, 9, "91" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 45, new DateTime(2020, 5, 15, 1, 39, 3, 461, DateTimeKind.Local).AddTicks(9313), 3, 24, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 159, new DateTime(2020, 9, 27, 2, 22, 46, 235, DateTimeKind.Local).AddTicks(7571), 3, 15, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 7, new DateTime(2020, 9, 13, 11, 51, 16, 428, DateTimeKind.Local).AddTicks(3534), 6, 16, "46" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 12, new DateTime(2020, 1, 20, 20, 37, 30, 712, DateTimeKind.Local).AddTicks(261), 1, 16, "64" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 61, new DateTime(2020, 3, 6, 19, 38, 17, 825, DateTimeKind.Local).AddTicks(9185), 5, 16, "79" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 87, new DateTime(2020, 8, 15, 11, 9, 8, 209, DateTimeKind.Local).AddTicks(8327), 4, 16, "48" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 5, new DateTime(2020, 7, 25, 23, 11, 27, 672, DateTimeKind.Local).AddTicks(3893), 5, 45, "61" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 120, new DateTime(2020, 11, 7, 17, 36, 39, 438, DateTimeKind.Local).AddTicks(4651), 3, 16, "38" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 91, new DateTime(2020, 10, 17, 4, 2, 0, 890, DateTimeKind.Local).AddTicks(6472), 6, 27, "25" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 69, new DateTime(2020, 6, 15, 12, 36, 46, 670, DateTimeKind.Local).AddTicks(9126), 4, 9, "32" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 161, new DateTime(2020, 10, 9, 12, 18, 6, 332, DateTimeKind.Local).AddTicks(9132), 3, 46, "18" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 67, new DateTime(2020, 12, 5, 18, 30, 16, 886, DateTimeKind.Local).AddTicks(6356), 4, 46, "23" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 52, new DateTime(2020, 5, 2, 4, 57, 33, 918, DateTimeKind.Local).AddTicks(7984), 1, 46, "40" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 46, new DateTime(2020, 5, 14, 1, 50, 48, 122, DateTimeKind.Local).AddTicks(7242), 3, 31, "53" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 115, new DateTime(2020, 7, 4, 2, 1, 12, 924, DateTimeKind.Local).AddTicks(5257), 2, 31, "81" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 139, new DateTime(2020, 5, 5, 7, 54, 46, 415, DateTimeKind.Local).AddTicks(5075), 1, 31, "43" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 176, new DateTime(2020, 8, 11, 0, 25, 51, 236, DateTimeKind.Local).AddTicks(2256), 4, 31, "72" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 180, new DateTime(2020, 6, 4, 21, 6, 28, 735, DateTimeKind.Local).AddTicks(3036), 6, 31, "39" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 3, new DateTime(2020, 5, 24, 18, 15, 45, 741, DateTimeKind.Local).AddTicks(1750), 6, 27, "32" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 191, new DateTime(2020, 4, 29, 10, 23, 12, 602, DateTimeKind.Local).AddTicks(863), 3, 31, "25" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 142, new DateTime(2020, 5, 12, 14, 52, 25, 276, DateTimeKind.Local).AddTicks(7822), 5, 42, "19" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 51, new DateTime(2020, 7, 18, 8, 57, 18, 668, DateTimeKind.Local).AddTicks(5827), 3, 32, "94" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 64, new DateTime(2020, 6, 13, 17, 20, 26, 223, DateTimeKind.Local).AddTicks(8279), 6, 32, "56" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 100, new DateTime(2020, 11, 25, 20, 6, 18, 753, DateTimeKind.Local).AddTicks(9171), 2, 42, "61" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 41, new DateTime(2019, 12, 23, 13, 52, 55, 45, DateTimeKind.Local).AddTicks(2103), 6, 42, "49" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 24, new DateTime(2020, 10, 28, 5, 36, 45, 451, DateTimeKind.Local).AddTicks(4940), 5, 39, "24" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 98, new DateTime(2020, 8, 14, 13, 23, 21, 501, DateTimeKind.Local).AddTicks(1378), 6, 39, "59" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 184, new DateTime(2020, 1, 12, 7, 9, 15, 309, DateTimeKind.Local).AddTicks(9819), 4, 39, "59" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 15, new DateTime(2020, 10, 18, 7, 3, 43, 733, DateTimeKind.Local).AddTicks(3109), 5, 42, "35" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 27, new DateTime(2020, 4, 6, 12, 27, 8, 643, DateTimeKind.Local).AddTicks(2749), 6, 43, "30" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 28, new DateTime(2020, 3, 27, 6, 28, 21, 636, DateTimeKind.Local).AddTicks(7133), 6, 43, "45" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 132, new DateTime(2020, 9, 8, 8, 49, 47, 775, DateTimeKind.Local).AddTicks(5142), 1, 43, "80" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 136, new DateTime(2019, 12, 16, 17, 15, 9, 283, DateTimeKind.Local).AddTicks(6036), 1, 43, "81" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 137, new DateTime(2020, 6, 24, 6, 59, 29, 610, DateTimeKind.Local).AddTicks(2416), 3, 43, "75" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 153, new DateTime(2020, 2, 21, 9, 32, 25, 236, DateTimeKind.Local).AddTicks(4374), 5, 43, "29" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 195, new DateTime(2020, 2, 14, 4, 10, 43, 300, DateTimeKind.Local).AddTicks(8495), 4, 11, "22" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 151, new DateTime(2020, 6, 28, 16, 59, 9, 24, DateTimeKind.Local).AddTicks(3578), 1, 15, "19" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 162, new DateTime(2020, 1, 9, 3, 6, 7, 251, DateTimeKind.Local).AddTicks(6241), 1, 25, "14" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 157, new DateTime(2020, 10, 4, 2, 41, 45, 908, DateTimeKind.Local).AddTicks(2322), 4, 15, "74" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 117, new DateTime(2020, 9, 9, 5, 32, 0, 226, DateTimeKind.Local).AddTicks(8030), 2, 15, "48" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 187, new DateTime(2020, 1, 16, 0, 35, 41, 308, DateTimeKind.Local).AddTicks(9859), 4, 3, "56" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 23, new DateTime(2020, 3, 24, 5, 31, 31, 515, DateTimeKind.Local).AddTicks(5584), 5, 29, "96" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 1, new DateTime(2020, 5, 11, 10, 21, 58, 755, DateTimeKind.Local).AddTicks(173), 6, 29, "96" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 170, new DateTime(2020, 10, 18, 10, 6, 11, 102, DateTimeKind.Local).AddTicks(3358), 3, 5, "27" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 18, new DateTime(2020, 2, 10, 4, 7, 55, 720, DateTimeKind.Local).AddTicks(2313), 5, 7, "19" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 134, new DateTime(2020, 9, 22, 4, 41, 48, 918, DateTimeKind.Local).AddTicks(5324), 3, 5, "38" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 82, new DateTime(2020, 12, 10, 19, 48, 16, 591, DateTimeKind.Local).AddTicks(4097), 2, 45, "23" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 6, new DateTime(2020, 10, 23, 8, 54, 59, 603, DateTimeKind.Local).AddTicks(4807), 1, 10, "22" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 8, new DateTime(2020, 10, 13, 3, 14, 21, 903, DateTimeKind.Local).AddTicks(208), 5, 10, "88" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 62, new DateTime(2020, 3, 17, 14, 3, 28, 411, DateTimeKind.Local).AddTicks(4392), 5, 10, "14" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 160, new DateTime(2020, 3, 20, 3, 58, 6, 668, DateTimeKind.Local).AddTicks(6627), 1, 10, "18" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 165, new DateTime(2020, 11, 30, 1, 14, 53, 163, DateTimeKind.Local).AddTicks(9029), 3, 28, "25" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 118, new DateTime(2020, 1, 8, 20, 35, 50, 549, DateTimeKind.Local).AddTicks(9000), 3, 28, "77" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 37, new DateTime(2020, 3, 18, 21, 33, 46, 578, DateTimeKind.Local).AddTicks(8908), 2, 18, "79" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 70, new DateTime(2020, 1, 14, 17, 21, 51, 946, DateTimeKind.Local).AddTicks(2759), 2, 18, "23" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 71, new DateTime(2020, 2, 6, 14, 14, 27, 698, DateTimeKind.Local).AddTicks(7909), 4, 18, "72" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 182, new DateTime(2020, 1, 23, 7, 33, 50, 474, DateTimeKind.Local).AddTicks(9846), 6, 18, "49" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 9, new DateTime(2020, 3, 6, 14, 35, 3, 166, DateTimeKind.Local).AddTicks(852), 2, 28, "26" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 145, new DateTime(2020, 6, 28, 20, 50, 23, 758, DateTimeKind.Local).AddTicks(388), 3, 20, "66" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 48, new DateTime(2020, 8, 2, 13, 5, 6, 818, DateTimeKind.Local).AddTicks(8432), 3, 19, "84" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 143, new DateTime(2020, 11, 18, 10, 11, 36, 629, DateTimeKind.Local).AddTicks(756), 2, 19, "58" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 149, new DateTime(2020, 2, 8, 6, 25, 10, 673, DateTimeKind.Local).AddTicks(8727), 4, 19, "85" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 163, new DateTime(2020, 9, 20, 2, 19, 46, 50, DateTimeKind.Local).AddTicks(8965), 6, 19, "46" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 172, new DateTime(2020, 7, 17, 21, 55, 10, 736, DateTimeKind.Local).AddTicks(3137), 1, 3, "24" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 199, new DateTime(2020, 8, 15, 9, 36, 20, 445, DateTimeKind.Local).AddTicks(7028), 5, 25, "45" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 26, new DateTime(2020, 9, 18, 16, 55, 1, 490, DateTimeKind.Local).AddTicks(6830), 6, 3, "79" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 2, new DateTime(2020, 6, 13, 18, 20, 37, 579, DateTimeKind.Local).AddTicks(9463), 3, 3, "56" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 21, new DateTime(2020, 9, 19, 18, 11, 39, 449, DateTimeKind.Local).AddTicks(7729), 3, 15, "33" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 40, new DateTime(2020, 6, 28, 9, 57, 9, 59, DateTimeKind.Local).AddTicks(3292), 3, 33, "48" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 77, new DateTime(2019, 12, 24, 1, 47, 32, 563, DateTimeKind.Local).AddTicks(526), 5, 33, "94" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 127, new DateTime(2020, 4, 7, 11, 15, 23, 876, DateTimeKind.Local).AddTicks(5138), 6, 33, "34" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 152, new DateTime(2020, 6, 11, 7, 29, 30, 746, DateTimeKind.Local).AddTicks(9224), 6, 33, "66" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 80, new DateTime(2020, 8, 27, 15, 5, 20, 396, DateTimeKind.Local).AddTicks(5775), 2, 45, "100" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 192, new DateTime(2020, 4, 29, 3, 53, 33, 287, DateTimeKind.Local).AddTicks(9687), 4, 5, "44" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 68, new DateTime(2020, 7, 27, 14, 19, 8, 359, DateTimeKind.Local).AddTicks(7511), 4, 44, "16" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 105, new DateTime(2020, 1, 11, 23, 23, 4, 874, DateTimeKind.Local).AddTicks(3555), 1, 44, "55" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 154, new DateTime(2020, 1, 29, 23, 57, 5, 541, DateTimeKind.Local).AddTicks(8635), 3, 44, "32" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 188, new DateTime(2020, 9, 4, 9, 8, 49, 837, DateTimeKind.Local).AddTicks(731), 6, 29, "91" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 20, new DateTime(2020, 9, 13, 4, 27, 1, 303, DateTimeKind.Local).AddTicks(1551), 1, 3, "86" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 171, new DateTime(2020, 8, 22, 5, 45, 35, 330, DateTimeKind.Local).AddTicks(4088), 5, 29, "84" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 29, new DateTime(2020, 6, 18, 18, 16, 13, 152, DateTimeKind.Local).AddTicks(9354), 1, 49, "88" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 88, new DateTime(2020, 6, 9, 15, 3, 59, 98, DateTimeKind.Local).AddTicks(3260), 5, 49, "87" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 94, new DateTime(2020, 4, 6, 21, 3, 53, 336, DateTimeKind.Local).AddTicks(7097), 3, 49, "66" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 121, new DateTime(2020, 2, 9, 9, 30, 12, 810, DateTimeKind.Local).AddTicks(1188), 3, 49, "10" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 122, new DateTime(2020, 9, 16, 15, 54, 54, 41, DateTimeKind.Local).AddTicks(4435), 1, 49, "75" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 129, new DateTime(2020, 1, 4, 20, 20, 24, 203, DateTimeKind.Local).AddTicks(6065), 5, 49, "53" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 185, new DateTime(2020, 12, 11, 18, 38, 31, 555, DateTimeKind.Local).AddTicks(2864), 3, 5, "13" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 167, new DateTime(2020, 7, 19, 4, 2, 2, 956, DateTimeKind.Local).AddTicks(554), 6, 29, "57" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 131, new DateTime(2020, 6, 28, 15, 28, 53, 255, DateTimeKind.Local).AddTicks(584), 2, 29, "51" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 19, new DateTime(2020, 3, 9, 3, 45, 31, 306, DateTimeKind.Local).AddTicks(1187), 3, 49, "10" });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[] { 10, new DateTime(2020, 10, 22, 4, 23, 36, 655, DateTimeKind.Local).AddTicks(2608), 1, 27, "86" });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 45, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 45, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 35, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 35, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 28, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 29, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 29, 3 });

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
                values: new object[] { 15, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 15, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 22, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 36, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 36, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 12, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 12, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 42, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 42, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 22, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 28, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 50, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 20, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 8, 1 });

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
                values: new object[] { 16, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 16, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 25, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 25, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 33, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 33, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 44, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 44, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 49, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 49, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 3, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 8, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 5, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 11, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 11, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 27, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 27, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 31, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 31, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 7, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 32, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 39, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 39, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 43, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 43, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 46, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 46, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 2, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 32, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 20, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 10, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 17, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 38, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 38, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 40, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 40, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 41, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 41, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 48, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 48, 2 });

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
                values: new object[] { 34, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 34, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 47, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 47, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 17, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 14, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 14, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 13, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 18, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 18, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 19, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 19, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 24, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 24, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 26, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 10, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 26, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 30, 3 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 37, 4 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 37, 1 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 50, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 6, 6 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 13, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 30, 5 });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 2, 2022, "1 التأثير لهدا الإنجاز", 4, "1 بعد الإنجازات لبعض الأنشطة ", "1 وضعية التنفيد لهدا الإنجاز", "1 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 7, 2024, "6 التأثير لهدا الإنجاز", 46, "6 بعد الإنجازات لبعض الأنشطة ", "6 وضعية التنفيد لهدا الإنجاز", "6 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 11, 2022, "10 التأثير لهدا الإنجاز", 46, "10 بعد الإنجازات لبعض الأنشطة ", "10 وضعية التنفيد لهدا الإنجاز", "10 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 30, 2021, "29 التأثير لهدا الإنجاز", 46, "29 بعد الإنجازات لبعض الأنشطة ", "29 وضعية التنفيد لهدا الإنجاز", "29 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 15, 2023, "14 التأثير لهدا الإنجاز", 15, "14 بعد الإنجازات لبعض الأنشطة ", "14 وضعية التنفيد لهدا الإنجاز", "14 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 16, 2028, "15 التأثير لهدا الإنجاز", 40, "15 بعد الإنجازات لبعض الأنشطة ", "15 وضعية التنفيد لهدا الإنجاز", "15 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 22, 2021, "21 التأثير لهدا الإنجاز", 10, "21 بعد الإنجازات لبعض الأنشطة ", "21 وضعية التنفيد لهدا الإنجاز", "21 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 23, 2027, "22 التأثير لهدا الإنجاز", 10, "22 بعد الإنجازات لبعض الأنشطة ", "22 وضعية التنفيد لهدا الإنجاز", "22 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 27, 2021, "26 التأثير لهدا الإنجاز", 20, "26 بعد الإنجازات لبعض الأنشطة ", "26 وضعية التنفيد لهدا الإنجاز", "26 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 37, 2020, "36 التأثير لهدا الإنجاز", 42, "36 بعد الإنجازات لبعض الأنشطة ", "36 وضعية التنفيد لهدا الإنجاز", "36 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 17, 2029, "16 التأثير لهدا الإنجاز", 26, "16 بعد الإنجازات لبعض الأنشطة ", "16 وضعية التنفيد لهدا الإنجاز", "16 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 9, 2021, "8 التأثير لهدا الإنجاز", 39, "8 بعد الإنجازات لبعض الأنشطة ", "8 وضعية التنفيد لهدا الإنجاز", "8 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 24, 2024, "23 التأثير لهدا الإنجاز", 39, "23 بعد الإنجازات لبعض الأنشطة ", "23 وضعية التنفيد لهدا الإنجاز", "23 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 45, 2023, "44 التأثير لهدا الإنجاز", 50, "44 بعد الإنجازات لبعض الأنشطة ", "44 وضعية التنفيد لهدا الإنجاز", "44 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 32, 2021, "31 التأثير لهدا الإنجاز", 5, "31 بعد الإنجازات لبعض الأنشطة ", "31 وضعية التنفيد لهدا الإنجاز", "31 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 40, 2023, "39 التأثير لهدا الإنجاز", 28, "39 بعد الإنجازات لبعض الأنشطة ", "39 وضعية التنفيد لهدا الإنجاز", "39 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 10, 2019, "9 التأثير لهدا الإنجاز", 44, "9 بعد الإنجازات لبعض الأنشطة ", "9 وضعية التنفيد لهدا الإنجاز", "9 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 3, 2022, "2 التأثير لهدا الإنجاز", 43, "2 بعد الإنجازات لبعض الأنشطة ", "2 وضعية التنفيد لهدا الإنجاز", "2 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 36, 2021, "35 التأثير لهدا الإنجاز", 43, "35 بعد الإنجازات لبعض الأنشطة ", "35 وضعية التنفيد لهدا الإنجاز", "35 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 41, 2028, "40 التأثير لهدا الإنجاز", 43, "40 بعد الإنجازات لبعض الأنشطة ", "40 وضعية التنفيد لهدا الإنجاز", "40 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 28, 2019, "27 التأثير لهدا الإنجاز", 34, "27 بعد الإنجازات لبعض الأنشطة ", "27 وضعية التنفيد لهدا الإنجاز", "27 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 4, 2020, "3 التأثير لهدا الإنجاز", 38, "3 بعد الإنجازات لبعض الأنشطة ", "3 وضعية التنفيد لهدا الإنجاز", "3 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 34, 2026, "33 التأثير لهدا الإنجاز", 1, "33 بعد الإنجازات لبعض الأنشطة ", "33 وضعية التنفيد لهدا الإنجاز", "33 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 14, 2025, "13 التأثير لهدا الإنجاز", 25, "13 بعد الإنجازات لبعض الأنشطة ", "13 وضعية التنفيد لهدا الإنجاز", "13 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 13, 2026, "12 التأثير لهدا الإنجاز", 25, "12 بعد الإنجازات لبعض الأنشطة ", "12 وضعية التنفيد لهدا الإنجاز", "12 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 47, 2019, "46 التأثير لهدا الإنجاز", 33, "46 بعد الإنجازات لبعض الأنشطة ", "46 وضعية التنفيد لهدا الإنجاز", "46 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 50, 2020, "49 التأثير لهدا الإنجاز", 4, "49 بعد الإنجازات لبعض الأنشطة ", "49 وضعية التنفيد لهدا الإنجاز", "49 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 21, 2025, "20 التأثير لهدا الإنجاز", 31, "20 بعد الإنجازات لبعض الأنشطة ", "20 وضعية التنفيد لهدا الإنجاز", "20 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 39, 2025, "38 التأثير لهدا الإنجاز", 31, "38 بعد الإنجازات لبعض الأنشطة ", "38 وضعية التنفيد لهدا الإنجاز", "38 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 19, 2027, "18 التأثير لهدا الإنجاز", 24, "18 بعد الإنجازات لبعض الأنشطة ", "18 وضعية التنفيد لهدا الإنجاز", "18 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 1, 2025, "0 التأثير لهدا الإنجاز", 12, "0 بعد الإنجازات لبعض الأنشطة ", "0 وضعية التنفيد لهدا الإنجاز", "0 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 26, 2024, "25 التأثير لهدا الإنجاز", 12, "25 بعد الإنجازات لبعض الأنشطة ", "25 وضعية التنفيد لهدا الإنجاز", "25 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 49, 2021, "48 التأثير لهدا الإنجاز", 12, "48 بعد الإنجازات لبعض الأنشطة ", "48 وضعية التنفيد لهدا الإنجاز", "48 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 44, 2024, "43 التأثير لهدا الإنجاز", 30, "43 بعد الإنجازات لبعض الأنشطة ", "43 وضعية التنفيد لهدا الإنجاز", "43 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 29, 2023, "28 التأثير لهدا الإنجاز", 8, "28 بعد الإنجازات لبعض الأنشطة ", "28 وضعية التنفيد لهدا الإنجاز", "28 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 12, 2027, "11 التأثير لهدا الإنجاز", 14, "11 بعد الإنجازات لبعض الأنشطة ", "11 وضعية التنفيد لهدا الإنجاز", "11 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 33, 2029, "32 التأثير لهدا الإنجاز", 38, "32 بعد الإنجازات لبعض الأنشطة ", "32 وضعية التنفيد لهدا الإنجاز", "32 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 20, 2024, "19 التأثير لهدا الإنجاز", 14, "19 بعد الإنجازات لبعض الأنشطة ", "19 وضعية التنفيد لهدا الإنجاز", "19 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 35, 2020, "34 التأثير لهدا الإنجاز", 41, "34 بعد الإنجازات لبعض الأنشطة ", "34 وضعية التنفيد لهدا الإنجاز", "34 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 42, 2019, "41 التأثير لهدا الإنجاز", 41, "41 بعد الإنجازات لبعض الأنشطة ", "41 وضعية التنفيد لهدا الإنجاز", "41 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 5, 2022, "4 التأثير لهدا الإنجاز", 45, "4 بعد الإنجازات لبعض الأنشطة ", "4 وضعية التنفيد لهدا الإنجاز", "4 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 48, 2018, "47 التأثير لهدا الإنجاز", 49, "47 بعد الإنجازات لبعض الأنشطة ", "47 وضعية التنفيد لهدا الإنجاز", "47 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 8, 2029, "7 التأثير لهدا الإنجاز", 3, "7 بعد الإنجازات لبعض الأنشطة ", "7 وضعية التنفيد لهدا الإنجاز", "7 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 31, 2020, "30 التأثير لهدا الإنجاز", 35, "30 بعد الإنجازات لبعض الأنشطة ", "30 وضعية التنفيد لهدا الإنجاز", "30 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 18, 2026, "17 التأثير لهدا الإنجاز", 7, "17 بعد الإنجازات لبعض الأنشطة ", "17 وضعية التنفيد لهدا الإنجاز", "17 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 6, 2024, "5 التأثير لهدا الإنجاز", 33, "5 بعد الإنجازات لبعض الأنشطة ", "5 وضعية التنفيد لهدا الإنجاز", "5 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 25, 2022, "24 التأثير لهدا الإنجاز", 33, "24 بعد الإنجازات لبعض الأنشطة ", "24 وضعية التنفيد لهدا الإنجاز", "24 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 43, 2027, "42 التأثير لهدا الإنجاز", 33, "42 بعد الإنجازات لبعض الأنشطة ", "42 وضعية التنفيد لهدا الإنجاز", "42 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 46, 2026, "45 التأثير لهدا الإنجاز", 32, "45 بعد الإنجازات لبعض الأنشطة ", "45 وضعية التنفيد لهدا الإنجاز", "45 معدل الإنجاز لهدا الإنجاز" });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[] { 38, 2020, "37 التأثير لهدا الإنجاز", 38, "37 بعد الإنجازات لبعض الأنشطة ", "37 وضعية التنفيد لهدا الإنجاز", "37 معدل الإنجاز لهدا الإنجاز" });

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

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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                values: new object[,]
                {
                    { 1, "الديمقراطية والحكامة" },
                    { 2, "الحقــوق الاقتصاديــة والاجتماعيــة والثقافيــة والبيئيــة" },
                    { 3, "حماية الحقوق الفئوية والنهوض بها" },
                    { 4, "الإطار القانوني والمؤسساتي" }
                });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[,]
                {
                    { 20, new DateTime(2020, 10, 9, 20, 35, 58, 71, DateTimeKind.Local).AddTicks(7704), "محضر رقم 20", "اللجنة رقم 20" },
                    { 19, new DateTime(2020, 3, 16, 9, 5, 32, 63, DateTimeKind.Local).AddTicks(3761), "محضر رقم 19", "اللجنة رقم 19" },
                    { 18, new DateTime(2020, 9, 20, 11, 29, 47, 555, DateTimeKind.Local).AddTicks(362), "محضر رقم 18", "اللجنة رقم 18" },
                    { 17, new DateTime(2020, 11, 24, 15, 15, 33, 740, DateTimeKind.Local).AddTicks(1471), "محضر رقم 17", "اللجنة رقم 17" },
                    { 16, new DateTime(2020, 2, 7, 12, 51, 45, 193, DateTimeKind.Local).AddTicks(2212), "محضر رقم 16", "اللجنة رقم 16" },
                    { 15, new DateTime(2020, 1, 23, 19, 23, 32, 262, DateTimeKind.Local).AddTicks(4696), "محضر رقم 15", "اللجنة رقم 15" },
                    { 14, new DateTime(2020, 3, 16, 21, 23, 59, 822, DateTimeKind.Local).AddTicks(8278), "محضر رقم 14", "اللجنة رقم 14" },
                    { 13, new DateTime(2020, 6, 6, 19, 48, 24, 985, DateTimeKind.Local).AddTicks(2126), "محضر رقم 13", "اللجنة رقم 13" },
                    { 12, new DateTime(2020, 10, 5, 16, 42, 4, 829, DateTimeKind.Local).AddTicks(2730), "محضر رقم 12", "اللجنة رقم 12" },
                    { 11, new DateTime(2020, 9, 11, 11, 32, 35, 84, DateTimeKind.Local).AddTicks(9), "محضر رقم 11", "اللجنة رقم 11" },
                    { 9, new DateTime(2020, 2, 27, 9, 8, 28, 14, DateTimeKind.Local).AddTicks(1418), "محضر رقم 9", "اللجنة رقم 9" },
                    { 8, new DateTime(2020, 3, 22, 11, 25, 52, 477, DateTimeKind.Local).AddTicks(5745), "محضر رقم 8", "اللجنة رقم 8" },
                    { 7, new DateTime(2020, 2, 11, 5, 50, 1, 122, DateTimeKind.Local).AddTicks(2121), "محضر رقم 7", "اللجنة رقم 7" },
                    { 6, new DateTime(2020, 6, 11, 0, 40, 7, 102, DateTimeKind.Local).AddTicks(5595), "محضر رقم 6", "اللجنة رقم 6" },
                    { 5, new DateTime(2020, 11, 26, 2, 14, 55, 723, DateTimeKind.Local).AddTicks(43), "محضر رقم 5", "اللجنة رقم 5" },
                    { 4, new DateTime(2020, 6, 7, 6, 18, 3, 475, DateTimeKind.Local).AddTicks(5500), "محضر رقم 4", "اللجنة رقم 4" },
                    { 3, new DateTime(2020, 1, 2, 5, 18, 18, 511, DateTimeKind.Local).AddTicks(8109), "محضر رقم 3", "اللجنة رقم 3" },
                    { 2, new DateTime(2020, 1, 19, 1, 38, 7, 372, DateTimeKind.Local).AddTicks(1571), "محضر رقم 2", "اللجنة رقم 2" },
                    { 1, new DateTime(2020, 7, 16, 22, 4, 21, 265, DateTimeKind.Local).AddTicks(4985), "محضر رقم 1", "اللجنة رقم 1" },
                    { 10, new DateTime(2020, 12, 18, 15, 42, 30, 981, DateTimeKind.Local).AddTicks(5871), "محضر رقم 10", "اللجنة رقم 10" }
                });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 4, "2030 - 2035" },
                    { 3, "2026 - 2030" },
                    { 1, "2018 - 2021" },
                    { 2, "2022 - 2025" }
                });

            migrationBuilder.InsertData(
                table: "Indicateurs",
                columns: new[] { "Id", "Nom", "Source" },
                values: new object[,]
                {
                    { 1, " إرتفاع نسبة التسجيل والتصويت", "غير معروف" },
                    { 2, "التعبير عن الرضا بخصوص تدبير العملية الإنتخابية من قبل عموم المعنيين والملاحظين ", "غير معروف" },
                    { 3, "إرتفاع نسب التمثيلية", "غير معروف" },
                    { 4, "النشر في الجريدة الرسمية", "غير معروف" },
                    { 5, "تنصيب رئيس واعضاء الهيئة ", "غير معروف" },
                    { 6, "عدد عمليات التشاور العمومي", "غير معروف" }
                });

            migrationBuilder.InsertData(
                table: "Natures",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 3, "تقوية القدرات" },
                    { 1, "الجانب التشريعي والمؤسساتي" },
                    { 2, "التواصل والتحسيس" }
                });

            migrationBuilder.InsertData(
                table: "Organismes",
                columns: new[] { "Id", "Adresse", "Label", "Tel", "Type" },
                values: new object[,]
                {
                    { 7, null, "وزارة الداخلية", null, 1 },
                    { 6, null, "جمعيات المجتمع المدني", null, 3 },
                    { 5, null, "الهيئات السياسية ", null, 3 },
                    { 2, null, "وزارة العدل", null, 1 },
                    { 3, null, "المجلس الأعلى للسلطة القضائية ", null, 1 },
                    { 1, null, "وزارة الدولة المكلفة بحقوق الإنسان", null, 1 },
                    { 8, null, "الجمعيات الترابية", null, 2 },
                    { 4, null, "المجلس الوطني لحقوق الإنسان", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Profils",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 3, "لجنة الوطنية" },
                    { 4, "لجنة التتبع" },
                    { 1, "مدير" },
                    { 2, "مشرف" },
                    { 5, "المخاطب الرئيسي" }
                });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[,]
                {
                    { 12, "Quentin.Marty@gmail.com", 12, "Romain Gautier" },
                    { 18, "Pauline_Leclercq@hotmail.fr", 18, "Lucie Renaud" },
                    { 17, "Tom40@hotmail.fr", 17, "Louise Renault" },
                    { 16, "Pierre31@yahoo.fr", 16, "Lisa Jean" },
                    { 15, "Mohamed.Garcia@yahoo.fr", 15, "Nicolas Roche" },
                    { 14, "Jade.Charpentier@hotmail.fr", 14, "Noa Marie" },
                    { 13, "Charlotte_Paris@yahoo.fr", 13, "Jeanne Schmitt" },
                    { 1, "Lea_Simon@gmail.com", 1, "Lucas Jean" },
                    { 2, "Noa.Lecomte66@yahoo.fr", 2, "Baptiste Giraud" },
                    { 3, "Nathan39@yahoo.fr", 3, "Lena Carre" },
                    { 4, "Alice.Renard@hotmail.fr", 4, "Ethan Benoit" },
                    { 5, "Oceane.Renard@gmail.com", 5, "Axel Charpentier" },
                    { 6, "Lea.Martin24@yahoo.fr", 6, "Clémence Blanchard" },
                    { 7, "Adam94@yahoo.fr", 7, "Marie Colin" },
                    { 8, "Mathis37@gmail.com", 8, "Victor Rousseau" },
                    { 9, "Matheo70@gmail.com", 9, "Lilou Fournier" },
                    { 19, "Matteo_Marie98@hotmail.fr", 19, "Thomas Carpentier" },
                    { 10, "Louise46@gmail.com", 10, "Noah Morel" },
                    { 20, "Lina6@hotmail.fr", 20, "Manon Aubry" },
                    { 11, "Clara14@yahoo.fr", 11, "Alexandre Fernandez" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[,]
                {
                    { 7, "Consultation", 5, "suivi-indicateur", "rapport-qualitative" },
                    { 6, "Consultation", 5, "rapport-qualitative", "rapport-qualitative" },
                    { 5, "Consultation", 5, "rapport-litteraire", "rapport-litteraire" },
                    { 4, "Modification", 5, "suivi", "suivi" },
                    { 3, "Consultation", 5, "mesure-programme", "mesure-programme" },
                    { 2, "Consultation", 5, "mesure-region", "mesure-region" },
                    { 1, "Consultation", 5, "mesure-executif", "mesure-executif" },
                    { 9, "Modification", 4, "commission", "commission" },
                    { 8, "Modification", 3, "commission", "commission" },
                    { 17, "Modification", 2, "suivi-indicateur", "suivi-indicateur" },
                    { 16, "Modification", 2, "commission", "commission" },
                    { 15, "Modification", 2, "rapport-qualitative", "rapport-qualitative" },
                    { 14, "Modification", 2, "rapport-litteraire", "rapport-litteraire" },
                    { 13, "Modification", 2, "suivi", "suivi" },
                    { 12, "Modification", 2, "mesure-programme", "mesure-programme" },
                    { 10, "Modification", 2, "mesure-executif", "mesure-executif" },
                    { 11, "Modification", 2, "mesure-region", "mesure-region" }
                });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[,]
                {
                    { 1, 1, "المشاركة السياسية " },
                    { 26, 4, "الحقوق والحريات والآليات المؤسساتية " },
                    { 2, 1, "المساواة والمناصفة وتكافؤ الفرص " },
                    { 3, 1, " الحكامة الترابية " },
                    { 4, 1, "الحكامة الإدارية والنزاهة والشفافية ومكافحة الفساد " },
                    { 5, 1, "الحكامة الأمنية " },
                    { 6, 1, " حريات الاجتماع والتجمع والتظاهر السلمي وتأسيس الجمعيات " },
                    { 7, 1, " مكافحة الإفلات من العقاب" },
                    { 8, 2, " جودة المنظومة الوطنية للتربية والتكوين والبحث العلمي " },
                    { 9, 2, "الحقوق الثقافية " },
                    { 11, 2, " الشغل وتكريس المساواة " },
                    { 12, 2, " السياسة السكنية " },
                    { 13, 2, "السياسة البيئية المندمجة " },
                    { 14, 2, " المقاولة وحقوق الإنسان " },
                    { 10, 2, " الولوج إلى الخدمات الصحية " },
                    { 16, 3, " حقوق الطفل " },
                    { 25, 4, " حفظ الأرشيف وصيانته " },
                    { 24, 4, "حماية التراث الثقافي " },
                    { 23, 4, "حريات التعبير والإعلام والصحافة والحق في المعلومة " },
                    { 15, 3, " الأبعاد المؤسساتية والتشريعية " },
                    { 21, 4, " الحماية القانونية والقضائية لحقوق الإنسان " },
                    { 20, 3, "حقوق المهاجرين واللاجئين " },
                    { 19, 3, " حقوق الأشخاص المسنين " },
                    { 22, 4, " الحماية القانونية والمؤسساتية لحقوق المرأة " },
                    { 18, 3, " حقوق الأشخاص في وضعية إعاقة " },
                    { 17, 3, "حقوق الشباب " }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[,]
                {
                    { 1, true, "Temara", "mourabit@angular.io", "05 ## ## ## ##", 1, 1, "mourabit", "123", "mohamed", "06 ## ## ## ##", "mourabit" },
                    { 4, true, "Temara", "soufiane@angular.io", "05 ## ## ## ##", 7, 3, "soufiane", "123", "soufiane", "06 ## ## ## ##", "soufiane" },
                    { 11, true, "taza", "fakri-11@angular.io", "05 ## ## ## ##", 7, 5, "fakri-11", "123", "mohamed", "06 ## ## ## ##", "fakri-11" },
                    { 2, true, "Temara", "mehdi@angular.io", "05 ## ## ## ##", 8, 2, "mehdi", "123", "mehdi", "06 ## ## ## ##", "mehdi" },
                    { 5, true, "taza", "fakri-5@angular.io", "05 ## ## ## ##", 1, 5, "fakri-5", "123", "mohamed", "06 ## ## ## ##", "fakri-5" },
                    { 6, true, "taza", "fakri-6@angular.io", "05 ## ## ## ##", 2, 5, "fakri-6", "123", "mohamed", "06 ## ## ## ##", "fakri-6" },
                    { 7, true, "taza", "fakri-7@angular.io", "05 ## ## ## ##", 3, 5, "fakri-7", "123", "mohamed", "06 ## ## ## ##", "fakri-7" },
                    { 8, true, "taza", "fakri-8@angular.io", "05 ## ## ## ##", 4, 5, "fakri-8", "123", "mohamed", "06 ## ## ## ##", "fakri-8" },
                    { 9, true, "taza", "fakri-9@angular.io", "05 ## ## ## ##", 5, 5, "fakri-9", "123", "mohamed", "06 ## ## ## ##", "fakri-9" },
                    { 10, true, "taza", "fakri-10@angular.io", "05 ## ## ## ##", 6, 5, "fakri-10", "123", "mohamed", "06 ## ## ## ##", "fakri-10" },
                    { 3, true, "Temara", "ahmed@angular.io", "05 ## ## ## ##", 5, 4, "ahmed", "123", "ahmed", "06 ## ## ## ##", "ahmed" },
                    { 12, true, "taza", "fakri-12@angular.io", "05 ## ## ## ##", 8, 5, "fakri-12", "123", "mohamed", "06 ## ## ## ##", "fakri-12" }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[,]
                {
                    { 2, "Code : {id - 1}", 4, 3, 1, 5, 26, 1, "2 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 2", "بعد الأهداف الخاصة : 2", "بعد النتائج المرتقبة : 2" },
                    { 3, "Code : {id - 1}", 4, 3, 2, 9, 1, 1, "3 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 3", "بعد الأهداف الخاصة : 3", "بعد النتائج المرتقبة : 3" },
                    { 6, "Code : {id - 1}", 4, 2, 1, 9, 18, 3, "6 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 6", "بعد الأهداف الخاصة : 6", "بعد النتائج المرتقبة : 6" },
                    { 9, "Code : {id - 1}", 4, 2, 1, 9, 14, 2, "9 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 9", "بعد الأهداف الخاصة : 9", "بعد النتائج المرتقبة : 9" },
                    { 12, "Code : {id - 1}", 1, 1, 1, 9, 19, 2, "12 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 12", "بعد الأهداف الخاصة : 12", "بعد النتائج المرتقبة : 12" },
                    { 16, "Code : {id - 1}", 3, 1, 1, 9, 20, 3, "16 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 16", "بعد الأهداف الخاصة : 16", "بعد النتائج المرتقبة : 16" },
                    { 41, "Code : {id - 1}", 1, 3, 2, 9, 3, 2, "41 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 41", "بعد الأهداف الخاصة : 41", "بعد النتائج المرتقبة : 41" },
                    { 4, "Code : {id - 1}", 2, 2, 2, 10, 12, 1, "4 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 4", "بعد الأهداف الخاصة : 4", "بعد النتائج المرتقبة : 4" },
                    { 10, "Code : {id - 1}", 2, 3, 3, 10, 11, 2, "10 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 10", "بعد الأهداف الخاصة : 10", "بعد النتائج المرتقبة : 10" },
                    { 23, "Code : {id - 1}", 1, 1, 2, 10, 17, 2, "23 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 23", "بعد الأهداف الخاصة : 23", "بعد النتائج المرتقبة : 23" },
                    { 26, "Code : {id - 1}", 2, 3, 2, 10, 13, 2, "26 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 26", "بعد الأهداف الخاصة : 26", "بعد النتائج المرتقبة : 26" },
                    { 1, "Code : {id - 1}", 4, 1, 3, 11, 2, 1, "1 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 1", "بعد الأهداف الخاصة : 1", "بعد النتائج المرتقبة : 1" },
                    { 21, "Code : {id - 1}", 2, 3, 2, 11, 6, 1, "21 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 21", "بعد الأهداف الخاصة : 21", "بعد النتائج المرتقبة : 21" },
                    { 27, "Code : {id - 1}", 1, 3, 1, 11, 5, 1, "27 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 27", "بعد الأهداف الخاصة : 27", "بعد النتائج المرتقبة : 27" },
                    { 30, "Code : {id - 1}", 3, 1, 3, 11, 8, 3, "30 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 30", "بعد الأهداف الخاصة : 30", "بعد النتائج المرتقبة : 30" },
                    { 31, "Code : {id - 1}", 1, 3, 3, 11, 23, 3, "31 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 31", "بعد الأهداف الخاصة : 31", "بعد النتائج المرتقبة : 31" },
                    { 33, "Code : {id - 1}", 3, 1, 3, 11, 18, 2, "33 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 33", "بعد الأهداف الخاصة : 33", "بعد النتائج المرتقبة : 33" },
                    { 44, "Code : {id - 1}", 4, 3, 3, 11, 18, 3, "44 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 44", "بعد الأهداف الخاصة : 44", "بعد النتائج المرتقبة : 44" },
                    { 50, "Code : {id - 1}", 4, 3, 2, 11, 9, 3, "50 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 50", "بعد الأهداف الخاصة : 50", "بعد النتائج المرتقبة : 50" },
                    { 18, "Code : {id - 1}", 3, 2, 1, 12, 15, 1, "18 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 18", "بعد الأهداف الخاصة : 18", "بعد النتائج المرتقبة : 18" },
                    { 29, "Code : {id - 1}", 4, 2, 2, 12, 3, 2, "29 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 29", "بعد الأهداف الخاصة : 29", "بعد النتائج المرتقبة : 29" },
                    { 32, "Code : {id - 1}", 4, 2, 2, 12, 15, 1, "32 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 32", "بعد الأهداف الخاصة : 32", "بعد النتائج المرتقبة : 32" },
                    { 46, "Code : {id - 1}", 3, 2, 1, 8, 15, 2, "46 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 46", "بعد الأهداف الخاصة : 46", "بعد النتائج المرتقبة : 46" },
                    { 43, "Code : {id - 1}", 2, 1, 3, 8, 25, 3, "43 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 43", "بعد الأهداف الخاصة : 43", "بعد النتائج المرتقبة : 43" },
                    { 35, "Code : {id - 1}", 2, 3, 3, 8, 18, 1, "35 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 35", "بعد الأهداف الخاصة : 35", "بعد النتائج المرتقبة : 35" },
                    { 24, "Code : {id - 1}", 4, 1, 1, 8, 5, 3, "24 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 24", "بعد الأهداف الخاصة : 24", "بعد النتائج المرتقبة : 24" },
                    { 11, "Code : {id - 1}", 4, 1, 1, 5, 2, 2, "11 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 11", "بعد الأهداف الخاصة : 11", "بعد النتائج المرتقبة : 11" },
                    { 19, "Code : {id - 1}", 3, 3, 2, 5, 22, 2, "19 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 19", "بعد الأهداف الخاصة : 19", "بعد النتائج المرتقبة : 19" },
                    { 20, "Code : {id - 1}", 3, 1, 2, 5, 10, 2, "20 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 20", "بعد الأهداف الخاصة : 20", "بعد النتائج المرتقبة : 20" },
                    { 25, "Code : {id - 1}", 3, 1, 1, 5, 26, 1, "25 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 25", "بعد الأهداف الخاصة : 25", "بعد النتائج المرتقبة : 25" },
                    { 39, "Code : {id - 1}", 3, 3, 3, 5, 20, 3, "39 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 39", "بعد الأهداف الخاصة : 39", "بعد النتائج المرتقبة : 39" },
                    { 45, "Code : {id - 1}", 1, 3, 1, 5, 25, 1, "45 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 45", "بعد الأهداف الخاصة : 45", "بعد النتائج المرتقبة : 45" },
                    { 8, "Code : {id - 1}", 4, 1, 1, 6, 19, 2, "8 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 8", "بعد الأهداف الخاصة : 8", "بعد النتائج المرتقبة : 8" },
                    { 22, "Code : {id - 1}", 1, 2, 2, 6, 13, 3, "22 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 22", "بعد الأهداف الخاصة : 22", "بعد النتائج المرتقبة : 22" },
                    { 28, "Code : {id - 1}", 3, 2, 1, 6, 1, 3, "28 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 28", "بعد الأهداف الخاصة : 28", "بعد النتائج المرتقبة : 28" },
                    { 34, "Code : {id - 1}", 3, 2, 1, 6, 10, 2, "34 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 34", "بعد الأهداف الخاصة : 34", "بعد النتائج المرتقبة : 34" },
                    { 36, "Code : {id - 1}", 4, 2, 3, 12, 6, 3, "36 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 36", "بعد الأهداف الخاصة : 36", "بعد النتائج المرتقبة : 36" },
                    { 37, "Code : {id - 1}", 1, 3, 2, 6, 26, 1, "37 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 37", "بعد الأهداف الخاصة : 37", "بعد النتائج المرتقبة : 37" },
                    { 48, "Code : {id - 1}", 3, 3, 2, 6, 17, 1, "48 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 48", "بعد الأهداف الخاصة : 48", "بعد النتائج المرتقبة : 48" },
                    { 5, "Code : {id - 1}", 2, 1, 3, 7, 26, 1, "5 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 5", "بعد الأهداف الخاصة : 5", "بعد النتائج المرتقبة : 5" },
                    { 13, "Code : {id - 1}", 3, 1, 2, 7, 11, 1, "13 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 13", "بعد الأهداف الخاصة : 13", "بعد النتائج المرتقبة : 13" },
                    { 40, "Code : {id - 1}", 2, 2, 2, 7, 21, 1, "40 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 40", "بعد الأهداف الخاصة : 40", "بعد النتائج المرتقبة : 40" },
                    { 42, "Code : {id - 1}", 2, 2, 1, 7, 21, 2, "42 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 42", "بعد الأهداف الخاصة : 42", "بعد النتائج المرتقبة : 42" },
                    { 49, "Code : {id - 1}", 2, 1, 3, 7, 17, 2, "49 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 49", "بعد الأهداف الخاصة : 49", "بعد النتائج المرتقبة : 49" },
                    { 7, "Code : {id - 1}", 3, 1, 3, 8, 20, 1, "7 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 7", "بعد الأهداف الخاصة : 7", "بعد النتائج المرتقبة : 7" },
                    { 14, "Code : {id - 1}", 1, 2, 2, 8, 9, 2, "14 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 14", "بعد الأهداف الخاصة : 14", "بعد النتائج المرتقبة : 14" },
                    { 15, "Code : {id - 1}", 1, 1, 3, 8, 18, 3, "15 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 15", "بعد الأهداف الخاصة : 15", "بعد النتائج المرتقبة : 15" },
                    { 17, "Code : {id - 1}", 1, 1, 2, 8, 20, 1, "17 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 17", "بعد الأهداف الخاصة : 17", "بعد النتائج المرتقبة : 17" },
                    { 47, "Code : {id - 1}", 1, 3, 1, 6, 26, 2, "47 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 47", "بعد الأهداف الخاصة : 47", "بعد النتائج المرتقبة : 47" },
                    { 38, "Code : {id - 1}", 3, 2, 2, 12, 13, 1, "38 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 38", "بعد الأهداف الخاصة : 38", "بعد النتائج المرتقبة : 38" }
                });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[,]
                {
                    { 44, "[\"2018\", \"2019\", \"2020\"]", 49, "43 بعد الأنشطة لبعض التدابير" },
                    { 7, "[\"2023\", \"2024\", \"2025\"]", 39, "6 بعد الأنشطة لبعض التدابير" },
                    { 21, "[\"2020\", \"2021\", \"2022\"]", 39, "20 بعد الأنشطة لبعض التدابير" },
                    { 29, "[\"2020\", \"2021\", \"2022\"]", 39, "28 بعد الأنشطة لبعض التدابير" },
                    { 11, "[\"2019\", \"2020\", \"2021\"]", 30, "10 بعد الأنشطة لبعض التدابير" },
                    { 6, "[\"2023\", \"2024\", \"2025\"]", 43, "5 بعد الأنشطة لبعض التدابير" },
                    { 14, "[\"2022\", \"2023\", \"2024\"]", 44, "13 بعد الأنشطة لبعض التدابير" },
                    { 40, "[\"2026\", \"2027\", \"2028\"]", 17, "39 بعد الأنشطة لبعض التدابير" },
                    { 43, "[\"2022\", \"2023\", \"2024\"]", 45, "42 بعد الأنشطة لبعض التدابير" },
                    { 28, "[\"2024\", \"2025\", \"2026\"]", 46, "27 بعد الأنشطة لبعض التدابير" },
                    { 3, "[\"2020\", \"2021\", \"2022\"]", 3, "2 بعد الأنشطة لبعض التدابير" },
                    { 1, "[\"2023\", \"2024\", \"2025\"]", 33, "0 بعد الأنشطة لبعض التدابير" },
                    { 5, "[\"2029\", \"2030\", \"2031\"]", 14, "4 بعد الأنشطة لبعض التدابير" },
                    { 50, "[\"2019\", \"2020\", \"2021\"]", 31, "49 بعد الأنشطة لبعض التدابير" },
                    { 19, "[\"2029\", \"2030\", \"2031\"]", 49, "18 بعد الأنشطة لبعض التدابير" },
                    { 47, "[\"2023\", \"2024\", \"2025\"]", 37, "46 بعد الأنشطة لبعض التدابير" },
                    { 15, "[\"2026\", \"2027\", \"2028\"]", 37, "14 بعد الأنشطة لبعض التدابير" },
                    { 9, "[\"2023\", \"2024\", \"2025\"]", 27, "8 بعد الأنشطة لبعض التدابير" },
                    { 16, "[\"2020\", \"2021\", \"2022\"]", 9, "15 بعد الأنشطة لبعض التدابير" },
                    { 17, "[\"2021\", \"2022\", \"2023\"]", 28, "16 بعد الأنشطة لبعض التدابير" },
                    { 10, "[\"2020\", \"2021\", \"2022\"]", 27, "9 بعد الأنشطة لبعض التدابير" },
                    { 45, "[\"2018\", \"2019\", \"2020\"]", 30, "44 بعد الأنشطة لبعض التدابير" },
                    { 31, "[\"2026\", \"2027\", \"2028\"]", 30, "30 بعد الأنشطة لبعض التدابير" },
                    { 35, "[\"2021\", \"2022\", \"2023\"]", 34, "34 بعد الأنشطة لبعض التدابير" },
                    { 12, "[\"2023\", \"2024\", \"2025\"]", 30, "11 بعد الأنشطة لبعض التدابير" },
                    { 48, "[\"2028\", \"2029\", \"2030\"]", 31, "47 بعد الأنشطة لبعض التدابير" },
                    { 33, "[\"2018\", \"2019\", \"2020\"]", 14, "32 بعد الأنشطة لبعض التدابير" },
                    { 2, "[\"2022\", \"2023\", \"2024\"]", 14, "1 بعد الأنشطة لبعض التدابير" },
                    { 20, "[\"2029\", \"2030\", \"2031\"]", 26, "19 بعد الأنشطة لبعض التدابير" },
                    { 41, "[\"2027\", \"2028\", \"2029\"]", 5, "40 بعد الأنشطة لبعض التدابير" },
                    { 22, "[\"2023\", \"2024\", \"2025\"]", 10, "21 بعد الأنشطة لبعض التدابير" },
                    { 46, "[\"2018\", \"2019\", \"2020\"]", 10, "45 بعد الأنشطة لبعض التدابير" },
                    { 4, "[\"2023\", \"2024\", \"2025\"]", 11, "3 بعد الأنشطة لبعض التدابير" },
                    { 32, "[\"2023\", \"2024\", \"2025\"]", 11, "31 بعد الأنشطة لبعض التدابير" },
                    { 8, "[\"2029\", \"2030\", \"2031\"]", 24, "7 بعد الأنشطة لبعض التدابير" },
                    { 36, "[\"2024\", \"2025\", \"2026\"]", 24, "35 بعد الأنشطة لبعض التدابير" },
                    { 49, "[\"2021\", \"2022\", \"2023\"]", 15, "48 بعد الأنشطة لبعض التدابير" },
                    { 24, "[\"2019\", \"2020\", \"2021\"]", 15, "23 بعد الأنشطة لبعض التدابير" },
                    { 18, "[\"2023\", \"2024\", \"2025\"]", 13, "17 بعد الأنشطة لبعض التدابير" },
                    { 30, "[\"2023\", \"2024\", \"2025\"]", 13, "29 بعد الأنشطة لبعض التدابير" },
                    { 39, "[\"2019\", \"2020\", \"2021\"]", 14, "38 بعد الأنشطة لبعض التدابير" },
                    { 23, "[\"2028\", \"2029\", \"2030\"]", 23, "22 بعد الأنشطة لبعض التدابير" },
                    { 26, "[\"2022\", \"2023\", \"2024\"]", 19, "25 بعد الأنشطة لبعض التدابير" },
                    { 42, "[\"2018\", \"2019\", \"2020\"]", 20, "41 بعد الأنشطة لبعض التدابير" },
                    { 25, "[\"2027\", \"2028\", \"2029\"]", 18, "24 بعد الأنشطة لبعض التدابير" },
                    { 27, "[\"2019\", \"2020\", \"2021\"]", 18, "26 بعد الأنشطة لبعض التدابير" },
                    { 38, "[\"2022\", \"2023\", \"2024\"]", 18, "37 بعد الأنشطة لبعض التدابير" },
                    { 34, "[\"2024\", \"2025\", \"2026\"]", 48, "33 بعد الأنشطة لبعض التدابير" },
                    { 13, "[\"2027\", \"2028\", \"2029\"]", 48, "12 بعد الأنشطة لبعض التدابير" },
                    { 37, "[\"2024\", \"2025\", \"2026\"]", 35, "36 بعد الأنشطة لبعض التدابير" }
                });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[,]
                {
                    { 36, new DateTime(2020, 5, 24, 19, 37, 56, 870, DateTimeKind.Local).AddTicks(7653), 1, 41, "45" },
                    { 90, new DateTime(2020, 3, 21, 22, 21, 19, 950, DateTimeKind.Local).AddTicks(4077), 4, 12, "43" },
                    { 131, new DateTime(2020, 1, 3, 7, 28, 24, 605, DateTimeKind.Local).AddTicks(2510), 4, 12, "36" },
                    { 13, new DateTime(2020, 12, 26, 6, 11, 8, 310, DateTimeKind.Local).AddTicks(3803), 2, 41, "49" },
                    { 179, new DateTime(2020, 5, 4, 22, 49, 52, 344, DateTimeKind.Local).AddTicks(4195), 1, 16, "64" },
                    { 28, new DateTime(2020, 5, 29, 9, 59, 23, 40, DateTimeKind.Local).AddTicks(7326), 4, 16, "35" },
                    { 59, new DateTime(2020, 5, 15, 3, 9, 45, 294, DateTimeKind.Local).AddTicks(3298), 4, 16, "20" },
                    { 121, new DateTime(2020, 6, 13, 5, 0, 19, 288, DateTimeKind.Local).AddTicks(5650), 3, 16, "48" },
                    { 198, new DateTime(2020, 9, 14, 18, 18, 1, 164, DateTimeKind.Local).AddTicks(2868), 6, 16, "75" },
                    { 178, new DateTime(2020, 7, 4, 15, 4, 49, 804, DateTimeKind.Local).AddTicks(8240), 2, 12, "54" },
                    { 77, new DateTime(2020, 8, 17, 3, 44, 39, 796, DateTimeKind.Local).AddTicks(9914), 2, 16, "32" },
                    { 196, new DateTime(2020, 4, 19, 10, 56, 27, 435, DateTimeKind.Local).AddTicks(3566), 2, 12, "94" },
                    { 15, new DateTime(2020, 11, 5, 20, 0, 41, 766, DateTimeKind.Local).AddTicks(5612), 6, 16, "73" },
                    { 122, new DateTime(2020, 12, 9, 7, 23, 23, 405, DateTimeKind.Local).AddTicks(4764), 1, 16, "64" },
                    { 9, new DateTime(2020, 6, 22, 9, 22, 13, 40, DateTimeKind.Local).AddTicks(330), 4, 12, "63" },
                    { 138, new DateTime(2020, 10, 9, 15, 27, 47, 670, DateTimeKind.Local).AddTicks(3343), 4, 24, "15" },
                    { 94, new DateTime(2020, 5, 24, 21, 32, 31, 124, DateTimeKind.Local).AddTicks(8521), 1, 9, "84" },
                    { 61, new DateTime(2020, 3, 10, 6, 53, 12, 520, DateTimeKind.Local).AddTicks(3472), 2, 17, "72" },
                    { 123, new DateTime(2020, 1, 4, 14, 22, 51, 5, DateTimeKind.Local).AddTicks(7712), 4, 17, "70" },
                    { 150, new DateTime(2020, 7, 11, 16, 10, 56, 548, DateTimeKind.Local).AddTicks(7496), 3, 17, "74" },
                    { 185, new DateTime(2020, 7, 2, 5, 39, 51, 693, DateTimeKind.Local).AddTicks(2801), 4, 17, "30" },
                    { 200, new DateTime(2020, 9, 27, 13, 35, 58, 382, DateTimeKind.Local).AddTicks(6431), 3, 17, "99" },
                    { 7, new DateTime(2020, 8, 30, 3, 51, 6, 549, DateTimeKind.Local).AddTicks(4704), 3, 24, "77" },
                    { 29, new DateTime(2020, 8, 27, 0, 53, 15, 796, DateTimeKind.Local).AddTicks(3604), 1, 24, "96" },
                    { 103, new DateTime(2020, 5, 1, 4, 40, 27, 160, DateTimeKind.Local).AddTicks(1282), 5, 24, "82" },
                    { 113, new DateTime(2020, 8, 26, 0, 35, 51, 279, DateTimeKind.Local).AddTicks(6758), 2, 38, "20" },
                    { 152, new DateTime(2020, 6, 23, 0, 44, 46, 871, DateTimeKind.Local).AddTicks(3797), 4, 24, "56" },
                    { 190, new DateTime(2020, 10, 29, 19, 2, 4, 851, DateTimeKind.Local).AddTicks(9401), 1, 24, "69" },
                    { 137, new DateTime(2020, 10, 13, 5, 15, 1, 463, DateTimeKind.Local).AddTicks(3017), 2, 35, "40" },
                    { 176, new DateTime(2020, 8, 23, 5, 48, 56, 571, DateTimeKind.Local).AddTicks(330), 2, 35, "85" },
                    { 182, new DateTime(2020, 4, 7, 18, 32, 39, 211, DateTimeKind.Local).AddTicks(3452), 3, 35, "39" },
                    { 17, new DateTime(2020, 10, 13, 7, 28, 55, 852, DateTimeKind.Local).AddTicks(3155), 2, 43, "77" },
                    { 108, new DateTime(2020, 1, 8, 19, 52, 15, 7, DateTimeKind.Local).AddTicks(485), 3, 43, "47" },
                    { 40, new DateTime(2020, 5, 5, 12, 19, 23, 940, DateTimeKind.Local).AddTicks(2510), 6, 46, "65" },
                    { 160, new DateTime(2020, 5, 2, 4, 59, 22, 267, DateTimeKind.Local).AddTicks(276), 4, 46, "47" },
                    { 33, new DateTime(2020, 12, 4, 5, 21, 27, 366, DateTimeKind.Local).AddTicks(4189), 1, 3, "19" },
                    { 81, new DateTime(2020, 8, 25, 23, 6, 25, 31, DateTimeKind.Local).AddTicks(6528), 1, 3, "62" },
                    { 174, new DateTime(2020, 4, 20, 21, 14, 43, 529, DateTimeKind.Local).AddTicks(5962), 3, 3, "86" },
                    { 166, new DateTime(2020, 2, 18, 16, 13, 38, 937, DateTimeKind.Local).AddTicks(58), 6, 41, "30" },
                    { 72, new DateTime(2020, 12, 25, 3, 27, 23, 419, DateTimeKind.Local).AddTicks(5908), 3, 6, "84" },
                    { 115, new DateTime(2020, 8, 18, 18, 25, 18, 562, DateTimeKind.Local).AddTicks(1559), 6, 6, "68" },
                    { 169, new DateTime(2020, 6, 20, 19, 36, 39, 624, DateTimeKind.Local).AddTicks(9561), 5, 6, "50" },
                    { 20, new DateTime(2020, 4, 21, 9, 6, 28, 658, DateTimeKind.Local).AddTicks(296), 5, 9, "54" },
                    { 52, new DateTime(2020, 9, 24, 0, 2, 34, 126, DateTimeKind.Local).AddTicks(2750), 4, 9, "32" },
                    { 100, new DateTime(2020, 9, 12, 13, 16, 12, 5, DateTimeKind.Local).AddTicks(3720), 6, 9, "61" },
                    { 168, new DateTime(2020, 8, 10, 7, 25, 49, 696, DateTimeKind.Local).AddTicks(8174), 2, 41, "91" },
                    { 3, new DateTime(2020, 1, 5, 14, 12, 51, 366, DateTimeKind.Local).AddTicks(139), 6, 26, "35" },
                    { 139, new DateTime(2020, 11, 1, 19, 46, 12, 583, DateTimeKind.Local).AddTicks(9890), 2, 4, "28" },
                    { 153, new DateTime(2020, 6, 11, 11, 22, 50, 674, DateTimeKind.Local).AddTicks(6072), 5, 33, "67" },
                    { 162, new DateTime(2020, 5, 12, 3, 40, 30, 554, DateTimeKind.Local).AddTicks(2072), 4, 33, "11" },
                    { 163, new DateTime(2020, 3, 9, 21, 20, 21, 706, DateTimeKind.Local).AddTicks(3982), 3, 33, "87" },
                    { 186, new DateTime(2020, 5, 3, 12, 5, 15, 751, DateTimeKind.Local).AddTicks(3288), 5, 33, "85" },
                    { 37, new DateTime(2020, 3, 20, 7, 47, 32, 463, DateTimeKind.Local).AddTicks(6403), 4, 44, "79" },
                    { 95, new DateTime(2020, 3, 30, 12, 18, 32, 279, DateTimeKind.Local).AddTicks(4570), 4, 44, "68" },
                    { 141, new DateTime(2020, 5, 4, 6, 2, 37, 406, DateTimeKind.Local).AddTicks(2914), 6, 44, "48" },
                    { 175, new DateTime(2020, 11, 12, 16, 53, 41, 205, DateTimeKind.Local).AddTicks(2885), 4, 44, "46" },
                    { 32, new DateTime(2020, 3, 23, 3, 52, 24, 540, DateTimeKind.Local).AddTicks(351), 2, 50, "27" },
                    { 66, new DateTime(2020, 11, 15, 8, 29, 54, 835, DateTimeKind.Local).AddTicks(1261), 2, 50, "11" },
                    { 128, new DateTime(2020, 8, 26, 22, 54, 22, 980, DateTimeKind.Local).AddTicks(2480), 3, 50, "93" },
                    { 117, new DateTime(2020, 5, 13, 9, 28, 16, 819, DateTimeKind.Local).AddTicks(5124), 5, 18, "69" },
                    { 35, new DateTime(2020, 9, 12, 21, 58, 14, 382, DateTimeKind.Local).AddTicks(223), 6, 29, "97" },
                    { 149, new DateTime(2020, 3, 19, 7, 25, 33, 555, DateTimeKind.Local).AddTicks(2031), 1, 33, "35" },
                    { 73, new DateTime(2020, 9, 9, 1, 52, 56, 89, DateTimeKind.Local).AddTicks(5153), 5, 29, "58" },
                    { 102, new DateTime(2020, 8, 10, 11, 14, 54, 877, DateTimeKind.Local).AddTicks(670), 5, 29, "25" },
                    { 177, new DateTime(2020, 9, 4, 17, 15, 41, 190, DateTimeKind.Local).AddTicks(426), 3, 29, "72" },
                    { 93, new DateTime(2020, 1, 26, 5, 41, 38, 511, DateTimeKind.Local).AddTicks(3690), 4, 32, "17" },
                    { 98, new DateTime(2020, 2, 13, 20, 37, 54, 275, DateTimeKind.Local).AddTicks(7163), 1, 32, "15" },
                    { 54, new DateTime(2020, 2, 20, 9, 31, 38, 801, DateTimeKind.Local).AddTicks(7201), 2, 36, "31" },
                    { 87, new DateTime(2020, 10, 15, 18, 27, 58, 402, DateTimeKind.Local).AddTicks(7696), 3, 36, "12" },
                    { 136, new DateTime(2020, 2, 18, 1, 57, 43, 444, DateTimeKind.Local).AddTicks(3841), 5, 36, "16" },
                    { 144, new DateTime(2020, 7, 8, 4, 4, 8, 521, DateTimeKind.Local).AddTicks(7732), 4, 36, "62" },
                    { 148, new DateTime(2020, 5, 18, 15, 50, 46, 944, DateTimeKind.Local).AddTicks(9298), 2, 36, "15" },
                    { 170, new DateTime(2020, 7, 18, 13, 5, 35, 501, DateTimeKind.Local).AddTicks(2401), 1, 36, "20" },
                    { 22, new DateTime(2020, 4, 14, 10, 53, 8, 662, DateTimeKind.Local).AddTicks(4656), 1, 38, "47" },
                    { 50, new DateTime(2020, 5, 2, 23, 38, 10, 411, DateTimeKind.Local).AddTicks(3409), 1, 38, "24" },
                    { 55, new DateTime(2020, 2, 19, 20, 11, 9, 790, DateTimeKind.Local).AddTicks(309), 2, 38, "55" },
                    { 74, new DateTime(2020, 12, 7, 17, 40, 31, 56, DateTimeKind.Local).AddTicks(318), 6, 29, "28" },
                    { 63, new DateTime(2020, 6, 16, 23, 29, 0, 425, DateTimeKind.Local).AddTicks(7903), 2, 4, "60" },
                    { 129, new DateTime(2020, 6, 7, 13, 4, 27, 219, DateTimeKind.Local).AddTicks(8563), 3, 33, "14" },
                    { 45, new DateTime(2020, 8, 18, 1, 32, 33, 570, DateTimeKind.Local).AddTicks(5372), 3, 33, "28" },
                    { 10, new DateTime(2020, 10, 28, 21, 26, 17, 302, DateTimeKind.Local).AddTicks(958), 3, 10, "20" },
                    { 12, new DateTime(2020, 10, 20, 3, 54, 24, 287, DateTimeKind.Local).AddTicks(3237), 5, 10, "26" },
                    { 21, new DateTime(2020, 3, 19, 1, 27, 25, 709, DateTimeKind.Local).AddTicks(4027), 4, 10, "57" },
                    { 194, new DateTime(2020, 4, 19, 3, 8, 40, 121, DateTimeKind.Local).AddTicks(8006), 3, 10, "64" },
                    { 5, new DateTime(2020, 5, 7, 18, 30, 7, 117, DateTimeKind.Local).AddTicks(584), 6, 23, "54" },
                    { 181, new DateTime(2020, 3, 20, 11, 8, 36, 688, DateTimeKind.Local).AddTicks(8547), 5, 23, "81" },
                    { 2, new DateTime(2020, 12, 20, 17, 1, 21, 960, DateTimeKind.Local).AddTicks(4641), 4, 26, "66" },
                    { 8, new DateTime(2020, 11, 26, 8, 54, 17, 130, DateTimeKind.Local).AddTicks(1926), 2, 1, "17" },
                    { 38, new DateTime(2020, 6, 18, 20, 44, 9, 492, DateTimeKind.Local).AddTicks(2691), 6, 1, "42" },
                    { 60, new DateTime(2020, 10, 13, 18, 20, 18, 34, DateTimeKind.Local).AddTicks(7977), 3, 1, "94" },
                    { 109, new DateTime(2020, 3, 18, 22, 19, 47, 106, DateTimeKind.Local).AddTicks(8557), 3, 1, "11" },
                    { 197, new DateTime(2020, 6, 27, 2, 58, 40, 58, DateTimeKind.Local).AddTicks(3079), 2, 1, "64" },
                    { 46, new DateTime(2020, 11, 20, 9, 41, 12, 818, DateTimeKind.Local).AddTicks(2407), 3, 21, "78" },
                    { 111, new DateTime(2020, 2, 15, 4, 43, 8, 138, DateTimeKind.Local).AddTicks(521), 5, 33, "85" },
                    { 57, new DateTime(2020, 1, 8, 8, 58, 40, 502, DateTimeKind.Local).AddTicks(7734), 1, 21, "57" },
                    { 91, new DateTime(2020, 9, 2, 20, 7, 44, 282, DateTimeKind.Local).AddTicks(4752), 5, 27, "35" },
                    { 96, new DateTime(2020, 7, 20, 12, 43, 39, 258, DateTimeKind.Local).AddTicks(4493), 4, 27, "59" },
                    { 145, new DateTime(2020, 7, 11, 4, 59, 54, 307, DateTimeKind.Local).AddTicks(9723), 3, 27, "36" },
                    { 84, new DateTime(2020, 9, 8, 0, 55, 55, 449, DateTimeKind.Local).AddTicks(8096), 1, 30, "76" },
                    { 107, new DateTime(2020, 10, 28, 3, 4, 8, 565, DateTimeKind.Local).AddTicks(7598), 2, 30, "86" },
                    { 118, new DateTime(2020, 1, 13, 18, 41, 57, 860, DateTimeKind.Local).AddTicks(3772), 3, 30, "14" },
                    { 130, new DateTime(2020, 9, 18, 2, 34, 27, 674, DateTimeKind.Local).AddTicks(9157), 6, 30, "75" },
                    { 154, new DateTime(2020, 3, 11, 7, 4, 9, 245, DateTimeKind.Local).AddTicks(5321), 1, 30, "51" },
                    { 161, new DateTime(2020, 1, 4, 13, 40, 48, 454, DateTimeKind.Local).AddTicks(934), 1, 30, "42" },
                    { 167, new DateTime(2020, 3, 22, 23, 52, 41, 134, DateTimeKind.Local).AddTicks(6410), 4, 30, "85" },
                    { 189, new DateTime(2020, 1, 31, 13, 56, 0, 382, DateTimeKind.Local).AddTicks(1589), 1, 30, "71" },
                    { 156, new DateTime(2020, 3, 25, 19, 34, 55, 800, DateTimeKind.Local).AddTicks(8964), 1, 31, "13" },
                    { 6, new DateTime(2020, 4, 21, 13, 20, 12, 658, DateTimeKind.Local).AddTicks(7439), 4, 33, "18" },
                    { 39, new DateTime(2020, 12, 28, 7, 28, 20, 510, DateTimeKind.Local).AddTicks(8858), 5, 27, "29" },
                    { 49, new DateTime(2020, 9, 6, 21, 12, 3, 295, DateTimeKind.Local).AddTicks(5427), 2, 17, "11" },
                    { 126, new DateTime(2020, 9, 16, 4, 20, 17, 152, DateTimeKind.Local).AddTicks(4482), 2, 38, "89" },
                    { 70, new DateTime(2020, 6, 24, 6, 16, 0, 929, DateTimeKind.Local).AddTicks(3927), 6, 13, "48" },
                    { 110, new DateTime(2020, 12, 21, 19, 9, 31, 870, DateTimeKind.Local).AddTicks(1956), 2, 48, "89" },
                    { 157, new DateTime(2020, 5, 20, 12, 8, 36, 822, DateTimeKind.Local).AddTicks(8193), 3, 48, "82" },
                    { 172, new DateTime(2020, 12, 10, 11, 53, 0, 979, DateTimeKind.Local).AddTicks(2528), 3, 48, "16" },
                    { 180, new DateTime(2020, 9, 30, 17, 24, 8, 490, DateTimeKind.Local).AddTicks(5300), 3, 48, "92" },
                    { 4, new DateTime(2020, 5, 20, 12, 47, 50, 180, DateTimeKind.Local).AddTicks(4841), 5, 39, "75" },
                    { 195, new DateTime(2020, 6, 3, 17, 13, 56, 201, DateTimeKind.Local).AddTicks(9578), 1, 48, "31" },
                    { 199, new DateTime(2020, 4, 22, 12, 43, 7, 843, DateTimeKind.Local).AddTicks(4919), 1, 48, "42" },
                    { 135, new DateTime(2020, 11, 2, 12, 6, 20, 697, DateTimeKind.Local).AddTicks(3858), 1, 25, "36" },
                    { 65, new DateTime(2020, 11, 28, 9, 13, 4, 879, DateTimeKind.Local).AddTicks(4574), 5, 5, "90" },
                    { 82, new DateTime(2020, 7, 22, 22, 14, 12, 989, DateTimeKind.Local).AddTicks(6576), 4, 5, "75" },
                    { 25, new DateTime(2019, 12, 29, 11, 7, 43, 633, DateTimeKind.Local).AddTicks(4192), 1, 39, "57" },
                    { 83, new DateTime(2020, 4, 25, 0, 25, 15, 189, DateTimeKind.Local).AddTicks(5832), 3, 5, "23" },
                    { 120, new DateTime(2020, 10, 22, 20, 38, 15, 216, DateTimeKind.Local).AddTicks(976), 5, 25, "39" },
                    { 85, new DateTime(2020, 2, 22, 6, 23, 41, 301, DateTimeKind.Local).AddTicks(9109), 3, 25, "79" },
                    { 67, new DateTime(2020, 11, 3, 14, 25, 59, 222, DateTimeKind.Local).AddTicks(3323), 6, 25, "20" },
                    { 51, new DateTime(2020, 9, 13, 12, 8, 26, 686, DateTimeKind.Local).AddTicks(1613), 5, 13, "47" },
                    { 58, new DateTime(2020, 7, 5, 7, 29, 13, 976, DateTimeKind.Local).AddTicks(9406), 4, 13, "100" },
                    { 171, new DateTime(2020, 3, 8, 11, 8, 31, 680, DateTimeKind.Local).AddTicks(7949), 2, 22, "97" },
                    { 112, new DateTime(2020, 7, 10, 11, 48, 28, 763, DateTimeKind.Local).AddTicks(1069), 3, 13, "91" },
                    { 127, new DateTime(2020, 2, 22, 10, 25, 56, 481, DateTimeKind.Local).AddTicks(2556), 1, 13, "44" },
                    { 134, new DateTime(2020, 12, 15, 2, 14, 56, 482, DateTimeKind.Local).AddTicks(724), 6, 13, "49" },
                    { 151, new DateTime(2020, 7, 18, 12, 56, 6, 117, DateTimeKind.Local).AddTicks(18), 4, 13, "26" },
                    { 99, new DateTime(2020, 8, 8, 13, 8, 8, 13, DateTimeKind.Local).AddTicks(9917), 6, 5, "38" },
                    { 30, new DateTime(2020, 3, 19, 9, 31, 29, 915, DateTimeKind.Local).AddTicks(9103), 2, 39, "61" },
                    { 53, new DateTime(2020, 7, 25, 4, 14, 46, 213, DateTimeKind.Local).AddTicks(9493), 3, 39, "42" },
                    { 155, new DateTime(2020, 12, 13, 21, 25, 40, 322, DateTimeKind.Local).AddTicks(5338), 4, 47, "44" },
                    { 92, new DateTime(2020, 9, 18, 17, 26, 5, 805, DateTimeKind.Local).AddTicks(7658), 3, 22, "65" },
                    { 42, new DateTime(2020, 1, 5, 16, 46, 29, 818, DateTimeKind.Local).AddTicks(6119), 2, 22, "44" },
                    { 89, new DateTime(2020, 4, 25, 2, 58, 42, 495, DateTimeKind.Local).AddTicks(1082), 2, 28, "43" },
                    { 11, new DateTime(2020, 8, 13, 1, 12, 7, 485, DateTimeKind.Local).AddTicks(1733), 5, 22, "47" },
                    { 165, new DateTime(2020, 12, 18, 21, 56, 57, 237, DateTimeKind.Local).AddTicks(9224), 3, 28, "54" },
                    { 187, new DateTime(2020, 12, 23, 17, 50, 51, 396, DateTimeKind.Local).AddTicks(7429), 1, 28, "26" },
                    { 14, new DateTime(2020, 7, 19, 22, 3, 34, 175, DateTimeKind.Local).AddTicks(1380), 4, 34, "47" },
                    { 56, new DateTime(2020, 4, 11, 20, 8, 16, 366, DateTimeKind.Local).AddTicks(3085), 6, 34, "73" },
                    { 64, new DateTime(2020, 8, 31, 8, 52, 15, 517, DateTimeKind.Local).AddTicks(9373), 2, 34, "98" },
                    { 124, new DateTime(2020, 5, 7, 16, 48, 48, 928, DateTimeKind.Local).AddTicks(9015), 4, 34, "18" },
                    { 142, new DateTime(2020, 3, 30, 13, 21, 53, 637, DateTimeKind.Local).AddTicks(4761), 2, 8, "17" },
                    { 184, new DateTime(2020, 10, 24, 12, 7, 50, 123, DateTimeKind.Local).AddTicks(2134), 6, 34, "79" },
                    { 192, new DateTime(2020, 9, 4, 14, 19, 21, 248, DateTimeKind.Local).AddTicks(3894), 2, 34, "84" },
                    { 23, new DateTime(2020, 10, 3, 9, 43, 51, 463, DateTimeKind.Local).AddTicks(1256), 1, 8, "29" },
                    { 19, new DateTime(2020, 2, 13, 16, 7, 6, 997, DateTimeKind.Local).AddTicks(2688), 2, 37, "29" },
                    { 47, new DateTime(2020, 7, 13, 21, 3, 29, 797, DateTimeKind.Local).AddTicks(1006), 4, 37, "58" },
                    { 101, new DateTime(2020, 10, 4, 15, 6, 49, 940, DateTimeKind.Local).AddTicks(2416), 5, 37, "61" },
                    { 146, new DateTime(2020, 2, 6, 12, 42, 7, 440, DateTimeKind.Local).AddTicks(8423), 1, 37, "100" },
                    { 159, new DateTime(2020, 11, 3, 8, 4, 58, 121, DateTimeKind.Local).AddTicks(9401), 5, 37, "29" },
                    { 183, new DateTime(2020, 10, 17, 14, 53, 23, 116, DateTimeKind.Local).AddTicks(5749), 5, 45, "69" },
                    { 88, new DateTime(2020, 8, 29, 1, 51, 44, 189, DateTimeKind.Local).AddTicks(3219), 4, 45, "72" },
                    { 16, new DateTime(2020, 9, 3, 9, 25, 11, 9, DateTimeKind.Local).AddTicks(3353), 2, 45, "11" },
                    { 116, new DateTime(2020, 12, 16, 19, 48, 32, 480, DateTimeKind.Local).AddTicks(317), 1, 47, "58" },
                    { 24, new DateTime(2020, 11, 11, 1, 21, 38, 941, DateTimeKind.Local).AddTicks(8205), 6, 40, "35" },
                    { 31, new DateTime(2020, 12, 2, 21, 33, 50, 870, DateTimeKind.Local).AddTicks(9495), 1, 40, "16" },
                    { 133, new DateTime(2020, 4, 19, 21, 16, 7, 267, DateTimeKind.Local).AddTicks(5046), 2, 22, "39" },
                    { 68, new DateTime(2020, 9, 10, 19, 28, 23, 145, DateTimeKind.Local).AddTicks(8946), 4, 7, "87" },
                    { 164, new DateTime(2020, 10, 21, 2, 57, 17, 46, DateTimeKind.Local).AddTicks(42), 5, 2, "87" },
                    { 147, new DateTime(2020, 12, 21, 9, 58, 42, 286, DateTimeKind.Local).AddTicks(2563), 1, 14, "65" },
                    { 125, new DateTime(2020, 7, 25, 20, 50, 1, 643, DateTimeKind.Local).AddTicks(1252), 5, 11, "56" },
                    { 119, new DateTime(2020, 6, 15, 6, 9, 28, 174, DateTimeKind.Local).AddTicks(3714), 4, 49, "98" },
                    { 105, new DateTime(2020, 5, 17, 8, 6, 45, 998, DateTimeKind.Local).AddTicks(8042), 6, 14, "59" },
                    { 140, new DateTime(2020, 10, 21, 2, 12, 52, 571, DateTimeKind.Local).AddTicks(6199), 6, 49, "54" },
                    { 173, new DateTime(2020, 7, 4, 23, 57, 35, 987, DateTimeKind.Local).AddTicks(5178), 1, 49, "65" },
                    { 86, new DateTime(2019, 12, 29, 1, 4, 7, 146, DateTimeKind.Local).AddTicks(9215), 3, 11, "30" },
                    { 79, new DateTime(2020, 6, 6, 0, 14, 6, 988, DateTimeKind.Local).AddTicks(7413), 3, 14, "97" },
                    { 75, new DateTime(2020, 7, 28, 21, 24, 23, 910, DateTimeKind.Local).AddTicks(8782), 4, 14, "38" },
                    { 69, new DateTime(2020, 8, 2, 9, 36, 43, 542, DateTimeKind.Local).AddTicks(5336), 2, 14, "57" },
                    { 34, new DateTime(2020, 10, 8, 2, 22, 5, 339, DateTimeKind.Local).AddTicks(2114), 3, 11, "69" },
                    { 18, new DateTime(2020, 1, 6, 17, 22, 48, 759, DateTimeKind.Local).AddTicks(8017), 2, 11, "47" },
                    { 44, new DateTime(2020, 4, 4, 16, 56, 43, 654, DateTimeKind.Local).AddTicks(7516), 2, 14, "97" },
                    { 71, new DateTime(2020, 11, 28, 11, 40, 3, 583, DateTimeKind.Local).AddTicks(5897), 3, 7, "92" },
                    { 191, new DateTime(2020, 7, 11, 1, 27, 57, 353, DateTimeKind.Local).AddTicks(1659), 6, 7, "49" },
                    { 41, new DateTime(2020, 10, 6, 3, 39, 15, 620, DateTimeKind.Local).AddTicks(331), 4, 14, "38" },
                    { 104, new DateTime(2020, 12, 25, 4, 50, 31, 550, DateTimeKind.Local).AddTicks(6543), 4, 49, "32" },
                    { 26, new DateTime(2020, 5, 24, 1, 43, 33, 112, DateTimeKind.Local).AddTicks(4842), 6, 2, "98" },
                    { 143, new DateTime(2020, 7, 18, 6, 48, 2, 86, DateTimeKind.Local).AddTicks(8669), 1, 2, "15" },
                    { 97, new DateTime(2020, 9, 11, 19, 36, 8, 294, DateTimeKind.Local).AddTicks(5688), 5, 40, "21" },
                    { 106, new DateTime(2020, 5, 28, 20, 26, 29, 501, DateTimeKind.Local).AddTicks(7598), 2, 15, "68" },
                    { 78, new DateTime(2020, 10, 18, 18, 19, 38, 537, DateTimeKind.Local).AddTicks(1644), 4, 40, "17" },
                    { 1, new DateTime(2020, 10, 29, 21, 38, 33, 676, DateTimeKind.Local).AddTicks(5772), 3, 2, "69" },
                    { 132, new DateTime(2020, 7, 15, 23, 54, 50, 574, DateTimeKind.Local).AddTicks(3333), 1, 40, "35" },
                    { 76, new DateTime(2020, 7, 16, 20, 34, 55, 680, DateTimeKind.Local).AddTicks(9899), 5, 40, "96" },
                    { 48, new DateTime(2020, 4, 27, 15, 0, 48, 335, DateTimeKind.Local).AddTicks(6046), 4, 15, "39" },
                    { 62, new DateTime(2020, 11, 28, 20, 54, 43, 162, DateTimeKind.Local).AddTicks(4191), 6, 15, "98" },
                    { 188, new DateTime(2020, 7, 19, 16, 21, 58, 860, DateTimeKind.Local).AddTicks(5870), 2, 40, "77" },
                    { 80, new DateTime(2020, 12, 18, 11, 29, 42, 10, DateTimeKind.Local).AddTicks(2962), 6, 19, "11" },
                    { 27, new DateTime(2020, 8, 20, 2, 41, 37, 876, DateTimeKind.Local).AddTicks(7667), 3, 42, "34" },
                    { 158, new DateTime(2020, 11, 19, 1, 15, 24, 384, DateTimeKind.Local).AddTicks(4474), 5, 15, "22" },
                    { 193, new DateTime(2020, 8, 28, 1, 18, 20, 361, DateTimeKind.Local).AddTicks(7267), 3, 15, "38" },
                    { 43, new DateTime(2020, 2, 24, 12, 4, 7, 417, DateTimeKind.Local).AddTicks(4810), 5, 19, "79" },
                    { 114, new DateTime(2020, 8, 1, 12, 25, 50, 687, DateTimeKind.Local).AddTicks(571), 6, 19, "11" }
                });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[,]
                {
                    { 38, 5 },
                    { 8, 1 },
                    { 31, 5 },
                    { 33, 4 },
                    { 22, 2 },
                    { 2, 2 },
                    { 31, 2 },
                    { 22, 4 },
                    { 33, 3 },
                    { 38, 2 },
                    { 20, 5 },
                    { 11, 6 },
                    { 18, 6 },
                    { 20, 2 },
                    { 25, 6 },
                    { 25, 2 },
                    { 29, 4 },
                    { 29, 2 },
                    { 50, 2 },
                    { 19, 3 },
                    { 19, 5 },
                    { 32, 5 },
                    { 8, 4 },
                    { 50, 5 },
                    { 39, 2 },
                    { 32, 2 },
                    { 44, 3 },
                    { 36, 5 },
                    { 44, 4 },
                    { 36, 3 },
                    { 18, 3 },
                    { 11, 1 },
                    { 45, 6 },
                    { 45, 2 },
                    { 39, 6 },
                    { 17, 4 },
                    { 47, 5 },
                    { 28, 3 },
                    { 40, 5 },
                    { 40, 1 },
                    { 12, 1 },
                    { 12, 4 },
                    { 9, 3 },
                    { 9, 5 },
                    { 42, 5 },
                    { 42, 1 },
                    { 6, 3 },
                    { 6, 5 },
                    { 49, 4 },
                    { 49, 3 },
                    { 3, 3 },
                    { 16, 6 },
                    { 3, 6 },
                    { 46, 5 },
                    { 7, 4 },
                    { 7, 3 },
                    { 43, 3 },
                    { 43, 6 },
                    { 14, 4 },
                    { 14, 2 },
                    { 35, 1 },
                    { 35, 4 },
                    { 24, 3 },
                    { 24, 5 },
                    { 15, 6 },
                    { 15, 2 },
                    { 46, 3 },
                    { 28, 4 },
                    { 16, 2 },
                    { 13, 6 },
                    { 30, 1 },
                    { 30, 6 },
                    { 34, 6 },
                    { 34, 2 },
                    { 27, 2 },
                    { 27, 5 },
                    { 37, 5 },
                    { 37, 3 },
                    { 21, 1 },
                    { 21, 6 },
                    { 1, 2 },
                    { 1, 4 },
                    { 17, 1 },
                    { 13, 1 },
                    { 47, 1 },
                    { 26, 4 },
                    { 48, 6 },
                    { 23, 3 },
                    { 23, 4 },
                    { 48, 1 },
                    { 10, 3 },
                    { 10, 6 },
                    { 5, 6 },
                    { 5, 2 },
                    { 4, 2 },
                    { 4, 5 },
                    { 41, 2 },
                    { 41, 6 },
                    { 26, 1 },
                    { 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[,]
                {
                    { 20, 2021, "19 التأثير لهدا الإنجاز", 26, "19 بعد الإنجازات لبعض الأنشطة ", "19 وضعية التنفيد لهدا الإنجاز", "19 معدل الإنجاز لهدا الإنجاز", 51.0 },
                    { 25, 2024, "24 التأثير لهدا الإنجاز", 6, "24 بعد الإنجازات لبعض الأنشطة ", "24 وضعية التنفيد لهدا الإنجاز", "24 معدل الإنجاز لهدا الإنجاز", 28.0 },
                    { 39, 2021, "38 التأثير لهدا الإنجاز", 28, "38 بعد الإنجازات لبعض الأنشطة ", "38 وضعية التنفيد لهدا الإنجاز", "38 معدل الإنجاز لهدا الإنجاز", 18.0 },
                    { 48, 2019, "47 التأثير لهدا الإنجاز", 3, "47 بعد الإنجازات لبعض الأنشطة ", "47 وضعية التنفيد لهدا الإنجاز", "47 معدل الإنجاز لهدا الإنجاز", 19.0 },
                    { 16, 2019, "15 التأثير لهدا الإنجاز", 16, "15 بعد الإنجازات لبعض الأنشطة ", "15 وضعية التنفيد لهدا الإنجاز", "15 معدل الإنجاز لهدا الإنجاز", 12.0 },
                    { 19, 2022, "18 التأثير لهدا الإنجاز", 16, "18 بعد الإنجازات لبعض الأنشطة ", "18 وضعية التنفيد لهدا الإنجاز", "18 معدل الإنجاز لهدا الإنجاز", 40.0 },
                    { 29, 2025, "28 التأثير لهدا الإنجاز", 16, "28 بعد الإنجازات لبعض الأنشطة ", "28 وضعية التنفيد لهدا الإنجاز", "28 معدل الإنجاز لهدا الإنجاز", 86.0 },
                    { 47, 2028, "46 التأثير لهدا الإنجاز", 9, "46 بعد الإنجازات لبعض الأنشطة ", "46 وضعية التنفيد لهدا الإنجاز", "46 معدل الإنجاز لهدا الإنجاز", 15.0 },
                    { 27, 2028, "26 التأثير لهدا الإنجاز", 11, "26 بعد الإنجازات لبعض الأنشطة ", "26 وضعية التنفيد لهدا الإنجاز", "26 معدل الإنجاز لهدا الإنجاز", 50.0 },
                    { 36, 2023, "35 التأثير لهدا الإنجاز", 11, "35 بعد الإنجازات لبعض الأنشطة ", "35 وضعية التنفيد لهدا الإنجاز", "35 معدل الإنجاز لهدا الإنجاز", 69.0 },
                    { 45, 2020, "44 التأثير لهدا الإنجاز", 11, "44 بعد الإنجازات لبعض الأنشطة ", "44 وضعية التنفيد لهدا الإنجاز", "44 معدل الإنجاز لهدا الإنجاز", 13.0 },
                    { 40, 2018, "39 التأثير لهدا الإنجاز", 12, "39 بعد الإنجازات لبعض الأنشطة ", "39 وضعية التنفيد لهدا الإنجاز", "39 معدل الإنجاز لهدا الإنجاز", 67.0 },
                    { 21, 2028, "20 التأثير لهدا الإنجاز", 31, "20 بعد الإنجازات لبعض الأنشطة ", "20 وضعية التنفيد لهدا الإنجاز", "20 معدل الإنجاز لهدا الإنجاز", 5.0 },
                    { 24, 2028, "23 التأثير لهدا الإنجاز", 31, "23 بعد الإنجازات لبعض الأنشطة ", "23 وضعية التنفيد لهدا الإنجاز", "23 معدل الإنجاز لهدا الإنجاز", 50.0 },
                    { 9, 2025, "8 التأثير لهدا الإنجاز", 50, "8 بعد الإنجازات لبعض الأنشطة ", "8 وضعية التنفيد لهدا الإنجاز", "8 معدل الإنجاز لهدا الإنجاز", 33.0 },
                    { 30, 2019, "29 التأثير لهدا الإنجاز", 50, "29 بعد الإنجازات لبعض الأنشطة ", "29 وضعية التنفيد لهدا الإنجاز", "29 معدل الإنجاز لهدا الإنجاز", 72.0 },
                    { 32, 2018, "31 التأثير لهدا الإنجاز", 50, "31 بعد الإنجازات لبعض الأنشطة ", "31 وضعية التنفيد لهدا الإنجاز", "31 معدل الإنجاز لهدا الإنجاز", 64.0 },
                    { 1, 2029, "0 التأثير لهدا الإنجاز", 1, "0 بعد الإنجازات لبعض الأنشطة ", "0 وضعية التنفيد لهدا الإنجاز", "0 معدل الإنجاز لهدا الإنجاز", 20.0 },
                    { 18, 2020, "17 التأثير لهدا الإنجاز", 1, "17 بعد الإنجازات لبعض الأنشطة ", "17 وضعية التنفيد لهدا الإنجاز", "17 معدل الإنجاز لهدا الإنجاز", 49.0 },
                    { 22, 2021, "21 التأثير لهدا الإنجاز", 1, "21 بعد الإنجازات لبعض الأنشطة ", "21 وضعية التنفيد لهدا الإنجاز", "21 معدل الإنجاز لهدا الإنجاز", 9.0 },
                    { 26, 2026, "25 التأثير لهدا الإنجاز", 1, "25 بعد الإنجازات لبعض الأنشطة ", "25 وضعية التنفيد لهدا الإنجاز", "25 معدل الإنجاز لهدا الإنجاز", 58.0 },
                    { 38, 2021, "37 التأثير لهدا الإنجاز", 1, "37 بعد الإنجازات لبعض الأنشطة ", "37 وضعية التنفيد لهدا الإنجاز", "37 معدل الإنجاز لهدا الإنجاز", 40.0 },
                    { 11, 2018, "10 التأثير لهدا الإنجاز", 6, "10 بعد الإنجازات لبعض الأنشطة ", "10 وضعية التنفيد لهدا الإنجاز", "10 معدل الإنجاز لهدا الإنجاز", 81.0 },
                    { 42, 2027, "41 التأثير لهدا الإنجاز", 37, "41 بعد الإنجازات لبعض الأنشطة ", "41 وضعية التنفيد لهدا الإنجاز", "41 معدل الإنجاز لهدا الإنجاز", 58.0 },
                    { 10, 2027, "9 التأثير لهدا الإنجاز", 37, "9 بعد الإنجازات لبعض الأنشطة ", "9 وضعية التنفيد لهدا الإنجاز", "9 معدل الإنجاز لهدا الإنجاز", 85.0 },
                    { 33, 2029, "32 التأثير لهدا الإنجاز", 40, "32 بعد الإنجازات لبعض الأنشطة ", "32 وضعية التنفيد لهدا الإنجاز", "32 معدل الإنجاز لهدا الإنجاز", 65.0 },
                    { 34, 2027, "33 التأثير لهدا الإنجاز", 7, "33 بعد الإنجازات لبعض الأنشطة ", "33 وضعية التنفيد لهدا الإنجاز", "33 معدل الإنجاز لهدا الإنجاز", 28.0 },
                    { 31, 2021, "30 التأثير لهدا الإنجاز", 21, "30 بعد الإنجازات لبعض الأنشطة ", "30 وضعية التنفيد لهدا الإنجاز", "30 معدل الإنجاز لهدا الإنجاز", 77.0 },
                    { 13, 2019, "12 التأثير لهدا الإنجاز", 29, "12 بعد الإنجازات لبعض الأنشطة ", "12 وضعية التنفيد لهدا الإنجاز", "12 معدل الإنجاز لهدا الإنجاز", 93.0 },
                    { 14, 2024, "13 التأثير لهدا الإنجاز", 29, "13 بعد الإنجازات لبعض الأنشطة ", "13 وضعية التنفيد لهدا الإنجاز", "13 معدل الإنجاز لهدا الإنجاز", 4.0 },
                    { 8, 2024, "7 التأثير لهدا الإنجاز", 35, "7 بعد الإنجازات لبعض الأنشطة ", "7 وضعية التنفيد لهدا الإنجاز", "7 معدل الإنجاز لهدا الإنجاز", 90.0 },
                    { 4, 2019, "3 التأثير لهدا الإنجاز", 47, "3 بعد الإنجازات لبعض الأنشطة ", "3 وضعية التنفيد لهدا الإنجاز", "3 معدل الإنجاز لهدا الإنجاز", 81.0 },
                    { 44, 2019, "43 التأثير لهدا الإنجاز", 47, "43 بعد الإنجازات لبعض الأنشطة ", "43 وضعية التنفيد لهدا الإنجاز", "43 معدل الإنجاز لهدا الإنجاز", 74.0 },
                    { 7, 2027, "6 التأثير لهدا الإنجاز", 13, "6 بعد الإنجازات لبعض الأنشطة ", "6 وضعية التنفيد لهدا الإنجاز", "6 معدل الإنجاز لهدا الإنجاز", 15.0 },
                    { 37, 2028, "36 التأثير لهدا الإنجاز", 41, "36 بعد الإنجازات لبعض الأنشطة ", "36 وضعية التنفيد لهدا الإنجاز", "36 معدل الإنجاز لهدا الإنجاز", 67.0 },
                    { 12, 2018, "11 التأثير لهدا الإنجاز", 30, "11 بعد الإنجازات لبعض الأنشطة ", "11 وضعية التنفيد لهدا الإنجاز", "11 معدل الإنجاز لهدا الإنجاز", 40.0 },
                    { 41, 2026, "40 التأثير لهدا الإنجاز", 14, "40 بعد الإنجازات لبعض الأنشطة ", "40 وضعية التنفيد لهدا الإنجاز", "40 معدل الإنجاز لهدا الإنجاز", 74.0 },
                    { 28, 2026, "27 التأثير لهدا الإنجاز", 30, "27 بعد الإنجازات لبعض الأنشطة ", "27 وضعية التنفيد لهدا الإنجاز", "27 معدل الإنجاز لهدا الإنجاز", 51.0 },
                    { 2, 2019, "1 التأثير لهدا الإنجاز", 44, "1 بعد الإنجازات لبعض الأنشطة ", "1 وضعية التنفيد لهدا الإنجاز", "1 معدل الإنجاز لهدا الإنجاز", 84.0 },
                    { 3, 2028, "2 التأثير لهدا الإنجاز", 2, "2 بعد الإنجازات لبعض الأنشطة ", "2 وضعية التنفيد لهدا الإنجاز", "2 معدل الإنجاز لهدا الإنجاز", 45.0 },
                    { 6, 2024, "5 التأثير لهدا الإنجاز", 5, "5 بعد الإنجازات لبعض الأنشطة ", "5 وضعية التنفيد لهدا الإنجاز", "5 معدل الإنجاز لهدا الإنجاز", 53.0 },
                    { 17, 2021, "16 التأثير لهدا الإنجاز", 5, "16 بعد الإنجازات لبعض الأنشطة ", "16 وضعية التنفيد لهدا الإنجاز", "16 معدل الإنجاز لهدا الإنجاز", 25.0 },
                    { 46, 2018, "45 التأثير لهدا الإنجاز", 5, "45 بعد الإنجازات لبعض الأنشطة ", "45 وضعية التنفيد لهدا الإنجاز", "45 معدل الإنجاز لهدا الإنجاز", 16.0 },
                    { 43, 2020, "42 التأثير لهدا الإنجاز", 33, "42 بعد الإنجازات لبعض الأنشطة ", "42 وضعية التنفيد لهدا الإنجاز", "42 معدل الإنجاز لهدا الإنجاز", 46.0 },
                    { 15, 2029, "14 التأثير لهدا الإنجاز", 39, "14 بعد الإنجازات لبعض الأنشطة ", "14 وضعية التنفيد لهدا الإنجاز", "14 معدل الإنجاز لهدا الإنجاز", 89.0 },
                    { 23, 2027, "22 التأثير لهدا الإنجاز", 39, "22 بعد الإنجازات لبعض الأنشطة ", "22 وضعية التنفيد لهدا الإنجاز", "22 معدل الإنجاز لهدا الإنجاز", 99.0 },
                    { 5, 2018, "4 التأثير لهدا الإنجاز", 24, "4 بعد الإنجازات لبعض الأنشطة ", "4 وضعية التنفيد لهدا الإنجاز", "4 معدل الإنجاز لهدا الإنجاز", 16.0 },
                    { 50, 2022, "49 التأثير لهدا الإنجاز", 24, "49 بعد الإنجازات لبعض الأنشطة ", "49 وضعية التنفيد لهدا الإنجاز", "49 معدل الإنجاز لهدا الإنجاز", 77.0 },
                    { 49, 2020, "48 التأثير لهدا الإنجاز", 19, "48 بعد الإنجازات لبعض الأنشطة ", "48 وضعية التنفيد لهدا الإنجاز", "48 معدل الإنجاز لهدا الإنجاز", 99.0 },
                    { 35, 2024, "34 التأثير لهدا الإنجاز", 38, "34 بعد الإنجازات لبعض الأنشطة ", "34 وضعية التنفيد لهدا الإنجاز", "34 معدل الإنجاز لهدا الإنجاز", 41.0 }
                });

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

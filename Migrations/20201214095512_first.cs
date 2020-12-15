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
                    { 20, new DateTime(2020, 5, 14, 20, 42, 28, 587, DateTimeKind.Local).AddTicks(8728), "محضر رقم 20", "اللجنة رقم 20" },
                    { 19, new DateTime(2020, 5, 5, 2, 32, 29, 873, DateTimeKind.Local).AddTicks(2865), "محضر رقم 19", "اللجنة رقم 19" },
                    { 18, new DateTime(2020, 5, 22, 13, 17, 45, 848, DateTimeKind.Local).AddTicks(7426), "محضر رقم 18", "اللجنة رقم 18" },
                    { 17, new DateTime(2020, 7, 22, 5, 25, 32, 401, DateTimeKind.Local).AddTicks(8885), "محضر رقم 17", "اللجنة رقم 17" },
                    { 16, new DateTime(2020, 3, 13, 17, 24, 3, 820, DateTimeKind.Local).AddTicks(6550), "محضر رقم 16", "اللجنة رقم 16" },
                    { 15, new DateTime(2020, 3, 21, 15, 18, 16, 217, DateTimeKind.Local).AddTicks(5748), "محضر رقم 15", "اللجنة رقم 15" },
                    { 14, new DateTime(2020, 8, 14, 9, 1, 17, 685, DateTimeKind.Local).AddTicks(4907), "محضر رقم 14", "اللجنة رقم 14" },
                    { 13, new DateTime(2020, 11, 7, 16, 12, 49, 185, DateTimeKind.Local).AddTicks(981), "محضر رقم 13", "اللجنة رقم 13" },
                    { 12, new DateTime(2020, 10, 8, 19, 15, 41, 700, DateTimeKind.Local).AddTicks(3614), "محضر رقم 12", "اللجنة رقم 12" },
                    { 11, new DateTime(2020, 7, 4, 5, 38, 12, 285, DateTimeKind.Local).AddTicks(5161), "محضر رقم 11", "اللجنة رقم 11" },
                    { 9, new DateTime(2019, 12, 24, 14, 50, 54, 740, DateTimeKind.Local).AddTicks(3378), "محضر رقم 9", "اللجنة رقم 9" },
                    { 8, new DateTime(2020, 7, 27, 1, 35, 23, 486, DateTimeKind.Local).AddTicks(1165), "محضر رقم 8", "اللجنة رقم 8" },
                    { 7, new DateTime(2020, 2, 21, 8, 27, 43, 293, DateTimeKind.Local).AddTicks(5594), "محضر رقم 7", "اللجنة رقم 7" },
                    { 6, new DateTime(2020, 8, 5, 18, 15, 31, 66, DateTimeKind.Local).AddTicks(8762), "محضر رقم 6", "اللجنة رقم 6" },
                    { 5, new DateTime(2020, 8, 17, 23, 46, 43, 486, DateTimeKind.Local).AddTicks(7971), "محضر رقم 5", "اللجنة رقم 5" },
                    { 4, new DateTime(2020, 10, 30, 0, 55, 50, 49, DateTimeKind.Local).AddTicks(6629), "محضر رقم 4", "اللجنة رقم 4" },
                    { 3, new DateTime(2020, 11, 9, 10, 28, 49, 277, DateTimeKind.Local).AddTicks(8894), "محضر رقم 3", "اللجنة رقم 3" },
                    { 2, new DateTime(2020, 11, 17, 14, 21, 14, 777, DateTimeKind.Local).AddTicks(5515), "محضر رقم 2", "اللجنة رقم 2" },
                    { 1, new DateTime(2020, 10, 26, 2, 43, 40, 306, DateTimeKind.Local).AddTicks(9985), "محضر رقم 1", "اللجنة رقم 1" },
                    { 10, new DateTime(2020, 9, 17, 18, 27, 10, 206, DateTimeKind.Local).AddTicks(737), "محضر رقم 10", "اللجنة رقم 10" }
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
                    { 12, "Yanis_Lefevre@hotmail.fr", 12, "Kylian Maillard" },
                    { 18, "Romane48@gmail.com", 18, "Raphaël Bertrand" },
                    { 17, "Yanis66@yahoo.fr", 17, "Noémie Perrot" },
                    { 16, "Mael.Sanchez60@gmail.com", 16, "Lisa Leroy" },
                    { 15, "Clement74@gmail.com", 15, "Adrien Hubert" },
                    { 14, "Lisa9@hotmail.fr", 14, "Quentin Morin" },
                    { 13, "Charlotte.Deschamps4@yahoo.fr", 13, "Julie Meyer" },
                    { 1, "Matteo_Bourgeois@yahoo.fr", 1, "Valentin Robin" },
                    { 2, "Antoine.Louis@yahoo.fr", 2, "Victor Masson" },
                    { 3, "Axel13@hotmail.fr", 3, "Mathilde Rolland" },
                    { 4, "Noa.Lambert@yahoo.fr", 4, "Eva Masson" },
                    { 5, "Paul.Simon80@yahoo.fr", 5, "Maxence Garnier" },
                    { 6, "Elisa.Philippe@yahoo.fr", 6, "Eva Lecomte" },
                    { 7, "Zoe.Rodriguez@hotmail.fr", 7, "Sarah Simon" },
                    { 8, "Noa_Jean87@yahoo.fr", 8, "Thomas David" },
                    { 9, "Maxence87@hotmail.fr", 9, "Carla Meyer" },
                    { 19, "Kylian.Lemaire@yahoo.fr", 19, "Zoe Simon" },
                    { 10, "Baptiste_Pons77@yahoo.fr", 10, "Maëlle Picard" },
                    { 20, "Lola.Schneider58@gmail.com", 20, "Elisa Petit" },
                    { 11, "Anais_Berger@hotmail.fr", 11, "Alexis Renaud" }
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
                    { 1, "Code : {id - 1}", 2, 3, 2, 5, 2, 2, "1 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 1", "بعد الأهداف الخاصة : 1", "بعد النتائج المرتقبة : 1" },
                    { 20, "Code : {id - 1}", 1, 2, 3, 9, 5, 2, "20 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 20", "بعد الأهداف الخاصة : 20", "بعد النتائج المرتقبة : 20" },
                    { 31, "Code : {id - 1}", 4, 3, 3, 9, 9, 2, "31 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 31", "بعد الأهداف الخاصة : 31", "بعد النتائج المرتقبة : 31" },
                    { 32, "Code : {id - 1}", 2, 3, 3, 9, 23, 2, "32 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 32", "بعد الأهداف الخاصة : 32", "بعد النتائج المرتقبة : 32" },
                    { 35, "Code : {id - 1}", 3, 2, 3, 9, 1, 1, "35 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 35", "بعد الأهداف الخاصة : 35", "بعد النتائج المرتقبة : 35" },
                    { 37, "Code : {id - 1}", 3, 3, 3, 9, 2, 1, "37 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 37", "بعد الأهداف الخاصة : 37", "بعد النتائج المرتقبة : 37" },
                    { 10, "Code : {id - 1}", 4, 3, 3, 10, 23, 1, "10 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 10", "بعد الأهداف الخاصة : 10", "بعد النتائج المرتقبة : 10" },
                    { 40, "Code : {id - 1}", 1, 1, 1, 10, 2, 2, "40 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 40", "بعد الأهداف الخاصة : 40", "بعد النتائج المرتقبة : 40" },
                    { 44, "Code : {id - 1}", 1, 2, 2, 10, 4, 3, "44 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 44", "بعد الأهداف الخاصة : 44", "بعد النتائج المرتقبة : 44" },
                    { 45, "Code : {id - 1}", 3, 1, 3, 10, 8, 3, "45 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 45", "بعد الأهداف الخاصة : 45", "بعد النتائج المرتقبة : 45" },
                    { 5, "Code : {id - 1}", 1, 1, 1, 11, 11, 1, "5 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 5", "بعد الأهداف الخاصة : 5", "بعد النتائج المرتقبة : 5" },
                    { 6, "Code : {id - 1}", 3, 1, 1, 11, 17, 3, "6 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 6", "بعد الأهداف الخاصة : 6", "بعد النتائج المرتقبة : 6" },
                    { 7, "Code : {id - 1}", 1, 1, 3, 11, 19, 2, "7 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 7", "بعد الأهداف الخاصة : 7", "بعد النتائج المرتقبة : 7" },
                    { 16, "Code : {id - 1}", 4, 1, 3, 11, 4, 2, "16 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 16", "بعد الأهداف الخاصة : 16", "بعد النتائج المرتقبة : 16" },
                    { 17, "Code : {id - 1}", 1, 1, 2, 11, 6, 2, "17 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 17", "بعد الأهداف الخاصة : 17", "بعد النتائج المرتقبة : 17" },
                    { 21, "Code : {id - 1}", 2, 1, 2, 11, 19, 3, "21 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 21", "بعد الأهداف الخاصة : 21", "بعد النتائج المرتقبة : 21" },
                    { 23, "Code : {id - 1}", 2, 1, 3, 11, 22, 1, "23 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 23", "بعد الأهداف الخاصة : 23", "بعد النتائج المرتقبة : 23" },
                    { 29, "Code : {id - 1}", 3, 3, 2, 11, 3, 1, "29 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 29", "بعد الأهداف الخاصة : 29", "بعد النتائج المرتقبة : 29" },
                    { 9, "Code : {id - 1}", 1, 2, 1, 12, 21, 1, "9 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 9", "بعد الأهداف الخاصة : 9", "بعد النتائج المرتقبة : 9" },
                    { 15, "Code : {id - 1}", 2, 2, 2, 12, 11, 3, "15 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 15", "بعد الأهداف الخاصة : 15", "بعد النتائج المرتقبة : 15" },
                    { 24, "Code : {id - 1}", 3, 2, 2, 12, 8, 2, "24 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 24", "بعد الأهداف الخاصة : 24", "بعد النتائج المرتقبة : 24" },
                    { 46, "Code : {id - 1}", 3, 3, 1, 12, 11, 1, "46 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 46", "بعد الأهداف الخاصة : 46", "بعد النتائج المرتقبة : 46" },
                    { 14, "Code : {id - 1}", 2, 2, 1, 9, 23, 1, "14 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 14", "بعد الأهداف الخاصة : 14", "بعد النتائج المرتقبة : 14" },
                    { 4, "Code : {id - 1}", 3, 1, 2, 9, 23, 1, "4 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 4", "بعد الأهداف الخاصة : 4", "بعد النتائج المرتقبة : 4" },
                    { 3, "Code : {id - 1}", 4, 3, 2, 9, 26, 2, "3 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 3", "بعد الأهداف الخاصة : 3", "بعد النتائج المرتقبة : 3" },
                    { 43, "Code : {id - 1}", 4, 2, 1, 8, 15, 2, "43 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 43", "بعد الأهداف الخاصة : 43", "بعد النتائج المرتقبة : 43" },
                    { 8, "Code : {id - 1}", 2, 2, 1, 5, 13, 1, "8 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 8", "بعد الأهداف الخاصة : 8", "بعد النتائج المرتقبة : 8" },
                    { 12, "Code : {id - 1}", 2, 2, 1, 5, 15, 1, "12 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 12", "بعد الأهداف الخاصة : 12", "بعد النتائج المرتقبة : 12" },
                    { 25, "Code : {id - 1}", 4, 2, 3, 5, 14, 2, "25 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 25", "بعد الأهداف الخاصة : 25", "بعد النتائج المرتقبة : 25" },
                    { 36, "Code : {id - 1}", 4, 2, 2, 5, 12, 1, "36 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 36", "بعد الأهداف الخاصة : 36", "بعد النتائج المرتقبة : 36" },
                    { 42, "Code : {id - 1}", 4, 3, 3, 5, 16, 3, "42 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 42", "بعد الأهداف الخاصة : 42", "بعد النتائج المرتقبة : 42" },
                    { 2, "Code : {id - 1}", 2, 3, 3, 6, 15, 3, "2 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 2", "بعد الأهداف الخاصة : 2", "بعد النتائج المرتقبة : 2" },
                    { 19, "Code : {id - 1}", 1, 3, 2, 6, 14, 3, "19 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 19", "بعد الأهداف الخاصة : 19", "بعد النتائج المرتقبة : 19" },
                    { 27, "Code : {id - 1}", 2, 3, 3, 6, 2, 1, "27 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 27", "بعد الأهداف الخاصة : 27", "بعد النتائج المرتقبة : 27" },
                    { 38, "Code : {id - 1}", 1, 2, 2, 6, 17, 2, "38 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 38", "بعد الأهداف الخاصة : 38", "بعد النتائج المرتقبة : 38" },
                    { 39, "Code : {id - 1}", 1, 2, 3, 6, 11, 2, "39 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 39", "بعد الأهداف الخاصة : 39", "بعد النتائج المرتقبة : 39" },
                    { 48, "Code : {id - 1}", 2, 1, 1, 12, 9, 2, "48 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 48", "بعد الأهداف الخاصة : 48", "بعد النتائج المرتقبة : 48" },
                    { 47, "Code : {id - 1}", 2, 3, 2, 6, 10, 3, "47 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 47", "بعد الأهداف الخاصة : 47", "بعد النتائج المرتقبة : 47" },
                    { 33, "Code : {id - 1}", 4, 2, 3, 7, 24, 2, "33 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 33", "بعد الأهداف الخاصة : 33", "بعد النتائج المرتقبة : 33" },
                    { 11, "Code : {id - 1}", 1, 3, 1, 8, 9, 2, "11 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 11", "بعد الأهداف الخاصة : 11", "بعد النتائج المرتقبة : 11" },
                    { 13, "Code : {id - 1}", 2, 3, 1, 8, 22, 2, "13 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 13", "بعد الأهداف الخاصة : 13", "بعد النتائج المرتقبة : 13" },
                    { 18, "Code : {id - 1}", 3, 1, 1, 8, 3, 3, "18 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 18", "بعد الأهداف الخاصة : 18", "بعد النتائج المرتقبة : 18" },
                    { 22, "Code : {id - 1}", 1, 1, 3, 8, 15, 1, "22 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 22", "بعد الأهداف الخاصة : 22", "بعد النتائج المرتقبة : 22" },
                    { 26, "Code : {id - 1}", 2, 2, 2, 8, 13, 3, "26 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 26", "بعد الأهداف الخاصة : 26", "بعد النتائج المرتقبة : 26" },
                    { 28, "Code : {id - 1}", 4, 2, 3, 8, 3, 3, "28 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 28", "بعد الأهداف الخاصة : 28", "بعد النتائج المرتقبة : 28" },
                    { 30, "Code : {id - 1}", 2, 1, 3, 8, 26, 1, "30 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 30", "بعد الأهداف الخاصة : 30", "بعد النتائج المرتقبة : 30" },
                    { 34, "Code : {id - 1}", 3, 2, 3, 8, 1, 2, "34 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 34", "بعد الأهداف الخاصة : 34", "بعد النتائج المرتقبة : 34" },
                    { 41, "Code : {id - 1}", 1, 3, 2, 8, 12, 1, "41 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 41", "بعد الأهداف الخاصة : 41", "بعد النتائج المرتقبة : 41" },
                    { 50, "Code : {id - 1}", 4, 2, 1, 6, 19, 1, "50 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 50", "بعد الأهداف الخاصة : 50", "بعد النتائج المرتقبة : 50" },
                    { 49, "Code : {id - 1}", 1, 1, 2, 12, 22, 3, "49 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 49", "بعد الأهداف الخاصة : 49", "بعد النتائج المرتقبة : 49" }
                });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[,]
                {
                    { 30, "[\"2023\", \"2024\", \"2025\"]", 1, "29 بعد الأنشطة لبعض التدابير" },
                    { 9, "[\"2024\", \"2025\", \"2026\"]", 29, "8 بعد الأنشطة لبعض التدابير" },
                    { 1, "[\"2029\", \"2030\", \"2031\"]", 29, "0 بعد الأنشطة لبعض التدابير" },
                    { 13, "[\"2025\", \"2026\", \"2027\"]", 20, "12 بعد الأنشطة لبعض التدابير" },
                    { 36, "[\"2021\", \"2022\", \"2023\"]", 2, "35 بعد الأنشطة لبعض التدابير" },
                    { 7, "[\"2029\", \"2030\", \"2031\"]", 19, "6 بعد الأنشطة لبعض التدابير" },
                    { 33, "[\"2019\", \"2020\", \"2021\"]", 19, "32 بعد الأنشطة لبعض التدابير" },
                    { 46, "[\"2018\", \"2019\", \"2020\"]", 19, "45 بعد الأنشطة لبعض التدابير" },
                    { 8, "[\"2028\", \"2029\", \"2030\"]", 31, "7 بعد الأنشطة لبعض التدابير" },
                    { 22, "[\"2022\", \"2023\", \"2024\"]", 22, "21 بعد الأنشطة لبعض التدابير" },
                    { 10, "[\"2019\", \"2020\", \"2021\"]", 27, "9 بعد الأنشطة لبعض التدابير" },
                    { 25, "[\"2023\", \"2024\", \"2025\"]", 27, "24 بعد الأنشطة لبعض التدابير" },
                    { 47, "[\"2029\", \"2030\", \"2031\"]", 27, "46 بعد الأنشطة لبعض التدابير" },
                    { 28, "[\"2023\", \"2024\", \"2025\"]", 18, "27 بعد الأنشطة لبعض التدابير" },
                    { 26, "[\"2025\", \"2026\", \"2027\"]", 17, "25 بعد الأنشطة لبعض التدابير" },
                    { 16, "[\"2022\", \"2023\", \"2024\"]", 13, "15 بعد الأنشطة لبعض التدابير" },
                    { 20, "[\"2024\", \"2025\", \"2026\"]", 16, "19 بعد الأنشطة لبعض التدابير" },
                    { 6, "[\"2025\", \"2026\", \"2027\"]", 16, "5 بعد الأنشطة لبعض التدابير" },
                    { 34, "[\"2027\", \"2028\", \"2029\"]", 38, "33 بعد الأنشطة لبعض التدابير" },
                    { 11, "[\"2026\", \"2027\", \"2028\"]", 32, "10 بعد الأنشطة لبعض التدابير" },
                    { 38, "[\"2023\", \"2024\", \"2025\"]", 32, "37 بعد الأنشطة لبعض التدابير" },
                    { 18, "[\"2022\", \"2023\", \"2024\"]", 11, "17 بعد الأنشطة لبعض التدابير" },
                    { 14, "[\"2025\", \"2026\", \"2027\"]", 11, "13 بعد الأنشطة لبعض التدابير" },
                    { 12, "[\"2022\", \"2023\", \"2024\"]", 7, "11 بعد الأنشطة لبعض التدابير" },
                    { 37, "[\"2018\", \"2019\", \"2020\"]", 39, "36 بعد الأنشطة لبعض التدابير" },
                    { 2, "[\"2019\", \"2020\", \"2021\"]", 6, "1 بعد الأنشطة لبعض التدابير" },
                    { 40, "[\"2028\", \"2029\", \"2030\"]", 37, "39 بعد الأنشطة لبعض التدابير" },
                    { 42, "[\"2026\", \"2027\", \"2028\"]", 37, "41 بعد الأنشطة لبعض التدابير" },
                    { 15, "[\"2021\", \"2022\", \"2023\"]", 36, "14 بعد الأنشطة لبعض التدابير" },
                    { 48, "[\"2029\", \"2030\", \"2031\"]", 4, "47 بعد الأنشطة لبعض التدابير" },
                    { 23, "[\"2021\", \"2022\", \"2023\"]", 44, "22 بعد الأنشطة لبعض التدابير" },
                    { 44, "[\"2025\", \"2026\", \"2027\"]", 25, "43 بعد الأنشطة لبعض التدابير" },
                    { 41, "[\"2024\", \"2025\", \"2026\"]", 34, "40 بعد الأنشطة لبعض التدابير" },
                    { 4, "[\"2020\", \"2021\", \"2022\"]", 49, "3 بعد الأنشطة لبعض التدابير" },
                    { 39, "[\"2020\", \"2021\", \"2022\"]", 48, "38 بعد الأنشطة لبعض التدابير" },
                    { 21, "[\"2019\", \"2020\", \"2021\"]", 3, "20 بعد الأنشطة لبعض التدابير" },
                    { 24, "[\"2027\", \"2028\", \"2029\"]", 48, "23 بعد الأنشطة لبعض التدابير" },
                    { 29, "[\"2020\", \"2021\", \"2022\"]", 49, "28 بعد الأنشطة لبعض التدابير" },
                    { 5, "[\"2025\", \"2026\", \"2027\"]", 25, "4 بعد الأنشطة لبعض التدابير" },
                    { 19, "[\"2022\", \"2023\", \"2024\"]", 25, "18 بعد الأنشطة لبعض التدابير" },
                    { 3, "[\"2022\", \"2023\", \"2024\"]", 48, "2 بعد الأنشطة لبعض التدابير" },
                    { 32, "[\"2026\", \"2027\", \"2028\"]", 46, "31 بعد الأنشطة لبعض التدابير" },
                    { 50, "[\"2022\", \"2023\", \"2024\"]", 46, "49 بعد الأنشطة لبعض التدابير" },
                    { 35, "[\"2029\", \"2030\", \"2031\"]", 34, "34 بعد الأنشطة لبعض التدابير" },
                    { 45, "[\"2027\", \"2028\", \"2029\"]", 3, "44 بعد الأنشطة لبعض التدابير" },
                    { 43, "[\"2019\", \"2020\", \"2021\"]", 3, "42 بعد الأنشطة لبعض التدابير" },
                    { 17, "[\"2024\", \"2025\", \"2026\"]", 12, "16 بعد الأنشطة لبعض التدابير" },
                    { 31, "[\"2021\", \"2022\", \"2023\"]", 1, "30 بعد الأنشطة لبعض التدابير" },
                    { 27, "[\"2025\", \"2026\", \"2027\"]", 3, "26 بعد الأنشطة لبعض التدابير" },
                    { 49, "[\"2022\", \"2023\", \"2024\"]", 25, "48 بعد الأنشطة لبعض التدابير" }
                });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[,]
                {
                    { 116, new DateTime(2020, 11, 11, 12, 7, 42, 748, DateTimeKind.Local).AddTicks(1366), 5, 43, "65" },
                    { 144, new DateTime(2019, 12, 15, 3, 48, 29, 629, DateTimeKind.Local).AddTicks(8013), 6, 31, "70" },
                    { 194, new DateTime(2020, 10, 31, 14, 42, 22, 770, DateTimeKind.Local).AddTicks(9096), 6, 43, "92" },
                    { 21, new DateTime(2020, 1, 3, 17, 51, 35, 701, DateTimeKind.Local).AddTicks(8123), 2, 4, "90" },
                    { 140, new DateTime(2020, 10, 6, 9, 58, 47, 985, DateTimeKind.Local).AddTicks(7415), 4, 32, "80" },
                    { 154, new DateTime(2020, 8, 19, 2, 15, 42, 376, DateTimeKind.Local).AddTicks(6323), 3, 32, "21" },
                    { 78, new DateTime(2020, 12, 2, 7, 33, 1, 15, DateTimeKind.Local).AddTicks(5593), 1, 43, "59" },
                    { 155, new DateTime(2020, 10, 12, 19, 56, 38, 280, DateTimeKind.Local).AddTicks(5139), 5, 32, "62" },
                    { 184, new DateTime(2020, 3, 22, 1, 43, 43, 442, DateTimeKind.Local).AddTicks(1997), 4, 32, "68" },
                    { 72, new DateTime(2019, 12, 20, 9, 11, 36, 638, DateTimeKind.Local).AddTicks(2732), 3, 43, "56" },
                    { 111, new DateTime(2020, 7, 25, 2, 27, 9, 746, DateTimeKind.Local).AddTicks(9940), 2, 35, "21" },
                    { 53, new DateTime(2020, 6, 20, 13, 36, 50, 557, DateTimeKind.Local).AddTicks(3942), 2, 43, "36" },
                    { 120, new DateTime(2020, 1, 6, 3, 0, 34, 929, DateTimeKind.Local).AddTicks(4802), 3, 37, "43" },
                    { 89, new DateTime(2020, 9, 26, 21, 22, 53, 460, DateTimeKind.Local).AddTicks(5730), 1, 10, "83" },
                    { 39, new DateTime(2020, 8, 11, 12, 33, 39, 223, DateTimeKind.Local).AddTicks(7826), 1, 40, "41" },
                    { 84, new DateTime(2020, 7, 22, 17, 51, 3, 94, DateTimeKind.Local).AddTicks(7472), 6, 32, "65" },
                    { 95, new DateTime(2019, 12, 16, 21, 12, 3, 803, DateTimeKind.Local).AddTicks(6258), 4, 31, "37" },
                    { 56, new DateTime(2020, 1, 6, 22, 42, 2, 670, DateTimeKind.Local).AddTicks(7839), 6, 31, "49" },
                    { 64, new DateTime(2020, 3, 9, 3, 43, 55, 886, DateTimeKind.Local).AddTicks(4057), 5, 31, "79" },
                    { 98, new DateTime(2020, 6, 21, 5, 17, 10, 163, DateTimeKind.Local).AddTicks(7693), 3, 4, "32" },
                    { 173, new DateTime(2020, 7, 15, 11, 26, 39, 294, DateTimeKind.Local).AddTicks(4686), 1, 3, "51" },
                    { 146, new DateTime(2019, 12, 14, 15, 37, 9, 994, DateTimeKind.Local).AddTicks(5214), 4, 4, "80" },
                    { 158, new DateTime(2020, 2, 2, 5, 14, 43, 914, DateTimeKind.Local).AddTicks(5525), 3, 4, "65" },
                    { 17, new DateTime(2020, 11, 23, 22, 45, 55, 124, DateTimeKind.Local).AddTicks(4015), 3, 14, "67" },
                    { 44, new DateTime(2020, 10, 21, 12, 54, 44, 604, DateTimeKind.Local).AddTicks(2864), 1, 14, "33" },
                    { 57, new DateTime(2020, 3, 8, 5, 14, 28, 349, DateTimeKind.Local).AddTicks(1973), 5, 14, "19" },
                    { 73, new DateTime(2020, 1, 7, 8, 30, 26, 481, DateTimeKind.Local).AddTicks(4832), 6, 14, "61" },
                    { 106, new DateTime(2020, 10, 16, 22, 18, 23, 237, DateTimeKind.Local).AddTicks(4845), 6, 14, "84" },
                    { 108, new DateTime(2020, 1, 15, 21, 29, 56, 915, DateTimeKind.Local).AddTicks(4882), 2, 14, "24" },
                    { 112, new DateTime(2020, 12, 3, 10, 41, 23, 740, DateTimeKind.Local).AddTicks(2165), 4, 40, "23" },
                    { 114, new DateTime(2020, 9, 4, 16, 4, 30, 5, DateTimeKind.Local).AddTicks(8640), 3, 20, "78" },
                    { 150, new DateTime(2020, 10, 4, 14, 26, 40, 950, DateTimeKind.Local).AddTicks(4292), 4, 20, "75" },
                    { 186, new DateTime(2019, 12, 20, 22, 29, 15, 970, DateTimeKind.Local).AddTicks(136), 6, 20, "92" },
                    { 137, new DateTime(2020, 8, 1, 5, 56, 11, 49, DateTimeKind.Local).AddTicks(1220), 6, 3, "89" },
                    { 45, new DateTime(2020, 9, 5, 20, 15, 21, 254, DateTimeKind.Local).AddTicks(653), 6, 3, "45" },
                    { 15, new DateTime(2020, 10, 26, 18, 25, 38, 464, DateTimeKind.Local).AddTicks(5413), 4, 31, "33" },
                    { 31, new DateTime(2020, 12, 1, 2, 30, 37, 566, DateTimeKind.Local).AddTicks(3859), 4, 31, "97" },
                    { 169, new DateTime(2020, 5, 5, 1, 37, 41, 685, DateTimeKind.Local).AddTicks(4814), 1, 49, "18" },
                    { 34, new DateTime(2020, 4, 25, 21, 21, 46, 260, DateTimeKind.Local).AddTicks(1328), 2, 31, "32" },
                    { 36, new DateTime(2019, 12, 20, 13, 38, 47, 380, DateTimeKind.Local).AddTicks(7799), 3, 31, "58" },
                    { 181, new DateTime(2020, 8, 6, 0, 52, 9, 912, DateTimeKind.Local).AddTicks(8502), 5, 3, "88" },
                    { 62, new DateTime(2020, 3, 21, 10, 58, 29, 819, DateTimeKind.Local).AddTicks(1013), 5, 31, "68" },
                    { 94, new DateTime(2020, 10, 25, 6, 37, 6, 998, DateTimeKind.Local).AddTicks(5861), 2, 31, "70" },
                    { 1, new DateTime(2019, 12, 23, 11, 30, 40, 436, DateTimeKind.Local).AddTicks(2305), 3, 20, "23" },
                    { 52, new DateTime(2020, 4, 12, 21, 55, 8, 839, DateTimeKind.Local).AddTicks(2938), 4, 7, "80" },
                    { 189, new DateTime(2020, 2, 6, 16, 16, 44, 666, DateTimeKind.Local).AddTicks(2529), 5, 44, "91" },
                    { 166, new DateTime(2020, 6, 15, 20, 41, 16, 27, DateTimeKind.Local).AddTicks(6888), 4, 23, "42" },
                    { 178, new DateTime(2020, 6, 15, 17, 1, 26, 36, DateTimeKind.Local).AddTicks(4618), 1, 23, "60" },
                    { 125, new DateTime(2020, 11, 9, 19, 46, 29, 882, DateTimeKind.Local).AddTicks(4457), 1, 29, "89" },
                    { 133, new DateTime(2020, 4, 3, 18, 27, 22, 920, DateTimeKind.Local).AddTicks(7843), 2, 29, "56" },
                    { 9, new DateTime(2020, 4, 21, 4, 13, 51, 723, DateTimeKind.Local).AddTicks(8193), 4, 9, "76" },
                    { 131, new DateTime(2019, 12, 31, 9, 49, 16, 206, DateTimeKind.Local).AddTicks(7465), 6, 9, "54" },
                    { 152, new DateTime(2020, 7, 14, 13, 34, 13, 882, DateTimeKind.Local).AddTicks(8064), 5, 9, "92" },
                    { 180, new DateTime(2020, 8, 28, 11, 39, 8, 180, DateTimeKind.Local).AddTicks(8515), 6, 15, "75" },
                    { 197, new DateTime(2020, 2, 18, 19, 20, 10, 524, DateTimeKind.Local).AddTicks(7270), 3, 15, "94" },
                    { 40, new DateTime(2020, 10, 25, 21, 6, 34, 327, DateTimeKind.Local).AddTicks(9635), 2, 24, "43" },
                    { 67, new DateTime(2020, 1, 26, 6, 57, 24, 264, DateTimeKind.Local).AddTicks(2835), 1, 24, "76" },
                    { 68, new DateTime(2019, 12, 27, 6, 27, 30, 288, DateTimeKind.Local).AddTicks(7387), 1, 24, "90" },
                    { 83, new DateTime(2020, 9, 20, 8, 19, 0, 837, DateTimeKind.Local).AddTicks(4449), 3, 24, "50" },
                    { 151, new DateTime(2020, 3, 7, 16, 39, 35, 965, DateTimeKind.Local).AddTicks(9972), 3, 23, "34" },
                    { 113, new DateTime(2019, 12, 29, 5, 27, 37, 127, DateTimeKind.Local).AddTicks(4581), 5, 24, "92" },
                    { 187, new DateTime(2020, 6, 7, 2, 56, 56, 203, DateTimeKind.Local).AddTicks(2072), 6, 24, "26" },
                    { 3, new DateTime(2020, 2, 23, 21, 56, 13, 384, DateTimeKind.Local).AddTicks(3068), 2, 46, "94" },
                    { 41, new DateTime(2020, 5, 2, 14, 24, 24, 49, DateTimeKind.Local).AddTicks(9848), 4, 46, "12" },
                    { 54, new DateTime(2020, 1, 22, 9, 4, 42, 948, DateTimeKind.Local).AddTicks(9055), 1, 46, "54" },
                    { 102, new DateTime(2020, 1, 31, 20, 8, 5, 112, DateTimeKind.Local).AddTicks(6367), 6, 46, "17" },
                    { 153, new DateTime(2020, 12, 13, 12, 38, 9, 144, DateTimeKind.Local).AddTicks(1855), 6, 46, "81" },
                    { 157, new DateTime(2020, 8, 1, 3, 15, 1, 898, DateTimeKind.Local).AddTicks(4253), 3, 46, "38" },
                    { 159, new DateTime(2020, 4, 6, 21, 17, 33, 801, DateTimeKind.Local).AddTicks(9165), 5, 46, "98" },
                    { 183, new DateTime(2020, 2, 23, 18, 2, 22, 576, DateTimeKind.Local).AddTicks(8797), 4, 46, "15" },
                    { 24, new DateTime(2020, 3, 27, 16, 47, 12, 934, DateTimeKind.Local).AddTicks(5910), 4, 48, "73" },
                    { 25, new DateTime(2020, 1, 2, 3, 30, 50, 984, DateTimeKind.Local).AddTicks(41), 1, 49, "99" },
                    { 76, new DateTime(2020, 1, 11, 15, 32, 26, 319, DateTimeKind.Local).AddTicks(3751), 5, 49, "33" },
                    { 100, new DateTime(2020, 12, 10, 11, 57, 1, 900, DateTimeKind.Local).AddTicks(4757), 5, 49, "45" },
                    { 135, new DateTime(2020, 3, 27, 0, 31, 18, 479, DateTimeKind.Local).AddTicks(6857), 5, 24, "49" },
                    { 38, new DateTime(2020, 11, 26, 9, 5, 18, 886, DateTimeKind.Local).AddTicks(5501), 3, 23, "62" },
                    { 29, new DateTime(2020, 9, 29, 14, 7, 0, 145, DateTimeKind.Local).AddTicks(4474), 1, 23, "16" },
                    { 12, new DateTime(2020, 3, 7, 15, 24, 25, 951, DateTimeKind.Local).AddTicks(5922), 4, 23, "53" },
                    { 199, new DateTime(2020, 5, 2, 2, 50, 49, 170, DateTimeKind.Local).AddTicks(742), 2, 44, "31" },
                    { 200, new DateTime(2020, 3, 23, 13, 22, 46, 731, DateTimeKind.Local).AddTicks(3934), 1, 44, "98" },
                    { 23, new DateTime(2019, 12, 28, 13, 57, 43, 583, DateTimeKind.Local).AddTicks(1068), 3, 5, "13" },
                    { 126, new DateTime(2020, 10, 26, 3, 8, 49, 264, DateTimeKind.Local).AddTicks(7593), 1, 5, "54" },
                    { 143, new DateTime(2020, 9, 19, 13, 41, 16, 409, DateTimeKind.Local).AddTicks(6236), 4, 5, "46" },
                    { 161, new DateTime(2020, 7, 14, 14, 5, 18, 668, DateTimeKind.Local).AddTicks(8302), 6, 5, "18" },
                    { 85, new DateTime(2020, 6, 18, 4, 38, 49, 301, DateTimeKind.Local).AddTicks(5349), 5, 6, "88" },
                    { 109, new DateTime(2020, 6, 27, 5, 25, 4, 820, DateTimeKind.Local).AddTicks(7001), 2, 6, "88" },
                    { 30, new DateTime(2020, 1, 28, 11, 22, 4, 185, DateTimeKind.Local).AddTicks(3189), 6, 7, "40" },
                    { 43, new DateTime(2020, 1, 7, 17, 44, 59, 360, DateTimeKind.Local).AddTicks(2886), 3, 43, "41" },
                    { 97, new DateTime(2020, 5, 28, 9, 49, 28, 986, DateTimeKind.Local).AddTicks(6812), 5, 7, "14" },
                    { 101, new DateTime(2020, 7, 5, 18, 9, 44, 534, DateTimeKind.Local).AddTicks(3700), 2, 7, "37" },
                    { 127, new DateTime(2020, 8, 4, 17, 29, 38, 375, DateTimeKind.Local).AddTicks(3018), 5, 7, "59" },
                    { 163, new DateTime(2020, 5, 10, 6, 59, 6, 367, DateTimeKind.Local).AddTicks(6525), 4, 7, "67" },
                    { 171, new DateTime(2020, 6, 16, 17, 23, 16, 610, DateTimeKind.Local).AddTicks(3636), 5, 7, "32" },
                    { 27, new DateTime(2020, 7, 8, 5, 9, 55, 248, DateTimeKind.Local).AddTicks(3651), 5, 16, "81" },
                    { 32, new DateTime(2020, 9, 16, 12, 13, 46, 432, DateTimeKind.Local).AddTicks(4244), 1, 16, "88" },
                    { 87, new DateTime(2020, 2, 4, 17, 1, 37, 152, DateTimeKind.Local).AddTicks(8771), 4, 16, "26" },
                    { 147, new DateTime(2019, 12, 16, 4, 53, 36, 161, DateTimeKind.Local).AddTicks(1386), 6, 16, "39" },
                    { 167, new DateTime(2020, 1, 17, 14, 35, 51, 970, DateTimeKind.Local).AddTicks(1323), 6, 16, "18" },
                    { 47, new DateTime(2020, 6, 12, 11, 37, 8, 960, DateTimeKind.Local).AddTicks(2146), 2, 17, "71" },
                    { 69, new DateTime(2020, 5, 10, 8, 45, 1, 82, DateTimeKind.Local).AddTicks(7345), 4, 17, "94" },
                    { 104, new DateTime(2020, 8, 6, 4, 27, 2, 423, DateTimeKind.Local).AddTicks(111), 3, 17, "83" },
                    { 124, new DateTime(2020, 1, 8, 23, 1, 39, 882, DateTimeKind.Local).AddTicks(4237), 2, 17, "50" },
                    { 16, new DateTime(2020, 8, 15, 10, 21, 23, 691, DateTimeKind.Local).AddTicks(2835), 1, 21, "88" },
                    { 33, new DateTime(2020, 6, 26, 19, 39, 56, 267, DateTimeKind.Local).AddTicks(8434), 6, 21, "42" },
                    { 86, new DateTime(2020, 11, 5, 5, 51, 23, 430, DateTimeKind.Local).AddTicks(8871), 4, 21, "22" },
                    { 119, new DateTime(2020, 11, 14, 14, 50, 47, 537, DateTimeKind.Local).AddTicks(1922), 1, 21, "32" },
                    { 170, new DateTime(2020, 9, 21, 9, 16, 29, 573, DateTimeKind.Local).AddTicks(755), 5, 21, "63" },
                    { 162, new DateTime(2020, 5, 19, 22, 11, 16, 449, DateTimeKind.Local).AddTicks(9380), 5, 44, "38" },
                    { 35, new DateTime(2020, 9, 25, 15, 57, 51, 246, DateTimeKind.Local).AddTicks(5300), 2, 43, "68" },
                    { 182, new DateTime(2020, 2, 2, 16, 44, 51, 859, DateTimeKind.Local).AddTicks(4358), 5, 49, "53" },
                    { 46, new DateTime(2020, 1, 13, 10, 9, 24, 249, DateTimeKind.Local).AddTicks(6413), 1, 33, "82" },
                    { 172, new DateTime(2020, 8, 3, 18, 32, 59, 904, DateTimeKind.Local).AddTicks(9956), 1, 39, "90" },
                    { 141, new DateTime(2020, 1, 22, 17, 30, 30, 641, DateTimeKind.Local).AddTicks(4033), 3, 42, "81" },
                    { 65, new DateTime(2020, 8, 9, 19, 22, 28, 929, DateTimeKind.Local).AddTicks(3274), 1, 42, "78" },
                    { 49, new DateTime(2020, 11, 16, 14, 47, 16, 430, DateTimeKind.Local).AddTicks(2302), 4, 42, "38" },
                    { 48, new DateTime(2020, 5, 25, 18, 10, 21, 67, DateTimeKind.Local).AddTicks(8673), 6, 42, "25" },
                    { 26, new DateTime(2020, 4, 8, 5, 37, 24, 71, DateTimeKind.Local).AddTicks(5690), 3, 47, "41" },
                    { 130, new DateTime(2020, 8, 21, 10, 17, 24, 155, DateTimeKind.Local).AddTicks(1053), 1, 47, "70" },
                    { 149, new DateTime(2020, 9, 12, 16, 46, 32, 406, DateTimeKind.Local).AddTicks(3457), 2, 47, "90" },
                    { 92, new DateTime(2020, 1, 26, 14, 49, 29, 889, DateTimeKind.Local).AddTicks(5345), 2, 36, "46" },
                    { 7, new DateTime(2020, 1, 10, 7, 28, 45, 432, DateTimeKind.Local).AddTicks(7571), 4, 36, "98" },
                    { 129, new DateTime(2020, 1, 29, 8, 32, 11, 112, DateTimeKind.Local).AddTicks(4989), 6, 39, "92" },
                    { 22, new DateTime(2020, 11, 27, 1, 50, 27, 260, DateTimeKind.Local).AddTicks(4884), 3, 50, "91" },
                    { 193, new DateTime(2020, 3, 24, 23, 26, 26, 433, DateTimeKind.Local).AddTicks(416), 6, 50, "24" },
                    { 196, new DateTime(2020, 6, 5, 7, 2, 21, 167, DateTimeKind.Local).AddTicks(2397), 6, 25, "41" },
                    { 177, new DateTime(2019, 12, 28, 21, 29, 47, 871, DateTimeKind.Local).AddTicks(9645), 1, 25, "67" },
                    { 37, new DateTime(2020, 2, 6, 20, 8, 47, 964, DateTimeKind.Local).AddTicks(640), 1, 33, "57" },
                    { 51, new DateTime(2020, 12, 9, 17, 14, 43, 817, DateTimeKind.Local).AddTicks(1682), 2, 33, "10" },
                    { 81, new DateTime(2020, 5, 1, 1, 12, 15, 944, DateTimeKind.Local).AddTicks(7320), 5, 33, "65" },
                    { 136, new DateTime(2020, 1, 29, 19, 43, 12, 381, DateTimeKind.Local).AddTicks(4046), 2, 33, "50" },
                    { 115, new DateTime(2020, 8, 15, 14, 35, 32, 136, DateTimeKind.Local).AddTicks(415), 1, 25, "91" },
                    { 179, new DateTime(2020, 3, 29, 21, 32, 45, 362, DateTimeKind.Local).AddTicks(5328), 4, 12, "62" },
                    { 128, new DateTime(2020, 11, 27, 4, 15, 13, 495, DateTimeKind.Local).AddTicks(5746), 5, 11, "59" },
                    { 164, new DateTime(2019, 12, 31, 20, 39, 33, 82, DateTimeKind.Local).AddTicks(4012), 4, 50, "71" },
                    { 165, new DateTime(2020, 3, 25, 15, 16, 32, 784, DateTimeKind.Local).AddTicks(8163), 5, 12, "88" },
                    { 110, new DateTime(2020, 8, 29, 23, 19, 26, 996, DateTimeKind.Local).AddTicks(2499), 2, 39, "64" },
                    { 19, new DateTime(2020, 8, 18, 21, 52, 11, 100, DateTimeKind.Local).AddTicks(4066), 1, 39, "65" },
                    { 139, new DateTime(2020, 9, 28, 23, 58, 8, 64, DateTimeKind.Local).AddTicks(8925), 4, 19, "94" },
                    { 10, new DateTime(2020, 11, 6, 9, 14, 50, 864, DateTimeKind.Local).AddTicks(9406), 2, 27, "69" },
                    { 138, new DateTime(2020, 6, 6, 5, 43, 4, 287, DateTimeKind.Local).AddTicks(7484), 4, 19, "100" },
                    { 8, new DateTime(2020, 7, 10, 7, 30, 50, 129, DateTimeKind.Local).AddTicks(1639), 4, 19, "96" },
                    { 14, new DateTime(2020, 8, 13, 2, 46, 45, 645, DateTimeKind.Local).AddTicks(2231), 1, 27, "49" },
                    { 61, new DateTime(2020, 4, 24, 15, 57, 36, 453, DateTimeKind.Local).AddTicks(5304), 1, 27, "69" },
                    { 77, new DateTime(2020, 12, 12, 10, 4, 56, 765, DateTimeKind.Local).AddTicks(1134), 3, 27, "99" },
                    { 82, new DateTime(2020, 1, 19, 17, 52, 29, 117, DateTimeKind.Local).AddTicks(4148), 6, 27, "94" },
                    { 118, new DateTime(2020, 10, 1, 5, 32, 35, 147, DateTimeKind.Local).AddTicks(5275), 3, 27, "62" },
                    { 156, new DateTime(2020, 7, 2, 22, 25, 41, 165, DateTimeKind.Local).AddTicks(7471), 3, 27, "23" },
                    { 96, new DateTime(2020, 6, 10, 14, 57, 22, 240, DateTimeKind.Local).AddTicks(4629), 1, 39, "70" },
                    { 188, new DateTime(2020, 4, 5, 5, 26, 52, 310, DateTimeKind.Local).AddTicks(4812), 3, 27, "33" },
                    { 11, new DateTime(2020, 9, 9, 14, 8, 7, 796, DateTimeKind.Local).AddTicks(963), 6, 38, "51" },
                    { 42, new DateTime(2020, 9, 8, 14, 32, 41, 236, DateTimeKind.Local).AddTicks(7874), 2, 38, "45" },
                    { 55, new DateTime(2020, 6, 30, 20, 40, 17, 923, DateTimeKind.Local).AddTicks(3570), 1, 38, "36" },
                    { 59, new DateTime(2020, 7, 23, 19, 57, 7, 544, DateTimeKind.Local).AddTicks(6883), 1, 38, "66" },
                    { 79, new DateTime(2020, 10, 12, 4, 14, 27, 954, DateTimeKind.Local).AddTicks(4013), 2, 38, "27" },
                    { 74, new DateTime(2020, 6, 5, 7, 38, 52, 1, DateTimeKind.Local).AddTicks(4650), 3, 2, "22" },
                    { 13, new DateTime(2020, 5, 28, 9, 29, 20, 567, DateTimeKind.Local).AddTicks(4053), 3, 2, "63" },
                    { 198, new DateTime(2020, 3, 27, 10, 46, 31, 429, DateTimeKind.Local).AddTicks(9981), 5, 38, "26" },
                    { 195, new DateTime(2020, 12, 9, 1, 31, 40, 258, DateTimeKind.Local).AddTicks(9966), 6, 42, "90" },
                    { 58, new DateTime(2020, 10, 26, 11, 21, 33, 584, DateTimeKind.Local).AddTicks(5595), 2, 41, "75" },
                    { 191, new DateTime(2020, 1, 18, 11, 57, 51, 986, DateTimeKind.Local).AddTicks(218), 5, 27, "13" },
                    { 160, new DateTime(2020, 5, 25, 16, 1, 59, 456, DateTimeKind.Local).AddTicks(5297), 1, 12, "84" },
                    { 168, new DateTime(2020, 5, 1, 2, 58, 13, 545, DateTimeKind.Local).AddTicks(9783), 3, 19, "17" },
                    { 88, new DateTime(2020, 4, 10, 6, 12, 33, 470, DateTimeKind.Local).AddTicks(662), 6, 12, "34" },
                    { 145, new DateTime(2020, 7, 12, 23, 51, 55, 858, DateTimeKind.Local).AddTicks(1001), 4, 22, "92" },
                    { 90, new DateTime(2020, 5, 17, 6, 43, 23, 819, DateTimeKind.Local).AddTicks(9180), 4, 8, "45" },
                    { 80, new DateTime(2020, 11, 16, 2, 5, 5, 526, DateTimeKind.Local).AddTicks(7771), 3, 13, "83" },
                    { 28, new DateTime(2020, 12, 12, 23, 16, 55, 912, DateTimeKind.Local).AddTicks(3379), 1, 26, "78" },
                    { 71, new DateTime(2020, 7, 23, 1, 16, 10, 715, DateTimeKind.Local).AddTicks(7380), 3, 8, "78" },
                    { 6, new DateTime(2020, 5, 18, 0, 35, 52, 352, DateTimeKind.Local).AddTicks(5114), 1, 8, "88" },
                    { 117, new DateTime(2020, 12, 1, 6, 30, 3, 80, DateTimeKind.Local).AddTicks(5071), 5, 26, "58" },
                    { 66, new DateTime(2020, 4, 15, 18, 46, 11, 559, DateTimeKind.Local).AddTicks(6841), 1, 28, "88" },
                    { 93, new DateTime(2020, 7, 10, 8, 0, 44, 660, DateTimeKind.Local).AddTicks(6502), 5, 28, "15" },
                    { 107, new DateTime(2020, 8, 22, 6, 32, 21, 211, DateTimeKind.Local).AddTicks(5221), 4, 28, "100" },
                    { 123, new DateTime(2020, 4, 23, 18, 20, 28, 768, DateTimeKind.Local).AddTicks(4539), 4, 28, "99" },
                    { 134, new DateTime(2020, 8, 23, 16, 54, 25, 636, DateTimeKind.Local).AddTicks(6900), 2, 28, "88" },
                    { 175, new DateTime(2020, 1, 6, 4, 52, 33, 934, DateTimeKind.Local).AddTicks(4392), 4, 28, "19" },
                    { 185, new DateTime(2020, 3, 6, 13, 13, 39, 732, DateTimeKind.Local).AddTicks(5094), 4, 28, "10" },
                    { 192, new DateTime(2020, 5, 15, 1, 29, 24, 417, DateTimeKind.Local).AddTicks(2872), 5, 1, "89" },
                    { 190, new DateTime(2020, 2, 20, 0, 41, 40, 473, DateTimeKind.Local).AddTicks(1741), 6, 28, "74" },
                    { 63, new DateTime(2020, 8, 20, 1, 48, 31, 566, DateTimeKind.Local).AddTicks(3663), 3, 1, "40" },
                    { 60, new DateTime(2020, 4, 9, 13, 25, 45, 494, DateTimeKind.Local).AddTicks(127), 5, 1, "80" },
                    { 4, new DateTime(2020, 4, 17, 17, 27, 56, 310, DateTimeKind.Local).AddTicks(7175), 1, 30, "10" },
                    { 20, new DateTime(2020, 10, 13, 17, 12, 45, 757, DateTimeKind.Local).AddTicks(3377), 4, 30, "21" },
                    { 176, new DateTime(2020, 4, 8, 9, 37, 44, 732, DateTimeKind.Local).AddTicks(417), 3, 30, "27" },
                    { 2, new DateTime(2020, 9, 18, 15, 39, 52, 6, DateTimeKind.Local).AddTicks(7990), 3, 34, "96" },
                    { 5, new DateTime(2020, 8, 5, 17, 56, 28, 506, DateTimeKind.Local).AddTicks(5409), 3, 1, "28" },
                    { 122, new DateTime(2020, 4, 17, 16, 23, 33, 857, DateTimeKind.Local).AddTicks(3146), 2, 22, "58" },
                    { 121, new DateTime(2020, 5, 24, 0, 48, 56, 123, DateTimeKind.Local).AddTicks(5170), 6, 22, "85" },
                    { 75, new DateTime(2020, 7, 1, 8, 2, 26, 58, DateTimeKind.Local).AddTicks(1691), 6, 8, "24" },
                    { 50, new DateTime(2020, 8, 3, 18, 14, 55, 384, DateTimeKind.Local).AddTicks(6254), 6, 22, "30" },
                    { 105, new DateTime(2020, 1, 5, 3, 9, 21, 354, DateTimeKind.Local).AddTicks(9091), 1, 22, "38" },
                    { 142, new DateTime(2020, 6, 16, 2, 36, 41, 129, DateTimeKind.Local).AddTicks(1697), 6, 8, "54" },
                    { 132, new DateTime(2020, 10, 23, 6, 54, 55, 988, DateTimeKind.Local).AddTicks(4029), 6, 18, "89" },
                    { 91, new DateTime(2020, 7, 4, 21, 46, 25, 417, DateTimeKind.Local).AddTicks(9121), 1, 22, "58" },
                    { 174, new DateTime(2020, 5, 29, 21, 15, 20, 274, DateTimeKind.Local).AddTicks(1353), 1, 8, "19" },
                    { 103, new DateTime(2020, 4, 24, 2, 4, 3, 866, DateTimeKind.Local).AddTicks(6006), 5, 22, "65" },
                    { 99, new DateTime(2020, 8, 15, 6, 48, 41, 721, DateTimeKind.Local).AddTicks(1510), 2, 22, "15" },
                    { 18, new DateTime(2020, 2, 21, 23, 29, 38, 143, DateTimeKind.Local).AddTicks(1264), 3, 22, "21" },
                    { 148, new DateTime(2020, 1, 5, 1, 34, 46, 184, DateTimeKind.Local).AddTicks(2405), 4, 18, "72" },
                    { 70, new DateTime(2020, 5, 18, 3, 19, 1, 234, DateTimeKind.Local).AddTicks(8460), 5, 12, "39" }
                });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[,]
                {
                    { 9, 6 },
                    { 23, 1 },
                    { 23, 6 },
                    { 12, 1 },
                    { 19, 5 },
                    { 25, 1 },
                    { 46, 2 },
                    { 25, 6 },
                    { 49, 6 },
                    { 49, 2 },
                    { 46, 5 },
                    { 1, 1 },
                    { 1, 4 },
                    { 19, 3 },
                    { 21, 1 },
                    { 24, 3 },
                    { 24, 4 },
                    { 42, 1 },
                    { 9, 1 },
                    { 42, 6 },
                    { 29, 2 },
                    { 29, 6 },
                    { 15, 4 },
                    { 15, 2 },
                    { 36, 3 },
                    { 8, 2 },
                    { 8, 6 },
                    { 36, 6 },
                    { 48, 4 },
                    { 2, 5 },
                    { 2, 2 },
                    { 48, 1 },
                    { 12, 6 },
                    { 43, 6 },
                    { 6, 5 },
                    { 27, 6 },
                    { 32, 6 },
                    { 11, 4 },
                    { 11, 3 },
                    { 13, 6 },
                    { 13, 1 },
                    { 18, 5 },
                    { 18, 3 },
                    { 22, 4 },
                    { 22, 3 },
                    { 31, 3 },
                    { 31, 4 },
                    { 20, 2 },
                    { 20, 5 },
                    { 26, 5 },
                    { 26, 3 },
                    { 14, 2 },
                    { 14, 6 },
                    { 28, 5 },
                    { 28, 3 },
                    { 4, 2 },
                    { 4, 6 },
                    { 3, 5 },
                    { 30, 4 },
                    { 30, 1 },
                    { 34, 4 },
                    { 34, 1 },
                    { 41, 5 },
                    { 41, 1 },
                    { 43, 3 },
                    { 32, 3 },
                    { 21, 6 },
                    { 35, 6 },
                    { 33, 3 },
                    { 27, 1 },
                    { 17, 3 },
                    { 17, 5 },
                    { 16, 1 },
                    { 16, 5 },
                    { 38, 6 },
                    { 38, 2 },
                    { 7, 3 },
                    { 7, 6 },
                    { 39, 4 },
                    { 39, 1 },
                    { 6, 1 },
                    { 5, 3 },
                    { 5, 4 },
                    { 45, 1 },
                    { 45, 6 },
                    { 47, 6 },
                    { 47, 3 },
                    { 44, 2 },
                    { 44, 6 },
                    { 50, 5 },
                    { 50, 2 },
                    { 40, 3 },
                    { 40, 6 },
                    { 10, 3 },
                    { 10, 6 },
                    { 37, 2 },
                    { 37, 5 },
                    { 33, 6 },
                    { 35, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux" },
                values: new object[,]
                {
                    { 3, 2021, "2 التأثير لهدا الإنجاز", 30, "2 بعد الإنجازات لبعض الأنشطة ", "2 وضعية التنفيد لهدا الإنجاز", "2 معدل الإنجاز لهدا الإنجاز" },
                    { 19, 2026, "18 التأثير لهدا الإنجاز", 45, "18 بعد الإنجازات لبعض الأنشطة ", "18 وضعية التنفيد لهدا الإنجاز", "18 معدل الإنجاز لهدا الإنجاز" },
                    { 17, 2025, "16 التأثير لهدا الإنجاز", 48, "16 بعد الإنجازات لبعض الأنشطة ", "16 وضعية التنفيد لهدا الإنجاز", "16 معدل الإنجاز لهدا الإنجاز" },
                    { 35, 2019, "34 التأثير لهدا الإنجاز", 48, "34 بعد الإنجازات لبعض الأنشطة ", "34 وضعية التنفيد لهدا الإنجاز", "34 معدل الإنجاز لهدا الإنجاز" },
                    { 39, 2022, "38 التأثير لهدا الإنجاز", 48, "38 بعد الإنجازات لبعض الأنشطة ", "38 وضعية التنفيد لهدا الإنجاز", "38 معدل الإنجاز لهدا الإنجاز" },
                    { 43, 2025, "42 التأثير لهدا الإنجاز", 48, "42 بعد الإنجازات لبعض الأنشطة ", "42 وضعية التنفيد لهدا الإنجاز", "42 معدل الإنجاز لهدا الإنجاز" },
                    { 6, 2019, "5 التأثير لهدا الإنجاز", 13, "5 بعد الإنجازات لبعض الأنشطة ", "5 وضعية التنفيد لهدا الإنجاز", "5 معدل الإنجاز لهدا الإنجاز" },
                    { 32, 2018, "31 التأثير لهدا الإنجاز", 11, "31 بعد الإنجازات لبعض الأنشطة ", "31 وضعية التنفيد لهدا الإنجاز", "31 معدل الإنجاز لهدا الإنجاز" },
                    { 41, 2025, "40 التأثير لهدا الإنجاز", 40, "40 بعد الإنجازات لبعض الأنشطة ", "40 وضعية التنفيد لهدا الإنجاز", "40 معدل الإنجاز لهدا الإنجاز" },
                    { 2, 2029, "1 التأثير لهدا الإنجاز", 42, "1 بعد الإنجازات لبعض الأنشطة ", "1 وضعية التنفيد لهدا الإنجاز", "1 معدل الإنجاز لهدا الإنجاز" },
                    { 4, 2021, "3 التأثير لهدا الإنجاز", 42, "3 بعد الإنجازات لبعض الأنشطة ", "3 وضعية التنفيد لهدا الإنجاز", "3 معدل الإنجاز لهدا الإنجاز" },
                    { 28, 2020, "27 التأثير لهدا الإنجاز", 42, "27 بعد الإنجازات لبعض الأنشطة ", "27 وضعية التنفيد لهدا الإنجاز", "27 معدل الإنجاز لهدا الإنجاز" },
                    { 24, 2021, "23 التأثير لهدا الإنجاز", 12, "23 بعد الإنجازات لبعض الأنشطة ", "23 وضعية التنفيد لهدا الإنجاز", "23 معدل الإنجاز لهدا الإنجاز" },
                    { 33, 2024, "32 التأثير لهدا الإنجاز", 20, "32 بعد الإنجازات لبعض الأنشطة ", "32 وضعية التنفيد لهدا الإنجاز", "32 معدل الإنجاز لهدا الإنجاز" },
                    { 20, 2023, "19 التأثير لهدا الإنجاز", 26, "19 بعد الإنجازات لبعض الأنشطة ", "19 وضعية التنفيد لهدا الإنجاز", "19 معدل الإنجاز لهدا الإنجاز" },
                    { 34, 2025, "33 التأثير لهدا الإنجاز", 9, "33 بعد الإنجازات لبعض الأنشطة ", "33 وضعية التنفيد لهدا الإنجاز", "33 معدل الإنجاز لهدا الإنجاز" },
                    { 9, 2021, "8 التأثير لهدا الإنجاز", 50, "8 بعد الإنجازات لبعض الأنشطة ", "8 وضعية التنفيد لهدا الإنجاز", "8 معدل الإنجاز لهدا الإنجاز" },
                    { 22, 2028, "21 التأثير لهدا الإنجاز", 50, "21 بعد الإنجازات لبعض الأنشطة ", "21 وضعية التنفيد لهدا الإنجاز", "21 معدل الإنجاز لهدا الإنجاز" },
                    { 10, 2027, "9 التأثير لهدا الإنجاز", 3, "9 بعد الإنجازات لبعض الأنشطة ", "9 وضعية التنفيد لهدا الإنجاز", "9 معدل الإنجاز لهدا الإنجاز" },
                    { 42, 2023, "41 التأثير لهدا الإنجاز", 24, "41 بعد الإنجازات لبعض الأنشطة ", "41 وضعية التنفيد لهدا الإنجاز", "41 معدل الإنجاز لهدا الإنجاز" },
                    { 7, 2019, "6 التأثير لهدا الإنجاز", 39, "6 بعد الإنجازات لبعض الأنشطة ", "6 وضعية التنفيد لهدا الإنجاز", "6 معدل الإنجاز لهدا الإنجاز" },
                    { 23, 2029, "22 التأثير لهدا الإنجاز", 39, "22 بعد الإنجازات لبعض الأنشطة ", "22 وضعية التنفيد لهدا الإنجاز", "22 معدل الإنجاز لهدا الإنجاز" },
                    { 13, 2025, "12 التأثير لهدا الإنجاز", 45, "12 بعد الإنجازات لبعض الأنشطة ", "12 وضعية التنفيد لهدا الإنجاز", "12 معدل الإنجاز لهدا الإنجاز" },
                    { 40, 2029, "39 التأثير لهدا الإنجاز", 43, "39 بعد الإنجازات لبعض الأنشطة ", "39 وضعية التنفيد لهدا الإنجاز", "39 معدل الإنجاز لهدا الإنجاز" },
                    { 36, 2029, "35 التأثير لهدا الإنجاز", 21, "35 بعد الإنجازات لبعض الأنشطة ", "35 وضعية التنفيد لهدا الإنجاز", "35 معدل الإنجاز لهدا الإنجاز" },
                    { 45, 2027, "44 التأثير لهدا الإنجاز", 41, "44 بعد الإنجازات لبعض الأنشطة ", "44 وضعية التنفيد لهدا الإنجاز", "44 معدل الإنجاز لهدا الإنجاز" },
                    { 46, 2022, "45 التأثير لهدا الإنجاز", 31, "45 بعد الإنجازات لبعض الأنشطة ", "45 وضعية التنفيد لهدا الإنجاز", "45 معدل الإنجاز لهدا الإنجاز" },
                    { 47, 2026, "46 التأثير لهدا الإنجاز", 5, "46 بعد الإنجازات لبعض الأنشطة ", "46 وضعية التنفيد لهدا الإنجاز", "46 معدل الإنجاز لهدا الإنجاز" },
                    { 15, 2027, "14 التأثير لهدا الإنجاز", 19, "14 بعد الإنجازات لبعض الأنشطة ", "14 وضعية التنفيد لهدا الإنجاز", "14 معدل الإنجاز لهدا الإنجاز" },
                    { 30, 2020, "29 التأثير لهدا الإنجاز", 19, "29 بعد الإنجازات لبعض الأنشطة ", "29 وضعية التنفيد لهدا الإنجاز", "29 معدل الإنجاز لهدا الإنجاز" },
                    { 27, 2026, "26 التأثير لهدا الإنجاز", 15, "26 بعد الإنجازات لبعض الأنشطة ", "26 وضعية التنفيد لهدا الإنجاز", "26 معدل الإنجاز لهدا الإنجاز" },
                    { 37, 2024, "36 التأثير لهدا الإنجاز", 15, "36 بعد الإنجازات لبعض الأنشطة ", "36 وضعية التنفيد لهدا الإنجاز", "36 معدل الإنجاز لهدا الإنجاز" },
                    { 12, 2029, "11 التأثير لهدا الإنجاز", 46, "11 بعد الإنجازات لبعض الأنشطة ", "11 وضعية التنفيد لهدا الإنجاز", "11 معدل الإنجاز لهدا الإنجاز" },
                    { 48, 2029, "47 التأثير لهدا الإنجاز", 46, "47 بعد الإنجازات لبعض الأنشطة ", "47 وضعية التنفيد لهدا الإنجاز", "47 معدل الإنجاز لهدا الإنجاز" },
                    { 14, 2018, "13 التأثير لهدا الإنجاز", 25, "13 بعد الإنجازات لبعض الأنشطة ", "13 وضعية التنفيد لهدا الإنجاز", "13 معدل الإنجاز لهدا الإنجاز" },
                    { 18, 2025, "17 التأثير لهدا الإنجاز", 25, "17 بعد الإنجازات لبعض الأنشطة ", "17 وضعية التنفيد لهدا الإنجاز", "17 معدل الإنجاز لهدا الإنجاز" },
                    { 1, 2019, "0 التأثير لهدا الإنجاز", 4, "0 بعد الإنجازات لبعض الأنشطة ", "0 وضعية التنفيد لهدا الإنجاز", "0 معدل الإنجاز لهدا الإنجاز" },
                    { 38, 2021, "37 التأثير لهدا الإنجاز", 47, "37 بعد الإنجازات لبعض الأنشطة ", "37 وضعية التنفيد لهدا الإنجاز", "37 معدل الإنجاز لهدا الإنجاز" },
                    { 16, 2021, "15 التأثير لهدا الإنجاز", 37, "15 بعد الإنجازات لبعض الأنشطة ", "15 وضعية التنفيد لهدا الإنجاز", "15 معدل الإنجاز لهدا الإنجاز" },
                    { 11, 2026, "10 التأثير لهدا الإنجاز", 14, "10 بعد الإنجازات لبعض الأنشطة ", "10 وضعية التنفيد لهدا الإنجاز", "10 معدل الإنجاز لهدا الإنجاز" },
                    { 26, 2027, "25 التأثير لهدا الإنجاز", 18, "25 بعد الإنجازات لبعض الأنشطة ", "25 وضعية التنفيد لهدا الإنجاز", "25 معدل الإنجاز لهدا الإنجاز" },
                    { 25, 2018, "24 التأثير لهدا الإنجاز", 16, "24 بعد الإنجازات لبعض الأنشطة ", "24 وضعية التنفيد لهدا الإنجاز", "24 معدل الإنجاز لهدا الإنجاز" },
                    { 44, 2018, "43 التأثير لهدا الإنجاز", 16, "43 بعد الإنجازات لبعض الأنشطة ", "43 وضعية التنفيد لهدا الإنجاز", "43 معدل الإنجاز لهدا الإنجاز" },
                    { 50, 2023, "49 التأثير لهدا الإنجاز", 28, "49 بعد الإنجازات لبعض الأنشطة ", "49 وضعية التنفيد لهدا الإنجاز", "49 معدل الإنجاز لهدا الإنجاز" },
                    { 49, 2027, "48 التأثير لهدا الإنجاز", 35, "48 بعد الإنجازات لبعض الأنشطة ", "48 وضعية التنفيد لهدا الإنجاز", "48 معدل الإنجاز لهدا الإنجاز" },
                    { 5, 2025, "4 التأثير لهدا الإنجاز", 41, "4 بعد الإنجازات لبعض الأنشطة ", "4 وضعية التنفيد لهدا الإنجاز", "4 معدل الإنجاز لهدا الإنجاز" },
                    { 21, 2026, "20 التأثير لهدا الإنجاز", 41, "20 بعد الإنجازات لبعض الأنشطة ", "20 وضعية التنفيد لهدا الإنجاز", "20 معدل الإنجاز لهدا الإنجاز" },
                    { 31, 2024, "30 التأثير لهدا الإنجاز", 41, "30 بعد الإنجازات لبعض الأنشطة ", "30 وضعية التنفيد لهدا الإنجاز", "30 معدل الإنجاز لهدا الإنجاز" },
                    { 8, 2023, "7 التأثير لهدا الإنجاز", 34, "7 بعد الإنجازات لبعض الأنشطة ", "7 وضعية التنفيد لهدا الإنجاز", "7 معدل الإنجاز لهدا الإنجاز" },
                    { 29, 2019, "28 التأثير لهدا الإنجاز", 4, "28 بعد الإنجازات لبعض الأنشطة ", "28 وضعية التنفيد لهدا الإنجاز", "28 معدل الإنجاز لهدا الإنجاز" }
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

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
                name: "OrganismeUsers",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false),
                    IdOrganisme = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganismeUsers", x => new { x.IdUser, x.IdOrganisme });
                    table.ForeignKey(
                        name: "FK_OrganismeUsers_Organismes_IdOrganisme",
                        column: x => x.IdOrganisme,
                        principalTable: "Organismes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganismeUsers_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
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
                name: "Responsables",
                columns: table => new
                {
                    IdMesure = table.Column<int>(nullable: false),
                    IdOrganisme = table.Column<int>(nullable: false),
                    IsPrincipale = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsables", x => new { x.IdMesure, x.IdOrganisme });
                    table.ForeignKey(
                        name: "FK_Responsables_Mesures_IdMesure",
                        column: x => x.IdMesure,
                        principalTable: "Mesures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responsables_Organismes_IdOrganisme",
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
                    { 1, "الحكامة والديمقراطية" },
                    { 2, "الحقوق الاقتصادية والاجتماعية والثقافية والبيئية" },
                    { 3, "حماية الحقوق الفئوية والنهوض بها" },
                    { 4, "الإطار القانوني والمؤسساتي" }
                });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "Id", "DateEvenement", "Pv", "Type" },
                values: new object[,]
                {
                    { 20, new DateTime(2021, 1, 30, 16, 21, 32, 544, DateTimeKind.Local).AddTicks(4021), "محضر رقم 20", "اللجنة رقم 20" },
                    { 19, new DateTime(2020, 2, 23, 20, 11, 10, 5, DateTimeKind.Local).AddTicks(4665), "محضر رقم 19", "اللجنة رقم 19" },
                    { 17, new DateTime(2021, 1, 12, 17, 21, 54, 575, DateTimeKind.Local).AddTicks(2104), "محضر رقم 17", "اللجنة رقم 17" },
                    { 16, new DateTime(2021, 1, 30, 1, 29, 52, 455, DateTimeKind.Local).AddTicks(835), "محضر رقم 16", "اللجنة رقم 16" },
                    { 15, new DateTime(2020, 7, 25, 0, 46, 35, 488, DateTimeKind.Local).AddTicks(2390), "محضر رقم 15", "اللجنة رقم 15" },
                    { 14, new DateTime(2020, 6, 2, 12, 51, 48, 4, DateTimeKind.Local).AddTicks(8904), "محضر رقم 14", "اللجنة رقم 14" },
                    { 13, new DateTime(2020, 11, 6, 13, 20, 10, 688, DateTimeKind.Local).AddTicks(9167), "محضر رقم 13", "اللجنة رقم 13" },
                    { 12, new DateTime(2020, 5, 23, 21, 25, 38, 196, DateTimeKind.Local).AddTicks(789), "محضر رقم 12", "اللجنة رقم 12" },
                    { 11, new DateTime(2020, 9, 9, 18, 52, 56, 645, DateTimeKind.Local).AddTicks(4858), "محضر رقم 11", "اللجنة رقم 11" },
                    { 18, new DateTime(2020, 12, 1, 1, 8, 43, 301, DateTimeKind.Local).AddTicks(3151), "محضر رقم 18", "اللجنة رقم 18" },
                    { 9, new DateTime(2020, 12, 10, 6, 30, 15, 852, DateTimeKind.Local).AddTicks(2023), "محضر رقم 9", "اللجنة رقم 9" },
                    { 8, new DateTime(2020, 5, 26, 23, 45, 2, 20, DateTimeKind.Local).AddTicks(4817), "محضر رقم 8", "اللجنة رقم 8" },
                    { 7, new DateTime(2020, 12, 8, 15, 43, 47, 286, DateTimeKind.Local).AddTicks(8831), "محضر رقم 7", "اللجنة رقم 7" },
                    { 6, new DateTime(2020, 10, 23, 20, 9, 57, 703, DateTimeKind.Local).AddTicks(9877), "محضر رقم 6", "اللجنة رقم 6" },
                    { 5, new DateTime(2020, 5, 18, 21, 42, 25, 957, DateTimeKind.Local).AddTicks(6219), "محضر رقم 5", "اللجنة رقم 5" },
                    { 4, new DateTime(2020, 12, 31, 11, 31, 31, 61, DateTimeKind.Local).AddTicks(7136), "محضر رقم 4", "اللجنة رقم 4" },
                    { 3, new DateTime(2020, 4, 26, 23, 10, 36, 774, DateTimeKind.Local).AddTicks(9537), "محضر رقم 3", "اللجنة رقم 3" },
                    { 10, new DateTime(2020, 12, 6, 17, 11, 7, 476, DateTimeKind.Local).AddTicks(444), "محضر رقم 10", "اللجنة رقم 10" },
                    { 2, new DateTime(2020, 6, 26, 20, 14, 38, 418, DateTimeKind.Local).AddTicks(1764), "محضر رقم 2", "اللجنة رقم 2" },
                    { 1, new DateTime(2020, 8, 13, 20, 50, 41, 57, DateTimeKind.Local).AddTicks(1929), "محضر رقم 1", "اللجنة رقم 1" }
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
                    { 197, "التقارير السنوية", "غير معروف" },
                    { 202, "عدد نقط الارتكاز  المحدثة", "غير معروف" },
                    { 201, "اعتماد السياسة  ", "غير معروف" },
                    { 200, "نشر الدليل", "غير معروف" },
                    { 199, "عدد القرارات", "غير معروف" },
                    { 198, "انخفاض نسب وحالات العنف بالوسط التربوي", "غير معروف" },
                    { 196, "نسبة الجماعات الترابية المتوفرة على برامج في مجال الطفولة ", "غير معروف" },
                    { 189, " عدد آليات التتبع المفعلة", "غير معروف" },
                    { 194, "عدد الشراكات المفعلة ", "غير معروف" },
                    { 193, "نسبة الأطفال المستفيدين ", "غير معروف" },
                    { 192, " دورية انعقاد اجتماعات اللجنة", "غير معروف" },
                    { 191, "نسبة تنفيذ البرنامج", "غير معروف" },
                    { 190, " النشر في الجريدة الرسمية ", "غير معروف" },
                    { 203, "عدد التقارير        والبحوث والدراسات", "غير معروف" },
                    { 195, "عدد الجهات التي تتوفر على أجهزة ترابية مندمجة لحماية الطفولة", "غير معروف" },
                    { 204, "عدد المبادرات والمشاريع المنفذة ", "غير معروف" },
                    { 218, "عدد البرامج التي اعتمدت مقاربة التنمية الدامجة", "غير معروف" },
                    { 206, "عدد المصوغات المعدة", "غير معروف" },
                    { 221, " النشر  في الجريدة الرسمية", "غير معروف" },
                    { 220, "نسبةتنفيذالمخطط", "غير معروف" },
                    { 219, "نسبة تجهيز المحاكم بالولوجيات", "غير معروف" },
                    { 188, "عدد آليات التتبع المفعلة ", "غير معروف" },
                    { 217, "نسبة تنفيذ البرنامج الوطني  مدن ولوجة", "غير معروف" },
                    { 216, "نسبة إدماج الأشخاص في وضعية إعاقة خريجي التكوين المهني", "غير معروف" },
                    { 215, "نسبة الإدماج المهني", "غير معروف" },
                    { 214, "نسبة التشغيل", "غير معروف" },
                    { 213, "ارتفاع نسبة التوظيف", "غير معروف" },
                    { 212, "نسبة الأطفال الممدرسين من الأطفال في وضعية إعاقة", "غير معروف" },
                    { 211, "عدد المناهج المنقحة", "غير معروف" },
                    { 210, "نسبة الأطفال المتمدرسين والمتمدرسات من الأطفال في وضعية إعاقة", "غير معروف" },
                    { 209, " عدد نقط الارتكاز المركزية والجهوية المفعلة", "غير معروف" },
                    { 208, "إيداع صكوك المصادقة ", "غير معروف" },
                    { 207, "نسبة انخفاض معدل الامية ", "غير معروف" },
                    { 205, "قاعدة معلومات مفعلة", "غير معروف" },
                    { 187, "نسبة تفعيل دفاتر التحملات", "غير معروف" },
                    { 173, "تنصيبأعضاءالآلية", "غير معروف" },
                    { 185, "نسبة التراجع  ", "غير معروف" },
                    { 164, "عدد التقارير المنجزة ", "غير معروف" },
                    { 163, "عدد المقاولات التي اعتمدت ميثاقا في مجال حقوق الإنسان", "غير معروف" },
                    { 162, "عدد المؤسسات المستفيدة", "غير معروف" },
                    { 161, "تطور عدد الكتب المدرسية المتضمنة للتربية البيئية", "غير معروف" },
                    { 160, " عدد وحدات التدريس في مجال البيئة ", "غير معروف" },
                    { 159, " عددالبحوثالعلميةالمنجزة", "غير معروف" },
                    { 165, "عدد المشاركات ", "غير معروف" },
                    { 158, "عدد القضايا المتعلقة بالأضرار البيئية ", "غير معروف" },
                    { 156, "نسبة الإنجاز", "غير معروف" },
                    { 155, " نسبة النفايات المثمنة بالنسبة لكل منظومة", "غير معروف" },
                    { 154, " عدد وحدات التثمين المحدثة", "غير معروف" },
                    { 153, " عدد آليات المشاركة المواطنة المفعلة", "غير معروف" },
                    { 152, " نسبة ولوج المواطنين والمواطنات للمعلومة البيئية", "غير معروف" },
                    { 151, "عدد مصالح القرب المحدثة", "غير معروف" },
                    { 157, "عدد آليات التنسيق المفعلة  ", "غير معروف" },
                    { 166, "نسبة المقاولات المعتمدة للمدونة في مجال حقوق الإنسان  ", "غير معروف" },
                    { 167, "عدد التقارير", "غير معروف" },
                    { 169, "نسبة مؤسسات الرعاية الاجتماعية التي تعتمد معايير الجودة التي تمت ملائمتها مع القانون 65.15", "غير معروف" },
                    { 184, "تراجع نسبة تشغيل الأطفال", "غير معروف" },
                    { 183, "تراجع عدد الأطفال الذين وجدوا صعوبات في اختيار الأسماء الشخصية", "غير معروف" },
                    { 182, "عدد الدورات التحسيسية المنظمة والدعامات المنجزة ", "غير معروف" },
                    { 181, "عدد البرامج الموجهة لحماية الطفل في وسائل الإعلام", "غير معروف" },
                    { 180, "نسبة تراجع تزويج القاصرات ", "غير معروف" },
                    { 179, "نسبة الأطفال المشمولين بالمساعدة الاجتماعية والقانونية", "غير معروف" },
                    { 178, "عدد الأطفال المسجلين", "غير معروف" },
                    { 177, "مقترحات عمل اللجنة", "غير معروف" },
                    { 176, " عدد المؤشرات.", "غير معروف" },
                    { 175, " نسبة العمال المنزليين الخاضعين لعقود العمل وفق القانون 19.12", "غير معروف" },
                    { 174, " عدد المستهدفين من الحملة التحسيسية", "غير معروف" },
                    { 222, " عدد الأشخاص المستفيدين من ذوي الإعاقة  ", "غير معروف" },
                    { 172, "تنصيب رئيس وأعضاء المجلس", "غير معروف" },
                    { 171, " عدد التقارير", "غير معروف" },
                    { 170, "عدد الأنظمةالمعلوماتية", "غير معروف" },
                    { 186, "عدد المؤسسات التي تم تأهيلها", "غير معروف" },
                    { 223, "عدد المؤسسات المؤهلة", "غير معروف" },
                    { 237, "عدد النوادي والفضاءات المحدثة والمؤهلة", "غير معروف" },
                    { 225, "نسبة ارتفاع موارد الصندوق", "غير معروف" },
                    { 277, "عدد الفضاءات المحدثة", "غير معروف" },
                    { 276, "عدد المنشورات", "غير معروف" },
                    { 275, "عددالإصدارات المنشورة", "غير معروف" },
                    { 274, "تراجع نسبة الفقر لدى النساء ", "غير معروف" },
                    { 273, "نسبة ارتفاع المقاولات المحدثة من طرف النساء ", "غير معروف" },
                    { 272, "عدد التقارير المنجرة", "غير معروف" },
                    { 278, "نسبة تراجع الصور النمطية", "غير معروف" },
                    { 271, "عدد البرامج والمبادرات المفعلة", "غير معروف" },
                    { 269, "عدد البرامج الدامجة لمقاربة النوع", "غير معروف" },
                    { 268, "عدد اللجان المفعلة", "غير معروف" },
                    { 267, "عدد الإجراءات المفعلة", "غير معروف" },
                    { 266, "مصنفات الاجتهادات العلمية/الفقهيةوالقضائية", "غير معروف" },
                    { 265, "عدد الأعمال الموثقة والمنشورة", "غير معروف" },
                    { 264, "عدد الاجتهادات القضائية المنشورة ", "غير معروف" },
                    { 270, "الأحكام القضائية ذات الصلة ", "غير معروف" },
                    { 279, "عدد الدورات التكوينية والدعامات المهنية المنجزة ", "غير معروف" },
                    { 280, "قرارات الهيئة العليا بخصوص المناصفة", "غير معروف" },
                    { 281, "عدد البرامج والشراكات والدعامات المنجزة", "غير معروف" },
                    { 296, "عدد اللجان المنظمة للتقصي", "غير معروف" },
                    { 295, "نسبة تنفيذ الاحكام القضائية", "غير معروف" },
                    { 294, "ارتفاع نسبة الرضا", "غير معروف" },
                    { 293, "ارتفاع نسبة الرضا ", "غير معروف" },
                    { 292, "تقارير الهيئة", "غير معروف" },
                    { 291, "نسبة تفعيل الهيكل التنظيمي  ", "غير معروف" },
                    { 290, "نسبة الإيداع", "غير معروف" },
                    { 289, "عدد الأرشيفات المسلمة", "غير معروف" },
                    { 288, "حجم الأرصدة المسترجعة", "غير معروف" },
                    { 287, "نسبة التفعيل", "غير معروف" },
                    { 286, "عدد القصور والقصبات المرممة", "غير معروف" },
                    { 285, "عدد المصنفات التراثية   ", "غير معروف" },
                    { 284, "الانضمام إلى الاتفاقيات الدولية", "غير معروف" },
                    { 283, " عدد المستفيدين ", "غير معروف" },
                    { 282, "عدد البرامج والدورات التكوينية", "غير معروف" },
                    { 263, "عدد الشكايات المعالجة", "غير معروف" },
                    { 262, "عدد القضاة المتخصصين", "غير معروف" },
                    { 261, "ارتفاع مستوى الرضا على النجاعة القضائية", "غير معروف" },
                    { 260, "عدد الشراكات المنفذة", "غير معروف" },
                    { 240, "عدد الخريجين", "غير معروف" },
                    { 239, "عدد المسنين المستفيدين من خدمات التكفل ", "غير معروف" },
                    { 238, "عدد المؤشرات", "غير معروف" },
                    { 150, " اعتماد السياسة الوطنية ", "غير معروف" },
                    { 236, "نسبة الجماعات الترابية المتوفرة على برامج موجهة للأشخاص المسنين ", "غير معروف" },
                    { 235, "عدد المراكز التي اعتمدت معايير الجودة", "غير معروف" },
                    { 234, "المصادقة على الإطار الاستراتيجيالوطني", "غير معروف" },
                    { 233, "نسبة إدماج لغة الإشارة ", "غير معروف" },
                    { 232, "عدد المراكز المحدثة", "غير معروف" },
                    { 231, "عدد الفضاءاتالمؤهلة ", "غير معروف" },
                    { 230, "عدد المبادرات النوعية", "غير معروف" },
                    { 229, "اعتماد الإطار المعياري", "غير معروف" },
                    { 228, " تقارير دورية ", "غير معروف" },
                    { 227, " اعتماد النظام الوطني ", "غير معروف" },
                    { 226, "نسبة ارتفاع المستفيدين", "غير معروف" },
                    { 241, "عدد البرامج ", "غير معروف" },
                    { 224, "عدد المؤسسات المحدثة", "غير معروف" },
                    { 242, "عدد اللقاءات والتصورات المبلورة", "غير معروف" },
                    { 244, "عدد الاتفاقيات المصادق عليها", "غير معروف" },
                    { 259, "بنك محدث", "غير معروف" },
                    { 258, "مرصد محدث", "غير معروف" },
                    { 257, "الاتفاقيات موضوع الانخراط ", "غير معروف" },
                    { 256, "عدد زيارات المساطر الخاصة  ", "غير معروف" },
                    { 255, " التقارير المقدمة ", "غير معروف" },
                    { 254, " الصكوك المصادق والمنظم إليها", "غير معروف" },
                    { 253, "عدد البرامج المفعلة", "غير معروف" },
                    { 252, "عدد التقارير المنشورة", "غير معروف" },
                    { 251, "عدد الأنشطة حسب النوع والتخصص", "غير معروف" },
                    { 250, "نسبة الاستجابة لانتظارات المغاربة المقيمين بالخارج", "غير معروف" },
                    { 249, "عدد الاجتماعات التنسيقية", "غير معروف" },
                    { 248, "تقارير دورية", "غير معروف" },
                    { 247, "نسبة الاستجابة لإنتظارات مغاربة العالم", "غير معروف" },
                    { 246, "النص التنظيمي المحدث للمرصد منشور في الجريدة الرسمية", "غير معروف" },
                    { 245, "عدد البرامج المنجزة", "غير معروف" },
                    { 243, "عدد الاتفاقيات التي تم تطويرها", "غير معروف" },
                    { 149, " اعتماد المخطط الوطني ", "غير معروف" },
                    { 168, " عدد المبادرات  المفعلة", "غير معروف" },
                    { 147, "عدد المشاريع المدعمة", "غير معروف" },
                    { 52, "عدد فضاءات الاستقبال المجهزة", "غير معروف" },
                    { 51, "إصدار الدليل", "غير معروف" },
                    { 50, "نسبة تطور الموارد (المالية والبشرية)", "غير معروف" },
                    { 49, "نسبة تأمين التغذية ", "غير معروف" },
                    { 48, "ارتفاع نسبة التصريحات الموثقة ", "غير معروف" },
                    { 47, "نسبة التدخلات الموثقة سمعيا وبصريا من مجموع التدخلات", "غير معروف" },
                    { 53, "عدد الدلائل المنشورة", "غير معروف" },
                    { 46, "انخفاض حالات استعمال القوة ", "غير معروف" },
                    { 44, "عدد تصاميم التهيئة المتضمنة للبعد الأمني", "غير معروف" },
                    { 43, "النشر في الجريدة الرسمية ", "غير معروف" },
                    { 42, "عدد المستفيدين ", "غير معروف" },
                    { 148, "اعتماد الإطار المرجعي", "غير معروف" },
                    { 40, "نسبة الاستهداف ", "غير معروف" },
                    { 39, "عدد المبادرات المفعلة", "غير معروف" },
                    { 45, "ارتفاع نسبة نصب الكاميرات ", "غير معروف" },
                    { 54, "عدد المستفدين", "غير معروف" },
                    { 55, "عدد المبادرات ", "غير معروف" },
                    { 56, "النشر بالجريدة الرسمية   ", "غير معروف" },
                    { 71, "ارتفاع نسبة تمدرس الفتيات ", "غير معروف" },
                    { 70, "نسبة تغطية الأساتذة لحصص اللغة الامازيغية", "غير معروف" },
                    { 69, " عدد المناهج والمقررات الدراسية المراجعة", "غير معروف" },
                    { 68, "نسبة التمدرس ", "غير معروف" },
                    { 67, " عدد البرامج المفعلة", "غير معروف" },
                    { 66, "عدد طلبات المعلومة المقدمة والمعالجة", "غير معروف" },
                    { 65, "عدد التظلمات المعالجة", "غير معروف" },
                    { 64, "عدد التحريات المحالة على القضاء", "غير معروف" },
                    { 63, "النشر في الجريدة الرسمية  ", "غير معروف" },
                    { 62, "عدد المستفيدين من المساعدة القانونية والقضائية", "غير معروف" },
                    { 61, "عدد التدخلات", "غير معروف" },
                    { 60, "ارتفاع نسبة استعمال بوابة الشراكة", "غير معروف" },
                    { 59, "مستوى تطور الشراكات ", "غير معروف" },
                    { 58, "التقارير الدورية للتتبع", "غير معروف" },
                    { 57, "نشر الدليل العملي المبسط", "غير معروف" },
                    { 38, "عدد المعايير الوطنية المعتمدة", "غير معروف" },
                    { 37, " تطور نسبة التبليغ عن حالات الفساد ومعالجتها ", "غير معروف" },
                    { 36, "تحسن مؤشر   e-gov", "غير معروف" },
                    { 35, "نسبة تنفيذ الاستراتيجية ", "غير معروف" },
                    { 15, "تقارير التنفيذ", "غير معروف" },
                    { 14, "عدد البرامج والمبادرات", "غير معروف" },
                    { 13, "عدد مشاريع المؤسسة التعليمية المفعلة ", "غير معروف" },
                    { 12, "نسبة تنفيذ البرامج", "غير معروف" },
                    { 11, " عدد البرامج المنفذة ", "غير معروف" },
                    { 10, " عدد آليات الديمقراطية التشاركية المفعلة", "غير معروف" },
                    { 9, "عدد البرامج", "غير معروف" },
                    { 8, "نسبة الخدمات الإعلامية المتعلقة بالمشاركة السياسية", "غير معروف" },
                    { 7, " عدد عمليات التشاور العمومي", "غير معروف" },
                    { 6, "النشر في الجريدة الرسمية", "غير معروف" },
                    { 5, "تنصيب رئيس وأعضاءالهيئة", "غير معروف" },
                    { 4, "النشر بالجريدة الرسمية", "غير معروف" },
                    { 3, "ارتفاع نسب التمثيلية ", "غير معروف" },
                    { 2, "التعبير عن الرضا بخصوص تدبير العملية الانتخابية من قبل عموم المعنيين والملاحظين", "غير معروف" },
                    { 1, "ارتفاع نسبة التسجيل والتصويت   ", "غير معروف" },
                    { 16, "عدد المستفيدين", "غير معروف" },
                    { 72, "نسبة التنفيذ ", "غير معروف" },
                    { 17, "إحصائيات   النوع الاجتماعي", "غير معروف" },
                    { 19, " عدد المبادرات المتخذة لتفعيل مقاربة النوع ", "غير معروف" },
                    { 34, "نسبة تنفيذ البرامج ", "غير معروف" },
                    { 33, " عدد اجتماعات اللجنة ولجانها الفرعية ", "غير معروف" },
                    { 32, " النشر في الجريدة الرسمية", "غير معروف" },
                    { 31, "عدد المبادرات المتخذة", "غير معروف" },
                    { 30, "عدد المبادرات", "غير معروف" },
                    { 29, "النشر  في الجريدة الرسمية ", "غير معروف" },
                    { 28, "النشر في الجريدة الرسمية. ", "غير معروف" },
                    { 27, "عدد الاتفاقياتالمفعلة", "غير معروف" },
                    { 26, " نسبة تغطية مختلف الجهات بالتصاميم الجهوية. ", "غير معروف" },
                    { 25, "نسبة التنفيذ", "غير معروف" },
                    { 24, "عدد البرامج المنفذة ", "غير معروف" },
                    { 23, "نسبة تنفيذ التوصيات", "غير معروف" },
                    { 22, "النشر فيالجريدة الرسمية ", "غير معروف" },
                    { 21, "نسبة الخدمات الإعلامية المتعلقة   بنشر قيم ومبادئ المساواة", "غير معروف" },
                    { 20, "نسبة ارتفاع تمكين النساء من مناصب المسؤولية ", "غير معروف" },
                    { 18, " نسبة الجماعات المتوفرة على هيئة للمساواة وتكافؤ الفرص ومقاربة النوع مفعلة", "غير معروف" },
                    { 73, " سياسة لغوية معتمدة", "غير معروف" },
                    { 41, "عدد الإصدارات ", "غير معروف" },
                    { 75, "عدد المستفيدات والمستفيدين من الدعم المادي", "غير معروف" },
                    { 127, "ارتفاع نسبة الخدمات الاجتماعية المقدمة للأجراء", "غير معروف" },
                    { 126, " عدد المستفيدين", "غير معروف" },
                    { 125, " عدد المشاريع", "غير معروف" },
                    { 124, "نسبة ارتفاع مناصب الشغل المحدثة", "غير معروف" },
                    { 123, "عدد النزاعات المعالجة", "غير معروف" },
                    { 122, " عدد التدخلات الاستباقية ", "غير معروف" },
                    { 128, "نسبة التغطية الترابية لهيئة تفتيش الشغل", "غير معروف" },
                    { 121, "عدد المستفيدين من البرامج موزعة حسب الفئات والمجالات", "غير معروف" },
                    { 119, "نسبة اللجان المفعلة", "غير معروف" },
                    { 118, "وثيقة تركيبية لنتائج الحوار", "غير معروف" },
                    { 117, "نتائج الدراسة والمشاورات المجراة", "غير معروف" },
                    { 116, "الإيداع", "غير معروف" },
                    { 115, "عدد البرامج المنفذة", "غير معروف" },
                    { 114, "نسبة الشكايات المعالجة", "غير معروف" },
                    { 120, "عدد نزاعات الشغل الجماعية التي تم تسويتها بمقتضى هذه الآليات.", "غير معروف" },
                    { 129, "نسبة إدماج خريجي التكوين المهني", "غير معروف" },
                    { 130, "عدد البرامج التحسيسية", "غير معروف" },
                    { 131, "عدد اتفاقيات الشراكة المفعلة", "غير معروف" },
                    { 146, "نسبة تطور موارد الصندوق", "غير معروف" },
                    { 145, "عدد المصنفات ", "غير معروف" },
                    { 144, " نسبة المستفيدين من برامج التواصل", "غير معروف" },
                    { 74, "عدد الآليات المفعلة ", "غير معروف" },
                    { 142, "عدد التدابير", "غير معروف" },
                    { 141, "نسبة التجديد الحضري", "غير معروف" },
                    { 140, "نسبة رفع الاعتمادات", "غير معروف" },
                    { 139, "عدد تدخلات المراقبة والتفتيش", "غير معروف" },
                    { 138, "عدد الوحدات السكنية المنجزة ", "غير معروف" },
                    { 137, "نسبة التغطية", "غير معروف" },
                    { 136, "انخفاض نسبة أحياء الصفيح", "غير معروف" },
                    { 135, " انخفاض نسبة السكن غير اللائق. ", "غير معروف" },
                    { 134, "النشر بالجريدة الرسمية.", "غير معروف" },
                    { 133, "عدد المستفيدين من التكوين", "غير معروف" },
                    { 132, "عدد المستفيدين من التكوين.", "غير معروف" },
                    { 113, "نسبة تغطية الخصاص", "غير معروف" },
                    { 112, "عدد الشراكات المفعلة", "غير معروف" },
                    { 143, " عدد المبادرات", "غير معروف" },
                    { 110, "نسبة الاستجابة للحاجيات", "غير معروف" },
                    { 90, "عدد الفضاءات والمؤسسات التي تحمل أسماء رموز مغربية", "غير معروف" },
                    { 89, "عدد البحوث الجامعية", "غير معروف" },
                    { 88, "عدد المحطات الإذاعية الجهوية المفعلة", "غير معروف" },
                    { 87, "ارتفاع نسبة البث", "غير معروف" },
                    { 86, "عدد اللجان المحدثة بالجهات ", "غير معروف" },
                    { 85, "عدد المبادرات  ", "غير معروف" },
                    { 84, "نسبة تطور إدماج الأمازيغية", "غير معروف" },
                    { 83, "عدد البرامج المنجزة ", "غير معروف" },
                    { 82, "الاعتماد في المجلس الحكومي", "غير معروف" },
                    { 81, "عدد المناهج والكتب المراجعة والأنشطة المنظمة", "غير معروف" },
                    { 80, " نسبة ولوج التعليم العالي", "غير معروف" },
                    { 79, " نسبة ارتفاعميزانية البحث العلمي؛", "غير معروف" },
                    { 77, "نسبة مجالس التدبير المفعلة ", "غير معروف" },
                    { 76, "نسبة ارتفاع المشاركة في المشاريع المدرسية", "غير معروف" },
                    { 111, "عدد آليات التنسيق والتتبع والمراقبة المفعلة", "غير معروف" },
                    { 91, "عدد الشراكات المنجزة", "غير معروف" },
                    { 92, "عدد المرافق الثقافية المحدثة ", "غير معروف" },
                    { 78, "عدد خلايا الإنصات والوساطة الاجتماعية المفعلة", "غير معروف" },
                    { 108, "نسبة تطور إحداث الوحدات المتخصصة في الصحة النفسية  ", "غير معروف" },
                    { 109, "عدد الزيارات الميدانية", "غير معروف" },
                    { 107, "عدد وحدات الاستقبال المحدثة ", "غير معروف" },
                    { 106, "عدد التقارير الإحصائية الدورية", "غير معروف" },
                    { 93, "نسبة التغطية ", "غير معروف" },
                    { 104, "انخفاض نسبةالأشخاصالمتعايشينمعالفيروسالذينيتعرضونللتمييزوالوصم", "غير معروف" },
                    { 103, "عدد بنيات الاستقبال المؤهلة", "غير معروف" },
                    { 102, "نسبة انخفاضوفياتالأمهاتأثناءالولادة", "غير معروف" },
                    { 105, "نسبة التغطية المجالية", "غير معروف" },
                    { 100, "نسبة مصالح المستعجلات الاستشفائية المؤهلة", "غير معروف" },
                    { 99, "نسبةالتأطيرالصحي للسكانحسبالمناطقوالجهات والتخصصات            ", "غير معروف" },
                    { 98, "نسبة ولوج الفئات الهشة للتغطية الصحية", "غير معروف" },
                    { 97, " نسبة التغطية الترابية ", "غير معروف" },
                    { 96, "إصدار الميثاق", "غير معروف" },
                    { 95, "عدد الدراسات المنجزة ", "غير معروف" },
                    { 94, "معدل المكتبات المحدثة لكل 50000 نسمة", "غير معروف" },
                    { 101, "نسبةانخفاض وفياتالأطفال", "غير معروف" }
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
                    { 44, null, "جهة كلميم واد نون", null, 2 },
                    { 43, null, "جهة سوس ماسة", null, 2 },
                    { 42, null, "جهة درعة تافيلالت", null, 2 },
                    { 41, null, "جهة مراكش آسفي", null, 2 },
                    { 40, null, "جهة الدار البيضاء سطات", null, 2 },
                    { 39, null, "جهة بني ملال خنيفرة", null, 2 },
                    { 59, null, "الأمانة العامة للحكومة", null, 1 },
                    { 37, null, "جهة فاس مكناس", null, 2 },
                    { 36, null, "جهة الشرق", null, 2 },
                    { 35, null, "جهة طنجة تطوان الحسيمة", null, 2 },
                    { 34, null, "وزارة الثقافة والاتصال قطاع الثقافة", null, 1 },
                    { 33, null, "قطاع التعليم العالي", null, 1 },
                    { 38, null, "جهة الرباط سلا القنيطرة", null, 2 },
                    { 45, null, "جهة العيون الساقية الحمراء", null, 2 },
                    { 54, null, "وزارة الطاقة والمعادن والتنمية المستدامة", null, 1 },
                    { 47, null, "مؤسسة-1", null, 3 },
                    { 48, null, "مؤسسة-2", null, 3 },
                    { 49, null, "مؤسسة-3", null, 3 },
                    { 50, null, "مؤسسة-4", null, 3 },
                    { 51, null, "وزارة السياحة والنقل الجوي والصناعة التقليدية والاقتصاد الاجتماعي", null, 1 },
                    { 52, null, "كتابة الدولة لدى وزير الطاقة والمعادن والتنمية المستدامة المكلفة بالتنمية المستدامة", null, 1 },
                    { 53, null, "وزارة الفلاحة والصيد البحري والتنمية القروية والمياه والغابات", null, 1 },
                    { 55, null, "الاتحاد العام لمقاولات المغرب", null, 1 },
                    { 56, null, "وزارة الشؤون الخارجية والتعاون الدولي", null, 1 },
                    { 57, null, "الوزارة المنتدبة لدى وزير الشؤون الخارجية والتعاون الدولي المكلفة بالمغاربة المقيمين بالخارج وشؤون الهجرة", null, 1 },
                    { 58, null, "الوكالة الوطنية لمحاربة الأمية", null, 1 },
                    { 32, null, "المجلس الأعلى للسلطة القضائية", null, 1 },
                    { 46, null, "جهة الداخلة وادي الذهب", null, 2 },
                    { 31, null, "رئاسة النيابة العامة", null, 1 },
                    { 13, null, " وزارة التربية الوطنية والتكوين المهني  والتعليم العالي  والبحث العلمي قطاع التربية الوطنية", null, 1 },
                    { 29, null, "وزارة الدولة المكلفة بحقوق الإنسان", null, 1 },
                    { 1, null, "وزارة الدولة المكلفة بحقوق الإنسان", null, 1 },
                    { 2, null, "وزارة العدل", null, 1 },
                    { 3, null, "المجلس الأعلى للسلطة القضائية ", null, 1 },
                    { 4, null, "المجلس الوطني لحقوق الإنسان", null, 1 },
                    { 5, null, "الهيئات السياسية ", null, 1 },
                    { 6, null, "جمعيات المجتمع المدني", null, 1 },
                    { 7, null, "وزارة الداخلية", null, 1 },
                    { 8, null, "الجمعيات الترابية", null, 1 },
                    { 9, null, "وزارة الأسرة والتضامن والمساواة والتنمية الاجتماعية", null, 1 },
                    { 10, null, "رئاسة الحكومة", null, 1 },
                    { 11, null, " الوزارة المنتدبة المكلفة بالعلاقات مع البرلمان والمجتمع المدني", null, 1 },
                    { 30, null, "المجلس الوطني لحقوق الإنسان", null, 1 },
                    { 14, null, "وزارة الشباب والرياضة", null, 1 },
                    { 12, null, "وزارة التربية الوطنية والتكوين المهني والتعليم العالي والبحث العلمي", null, 1 },
                    { 16, null, "هيئة المناصفة ومكافحة جميع أشكال التمييز", null, 1 },
                    { 28, null, "المندوبية العامة لإدارة السجون وإعادة الإدماج", null, 1 },
                    { 27, null, "الدرك الملكي", null, 1 },
                    { 26, null, "وزارة الصحة", null, 1 },
                    { 15, null, "وزارة الاقتصاد والمالية", null, 1 },
                    { 24, null, "وزارة إصلاح الإدارة والوظيفة العمومية وجميع الإدارات", null, 1 },
                    { 23, null, " وزارة الصناعة والاستثمار والتجارة والاقتصاد الرقمي", null, 1 },
                    { 25, null, "الهيئة المركزية للوقاية من الرشوة", null, 1 },
                    { 21, null, "الهيئة الوطنية للنزاهة والوقاية  من الرشوة ومحاربتها", null, 1 },
                    { 20, null, "البرلمان", null, 1 },
                    { 19, null, "وزارة الثقافة والاتصال", null, 1 },
                    { 18, null, "وزارة إعداد التراب الوطني والتعمير والإسكان وسياسة المدينة", null, 1 },
                    { 17, null, "الوزارة المنتدبة لدى رئيس الحكومة المكلفة بإصلاح الإدارة وبالوظيفة العمومية", null, 1 },
                    { 22, null, "الوزارة المنتدبة لدى رئيس الحكومة المكلفة بالشؤون العامة والحكامة", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Profils",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 4, "لجنة التتبع" },
                    { 1, "مدير" },
                    { 2, "مشرف" },
                    { 3, "لجنة الوطنية" },
                    { 5, "المخاطب الرئيسي" }
                });

            migrationBuilder.InsertData(
                table: "MembreCommissions",
                columns: new[] { "Id", "Email", "IdCommission", "NomComplete" },
                values: new object[,]
                {
                    { 19, "Lena_Lecomte@gmail.com", 19, "Enzo Denis" },
                    { 17, "Victor63@gmail.com", 17, "Adam Julien" },
                    { 16, "Paul.Leroy@gmail.com", 16, "Ambre Martin" },
                    { 15, "Clara69@yahoo.fr", 15, "Manon Roy" },
                    { 14, "Romain_Petit49@yahoo.fr", 14, "Chloé Leroux" },
                    { 13, "Gabriel_Cousin@gmail.com", 13, "Alexis Arnaud" },
                    { 12, "Ethan_Martin90@gmail.com", 12, "Lucie Garcia" },
                    { 1, "Mathilde.Brun91@hotmail.fr", 1, "Lina Poirier" },
                    { 2, "Mathis.Durand46@gmail.com", 2, "Quentin Thomas" },
                    { 3, "Mathilde49@yahoo.fr", 3, "Maëlys Prevost" },
                    { 4, "Eva18@hotmail.fr", 4, "Jeanne Richard" },
                    { 5, "Lina_Dupuy@yahoo.fr", 5, "Justine Guillaume" },
                    { 6, "Alexandre.Morin@hotmail.fr", 6, "Tom Gaillard" },
                    { 7, "Victor24@hotmail.fr", 7, "Yanis Roche" },
                    { 8, "Axel_Riviere@gmail.com", 8, "Alexis Maillard" },
                    { 9, "Oceane12@gmail.com", 9, "Lisa Riviere" },
                    { 18, "Matteo3@yahoo.fr", 18, "Julie Bourgeois" },
                    { 10, "Louna_Marchal@gmail.com", 10, "Quentin Renard" },
                    { 11, "Kylian68@yahoo.fr", 11, "Arthur Caron" },
                    { 20, "Zoe_Lacroix@yahoo.fr", 20, "Pauline Blanchard" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "IdProfil", "RouteScreen", "RouteScreenAr" },
                values: new object[,]
                {
                    { 10, "Modification", 2, "mesure-executif", "mesure-executif" },
                    { 7, "Consultation", 5, "suivi-indicateur", "rapport-qualitative" },
                    { 6, "Consultation", 5, "rapport-qualitative", "rapport-qualitative" },
                    { 5, "Consultation", 5, "rapport-litteraire", "rapport-litteraire" },
                    { 4, "Modification", 5, "suivi", "suivi" },
                    { 3, "Consultation", 5, "mesure-programme", "mesure-programme" },
                    { 2, "Consultation", 5, "mesure-region", "mesure-region" },
                    { 1, "Consultation", 5, "mesure-executif", "mesure-executif" },
                    { 9, "Modification", 4, "commission", "commission" },
                    { 16, "Modification", 2, "commission", "commission" },
                    { 15, "Modification", 2, "rapport-qualitative", "rapport-qualitative" },
                    { 14, "Modification", 2, "rapport-litteraire", "rapport-litteraire" },
                    { 13, "Modification", 2, "suivi", "suivi" },
                    { 12, "Modification", 2, "mesure-programme", "mesure-programme" },
                    { 11, "Modification", 2, "mesure-region", "mesure-region" },
                    { 17, "Modification", 2, "suivi-indicateur", "suivi-indicateur" },
                    { 8, "Modification", 3, "commission", "commission" }
                });

            migrationBuilder.InsertData(
                table: "SousAxes",
                columns: new[] { "Id", "IdAxe", "Label" },
                values: new object[,]
                {
                    { 1, 1, "المشاركة السياسية " },
                    { 25, 4, " حفظ الأرشيف وصيانته " },
                    { 26, 4, "الحقوق والحريات والآليات المؤسساتية " },
                    { 2, 1, "المساواة والمناصفة وتكافؤ الفرص " },
                    { 3, 1, " الحكامة الترابية " },
                    { 4, 1, "الحكامة الإدارية والنزاهة والشفافية ومكافحة الفساد " },
                    { 5, 1, "الحكامة الأمنية " },
                    { 7, 1, " مكافحة الإفلات من العقاب" },
                    { 8, 2, " جودة المنظومة الوطنية للتربية والتكوين والبحث العلمي " },
                    { 9, 2, "الحقوق الثقافية " },
                    { 10, 2, " الولوج إلى الخدمات الصحية " },
                    { 11, 2, " الشغل وتكريس المساواة " },
                    { 12, 2, " السياسة السكنية " },
                    { 13, 2, "السياسة البيئية المندمجة " },
                    { 6, 1, " حريات الاجتماع والتجمع والتظاهر السلمي وتأسيس الجمعيات " },
                    { 15, 3, " الأبعاد المؤسساتية والتشريعية " },
                    { 16, 3, " حقوق الطفل " },
                    { 17, 3, "حقوق الشباب " },
                    { 14, 2, " المقاولة وحقوق الإنسان " },
                    { 23, 4, "حريات التعبير والإعلام والصحافة والحق في المعلومة " },
                    { 18, 3, " حقوق الأشخاص في وضعية إعاقة " },
                    { 19, 3, " حقوق الأشخاص المسنين " },
                    { 24, 4, "حماية التراث الثقافي " },
                    { 20, 3, "حقوق المهاجرين واللاجئين " },
                    { 21, 4, " الحماية القانونية والقضائية لحقوق الإنسان " },
                    { 22, 4, " الحماية القانونية والمؤسساتية لحقوق المرأة " }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Actif", "Adresse", "Email", "Fix", "IdOrganisme", "IdProfil", "Nom", "Password", "Prenom", "Tel", "Username" },
                values: new object[,]
                {
                    { 35, true, "taza", "user-regions-35@panddh.com", "05 ## ## ## ##", 35, 5, "user-regions-35", "123", "mohamed", "06 ## ## ## ##", "user-regions-35" },
                    { 34, true, "taza", "user-34@panddh.com", "05 ## ## ## ##", 34, 5, "user-34", "123", "mohamed", "06 ## ## ## ##", "user-34" },
                    { 33, true, "taza", "user-33@panddh.com", "05 ## ## ## ##", 33, 5, "user-33", "123", "mohamed", "06 ## ## ## ##", "user-33" },
                    { 32, true, "taza", "user-32@panddh.com", "05 ## ## ## ##", 32, 5, "user-32", "123", "mohamed", "06 ## ## ## ##", "user-32" },
                    { 30, true, "taza", "user-30@panddh.com", "05 ## ## ## ##", 30, 5, "user-30", "123", "mohamed", "06 ## ## ## ##", "user-30" },
                    { 29, true, "taza", "user-29@panddh.com", "05 ## ## ## ##", 29, 5, "user-29", "123", "mohamed", "06 ## ## ## ##", "user-29" },
                    { 28, true, "taza", "user-28@panddh.com", "05 ## ## ## ##", 28, 5, "user-28", "123", "mohamed", "06 ## ## ## ##", "user-28" },
                    { 27, true, "taza", "user-27@panddh.com", "05 ## ## ## ##", 27, 5, "user-27", "123", "mohamed", "06 ## ## ## ##", "user-27" },
                    { 31, true, "taza", "user-31@panddh.com", "05 ## ## ## ##", 31, 5, "user-31", "123", "mohamed", "06 ## ## ## ##", "user-31" },
                    { 36, true, "taza", "user-regions-36@panddh.com", "05 ## ## ## ##", 36, 5, "user-regions-36", "123", "mohamed", "06 ## ## ## ##", "user-regions-36" },
                    { 41, true, "taza", "user-regions-41@panddh.com", "05 ## ## ## ##", 41, 5, "user-regions-41", "123", "mohamed", "06 ## ## ## ##", "user-regions-41" },
                    { 38, true, "taza", "user-regions-38@panddh.com", "05 ## ## ## ##", 38, 5, "user-regions-38", "123", "mohamed", "06 ## ## ## ##", "user-regions-38" },
                    { 39, true, "taza", "user-regions-39@panddh.com", "05 ## ## ## ##", 39, 5, "user-regions-39", "123", "mohamed", "06 ## ## ## ##", "user-regions-39" },
                    { 40, true, "taza", "user-regions-40@panddh.com", "05 ## ## ## ##", 40, 5, "user-regions-40", "123", "mohamed", "06 ## ## ## ##", "user-regions-40" },
                    { 42, true, "taza", "user-regions-42@panddh.com", "05 ## ## ## ##", 42, 5, "user-regions-42", "123", "mohamed", "06 ## ## ## ##", "user-regions-42" },
                    { 43, true, "taza", "user-regions-43@panddh.com", "05 ## ## ## ##", 43, 5, "user-regions-43", "123", "mohamed", "06 ## ## ## ##", "user-regions-43" },
                    { 26, true, "taza", "user-26@panddh.com", "05 ## ## ## ##", 26, 5, "user-26", "123", "mohamed", "06 ## ## ## ##", "user-26" },
                    { 44, true, "taza", "user-regions-44@panddh.com", "05 ## ## ## ##", 44, 5, "user-regions-44", "123", "mohamed", "06 ## ## ## ##", "user-regions-44" },
                    { 48, true, "taza", "user-societe-48@panddh.com", "05 ## ## ## ##", 48, 5, "user-societe-48", "123", "mohamed", "06 ## ## ## ##", "user-societe-48" },
                    { 45, true, "taza", "user-regions-45@panddh.com", "05 ## ## ## ##", 45, 5, "user-regions-45", "123", "mohamed", "06 ## ## ## ##", "user-regions-45" },
                    { 46, true, "taza", "user-regions-46@panddh.com", "05 ## ## ## ##", 46, 5, "user-regions-46", "123", "mohamed", "06 ## ## ## ##", "user-regions-46" },
                    { 47, true, "taza", "user-societe-47@panddh.com", "05 ## ## ## ##", 47, 5, "user-societe-47", "123", "mohamed", "06 ## ## ## ##", "user-societe-47" },
                    { 37, true, "taza", "user-regions-37@panddh.com", "05 ## ## ## ##", 37, 5, "user-regions-37", "123", "mohamed", "06 ## ## ## ##", "user-regions-37" },
                    { 25, true, "taza", "user-25@panddh.com", "05 ## ## ## ##", 25, 5, "user-25", "123", "mohamed", "06 ## ## ## ##", "user-25" },
                    { 13, true, "taza", "user-13@panddh.com", "05 ## ## ## ##", 13, 5, "user-13", "123", "mohamed", "06 ## ## ## ##", "user-13" },
                    { 23, true, "taza", "user-23@panddh.com", "05 ## ## ## ##", 23, 5, "user-23", "123", "mohamed", "06 ## ## ## ##", "user-23" },
                    { 1, true, "Temara", "admin@panddh.com", "05 ## ## ## ##", 1, 1, "admin", "123", "panddh", "06 ## ## ## ##", "panddh" },
                    { 2, true, "Temara", "mehdi@angular.io", "05 ## ## ## ##", 2, 2, "mehdi", "123", "mehdi", "06 ## ## ## ##", "mehdi" },
                    { 49, true, "taza", "user-societe-49@panddh.com", "05 ## ## ## ##", 49, 5, "user-societe-49", "123", "mohamed", "06 ## ## ## ##", "user-societe-49" },
                    { 4, true, "Temara", "soufiane@angular.io", "05 ## ## ## ##", 4, 3, "soufiane", "123", "soufiane", "06 ## ## ## ##", "soufiane" },
                    { 3, true, "Temara", "ahmed@angular.io", "05 ## ## ## ##", 3, 4, "ahmed", "123", "ahmed", "06 ## ## ## ##", "ahmed" },
                    { 5, true, "taza", "user-5@panddh.com", "05 ## ## ## ##", 5, 5, "user-5", "123", "mohamed", "06 ## ## ## ##", "user-5" },
                    { 6, true, "taza", "user-6@panddh.com", "05 ## ## ## ##", 6, 5, "user-6", "123", "mohamed", "06 ## ## ## ##", "user-6" },
                    { 7, true, "taza", "user-7@panddh.com", "05 ## ## ## ##", 7, 5, "user-7", "123", "mohamed", "06 ## ## ## ##", "user-7" },
                    { 8, true, "taza", "user-8@panddh.com", "05 ## ## ## ##", 8, 5, "user-8", "123", "mohamed", "06 ## ## ## ##", "user-8" },
                    { 9, true, "taza", "user-9@panddh.com", "05 ## ## ## ##", 9, 5, "user-9", "123", "mohamed", "06 ## ## ## ##", "user-9" },
                    { 24, true, "taza", "user-24@panddh.com", "05 ## ## ## ##", 24, 5, "user-24", "123", "mohamed", "06 ## ## ## ##", "user-24" },
                    { 10, true, "taza", "user-10@panddh.com", "05 ## ## ## ##", 10, 5, "user-10", "123", "mohamed", "06 ## ## ## ##", "user-10" },
                    { 12, true, "taza", "user-12@panddh.com", "05 ## ## ## ##", 12, 5, "user-12", "123", "mohamed", "06 ## ## ## ##", "user-12" },
                    { 14, true, "taza", "user-14@panddh.com", "05 ## ## ## ##", 14, 5, "user-14", "123", "mohamed", "06 ## ## ## ##", "user-14" },
                    { 15, true, "taza", "user-15@panddh.com", "05 ## ## ## ##", 15, 5, "user-15", "123", "mohamed", "06 ## ## ## ##", "user-15" },
                    { 16, true, "taza", "user-16@panddh.com", "05 ## ## ## ##", 16, 5, "user-16", "123", "mohamed", "06 ## ## ## ##", "user-16" },
                    { 17, true, "taza", "user-17@panddh.com", "05 ## ## ## ##", 17, 5, "user-17", "123", "mohamed", "06 ## ## ## ##", "user-17" },
                    { 18, true, "taza", "user-18@panddh.com", "05 ## ## ## ##", 18, 5, "user-18", "123", "mohamed", "06 ## ## ## ##", "user-18" },
                    { 19, true, "taza", "user-19@panddh.com", "05 ## ## ## ##", 19, 5, "user-19", "123", "mohamed", "06 ## ## ## ##", "user-19" },
                    { 20, true, "taza", "user-20@panddh.com", "05 ## ## ## ##", 20, 5, "user-20", "123", "mohamed", "06 ## ## ## ##", "user-20" },
                    { 21, true, "taza", "user-21@panddh.com", "05 ## ## ## ##", 21, 5, "user-21", "123", "mohamed", "06 ## ## ## ##", "user-21" },
                    { 22, true, "taza", "user-22@panddh.com", "05 ## ## ## ##", 22, 5, "user-22", "123", "mohamed", "06 ## ## ## ##", "user-22" },
                    { 11, true, "taza", "user-11@panddh.com", "05 ## ## ## ##", 11, 5, "user-11", "123", "mohamed", "06 ## ## ## ##", "user-11" },
                    { 50, true, "taza", "user-societe-50@panddh.com", "05 ## ## ## ##", 50, 5, "user-societe-50", "123", "mohamed", "06 ## ## ## ##", "user-societe-50" }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[,]
                {
                    { 13, "13", 1, 2, 3, 1, 1, 2, " وضع برامج تكوينية على المواطنة وحقوق الإنسان وسيادة القانون لفائدة المنتخبين وموظفي الجماعات الترابية والمجتمع المدني.", null, null, "" },
                    { 43, "43", 1, 1, 3, 29, 4, 1, "توثيق ونشر الممارسات الفضلى في مجال مكافحة للفساد.", null, null, "" },
                    { 427, "427", 4, 1, 1, 28, 26, 2, "الرفع من جودة الأحكام.", null, null, "آلية داعمة للرفع من جودة الاحكام" },
                    { 333, "333", 3, 1, 1, 28, 19, 2, " دعم وتشجيع مبادرات المجتمع المدني والقطاع الخاص لإحداث نوادي وفضاءات الترفيه الموجهة للأشخاص المسنين.", null, null, "دينامية داعمة لمبادرات المجتمع المدني والقطاع الخاص في مجال الترفيه لفائدة الأشخاص المسنين " },
                    { 328, "328", 3, 1, 1, 28, 19, 1, " وضع إطار استراتيجي للنهوض بحقوق الأشخاص المسنين وحمايتها.", null, null, "إطار استراتيجي معد ومعتمد" },
                    { 278, "278", 3, 1, 3, 28, 16, 2, "مواصلة برامج وأنشطة التدريب والتكوين المستمر على اتفاقية الأمم المتحدة لحقوق الطفل والبروتوكولات الملحقة بها.", null, null, "قدرات الفاعلين متطورة " },
                    { 269, "269", 3, 1, 1, 28, 16, 2, "تفعيل ميثاق السياحة المستدامة من أجل وضع برامج وقائية لحماية الأطفال من الأشخاص الذين يستغلون السياحة لأسباب جنسية.", null, null, "آليات داعمة لحماية الأطفال من الاستغلال الجنسي" },
                    { 250, "250", 3, 1, 1, 28, 16, 1, " تعزيز حقوق الأطفال في المشاركة في إعداد وتتبع تفعيل السياسات والبرامج والمشاريع الوطنية.", null, null, "بيئة مشجعة على مشاركة الأطفال" },
                    { 246, "246", 3, 1, 1, 28, 16, 1, "تبسيط المساطر المتعلقة بتسجيل الأطفال في سجلات الحالة المدنية. ", null, null, "إطار قانوني داعم لتعزيز حق الطفل في الهوية " },
                    { 228, "228", 3, 2, 1, 28, 15, 1, " وضع أنظمة معلوماتية لتتبع الحقوق الفئوية.", null, null, "أنظمة معلوماتية مساعدة على تتبع الحقوق الفئوية" },
                    { 187, "187", 2, 1, 1, 28, 13, 1, " الإسراع بإصدار المرسوم المتعلق بإحداث نظام وطني لجرد الغازات الدفيئة تطبيقا لمقتضيات الاتفاقية الإطارية للأمم المتحدة المتعلق بتغير المناخ.", null, null, "" },
                    { 143, "143", 2, 2, 1, 28, 10, 2, " ضمان التنسيق الفعال بين مختلف الإدارات الصحية على الصعيد الوطني وبين المستشفيات والمراكز الصحية، وإحداث آليات التتبع والمراقبة وتقييم الأداء وجودة الخدمات وفعاليتها.", null, null, ".آليات مساعدة على التنسيق والتتبع والمراقبة " },
                    { 76, "76", 1, 2, 1, 28, 7, 1, " وضع إطار تشريعي وتنظيمي مستقل لمأسسة الطب الشرعي.", null, null, "" },
                    { 52, "52", 1, 1, 1, 28, 5, 1, "تجهيز أماكن الحرمان من الحرية بوسائل التوثيق السمعية البصرية لتوثيق تصريحات المستجوبين من طرف الشرطة القضائية ووضعها رهن إشارة القضاء.", null, null, "" },
                    { 51, "51", 1, 2, 1, 28, 5, 2, "-51-التوثيق السمعي البصري للتدخلات الأمنية لفض التجمعات العمومية.", null, null, "" },
                    { 18, "18", 1, 2, 3, 28, 2, 2, " وضع برامج فعالة للتوعية والتحسيس والتربية على قيم ومبادئ المساواة وتكافؤ الفرص والمناصفة لفائدة أطر وموظفي الإدارات والمؤسسات العمومية والجماعات الترابية.", null, null, "" },
                    { 15, "15", 1, 1, 1, 28, 2, 2, " الإسراع بتفعيل هيئة المناصفة ومكافحة جميع أشكال التمييز كمدخل أساسي من مداخل تقوية قيم المساواة والإنصاف الموجهة للسياسات العمومية والاستراتيجيات والمخططات والبرامج الوطنية.", null, null, "" },
                    { 3, "3", 1, 1, 1, 28, 1, 1, "الإسراع بإحداث مرصد وطني مستقل يساهم في تحليل تطورات المشاركة السياسية والانتقال الديمقراطي.", null, null, "آلية مؤسساتية مساعدة على تتبع تحليل وفهم تطورات المشاركة السياسية والانتقال الديمقراطي" },
                    { 410, "410", 4, 1, 3, 27, 23, 1, "تعزيز برامج التوعية والتحسيس بشأن مكتسبات وتحديات ممارسة حريات التعبير والإعلام والصحافة والحق في المعلومة", null, null, "عدد البرامج والشراكات والدعامات المنجزة" },
                    { 384, "384", 4, 1, 1, 27, 22, 1, "مواصلة ترصيد المكتسبات المعرفية المتعلقة بالكد والسعاية في التشريع والعمل القضائي.", null, null, "دينامية داعمة لترصيد الاجتهادات العلمية/الفقهية والقضائية المتعلقة بالكد والسعاية  " },
                    { 379, "379", 4, 1, 1, 27, 22, 1, " تفعيل الهيئة المكلفة بالمناصفة ومكافحة جميع أشكال التمييز.", null, null, "هيئة المناصفة ومكافحة جميع أشكال التمييز مفعلة." },
                    { 351, "351", 3, 2, 1, 27, 20, 1, "مواصلة المجهودات المبذولة للرقي بالبرامج الموجهة لفائدة مغاربة العالم والاستجابة لانتظاراتهم الثقافية واللغوية والدينية والتربوية في بلدان الاستقبال وتعزيز التواصل بينهم وبين بلدهم الأصلي.", null, null, "برامج متنوعة تستجيب لإنتظارات مغاربة العالم" },
                    { 307, "307", 3, 1, 1, 27, 18, 1, "وضع برامج لدعم وتشجيع التشغيل الذاتي للأشخاص في وضعية إعاقة.", null, null, "برامج دعم وتشجيع التشغيل الذاتي للأشخاص في وضعية إعاقة مفعلة" },
                    { 292, "292", 3, 1, 3, 27, 17, 1, " وضع برامج لتعزيز قدرات المتدخلين في السياسة الوطنية المندمجة للشباب.", null, null, "قدرات متطورة لتفعيل السياسة الوطنية المندمجة للشباب" },
                    { 271, "271", 3, 1, 1, 27, 16, 2, "تفعيل آليات المراقبة التربوية والبيداغوجية واللوجيستيكية بالأماكن التي تخصص لتعليم وتربية الأطفال.", null, null, "آليات معززة للمراقبة التربوية والبيداغوجية واللوجيستيكية" },
                    { 239, "239", 3, 2, 1, 27, 16, 1, " الإسراع بالمصادقة على مشروع قانون متعلق بمراكز حماية الطفولة.", null, null, "إطار قانوني مساعد على تجويد خدمات مراكز حماية الطفولة " },
                    { 238, "238", 3, 2, 1, 27, 16, 2, " مواصلة تقوية الإطار القانوني المتعلق بحماية الأطفال وضمان فعاليته.", null, null, "إطار قانوني داعم لحماية حقوق  الأطفال" },
                    { 235, "235", 3, 2, 3, 27, 15, 1, " تأهيل وتعزيز قدرات جمعية الهلال الأحمر المغربي والجمعيات الوطنية الأخرى المعنية بالفئات الاجتماعية في وضعية هشاشة.", null, null, "برنامج داعم لقدرات جمعيات المجتمع المدني" },
                    { 234, "234", 3, 2, 3, 27, 15, 1, " تعزيز قدرات مختلف الفاعلين المعنيين، حكوميين وغير حكوميين، في مجال الحقوق الفئوية.", null, null, "برامج للتكوين والتكوين المستمر داعمة لتعزيز القدرات في مجال الحقوق الفئوية" },
                    { 222, "222", 3, 2, 1, 27, 15, 1, " دعم الآليات والتدابير الكفيلة ببلورة وتيسير تتبع وتقييم السياسات العمومية والبرامج التي تستهدف الحماية والنهوض بالحقوق الفئوية.", null, null, "آليات كفيلة بتطوير نجاعة البرامج الخاصة بالحقوق الفئوية " },
                    { 44, "44", 1, 1, 3, 29, 4, 1, "وضع برامج للتدريب والتكوين والتكوين المستمر لفائدة مختلف الفاعلين والمتدخلين في مجالات مكافحة الفساد وتعزيز النزاهة والشفافية وإشاعة أخلاقياتها.", null, null, "" },
                    { 88, "88", 1, 2, 1, 29, 8, 2, "  بلورة سياسة لغوية تضمن العدالة اللغوية وتأخذ بعين الاعتبار حاجيات التلاميذ وتراعي الخصوصيات اللغوية والثقافية للأقاليم والجهات", null, null, "" },
                    { 99, "99", 2, 1, 1, 29, 9, 1, "  تنمية الأشكال والآليات والوسائل الكفيلة بالحفاظ على التنوع الثقافي وتطويره في السياسات العمومية والاستراتيجيات والمخططات والبرامج الوطنية التي تقتضي إعمال الحقوق الثقافية بما فيها الحق في المشاركة الثقافية ", null, null, "" },
                    { 116, "116", 2, 2, 1, 29, 9, 1, " توسيع شبكة المراكز والمركبات الثقافية لتشمل عموم المناطق الحضرية والقروية.", null, null, "مركبات ثقافية جهوية ومحلية مساهمة في الإشعاع الثقافي" },
                    { 259, "259", 3, 2, 1, 31, 16, 1, " اعتماد معايير الجودة في خدمات التكفل بمؤسسات الرعاية الاجتماعية للأطفال.", null, null, "توفر مؤسسات الرعاية الاجتماعية على خدمات ذات جودة" },
                    { 245, "245", 3, 1, 1, 31, 16, 2, " وضع مؤشرات التتبع والتقييم في مجال حماية الأطفال من سوء المعاملة ومن كل أشكال الاستغلال والعنف.", null, null, " منظومة المؤشرات الخاصة بتتبع وضعية حماية الأطفال وتقييمها معتمدة ومفعلة" },
                    { 212, "212", 2, 1, 3, 31, 14, 1, "-212- تحفيز المقاولات على وضع ميثاق داخلي عام للسلوك في مجال حقوق الإنسان.", null, null, "بيئة داعمة للنهوض بحقوق الإنسان داخل المقاولة " },
                    { 207, "207", 2, 2, 3, 31, 13, 2, " إدماج البعد البيئي في البرامج والمقررات الدراسية وفي الأنشطة التربوية بالوسط المدرسي.", null, null, "مناهج ومقرراتدراسية معززة للتربية البيئية" },
                    { 162, "162", 2, 2, 3, 31, 11, 1, "وضع برامج للتوعية والتحسيس بمقتضيات مدونة الشغل لفائدة العمال.", null, null, "برامج داعمةلاحترام مقتضيات مدونة الشغل" },
                    { 128, "128", 2, 2, 1, 31, 10, 2, "ضمان العدالة المجالية في الميدان الصحي من خلال خريطة صحية عادلة تغطي مكونات التراب الوطني.", null, null, "خريطة صحية داعمة للعدالة المجالية " },
                    { 110, "110", 2, 1, 1, 31, 9, 1, "تشجيع البحث الجامعي على مواصلة الجهود حول تاريخ المغرب المتعدد بعمقه الديني وبمكوناته البشرية والثقافية والمحلية", null, null, "برامج داعمة للبحث الجامعي حول تاريخ المغرب المتعدد بعمقه الديني وبمكوناته البشرية والثقافية والمحلية" },
                    { 78, "78", 1, 1, 1, 31, 7, 1, " إحالة نتائج تحريات الآلية الوطنية للوقاية من التعذيب على القضاء.", null, null, "" },
                    { 35, "35", 1, 1, 1, 31, 4, 2, " تعزيز الالتقائية بين البرامج والمبادرات الأفقية والقطاعية.", null, null, "" },
                    { 421, "421", 4, 1, 3, 30, 25, 2, "تحسيس وتعبئة الخواص الذين بحوزتهم أرشيفات تراثية لإيداعها لدى مؤسسة أرشيف المغرب.", null, null, "دينامية مشجعة على تفاعل الخواص" },
                    { 420, "420", 4, 2, 1, 30, 25, 1, " رصد مصادر الأرشيف الخاصة بالمغرب والموجودة خارج الوطن ومواصلة استرجاعها ومعالجتها وحفظها وتيسير الاطلاع عليها من قبل المهتمين. ", null, null, "الأرصدة الوثائقية المتعلقة بالمغرب والموجودة بالخارج مرصودة ومعالجة وميسرة للاطلاع" },
                    { 416, "416", 4, 2, 1, 30, 24, 2, "تأهيل آليات الحفاظ على التراث الثقافي المغربي بكل مكوناته وأبعاده المادية والرمزية والمحافظة عليها.", null, null, "آليات الحفاظ على التراث الثقافي المغربي مؤهلة" },
                    { 414, "414", 4, 1, 1, 30, 24, 1, " مراجعة النصوص المتعلقة بالتراث الثقافي.", null, null, "إطار قانوني معزز" },
                    { 412, "412", 4, 2, 1, 30, 24, 1, " التشجيع على الانضمام إلى الاتفاقيات الدولية المتعلقة بحماية التراث الثقافي والمحافظة عليه.", null, null, "تعزيز الممارسة الاتفاقية" },
                    { 209, "209", 2, 1, 3, 27, 13, 1, " تعزيز برامج دعم القدرات في مجال البيئة والتنمية المستدامة.", null, null, "برامج مساعدة على رفع القدرات في مجال البيئة والتنمية المستدامة" },
                    { 339, "339", 3, 2, 1, 30, 19, 1, "تشجيع النهوض بطب الشيخوخة في وزارة الصحة وإحداث شعب للتكوين الطبي المتخصص في هذا المجال.", null, null, "منظومة داعمة لطب الشيخوخة" },
                    { 318, "318", 3, 2, 1, 30, 18, 1, " توحيد لغة الإشارة ووضع معايير لها.", null, null, "إطار معياري معد ومعتمد" },
                    { 270, "270", 3, 2, 1, 30, 16, 2, "إدماج الجماعات الترابية لانشغالات الأطفال في مخططات التنمية المحلية على مستوى التشخيص وتحديد الحاجيات والتخطيط والتنفيذ.", null, null, "مخططات للتنمية المحلية داعمة للنهوض بأوضاع الطفولة  من الاستغلال مطورة" },
                    { 257, "257", 3, 1, 1, 30, 16, 2, "مواصلة الجهود الرامية إلى الحد من ظاهرة تشغيل الأطفال.", null, null, "الجهود الرامية إلى الحد من ظاهرة تشغيل الأطفال متواصلة ومعززة" },
                    { 192, "192", 2, 1, 1, 30, 13, 1, " تخصيص تحفيزات مالية وتقنية لدعم المشاريع في مجال البيئة والتنمية المستدامة.", null, null, "موارد مالية مساهمة في دعم المشاريع الصديقة للبيئة " },
                    { 155, "155", 2, 1, 1, 30, 11, 2, " إعمال مبدأ الشفافية وتكافؤ الفرص في التشغيل ووضع آليات ومساطر إدارية تنظم الإعلان عن المناصب الشاغرة في جميع القطاعات وفي مرافق الإدارة العمومية ضمانا للشفافية.", null, null, "الشفافية   وتكافؤ الفرص في التوظيف معززة  " },
                    { 65, "65", 1, 1, 1, 30, 6, 2, " تدقيق القواعد والإجراءات القانونية المتعلقة بمختلف أشكال وأصناف التظاهر (الوقفة، التجمع، التظاهر في الشارع العمومي، مسار التظاهرات...) من حيث السير والجولان والتوقيت.", null, null, "" },
                    { 19, "19", 1, 2, 3, 30, 2, 2, " تعزيز دور وسائل الإعلام في نشر قيم ومبادئ المساواة والمناصفة وتكافؤ الفرص ومحاربة التمييز.", null, null, "" },
                    { 426, "426", 4, 2, 1, 29, 26, 2, "  تسهيل ولوج المتقاضين إلى المحاكم وتيسير التواصل اللغوي في عملها.", null, null, "آليات داعمة لتيسير الولوج لخدمات العدالة" },
                    { 424, "424", 4, 1, 3, 29, 25, 1, "النهوض بالموارد البشرية المعنية بمعالجة وبحفظ وتنظيم الأرشيف باعتماد برامج منتظمة خاصة بالتكوين والتكوين المستمر موجهة لفائدة المهنيين.", null, null, "الموارد البشرية بمؤسسة أرشيف المغرب مكونة" },
                    { 350, "350", 3, 1, 1, 29, 20, 1, " وضع آلية وطنية للرصد ومتابعة تطور الهجرة من وإلى المغرب وقياس آثارها المجتمعية والاقتصادية والثقافية.", null, null, "مرصد متخصص في متابعة تطور الهجرة محدث" },
                    { 297, "297", 3, 2, 1, 29, 18, 2, "ملاءمة التشريع الوطني مع مقتضيات الاتفاقية الدولية للأشخاص في وضعية إعاقة، لا سيما ما يتعلق بالأهلية القانونية.", null, null, "إطار قانوني ملائم" },
                    { 253, "253", 3, 1, 1, 29, 16, 1, " العمل على ضمان المساواة بين الرجل والمرأة في التمتع بالجنسية المغربية إعمالا للمصلحة الفضلى للطفل.", null, null, "إطار قانوني ضامن للمصلحة الفضلى للأطفال والأسرة" },
                    { 175, "175", 2, 2, 1, 29, 12, 2, " حصر الاستفادة من برنامج السكن الاجتماعي في ذوي الدخل المحدود بالصرامة اللازمة", null, null, "آليات داعمة لتعزيز الحكامة في تنفيذ برامج السكن الاجتماعي" },
                    { 154, "154", 2, 2, 1, 29, 11, 1, " تعزيز دور الآليات الاستباقية للتقليص من النزاعات في مجال الشغل.", null, null, "قدرات جهاز تفتيش الشغل في مجال التدخل الإستباقي معززة" },
                    { 323, "323", 3, 2, 1, 30, 18, 2, " تسهيل الولوج لإعادة تأهيل الأشخاص في وضعية إعاقة من خلال إحداث وتجهيز مراكز الترويض في مختلف الجهات والنهوض بأنظمة التكوين الطبي وشبه الطبي مصادق عليها ومستجيبة لمجموع الحاجيات.", null, null, "بنيات داعمة لإعادة تأهيل الأشخاص في وضعية إعاقة" },
                    { 268, "268", 3, 1, 1, 31, 16, 1, "وضع آليات ترابية مندمجة لحماية الطفولة تضمن التنسيق واليقظة من حيث الإشعار والتبليغ وتتبع الخدمات الموجهة للأطفال ضحايا العنف.", null, null, "آليات ترابية مندمجة لحماية الطفولة مفعلة" },
                    { 137, "137", 2, 2, 1, 27, 10, 2, " دعم التحصيل والتحليل الممنهج والشمولي للمعطيات والمعلومات حسب النوع الاجتماعي في مجال الصحة وخصوصا ما تعلق بالأمراض المتنقلة جنسيا والعنف. ", null, null, " نظاممعلوماتي مندمج معد" },
                    { 74, "74", 1, 1, 1, 27, 7, 1, "تعزيز المقتضيات القانونية المتعلقة بجبر ضرر ضحايا انتهاكات حقوق الإنسان.", null, null, "" },
                    { 279, "279", 3, 1, 1, 24, 17, 1, " تفعيل المجلس الاستشاري للشباب والعمل الجمعوي وإصدار النصوص التشريعية والتنظيمية المتعلقة به.", null, null, "المجلس الاستشاري للشباب والعمل الجمعوي مفعل" },
                    { 262, "262", 3, 2, 1, 24, 16, 2, " الرفع من مستوى آليات تتبع أوضاع الأطفال المتكفل بهم.", null, null, "آليات داعمة لحماية حقوق الأطفال في وضعية كفالة " },
                    { 251, "251", 3, 1, 1, 24, 16, 2, " مواصلة ودعم الجهود الرامية إلى الحد من تزويج القاصرات. ", null, null, "بيئة مساعدة على الحد من تزويج القاصرات " },
                    { 236, "236", 3, 1, 1, 24, 16, 2, " تفعيل المجلس الاستشاري للأسرة والطفولة وإصدار النصوص التشريعية والتنظيمية المتعلقة به.", null, null, "المجلس الاستشاري للأسرة والطفولة مفعل" },
                    { 217, "217", 2, 1, 3, 24, 14, 2, " تشجيع تبادل التجارب والممارسات الفضلى بين المقاولات في مجال احترام حقوق الإنسان في المقاولة.", null, null, "مبادرات داعمة لترسيخ الممارسات الفضلى في مجال المقاولة وحقوق الإنسان " },
                    { 189, "189", 2, 2, 1, 24, 13, 1, " تغطية المجالات البيئية غير المشمولة بالتشريع البيئي والتنمية المستدامة بغية استكمال التأطير القانوني لمختلف هذه المجالات. ", null, null, "إطار تشريعي معزز" },
                    { 178, "178", 2, 2, 1, 24, 12, 1, " جعل التدابير الجبائية التحفيزية لفائدة المنعشين العقاريين المنخرطين في إنجاز مشاريع السكن الاجتماعي تتلاءم وتوفير العرض السكني اللائق لمختلف فئات المجتمع.", null, null, "تدابير تحفيزية داعمة لتكثيف العرض السكني" },
                    { 144, "144", 2, 2, 1, 24, 10, 2, " تطوير سبل التعاون والتنسيق بين القطاع العام والخاص بما يؤمن تجويد الخدمات الصحية والولوج العادل والمتكافئ إليها. ", null, null, "شراكات مساهمة في الارتقاء بالمنظومة الصحية" },
                    { 56, "56", 1, 2, 3, 24, 5, 2, " وضع خطط للإعلام والتواصل مع المواطنات والمواطنين ومهنيي الإعلام بخصوص الحالة الأمنية من خلال تقارير وبلاغات وندوات صحفية ومنشورات.", null, null, "" },
                    { 385, "385", 4, 2, 1, 23, 22, 2, " تفعيل النصوص التنظيمية الخاصة بتنفيذ القانون المتعلق بتحديد شروط التشغيل والشغل الخاص بالعمال المنزليين.", null, null, "المقتضيات القانونية للقانون رقم 19.12 مفعلة" },
                    { 320, "320", 3, 2, 1, 23, 18, 2, " دعم وتشجيع مبادرات المجتمع المدني العامل في مجال الإعاقة.", null, null, "مجتمع مدني متفاعل في مجال الإعاقة" },
                    { 314, "314", 3, 1, 1, 23, 18, 2, "تقنين وتأهيل خدمات مؤسسات الرعاية الاجتماعية.  ", null, null, "  توفر مؤسسات الرعاية الاجتماعية على خدمات ذات جودة" },
                    { 311, "311", 3, 2, 1, 23, 18, 1, " توفير الوسائل التيسيرية لولوج الأشخاص في وضعية إعاقة إلى منظومة العدالة.", null, null, "بنيات منظومة العدالة مساعدة على ولوجها" },
                    { 204, "204", 2, 1, 1, 23, 13, 2, " تشجيع التدريس والبحث العلمي في الجامعة ومعاهد التكوين ومراكز البحث العلمي حول البيئة والتنمية المستدامة.", null, null, "مبادرات داعمة للتدريس والبحث العلمي في مجال البيئة" },
                    { 203, "203", 2, 1, 1, 23, 13, 2, " تيسير ولوج المواطنات المواطنين إلى القضاء عند التعرض للأضرار البيئية لأجل تحقيق عدالة بيئية.", null, null, "معرفة مساعدة على تيسير الحق في العدالة البيئية  " },
                    { 176, "176", 2, 2, 1, 23, 12, 1, " مضاعفة الإمكانيات المالية لصناديق الضمان الموجهة للشرائح الاجتماعية ذات الدخل المحدود والضعيف وغير القار لتمكينها من ولوج القروض السكنية في ظروف ملائمة.", null, null, "آلية مالية داعمة لتمكين الشرائح الاجتماعية ذات الدخل المحدود والضعيف والقار من ولوج السكن" },
                    { 150, "150", 2, 1, 1, 23, 11, 2, " النظر في المصادقة على اتفاقية منظمة العمل الدولية رقم 118 التي تهم المساواة في معاملة مواطني البلد والذين ليسوا من مواطني البلد في مجال الضمان الاجتماعي.", null, null, "بلورة تصور " },
                    { 20, "20", 1, 2, 1, 23, 3, 1, "-20- تسريع إصدار قانون خاص بإعداد التراب الوطني. ", null, null, "" },
                    { 5, "5", 1, 1, 1, 23, 1, 2, "تكريس مبدأ التشاور العمومي في إعداد السياسات العمومية وتنفيذها وتقييمها، وكذا تفعيل دور الجمعيات المهتمة بقضايا الشأن العام والمنظمات غير الحكومية في المساهمة في إعداد القرارات والمشاريع لدى المؤسسات المنتخبة والسلطات العمومية وتفعيلها وتقييمها.", null, null, "مقتضيات قانونية تعزز المشاركة المواطنة" },
                    { 386, "386", 4, 1, 1, 22, 22, 1, "  تعزيز الضمانات القانونية المتعلقة بتجريم التحرش الجنسي.", null, null, "إطار قانوني داعم لحماية النساء ضحايا العنف" },
                    { 358, "358", 3, 2, 3, 22, 20, 1, "مواصلة دعم وتعزيز قدرات فعاليات المجتمع المدني التي تهتم ميدانيا بأوضاع المهاجرين سواء في المغرب أو في بلدان الاستقبال.", null, null, "قدرات فعاليات المجتمع المدني معززة" },
                    { 300, "300", 3, 1, 1, 22, 18, 2, " دعم عمل آلية التنسيق الحكومية ذات الصلة بالمجال.", null, null, "آلية مؤسساتية داعمة لتنفيذ الاستراتيجية" },
                    { 273, "273", 3, 1, 3, 22, 16, 1, " إشاعة ثقافة حقوق الطفل داخل مؤسسات الرعاية الاجتماعية المستقبلة للأطفال.", null, null, "ثقافة حقوق الطفل مشاعة داخل مؤسسات الرعاية الاجتماعية" },
                    { 260, "260", 3, 2, 1, 22, 16, 1, "وضع تصنيفات ودفاتر تحملات خاصة بأصناف مؤسسات الرعاية الاجتماعية المستقبلة للأطفال في حاجة للحماية.", null, null, "مؤسسات الرعاية الاجتماعية المستقبلة للأطفال مصنفة" },
                    { 243, "243", 3, 2, 1, 22, 16, 1, " مواصلة الحوار المجتمعي حول مراجعة المادة 20 من مدونة الأسرة المتعلقة بالإذن بزواج القاصر.", null, null, "حوار مجتمعي منظم" },
                    { 182, "182", 2, 2, 3, 22, 12, 2, "إعداد مواد مرجعية بيداغوجية حول ثقافة حقوق الإنسان وقيمتها الدستورية موجهة لطلبة الدراسات العليا في مجال الهندسة المعمارية.", null, null, "آليات داعمة لإدماج ثقافة حقوق الإنسان في منهاج التكوين" },
                    { 177, "177", 2, 1, 1, 22, 12, 1, "تفعيل القانون المتعلق بالمباني الآيلة للسقوط وتنظيم عمليات التجديد الحضري ووضع برامج متكاملة لمعالجة السكن المهدد بالانهيار لتشمل مجموع التراب الوطني.", null, null, "إطار مؤسساتي وتنظيمي داعم لمعالجة إشكالية السكن المهدد بالانهيار" },
                    { 172, "172", 2, 1, 1, 22, 12, 1, " الإسراع باعتماد المرسوم المتعلق بتحديد النفوذ الترابي للوكالات الحضرية، طبقا للتقسيم الترابي الجديد.", null, null, "" },
                    { 170, "170", 2, 1, 1, 22, 12, 2, " إسراع وتيرة إنجاز برامج القضاء على السكن غير اللائق.", null, null, "برامج مساهمة في القضاء على السكن غير اللائق" },
                    { 346, "346", 3, 2, 1, 24, 20, 2, " مواصلة تطوير الاتفاقيات الخاصة بالحماية الاجتماعية المبرمة بين المغرب ودول الاستقبال وفق مقاربة حقوق الإنسان.", null, null, "الإطار الاتفاقي الثنائي في مجال الحماية الاجتماعية معزز وفق مقاربة حقوق الانسان" },
                    { 363, "363", 4, 2, 1, 24, 21, 1, "الإسراع باعتماد قانون جديد منظم للسجون بما يضمن أنسنة المؤسسات السجنية وتحسين ظروف إقامة النزلاء وتغذيتهم وحماية باقي حقوقهم.", null, null, "إطار قانوني داعم لأنسنة المؤسسات السجنية  " },
                    { 364, "364", 4, 1, 1, 24, 21, 2, "الإسراع بإخراج المقتضيات القانونية الناظمة للعقوبات البديلة بهدف الحد من إشكالات الاعتقال الاحتياطي والاكتظاظ في السجون.", null, null, "مقتضيات قانونية داعمة لتجويد خدمات المؤسسة السجنية" },
                    { 368, "368", 4, 2, 1, 24, 21, 1, "إحداث مرصد وطني للإجرام.", null, null, "آلية مؤسساتية مساعدة على تتبع تطور ظاهرة الإجرام" },
                    { 41, "41", 1, 1, 1, 27, 4, 1, " تقوية الحوار العمومي حول منجز مؤسسات الرقابة والحكامة.", null, null, "" },
                    { 23, "23", 1, 2, 1, 27, 3, 1, " تقوية خدمات القرب وإلزامية تقييم السياسات العمومية وإحداث جهاز مؤسساتي متخصص في هذا المجال.", null, null, "" },
                    { 11, "11", 1, 1, 3, 27, 1, 2, " إحداث فضاءات لإثراء مشاركة اليافعين والشباب في الوسط التربوي والهيئات التمثيلية.", null, null, "برامج ومبادرات داعمة لمشاركة الشباب واليافعين" },
                    { 10, "10", 1, 1, 3, 27, 1, 2, " وضع برامج لتربية الأطفال على قيم المواطنة في الوسط التربوي ودعم برلمان الطفل وكافة أشكال تفعيل حقوق المشاركة لدى الأطفال.", null, null, "برامج داعمة لقيم المواطنة ومشاركة الأطفال " },
                    { 4, "4", 1, 2, 1, 27, 1, 1, "الإسراع بتفعيل هيئة المناصفة ومكافحة جميع أشكال التمييز. ", null, null, "هيئة المناصفة ومكافحة جميع أشكال التمييز مفعلة." },
                    { 359, "359", 3, 2, 3, 26, 20, 2, " إعداد برامج للتكوين والتكوين المستمر تستحضر البعد الحقوقي وتستهدف الجمعيات التي تعمل مع المغاربة في الخارج والمهاجرين بالمغرب.", null, null, "قدرات فعاليات المجتمع المدني معززة" },
                    { 348, "348", 3, 1, 1, 26, 20, 2, "ضمان حماية النساء المغربيات المهاجرات وتعزيز الجهود الحكومية ذات الصلة.", null, null, "آلية لتعزيز حماية النساء المغربيات المهاجرات محدثة ومفعلة" },
                    { 322, "322", 3, 2, 1, 26, 18, 1, " دعم دور القطاع الخاص للمساهمة في مسلسل الإدماج الاجتماعي للأشخاص في وضعية إعاقة. ", null, null, "قطاع خاص منخرط في الإدماج الاجتماعي للأشخاص في وضعية إعاقة" },
                    { 319, "319", 3, 1, 1, 26, 18, 2, " البحث في سبل إشراك القطاع الخاص في إدماج الأشخاص في وضعية إعاقة في سوق الشغل.", null, null, "آلية مشتركة مساعدة على إدماج الأشخاص في وضعية إعاقة في سوق الشغل" },
                    { 237, "237", 3, 2, 1, 26, 16, 2, " الإسراع بإحداث وتفعيل الآلية الوطنية للتظلم الخاصة بالأطفال ضحايا انتهاكات حقوق الطفل.", null, null, "الآلية الوطنية للتظلم الخاصة بالأطفال ضحايا انتهاكات حقوق الطفل مفعلة" },
                    { 232, "232", 3, 2, 1, 26, 15, 2, "مراجعة الإطار القانوني المتعلق بالإحسان العمومي.           ", null, null, "إطار قانوني داعم لتجويد مبادرات الإحسان العمومي" },
                    { 185, "185", 2, 2, 1, 26, 13, 2, " مراجعة النصوص التشريعية والتنظيمية مع المعايير ذات الصلة بالجودة البيئية الجاري بها العمل لاسيما التشريع المتعلق بالماء والطاقات المتجددة والتنوع البيولوجي ومحاربة تلوث الهواء والتغييرات المناخية وتدبير وتثمين النفايات والتقييم البيئي واستصلاح البيئة ووضع تدابير لردع وزجر المخالفات البيئية. ", null, null, "إطار قانوني متلائم" },
                    { 124, "124", 2, 2, 1, 26, 9, 2, "وضع ميثاق وطني في مجال التنوع الثقافي موجه إلى كافة المتدخلين والفاعلين.", null, null, "ميثاق وطني في مجال التنوع الثقافي معتمد" },
                    { 104, "104", 2, 1, 1, 26, 9, 2, "تعزيز مكانة الثقافة والموروث الحساني في النموذج التنموي الخاص بالأقاليم الجنوبية وضمن التطور المجتمعي الوطني", null, null, "برامج معززة لمكانة الموروث الثقافي الحساني في النموذج التنموي" },
                    { 92, "92", 2, 1, 1, 27, 8, 2, "  تفعيل مجالس التدبير وتعزيز أدوارها باعتبارها أداة لتحقيق تدبير تشاركي للشأن التعليمي", null, null, "" },
                    { 71, "71", 1, 2, 1, 26, 7, 1, "مواصلة تجريم كل الأفعال التي تمثل انتهاكا جسيما لحقوق الإنسان وفقا لأحكام الدستور.", null, null, "" },
                    { 365, "365", 4, 1, 1, 25, 21, 1, "مواصلة الحوار المجتمعي حول الانضمام إلى البروتوكول الاختياري الثاني الملحق بالعهد الدولي الخاص بالحقوق المدنية والسياسية المتعلق بإلغاء عقوبة الاعدام. ", null, null, "حوار مجتمعي منظم" },
                    { 362, "362", 4, 1, 1, 25, 21, 2, "الإسراع باعتماد مشروعي القانون الجنائي وقانون المسطرة الجنائية.", null, null, "منظومة جنائية معتمدة" },
                    { 343, "343", 3, 1, 1, 25, 20, 2, " مواصلة التفكير في سبل تفعيل مقتضيات الدستور ذات الصلة بحقوق مغاربة العالم.", null, null, "تصورات حول تفعيل مقتضيات الدستور ذات الصلة بحقوق مغاربة العالم مبلورة" },
                    { 337, "337", 3, 2, 1, 25, 19, 2, "دعم الأسر التي تحتضن أفرادا مسنين في وضعية صعبة.", null, null, "إطار داعم لخدمات التكفل بالأفراد المسنين في وضعية صعبة" },
                    { 301, "301", 3, 2, 1, 25, 18, 2, " إحداث مركز وطني للرصد والتوثيق والبحث في مجال الإعاقة.", null, null, "" },
                    { 286, "286", 3, 1, 1, 25, 17, 1, " إعداد وتعميم تقارير دورية حول الشباب.", null, null, "تقارير مساعدة على تتبع وضعية الشباب" },
                    { 138, "138", 2, 2, 1, 25, 10, 1, " إحداث خلايا تساعد الأطر الصحية على التواصل مع المرضى المتحدثين بالأمازيغية والحسانية.", null, null, "بنيات داعمة للتواصل مع المرضى المتحدثين باللغة الأمازيغية والحسانية" },
                    { 136, "136", 2, 2, 1, 25, 10, 1, " مواصلة تحسين جودة الخدمات وتوسيع التغطية لتشمل باقي الفئات الأخرى وضمان التوزيع العادل للموارد على كافة التراب الوطني. ", null, null, "برامج داعمة لتعميم وتجويد الخدمات الصحية" },
                    { 129, "129", 2, 1, 1, 25, 10, 2, " دعم ولوج الفئات الأكثر هشاشة للخدمات الصحية.", null, null, "برامج داعمة لتعميم الخدمات الصحية." },
                    { 72, "72", 1, 1, 1, 25, 7, 2, "تكريس مبدأ عدم الإفلات من العقاب في السياسة الجنائية وفي سائر التدابير العمومية.", null, null, "" },
                    { 30, "30", 1, 1, 1, 25, 4, 2, "الإسراع بوضع المقتضيات التنظيمية الخاصة بالتدابير المتعلقة بالوقاية من الفساد. ", null, null, "" },
                    { 9, "9", 1, 1, 3, 25, 1, 1, "دعم وتشجيع البرامج والأنشطة المتعلقة بالتنشئة السياسية والاجتماعية الهادفة إلى نشر قيم الديمقراطية والمساواة والتعدد والاختلاف والتسامح والعيش المشترك وعدم التمييز ونبذ الكراهية والعنف والتطرف.", null, null, "مجتمع داعم لقيم الديمقراطية" },
                    { 7, "7", 1, 2, 3, 25, 1, 1, "تعزيز دور وسائل الإعلام في مجال التوعية والاتصال والحوار العمومي بشأن المشاركة السياسية.", null, null, "برامج داعمة للمشاركة السياسية" },
                    { 407, "407", 4, 1, 1, 24, 23, 2, "التنصيص على مبدأ المناصفة في دفاتر تحملات شركات الاتصال السمعي البصري.", null, null, "بيئة إعلامية معززة لمبدأ المناصفة في الفضاء السمعي البصري " },
                    { 46, "46", 1, 2, 1, 26, 5, 1, "مراجعة المقتضيات القانونية بما يضمن إلزامية إجراء الخبرة الطبية في حالة ادعاء التعرض للتعذيب واعتبار المحاضر المنجزة باطلة في حالة رفض إجراءها بعد طلبها من طرف المتهم أو دفاعه. ", null, null, "" },
                    { 148, "148", 2, 1, 3, 22, 10, 1, "تعزيز البرامج السمعية البصرية المتعلقة بالحق في الصحة", null, null, "برامج سمعية بصرية داعمة للحق في الصحة" },
                    { 282, "282", 3, 2, 1, 31, 17, 2, "مراجعة القوانين التنظيمية للجماعات الترابية بكيفية تمكن الشباب من المساهمة الفعالة في تدبير الشأن المحلي.", null, null, "إطار قانوني تنظيمي داعم لمساهمة الشباب في تدبير الشأن المحلي" },
                    { 293, "293", 3, 2, 3, 31, 17, 2, "تعزيز مواكبة الشباب ودعمهم في مجالات الادماج الاقتصادي والمهني والاجتماعي.", null, null, "آليات داعمة لقدرات الشباب على الاندماج الاقتصادي والمهني والاجتماعي" },
                    { 492, "Code : {id - 1}", 3, 1, 2, 48, 6, 3, "492 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 492", "بعد الأهداف الخاصة : 492", "بعد النتائج المرتقبة : 492" },
                    { 491, "Code : {id - 1}", 2, 2, 2, 48, 26, 2, "491 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 491", "بعد الأهداف الخاصة : 491", "بعد النتائج المرتقبة : 491" },
                    { 530, "Code : {id - 1}", 2, 3, 3, 47, 15, 1, "530 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 530", "بعد الأهداف الخاصة : 530", "بعد النتائج المرتقبة : 530" },
                    { 528, "Code : {id - 1}", 2, 1, 1, 47, 19, 3, "528 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 528", "بعد الأهداف الخاصة : 528", "بعد النتائج المرتقبة : 528" },
                    { 523, "Code : {id - 1}", 2, 1, 3, 47, 4, 3, "523 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 523", "بعد الأهداف الخاصة : 523", "بعد النتائج المرتقبة : 523" },
                    { 521, "Code : {id - 1}", 3, 2, 3, 47, 12, 1, "521 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 521", "بعد الأهداف الخاصة : 521", "بعد النتائج المرتقبة : 521" },
                    { 519, "Code : {id - 1}", 2, 1, 2, 47, 7, 3, "519 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 519", "بعد الأهداف الخاصة : 519", "بعد النتائج المرتقبة : 519" },
                    { 511, "Code : {id - 1}", 1, 3, 3, 47, 24, 2, "511 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 511", "بعد الأهداف الخاصة : 511", "بعد النتائج المرتقبة : 511" },
                    { 507, "Code : {id - 1}", 2, 1, 2, 47, 18, 1, "507 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 507", "بعد الأهداف الخاصة : 507", "بعد النتائج المرتقبة : 507" },
                    { 503, "Code : {id - 1}", 1, 1, 1, 47, 7, 1, "503 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 503", "بعد الأهداف الخاصة : 503", "بعد النتائج المرتقبة : 503" },
                    { 499, "Code : {id - 1}", 1, 2, 1, 47, 15, 1, "499 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 499", "بعد الأهداف الخاصة : 499", "بعد النتائج المرتقبة : 499" },
                    { 494, "Code : {id - 1}", 2, 3, 3, 47, 18, 3, "494 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 494", "بعد الأهداف الخاصة : 494", "بعد النتائج المرتقبة : 494" },
                    { 493, "Code : {id - 1}", 3, 3, 3, 47, 8, 1, "493 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 493", "بعد الأهداف الخاصة : 493", "بعد النتائج المرتقبة : 493" },
                    { 488, "Code : {id - 1}", 1, 2, 1, 47, 1, 3, "488 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 488", "بعد الأهداف الخاصة : 488", "بعد النتائج المرتقبة : 488" },
                    { 480, "Code : {id - 1}", 1, 2, 2, 46, 16, 2, "480 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 480", "بعد الأهداف الخاصة : 480", "بعد النتائج المرتقبة : 480" },
                    { 474, "Code : {id - 1}", 4, 1, 2, 46, 23, 2, "474 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 474", "بعد الأهداف الخاصة : 474", "بعد النتائج المرتقبة : 474" },
                    { 455, "Code : {id - 1}", 3, 3, 2, 46, 11, 1, "455 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 455", "بعد الأهداف الخاصة : 455", "بعد النتائج المرتقبة : 455" },
                    { 485, "Code : {id - 1}", 2, 1, 1, 45, 22, 3, "485 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 485", "بعد الأهداف الخاصة : 485", "بعد النتائج المرتقبة : 485" },
                    { 481, "Code : {id - 1}", 2, 2, 2, 45, 4, 1, "481 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 481", "بعد الأهداف الخاصة : 481", "بعد النتائج المرتقبة : 481" },
                    { 476, "Code : {id - 1}", 3, 1, 3, 45, 17, 3, "476 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 476", "بعد الأهداف الخاصة : 476", "بعد النتائج المرتقبة : 476" },
                    { 452, "Code : {id - 1}", 1, 1, 3, 45, 3, 1, "452 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 452", "بعد الأهداف الخاصة : 452", "بعد النتائج المرتقبة : 452" },
                    { 443, "Code : {id - 1}", 2, 2, 1, 45, 6, 3, "443 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 443", "بعد الأهداف الخاصة : 443", "بعد النتائج المرتقبة : 443" },
                    { 475, "Code : {id - 1}", 1, 3, 1, 44, 10, 3, "475 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 475", "بعد الأهداف الخاصة : 475", "بعد النتائج المرتقبة : 475" },
                    { 461, "Code : {id - 1}", 1, 3, 1, 44, 14, 2, "461 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 461", "بعد الأهداف الخاصة : 461", "بعد النتائج المرتقبة : 461" },
                    { 458, "Code : {id - 1}", 1, 1, 3, 44, 16, 2, "458 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 458", "بعد الأهداف الخاصة : 458", "بعد النتائج المرتقبة : 458" },
                    { 451, "Code : {id - 1}", 2, 2, 1, 44, 18, 2, "451 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 451", "بعد الأهداف الخاصة : 451", "بعد النتائج المرتقبة : 451" },
                    { 436, "Code : {id - 1}", 1, 1, 2, 44, 15, 1, "436 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 436", "بعد الأهداف الخاصة : 436", "بعد النتائج المرتقبة : 436" },
                    { 482, "Code : {id - 1}", 2, 1, 2, 43, 7, 1, "482 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 482", "بعد الأهداف الخاصة : 482", "بعد النتائج المرتقبة : 482" },
                    { 469, "Code : {id - 1}", 2, 1, 1, 43, 7, 3, "469 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 469", "بعد الأهداف الخاصة : 469", "بعد النتائج المرتقبة : 469" },
                    { 502, "Code : {id - 1}", 1, 3, 3, 48, 10, 1, "502 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 502", "بعد الأهداف الخاصة : 502", "بعد النتائج المرتقبة : 502" },
                    { 505, "Code : {id - 1}", 1, 1, 1, 48, 3, 1, "505 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 505", "بعد الأهداف الخاصة : 505", "بعد النتائج المرتقبة : 505" },
                    { 516, "Code : {id - 1}", 3, 1, 1, 48, 19, 1, "516 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 516", "بعد الأهداف الخاصة : 516", "بعد النتائج المرتقبة : 516" },
                    { 518, "Code : {id - 1}", 3, 1, 2, 48, 19, 3, "518 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 518", "بعد الأهداف الخاصة : 518", "بعد النتائج المرتقبة : 518" },
                    { 525, "Code : {id - 1}", 1, 3, 2, 50, 25, 3, "525 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 525", "بعد الأهداف الخاصة : 525", "بعد النتائج المرتقبة : 525" },
                    { 522, "Code : {id - 1}", 3, 3, 2, 50, 19, 2, "522 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 522", "بعد الأهداف الخاصة : 522", "بعد النتائج المرتقبة : 522" },
                    { 515, "Code : {id - 1}", 3, 1, 1, 50, 17, 2, "515 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 515", "بعد الأهداف الخاصة : 515", "بعد النتائج المرتقبة : 515" },
                    { 514, "Code : {id - 1}", 4, 1, 2, 50, 22, 2, "514 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 514", "بعد الأهداف الخاصة : 514", "بعد النتائج المرتقبة : 514" },
                    { 512, "Code : {id - 1}", 2, 3, 1, 50, 19, 3, "512 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 512", "بعد الأهداف الخاصة : 512", "بعد النتائج المرتقبة : 512" },
                    { 508, "Code : {id - 1}", 2, 2, 1, 50, 5, 3, "508 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 508", "بعد الأهداف الخاصة : 508", "بعد النتائج المرتقبة : 508" }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[,]
                {
                    { 506, "Code : {id - 1}", 2, 3, 2, 50, 7, 2, "506 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 506", "بعد الأهداف الخاصة : 506", "بعد النتائج المرتقبة : 506" },
                    { 504, "Code : {id - 1}", 2, 1, 1, 50, 1, 2, "504 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 504", "بعد الأهداف الخاصة : 504", "بعد النتائج المرتقبة : 504" },
                    { 500, "Code : {id - 1}", 3, 2, 2, 50, 17, 3, "500 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 500", "بعد الأهداف الخاصة : 500", "بعد النتائج المرتقبة : 500" },
                    { 497, "Code : {id - 1}", 3, 1, 1, 50, 13, 2, "497 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 497", "بعد الأهداف الخاصة : 497", "بعد النتائج المرتقبة : 497" },
                    { 495, "Code : {id - 1}", 4, 1, 1, 50, 12, 2, "495 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 495", "بعد الأهداف الخاصة : 495", "بعد النتائج المرتقبة : 495" },
                    { 490, "Code : {id - 1}", 1, 2, 2, 50, 7, 2, "490 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 490", "بعد الأهداف الخاصة : 490", "بعد النتائج المرتقبة : 490" },
                    { 536, "Code : {id - 1}", 3, 1, 3, 49, 21, 1, "536 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 536", "بعد الأهداف الخاصة : 536", "بعد النتائج المرتقبة : 536" },
                    { 532, "Code : {id - 1}", 4, 3, 3, 49, 24, 1, "532 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 532", "بعد الأهداف الخاصة : 532", "بعد النتائج المرتقبة : 532" },
                    { 448, "Code : {id - 1}", 2, 3, 3, 43, 15, 3, "448 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 448", "بعد الأهداف الخاصة : 448", "بعد النتائج المرتقبة : 448" },
                    { 529, "Code : {id - 1}", 3, 1, 3, 49, 11, 1, "529 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 529", "بعد الأهداف الخاصة : 529", "بعد النتائج المرتقبة : 529" },
                    { 520, "Code : {id - 1}", 1, 2, 3, 49, 22, 3, "520 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 520", "بعد الأهداف الخاصة : 520", "بعد النتائج المرتقبة : 520" },
                    { 517, "Code : {id - 1}", 1, 2, 3, 49, 14, 1, "517 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 517", "بعد الأهداف الخاصة : 517", "بعد النتائج المرتقبة : 517" },
                    { 513, "Code : {id - 1}", 3, 2, 1, 49, 25, 2, "513 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 513", "بعد الأهداف الخاصة : 513", "بعد النتائج المرتقبة : 513" },
                    { 510, "Code : {id - 1}", 2, 2, 3, 49, 24, 1, "510 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 510", "بعد الأهداف الخاصة : 510", "بعد النتائج المرتقبة : 510" },
                    { 509, "Code : {id - 1}", 4, 1, 2, 49, 18, 1, "509 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 509", "بعد الأهداف الخاصة : 509", "بعد النتائج المرتقبة : 509" },
                    { 501, "Code : {id - 1}", 4, 1, 3, 49, 13, 3, "501 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 501", "بعد الأهداف الخاصة : 501", "بعد النتائج المرتقبة : 501" },
                    { 498, "Code : {id - 1}", 2, 2, 3, 49, 13, 2, "498 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 498", "بعد الأهداف الخاصة : 498", "بعد النتائج المرتقبة : 498" },
                    { 496, "Code : {id - 1}", 2, 1, 1, 49, 25, 1, "496 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 496", "بعد الأهداف الخاصة : 496", "بعد النتائج المرتقبة : 496" },
                    { 489, "Code : {id - 1}", 1, 1, 3, 49, 23, 3, "489 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 489", "بعد الأهداف الخاصة : 489", "بعد النتائج المرتقبة : 489" },
                    { 487, "Code : {id - 1}", 2, 3, 3, 49, 17, 3, "487 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 487", "بعد الأهداف الخاصة : 487", "بعد النتائج المرتقبة : 487" },
                    { 535, "Code : {id - 1}", 1, 1, 1, 48, 16, 2, "535 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 535", "بعد الأهداف الخاصة : 535", "بعد النتائج المرتقبة : 535" },
                    { 531, "Code : {id - 1}", 1, 3, 2, 48, 7, 3, "531 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 531", "بعد الأهداف الخاصة : 531", "بعد النتائج المرتقبة : 531" },
                    { 527, "Code : {id - 1}", 3, 1, 1, 48, 26, 1, "527 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 527", "بعد الأهداف الخاصة : 527", "بعد النتائج المرتقبة : 527" },
                    { 526, "Code : {id - 1}", 2, 1, 2, 48, 9, 3, "526 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 526", "بعد الأهداف الخاصة : 526", "بعد النتائج المرتقبة : 526" },
                    { 524, "Code : {id - 1}", 4, 3, 1, 49, 5, 3, "524 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 524", "بعد الأهداف الخاصة : 524", "بعد النتائج المرتقبة : 524" },
                    { 283, "283", 3, 2, 1, 31, 17, 2, "تقوية آليات التنسيق عبر القطاعية الخاصة بالشباب.", null, null, "سياسة وطنية للشباب معتمدة " },
                    { 447, "Code : {id - 1}", 3, 2, 1, 43, 21, 1, "447 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 447", "بعد الأهداف الخاصة : 447", "بعد النتائج المرتقبة : 447" },
                    { 437, "Code : {id - 1}", 3, 2, 3, 43, 16, 2, "437 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 437", "بعد الأهداف الخاصة : 437", "بعد النتائج المرتقبة : 437" },
                    { 380, "380", 4, 1, 1, 33, 22, 2, " البحث في سبل مبادرات الحكومة وهيئات الديمقراطية التشاركية لتنظيم حوارات عمومية حول رصيد إعمال مدونة الأسرة على مستوى الاجتهاد القضائي والتطور المجتمعي.", null, null, "ديناميات داعمة لتطوير مدونة الأسرة " },
                    { 369, "369", 4, 1, 1, 33, 21, 2, "إحداث بنك وطني للبصمات الجينية.", null, null, "آلية داعمة للنجاعة الأمنية " },
                    { 357, "357", 3, 1, 3, 33, 20, 2, " تعزيز البرامج الإعلامية الموجهة إلى المهاجرين.", null, null, "بيئة إعلامية داعمة لحقوق المهاجرين" },
                    { 338, "338", 3, 2, 1, 33, 19, 1, "ضمان التغطية الصحية الإجبارية للأشخاص المسنين غير المستفيدين منها ", null, null, "تغطية صحية شاملة لجميع الأشخاص المسنين" },
                    { 265, "265", 3, 1, 1, 33, 16, 2, "اتخاذ تدابير خاصة بحماية الأطفال المهاجرين غير المرافقين وبولوجهم إلى الخدمات الأساسية لا سيما تلك المتعلقة بالصحة والتربية والتعليم.", null, null, "برامج داعمة لحماية الأطفال المهاجرين غير المرافقين " },
                    { 255, "255", 3, 1, 1, 33, 16, 1, " تعزيز الولوج الآمن للأطفال إلى وسائل الإعلام والاتصال المعتمدة على التكنولوجية الحديثة عبر وضع برامج خاصة وحمايتهم من كافة أشكال الاستغلال.", null, null, "بيئة داعمة لولوج الأطفال الآمن   لوسائل الإعلام والاتصال المعتمدة على التكنولوجيا الحديثة" },
                    { 231, "231", 3, 1, 1, 33, 15, 1, " اعتماد الحكامة الجيدة في تتبع تنفيذ البرامج والاستراتيجيات الخاصة بالفئات في وضعية هشاشة. ", null, null, "آليات داعمة لضمان الحكامة الجيدة في تتبع البرامج الخاصة بالفئات في وضعية هشاشة" },
                    { 223, "223", 3, 2, 1, 33, 15, 1, "مواصلة إدماج ثقافة حقوق الإنسان ذات الصلة بالحقوق الفئوية في برامج المعهد العالي للقضاء والمهن القضائية.", null, null, "قدرات متطورة في مجال التكوين القضائي التخصصي   " },
                    { 208, "208", 2, 2, 3, 33, 13, 2, " النهوض بثقافة حماية البيئة عبر التربية والتكوين والتكوين المستمر والتحسيس.", null, null, "برامج داعمة للنهوض بالثقافة البيئية " },
                    { 196, "196", 2, 2, 1, 33, 13, 1, " تفعيل سياسة القرب في مجال تدبير البيئة وتسريع وتيرة تنفيذها.", null, null, "إطار مؤسساتي داعم لسياسة القرب" },
                    { 186, "186", 2, 2, 1, 33, 13, 2, " الإسراع بإصدار القانون المتعلق بالحصول على الموارد الجينية والتقاسم العادل والمنصف للمنافع الناشئة عن استخدامها إعمالا للاتفاقية المتعلقة بالتنوع البيولوجي وبروتوكول ناغويا.", null, null, "إطار قانوني معتمد وفق المعايير الدولية ذات الصلة " },
                    { 167, "167", 2, 1, 1, 33, 12, 2, "وضع مقتضيات قانونية وتنظيمية تخص المعايير الدنيا المطبقة على السكن الاجتماعي من حيث المواصفات العمرانية والمناطق الخضراء والسلامة الأمنية والولوجيات.", null, null, "منظومة قانونية داعمة للسكن الاجتماعي " },
                    { 98, "98", 2, 1, 1, 33, 9, 1, "  الإسراع بإصدار القانون التنظيمي المتعلق بالمجلس الوطني للغات والثقافة المغربية", null, null, "" },
                    { 400, "400", 4, 2, 3, 32, 22, 2, "محاربة الصور النمطية والتمييزية ضد النساء في وسائل الإعلام وفي البرامج والمقررات المدرسية.", null, null, "بيئة داعمة لمكافحة الصور النمطية والتمييزية ضد النساء" },
                    { 396, "396", 4, 1, 1, 32, 22, 1, "تعزيز البرامج الخاصة بالقضاء على الفقر والتهميش والإقصاء الاجتماعي في أوساط النساء.", null, null, "البرامج الخاصة بالقضاء على الفقر والتهميش والإقصاء الاجتماعي في أوساط النساء معززة" },
                    { 356, "356", 3, 2, 3, 32, 20, 2, " تعميم ونشر التقارير الوطنية عن الهجرة وبأوضاع المهاجرين.", null, null, "التقارير الوطنية عن الهجرة وأوضاع المهاجرين معممة ومنشورة " },
                    { 289, "289", 3, 2, 3, 32, 17, 1, " الرفع من عدد البرامج المعدة من الشباب والموجهة إليهم في دفاتر تحملات الشركات العمومية للاتصال السمعي البصري.", null, null, "برامج إعلامية محفزة على مشاركة الشباب " },
                    { 285, "285", 3, 2, 1, 32, 17, 2, " وضع برامج استعجالية لفائدة فئات الشباب الأكثر هشاشة (في وضعية إعاقة أو إقصاء...).", null, null, "برامج مساعدة على إدماج الشباب الأكثر هشاشة " },
                    { 247, "247", 3, 1, 1, 32, 16, 1, "نقل جميع الاختصاصات المخولة للجنة العليا للحالة المدنية في موضوع الأسماء العائلية إلى القضاء.", null, null, "آليات وسبل إعمال الحق في الهوية معززة " },
                    { 160, "160", 2, 1, 1, 32, 11, 1, " تقوية هيئة مفتشي الشغل.", null, null, "هيئة مفتشي الشغل معززة " },
                    { 157, "157", 2, 2, 1, 32, 11, 2, " تشجيع المشاريع المذرة للدخل.", null, null, "برامج داعمة للمقاولات الصغرى  والمتوسطة / أنشطة داعمة لتحسين الدخل والإدماج الاقتصادي" },
                    { 147, "147", 2, 2, 3, 32, 10, 1, "القيام بحملات للتوعية داخل المستشفيات والمراكز والمستوصفات الصحية (ملصقات ومنشورات وأشرطة سمعية بصرية...) من أجل توعية المواطنات والمواطنين بحقوقهم وواجباتهم باللغات المتداولة.", null, null, "مبادرات مساهمة في النهوض بثقافة الحق والواجب                  " },
                    { 123, "123", 2, 2, 1, 32, 9, 1, "تمكين الشباب من المساهمة الفاعلة في تدبير الحياة الثقافية والتحفيز على الولوج إليها", null, null, "مناخ داعم لمبادرات الشباب في المجال الثقافي " },
                    { 117, "117", 2, 1, 1, 32, 9, 2, " تعميم المكتبات ومراكز التنشيط الثقافي والمسرحي والفني في المناطق التي تفتقر للبنيات التحتية الثقافية.", null, null, "بنيات مشجعة على الحياة الثقافية " },
                    { 32, "32", 1, 2, 1, 32, 4, 1, " اعتماد المقاربة التشاركية عند إعداد المقترحات المتعلقة بمجالات مكافحة الفساد. ", null, null, "" },
                    { 14, "14", 1, 1, 1, 32, 2, 1, " تفعيل مقتضيات القانون التنظيمي لقانون المالية المتعلق بالإدماج العرضاني لمقاربة النوع في السياسات العمومية.", null, null, "" },
                    { 429, "429", 4, 2, 1, 31, 26, 2, "مواصلة جهود تخليق العدالة.", null, null, "دينامية داعمة لتخليق العدالة" },
                    { 366, "366", 4, 1, 1, 31, 21, 1, " مواصلة الحوار المجتمعي بشأن المصادقة على النظام الأساسي للمحكمة الجنائية الدولية.", null, null, "حوار مجتمعي منظم" },
                    { 321, "321", 3, 2, 1, 31, 18, 1, " تعميم ولوج الأشخاص في وضعية إعاقة إلى الخدمات الثقافية من خلال اعتماد الوسائل التقنية الحديثة سواء في المؤسسات التعليمية أو المكتبات والمركبات الثقافية والبنيات الرياضية.", null, null, "فضاءات مساعدة على ولوج الأشخاص في وضعية إعاقة إلى الخدمات الثقافية" },
                    { 381, "381", 4, 1, 1, 33, 22, 2, " تعزيز الخطة الحكومية للمساواة في أفق المناصفة إكرام 2", null, null, "الإعمال الناجع لخطة إكرام 2" },
                    { 382, "382", 4, 2, 1, 33, 22, 2, " تعزيز حماية النساء ضد العنف على مستوى التشريع والسياسة الجنائية الوطنية.", null, null, "إطار قانوني داعم لحماية النساء ضحايا العنف" },
                    { 399, "399", 4, 2, 3, 33, 22, 2, "توسيع شبكة الفضاءات متعددة الاختصاصات والوظائف الموجهة للنساء وتعزيزها وتقويتها.", null, null, "نسيج مؤسساتي داعم ومنصف للنساء" },
                    { 454, "Code : {id - 1}", 4, 1, 3, 35, 13, 2, "454 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 454", "بعد الأهداف الخاصة : 454", "بعد النتائج المرتقبة : 454" },
                    { 477, "Code : {id - 1}", 1, 3, 1, 42, 24, 1, "477 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 477", "بعد الأهداف الخاصة : 477", "بعد النتائج المرتقبة : 477" },
                    { 473, "Code : {id - 1}", 1, 1, 3, 42, 13, 2, "473 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 473", "بعد الأهداف الخاصة : 473", "بعد النتائج المرتقبة : 473" },
                    { 470, "Code : {id - 1}", 4, 2, 2, 42, 20, 3, "470 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 470", "بعد الأهداف الخاصة : 470", "بعد النتائج المرتقبة : 470" },
                    { 462, "Code : {id - 1}", 1, 1, 2, 42, 4, 1, "462 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 462", "بعد الأهداف الخاصة : 462", "بعد النتائج المرتقبة : 462" },
                    { 446, "Code : {id - 1}", 2, 3, 1, 42, 1, 3, "446 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 446", "بعد الأهداف الخاصة : 446", "بعد النتائج المرتقبة : 446" },
                    { 478, "Code : {id - 1}", 2, 3, 2, 41, 18, 1, "478 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 478", "بعد الأهداف الخاصة : 478", "بعد النتائج المرتقبة : 478" },
                    { 442, "Code : {id - 1}", 1, 3, 3, 41, 8, 3, "442 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 442", "بعد الأهداف الخاصة : 442", "بعد النتائج المرتقبة : 442" },
                    { 483, "Code : {id - 1}", 1, 3, 3, 40, 16, 3, "483 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 483", "بعد الأهداف الخاصة : 483", "بعد النتائج المرتقبة : 483" },
                    { 464, "Code : {id - 1}", 4, 1, 2, 40, 24, 2, "464 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 464", "بعد الأهداف الخاصة : 464", "بعد النتائج المرتقبة : 464" },
                    { 445, "Code : {id - 1}", 1, 1, 2, 40, 1, 2, "445 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 445", "بعد الأهداف الخاصة : 445", "بعد النتائج المرتقبة : 445" },
                    { 438, "Code : {id - 1}", 3, 3, 3, 40, 4, 3, "438 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 438", "بعد الأهداف الخاصة : 438", "بعد النتائج المرتقبة : 438" },
                    { 479, "Code : {id - 1}", 2, 2, 3, 38, 23, 3, "479 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 479", "بعد الأهداف الخاصة : 479", "بعد النتائج المرتقبة : 479" },
                    { 471, "Code : {id - 1}", 1, 1, 1, 38, 1, 3, "471 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 471", "بعد الأهداف الخاصة : 471", "بعد النتائج المرتقبة : 471" },
                    { 465, "Code : {id - 1}", 2, 2, 1, 38, 26, 3, "465 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 465", "بعد الأهداف الخاصة : 465", "بعد النتائج المرتقبة : 465" },
                    { 440, "Code : {id - 1}", 4, 1, 2, 43, 25, 2, "440 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 440", "بعد الأهداف الخاصة : 440", "بعد النتائج المرتقبة : 440" },
                    { 459, "Code : {id - 1}", 3, 2, 2, 38, 2, 2, "459 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 459", "بعد الأهداف الخاصة : 459", "بعد النتائج المرتقبة : 459" },
                    { 449, "Code : {id - 1}", 2, 3, 1, 38, 19, 3, "449 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 449", "بعد الأهداف الخاصة : 449", "بعد النتائج المرتقبة : 449" },
                    { 441, "Code : {id - 1}", 4, 3, 3, 38, 25, 3, "441 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 441", "بعد الأهداف الخاصة : 441", "بعد النتائج المرتقبة : 441" },
                    { 472, "Code : {id - 1}", 2, 1, 2, 37, 5, 1, "472 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 472", "بعد الأهداف الخاصة : 472", "بعد النتائج المرتقبة : 472" },
                    { 468, "Code : {id - 1}", 1, 2, 2, 37, 26, 3, "468 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 468", "بعد الأهداف الخاصة : 468", "بعد النتائج المرتقبة : 468" },
                    { 453, "Code : {id - 1}", 3, 3, 3, 37, 26, 2, "453 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 453", "بعد الأهداف الخاصة : 453", "بعد النتائج المرتقبة : 453" },
                    { 467, "Code : {id - 1}", 1, 1, 2, 36, 26, 2, "467 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 467", "بعد الأهداف الخاصة : 467", "بعد النتائج المرتقبة : 467" },
                    { 463, "Code : {id - 1}", 3, 3, 2, 36, 25, 2, "463 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 463", "بعد الأهداف الخاصة : 463", "بعد النتائج المرتقبة : 463" },
                    { 460, "Code : {id - 1}", 3, 2, 2, 36, 18, 3, "460 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 460", "بعد الأهداف الخاصة : 460", "بعد النتائج المرتقبة : 460" },
                    { 444, "Code : {id - 1}", 1, 2, 3, 36, 11, 3, "444 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 444", "بعد الأهداف الخاصة : 444", "بعد النتائج المرتقبة : 444" },
                    { 439, "Code : {id - 1}", 2, 2, 1, 36, 16, 1, "439 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 439", "بعد الأهداف الخاصة : 439", "بعد النتائج المرتقبة : 439" },
                    { 484, "Code : {id - 1}", 4, 2, 2, 35, 18, 1, "484 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 484", "بعد الأهداف الخاصة : 484", "بعد النتائج المرتقبة : 484" },
                    { 466, "Code : {id - 1}", 2, 3, 2, 35, 12, 3, "466 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 466", "بعد الأهداف الخاصة : 466", "بعد النتائج المرتقبة : 466" },
                    { 457, "Code : {id - 1}", 1, 1, 3, 35, 7, 3, "457 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 457", "بعد الأهداف الخاصة : 457", "بعد النتائج المرتقبة : 457" },
                    { 456, "Code : {id - 1}", 2, 1, 2, 35, 2, 2, "456 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 456", "بعد الأهداف الخاصة : 456", "بعد النتائج المرتقبة : 456" },
                    { 450, "Code : {id - 1}", 4, 2, 2, 38, 1, 1, "450 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 450", "بعد الأهداف الخاصة : 450", "بعد النتائج المرتقبة : 450" },
                    { 533, "Code : {id - 1}", 2, 1, 2, 50, 18, 1, "533 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 533", "بعد الأهداف الخاصة : 533", "بعد النتائج المرتقبة : 533" },
                    { 109, "109", 2, 2, 1, 22, 9, 2, "تشجيع إحداث محطات إذاعية تستخدم اللغات المتداولة وتلبي حاجيات المواطنين على مستوى الإعلام والتثقيف والتوعية والترفيه.", null, null, "محطات جهوية متفاعلة مع محيطها" },
                    { 55, "55", 1, 1, 1, 22, 5, 2, "تقوية أداء المؤسسة البرلمانية في مجال التقصي حول انتهاكات حقوق الإنسان مع إخضاع الأجهزة الأمنية للرقابة البرلمانية.", null, null, "" },
                    { 308, "308", 3, 1, 1, 8, 18, 2, "تفعيل وتقوية آليات الإدماج المهني للأشخاص في وضعية إعاقة في أنظمة التكوين المهني والتشغيل الذاتي واستخدام آليات التمييز الإيجابي والنهوض بمراكز العمل المحمية.", null, null, "آليات داعمة للإدماج المهني للأشخاص في وضعية إعاقة " },
                    { 305, "305", 3, 1, 1, 8, 18, 2, "النهوض بالحق في الشغل للأشخاص في وضعية إعاقة من خلال تطبيق نسب التوظيف القانونية. ", null, null, "آليات ضامنة لتطبيق النسب القانونية " },
                    { 298, "298", 3, 2, 1, 8, 18, 2, "  الإسراع بإصدار النصوص التنظيمية المنصوص عليها في القانون الإطار المتعلق بحماية حقوق الأشخاص في وضعية إعاقة والنهوض بها.", null, null, "مقتضيات تنظيمية داعمة لتفعيل القانون الإطار" },
                    { 294, "294", 3, 1, 3, 8, 17, 1, " تعزيز المقررات المدرسية والجامعية بمصوغات بيداغوجية تعنى بحقوق الانسان وبالتربية على المواطنة.", null, null, "بيئة تربوية داعمة لترسيخ ثقافة حقوق الإنسان" },
                    { 248, "248", 3, 1, 1, 8, 16, 2, " تفعيل منشور رئيس الحكومة حول الحملة الوطنية لتسجيل الأطفال غير المسجلين في الحالة المدنية بشكل دوري ومستمر.", null, null, "آليات داعمة لحماية الأطفال في هويتهم المدنية وحقوقهم الأساسية " },
                    { 224, "224", 3, 1, 1, 8, 15, 2, "إدماج ثقافة حقوق الإنسان ذات الصلة في مؤسسات التكوين الأساسي والمستمر للعاملين في مجال حماية الحقوق الفئوية.", null, null, "إطار مرجعي وبرامج داعمة لإدماج ثقافة حقوق الإنسان في التكوين الأساسي والمستمر  " },
                    { 206, "206", 2, 2, 3, 8, 13, 1, "تنظيم حملات تحسيسية بمتطلبات ترشيد وعقلنة تدبير الموارد الطبيعية وحماية البيئة عبر وسائل الإعلام المكتوبة والمسموعة والمرئية والإلكترونية.", null, null, "برامج إعلامية داعمة لحماية البيئة  " },
                    { 202, "202", 2, 2, 1, 8, 13, 2, " تعزيز آليات التنسيق بين القطاعات المعنية بالبيئة والتنمية المستدامة.", null, null, "آليات مؤسساتية داعمة لتنسيق تنفيذ برامج التنمية المستدامة" },
                    { 193, "193", 2, 2, 1, 8, 13, 1, " تعزيز الجهود الرامية إلى تحسين التقييم الاستراتيجي البيئي.", null, null, "إطار مرجعي وطني للتقييم الاستراتيجي البيئي معزز" },
                    { 180, "180", 2, 1, 2, 8, 12, 1, "وضع سياسة إعلامية تيسر التواصل الموجه في مجال تمتع الفئات الاجتماعية من الحق في السكن اللائق. ", null, null, "برامج إعلامية لتعزيز التواصل حول الحق في السكن اللائق" },
                    { 101, "101", 2, 2, 1, 8, 9, 1, "تقوية مكانة اللغة العربية في البحث العلمي والتقني الجامعي والأكاديمي", null, null, "برامج داعمة لتعزيز مكانة اللغة العربية في الجامعة" },
                    { 100, "100", 2, 1, 1, 8, 9, 2, "تعزيز استعمال اللغة العربية في المرافق العمومية وباقي مناحي الحياة العامة", null, null, "" },
                    { 91, "91", 2, 2, 1, 8, 8, 1, "  إيجاد آليات إدارية تحفز المدرسين على المشاركة الفعالة في المشاريع المدرسية والتربوية وتسمح بتوسيع مشاركة التلاميذ فيها", null, null, "" },
                    { 87, "87", 1, 2, 1, 8, 8, 2, "   إدماج المقاربة الحقوقية في جميع الأنشطة التربوية.", null, null, "" },
                    { 432, "432", 4, 2, 3, 7, 26, 1, "إشاعة ثقافة حقوق الإنسان وتنميتها في أوساط العدالة.", null, null, "شراكات وبرامج داعمة لتملك ثقافة حقوق الإنسان" },
                    { 393, "393", 4, 2, 1, 7, 22, 1, " تعزيز دور الجماعات الترابية في توفير بيئة آمنة تحمي الأطفال والنساء من كل أشكال العنف.", null, null, "بيئة آمنة تحمي الأطفال والنساء من كل أشكال العنف" },
                    { 315, "315", 3, 2, 1, 7, 18, 2, " إحداث مؤسسات اجتماعية تعنى بإيواء الأشخاص في وضعية إعاقة المتخلى عنهم.", null, null, "بنيات داعمة للتكفل بالأشخاص في وضعية إعاقة المتخلى عنهم" },
                    { 266, "266", 3, 2, 1, 7, 16, 1, " اتخاذ تدابير خاصة بحماية الأطفال المتخلى عنهم والعناية ببنيات استقبالهم وتبسيط مسطرة التكفل بهم.", null, null, "بنيات مؤسساتية كفيلة بحماية الأطفال المتخلى عنهم" },
                    { 211, "211", 2, 1, 3, 7, 14, 1, " إعداد واعتماد خطة عمل وطنية في مجال المقاولة وحقوق الإنسان بإشراك كافة الفاعلين المعنيين (قطاعات حكومية والبرلمان والقطاع الخاص والنقابات وهيئات الحكامة والديمقراطية التشاركية وحقوق الإنسان ومنظمات المجتمع المدني...).", null, null, "خطة معتمدة في مجال المقاولة وحقوق الإنسان " },
                    { 183, "183", 2, 2, 3, 7, 12, 1, " وضع برامج تدريب وتكوين المنشطين في ميدان المصاحبة الاجتماعية للمشاريع السكنية. ", null, null, "موارد بشرية مؤهلة، داعمة للمصاحبة الاجتماعية  " },
                    { 103, "103", 2, 2, 1, 7, 9, 1, "الإدماج العرضاني للحقوق اللغوية والثقافية الأمازيغية في برامج التربية والتكوين وفي المحيط المدرسي والجامعي", null, null, "بيئة تربوية مساعدة على إدماج الحقوق اللغوية والثقافية الأمازيغية" },
                    { 90, "90", 2, 1, 1, 7, 8, 2, "  مأسسة وتعميم الدعم المادي المقدم للمتمدرسين المعوزين والأطفال في وضعية إعاقة", null, null, "" },
                    { 89, "89", 1, 1, 1, 7, 8, 2, "   إيجاد آليات لربط مخرجات المنظومة التربوية بالحاجيات الاقتصادية والاجتماعية والثقافية وبأهداف الخطط التنموية", null, null, "" },
                    { 86, "86", 1, 2, 1, 7, 8, 2, "  اعتماد تدابير تحفيزية لتعميم تمدرس الفتيات في جميع المستويات التعليمية.", null, null, "" },
                    { 61, "61", 1, 2, 3, 7, 5, 2, " تعزيز برامج تكوين المكلفين بإنفاذ القانون في مجال استعمال القوة وتدبير فضاء الاحتجاج.", null, null, "" },
                    { 40, "40", 1, 2, 1, 7, 4, 1, " وضع معايير مرجعية قابلة للتتبع وقياس مظاهر الفساد.", null, null, "" },
                    { 433, "433", 4, 2, 3, 6, 26, 1, "تأهيل الموارد البشرية لإدارة العدالة وهيئات وجمعيات المهن القانونية من خلال وضع برامج في مجال التكوين والتكوين المستمر وتقويم الأداء.", null, null, "قدرات الموارد البشرية لمنظومة العدالة معززة " },
                    { 370, "370", 4, 2, 1, 6, 21, 1, "عقد شراكات وعلاقات تعاون مع مؤسسات وطنية ودولية تعنى بحقوق الإنسان للمساهمة في تأطير وتكوين القضاة والمحامين في مجال تملك ثقافة حقوق الإنسان فكرا وسلوكا وعملا.", null, null, "شراكات وبرامج داعمة لتملك ثقافة حقوق الإنسان" },
                    { 329, "329", 3, 2, 1, 6, 19, 2, " إحداث نظام أساسي لمهن المساعدة الاجتماعية لرعاية المسنين.", null, null, "مهن المساعدة الاجتماعية مقننة " },
                    { 345, "345", 3, 2, 1, 8, 20, 2, " وضع المقتضيات التنظيمية الخاصة بقانون مكافحة الاتجار بالبشر.", null, null, "" },
                    { 347, "347", 3, 2, 1, 8, 20, 1, " وضع اتفاقيات ثنائية مع البلدان الأصلية للمهاجرين المقيمين بالمغرب للتمتع بالحقوق الاجتماعية والاقتصادية والثقافية.", null, null, "اتفاقيات ثنائية مع الدول الأصلية للمهاجرين بالمغرب مبرمة" },
                    { 376, "376", 4, 2, 3, 8, 21, 1, "ترصيد التواصل بين مهنيي ومساعدي العدالة والعمل على مأسسته على نحو أفضل.", null, null, "آلية داعمة للتواصل" },
                    { 408, "408", 4, 2, 1, 8, 23, 1, "تقوية المقتضيات القانونية المتعلقة بالاعتداء على الملكية الفكرية لتتلاءم مع الدستور.", null, null, "مقتضيات قانونية داعمة لحماية الملكية الفكرية  " },
                    { 94, "94", 2, 1, 1, 11, 8, 2, "  تيسير شروط ولوج التعليم العالي وتقوية وتثمين البحث العلمي والرفع من الميزانية المخصصة له", null, null, "" },
                    { 85, "85", 1, 1, 1, 11, 8, 1, "--", null, null, "" },
                    { 50, "50", 1, 1, 1, 11, 5, 2, "مراعاة الضرورة والتناسب أثناء استعمال القوة في فض التجمعات العمومية وفي التجمهرات والتظاهرات السلمية. ", null, null, "" },
                    { 38, "38", 1, 2, 1, 11, 4, 2, " تعميم الخدمات العمومية الإلكترونية في أفق الوصول إلى تحقيق الإدارة الرقمية الشاملة. ", null, null, "" },
                    { 26, "26", 1, 1, 1, 11, 3, 2, "الإسراع بوضع ميثاق اللاتمركز الإداري في إطار تنزيل الجهوية المتقدمة وتكريس الحكامة الترابية", null, null, "" },
                    { 16, "16", 1, 1, 1, 11, 2, 2, "تفعيل مقاربة النوع في كافة المجالس المنتخبة وطنيا وجهويا ومحليا.", null, null, "" },
                    { 397, "397", 4, 2, 3, 10, 22, 1, "توثيق ونشر الاجتهاد القضائي في مجال حماية حقوق المرأة كمصدر من مصادر التشريع.", null, null, "دينامية داعمة لترصيد الاجتهاد القضائي في مجال حماية حقوق المرأة" },
                    { 373, "373", 4, 2, 1, 10, 21, 2, "الإسراع بوضع منظومة مندمجة لمعالجة الشكايات المتعلقة بحقوق المرتفقين.", null, null, "منظومة مندمجة لمعالجة الشكايات مفعلة " },
                    { 330, "330", 3, 1, 1, 10, 19, 2, " حماية حقوق وكرامة الأشخاص المسنين بتجويد معايير وخدمات التكفل على مستوى البنيات والموارد البشرية.", null, null, "بنيات مهيكلة وفق معايير الجودة، مؤهلة لصيانة حقوق وكرامة الأشخاص المسنين" },
                    { 310, "310", 3, 2, 1, 10, 18, 1, " اعتماد مقاربة التنمية الدامجة بشكل عرضاني في كل البرامج والسياسات المرتبطة بمجال الإعاقة.", null, null, "مقاربة التنمية الدامجة مفعلة" },
                    { 275, "275", 3, 2, 3, 10, 16, 2, "مواصلة تعزيز برامج وأنشطة حقوق المشاركة لدى الأطفال.", null, null, "بيئة مشجعة على مشاركة الأطفال" },
                    { 118, "118", 2, 1, 1, 10, 9, 1, " وضع برامج تيسر مشاركة وتمتع الأشخاص المسنين وفي وضعية إعاقة بالحقوق الثقافية.", null, null, "بيئة داعمة لتمتع الأشخاص المسنين      وفي وضعية إعاقة بالحقوق الثقافية" },
                    { 83, "83", 1, 2, 1, 10, 8, 2, "تفعيل مقتضيات القانون رقم 00-04 المتعلق بإلزامية التعليم.", null, null, "" },
                    { 73, "73", 1, 2, 1, 10, 7, 1, "تيسير التقاضي للضحايا من خلال توفير المساعدة القانونية والقضائية.", null, null, "" },
                    { 221, "221", 3, 2, 1, 6, 15, 1, " تكثيف البرامج التي تستهدف الفئات الهشة خاصة في وضعية التشرد، وضمان خدمات المواكبة والاستماع والتكفل والادماج الاقتصادي والاجتماعي والأسري.", null, null, "برامج داعمة للفئات الهشة" },
                    { 39, "39", 1, 1, 1, 10, 4, 1, " تعزيز طرق وأشكال التبليغ عن حالات الفساد، بما في ذلك وضع خط أخضر وتيسير تقديم الشكايات.", null, null, "" },
                    { 413, "413", 4, 1, 1, 9, 24, 1, "وضع النصوص التطبيقية للقانون المنظم لحماية التراث الثقافي.", null, null, "نصوص تنظيمية داعمة لحماية التراث الثقافي." },
                    { 377, "377", 4, 2, 3, 9, 21, 2, "وضع برامج للتدريب والتكوين المستمر على سيادة القانون واحترام حقوق الإنسان تتأسس على الدستور والرصيد الثري للاجتهاد القضائي المغربي والممارسات الفضلى ذات الصلة لفائدة مكونات العدالة ومساعديها.", null, null, "برامج للتكوين داعمة لتمكين الجهاز القضائي من ثقافة حقوق الانسان  " },
                    { 375, "375", 4, 1, 3, 9, 21, 1, "توثيق ونشر الأعمال البحثية المعززة لرصيد ثقافة حقوق الإنسان المنجزة بمناسبة الآراء والأعمال الاستشارية من قبل مؤسسات الديمقراطية التشاركية.", null, null, "برامج معززة لرصيد ثقافة حقوق الإنسان " },
                    { 361, "361", 4, 2, 1, 9, 21, 2, " مواصلة الانخراط في اتفاقيات مجلس أوروبا المفتوحة للبلدان غير الأعضاء.", null, null, "ممارسة اتفاقية في مجال حقوق الإنسان معززة " },
                    { 336, "336", 3, 2, 1, 9, 19, 1, " وضع مؤشرات وأنظمة معلوماتية لتتبع أوضاع الأشخاص المسنين لاسيما الموجودين في أوضاع صعبة محليا جهويا ووطنيا.", null, null, "منظومة معلوماتية ومؤشرات للتتبع مبلورة " },
                    { 302, "302", 3, 1, 1, 9, 18, 2, " تفعيل مقتضيات الرافعة الرابعة من الرؤية الاستراتيجية لإصلاح التربية والتعليم 2015-2030 من أجل مدرسة الانصاف والجودة والارتقاء لفائدة الأشخاص في وضعية إعاقة أو في وضعيات خاصة.", null, null, "مؤسسة تعليمية دامجة " },
                    { 272, "272", 3, 1, 1, 9, 16, 1, "تعزيز إجراءات حماية محيط المؤسسات التعليمية لحماية الأطفال واليافعين من أخطار المخدرات ومروجيها.", null, null, "إجراءات أمنية معززة لحماية     الأطفال واليافعين من أخطار المخدرات ومروجيها" },
                    { 229, "229", 3, 1, 1, 9, 15, 2, " وضع الجماعات الترابية لبرامج في مجال الحقوق الفئوية.", null, null, "برامج داعمة للنهوض بالحقوق الفئوية" },
                    { 151, "151", 2, 2, 1, 9, 11, 1, " مواصلة الحوار المجتمعي بشأن الانضمام إلى اتفاقية منظمة العمل الدولية رقم 87 بشأن الحرية النقابية وحماية حق التنظيم النقابي. ", null, null, "حوارمجتمعيواسع. " },
                    { 131, "131", 2, 1, 1, 9, 10, 1, " دعم الموارد البشرية الطبية وشبه الطبية والإدارية ومواصلة تعزيز الكفاءات عن طريق التكوين والتكوين المستمر.", null, null, "برامج داعمة لتعزيز كفاءات القطاع الصحي   " },
                    { 102, "102", 2, 2, 1, 9, 9, 1, "تعزيز مكانة اللغة والثقافة الأمازيغية في المجالات الثقافية والإدارية والقضائية وباقي مناحي الحياة العامة.", null, null, "ديناميات داعمة لتعزيز مكانة اللغة والثقافة الأمازيغية " },
                    { 97, "97", 2, 2, 1, 9, 9, 2, "  الإسراع بإصدار القانون التنظيمي المتعلق بإعمال الطابع الرسمي للغة الأمازيغية", null, null, "" },
                    { 54, "54", 1, 1, 1, 9, 5, 2, "دعم المؤسسات الأمنية بالموارد البشرية والمالية والتقنية اللازمة.", null, null, "" },
                    { 409, "409", 4, 2, 1, 8, 23, 1, " تعزيز دور المكتب المغربي لحقوق المؤلفين ومراجعة قانونه ليصبح مؤسسة عمومية.", null, null, "إطار قانوني داعم لحقوق المؤلف" },
                    { 425, "425", 4, 1, 1, 9, 26, 1, "  تأهيل الهياكل القضائية والإدارية بما يكرس النجاعة القضائية الضامنة للأجل المعقول. ", null, null, "آليات مؤسساتية داعمة للنجاعة القضائية" },
                    { 105, "105", 2, 1, 1, 11, 9, 2, "استثمار وحفظ الرصيد الحضاري العبري المغربي في إغناء التنوع الثقافي والتطور المجتمعي", null, null, "مبادرات داعمة للتنوع الثقافي والتطور الاجتماعي " },
                    { 215, "215", 2, 1, 3, 6, 14, 1, " تعزيز المشاركة الوطنية في اللقاءات الدولية والجهوية المتعلقة بالمقاولة وحقوق الإنسان.", null, null, "دينامية داعمة لترصيد وتملك وتبادل الخبرات والممارسات الفضلى في مجال المقاولة وحقوق الإنسان " },
                    { 171, "171", 2, 1, 1, 6, 12, 2, " إسراع وتيرة إنجاز برامج القضاء على أحياء الصفيح للسعي إلى معالجة وضعيات 50 % من الأسر التي تعيش² في دور الصفيح في أفق 2021.", null, null, "برامج مساهمة في القضاء على أحياء الصفيح  " },
                    { 258, "258", 3, 1, 1, 4, 16, 2, " تشجيع ودعم الأسر التي يوجد أطفالها في وضعية صعبة لتفادي الرعاية المؤسساتية.", null, null, "تراجع ظاهرة إيداع الأطفال بمؤسسات الرعاية الاجتماعية" },
                    { 213, "213", 2, 2, 3, 4, 14, 2, "إدماج بعد احترام حقوق الإنسان في المقاولة على مستوى القانون والممارسة والنهوض بأدوار المقاولة المتعلقة بحقوق الانسان وقيم المواطنة.", null, null, "بيئة داعمة للنهوض بحقوق الإنسان داخل المقاولة" },
                    { 179, "179", 2, 2, 1, 4, 12, 2, " تضمين دفاتر التحملات للمعايير الدنيا المطبقة على السكن الاجتماعي المحددة بصفة قانونية أو تنظيمية.", null, null, "" },
                    { 165, "165", 2, 1, 1, 4, 12, 1, "إرساء استراتيجية وطنية شمولية ومندمجة في مجال السكن.", null, null, "استراتيجية وطنية معتمدة داعمة للحق في السكن   " },
                    { 156, "156", 2, 2, 1, 4, 11, 1, " إعداد برامج لدعم وتنشيط المقاولات الصغرى والمتوسطة والتعاونيات ووضع شباك داخل الجماعات الترابية للتعريف بالمقاولات خصوصا النسائية منها.", null, null, "برامج داعمة للمقاولات الصغرى           والمتوسطة" },
                    { 140, "140", 2, 1, 1, 4, 10, 1, " دعم عمل الفرق الطبية المتنقلة في إطار تقريب الخدمات الصحية وتيسيرها.", null, null, "آليات داعمة لتقريب الخدمات الصحية وتيسيرها" },
                    { 134, "134", 2, 1, 1, 4, 10, 1, " تعزيز مبدأي المساواة وعدم التمييز في التعامل مع المرضى داخل المؤسسات الاستشفائية. ", null, null, "بيئة صحية تكفل الولوج المتساوي للخدمات الصحية" },
                    { 34, "34", 1, 2, 1, 4, 4, 1, " تفعيل أدوار مؤسسات الحكامة والديمقراطية التشاركية في اقتراح التدابير ذات الأثر المباشر على مكافحة الفساد ودعم عملها في كل ما يخص نشر قيم النزاهة والشفافية.", null, null, "" },
                    { 428, "428", 4, 2, 1, 2, 26, 1, "مواصلة تحسين الخدمات القضائية.", null, null, "إجراءات معززة للخدمات القضائية" },
                    { 405, "405", 4, 1, 1, 2, 23, 1, " تعزيز الأخلاقيات المهنية في الممارسة الإعلامية.", null, null, "بيئة داعمة لممارسة إعلامية وفق الضوابط المهنية  " },
                    { 392, "392", 4, 2, 1, 2, 22, 1, " التفعيل الحازم لمقتضيات قانون الاتجار بالبشر المتعلقة بحماية الأطفال والنساء الضحايا.", null, null, "إجراءات داعمة لحماية الأطفال والنساء ضحايا الاتجار بالبشر " },
                    { 371, "371", 4, 1, 1, 2, 21, 2, " وضع ميثاق النجاعة القضائية للتدبير الجيد للجلسات وآجال البت وتصفية المخلف والتواصل مع المواطنين والاستماع إلى شكاياتهم وغيرها من الإجراءات المماثلة.", null, null, "آليات داعمة لتجويد خدمات العدالة" }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[,]
                {
                    { 276, "276", 3, 2, 3, 2, 16, 1, " تقوية برامج الوقاية الموجهة للأطفال في وضعية صعبة ولأسرهم.", null, null, "برامج معززة لحماية الأطفال في وضعية صعبة ولأسرهم" },
                    { 230, "230", 3, 1, 1, 2, 15, 1, "الرفع من الاعتمادات المخصصة للنهوض بالحقوق الفئوية في الميزانية العامة.", null, null, "اعتمادات مالية مساهمة في النهوض بالحقوق الفئوية" },
                    { 227, "227", 3, 2, 1, 2, 15, 2, "تجميع ونشر القوانين والتشريعات المتعلقة بالفئات المعنية والتعريف بمقتضياتها.", null, null, "مصنفات منجزة" },
                    { 218, "218", 2, 1, 3, 2, 14, 1, "وضع برامج تكوينية في مجال حقوق الإنسان في المقاولة لفائدة كل المتدخلين وأصحاب المصلحة (مسؤولو المقاولة والأطر النقابية والفاعلون المدنيون والقضاة والمحامون ومفتشو الشغل).", null, null, "برامج تكوينية مساعدة على الرفع من مستوى الوعي بحقوق الإنسان في المقاولة" },
                    { 200, "200", 2, 2, 1, 2, 13, 2, " دعم البرنامج الوطني لتدبير وتثمين النفايات.", null, null, "البرنامج الوطني لتدبير وتثمين النفاياتمدعم" },
                    { 181, "181", 2, 2, 3, 2, 12, 2, " وضع برامج تدريب وتكوين في مجالات التمتع بالحق في السكن اللائق والمصاحبة الاجتماعية الموجهة للفئات ذات الدخل المحدود وغير القار.", null, null, "برامج داعمة للتحسيس بالحق في السكن" },
                    { 96, "96", 2, 2, 1, 2, 9, 2, "  إرساء استراتيجية ثقافية وطنية", null, null, "" },
                    { 75, "75", 1, 2, 1, 2, 7, 1, "حماية المشتكين والمبلغين والشهود والمدافعين عن حقوق الإنسان من أي سوء معاملة ومن أي ترهيب بسبب شكاويهم أو شهاداتهم أمام السلطات العمومية والقضائية.", null, null, "" },
                    { 48, "48", 1, 2, 1, 2, 5, 1, "استحضار البعد الأمني في وضع خطط التهيئة الحضرية وتصميم التجمعات السكنية الجديدة والأحياء بضواحي المدن بشكل يضمن أمن المواطنات والمواطنين.", null, null, "" },
                    { 402, "402", 4, 1, 1, 1, 23, 2, "  التعجيل بإصدار القانون المتعلق بالحق في الحصول على المعلومات، انسجاما مع الدستور والاتفاقيات الدولية.", null, null, "" },
                    { 309, "309", 3, 2, 1, 1, 18, 1, "النهوض بالولوجية الشاملة سواء على المستوى العمراني والمعماري ووسائل النقل والاتصال.", null, null, "ولوجيات كفيلة بالمساهمة في تحسين ظروف عيش الأشخاص في وضعية إعاقة" },
                    { 290, "290", 3, 1, 3, 1, 17, 2, " تعزيز دور الشباب في الحوارات الوطنية والجهوية المتعلقة بتدبير الشأن العام والنهوض بأوضاعهم.", null, null, "برامج داعمة لمشاركة الشباب في تدبير الشأن العام وتقييم السياسات العمومية" },
                    { 287, "287", 3, 2, 1, 1, 17, 2, " دعم الجمعيات التي تعنى بالشباب وبالترافع عن قضاياهم.", null, null, " قدرات متطورة في مجال الترافع " },
                    { 242, "242", 3, 1, 1, 1, 16, 2, " تفعيل المقتضيات القانونية ذات الصلة بالأطفال في المرحلة الانتقالية في القانون المتعلق بتشغيل العمال المنزليين.", null, null, "مناخ داعم لاحترام القانون المتعلق بتشغيل العاملات والعمال المنزليين " },
                    { 198, "198", 2, 2, 1, 1, 13, 1, " تقنين الزراعات المستهلكة للمياه خاصة بالمناطق الهشة.", null, null, "برامج داعمةلتكريس تدبير يحافظ على الموارد المائية المحدودة ويضمن استدامتها" },
                    { 169, "169", 2, 1, 1, 1, 12, 2, " تفعيل القانون للحد من التجاوزات في ميدان التعمير والإسكان وزجر المخالفات وضمان سلامة البناء في الوسطين الحضري والقروي.", null, null, "منظومة قانونية داعمة للحد من التجاوزات في ميدان التعمير والإسكان" },
                    { 68, "68", 1, 1, 1, 1, 6, 2, "تعزيز الشراكة بين مؤسسات الدولة والجمعيات والرفع من مستوى حكامتها.", null, null, "" },
                    { 274, "274", 3, 2, 3, 4, 16, 1, " التحسيس والتوعية بخطورة العقاب البدني والعنف في الوسط التربوي كبيئة آمنة.", null, null, "برامج مساعدة على الحد من العنف في الوسط التربوي " },
                    { 332, "332", 3, 2, 1, 4, 19, 1, "حث الجماعات الترابية على إدماج احتياجات الأشخاص المسنين في برامج تفعيل مخططات التنمية.", null, null, "مخططات للتنمية المحلية داعمة للنهوض بأوضاع الأشخاص المسنين  " },
                    { 387, "387", 4, 2, 1, 4, 22, 1, " مواصلة الحوار المجتمعي حول بعض مقتضيات مدونة الأسرة، ويتعلق الأمر بإعادة صياغة المادة 49 بما يضمن استيعاب مفهوم الكد والسعاية ومراجعة المادة 175 بإقرار عدم سقوط الحضانة عن الأم رغم زواجها وتعديل المادتين 236 و238 من أجل كفالة المساواة بين الأب والأم في الولاية على الأبناء.", null, null, "حوار مجتمعي منظم" },
                    { 403, "403", 4, 1, 1, 4, 23, 1, "إصدار القرار الخاص بتحديد كيفيات سير وتنظيم مراحل انتخاب أعضاء المجلس الوطني للصحافة.", null, null, "" },
                    { 166, "166", 2, 1, 1, 6, 12, 1, " تعزيز المنظومة القانونية المتعلقة بالسكن والتعمير وملاءمتها مع متطلبات حقوق الإنسان.", null, null, "إطار قانوني داعم للحق في السكن" },
                    { 127, "127", 2, 1, 1, 6, 10, 2, " الإسراع بالمصادقة على مشروع القانون المتعلق بمكافحة الاضطرابات العقلية وبحماية حقوق الأشخاص المصابين بها.", null, null, "إطار قانوني داعم لحماية الأشخاص المصابين بالاضطرابات العقلية " },
                    { 126, "126", 2, 1, 3, 6, 9, 1, "وضع برامج متخصصة بمساعدة المختصين في المهن الثقافية للنهوض بقدرات المنظمات غير الحكومية والجماعات الترابية وسائر المؤسسات العاملة في مجال الحقوق الثقافية", null, null, "برامج داعمة لقدرات مختلف الفاعلين في مجال الحقوق الثقافية" },
                    { 121, "121", 2, 1, 1, 6, 9, 2, " تشجيع وتثمين الدراسات البحثية في مجال التأصيل للتنوع الثقافي والحفاظ على الذاكرة والثقافة الشعبية وسائر الإبداعات المماثلة.", null, null, "مناخ مشجع على البحث " },
                    { 120, "120", 2, 1, 1, 6, 9, 2, " ترميم وصيانة المواقع الأثرية والصخرية وتأمين حراستها حفاظا على التراث الثقافي الوطني وتعزيز آليات حمايته من الإتلاف والحفاظ على الذاكرة في بعديها الوطني والمحلي.", null, null, "منظومة حافظة للمواقع الأثرية والصخرية " },
                    { 60, "60", 1, 2, 3, 6, 5, 2, "تعميم تدريس مادة حقوق الإنسان وأحكام القانون الدولي الإنساني ضمن برامج التكوين الأساسي والمستمر الخاص بالموظفين المكلفين بتنفيذ القانون.", null, null, "" },
                    { 53, "53", 1, 1, 1, 6, 5, 1, "العمل على تأمين تغذية الأشخاص الموضوعين رهن الحراسة النظرية.", null, null, "" },
                    { 435, "435", 4, 1, 3, 5, 26, 1, " وضع برامج للتكوين المستمر وتبادل الخبرات والممارسات الفضلى بشأن إدماج حقوق الإنسان في الاجتهاد القضائي، تفاعلا مع التزامات المغرب في مجال حقوق الإنسان وأحكام الدستور.", null, null, "آليات داعمة لاستحضار بعد حقوق الإنسان في الاحكام القضائية" },
                    { 422, "422", 4, 2, 3, 5, 25, 1, " تحسيس مصالح الإدارات العمومية بأهمية إيداع أرشيفها بانتظام لدى مصالح أرشيف المغرب طبقا للنصوص الجاري بها العمل.", null, null, "مصالح الإدارات العمومية منخرطة" },
                    { 418, "418", 4, 1, 1, 5, 25, 1, " مراجعة قانون الأرشيف طبقا للممارسات الفضلى المعمول بها في هذا المجال مع استكمال إصدار المراسيم التطبيقية لقانون الأرشيف.", null, null, "إطار قانوني داعم لثقافة الأرشيف " },
                    { 411, "411", 4, 1, 3, 5, 23, 1, "إدماج قيم حقوق الإنسان في برامج التكوين والتدريب الموجهة لمهنيي الإعلام والاتصال", null, null, "برامج التكوين والتدريب معززة بقيم حقوق الانسان" },
                    { 344, "344", 3, 1, 1, 5, 20, 1, " مواصلة تحيين الإطار التشريعي والمؤسساتي المتعلق بالهجرة واللجوء.", null, null, "الإطار التشريعي والمؤسساتي المتعلق بالهجرة واللجوء معزز ومحين" },
                    { 340, "340", 3, 1, 3, 5, 19, 1, "تعزيز البرامج الإعلامية الموجهة للمسنين", null, null, "برامج إعلامية مواكبة لحاجيات المسنين" },
                    { 313, "313", 3, 1, 1, 5, 18, 1, "الإسراع بتفعيل نظام الدعم الاجتماعي والتشجيع والمساندة لفائدة الأشخاص في وضعية إعاقة المنصوص عليه في المادة 6 من القانون الإطار رقم 97.13 المتعلق بحماية حقوق الاشخاص في وضعية إعاقة والنهوض بها.", null, null, "نظام الدعم الاجتماعي مشجع على النهوض بوضعية الأشخاص في وضعية إعاقة" },
                    { 188, "188", 2, 1, 1, 6, 13, 1, "مراجعة اختصاصات وتنظيم المجلس الوطني للبيئة بهدف وضع الهياكل والمؤسسات والآليات والمساطر اللازمة للحكامة البيئية الجيدة وتحقيق التنمية المستدامة طبقا لمبادئ وأهداف القانون الإطار بمثابة ميثاق وطني للبيئة والتنمية المستدامة. ", null, null, "التأطير القانوني للمجالات البيئية معزز" },
                    { 295, "295", 3, 1, 3, 5, 17, 1, "تعزيز برامج محو الأمية في أفق القضاء عليها وتأهيل الشباب.", null, null, "تقليص المعدل العام للأمية إلى20 % سنة 2021" },
                    { 141, "141", 2, 2, 1, 5, 10, 2, " دعم الخطة المتعلقة بتوفير الأدوية الأساسية الاستعجالية وتلك المتعلقة بالأمراض المزمنة.", null, null, "خطة داعمة لضمان تموين مستمر بالأدوية" },
                    { 42, "42", 1, 1, 3, 5, 4, 1, "وضع سياسة إعلامية وخطط تواصلية لبلوغ أهداف الاستراتيجية الوطنية لمكافحة الفساد وفق مقاربة تتأسس على سيادة القانون واحترام حقوق الإنسان.", null, null, "" },
                    { 31, "31", 1, 1, 1, 5, 4, 2, "  استكمال الإجراءات التشريعية المتعلقة بإصدار مشروع القانون رقم 13.31 المتعلق بالحق في الوصول إلى المعلومات.", null, null, "" },
                    { 28, "28", 1, 1, 1, 5, 4, 1, " الإسراع بالمصادقة على المقتضيات القانونية المؤطرة لتجريم الإثراء غير المشروع.", null, null, "" },
                    { 419, "419", 4, 1, 1, 3, 25, 1, "وضع تصور لتدبير الأرشيف في إطار الجهوية المتقدمة.", null, null, "خطة وطنية لتنظيم الأرشيفات الترابية معتمدة" },
                    { 417, "417", 4, 1, 1, 3, 24, 1, " تعزيز تأهيل القصور والقصبات والحفاظ عليها.", null, null, "التراث العمراني مرمم ومحافظ عليه" },
                    { 388, "388", 4, 1, 1, 3, 22, 2, " صيانة الكرامة الإنسانية للمرأة في وسائل الإعلام، ووضع تدابير زجرية في حالة انتهاكها. ", null, null, "إجراءات داعمة لصيانة كرامة المرأة في وسائل الاعلام" },
                    { 378, "378", 4, 2, 3, 3, 21, 2, "تعزيز برامج التكوين الأساسي والتكوين المستمر في المعاهد والمراكز المعنية بالمكلفين بإنفاذ القانون.", null, null, "" },
                    { 374, "374", 4, 1, 3, 3, 21, 2, " وضع برنامج خاص بجمع وتصنيف وتقديم ونشر الاجتهادات القضائية الجنائية والإدارية المعززة لإعمال المعايير الدولية لحقوق الإنسان.", null, null, "منظومة داعمة لتثمين الاجتهادات القضائية واستثمارها" },
                    { 354, "354", 3, 1, 3, 3, 20, 1, " تقوية نقط التواصل بالسفارات والقنصليات وتيسير الخدمات لفائدة المغاربة المقيمين بالخارج.", null, null, "الخدمات المقدمة من طرف نقط التواصل بالسفارات والقنصليات ميسرة" },
                    { 341, "341", 3, 1, 3, 3, 19, 2, "تعزيز قدرات العاملين العموميين والمؤسساتيين لإدماج حاجيات الأشخاص المسنين في السياسات العمومية", null, null, "قدرات معززة لإدماج حاجيات الأشخاص المسنين في السياسات العمومية" },
                    { 306, "306", 3, 2, 1, 3, 18, 2, "الإسراع بتحديد وإعمال النسبة المائوية للأشخاص في وضعية إعاقة الواجب تشغيلهم في إطار تعاقدي بين الدولة ومقاولات القطاع الخاص.", null, null, " إطار تعاقدي محفز لتشغيل الأشخاص في وضعية إعاقة" },
                    { 296, "296", 3, 1, 1, 3, 18, 1, " المصادقة على معاهدة مراكش لتيسير النفاذ إلى المصنفات المنشورة لفائدة الأشخاص المكفوفين أو معاقي البصر أو ذوي إعاقات أخرى في قراءة المطبوعات لسنة 2013.", null, null, "المصادقة على المعاهدة" },
                    { 197, "197", 2, 1, 1, 3, 13, 2, "تطوير تدبير المجال الغابوي بالشكل الذي يوفر حماية شاملة للمحميات ولحقوق السكان ونشاطهم الزراعي والفلاحي.", null, null, "ديناميات معززة للحماية القانونية للمجال الغابوي  وداعمة لتنمية مستدامة" },
                    { 145, "145", 2, 2, 1, 5, 10, 2, " تشجيع وتحفيز طلبة الطب على التخصص في الطب الشرعي والطب النفسي والوظيفي وتوفير المناصب المالية اللازمة.", null, null, "تحفيزات مساعدة على تقليص الخصاص" },
                    { 63, "63", 1, 2, 1, 22, 6, 1, "مواصلة ملاءمة الإطار القانوني المتعلق بحريات الاجتماع وتأسيس الجمعيات مع المعايير الدولية لحقوق الإنسان في نطاق الدستور وأحكامه.", null, null, "" },
                    { 130, "130", 2, 1, 1, 11, 10, 1, " مواصلة توفير الموارد البشرية اللازمة من حيث عدد الأطر الطبية وشبه الطبية وتخصصاتها وتأمين توزيعها العادل على المجال الترابي وفق منظور يراعي حاجيات وخصوصيات كل منطقة.", null, null, "مواردبشريةكفيلةبتأمينالحاجياتمنالخدماتالصحية." },
                    { 168, "168", 2, 2, 1, 11, 12, 1, " الإسراع بإصدار مشاريع القوانين ذات الصلة بالتعمير وفق منظور يتوخى التنمية البشرية المستدامة ويراعي التنوع المجالي والخصوصيات المحلية والهوية المعمارية لمختلف الأقاليم.", null, null, "منظومة قانونية للتعمير داعمةللتنمية المستدامة" },
                    { 360, "360", 4, 1, 1, 18, 21, 1, " مواصلة الانضمام والتفاعل مع الأنظمة الدولية والإقليمية لحقوق الإنسان.", null, null, "ممارسة اتفاقية في مجال حقوق الإنسان معززة " },
                    { 316, "316", 3, 1, 1, 18, 18, 1, " تقوية موارد وخدمات صندوق دعم التماسك الاجتماعي الموجهة للأشخاص في وضعية إعاقة. ", null, null, "خدمات الصندوق مستجيبة لحاجيات الفئة المستفيدة" },
                    { 249, "249", 3, 1, 1, 18, 16, 1, " تعزيز وتقوية المساعدة الاجتماعية والقانونية للأطفال ضحايا الاعتداء والعنف والاستغلال أو في تماس مع القانون.", null, null, "المساعدة الاجتماعية والقانونية للأطفال ضحايا العنف والاستغلال معززة وشاملة" },
                    { 199, "199", 2, 2, 1, 18, 13, 1, " تيسير الولوج إلى المعلومة البيئية وتأمين مشاركة المواطنات والمواطنين في إعداد المشاريع والبرامج ذات الصلة بالبيئة والمشاركة في اتخاذ القرار.", null, null, "إطار مؤسساتي ضامن للحق في المعلومة ومؤمن للمشاركة" },
                    { 194, "194", 2, 2, 1, 18, 13, 1, " إعداد مخطط وطني في مجال مكافحة التغيرات المناخية ووضع سياسة وطنية لمكافحة الاحتباس الحراري وتعبئة جميع الفاعلين في مجال مكافحة تغير المناخ.", null, null, "مبادرات داعمة لمكافحة التغيرات المناخية " },
                    { 84, "84", 1, 1, 1, 18, 8, 1, " مراجعة المناهج والمقررات الدراسية وملاءمتها مع مبادئ وقيم الدستور وأحكامه والاتفاقيات الدولية ذات الصلة. ", null, null, "" },
                    { 67, "67", 1, 2, 1, 18, 6, 1, "كفالة احترام المقتضيات القانونية المتعلقة بوصل إيداع ملفات تأسيس الجمعيات.", null, null, "" },
                    { 59, "59", 1, 2, 3, 18, 5, 2, "إعداد ونشر دلائل ودعائم ديداكتيكية لتوعية وتحسيس المسؤولين وأعوان الأمن بقواعد الحكامة الجيدة على المستوى الأمني واحترام حقوق الإنسان.", null, null, "" },
                    { 17, "17", 1, 1, 1, 18, 2, 2, " تجويد عمل آليات الحوار والتشاور الكفيلة بإعمال المساواة وتكافؤ الفرص على نحو أفضل في كافة دوائر اتخاذ القرار في القطاعات العمومية الوطنية والمحلية والقطاع الخاص والمنظمات غير الحكومية. ", null, null, "" },
                    { 6, "6", 1, 2, 3, 18, 1, 2, "  إغناء وإثراء الحوار العمومي الخاص بالمشاركة السياسية من خلال برامج تسهل وتضمن ولوج مختلف الفاعلين (أحزاب سياسية، نقابات، جمعيات...) للخدمات الإعلامية العمومية لتعزيز مساهمتهم في تأطير المواطنات والمواطنين وتطوير التعددية والحكامة السياسية.", null, null, "فضاء سمعي بصري داعم للمشاركة السياسية" },
                    { 2, "2", 1, 1, 1, 18, 1, 1, "الرفع من مستوى مشاركة النساء في المجالس التمثيلية.", null, null, "بيئة داعمة للرفع من مشاركة النساء" },
                    { 434, "434", 4, 1, 3, 17, 26, 1, " تعزيز إدماج مرجعية حقوق الإنسان والتربية على المواطنة ضمن برامج التكوين بالمعهد العالي للقضاء.", null, null, "قدرات متطورة في مجال التكوين القضائي التخصصي; برامج مساهمة في توسيع المعارف وتعزيز القدرات في مجال حقوق الإنسان" },
                    { 431, "431", 4, 1, 1, 17, 26, 2, " تفعيل المقتضيات الدستورية المتعلقة بتقوية الدور الرقابي للبرلمان على الحكومة والمؤسسات التابعة للدولة من خلال لجن التقصي وغيرها من الآليات المتوفرة.", null, null, "إطار قانوني داعم للدور الرقابي للبرلمان على الحكومة والمؤسسات التابعة للدولة " },
                    { 430, "430", 4, 2, 1, 17, 26, 2, " وضع سياسة فعالة تضمن تنفيذ الأحكام الصادرة ضد كافة مؤسسات الدولة والخواص.", null, null, "سياسة داعمة لتنفيذ الاحكام القضائية" },
                    { 423, "423", 4, 1, 3, 17, 25, 1, "تقوية قدرات مؤسسة أرشيف المغرب المادية والبشرية حتى تتمكن من الاضطلاع بالمهام المنوطة بها.", null, null, "قدرات مؤسسة أرشيف المغرب معززة " },
                    { 406, "406", 4, 2, 1, 17, 23, 1, " النهوض بمعاهد التكوين في مجال الإعلام.", null, null, "منظومة وطنية للتكوين في مجال الإعلام مستجيبة لحاجيات القطاع من الكفاءات كما وكيفا  " },
                    { 304, "304", 3, 2, 1, 17, 18, 1, " تعزيز التمدرس بالقسم الدراسي العادي مع توفير الترتيبات التيسيرية اللازمة وتوسيع شبكة الأقسام المدمجة لتشمل المستوى الإعدادي والثانوي وجعل المراكز المتخصصة جزء من المنظومة التعليمية الوطنية.", null, null, "تضاعف عدد الممدرسين من الأطفال في وضعية إعاقة" },
                    { 241, "241", 3, 1, 1, 17, 16, 2, " الإسراع بإصدار القانون المتعلق بشروط فتح وتدبير مؤسسات الرعاية الاجتماعية والنصوص القانونية والتنظيمية ذات الصلة.", null, null, " إطار قانوني داعم تجويد خدمات مؤسسات الرعاية الاجتماعية" },
                    { 233, "233", 3, 1, 3, 17, 15, 1, "تشجيع ودعم المبادرات التحسيسية الهادفة إلى حماية الفئات الاجتماعية في وضعية هشاشة", null, null, "برامج داعمة لحماية الفئات الاجتماعية في وضعية هشاشة " },
                    { 226, "226", 3, 1, 1, 17, 15, 1, " اعتماد معايير الجودة في التدبير وفي خدمات التكفل بمؤسسات الرعاية الاجتماعية من أجل ضمان الحقوق الفئوية. ", null, null, "مؤسسات للرعاية الاجتماعية معتمدة لمعايير الجودة في التدبير وخدمات التكفل" },
                    { 220, "220", 3, 2, 1, 17, 15, 2, " إصدار القانون المتعلق بشروط فتح وإحداث وتدبير مؤسسات الرعاية الاجتماعية.", null, null, "" },
                    { 210, "210", 2, 2, 3, 17, 13, 1, " تكوين القضاة والشرطة القضائية والبيئية في مجال الحقوق البيئية.", null, null, "قدرات متطورة في مجال التكوين القضائي التخصصي   " },
                    { 142, "142", 2, 2, 1, 17, 10, 2, "تخليق المرفق الصحي وعقلنة طرق تدبير الأدوية والمستلزمات الطبية داخل المستشفيات.", null, null, "آليات مساعدة على التدبير المعقلن وداعمة لتخليق المرفق الصحي" },
                    { 133, "133", 2, 2, 1, 17, 10, 1, " النهوض بصحة الأم والمواليد الجدد والعناية بطب التوليد.", null, null, "برامج صحية معززة لصحة الأم والطفل والمواليد الجدد" },
                    { 77, "77", 1, 2, 1, 17, 7, 2, "إحالة نتائج البحث المتوصل إليها في إطار الطب الشرعي بخصوص حالات ادعاء التعذيب على النيابة العامة للتقرير فيها مالم تكن قد أمرت بها.", null, null, "" },
                    { 57, "57", 1, 1, 3, 17, 5, 2, "تبسيط وتيسير وتعميم نشر المذكرات والدوريات المتعلقة بحقوق الإنسان المعمول بها في المؤسسات الأمنية على كافة موظفيها المكلفين بتنفيذ القانون.", null, null, "" },
                    { 404, "404", 4, 1, 1, 16, 23, 2, " الإسراع بوضع ميثاق أخلاقيات مهنة الصحافة والإعلام بما في ذلك الصحافة الإلكترونية.", null, null, "ميثاق أخلاقيات مهنة الصحافة والإعلام معتمد" },
                    { 367, "367", 4, 2, 1, 16, 21, 1, "مواصلة الحوار المجتمعي حول تعديل المادة 53 من مدونة الأسرة لأجل كفالة الحماية الفعلية للزوج أو الزوجة من طرف النيابة العامة عند الإرجاع إلى بيت الزوجية.", null, null, "حوار مجتمعي منظم" },
                    { 353, "353", 3, 1, 3, 16, 20, 2, " مواصلة التنسيق والالتقائية بين كافة المتدخلين في مجال الهجرة وتعزيز دور اللجنة بين الوزارية لمغاربة العالم وشؤون الهجرة في هذا المجال. ", null, null, "أداء اللجنة بين الوزارية معزز وفعال" },
                    { 372, "372", 4, 1, 1, 18, 21, 2, " تعزيز دور القضاء الإداري في ترسيخ دولة القانون وتكريس مبدأ سمو القانون واحترام حقوق الإنسان.", null, null, "إطار مؤسساتي معزز للقضاء الإداري" },
                    { 62, "62", 1, 2, 3, 19, 5, 2, " تقوية الخبرة الفنية فيما يخص عمل لجان تقصي الحقائق البرلمانية.", null, null, "" },
                    { 119, "119", 2, 1, 1, 19, 9, 2, " إحداث متاحف موضوعاتية جهوية تبرز تراث كل منطقة وخصوصياتها الثقافية والفنية.", null, null, "بنيات حاضنة للتنوع الثقافي والتراثي " },
                    { 158, "158", 2, 2, 1, 19, 11, 2, "تعزيز الخدمات الاجتماعية الموجهة إلى العمال والأجراء.", null, null, "ارتفاع عدد المقاولات المحدثة للخدمات الاجتماعية " },
                    { 394, "394", 4, 2, 1, 21, 22, 1, "إدماج بعد النوع الاجتماعي في السياسات والميزانيات ووضع آليات للمتابعة والتقييم.", null, null, "آليات داعمة لإدماج بعد النوع في السياسات والميزانيات" },
                    { 334, "334", 3, 2, 1, 21, 19, 1, " تشجيع كل المبادرات العمومية والجمعوية الداعمة والحاضنة لرفاه الأشخاص المسنين ومشاركتهم.", null, null, "مبادرات عمومية داعمة لرفاه الأشخاص المسنين ومشاركتهم " },
                    { 264, "264", 3, 2, 1, 21, 16, 1, " دعم عمل اللجنة بين الوزارية المكلفة بتتبع السياسات والبرامج في مجال النهوض بحقوق الطفل وحمايتها.", null, null, "آلية مؤسساتية داعمة لتنفيذ السياسات والبرامج في مجال النهوض بحقوق الطفل وحمايتها " },
                    { 263, "263", 3, 2, 1, 21, 16, 2, " تفعيل البرنامج التنفيذي للسياسة العمومية المندمجة لحماية الطفولة بالمغرب محليا وجهويا.", null, null, "تدابير البرنامج الوطني للسياسة العمومية المندمجة لحماية الطفولة منفذة جهويا ومحليا" },
                    { 254, "254", 3, 1, 1, 21, 16, 2, " حماية حقوق الأطفال في وسائل الإعلام بما في ذلك وسائل الاتصال الحديثة والنهوض بالتربية عليها.", null, null, "بيئة إعلامية داعمة لحقوق الطفل " },
                    { 214, "214", 2, 1, 3, 21, 14, 1, " النهوض بدور المقاولة في مجال تقييم أثر أنشطتها على حقوق الانسان.", null, null, "آليات داعمة للنهوض بحقوق الإنسان داخل المقاولة" },
                    { 173, "173", 2, 2, 1, 21, 12, 1, " التأهيل الحضري للأحياء غير القانونية لتحسين ظروف السكان القاطنين بها.", null, null, "برامج للتأهيل الحضري داعمة لتحسين ظروف عيش الساكنة" },
                    { 146, "146", 2, 2, 1, 21, 10, 1, " مواصلة تعزيز الخدمات المتعلقة بمعالجة الشكايات والتظلمات والاقتراحات من طرف المرتفقين على الصعيد الجهوي، واعتماد استمارات توضع رهن إشارة المرتفقين لقياس مستوى رضاهم عن الخدمات. ", null, null, "منظومة داعمة لتحسين مستوى الخدمات" },
                    { 132, "132", 2, 2, 1, 21, 10, 1, "  تأهيل أقسام المستعجلات لتعزيز الخدمات المتعلقة بالحالات الطارئة والخطيرة.", null, null, "برامج داعمة لتعزيز كفاءات القطاع الصحي/ أقسام المستعجلات مؤهلة لتقديم خدمات ذات جودة وتغطي الحاجيات" },
                    { 112, "112", 2, 1, 1, 21, 9, 1, "تعزيز الشراكات بين المؤسسات الثقافية العمومية والقطاع الخاص ومنظمات الشباب والمجتمع المدني.", null, null, "شراكات داعمة لإبداعات الشباب " },
                    { 69, "69", 1, 1, 1, 21, 6, 2, "تيسير حريات الاجتماع والتجمهر والتظاهر السلمي من حيث تحديد الأماكن المخصصة لها والقيام بالوساطة والتفاوض.", null, null, "" },
                    { 45, "45", 1, 1, 1, 21, 5, 2, "مراجعة المقتضيات القانونية بما يسمح بمرافقة الدفاع للشخص المعتقل بمجرد وضعه تحت الحراسة النظرية لدى الضابطة القضائية، ومواصلة ملاءمة الإطار التشريعي المنظم للبحث التمهيدي والحراسة النظرية والتفتيش وكافة الإجراءات الضبطية وملاءمتها مع المعايير الدولية ذات الصلة.", null, null, "" },
                    { 24, "24", 1, 1, 1, 21, 3, 1, " مواصلة دعم الجهات بمناسبة وضع التصاميم الجهوية المقترحة لإعداد التراب.", null, null, "" },
                    { 21, "21", 1, 2, 1, 21, 3, 2, "-21- تنفيذ توصيات المجلس الأعلى لإعداد التراب الوطني واللجن المنبثقة عنه.", null, null, "" },
                    { 317, "317", 3, 2, 1, 16, 18, 1, " وضع نظام جديد لتقييم الإعاقة يتلاءم والمفهوم الطبي والنفسي والاجتماعي المعتمد بموجب الاتفاقية الدولية لحقوق الأشخاص ذوي الإعاقة.", null, null, "نظام جديد لتقييم الإعاقة معتمد" },
                    { 12, "12", 1, 2, 3, 21, 1, 2, " وضع برامج تدريبية وتكوينية فعالة تستهدف تطوير مهارات التواصل والرفع بمستوى الثقافة الحقوقية والسياسية في نطاق الدستور والتزامات المملكة المغربية في مجال حقوق الإنسان.", null, null, "" },
                    { 252, "252", 3, 2, 1, 20, 16, 1, "إيلاء أهمية قصوى للبرامج الاجتماعية المساهمة في النهوض بوضعية الفتاة وخاصة في مجالات التعليم والتكوين والوصول إلى الموارد.", null, null, "برامج داعمة للنهوض بوضعية الفتاة" },
                    { 201, "201", 2, 2, 1, 20, 13, 2, "  الإسراع بتنفيذ المخطط الوطني لتطهير السائل لا سيما بالعالم القروي.", null, null, "مخطط وطني منجز" },
                    { 164, "164", 2, 1, 3, 20, 11, 2, " وضع برامج لتكوين قضاة متخصصين في قانون الشغل.", null, null, "برامج داعمة للتخصص القضائي في قانون الشغل" },
                    { 135, "135", 2, 2, 1, 20, 10, 2, " ضمان حقوق المصابين بالأمراض المتنقلة جنسيا وحمايتهم من كل أشكال التمييز أو الإقصاء أو الوصم.", null, null, "برامج داعمة لحقوق المصابين بالأمراض المتنقلة جنسيا" },
                    { 115, "115", 2, 1, 1, 20, 9, 2, "تعزيز القواعد المنظمة للسكن اللائق بإحداث مرافق تعزز الحياة والإبداع الثقافيين.", null, null, "برامج سكنية معززة للحياة الثقافية" },
                    { 111, "111", 2, 2, 1, 20, 9, 2, "مواصلة تثمين الرموز الوطنية المغربية من خلال إطلاق أسمائها على المؤسسات والشوارع والساحات العمومية حفظا لها في ذاكرة الأجيال.", null, null, "فضاءات ومؤسسات عامة مساعدة على حفظ الذاكرة" },
                    { 80, "80", 1, 2, 3, 20, 7, 1, "إعمال الحق في الوصول إلى المعلومة واستلامها ونشرها بما يضمن تفعيل مبدأ عدم الإفلات من العقاب", null, null, "" },
                    { 79, "79", 1, 2, 1, 20, 7, 2, " تشجيع إمكانيات التظلم الإداري والقضائي صونا لمبدأ عدم الإفلات من العقاب وضمانا لوصول الضحايا إلى سبل الانتصاف المناسبة.", null, null, "" },
                    { 390, "390", 4, 2, 1, 19, 22, 2, " مواصلة تفعيل مقتضيات صندوق التكافل العائلي وتبسيط مساطره.", null, null, "مقتضيات داعمة لتوسيع دائرة المستفيدين" },
                    { 352, "352", 3, 2, 1, 19, 20, 2, "تفعيل الآليات الكفيلة بتتبع أوضاع السجناء المغاربة الذين يقضون عقوبتهم السجنية بالخارج ضمانا لحقوقهم واعتناء بأوضاعهم. ", null, null, "آليات داعمة لحماية حقوق السجناء المغاربة بالخارج" },
                    { 312, "312", 3, 1, 1, 19, 18, 1, " تفعيل المخطط الوطني للصحة والإعاقة.", null, null, "مخطط وطني للصحة والإعاقة      مفعل" },
                    { 303, "303", 3, 1, 1, 19, 18, 1, " إدماج التربية على الاختلاف في المناهج المدرسية للمساهمة في تغيير المواقف والتمثلات في أوساط الأطفال والشباب.", null, null, "كتب مدرسية معززة للتعايش وقبول الاختلاف" },
                    { 299, "299", 3, 1, 1, 19, 18, 2, " الإسراع بإحداث الآلية الوطنية لحماية حقوق الأشخاص في وضعية إعاقة وفقا لمقتضيات اتفاقية حقوق الأشخاص ذوي الإعاقة.", null, null, "الآلية الوطنية لحماية حقوق الأشخاص في وضعية إعاقة مفعلة" },
                    { 280, "280", 3, 2, 1, 19, 17, 1, " وضع تدابير تشريعية وتنظيمية في مجال حماية الجمهور الناشئ ضد المخاطر المترتبة عن الاستعمال السيئ لوسائل التواصل المعتمدة على التكنولوجيات الحديثة. ", null, null, "إطار قانوني داعم لحماية الجمهور الناشئ  " },
                    { 391, "391", 4, 1, 1, 20, 22, 2, " إدماج مقاربة النوع الاجتماعي في البرامج الاقتصادية الداعمة لإحداث المقاولات.", null, null, "آليات كفيلة بإدماج مقاربة النوع" },
                    { 153, "153", 2, 1, 1, 11, 11, 2, " اعتماد المساواة وتكافؤ الفرص في برامج التكوين والتأهيل والإدماج في سوق الشغل.", null, null, "المساواة وتكافؤ الفرص فئويا ومجاليا مفعلة في برامج التكوين والتأهيل والإدماج في سوق الشغل" },
                    { 267, "267", 3, 2, 1, 16, 16, 1, " العمل على تطوير شراكات مع دول الاستقبال لحماية الأطفال المغاربة من الاستغلال إعمالا لمصلحتهم الفضلى.", null, null, "الشراكات مع دول الاستقبال لحماية الأطفال المغاربة من الاستغلال مطورة" },
                    { 205, "205", 2, 1, 3, 16, 13, 2, " إعمال مضامين الميثاق الوطني للإعلام والبيئة والتنمية المستدامة.", null, null, "الميثاق الوطني للإعلام والبيئة والتنمية المستدامة مفعل" },
                    { 389, "389", 4, 2, 1, 13, 22, 2, " تعزيز آليات الرصد والتتبع لحماية النساء ضحايا العنف وطنيا جهويا ومحليا.", null, null, "آليات فعالة لحماية النساء ضحايا العنف" },
                    { 383, "383", 4, 1, 1, 13, 22, 2, "الإسراع بإصدار القانون المتعلق بمحاربة العنف ضد النساء.", null, null, "" },
                    { 342, "342", 3, 2, 3, 13, 19, 2, "تعزيز العمل المؤسسي للجمعيات التي تعنى بأوضاع الأشخاص المسنين", null, null, "العمل الجمعوي معزز في مجال النهوض بأوضاع الأشخاص المسنين" },
                    { 335, "335", 3, 1, 1, 13, 19, 2, " التفكير في سبل تثمين خبرات ومهارات الأشخاص المسنين بوصفها جزءا من الرصيد الثقافي والقيمي للرأسمال اللامادي.", null, null, "بيئة داعمة لتثمين خبرات ومهارات الأشخاص المسنين" },
                    { 261, "261", 3, 1, 1, 13, 16, 1, " تنظيم وتتبع أوضاع كفالة الأطفال خارج المغرب.", null, null, "آليات مساعدة على تتبع أوضاع كفالة الأطفال خارج المغرب  " },
                    { 161, "161", 2, 1, 1, 13, 11, 1, "وضع برامج وخطط كفيلة بتأهيل التكوين المهني وجعله يساهم بفعالية في تقليص معدلات البطالة. ", null, null, "برامج داعمة للنهوض بالتكوين المهني كرافعة للتشغيل" },
                    { 95, "95", 2, 1, 3, 13, 8, 2, "  تقوية قيم التسامح والعيش المشترك واحترام حقوق الإنسان ونبذ الكراهية والعنف والتطرف في المناهج التربوية وفي الفضاء المدرسي.", null, null, "" },
                    { 36, "36", 1, 1, 1, 13, 4, 2, "تعزيز المشاريع والإجراءات الرامية إلى مكافحة الفساد وتعزيز الحكامة الإدارية والنزاهة والشفافية.", null, null, "" },
                    { 29, "29", 1, 2, 1, 13, 4, 1, "الإسراع بوضع ميثاق للمرافق العمومية يتضمن قواعد الحكامة الإدارية الجيدة.", null, null, "" },
                    { 27, "27", 1, 2, 1, 13, 4, 2, " تقوية الإطار القانوني والتنظيمي لتعزيز النزاهة والشفافية من خلال ملاءمته مع الاتفاقيات الدولية لمكافحة الفساد كما صادقت عليها المملكة المغربية ليشمل ما يتعلق بالتنسيق وآليات التحري والوصول إلى المعلومات والتنفيذ الفعال والتتبع والإشراف.", null, null, "" },
                    { 25, "25", 1, 2, 1, 13, 3, 2, "--", null, null, "" },
                    { 326, "326", 3, 1, 3, 12, 18, 1, " تطوير التكوين الأساسي والمستمر في مجال الإعاقة خصوصا في ميدان التربية والتكوين المهني والصحة ولاسيما ما يتعلق ببعض أنواع الإعاقة كالتوحد.", null, null, "برامج داعمة للنهوض بالتكوين الأساسي والمستمر في مجال الإعاقة في ميدان التربية والتكوين المهني" },
                    { 325, "325", 3, 1, 3, 12, 18, 2, "تمكين الأشخاص في وضعية إعاقة من خدمات الإعلام والتواصل عن طريق إدماج لغة الإشارة في البرامج الإعلامية.", null, null, "بيئة داعمة لولوج   الأشخاص في وضعية إعاقة للخدمات الإعلامية  " },
                    { 284, "284", 3, 1, 1, 12, 17, 2, " تعزيز نقط ارتكاز خاصة بالشباب في القطاعات والمؤسسات المعنية مركزيا ومحليا.", null, null, "بيئة إدارية داعمة للتنسيق بين القطاعات" },
                    { 256, "256", 3, 1, 1, 12, 16, 1, " تفعيل دورية وزارة الداخلية المتعلقة باختيار الأسماء الشخصية. ", null, null, "آليات ميسرة لإعمال الدورية" },
                    { 216, "216", 2, 1, 3, 12, 14, 1, " تعزيز الوعي بموضوع المقاولة وحقوق الإنسان من خلال تنظيم لقاءات وطنية وجهوية بمشاركة الأطراف المعنية. ", null, null, "برامج داعمة للنهوض بمجال المقاولة وحقوق الإنسان " },
                    { 191, "191", 2, 1, 1, 12, 13, 2, " دعم الصندوق الوطني للبيئة والتنمية المستدامة.", null, null, "آلية مساهمة في دعم المشاريع البيئية" },
                    { 125, "125", 2, 1, 3, 12, 9, 2, "وضع برامج تواصلية للجمهور الواسع تستهدف التعريف والتحسيس بالحقوق الثقافية واللغوية ومختلف إبداعاتها", null, null, "بيئة مشجعة للنهوض بالحقوق الثقافية " },
                    { 114, "114", 2, 2, 1, 12, 9, 1, "تشجيع مبادرات الشباب والمجتمع المدني فيما يخص التربية الثقافية والإنتاج الثقافي ودعم المشاريع المحفزة على الإبداع", null, null, "مناخ داعم لمبادرات الشباب في المجال الثقافي " },
                    { 33, "33", 1, 2, 1, 12, 4, 1, "تفعيل مختلف أشكال الرقابة البرلمانية والإدارية والقضائية في مكافحة الفساد.", null, null, "" },
                    { 8, "8", 1, 2, 3, 12, 1, 1, "إطلاق برامج تواصلية لتعزيز الديمقراطية التشاركية.", null, null, "بيئة داعمة ومحفزة للديمقراطية التشاركية " },
                    { 1, "1", 1, 2, 1, 12, 1, 2, "التفعيل الأمثل للقوانين المنظمة للانتخابات الوطنية والمحلية لتقوية النزاهة والحكامة الرشيدة والشفافية", null, null, "بيئة داعمة للنزاهة والشفافية والحكامة الانتخابية " },
                    { 355, "355", 3, 1, 3, 11, 20, 2, " النهوض بإبداعات وابتكارات الباحثين المغاربة المقيمين بالخارج.", null, null, "إبداعات وابتكارات الباحثين المغاربة المقيمين بالخارج مثمنة" },
                    { 291, "291", 3, 2, 3, 11, 17, 2, " وضع قاعدة معلومات خاصة بالشباب. ", null, null, "قاعدة معلومات مساعدة على التخطيط     والبرمجة" },
                    { 281, "281", 3, 1, 1, 11, 17, 2, "مراجعة القانون التنظيمي للأحزاب بكيفية تمكن الشباب من المساهمة الفعالة في تدبير الشأن الحزبي. ", null, null, "مقتضيات قانونية داعمة للمشاركة السياسية للشباب" },
                    { 244, "244", 3, 2, 1, 11, 16, 2, " تطوير وتفعيل المقتضيات القانونية الخاصة بتجريم الاستغلال الجنسي للأطفال والاتجار بهم مع تشديد العقوبات على الجناة.", null, null, "إطار قانوني داعم    لحماية حقوق الطفل " },
                    { 225, "225", 3, 1, 1, 11, 15, 1, "إدماج العمل التطوعي الاجتماعي في الوسطين التربوي والجامعي.", null, null, "دينامية داعمة لترسيخ العمل التطوعي في الوسطين التربوي والجامعي" },
                    { 190, "190", 2, 1, 1, 11, 13, 1, " النظر في تجميع القوانين القطاعية ذات الصلة بالبيئة في إطار مدونة واضحة ومحينة لأجل تعزيز الانسجام بينها وتسهيل الولوج إلى مضامينها من طرف الهيئات التي تسهر على تطبيقها ومن طرف المواطنات والمواطنين.", null, null, "مصنفات مساهمة في الولوج إلى القوانين ذات الصلة بالبيئة " },
                    { 184, "184", 2, 2, 1, 11, 13, 1, " ملاءمة الإطار القانوني الوطني مع الاتفاقيات الدولية المتعلقة بحماية البيئة والتنمية المستدامة.", null, null, "إطار قانوني وطنيمتلائم" },
                    { 415, "415", 4, 2, 3, 13, 24, 2, " جرد التراث الثقافي وتوثيقه وتصنيفه.", null, null, " تراث ثقافي موثق ومصنف" },
                    { 22, "22", 1, 1, 1, 14, 3, 1, " إدماج البعد الثقافي في التنظيم الجهوي على مستوى وسائل الإعلام والبرامج التربوية والتظاهرات الثقافية والفنية.", null, null, "" },
                    { 37, "37", 1, 1, 1, 14, 4, 1, " تقوية الآليات المكلفة بتعزيز النزاهة والشفافية بالخبرة المطلوبة والدعم الفني اللازم.", null, null, "" },
                    { 64, "64", 1, 2, 1, 14, 6, 2, "مراجعة القوانين المنظمة للحريات العامة لضمان انسجامها مع الدستور من حيث القواعد القانونية الجوهرية والإجراءات الخاصة بفض التجمعات العمومية والتجمهر والتظاهر وذلك في إطار احترام المعايير الدولية والقواعد الديمقراطية المتعارف عليها.", null, null, "" },
                    { 159, "159", 2, 2, 1, 16, 11, 1, " تقوية آلية التعويض عن فقدان الشغل.", null, null, "إطار قانوني داعم لحماية العمال      والأجراء عند فقدان الشغل" },
                    { 122, "122", 2, 2, 1, 16, 9, 1, "تشجيع إحداث محطات إعلامية جهوية", null, null, "محطات جهوية متفاعلة مع محيطها" },
                    { 113, "113", 2, 1, 1, 16, 9, 1, "إحداث فضاءات للحوار والتشاور الدائمين بين منظمات المجتمع المدني والشباب على صعيد الجماعات الترابية فيما يخص الإنتاج الثقافي والأنشطة الداعمة للحياة الثقافية", null, null, "جماعات ترابية داعمة لمبادرات الشباب والمجتمع المدني في المجال الثقافي " },
                    { 108, "108", 2, 1, 1, 16, 9, 1, "مراجعة دفاتر تحملات شركات الاتصال السمعي البصري بما يسمح بتعزيز حصة البث بالأمازيغية", null, null, "إطار تنظيمي معزز لحصة البث باللغة الأمازيغية" },
                    { 66, "66", 1, 2, 1, 16, 6, 1, "تبسيط المساطر المتعلقة بالتصريح بالتجمعات العمومية من أجل تعزيز وضمان ممارسة الحريات العامة من طرف مختلف مكونات المجتمع (جمعيات، نقابات) والعمل على ضمان التطبيق السليم للمساطر المعمول بها في هذا المجال.", null, null, "" },
                    { 49, "49", 1, 1, 1, 16, 5, 1, "إلزام المنظومة التعميرية والأمنية بنصب كاميرات يكون بإمكانها المساعدة على مكافحة الجريمة وحماية الأشخاص والممتلكات.", null, null, "" },
                    { 47, "47", 1, 1, 1, 16, 5, 1, "الإسراع بإصدار قانون يتعلق بالتحقق من هوية الأشخاص بواسطة البصمات الجينية. ", null, null, "" },
                    { 349, "349", 3, 1, 1, 15, 20, 2, "حماية حقوق الأطفال المغاربة المهاجرين غير المرفقين في دول الاستقبال.", null, null, "برامج متخصصة مع جمعيات ومنظمات في مجال حماية حقوق الأطفال مبلورة ومنفذة" },
                    { 331, "331", 3, 2, 1, 15, 19, 2, "تحفيز البحث العلمي والدراسات الجامعية حول أوضاع الأشخاص المسنين وآثار الشيخوخة في مختلف المستويات الديمغرافية والاقتصادية والاجتماعية.", null, null, "بيئة داعمة للبحث العلمي حول أوضاع الأشخاص المسنين" },
                    { 324, "324", 3, 1, 3, 15, 18, 2, "تعزيز دور الإعلام في تطوير حملات للوقاية من الإعاقة وبرامج مكافحة التمييز والوصم تجاه الأشخاص ذوي الإعاقة.", null, null, " إعلام داعم لمكافحة التمييز والوصم تجاه الأشخاص ذوي الإعاقة " },
                    { 240, "240", 3, 1, 1, 15, 16, 1, " مراجعة قانون الكفالة بما يتلاءم ومقتضيات الدستور.", null, null, "إطار تشريعي   وتنظيمي معتمد" },
                    { 195, "195", 2, 1, 1, 15, 13, 1, "تأمين مشاركة ومساهمة مختلف الفاعلين وخاصة منظمات المجتمع المدني والهيئات السياسية والنقابية والإعلامية في النهوض بالثقافة البيئية ومختلف البرامج البيئية.", null, null, "برامج داعمة للنهوض بالثقافة البيئية" },
                    { 152, "152", 2, 1, 1, 15, 11, 1, "تشجيع وتقوية أدوار لجان الحوار والمصالحة الإقليمية والوطنية.", null, null, "اللجان الإقليمية للبحث والمصالحة مفعلة على مستوى العمالات والأقاليم." },
                    { 149, "149", 2, 2, 1, 15, 11, 2, " استكمال مسطرة المصادقة على اتفاقية منظمة العمل الدولية رقم 102 المتعلقة بالمعايير الدنيا للضمان الاجتماعي.", null, null, "المصادقة على تفاقية منظمةا لعمل الدولية رقم 102 المتعلقة بالمعاييرالدنيا للضمان الاجتماعي" },
                    { 219, "219", 2, 1, 3, 16, 14, 1, "تشجيع التدريس والبحث العلمي في الجامعة ومعاهد التكوين ومراكز البحث العلمي حول المقاولة وحقوق الإنسان", null, null, "برامج داعمة للتدريس والبحث الجامعي حول المقاولة وحقوق الإنسان" },
                    { 139, "139", 2, 2, 1, 15, 10, 1, " النهوض بالصحة النفسية والعقلية ومواصلة مأسستها وتعميم خدماتها.", null, null, "بنيات داعمة للنهوض بالصحةالنفسيةوالعقلية" },
                    { 70, "70", 1, 1, 1, 15, 6, 1, "تعزيز آليات الوساطة والتوفيق والتدخل الاستباقي المؤسساتي والمدني لتفادي حالات التوتر والحيلولة دون وقوع انتهاكات.", null, null, "" },
                    { 58, "58", 1, 1, 3, 15, 5, 2, "تقوية بنيات ووسائل وقنوات التواصل بين المؤسسات الأمنية والمواطنين (حسن الاستقبال والتوجيه وتقديم الإرشادات).", null, null, "" },
                    { 401, "401", 4, 2, 3, 14, 22, 2, "مواصلة برامج التدريب وتطوير القدرات في مجال التكوين والتكوين المستمر على حقوق النساء لفائدة القضاة ومساعدي العدالة.", null, null, "برامج مساعدة على تقوية القدرات في مجال حقوق النساء" }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "Code", "IdAxe", "IdCycle", "IdNature", "IdResponsable", "IdSousAxe", "IdType", "Nom", "ObjectifGlobal", "ObjectifSpeciaux", "ResultatsAttendu" },
                values: new object[,]
                {
                    { 398, "398", 4, 1, 3, 14, 22, 1, "نشر الممارسات الفضلى المتعلقة بتطبيق مدونة الأسرة على مستوى عمل كتابة الضبط ومراكز الاستقبال.", null, null, "دينامية داعمة للتطبيق الناجع لمدونة الأسرة " },
                    { 395, "395", 4, 2, 1, 14, 22, 2, " وضع الآليات الكفيلة بضمان ولوج النساء لمجال المقاولة.", null, null, "أليات كفيلة بتيسير ولوج النساء للمقاولة " },
                    { 327, "327", 3, 2, 3, 14, 18, 1, " تعزيز دور المجتمع المدني في النهوض بحقوق الأشخاص في وضعية إعاقة. ", null, null, "مبادرات مثمنة وداعمة لأدوار المجتمع المدني في مجال النهوض بحقوق الأشخاص في وضعية إعاقة" },
                    { 288, "288", 3, 1, 3, 14, 17, 2, "تقوية مشاركة الشباب في خدمات الإعلام والتواصل. ", null, null, "آليات داعمة لتمكين الشباب من التواصل والولوج إلى المعلومة " },
                    { 277, "277", 3, 1, 3, 14, 16, 1, " الإبداع في أشكال وصيغ الأدوات البيداغوجية حول التربية الجنسية وفق مقاربة وقائية تراعي أعمار ومستوى نضج الأطفال والمخاطر التي قد تهددهم.", null, null, " بيئة داعمة للتربية الجنسية بالوسط المدرسي " },
                    { 174, "174", 2, 2, 1, 14, 12, 2, "تنفيذ أولويات السكن الاجتماعي بمضاعفة العرض في مجال المنتوجات السكنية الملائمة لحاجيات وإمكانيات الفئات المحدودة الدخل في إطار مشروع تطوير المنتوج السكني البديل في أفق 2021.", null, null, "عرض سكني مستجيب لحاجيات الفئات المحدودة الدخل" },
                    { 163, "163", 2, 1, 3, 14, 11, 1, "تنظيم دورات تدريبية لفائدة موظفي وأطر وزارة الشغل والأطر النقابية ومناديب المستخدمين وأرباب العمل بغية إشاعة ثقافة حقوق الإنسان في ميدان التشغيل.", null, null, "الرفع من قدرات أطر وزارة الشغل والإدماج المهني والأطر النقابية ومناديب المستخدمين وأرباب العمل في مجال حقوق الانسان" },
                    { 107, "107", 2, 2, 1, 14, 9, 1, "مواصلة تعزيز القناة التلفزية الأمازيغية وتمكينها من الموارد البشرية والكفاءات اللازمة للبث المتواصل", null, null, "بث متواصل للقناة التلفزية الأمازيغية" },
                    { 106, "106", 2, 1, 1, 14, 9, 2, "تعزيز وسائل التظلم والانتصاف المتعلقة بالتمييز في مجال الحقوق الثقافية", null, null, "سائل التظلم والانتصاف المتعلقة بالتمييز في مجال الحقوق معززة جهويا ومركزيا" },
                    { 82, "82", 1, 1, 1, 14, 8, 1, "تفعيل الرؤية الاستراتيجية لإصلاح التعليم 2015-2030 من أجل مدرسة الجودة والارتقاء، وإصدار القانون الإطار الخاص بها", null, null, "" },
                    { 81, "81", 1, 2, 3, 14, 7, 2, "تعزيز برامج التدريب والتكوين والتوعية بقيم حقوق الإنسان وآليات حمايتها والنهوض بها الموجهة للقضاة وللمكلفين بإنفاذ القوانين وموظفي السجون", null, null, "" },
                    { 93, "93", 2, 2, 1, 15, 8, 1, "  اعتماد آلية المساعدة الاجتماعية في الوسط المدرسي", null, null, "" },
                    { 534, "Code : {id - 1}", 3, 2, 1, 50, 21, 3, "534 : تدابير عشوائية لغايات تجريبية فقط", "بعد الأهداف العامة  : 534", "بعد الأهداف الخاصة : 534", "بعد النتائج المرتقبة : 534" }
                });

            migrationBuilder.InsertData(
                table: "Activites",
                columns: new[] { "Id", "Duree", "IdMesure", "Nom" },
                values: new object[,]
                {
                    { 140, "[\"2021\", \"2022\", \"2023\"]", 525, "139 بعد الأنشطة لبعض التدابير" },
                    { 27, "[\"2023\", \"2024\", \"2025\"]", 190, "26 بعد الأنشطة لبعض التدابير" },
                    { 7, "[\"2021\", \"2022\", \"2023\"]", 143, "6 بعد الأنشطة لبعض التدابير" },
                    { 28, "[\"2018\", \"2019\", \"2020\"]", 143, "27 بعد الأنشطة لبعض التدابير" },
                    { 8, "[\"2028\", \"2029\", \"2030\"]", 316, "7 بعد الأنشطة لبعض التدابير" },
                    { 19, "[\"2021\", \"2022\", \"2023\"]", 414, "18 بعد الأنشطة لبعض التدابير" },
                    { 15, "[\"2027\", \"2028\", \"2029\"]", 110, "14 بعد الأنشطة لبعض التدابير" },
                    { 46, "[\"2026\", \"2027\", \"2028\"]", 151, "45 بعد الأنشطة لبعض التدابير" },
                    { 16, "[\"2018\", \"2019\", \"2020\"]", 131, "15 بعد الأنشطة لبعض التدابير" },
                    { 43, "[\"2022\", \"2023\", \"2024\"]", 117, "42 بعد الأنشطة لبعض التدابير" },
                    { 30, "[\"2023\", \"2024\", \"2025\"]", 285, "29 بعد الأنشطة لبعض التدابير" },
                    { 50, "[\"2025\", \"2026\", \"2027\"]", 91, "49 بعد الأنشطة لبعض التدابير" },
                    { 21, "[\"2024\", \"2025\", \"2026\"]", 91, "20 بعد الأنشطة لبعض التدابير" },
                    { 38, "[\"2022\", \"2023\", \"2024\"]", 266, "37 بعد الأنشطة لبعض التدابير" },
                    { 136, "[\"2024\", \"2025\", \"2026\"]", 488, "135 بعد الأنشطة لبعض التدابير" },
                    { 139, "[\"2028\", \"2029\", \"2030\"]", 488, "138 بعد الأنشطة لبعض التدابير" },
                    { 122, "[\"2029\", \"2030\", \"2031\"]", 493, "121 بعد الأنشطة لبعض التدابير" },
                    { 150, "[\"2027\", \"2028\", \"2029\"]", 493, "149 بعد الأنشطة لبعض التدابير" },
                    { 4, "[\"2021\", \"2022\", \"2023\"]", 188, "3 بعد الأنشطة لبعض التدابير" },
                    { 114, "[\"2022\", \"2023\", \"2024\"]", 499, "113 بعد الأنشطة لبعض التدابير" },
                    { 138, "[\"2018\", \"2019\", \"2020\"]", 507, "137 بعد الأنشطة لبعض التدابير" },
                    { 116, "[\"2018\", \"2019\", \"2020\"]", 519, "115 بعد الأنشطة لبعض التدابير" },
                    { 39, "[\"2023\", \"2024\", \"2025\"]", 1, "38 بعد الأنشطة لبعض التدابير" },
                    { 32, "[\"2026\", \"2027\", \"2028\"]", 235, "31 بعد الأنشطة لبعض التدابير" },
                    { 22, "[\"2022\", \"2023\", \"2024\"]", 256, "21 بعد الأنشطة لبعض التدابير" },
                    { 44, "[\"2027\", \"2028\", \"2029\"]", 11, "43 بعد الأنشطة لبعض التدابير" },
                    { 36, "[\"2023\", \"2024\", \"2025\"]", 372, "35 بعد الأنشطة لبعض التدابير" },
                    { 137, "[\"2028\", \"2029\", \"2030\"]", 525, "136 بعد الأنشطة لبعض التدابير" },
                    { 23, "[\"2020\", \"2021\", \"2022\"]", 390, "22 بعد الأنشطة لبعض التدابير" },
                    { 33, "[\"2029\", \"2030\", \"2031\"]", 430, "32 بعد الأنشطة لبعض التدابير" },
                    { 24, "[\"2021\", \"2022\", \"2023\"]", 423, "23 بعد الأنشطة لبعض التدابير" },
                    { 47, "[\"2023\", \"2024\", \"2025\"]", 406, "46 بعد الأنشطة لبعض التدابير" },
                    { 20, "[\"2025\", \"2026\", \"2027\"]", 406, "19 بعد الأنشطة لبعض التدابير" },
                    { 6, "[\"2021\", \"2022\", \"2023\"]", 142, "5 بعد الأنشطة لبعض التدابير" },
                    { 1, "[\"2020\", \"2021\", \"2022\"]", 264, "0 بعد الأنشطة لبعض التدابير" },
                    { 37, "[\"2020\", \"2021\", \"2022\"]", 172, "36 بعد الأنشطة لبعض التدابير" },
                    { 119, "[\"2020\", \"2021\", \"2022\"]", 519, "118 بعد الأنشطة لبعض التدابير" },
                    { 25, "[\"2020\", \"2021\", \"2022\"]", 177, "24 بعد الأنشطة لبعض التدابير" },
                    { 13, "[\"2021\", \"2022\", \"2023\"]", 324, "12 بعد الأنشطة لبعض التدابير" },
                    { 41, "[\"2023\", \"2024\", \"2025\"]", 177, "40 بعد الأنشطة لبعض التدابير" },
                    { 14, "[\"2022\", \"2023\", \"2024\"]", 386, "13 بعد الأنشطة لبعض التدابير" },
                    { 31, "[\"2020\", \"2021\", \"2022\"]", 174, "30 بعد الأنشطة لبعض التدابير" },
                    { 45, "[\"2024\", \"2025\", \"2026\"]", 81, "44 بعد الأنشطة لبعض التدابير" },
                    { 11, "[\"2027\", \"2028\", \"2029\"]", 368, "10 بعد الأنشطة لبعض التدابير" },
                    { 9, "[\"2027\", \"2028\", \"2029\"]", 337, "8 بعد الأنشطة لبعض التدابير" },
                    { 2, "[\"2021\", \"2022\", \"2023\"]", 342, "1 بعد الأنشطة لبعض التدابير" },
                    { 49, "[\"2024\", \"2025\", \"2026\"]", 362, "48 بعد الأنشطة لبعض التدابير" },
                    { 3, "[\"2022\", \"2023\", \"2024\"]", 261, "2 بعد الأنشطة لبعض التدابير" },
                    { 40, "[\"2020\", \"2021\", \"2022\"]", 177, "39 بعد الأنشطة لبعض التدابير" },
                    { 146, "[\"2022\", \"2023\", \"2024\"]", 523, "145 بعد الأنشطة لبعض التدابير" },
                    { 17, "[\"2023\", \"2024\", \"2025\"]", 253, "16 بعد الأنشطة لبعض التدابير" },
                    { 113, "[\"2023\", \"2024\", \"2025\"]", 492, "112 بعد الأنشطة لبعض التدابير" },
                    { 121, "[\"2025\", \"2026\", \"2027\"]", 524, "120 بعد الأنشطة لبعض التدابير" },
                    { 123, "[\"2021\", \"2022\", \"2023\"]", 520, "122 بعد الأنشطة لبعض التدابير" },
                    { 129, "[\"2023\", \"2024\", \"2025\"]", 513, "128 بعد الأنشطة لبعض التدابير" },
                    { 126, "[\"2023\", \"2024\", \"2025\"]", 498, "125 بعد الأنشطة لبعض التدابير" },
                    { 132, "[\"2022\", \"2023\", \"2024\"]", 530, "131 بعد الأنشطة لبعض التدابير" },
                    { 115, "[\"2026\", \"2027\", \"2028\"]", 498, "114 بعد الأنشطة لبعض التدابير" },
                    { 111, "[\"2019\", \"2020\", \"2021\"]", 529, "110 بعد الأنشطة لبعض التدابير" },
                    { 12, "[\"2025\", \"2026\", \"2027\"]", 165, "11 بعد الأنشطة لبعض التدابير" },
                    { 128, "[\"2018\", \"2019\", \"2020\"]", 496, "127 بعد الأنشطة لبعض التدابير" },
                    { 102, "[\"2019\", \"2020\", \"2021\"]", 489, "101 بعد الأنشطة لبعض التدابير" },
                    { 141, "[\"2024\", \"2025\", \"2026\"]", 487, "140 بعد الأنشطة لبعض التدابير" },
                    { 106, "[\"2028\", \"2029\", \"2030\"]", 487, "105 بعد الأنشطة لبعض التدابير" },
                    { 103, "[\"2029\", \"2030\", \"2031\"]", 487, "102 بعد الأنشطة لبعض التدابير" },
                    { 117, "[\"2022\", \"2023\", \"2024\"]", 535, "116 بعد الأنشطة لبعض التدابير" },
                    { 145, "[\"2029\", \"2030\", \"2031\"]", 496, "144 بعد الأنشطة لبعض التدابير" },
                    { 127, "[\"2026\", \"2027\", \"2028\"]", 531, "126 بعد الأنشطة لبعض التدابير" },
                    { 118, "[\"2022\", \"2023\", \"2024\"]", 529, "117 بعد الأنشطة لبعض التدابير" },
                    { 130, "[\"2025\", \"2026\", \"2027\"]", 529, "129 بعد الأنشطة لبعض التدابير" },
                    { 134, "[\"2025\", \"2026\", \"2027\"]", 525, "133 بعد الأنشطة لبعض التدابير" },
                    { 110, "[\"2019\", \"2020\", \"2021\"]", 522, "109 بعد الأنشطة لبعض التدابير" },
                    { 147, "[\"2018\", \"2019\", \"2020\"]", 514, "146 بعد الأنشطة لبعض التدابير" },
                    { 144, "[\"2029\", \"2030\", \"2031\"]", 512, "143 بعد الأنشطة لبعض التدابير" },
                    { 105, "[\"2019\", \"2020\", \"2021\"]", 508, "104 بعد الأنشطة لبعض التدابير" },
                    { 124, "[\"2025\", \"2026\", \"2027\"]", 506, "123 بعد الأنشطة لبعض التدابير" },
                    { 29, "[\"2018\", \"2019\", \"2020\"]", 405, "28 بعد الأنشطة لبعض التدابير" },
                    { 135, "[\"2026\", \"2027\", \"2028\"]", 504, "134 بعد الأنشطة لبعض التدابير" },
                    { 148, "[\"2027\", \"2028\", \"2029\"]", 500, "147 بعد الأنشطة لبعض التدابير" },
                    { 133, "[\"2022\", \"2023\", \"2024\"]", 497, "132 بعد الأنشطة لبعض التدابير" },
                    { 149, "[\"2022\", \"2023\", \"2024\"]", 490, "148 بعد الأنشطة لبعض التدابير" },
                    { 107, "[\"2026\", \"2027\", \"2028\"]", 490, "106 بعد الأنشطة لبعض التدابير" },
                    { 104, "[\"2025\", \"2026\", \"2027\"]", 490, "103 بعد الأنشطة لبعض التدابير" },
                    { 143, "[\"2027\", \"2028\", \"2029\"]", 529, "142 بعد الأنشطة لبعض التدابير" },
                    { 18, "[\"2024\", \"2025\", \"2026\"]", 309, "17 بعد الأنشطة لبعض التدابير" },
                    { 34, "[\"2028\", \"2029\", \"2030\"]", 306, "33 بعد الأنشطة لبعض التدابير" },
                    { 42, "[\"2026\", \"2027\", \"2028\"]", 156, "41 بعد الأنشطة لبعض التدابير" },
                    { 131, "[\"2025\", \"2026\", \"2027\"]", 505, "130 بعد الأنشطة لبعض التدابير" },
                    { 5, "[\"2027\", \"2028\", \"2029\"]", 28, "4 بعد الأنشطة لبعض التدابير" },
                    { 120, "[\"2022\", \"2023\", \"2024\"]", 505, "119 بعد الأنشطة لبعض التدابير" },
                    { 26, "[\"2028\", \"2029\", \"2030\"]", 354, "25 بعد الأنشطة لبعض التدابير" },
                    { 142, "[\"2024\", \"2025\", \"2026\"]", 526, "141 بعد الأنشطة لبعض التدابير" },
                    { 108, "[\"2020\", \"2021\", \"2022\"]", 527, "107 بعد الأنشطة لبعض التدابير" },
                    { 48, "[\"2026\", \"2027\", \"2028\"]", 53, "47 بعد الأنشطة لبعض التدابير" },
                    { 101, "[\"2018\", \"2019\", \"2020\"]", 516, "100 بعد الأنشطة لبعض التدابير" },
                    { 109, "[\"2026\", \"2027\", \"2028\"]", 502, "108 بعد الأنشطة لبعض التدابير" },
                    { 125, "[\"2026\", \"2027\", \"2028\"]", 531, "124 بعد الأنشطة لبعض التدابير" },
                    { 10, "[\"2021\", \"2022\", \"2023\"]", 378, "9 بعد الأنشطة لبعض التدابير" },
                    { 35, "[\"2027\", \"2028\", \"2029\"]", 60, "34 بعد الأنشطة لبعض التدابير" },
                    { 112, "[\"2019\", \"2020\", \"2021\"]", 518, "111 بعد الأنشطة لبعض التدابير" }
                });

            migrationBuilder.InsertData(
                table: "IndicateurMesureValues",
                columns: new[] { "Id", "Date", "IdIndicateur", "IdMesure", "Value" },
                values: new object[,]
                {
                    { 171, new DateTime(2020, 9, 22, 11, 12, 27, 747, DateTimeKind.Local).AddTicks(1334), 4, 265, "88" },
                    { 197, new DateTime(2020, 9, 2, 0, 24, 55, 547, DateTimeKind.Local).AddTicks(3106), 1, 265, "11" },
                    { 53, new DateTime(2020, 10, 13, 22, 18, 42, 301, DateTimeKind.Local).AddTicks(7221), 2, 260, "77" },
                    { 10, new DateTime(2020, 8, 10, 18, 49, 15, 252, DateTimeKind.Local).AddTicks(8417), 6, 338, "14" },
                    { 61, new DateTime(2020, 9, 16, 17, 27, 56, 231, DateTimeKind.Local).AddTicks(1040), 3, 338, "16" },
                    { 188, new DateTime(2020, 8, 15, 13, 34, 56, 786, DateTimeKind.Local).AddTicks(6652), 2, 182, "47" },
                    { 19, new DateTime(2020, 8, 22, 15, 51, 21, 689, DateTimeKind.Local).AddTicks(47), 5, 259, "80" },
                    { 160, new DateTime(2020, 4, 11, 23, 44, 46, 839, DateTimeKind.Local).AddTicks(5134), 1, 172, "62" },
                    { 186, new DateTime(2020, 8, 6, 7, 50, 56, 73, DateTimeKind.Local).AddTicks(1442), 4, 273, "42" },
                    { 51, new DateTime(2020, 10, 12, 15, 17, 59, 654, DateTimeKind.Local).AddTicks(3590), 3, 300, "54" },
                    { 78, new DateTime(2020, 3, 23, 0, 9, 52, 757, DateTimeKind.Local).AddTicks(752), 6, 300, "13" },
                    { 11, new DateTime(2020, 6, 11, 9, 37, 28, 218, DateTimeKind.Local).AddTicks(1580), 2, 386, "27" },
                    { 22, new DateTime(2020, 3, 12, 5, 4, 10, 33, DateTimeKind.Local).AddTicks(3874), 4, 223, "39" },
                    { 113, new DateTime(2020, 8, 19, 22, 24, 46, 285, DateTimeKind.Local).AddTicks(5456), 2, 386, "26" },
                    { 89, new DateTime(2020, 9, 20, 13, 35, 5, 891, DateTimeKind.Local).AddTicks(2628), 1, 203, "73" },
                    { 121, new DateTime(2020, 6, 30, 8, 52, 34, 64, DateTimeKind.Local).AddTicks(7152), 3, 204, "97" },
                    { 141, new DateTime(2020, 8, 31, 0, 26, 14, 126, DateTimeKind.Local).AddTicks(3251), 5, 204, "58" },
                    { 133, new DateTime(2020, 5, 2, 11, 20, 48, 322, DateTimeKind.Local).AddTicks(2902), 5, 320, "55" },
                    { 177, new DateTime(2020, 7, 16, 21, 9, 7, 915, DateTimeKind.Local).AddTicks(8730), 1, 273, "60" },
                    { 6, new DateTime(2020, 9, 21, 2, 27, 27, 998, DateTimeKind.Local).AddTicks(8843), 4, 357, "80" },
                    { 87, new DateTime(2020, 5, 11, 18, 25, 31, 548, DateTimeKind.Local).AddTicks(1111), 5, 254, "62" },
                    { 75, new DateTime(2021, 1, 19, 8, 25, 7, 409, DateTimeKind.Local).AddTicks(8359), 6, 334, "80" },
                    { 88, new DateTime(2020, 10, 23, 15, 19, 1, 600, DateTimeKind.Local).AddTicks(2310), 2, 372, "97" },
                    { 16, new DateTime(2020, 9, 7, 8, 36, 41, 5, DateTimeKind.Local).AddTicks(6718), 4, 62, "41" },
                    { 30, new DateTime(2020, 12, 3, 14, 50, 6, 868, DateTimeKind.Local).AddTicks(3400), 4, 62, "94" },
                    { 12, new DateTime(2020, 4, 3, 19, 18, 34, 369, DateTimeKind.Local).AddTicks(705), 2, 119, "77" },
                    { 136, new DateTime(2020, 10, 25, 23, 5, 20, 189, DateTimeKind.Local).AddTicks(218), 5, 119, "14" },
                    { 153, new DateTime(2020, 12, 10, 9, 52, 0, 931, DateTimeKind.Local).AddTicks(7510), 5, 158, "61" },
                    { 68, new DateTime(2021, 2, 12, 12, 22, 43, 90, DateTimeKind.Local).AddTicks(6361), 5, 303, "58" },
                    { 187, new DateTime(2020, 11, 10, 19, 53, 49, 21, DateTimeKind.Local).AddTicks(4920), 3, 390, "25" },
                    { 29, new DateTime(2020, 6, 23, 6, 31, 40, 955, DateTimeKind.Local).AddTicks(2607), 6, 115, "98" },
                    { 183, new DateTime(2021, 1, 29, 17, 3, 27, 395, DateTimeKind.Local).AddTicks(9804), 1, 135, "59" },
                    { 81, new DateTime(2021, 1, 20, 13, 30, 52, 301, DateTimeKind.Local).AddTicks(4895), 3, 164, "55" },
                    { 97, new DateTime(2020, 6, 10, 7, 14, 55, 315, DateTimeKind.Local).AddTicks(8831), 6, 164, "88" },
                    { 31, new DateTime(2020, 10, 15, 18, 38, 27, 375, DateTimeKind.Local).AddTicks(8486), 5, 201, "99" },
                    { 114, new DateTime(2020, 10, 27, 17, 23, 56, 841, DateTimeKind.Local).AddTicks(4950), 1, 24, "11" },
                    { 62, new DateTime(2020, 3, 17, 11, 1, 46, 112, DateTimeKind.Local).AddTicks(3515), 3, 45, "95" },
                    { 47, new DateTime(2020, 6, 16, 9, 54, 39, 811, DateTimeKind.Local).AddTicks(3963), 1, 173, "90" },
                    { 65, new DateTime(2020, 3, 9, 14, 36, 55, 928, DateTimeKind.Local).AddTicks(7150), 6, 214, "65" },
                    { 86, new DateTime(2020, 10, 19, 11, 21, 50, 979, DateTimeKind.Local).AddTicks(4438), 2, 254, "43" },
                    { 107, new DateTime(2020, 4, 12, 8, 8, 20, 516, DateTimeKind.Local).AddTicks(8056), 2, 385, "15" },
                    { 35, new DateTime(2020, 8, 17, 0, 11, 29, 829, DateTimeKind.Local).AddTicks(4515), 6, 399, "49" },
                    { 159, new DateTime(2020, 4, 12, 0, 3, 39, 747, DateTimeKind.Local).AddTicks(3098), 5, 264, "86" },
                    { 44, new DateTime(2020, 4, 18, 20, 27, 26, 459, DateTimeKind.Local).AddTicks(7557), 3, 55, "11" },
                    { 185, new DateTime(2020, 11, 20, 19, 9, 24, 214, DateTimeKind.Local).AddTicks(5407), 4, 178, "80" },
                    { 93, new DateTime(2020, 5, 8, 14, 17, 52, 720, DateTimeKind.Local).AddTicks(4313), 6, 346, "72" },
                    { 138, new DateTime(2020, 2, 29, 19, 14, 41, 596, DateTimeKind.Local).AddTicks(8065), 2, 162, "74" },
                    { 100, new DateTime(2020, 4, 3, 23, 39, 13, 815, DateTimeKind.Local).AddTicks(4495), 1, 384, "79" },
                    { 69, new DateTime(2021, 1, 31, 7, 58, 28, 255, DateTimeKind.Local).AddTicks(4433), 4, 51, "16" },
                    { 73, new DateTime(2020, 2, 29, 3, 4, 37, 884, DateTimeKind.Local).AddTicks(4769), 4, 76, "73" },
                    { 13, new DateTime(2021, 1, 23, 5, 31, 33, 972, DateTimeKind.Local).AddTicks(8520), 4, 14, "30" },
                    { 191, new DateTime(2020, 2, 27, 15, 39, 37, 576, DateTimeKind.Local).AddTicks(1066), 5, 187, "35" },
                    { 49, new DateTime(2020, 8, 7, 2, 18, 47, 615, DateTimeKind.Local).AddTicks(1044), 6, 246, "80" },
                    { 143, new DateTime(2020, 8, 11, 7, 39, 17, 676, DateTimeKind.Local).AddTicks(66), 1, 250, "52" },
                    { 112, new DateTime(2020, 6, 19, 1, 49, 7, 2, DateTimeKind.Local).AddTicks(9552), 4, 328, "81" },
                    { 28, new DateTime(2020, 10, 26, 11, 35, 24, 795, DateTimeKind.Local).AddTicks(1467), 3, 43, "20" },
                    { 125, new DateTime(2020, 8, 17, 19, 37, 41, 360, DateTimeKind.Local).AddTicks(8782), 6, 99, "97" },
                    { 144, new DateTime(2020, 8, 18, 10, 30, 17, 686, DateTimeKind.Local).AddTicks(2226), 4, 175, "24" },
                    { 25, new DateTime(2020, 8, 21, 15, 7, 4, 159, DateTimeKind.Local).AddTicks(9459), 5, 429, "83" },
                    { 166, new DateTime(2020, 5, 16, 23, 25, 22, 345, DateTimeKind.Local).AddTicks(2055), 5, 253, "96" },
                    { 161, new DateTime(2020, 9, 3, 1, 29, 57, 587, DateTimeKind.Local).AddTicks(4229), 6, 424, "27" },
                    { 23, new DateTime(2020, 9, 30, 18, 47, 22, 595, DateTimeKind.Local).AddTicks(5167), 6, 426, "12" },
                    { 85, new DateTime(2020, 5, 12, 6, 13, 40, 81, DateTimeKind.Local).AddTicks(7022), 6, 257, "49" },
                    { 72, new DateTime(2021, 1, 25, 20, 40, 30, 13, DateTimeKind.Local).AddTicks(7438), 1, 270, "69" },
                    { 54, new DateTime(2020, 9, 26, 23, 3, 34, 977, DateTimeKind.Local).AddTicks(9650), 4, 323, "90" },
                    { 67, new DateTime(2020, 6, 13, 16, 15, 33, 401, DateTimeKind.Local).AddTicks(5094), 1, 282, "57" },
                    { 45, new DateTime(2020, 6, 27, 19, 20, 24, 838, DateTimeKind.Local).AddTicks(9199), 3, 420, "54" },
                    { 119, new DateTime(2020, 5, 26, 1, 13, 45, 772, DateTimeKind.Local).AddTicks(4563), 5, 421, "96" },
                    { 3, new DateTime(2020, 8, 5, 12, 59, 33, 137, DateTimeKind.Local).AddTicks(9939), 4, 78, "57" },
                    { 48, new DateTime(2020, 6, 12, 0, 40, 47, 362, DateTimeKind.Local).AddTicks(9490), 6, 268, "76" },
                    { 126, new DateTime(2020, 2, 23, 4, 29, 50, 782, DateTimeKind.Local).AddTicks(5161), 5, 147, "20" },
                    { 17, new DateTime(2020, 2, 28, 22, 52, 53, 26, DateTimeKind.Local).AddTicks(3874), 5, 379, "76" },
                    { 32, new DateTime(2020, 4, 26, 14, 10, 5, 999, DateTimeKind.Local).AddTicks(7278), 5, 157, "35" },
                    { 101, new DateTime(2020, 3, 31, 20, 19, 12, 319, DateTimeKind.Local).AddTicks(7682), 4, 307, "98" },
                    { 199, new DateTime(2020, 3, 18, 6, 46, 2, 119, DateTimeKind.Local).AddTicks(9725), 3, 208, "83" },
                    { 193, new DateTime(2020, 11, 8, 14, 11, 1, 866, DateTimeKind.Local).AddTicks(7352), 4, 186, "69" },
                    { 37, new DateTime(2020, 3, 10, 7, 42, 10, 454, DateTimeKind.Local).AddTicks(2287), 5, 368, "20" },
                    { 24, new DateTime(2020, 11, 14, 13, 12, 48, 342, DateTimeKind.Local).AddTicks(4117), 5, 407, "44" },
                    { 140, new DateTime(2020, 10, 25, 15, 15, 9, 980, DateTimeKind.Local).AddTicks(8878), 5, 136, "16" },
                    { 157, new DateTime(2020, 4, 11, 7, 43, 18, 381, DateTimeKind.Local).AddTicks(1184), 6, 286, "65" },
                    { 137, new DateTime(2021, 1, 14, 4, 29, 23, 560, DateTimeKind.Local).AddTicks(3745), 4, 301, "74" },
                    { 149, new DateTime(2020, 7, 29, 10, 1, 34, 103, DateTimeKind.Local).AddTicks(8586), 4, 396, "40" },
                    { 84, new DateTime(2020, 4, 11, 5, 23, 21, 322, DateTimeKind.Local).AddTicks(136), 3, 356, "53" },
                    { 39, new DateTime(2020, 6, 3, 11, 50, 29, 894, DateTimeKind.Local).AddTicks(4422), 4, 356, "12" },
                    { 164, new DateTime(2020, 5, 29, 0, 11, 28, 411, DateTimeKind.Local).AddTicks(726), 2, 71, "43" },
                    { 123, new DateTime(2020, 2, 22, 11, 55, 28, 11, DateTimeKind.Local).AddTicks(1114), 2, 262, "100" },
                    { 118, new DateTime(2020, 6, 1, 11, 12, 5, 179, DateTimeKind.Local).AddTicks(2011), 6, 237, "50" },
                    { 57, new DateTime(2020, 11, 14, 9, 49, 17, 11, DateTimeKind.Local).AddTicks(1756), 1, 319, "76" },
                    { 59, new DateTime(2020, 12, 11, 5, 48, 21, 381, DateTimeKind.Local).AddTicks(3090), 1, 359, "96" },
                    { 82, new DateTime(2020, 9, 10, 12, 3, 48, 254, DateTimeKind.Local).AddTicks(7471), 4, 4, "98" },
                    { 162, new DateTime(2021, 1, 14, 20, 25, 34, 290, DateTimeKind.Local).AddTicks(3781), 2, 23, "42" },
                    { 66, new DateTime(2021, 1, 6, 3, 55, 47, 122, DateTimeKind.Local).AddTicks(1457), 1, 41, "76" },
                    { 150, new DateTime(2020, 2, 29, 0, 1, 9, 273, DateTimeKind.Local).AddTicks(8149), 4, 92, "57" },
                    { 165, new DateTime(2020, 3, 30, 23, 38, 38, 572, DateTimeKind.Local).AddTicks(3496), 4, 137, "68" },
                    { 102, new DateTime(2020, 5, 22, 9, 27, 25, 542, DateTimeKind.Local).AddTicks(4486), 2, 222, "37" },
                    { 56, new DateTime(2020, 7, 10, 11, 20, 12, 297, DateTimeKind.Local).AddTicks(7420), 3, 234, "10" },
                    { 92, new DateTime(2020, 3, 1, 14, 53, 3, 695, DateTimeKind.Local).AddTicks(9064), 5, 247, "17" },
                    { 169, new DateTime(2020, 7, 13, 12, 20, 53, 930, DateTimeKind.Local).AddTicks(4959), 4, 235, "35" },
                    { 41, new DateTime(2020, 7, 17, 16, 24, 13, 862, DateTimeKind.Local).AddTicks(4967), 4, 319, "42" },
                    { 198, new DateTime(2020, 12, 23, 16, 41, 19, 868, DateTimeKind.Local).AddTicks(8814), 3, 249, "95" },
                    { 38, new DateTime(2020, 9, 13, 19, 54, 48, 485, DateTimeKind.Local).AddTicks(1808), 5, 352, "20" },
                    { 34, new DateTime(2020, 8, 12, 6, 15, 43, 338, DateTimeKind.Local).AddTicks(8893), 4, 121, "59" },
                    { 152, new DateTime(2020, 12, 29, 11, 44, 28, 349, DateTimeKind.Local).AddTicks(685), 2, 370, "61" },
                    { 175, new DateTime(2020, 5, 14, 21, 6, 42, 39, DateTimeKind.Local).AddTicks(1747), 3, 22, "99" },
                    { 170, new DateTime(2020, 9, 11, 12, 20, 7, 626, DateTimeKind.Local).AddTicks(5828), 1, 215, "92" },
                    { 155, new DateTime(2020, 11, 15, 15, 32, 17, 1, DateTimeKind.Local).AddTicks(3888), 1, 126, "48" },
                    { 70, new DateTime(2020, 10, 13, 12, 17, 24, 660, DateTimeKind.Local).AddTicks(3374), 4, 126, "55" },
                    { 7, new DateTime(2020, 8, 9, 14, 32, 1, 970, DateTimeKind.Local).AddTicks(7438), 1, 126, "42" },
                    { 135, new DateTime(2020, 4, 26, 22, 20, 3, 466, DateTimeKind.Local).AddTicks(8421), 6, 121, "88" },
                    { 134, new DateTime(2020, 5, 28, 5, 18, 1, 518, DateTimeKind.Local).AddTicks(1154), 3, 37, "13" },
                    { 129, new DateTime(2020, 5, 22, 1, 56, 41, 462, DateTimeKind.Local).AddTicks(4498), 4, 121, "81" },
                    { 71, new DateTime(2020, 11, 6, 13, 26, 58, 336, DateTimeKind.Local).AddTicks(4337), 5, 50, "34" },
                    { 181, new DateTime(2020, 4, 9, 13, 52, 15, 309, DateTimeKind.Local).AddTicks(2966), 2, 81, "23" },
                    { 4, new DateTime(2020, 3, 6, 8, 45, 2, 282, DateTimeKind.Local).AddTicks(5749), 5, 375, "84" },
                    { 142, new DateTime(2020, 4, 28, 5, 49, 32, 585, DateTimeKind.Local).AddTicks(2278), 5, 344, "32" },
                    { 158, new DateTime(2020, 11, 9, 1, 55, 55, 422, DateTimeKind.Local).AddTicks(2649), 4, 82, "36" },
                    { 120, new DateTime(2020, 10, 1, 0, 3, 6, 22, DateTimeKind.Local).AddTicks(5280), 1, 344, "98" },
                    { 131, new DateTime(2020, 10, 16, 3, 46, 56, 509, DateTimeKind.Local).AddTicks(6141), 6, 106, "49" },
                    { 99, new DateTime(2020, 7, 14, 9, 5, 33, 252, DateTimeKind.Local).AddTicks(2012), 1, 313, "90" },
                    { 64, new DateTime(2020, 10, 19, 16, 4, 34, 924, DateTimeKind.Local).AddTicks(8554), 5, 28, "91" },
                    { 200, new DateTime(2020, 5, 30, 10, 43, 21, 348, DateTimeKind.Local).AddTicks(6792), 3, 107, "37" },
                    { 79, new DateTime(2020, 11, 5, 19, 42, 7, 923, DateTimeKind.Local).AddTicks(5041), 2, 168, "85" },
                    { 139, new DateTime(2020, 9, 13, 23, 23, 19, 462, DateTimeKind.Local).AddTicks(1061), 4, 288, "33" },
                    { 91, new DateTime(2020, 10, 12, 17, 1, 15, 115, DateTimeKind.Local).AddTicks(241), 6, 383, "39" },
                    { 146, new DateTime(2020, 9, 15, 5, 13, 37, 309, DateTimeKind.Local).AddTicks(9326), 6, 327, "49" },
                    { 40, new DateTime(2020, 7, 25, 1, 56, 48, 410, DateTimeKind.Local).AddTicks(7122), 2, 342, "35" },
                    { 172, new DateTime(2020, 10, 15, 9, 27, 1, 155, DateTimeKind.Local).AddTicks(2946), 2, 151, "19" },
                    { 176, new DateTime(2020, 11, 6, 5, 20, 58, 197, DateTimeKind.Local).AddTicks(4227), 6, 281, "20" },
                    { 192, new DateTime(2020, 8, 12, 11, 9, 17, 245, DateTimeKind.Local).AddTicks(5314), 2, 101, "12" },
                    { 124, new DateTime(2020, 12, 4, 12, 12, 49, 499, DateTimeKind.Local).AddTicks(3272), 1, 308, "14" },
                    { 20, new DateTime(2021, 1, 28, 2, 0, 24, 635, DateTimeKind.Local).AddTicks(4498), 1, 194, "22" },
                    { 128, new DateTime(2020, 10, 17, 4, 7, 31, 41, DateTimeKind.Local).AddTicks(9248), 2, 91, "57" },
                    { 18, new DateTime(2020, 11, 30, 7, 52, 7, 853, DateTimeKind.Local).AddTicks(4831), 3, 130, "25" },
                    { 2, new DateTime(2020, 6, 16, 6, 20, 26, 588, DateTimeKind.Local).AddTicks(4092), 4, 125, "23" },
                    { 5, new DateTime(2020, 6, 20, 22, 29, 12, 718, DateTimeKind.Local).AddTicks(3794), 4, 87, "31" },
                    { 21, new DateTime(2020, 5, 3, 5, 12, 10, 237, DateTimeKind.Local).AddTicks(5020), 3, 125, "54" },
                    { 163, new DateTime(2021, 1, 11, 3, 25, 11, 753, DateTimeKind.Local).AddTicks(213), 5, 432, "34" },
                    { 130, new DateTime(2020, 9, 10, 5, 19, 20, 826, DateTimeKind.Local).AddTicks(6774), 2, 216, "40" },
                    { 96, new DateTime(2020, 3, 12, 23, 37, 42, 746, DateTimeKind.Local).AddTicks(4605), 2, 432, "62" },
                    { 52, new DateTime(2020, 9, 27, 21, 54, 33, 528, DateTimeKind.Local).AddTicks(8112), 5, 432, "37" },
                    { 98, new DateTime(2020, 9, 8, 8, 52, 38, 613, DateTimeKind.Local).AddTicks(4735), 1, 315, "18" },
                    { 117, new DateTime(2021, 2, 3, 2, 47, 12, 358, DateTimeKind.Local).AddTicks(5441), 2, 103, "25" },
                    { 148, new DateTime(2020, 8, 19, 12, 22, 38, 33, DateTimeKind.Local).AddTicks(2103), 4, 94, "47" },
                    { 110, new DateTime(2020, 12, 10, 19, 15, 47, 718, DateTimeKind.Local).AddTicks(4756), 5, 102, "48" },
                    { 1, new DateTime(2020, 10, 15, 9, 33, 43, 937, DateTimeKind.Local).AddTicks(1776), 2, 86, "83" },
                    { 80, new DateTime(2020, 6, 27, 17, 26, 1, 290, DateTimeKind.Local).AddTicks(1462), 3, 335, "54" },
                    { 127, new DateTime(2020, 11, 10, 16, 0, 29, 417, DateTimeKind.Local).AddTicks(339), 3, 335, "57" },
                    { 36, new DateTime(2020, 7, 31, 9, 21, 15, 626, DateTimeKind.Local).AddTicks(1286), 4, 85, "85" },
                    { 194, new DateTime(2020, 6, 19, 1, 24, 23, 912, DateTimeKind.Local).AddTicks(1455), 2, 335, "69" },
                    { 76, new DateTime(2020, 11, 5, 12, 8, 38, 257, DateTimeKind.Local).AddTicks(1976), 2, 378, "30" },
                    { 15, new DateTime(2020, 11, 12, 10, 52, 51, 891, DateTimeKind.Local).AddTicks(7124), 3, 174, "14" },
                    { 46, new DateTime(2020, 7, 6, 21, 4, 29, 645, DateTimeKind.Local).AddTicks(2438), 3, 296, "10" },
                    { 83, new DateTime(2020, 10, 19, 16, 40, 49, 325, DateTimeKind.Local).AddTicks(6152), 3, 58, "35" },
                    { 60, new DateTime(2020, 7, 21, 9, 5, 4, 499, DateTimeKind.Local).AddTicks(3899), 4, 371, "66" },
                    { 109, new DateTime(2020, 10, 2, 23, 17, 20, 568, DateTimeKind.Local).AddTicks(9008), 4, 181, "56" },
                    { 174, new DateTime(2020, 11, 12, 11, 37, 43, 313, DateTimeKind.Local).AddTicks(4459), 5, 210, "34" },
                    { 26, new DateTime(2020, 6, 26, 5, 26, 44, 471, DateTimeKind.Local).AddTicks(9880), 5, 220, "62" },
                    { 178, new DateTime(2020, 12, 12, 20, 18, 12, 305, DateTimeKind.Local).AddTicks(6902), 5, 430, "30" },
                    { 168, new DateTime(2020, 12, 20, 11, 16, 56, 858, DateTimeKind.Local).AddTicks(3273), 5, 425, "24" },
                    { 189, new DateTime(2020, 9, 22, 8, 23, 0, 247, DateTimeKind.Local).AddTicks(1782), 5, 16, "62" },
                    { 55, new DateTime(2020, 4, 10, 7, 58, 5, 415, DateTimeKind.Local).AddTicks(924), 5, 290, "27" },
                    { 179, new DateTime(2021, 1, 25, 4, 1, 39, 123, DateTimeKind.Local).AddTicks(5759), 2, 287, "34" },
                    { 182, new DateTime(2020, 4, 11, 21, 11, 56, 435, DateTimeKind.Local).AddTicks(6591), 2, 77, "71" },
                    { 94, new DateTime(2020, 12, 14, 15, 52, 13, 388, DateTimeKind.Local).AddTicks(6640), 5, 6, "15" },
                    { 104, new DateTime(2020, 6, 14, 16, 32, 50, 835, DateTimeKind.Local).AddTicks(3115), 1, 287, "35" },
                    { 74, new DateTime(2020, 5, 23, 17, 5, 10, 506, DateTimeKind.Local).AddTicks(7871), 5, 17, "53" },
                    { 147, new DateTime(2020, 7, 26, 15, 46, 7, 844, DateTimeKind.Local).AddTicks(8408), 4, 17, "21" },
                    { 58, new DateTime(2020, 5, 31, 3, 29, 49, 533, DateTimeKind.Local).AddTicks(8925), 3, 287, "60" },
                    { 116, new DateTime(2020, 7, 6, 17, 2, 26, 467, DateTimeKind.Local).AddTicks(411), 3, 59, "91" },
                    { 154, new DateTime(2020, 7, 28, 12, 24, 10, 780, DateTimeKind.Local).AddTicks(4844), 5, 59, "60" },
                    { 95, new DateTime(2020, 11, 29, 0, 46, 29, 315, DateTimeKind.Local).AddTicks(3893), 2, 39, "54" },
                    { 132, new DateTime(2020, 4, 27, 21, 9, 41, 794, DateTimeKind.Local).AddTicks(1040), 3, 397, "10" },
                    { 184, new DateTime(2020, 6, 4, 20, 44, 33, 876, DateTimeKind.Local).AddTicks(703), 1, 67, "81" },
                    { 196, new DateTime(2021, 1, 10, 4, 16, 7, 871, DateTimeKind.Local).AddTicks(9119), 3, 67, "49" },
                    { 111, new DateTime(2020, 12, 7, 6, 38, 2, 91, DateTimeKind.Local).AddTicks(4353), 1, 287, "65" },
                    { 180, new DateTime(2020, 11, 3, 18, 24, 33, 958, DateTimeKind.Local).AddTicks(9646), 4, 371, "47" },
                    { 106, new DateTime(2020, 5, 27, 11, 49, 19, 928, DateTimeKind.Local).AddTicks(6579), 3, 371, "31" },
                    { 63, new DateTime(2020, 8, 2, 9, 0, 57, 733, DateTimeKind.Local).AddTicks(8001), 3, 428, "88" },
                    { 195, new DateTime(2020, 4, 21, 21, 18, 15, 162, DateTimeKind.Local).AddTicks(4724), 4, 387, "97" },
                    { 33, new DateTime(2020, 6, 6, 11, 55, 36, 873, DateTimeKind.Local).AddTicks(7067), 4, 149, "55" },
                    { 43, new DateTime(2020, 11, 1, 2, 51, 16, 237, DateTimeKind.Local).AddTicks(8893), 3, 195, "76" },
                    { 90, new DateTime(2020, 11, 9, 13, 57, 30, 535, DateTimeKind.Local).AddTicks(6698), 1, 331, "34" },
                    { 9, new DateTime(2020, 9, 12, 18, 15, 44, 204, DateTimeKind.Local).AddTicks(1230), 6, 349, "57" },
                    { 190, new DateTime(2020, 10, 30, 12, 36, 13, 825, DateTimeKind.Local).AddTicks(441), 2, 332, "19" },
                    { 156, new DateTime(2020, 3, 3, 18, 12, 13, 29, DateTimeKind.Local).AddTicks(4486), 5, 258, "63" },
                    { 151, new DateTime(2020, 10, 28, 7, 48, 51, 60, DateTimeKind.Local).AddTicks(2233), 6, 179, "57" },
                    { 105, new DateTime(2020, 7, 9, 22, 36, 3, 120, DateTimeKind.Local).AddTicks(4585), 3, 179, "98" },
                    { 42, new DateTime(2020, 7, 4, 12, 4, 18, 246, DateTimeKind.Local).AddTicks(9401), 3, 405, "12" },
                    { 115, new DateTime(2020, 11, 13, 21, 42, 14, 877, DateTimeKind.Local).AddTicks(6976), 2, 165, "100" },
                    { 14, new DateTime(2020, 7, 26, 20, 52, 1, 375, DateTimeKind.Local).AddTicks(2325), 6, 179, "93" },
                    { 167, new DateTime(2020, 9, 3, 14, 34, 8, 336, DateTimeKind.Local).AddTicks(7050), 2, 206, "62" },
                    { 145, new DateTime(2020, 11, 16, 9, 36, 25, 399, DateTimeKind.Local).AddTicks(3476), 1, 375, "68" },
                    { 27, new DateTime(2020, 6, 8, 4, 37, 25, 194, DateTimeKind.Local).AddTicks(3747), 1, 156, "53" },
                    { 8, new DateTime(2020, 5, 24, 0, 42, 3, 29, DateTimeKind.Local).AddTicks(2052), 5, 140, "76" },
                    { 173, new DateTime(2020, 4, 17, 21, 26, 54, 681, DateTimeKind.Local).AddTicks(3607), 1, 134, "58" },
                    { 50, new DateTime(2020, 9, 12, 22, 7, 34, 131, DateTimeKind.Local).AddTicks(3367), 2, 122, "66" },
                    { 103, new DateTime(2020, 7, 17, 13, 35, 4, 607, DateTimeKind.Local).AddTicks(2223), 4, 34, "38" },
                    { 108, new DateTime(2021, 1, 23, 19, 45, 19, 116, DateTimeKind.Local).AddTicks(8747), 3, 367, "36" },
                    { 77, new DateTime(2020, 9, 4, 17, 57, 24, 491, DateTimeKind.Local).AddTicks(1576), 6, 367, "48" },
                    { 122, new DateTime(2020, 11, 13, 15, 52, 31, 271, DateTimeKind.Local).AddTicks(2867), 5, 122, "11" }
                });

            migrationBuilder.InsertData(
                table: "IndicateurMesures",
                columns: new[] { "IdMesure", "IdIndicateur" },
                values: new object[,]
                {
                    { 14, 17 },
                    { 35, 33 },
                    { 39, 37 },
                    { 110, 89 },
                    { 54, 50 },
                    { 97, 6 },
                    { 78, 64 },
                    { 35, 32 },
                    { 102, 9 },
                    { 84, 69 },
                    { 101, 25 },
                    { 68, 59 },
                    { 68, 60 },
                    { 48, 44 },
                    { 75, 6 },
                    { 96, 82 },
                    { 34, 31 },
                    { 28, 28 },
                    { 42, 40 },
                    { 53, 49 },
                    { 60, 53 },
                    { 73, 6 },
                    { 40, 38 },
                    { 61, 53 },
                    { 86, 71 },
                    { 89, 74 },
                    { 90, 75 },
                    { 103, 84 },
                    { 98, 6 },
                    { 87, 25 },
                    { 91, 76 },
                    { 100, 25 },
                    { 32, 30 },
                    { 73, 62 },
                    { 51, 47 },
                    { 19, 21 },
                    { 66, 57 },
                    { 63, 6 },
                    { 109, 88 },
                    { 49, 45 },
                    { 47, 6 },
                    { 93, 78 },
                    { 70, 61 },
                    { 58, 52 },
                    { 55, 51 },
                    { 5, 6 },
                    { 20, 22 },
                    { 107, 87 },
                    { 106, 86 },
                    { 82, 9 },
                    { 56, 9 },
                    { 82, 32 },
                    { 81, 42 },
                    { 64, 6 },
                    { 5, 7 },
                    { 37, 35 },
                    { 55, 30 },
                    { 113, 30 },
                    { 62, 30 },
                    { 67, 58 },
                    { 59, 53 },
                    { 17, 5 },
                    { 17, 3 },
                    { 79, 65 },
                    { 80, 66 },
                    { 111, 90 },
                    { 108, 6 },
                    { 6, 8 },
                    { 12, 15 },
                    { 21, 23 },
                    { 24, 26 },
                    { 45, 6 },
                    { 77, 6 },
                    { 69, 25 },
                    { 112, 91 },
                    { 57, 25 },
                    { 2, 3 },
                    { 7, 9 },
                    { 9, 12 },
                    { 30, 29 },
                    { 3, 4 },
                    { 15, 5 },
                    { 18, 20 },
                    { 52, 48 },
                    { 76, 6 },
                    { 105, 30 },
                    { 94, 80 },
                    { 94, 79 },
                    { 1, 1 },
                    { 85, 70 },
                    { 50, 46 },
                    { 44, 42 },
                    { 88, 73 },
                    { 99, 25 },
                    { 38, 36 },
                    { 16, 19 },
                    { 16, 18 },
                    { 83, 68 },
                    { 43, 41 },
                    { 1, 2 },
                    { 8, 10 },
                    { 8, 11 },
                    { 72, 6 },
                    { 22, 24 },
                    { 46, 6 },
                    { 71, 6 },
                    { 104, 34 },
                    { 95, 81 },
                    { 36, 34 },
                    { 29, 4 },
                    { 4, 5 },
                    { 27, 6 },
                    { 10, 13 },
                    { 25, 27 },
                    { 11, 14 },
                    { 23, 25 },
                    { 41, 39 },
                    { 74, 6 },
                    { 92, 77 },
                    { 114, 9 },
                    { 33, 30 },
                    { 65, 4 },
                    { 13, 16 }
                });

            migrationBuilder.InsertData(
                table: "Realisations",
                columns: new[] { "Id", "Annee", "Effet", "IdActivite", "Nom", "Situation", "Taux", "TauxRealisation" },
                values: new object[,]
                {
                    { 5, 2020, "4 التأثير لهدا الإنجاز", 18, "4 بعد الإنجازات لبعض الأنشطة ", "4 وضعية التنفيد لهدا الإنجاز", "4 معدل الإنجاز لهدا الإنجاز", 83.0 },
                    { 258, 2029, "257 التأثير لهدا الإنجاز", 106, "257 بعد الإنجازات لبعض الأنشطة ", "257 وضعية التنفيد لهدا الإنجاز", "257 معدل الإنجاز لهدا الإنجاز", 84.0 },
                    { 263, 2027, "262 التأثير لهدا الإنجاز", 117, "262 بعد الإنجازات لبعض الأنشطة ", "262 وضعية التنفيد لهدا الإنجاز", "262 معدل الإنجاز لهدا الإنجاز", 90.0 },
                    { 277, 2025, "276 التأثير لهدا الإنجاز", 127, "276 بعد الإنجازات لبعض الأنشطة ", "276 وضعية التنفيد لهدا الإنجاز", "276 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 247, 2025, "246 التأثير لهدا الإنجاز", 127, "246 بعد الإنجازات لبعض الأنشطة ", "246 وضعية التنفيد لهدا الإنجاز", "246 معدل الإنجاز لهدا الإنجاز", 35.0 },
                    { 237, 2028, "236 التأثير لهدا الإنجاز", 127, "236 بعد الإنجازات لبعض الأنشطة ", "236 وضعية التنفيد لهدا الإنجاز", "236 معدل الإنجاز لهدا الإنجاز", 93.0 },
                    { 241, 2018, "240 التأثير لهدا الإنجاز", 125, "240 بعد الإنجازات لبعض الأنشطة ", "240 وضعية التنفيد لهدا الإنجاز", "240 معدل الإنجاز لهدا الإنجاز", 22.0 },
                    { 274, 2024, "273 التأثير لهدا الإنجاز", 142, "273 بعد الإنجازات لبعض الأنشطة ", "273 وضعية التنفيد لهدا الإنجاز", "273 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 244, 2021, "243 التأثير لهدا الإنجاز", 142, "243 بعد الإنجازات لبعض الأنشطة ", "243 وضعية التنفيد لهدا الإنجاز", "243 معدل الإنجاز لهدا الإنجاز", 72.0 },
                    { 246, 2022, "245 التأثير لهدا الإنجاز", 112, "245 بعد الإنجازات لبعض الأنشطة ", "245 وضعية التنفيد لهدا الإنجاز", "245 معدل الإنجاز لهدا الإنجاز", 39.0 },
                    { 275, 2020, "274 التأثير لهدا الإنجاز", 101, "274 بعد الإنجازات لبعض الأنشطة ", "274 وضعية التنفيد لهدا الإنجاز", "274 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 272, 2022, "271 التأثير لهدا الإنجاز", 101, "271 بعد الإنجازات لبعض الأنشطة ", "271 وضعية التنفيد لهدا الإنجاز", "271 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 266, 2018, "265 التأثير لهدا الإنجاز", 101, "265 بعد الإنجازات لبعض الأنشطة ", "265 وضعية التنفيد لهدا الإنجاز", "265 معدل الإنجاز لهدا الإنجاز", 47.0 },
                    { 281, 2019, "280 التأثير لهدا الإنجاز", 131, "280 بعد الإنجازات لبعض الأنشطة ", "280 وضعية التنفيد لهدا الإنجاز", "280 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 259, 2018, "258 التأثير لهدا الإنجاز", 131, "258 بعد الإنجازات لبعض الأنشطة ", "258 وضعية التنفيد لهدا الإنجاز", "258 معدل الإنجاز لهدا الإنجاز", 57.0 },
                    { 243, 2027, "242 التأثير لهدا الإنجاز", 131, "242 بعد الإنجازات لبعض الأنشطة ", "242 وضعية التنفيد لهدا الإنجاز", "242 معدل الإنجاز لهدا الإنجاز", 21.0 },
                    { 276, 2028, "275 التأثير لهدا الإنجاز", 120, "275 بعد الإنجازات لبعض الأنشطة ", "275 وضعية التنفيد لهدا الإنجاز", "275 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 250, 2025, "249 التأثير لهدا الإنجاز", 120, "249 بعد الإنجازات لبعض الأنشطة ", "249 وضعية التنفيد لهدا الإنجاز", "249 معدل الإنجاز لهدا الإنجاز", 32.0 },
                    { 242, 2019, "241 التأثير لهدا الإنجاز", 122, "241 بعد الإنجازات لبعض الأنشطة ", "241 وضعية التنفيد لهدا الإنجاز", "241 معدل الإنجاز لهدا الإنجاز", 71.0 },
                    { 251, 2028, "250 التأثير لهدا الإنجاز", 150, "250 بعد الإنجازات لبعض الأنشطة ", "250 وضعية التنفيد لهدا الإنجاز", "250 معدل الإنجاز لهدا الإنجاز", 52.0 },
                    { 288, 2020, "287 التأثير لهدا الإنجاز", 150, "287 بعد الإنجازات لبعض الأنشطة ", "287 وضعية التنفيد لهدا الإنجاز", "287 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 252, 2026, "251 التأثير لهدا الإنجاز", 114, "251 بعد الإنجازات لبعض الأنشطة ", "251 وضعية التنفيد لهدا الإنجاز", "251 معدل الإنجاز لهدا الإنجاز", 24.0 },
                    { 234, 2021, "233 التأثير لهدا الإنجاز", 138, "233 بعد الإنجازات لبعض الأنشطة ", "233 وضعية التنفيد لهدا الإنجاز", "233 معدل الإنجاز لهدا الإنجاز", 49.0 },
                    { 253, 2020, "252 التأثير لهدا الإنجاز", 138, "252 بعد الإنجازات لبعض الأنشطة ", "252 وضعية التنفيد لهدا الإنجاز", "252 معدل الإنجاز لهدا الإنجاز", 11.0 },
                    { 224, 2025, "223 التأثير لهدا الإنجاز", 102, "223 بعد الإنجازات لبعض الأنشطة ", "223 وضعية التنفيد لهدا الإنجاز", "223 معدل الإنجاز لهدا الإنجاز", 64.0 },
                    { 225, 2029, "224 التأثير لهدا الإنجاز", 119, "224 بعد الإنجازات لبعض الأنشطة ", "224 وضعية التنفيد لهدا الإنجاز", "224 معدل الإنجاز لهدا الإنجاز", 63.0 },
                    { 222, 2023, "221 التأثير لهدا الإنجاز", 113, "221 بعد الإنجازات لبعض الأنشطة ", "221 وضعية التنفيد لهدا الإنجاز", "221 معدل الإنجاز لهدا الإنجاز", 77.0 },
                    { 231, 2028, "230 التأثير لهدا الإنجاز", 113, "230 بعد الإنجازات لبعض الأنشطة ", "230 وضعية التنفيد لهدا الإنجاز", "230 معدل الإنجاز لهدا الإنجاز", 21.0 },
                    { 257, 2022, "256 التأثير لهدا الإنجاز", 113, "256 بعد الإنجازات لبعض الأنشطة ", "256 وضعية التنفيد لهدا الإنجاز", "256 معدل الإنجاز لهدا الإنجاز", 12.0 },
                    { 221, 2020, "220 التأثير لهدا الإنجاز", 109, "220 بعد الإنجازات لبعض الأنشطة ", "220 وضعية التنفيد لهدا الإنجاز", "220 معدل الإنجاز لهدا الإنجاز", 89.0 },
                    { 229, 2029, "228 التأثير لهدا الإنجاز", 109, "228 بعد الإنجازات لبعض الأنشطة ", "228 وضعية التنفيد لهدا الإنجاز", "228 معدل الإنجاز لهدا الإنجاز", 20.0 },
                    { 245, 2025, "244 التأثير لهدا الإنجاز", 109, "244 بعد الإنجازات لبعض الأنشطة ", "244 وضعية التنفيد لهدا الإنجاز", "244 معدل الإنجاز لهدا الإنجاز", 57.0 },
                    { 226, 2026, "225 التأثير لهدا الإنجاز", 146, "225 بعد الإنجازات لبعض الأنشطة ", "225 وضعية التنفيد لهدا الإنجاز", "225 معدل الإنجاز لهدا الإنجاز", 29.0 },
                    { 290, 2028, "289 التأثير لهدا الإنجاز", 139, "289 بعد الإنجازات لبعض الأنشطة ", "289 وضعية التنفيد لهدا الإنجاز", "289 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 261, 2026, "260 التأثير لهدا الإنجاز", 145, "260 بعد الإنجازات لبعض الأنشطة ", "260 وضعية التنفيد لهدا الإنجاز", "260 معدل الإنجاز لهدا الإنجاز", 12.0 },
                    { 264, 2028, "263 التأثير لهدا الإنجاز", 115, "263 بعد الإنجازات لبعض الأنشطة ", "263 وضعية التنفيد لهدا الإنجاز", "263 معدل الإنجاز لهدا الإنجاز", 10.0 },
                    { 228, 2024, "227 التأثير لهدا الإنجاز", 137, "227 بعد الإنجازات لبعض الأنشطة ", "227 وضعية التنفيد لهدا الإنجاز", "227 معدل الإنجاز لهدا الإنجاز", 70.0 },
                    { 287, 2020, "286 التأثير لهدا الإنجاز", 134, "286 بعد الإنجازات لبعض الأنشطة ", "286 وضعية التنفيد لهدا الإنجاز", "286 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 270, 2028, "269 التأثير لهدا الإنجاز", 134, "269 بعد الإنجازات لبعض الأنشطة ", "269 وضعية التنفيد لهدا الإنجاز", "269 معدل الإنجاز لهدا الإنجاز", 67.0 },
                    { 262, 2020, "261 التأثير لهدا الإنجاز", 110, "261 بعد الإنجازات لبعض الأنشطة ", "261 وضعية التنفيد لهدا الإنجاز", "261 معدل الإنجاز لهدا الإنجاز", 40.0 },
                    { 239, 2023, "238 التأثير لهدا الإنجاز", 110, "238 بعد الإنجازات لبعض الأنشطة ", "238 وضعية التنفيد لهدا الإنجاز", "238 معدل الإنجاز لهدا الإنجاز", 63.0 },
                    { 256, 2026, "255 التأثير لهدا الإنجاز", 147, "255 بعد الإنجازات لبعض الأنشطة ", "255 وضعية التنفيد لهدا الإنجاز", "255 معدل الإنجاز لهدا الإنجاز", 28.0 },
                    { 271, 2025, "270 التأثير لهدا الإنجاز", 105, "270 بعد الإنجازات لبعض الأنشطة ", "270 وضعية التنفيد لهدا الإنجاز", "270 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 232, 2027, "231 التأثير لهدا الإنجاز", 105, "231 بعد الإنجازات لبعض الأنشطة ", "231 وضعية التنفيد لهدا الإنجاز", "231 معدل الإنجاز لهدا الإنجاز", 3.0 },
                    { 227, 2028, "226 التأثير لهدا الإنجاز", 105, "226 بعد الإنجازات لبعض الأنشطة ", "226 وضعية التنفيد لهدا الإنجاز", "226 معدل الإنجاز لهدا الإنجاز", 66.0 },
                    { 285, 2018, "284 التأثير لهدا الإنجاز", 124, "284 بعد الإنجازات لبعض الأنشطة ", "284 وضعية التنفيد لهدا الإنجاز", "284 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 284, 2028, "283 التأثير لهدا الإنجاز", 135, "283 بعد الإنجازات لبعض الأنشطة ", "283 وضعية التنفيد لهدا الإنجاز", "283 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 269, 2019, "268 التأثير لهدا الإنجاز", 135, "268 بعد الإنجازات لبعض الأنشطة ", "268 وضعية التنفيد لهدا الإنجاز", "268 معدل الإنجاز لهدا الإنجاز", 92.0 },
                    { 267, 2019, "266 التأثير لهدا الإنجاز", 135, "266 بعد الإنجازات لبعض الأنشطة ", "266 وضعية التنفيد لهدا الإنجاز", "266 معدل الإنجاز لهدا الإنجاز", 62.0 },
                    { 286, 2024, "285 التأثير لهدا الإنجاز", 148, "285 بعد الإنجازات لبعض الأنشطة ", "285 وضعية التنفيد لهدا الإنجاز", "285 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 283, 2018, "282 التأثير لهدا الإنجاز", 148, "282 بعد الإنجازات لبعض الأنشطة ", "282 وضعية التنفيد لهدا الإنجاز", "282 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 279, 2023, "278 التأثير لهدا الإنجاز", 148, "278 بعد الإنجازات لبعض الأنشطة ", "278 وضعية التنفيد لهدا الإنجاز", "278 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 278, 2018, "277 التأثير لهدا الإنجاز", 148, "277 بعد الإنجازات لبعض الأنشطة ", "277 وضعية التنفيد لهدا الإنجاز", "277 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 265, 2023, "264 التأثير لهدا الإنجاز", 126, "264 بعد الإنجازات لبعض الأنشطة ", "264 وضعية التنفيد لهدا الإنجاز", "264 معدل الإنجاز لهدا الإنجاز", 88.0 },
                    { 240, 2023, "239 التأثير لهدا الإنجاز", 129, "239 بعد الإنجازات لبعض الأنشطة ", "239 وضعية التنفيد لهدا الإنجاز", "239 معدل الإنجاز لهدا الإنجاز", 46.0 },
                    { 254, 2026, "253 التأثير لهدا الإنجاز", 123, "253 بعد الإنجازات لبعض الأنشطة ", "253 وضعية التنفيد لهدا الإنجاز", "253 معدل الإنجاز لهدا الإنجاز", 84.0 },
                    { 289, 2029, "288 التأثير لهدا الإنجاز", 123, "288 بعد الإنجازات لبعض الأنشطة ", "288 وضعية التنفيد لهدا الإنجاز", "288 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 255, 2018, "254 التأثير لهدا الإنجاز", 111, "254 بعد الإنجازات لبعض الأنشطة ", "254 وضعية التنفيد لهدا الإنجاز", "254 معدل الإنجاز لهدا الإنجاز", 59.0 },
                    { 268, 2027, "267 التأثير لهدا الإنجاز", 111, "267 بعد الإنجازات لبعض الأنشطة ", "267 وضعية التنفيد لهدا الإنجاز", "267 معدل الإنجاز لهدا الإنجاز", 25.0 },
                    { 233, 2029, "232 التأثير لهدا الإنجاز", 115, "232 بعد الإنجازات لبعض الأنشطة ", "232 وضعية التنفيد لهدا الإنجاز", "232 معدل الإنجاز لهدا الإنجاز", 46.0 },
                    { 248, 2024, "247 التأثير لهدا الإنجاز", 118, "247 بعد الإنجازات لبعض الأنشطة ", "247 وضعية التنفيد لهدا الإنجاز", "247 معدل الإنجاز لهدا الإنجاز", 60.0 },
                    { 230, 2023, "229 التأثير لهدا الإنجاز", 143, "229 بعد الإنجازات لبعض الأنشطة ", "229 وضعية التنفيد لهدا الإنجاز", "229 معدل الإنجاز لهدا الإنجاز", 29.0 },
                    { 235, 2020, "234 التأثير لهدا الإنجاز", 107, "234 بعد الإنجازات لبعض الأنشطة ", "234 وضعية التنفيد لهدا الإنجاز", "234 معدل الإنجاز لهدا الإنجاز", 47.0 },
                    { 282, 2018, "281 التأثير لهدا الإنجاز", 107, "281 بعد الإنجازات لبعض الأنشطة ", "281 وضعية التنفيد لهدا الإنجاز", "281 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 280, 2025, "279 التأثير لهدا الإنجاز", 149, "279 بعد الإنجازات لبعض الأنشطة ", "279 وضعية التنفيد لهدا الإنجاز", "279 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 236, 2025, "235 التأثير لهدا الإنجاز", 133, "235 بعد الإنجازات لبعض الأنشطة ", "235 وضعية التنفيد لهدا الإنجاز", "235 معدل الإنجاز لهدا الإنجاز", 66.0 },
                    { 223, 2026, "222 التأثير لهدا الإنجاز", 148, "222 بعد الإنجازات لبعض الأنشطة ", "222 وضعية التنفيد لهدا الإنجاز", "222 معدل الإنجاز لهدا الإنجاز", 78.0 },
                    { 238, 2028, "237 التأثير لهدا الإنجاز", 130, "237 بعد الإنجازات لبعض الأنشطة ", "237 وضعية التنفيد لهدا الإنجاز", "237 معدل الإنجاز لهدا الإنجاز", 50.0 },
                    { 249, 2021, "248 التأثير لهدا الإنجاز", 136, "248 بعد الإنجازات لبعض الأنشطة ", "248 وضعية التنفيد لهدا الإنجاز", "248 معدل الإنجاز لهدا الإنجاز", 97.0 },
                    { 50, 2021, "49 التأثير لهدا الإنجاز", 19, "49 بعد الإنجازات لبعض الأنشطة ", "49 وضعية التنفيد لهدا الإنجاز", "49 معدل الإنجاز لهدا الإنجاز", 86.0 },
                    { 36, 2027, "35 التأثير لهدا الإنجاز", 19, "35 بعد الإنجازات لبعض الأنشطة ", "35 وضعية التنفيد لهدا الإنجاز", "35 معدل الإنجاز لهدا الإنجاز", 61.0 },
                    { 6, 2025, "5 التأثير لهدا الإنجاز", 31, "5 بعد الإنجازات لبعض الأنشطة ", "5 وضعية التنفيد لهدا الإنجاز", "5 معدل الإنجاز لهدا الإنجاز", 84.0 },
                    { 57, 2026, "56 التأثير لهدا الإنجاز", 45, "56 بعد الإنجازات لبعض الأنشطة ", "56 وضعية التنفيد لهدا الإنجاز", "56 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 28, 2027, "27 التأثير لهدا الإنجاز", 45, "27 بعد الإنجازات لبعض الأنشطة ", "27 وضعية التنفيد لهدا الإنجاز", "27 معدل الإنجاز لهدا الإنجاز", 17.0 },
                    { 21, 2022, "20 التأثير لهدا الإنجاز", 45, "20 بعد الإنجازات لبعض الأنشطة ", "20 وضعية التنفيد لهدا الإنجاز", "20 معدل الإنجاز لهدا الإنجاز", 95.0 },
                    { 14, 2022, "13 التأثير لهدا الإنجاز", 3, "13 بعد الإنجازات لبعض الأنشطة ", "13 وضعية التنفيد لهدا الإنجاز", "13 معدل الإنجاز لهدا الإنجاز", 53.0 },
                    { 17, 2020, "16 التأثير لهدا الإنجاز", 22, "16 بعد الإنجازات لبعض الأنشطة ", "16 وضعية التنفيد لهدا الإنجاز", "16 معدل الإنجاز لهدا الإنجاز", 13.0 },
                    { 65, 2018, "64 التأثير لهدا الإنجاز", 39, "64 بعد الإنجازات لبعض الأنشطة ", "64 وضعية التنفيد لهدا الإنجاز", "64 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 30, 2029, "29 التأثير لهدا الإنجاز", 39, "29 بعد الإنجازات لبعض الأنشطة ", "29 وضعية التنفيد لهدا الإنجاز", "29 معدل الإنجاز لهدا الإنجاز", 31.0 },
                    { 70, 2021, "69 التأثير لهدا الإنجاز", 27, "69 بعد الإنجازات لبعض الأنشطة ", "69 وضعية التنفيد لهدا الإنجاز", "69 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 49, 2021, "48 التأثير لهدا الإنجاز", 27, "48 بعد الإنجازات لبعض الأنشطة ", "48 وضعية التنفيد لهدا الإنجاز", "48 معدل الإنجاز لهدا الإنجاز", 24.0 },
                    { 19, 2028, "18 التأثير لهدا الإنجاز", 50, "18 بعد الإنجازات لبعض الأنشطة ", "18 وضعية التنفيد لهدا الإنجاز", "18 معدل الإنجاز لهدا الإنجاز", 93.0 },
                    { 9, 2029, "8 التأثير لهدا الإنجاز", 50, "8 بعد الإنجازات لبعض الأنشطة ", "8 وضعية التنفيد لهدا الإنجاز", "8 معدل الإنجاز لهدا الإنجاز", 84.0 },
                    { 4, 2025, "3 التأثير لهدا الإنجاز", 21, "3 بعد الإنجازات لبعض الأنشطة ", "3 وضعية التنفيد لهدا الإنجاز", "3 معدل الإنجاز لهدا الإنجاز", 28.0 },
                    { 54, 2026, "53 التأثير لهدا الإنجاز", 38, "53 بعد الإنجازات لبعض الأنشطة ", "53 وضعية التنفيد لهدا الإنجاز", "53 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 41, 2025, "40 التأثير لهدا الإنجاز", 38, "40 بعد الإنجازات لبعض الأنشطة ", "40 وضعية التنفيد لهدا الإنجاز", "40 معدل الإنجاز لهدا الإنجاز", 21.0 },
                    { 31, 2026, "30 التأثير لهدا الإنجاز", 38, "30 بعد الإنجازات لبعض الأنشطة ", "30 وضعية التنفيد لهدا الإنجاز", "30 معدل الإنجاز لهدا الإنجاز", 13.0 },
                    { 62, 2028, "61 التأثير لهدا الإنجاز", 4, "61 بعد الإنجازات لبعض الأنشطة ", "61 وضعية التنفيد لهدا الإنجاز", "61 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 27, 2024, "26 التأثير لهدا الإنجاز", 18, "26 بعد الإنجازات لبعض الأنشطة ", "26 وضعية التنفيد لهدا الإنجاز", "26 معدل الإنجاز لهدا الإنجاز", 96.0 },
                    { 32, 2029, "31 التأثير لهدا الإنجاز", 29, "31 بعد الإنجازات لبعض الأنشطة ", "31 وضعية التنفيد لهدا الإنجاز", "31 معدل الإنجاز لهدا الإنجاز", 2.0 },
                    { 3, 2021, "2 التأثير لهدا الإنجاز", 42, "2 بعد الإنجازات لبعض الأنشطة ", "2 وضعية التنفيد لهدا الإنجاز", "2 معدل الإنجاز لهدا الإنجاز", 90.0 },
                    { 16, 2029, "15 التأثير لهدا الإنجاز", 12, "15 بعد الإنجازات لبعض الأنشطة ", "15 وضعية التنفيد لهدا الإنجاز", "15 معدل الإنجاز لهدا الإنجاز", 50.0 },
                    { 60, 2021, "59 التأثير لهدا الإنجاز", 12, "59 بعد الإنجازات لبعض الأنشطة ", "59 وضعية التنفيد لهدا الإنجاز", "59 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 12, 2020, "11 التأثير لهدا الإنجاز", 34, "11 بعد الإنجازات لبعض الأنشطة ", "11 وضعية التنفيد لهدا الإنجاز", "11 معدل الإنجاز لهدا الإنجاز", 71.0 },
                    { 48, 2023, "47 التأثير لهدا الإنجاز", 31, "47 بعد الإنجازات لبعض الأنشطة ", "47 وضعية التنفيد لهدا الإنجاز", "47 معدل الإنجاز لهدا الإنجاز", 67.0 },
                    { 24, 2026, "23 التأثير لهدا الإنجاز", 34, "23 بعد الإنجازات لبعض الأنشطة ", "23 وضعية التنفيد لهدا الإنجاز", "23 معدل الإنجاز لهدا الإنجاز", 31.0 },
                    { 8, 2019, "7 التأثير لهدا الإنجاز", 26, "7 بعد الإنجازات لبعض الأنشطة ", "7 وضعية التنفيد لهدا الإنجاز", "7 معدل الإنجاز لهدا الإنجاز", 84.0 },
                    { 42, 2022, "41 التأثير لهدا الإنجاز", 10, "41 بعد الإنجازات لبعض الأنشطة ", "41 وضعية التنفيد لهدا الإنجاز", "41 معدل الإنجاز لهدا الإنجاز", 1.0 },
                    { 51, 2027, "50 التأثير لهدا الإنجاز", 10, "50 بعد الإنجازات لبعض الأنشطة ", "50 وضعية التنفيد لهدا الإنجاز", "50 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 63, 2024, "62 التأثير لهدا الإنجاز", 10, "62 بعد الإنجازات لبعض الأنشطة ", "62 وضعية التنفيد لهدا الإنجاز", "62 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 1, 2018, "0 التأثير لهدا الإنجاز", 35, "0 بعد الإنجازات لبعض الأنشطة ", "0 وضعية التنفيد لهدا الإنجاز", "0 معدل الإنجاز لهدا الإنجاز", 83.0 },
                    { 58, 2026, "57 التأثير لهدا الإنجاز", 35, "57 بعد الإنجازات لبعض الأنشطة ", "57 وضعية التنفيد لهدا الإنجاز", "57 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 46, 2028, "45 التأثير لهدا الإنجاز", 34, "45 بعد الإنجازات لبعض الأنشطة ", "45 وضعية التنفيد لهدا الإنجاز", "45 معدل الإنجاز لهدا الإنجاز", 65.0 },
                    { 53, 2028, "52 التأثير لهدا الإنجاز", 31, "52 بعد الإنجازات لبعض الأنشطة ", "52 وضعية التنفيد لهدا الإنجاز", "52 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 7, 2018, "6 التأثير لهدا الإنجاز", 13, "6 بعد الإنجازات لبعض الأنشطة ", "6 وضعية التنفيد لهدا الإنجاز", "6 معدل الإنجاز لهدا الإنجاز", 51.0 },
                    { 11, 2018, "10 التأثير لهدا الإنجاز", 13, "10 بعد الإنجازات لبعض الأنشطة ", "10 وضعية التنفيد لهدا الإنجاز", "10 معدل الإنجاز لهدا الإنجاز", 83.0 },
                    { 44, 2022, "43 التأثير لهدا الإنجاز", 40, "43 بعد الإنجازات لبعض الأنشطة ", "43 وضعية التنفيد لهدا الإنجاز", "43 معدل الإنجاز لهدا الإنجاز", 2.0 },
                    { 29, 2022, "28 التأثير لهدا الإنجاز", 41, "28 بعد الإنجازات لبعض الأنشطة ", "28 وضعية التنفيد لهدا الإنجاز", "28 معدل الإنجاز لهدا الإنجاز", 31.0 },
                    { 35, 2019, "34 التأثير لهدا الإنجاز", 41, "34 بعد الإنجازات لبعض الأنشطة ", "34 وضعية التنفيد لهدا الإنجاز", "34 معدل الإنجاز لهدا الإنجاز", 51.0 },
                    { 68, 2025, "67 التأثير لهدا الإنجاز", 41, "67 بعد الإنجازات لبعض الأنشطة ", "67 وضعية التنفيد لهدا الإنجاز", "67 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 18, 2026, "17 التأثير لهدا الإنجاز", 14, "17 بعد الإنجازات لبعض الأنشطة ", "17 وضعية التنفيد لهدا الإنجاز", "17 معدل الإنجاز لهدا الإنجاز", 2.0 },
                    { 40, 2029, "39 التأثير لهدا الإنجاز", 14, "39 بعد الإنجازات لبعض الأنشطة ", "39 وضعية التنفيد لهدا الإنجاز", "39 معدل الإنجاز لهدا الإنجاز", 67.0 },
                    { 39, 2019, "38 التأثير لهدا الإنجاز", 40, "38 بعد الإنجازات لبعض الأنشطة ", "38 وضعية التنفيد لهدا الإنجاز", "38 معدل الإنجاز لهدا الإنجاز", 64.0 },
                    { 67, 2021, "66 التأثير لهدا الإنجاز", 14, "66 بعد الإنجازات لبعض الأنشطة ", "66 وضعية التنفيد لهدا الإنجاز", "66 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 43, 2029, "42 التأثير لهدا الإنجاز", 32, "42 بعد الإنجازات لبعض الأنشطة ", "42 وضعية التنفيد لهدا الإنجاز", "42 معدل الإنجاز لهدا الإنجاز", 15.0 },
                    { 55, 2023, "54 التأثير لهدا الإنجاز", 32, "54 بعد الإنجازات لبعض الأنشطة ", "54 وضعية التنفيد لهدا الإنجاز", "54 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 66, 2025, "65 التأثير لهدا الإنجاز", 32, "65 بعد الإنجازات لبعض الأنشطة ", "65 وضعية التنفيد لهدا الإنجاز", "65 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 23, 2020, "22 التأثير لهدا الإنجاز", 7, "22 بعد الإنجازات لبعض الأنشطة ", "22 وضعية التنفيد لهدا الإنجاز", "22 معدل الإنجاز لهدا الإنجاز", 5.0 },
                    { 64, 2024, "63 التأثير لهدا الإنجاز", 7, "63 بعد الإنجازات لبعض الأنشطة ", "63 وضعية التنفيد لهدا الإنجاز", "63 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 26, 2020, "25 التأثير لهدا الإنجاز", 28, "25 بعد الإنجازات لبعض الأنشطة ", "25 وضعية التنفيد لهدا الإنجاز", "25 معدل الإنجاز لهدا الإنجاز", 45.0 },
                    { 25, 2019, "24 التأثير لهدا الإنجاز", 49, "24 بعد الإنجازات لبعض الأنشطة ", "24 وضعية التنفيد لهدا الإنجاز", "24 معدل الإنجاز لهدا الإنجاز", 64.0 },
                    { 260, 2019, "259 التأثير لهدا الإنجاز", 137, "259 بعد الإنجازات لبعض الأنشطة ", "259 وضعية التنفيد لهدا الإنجاز", "259 معدل الإنجاز لهدا الإنجاز", 75.0 },
                    { 10, 2022, "9 التأثير لهدا الإنجاز", 40, "9 بعد الإنجازات لبعض الأنشطة ", "9 وضعية التنفيد لهدا الإنجاز", "9 معدل الإنجاز لهدا الإنجاز", 3.0 },
                    { 37, 2021, "36 التأثير لهدا الإنجاز", 25, "36 بعد الإنجازات لبعض الأنشطة ", "36 وضعية التنفيد لهدا الإنجاز", "36 معدل الإنجاز لهدا الإنجاز", 68.0 },
                    { 61, 2029, "60 التأثير لهدا الإنجاز", 6, "60 بعد الإنجازات لبعض الأنشطة ", "60 وضعية التنفيد لهدا الإنجاز", "60 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 2, 2022, "1 التأثير لهدا الإنجاز", 20, "1 بعد الإنجازات لبعض الأنشطة ", "1 وضعية التنفيد لهدا الإنجاز", "1 معدل الإنجاز لهدا الإنجاز", 33.0 },
                    { 69, 2027, "68 التأثير لهدا الإنجاز", 20, "68 بعد الإنجازات لبعض الأنشطة ", "68 وضعية التنفيد لهدا الإنجاز", "68 معدل الإنجاز لهدا الإنجاز", 0.0 },
                    { 15, 2026, "14 التأثير لهدا الإنجاز", 47, "14 بعد الإنجازات لبعض الأنشطة ", "14 وضعية التنفيد لهدا الإنجاز", "14 معدل الإنجاز لهدا الإنجاز", 29.0 },
                    { 13, 2021, "12 التأثير لهدا الإنجاز", 24, "12 بعد الإنجازات لبعض الأنشطة ", "12 وضعية التنفيد لهدا الإنجاز", "12 معدل الإنجاز لهدا الإنجاز", 17.0 },
                    { 20, 2020, "19 التأثير لهدا الإنجاز", 24, "19 بعد الإنجازات لبعض الأنشطة ", "19 وضعية التنفيد لهدا الإنجاز", "19 معدل الإنجاز لهدا الإنجاز", 42.0 },
                    { 59, 2025, "58 التأثير لهدا الإنجاز", 25, "58 بعد الإنجازات لبعض الأنشطة ", "58 وضعية التنفيد لهدا الإنجاز", "58 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 45, 2028, "44 التأثير لهدا الإنجاز", 8, "44 بعد الإنجازات لبعض الأنشطة ", "44 وضعية التنفيد لهدا الإنجاز", "44 معدل الإنجاز لهدا الإنجاز", 11.0 },
                    { 47, 2018, "46 التأثير لهدا الإنجاز", 36, "46 بعد الإنجازات لبعض الأنشطة ", "46 وضعية التنفيد لهدا الإنجاز", "46 معدل الإنجاز لهدا الإنجاز", 60.0 },
                    { 22, 2018, "21 التأثير لهدا الإنجاز", 23, "21 بعد الإنجازات لبعض الأنشطة ", "21 وضعية التنفيد لهدا الإنجاز", "21 معدل الإنجاز لهدا الإنجاز", 58.0 },
                    { 34, 2023, "33 التأثير لهدا الإنجاز", 23, "33 بعد الإنجازات لبعض الأنشطة ", "33 وضعية التنفيد لهدا الإنجاز", "33 معدل الإنجاز لهدا الإنجاز", 81.0 },
                    { 38, 2023, "37 التأثير لهدا الإنجاز", 23, "37 بعد الإنجازات لبعض الأنشطة ", "37 وضعية التنفيد لهدا الإنجاز", "37 معدل الإنجاز لهدا الإنجاز", 60.0 },
                    { 52, 2029, "51 التأثير لهدا الإنجاز", 23, "51 بعد الإنجازات لبعض الأنشطة ", "51 وضعية التنفيد لهدا الإنجاز", "51 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 56, 2027, "55 التأثير لهدا الإنجاز", 23, "55 بعد الإنجازات لبعض الأنشطة ", "55 وضعية التنفيد لهدا الإنجاز", "55 معدل الإنجاز لهدا الإنجاز", 100.0 },
                    { 33, 2020, "32 التأثير لهدا الإنجاز", 36, "32 بعد الإنجازات لبعض الأنشطة ", "32 وضعية التنفيد لهدا الإنجاز", "32 معدل الإنجاز لهدا الإنجاز", 65.0 },
                    { 273, 2029, "272 التأثير لهدا الإنجاز", 137, "272 بعد الإنجازات لبعض الأنشطة ", "272 وضعية التنفيد لهدا الإنجاز", "272 معدل الإنجاز لهدا الإنجاز", 100.0 }
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
                name: "IX_OrganismeUsers_IdOrganisme",
                table: "OrganismeUsers",
                column: "IdOrganisme");

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
                name: "IX_Responsables_IdOrganisme",
                table: "Responsables",
                column: "IdOrganisme");

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
                name: "OrganismeUsers");

            migrationBuilder.DropTable(
                name: "Partenariats");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Realisations");

            migrationBuilder.DropTable(
                name: "Responsables");

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

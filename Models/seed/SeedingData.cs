using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Models;

// dotnet ef dbcontext scaffold 
// "data source=DESKTOP-3550K4L\HARMONY;database=rfid;user id=sa; password=123" 
// Microsoft.EntityFrameworkCore.SqlServer 
// -o Model 
// -c "RfidContext"

// dotnet add package Bogus
namespace seed
{
    public static class SeedingData
    {
        public static int i = 100;
        public static string lang = "fr";
        public static ModelBuilder Profils(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profil>().HasData(new Profil[]{
                new Profil {Id = 1, Label = "مدير"},
                new Profil {Id = 2, Label = "مشرف"},
                new Profil {Id = 3, Label = "لجنة الوطنية"},
                new Profil {Id = 4, Label = "لجنة التتبع"},
                new Profil {Id = 5, Label = "المخاطب الرئيسي"},
                // new Profil {Id = 5, Label = "مالك"},
            });

            return modelBuilder;
        }

         
        public static ModelBuilder Permissions(this ModelBuilder modelBuilder)
        {
            string Consultation = "Consultation";
            string Modification = "Modification";
            int id = 1;
            var route = new[] { "mesure-executif", "mesure-region", "mesure-programme"
            , "suivi", "rapport-litteraire", "rapport-qualitative", "commission", "suivi-indicateur"};

            var data = new List<Permission>() {
                new Permission {Id = id++, IdProfil = 5, Action = Consultation, RouteScreen = route[0], RouteScreenAr = route[0]},
                new Permission {Id = id++, IdProfil = 5, Action = Consultation, RouteScreen = route[1], RouteScreenAr = route[1]},
                new Permission {Id = id++, IdProfil = 5, Action = Consultation, RouteScreen = route[2], RouteScreenAr = route[2]},
                new Permission {Id = id++, IdProfil = 5, Action = Modification, RouteScreen = route[3], RouteScreenAr = route[3]},
                new Permission {Id = id++, IdProfil = 5, Action = Consultation, RouteScreen = route[4], RouteScreenAr = route[4]},
                new Permission {Id = id++, IdProfil = 5, Action = Consultation, RouteScreen = route[5], RouteScreenAr = route[5]},
                new Permission {Id = id++, IdProfil = 5, Action = Consultation, RouteScreen = route[7], RouteScreenAr = route[5]},

                new Permission {Id = id++, IdProfil = 3, Action = Modification, RouteScreen = route[6], RouteScreenAr = route[6]},
                new Permission {Id = id++, IdProfil = 4, Action = Modification, RouteScreen = route[6], RouteScreenAr = route[6]},

                // new Permission {Id = id++, IdProfil = 2, Action = Modification, RouteScreen = route[6], RouteScreenAr = route[6]},
                
            };

            foreach (var r in route)
            {
                data.Add(new Permission {Id = id++, IdProfil = 2, Action = Modification, RouteScreen = r, RouteScreenAr = r});
            }

            modelBuilder.Entity<Permission>().HasData(data);

            return modelBuilder;
        }

        public static ModelBuilder Organismes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organisme>().HasData(new Organisme[]{
                new Organisme {Id = 1, Type = 1, Label = "وزارة الدولة المكلفة بحقوق الإنسان"},
                new Organisme {Id = 2, Type = 1, Label = "وزارة العدل"},
                new Organisme {Id = 3, Type = 1, Label = "المجلس الأعلى للسلطة القضائية "},
                new Organisme {Id = 4, Type = 1, Label = "المجلس الوطني لحقوق الإنسان"},
                new Organisme {Id = 5, Type = 1, Label = "الهيئات السياسية "},
                new Organisme {Id = 6, Type = 1, Label = "جمعيات المجتمع المدني"},
                new Organisme {Id = 7, Type = 1, Label = "وزارة الداخلية"},
                new Organisme {Id = 8, Type = 1, Label = "الجمعيات الترابية"},
                new Organisme {Id = 9, Type = 1, Label = "وزارة الأسرة والتضامن والمساواة والتنمية الاجتماعية"},
                new Organisme {Id = 10, Type = 1, Label = "رئاسة الحكومة"},
                new Organisme {Id = 11, Type = 1, Label = " الوزارة المنتدبة المكلفة بالعلاقات مع البرلمان والمجتمع المدني"},
                new Organisme {Id = 12, Type = 1, Label = "وزارة التربية الوطنية والتكوين المهني والتعليم العالي والبحث العلمي"},
                new Organisme {Id = 13, Type = 1, Label = " وزارة التربية الوطنية والتكوين المهني  والتعليم العالي  والبحث العلمي قطاع التربية الوطنية"},
                new Organisme {Id = 14, Type = 1, Label = "وزارة الشباب والرياضة"},
                new Organisme {Id = 15, Type = 1, Label = "وزارة الاقتصاد والمالية"},
                new Organisme {Id = 16, Type = 1, Label = "هيئة المناصفة ومكافحة جميع أشكال التمييز"},
                new Organisme {Id = 17, Type = 1, Label = "الوزارة المنتدبة لدى رئيس الحكومة المكلفة بإصلاح الإدارة وبالوظيفة العمومية"},
                new Organisme {Id = 18, Type = 1, Label = "وزارة إعداد التراب الوطني والتعمير والإسكان وسياسة المدينة"},
                new Organisme {Id = 19, Type = 1, Label = "وزارة الثقافة والاتصال"},
                new Organisme {Id = 20, Type = 1, Label = "البرلمان"},
                new Organisme {Id = 21, Type = 1, Label = "الهيئة الوطنية للنزاهة والوقاية  من الرشوة ومحاربتها"},
                new Organisme {Id = 22, Type = 1, Label = "الوزارة المنتدبة لدى رئيس الحكومة المكلفة بالشؤون العامة والحكامة"},
                new Organisme {Id = 23, Type = 1, Label = " وزارة الصناعة والاستثمار والتجارة والاقتصاد الرقمي"},
                new Organisme {Id = 24, Type = 1, Label = "وزارة إصلاح الإدارة والوظيفة العمومية وجميع الإدارات"},
                new Organisme {Id = 25, Type = 1, Label = "الهيئة المركزية للوقاية من الرشوة"},
                new Organisme {Id = 26, Type = 1, Label = "وزارة الصحة"},
                new Organisme {Id = 27, Type = 1, Label = "الدرك الملكي"},
                new Organisme {Id = 28, Type = 1, Label = "المندوبية العامة لإدارة السجون وإعادة الإدماج"},
                new Organisme {Id = 29, Type = 1, Label = "وزارة الدولة المكلفة بحقوق الإنسان"},
                new Organisme {Id = 30, Type = 1, Label = "المجلس الوطني لحقوق الإنسان"},
                new Organisme {Id = 31, Type = 1, Label = "رئاسة النيابة العامة"},
                new Organisme {Id = 32, Type = 1, Label = "المجلس الأعلى للسلطة القضائية"},
                new Organisme {Id = 33, Type = 1, Label = "قطاع التعليم العالي"},
                new Organisme {Id = 34, Type = 1, Label = "وزارة الثقافة والاتصال قطاع الثقافة"},

                new Organisme {Id = 35, Type = 2, Label = "جهة طنجة تطوان الحسيمة"},
                new Organisme {Id = 36, Type = 2, Label = "جهة الشرق"},
                new Organisme {Id = 37, Type = 2, Label = "جهة فاس مكناس"},
                new Organisme {Id = 38, Type = 2, Label = "جهة الرباط سلا القنيطرة"},
                new Organisme {Id = 39, Type = 2, Label = "جهة بني ملال خنيفرة"},
                new Organisme {Id = 40, Type = 2, Label = "جهة الدار البيضاء سطات"},
                new Organisme {Id = 41, Type = 2, Label = "جهة مراكش آسفي"},
                new Organisme {Id = 42, Type = 2, Label = "جهة درعة تافيلالت"},
                new Organisme {Id = 43, Type = 2, Label = "جهة سوس ماسة"},
                new Organisme {Id = 44, Type = 2, Label = "جهة كلميم واد نون"},
                new Organisme {Id = 45, Type = 2, Label = "جهة العيون الساقية الحمراء"},
                new Organisme {Id = 46, Type = 2, Label = "جهة الداخلة وادي الذهب"},

                new Organisme {Id = 47, Type = 3, Label = "مؤسسة-1"},
                new Organisme {Id = 48, Type = 3, Label = "مؤسسة-2"},
                new Organisme {Id = 49, Type = 3, Label = "مؤسسة-3"},
                new Organisme {Id = 50, Type = 3, Label = "مؤسسة-4"},



                
            });

            return modelBuilder;
        }

        public static ModelBuilder Users(this ModelBuilder modelBuilder)
        {
            int id = 1;

            // var faker = new Faker<User>(SeedingData.lang)
            //     .CustomInstantiator(f => new User { Id = id++ })
            //     .RuleFor(o => o.Nom, f => f.Name.FirstName())
            //     .RuleFor(o => o.Prenom, f => f.Name.LastName())
            //     .RuleFor(o => o.Email, (f, u) => f.Internet.Email($"{u.Nom}{f.UniqueIndex}", u.Prenom))
            //     .RuleFor(o => o.Password, f => f.Internet.Password(6))
            //     .RuleFor(o => o.Adresse, f => f.Address.FullAddress())
            //     .RuleFor(o => o.Tel, f => f.Phone.PhoneNumber("(+212)6 ## ##-##-##"))
            //     .RuleFor(o => o.Fix, f => f.Phone.PhoneNumber("(+212)5 ## ##-##-##"))
            //     .RuleFor(o => o.Username, (f, u) => f.Internet.UserName(u.Nom, u.Prenom))
            //     .RuleFor(o => o.IdOrganisme, f => f.Random.Number(1, 3))
            //     .RuleFor(o => o.IdProfil, f => f.Random.Number(2, 4));
            // f.Company.CompanyName()

            // var users = faker.Generate(SeedingData.i);
            var users = new List<User>();
            users.Add(new User
            {
                Id = id++,
                Nom = "admin",
                Prenom = "panddh",
                Email = "admin@panddh.com",
                Adresse = "Temara",
                Tel = "06 ## ## ## ##",
                Fix = "05 ## ## ## ##",
                Username = "panddh",
                Password = "123",
                Actif = true,
                IdOrganisme = 1,
                IdProfil = 1
            });
            users.Add(new User
            {
                Id = id++,
                Nom = "mehdi",
                Prenom = "mehdi",
                Email = "mehdi@angular.io",
                Adresse = "Temara",
                Tel = "06 ## ## ## ##",
                Fix = "05 ## ## ## ##",
                Username = "mehdi",
                Password = "123",
                Actif = true,
                IdOrganisme = 2,
                IdProfil = 2
            });

            users.Add(new User
            {
                Id = id++,
                Nom = "ahmed",
                Prenom = "ahmed",
                Email = "ahmed@angular.io",
                Adresse = "Temara",
                Tel = "06 ## ## ## ##",
                Fix = "05 ## ## ## ##",
                Username = "ahmed",
                Password = "123",
                Actif = true,
                IdOrganisme = 3,
                IdProfil = 4
            });
            users.Add(new User
            {
                Id = id++,
                Nom = "soufiane",
                Prenom = "soufiane",
                Email = "soufiane@angular.io",
                Adresse = "Temara",
                Tel = "06 ## ## ## ##",
                Fix = "05 ## ## ## ##",
                Username = "soufiane",
                Password = "123",
                Actif = true,
                IdOrganisme = 4,
                IdProfil = 3
            });
            
            for (int i = 5; i <= 34; i++)
             {
                var u = new User
                {
                Id = id++,
                Nom = $"user-{id-1}",
                Prenom = "mohamed",
                Email = $"user-{id-1}@panddh.com",
                Adresse = "taza",
                Tel = "06 ## ## ## ##",
                Fix = "05 ## ## ## ##",
                Username = $"user-{id-1}",
                Password = "123",
                Actif = true,
                IdOrganisme = i,
                IdProfil = 5
                };

                users.Add(u);
             }


             for (int i = 35; i <= 46; i++)
             {
                var u = new User
                {
                Id = id++,
                Nom = $"user-regions-{id-1}",
                Prenom = "mohamed",
                Email = $"user-regions-{id-1}@panddh.com",
                Adresse = "taza",
                Tel = "06 ## ## ## ##",
                Fix = "05 ## ## ## ##",
                Username = $"user-regions-{id-1}",
                Password = "123",
                Actif = true,
                IdOrganisme = i,
                IdProfil = 5
                };

                users.Add(u);
             }

             for (int i = 47; i <= 50; i++)
             {
                var u = new User
                {
                Id = id++,
                Nom = $"user-societe-{id-1}",
                Prenom = "mohamed",
                Email = $"user-societe-{id-1}@panddh.com",
                Adresse = "taza",
                Tel = "06 ## ## ## ##",
                Fix = "05 ## ## ## ##",
                Username = $"user-societe-{id-1}",
                Password = "123",
                Actif = true,
                IdOrganisme = i,
                IdProfil = 5
                };

                users.Add(u);
             }

             

            modelBuilder.Entity<User>().HasData(users);

            return modelBuilder;
        }



        public static ModelBuilder Cycles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cycle>().HasData(new List<Cycle>() {
                new Cycle {Id = 1, Label = "2018 - 2021"},
                new Cycle {Id = 2, Label = "2022 - 2025"},
                new Cycle {Id = 3, Label = "2026 - 2030"},
                new Cycle {Id = 4, Label = "2030 - 2035"},
            });

            return modelBuilder;
        }

        public static ModelBuilder Natures(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nature>().HasData(new List<Nature>() {
                new Nature {Id = 1, Label = "الجانب التشريعي والمؤسساتي"},
                new Nature {Id = 2, Label = "التواصل والتحسيس"},
                new Nature {Id = 3, Label = "تقوية القدرات"},
            });

            return modelBuilder;
        }

        static List<Axe> axes = new List<Axe>();


        public static ModelBuilder Axes(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var list = new[]
            {
                "الحكامة والديمقراطية",
                "الحقوق الاقتصادية والاجتماعية والثقافية والبيئية",
                "حماية الحقوق الفئوية والنهوض بها",
                "الإطار القانوني والمؤسساتي",
             };
            var faker = new Faker<Axe>(SeedingData.lang)
                .CustomInstantiator(f => new Axe { Id = id++ })
                .RuleFor(o => o.Label, f => list[id - 2]);
            SeedingData.axes = faker.Generate(4);
            modelBuilder.Entity<Axe>().HasData(axes);

            return modelBuilder;
        }

        public static ModelBuilder Commissions(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var faker = new Faker<Commission>(SeedingData.lang)
                .CustomInstantiator(f => new Commission { Id = id++ })
                .RuleFor(o => o.Type, f => $"اللجنة رقم {id - 1}")
                .RuleFor(o => o.Pv, f => $"محضر رقم {id - 1}")
                .RuleFor(o => o.DateEvenement, f => f.Date.Past())
                ;

            modelBuilder.Entity<Commission>().HasData(faker.Generate(20));

            return modelBuilder;
        }

        public static ModelBuilder MembreCommissions(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var numberList = Enumerable.Range(1, 20).ToList();
            var faker = new Faker<MembreCommission>(SeedingData.lang)
                .CustomInstantiator(f => new MembreCommission { Id = id++ })
                .RuleFor(o => o.NomComplete, f => f.Name.FullName())
                .RuleFor(o => o.Email, f => f.Internet.Email())
                .RuleFor(o => o.IdCommission, f => numberList[id - 2])
                ;

            modelBuilder.Entity<MembreCommission>().HasData(faker.Generate(20));

            return modelBuilder;
        }

        public static ModelBuilder SousAxes(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var list = new List<SousAxe>();
            list.Add(new SousAxe { Id = 0, Label = "المشاركة السياسية ", IdAxe = 1 });
            list.Add(new SousAxe { Id = 0, Label = "المساواة والمناصفة وتكافؤ الفرص ", IdAxe = 1 });
            list.Add(new SousAxe { Id = 0, Label = " الحكامة الترابية ", IdAxe = 1 });
            list.Add(new SousAxe { Id = 0, Label = "الحكامة الإدارية والنزاهة والشفافية ومكافحة الفساد ", IdAxe = 1 });
            list.Add(new SousAxe { Id = 0, Label = "الحكامة الأمنية ", IdAxe = 1 });
            list.Add(new SousAxe { Id = 0, Label = " حريات الاجتماع والتجمع والتظاهر السلمي وتأسيس الجمعيات ", IdAxe = 1 });
            list.Add(new SousAxe { Id = 0, Label = " مكافحة الإفلات من العقاب", IdAxe = 1 });

            list.Add(new SousAxe { Id = 0, Label = " جودة المنظومة الوطنية للتربية والتكوين والبحث العلمي ", IdAxe = 2 });
            list.Add(new SousAxe { Id = 0, Label = "الحقوق الثقافية ", IdAxe = 2 });
            list.Add(new SousAxe { Id = 0, Label = " الولوج إلى الخدمات الصحية ", IdAxe = 2 });
            list.Add(new SousAxe { Id = 0, Label = " الشغل وتكريس المساواة ", IdAxe = 2 });
            list.Add(new SousAxe { Id = 0, Label = " السياسة السكنية ", IdAxe = 2 });
            list.Add(new SousAxe { Id = 0, Label = "السياسة البيئية المندمجة ", IdAxe = 2 });
            list.Add(new SousAxe { Id = 0, Label = " المقاولة وحقوق الإنسان ", IdAxe = 2 });

            list.Add(new SousAxe { Id = 0, Label = " الأبعاد المؤسساتية والتشريعية ", IdAxe = 3 });
            list.Add(new SousAxe { Id = 0, Label = " حقوق الطفل ", IdAxe = 3 });
            list.Add(new SousAxe { Id = 0, Label = "حقوق الشباب ", IdAxe = 3 });
            list.Add(new SousAxe { Id = 0, Label = " حقوق الأشخاص في وضعية إعاقة ", IdAxe = 3 });
            list.Add(new SousAxe { Id = 0, Label = " حقوق الأشخاص المسنين ", IdAxe = 3 });
            list.Add(new SousAxe { Id = 0, Label = "حقوق المهاجرين واللاجئين ", IdAxe = 3 });

            list.Add(new SousAxe { Id = 0, Label = " الحماية القانونية والقضائية لحقوق الإنسان ", IdAxe = 4 });
            list.Add(new SousAxe { Id = 0, Label = " الحماية القانونية والمؤسساتية لحقوق المرأة ", IdAxe = 4 });
            list.Add(new SousAxe { Id = 0, Label = "حريات التعبير والإعلام والصحافة والحق في المعلومة ", IdAxe = 4 });
            list.Add(new SousAxe { Id = 0, Label = "حماية التراث الثقافي ", IdAxe = 4 });
            list.Add(new SousAxe { Id = 0, Label = " حفظ الأرشيف وصيانته ", IdAxe = 4 });
            list.Add(new SousAxe { Id = 0, Label = "الحقوق والحريات والآليات المؤسساتية ", IdAxe = 4 });

            var idAxe = 0;
            var faker = new Faker<SousAxe>(SeedingData.lang)
                .CustomInstantiator(f => new SousAxe { Id = id++ })
                .RuleFor(o => o.Label, (f, o) =>
                {
                    var sa = list[id -2];
                    idAxe = sa.IdAxe;
                    return sa.Label;
                })
                .RuleFor(o => o.IdAxe, f => idAxe)
                ;
            modelBuilder.Entity<SousAxe>().HasData(faker.Generate(26));
        
            return modelBuilder;
        }

        



public static ModelBuilder Mesures(this ModelBuilder modelBuilder)
{
    Random random = new Random(); 
    modelBuilder.Entity<Mesure>().HasData(new Mesure[]{
        new Mesure {Id = 1, IdAxe = 1, IdSousAxe = 1 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,  IdResponsable= 12, IdNature = 1,   Code ="1", Nom = "التفعيل الأمثل للقوانين المنظمة للانتخابات الوطنية والمحلية لتقوية النزاهة والحكامة الرشيدة والشفافية" , ResultatsAttendu ="بيئة داعمة للنزاهة والشفافية والحكامة الانتخابية " },
        new Mesure {Id = 2, IdAxe = 1, IdSousAxe = 1 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,  IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="2", Nom = "الرفع من مستوى مشاركة النساء في المجالس التمثيلية." , ResultatsAttendu ="بيئة داعمة للرفع من مشاركة النساء" },
        new Mesure {Id = 3, IdAxe = 1, IdSousAxe = 1 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,  IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="3", Nom = "الإسراع بإحداث مرصد وطني مستقل يساهم في تحليل تطورات المشاركة السياسية والانتقال الديمقراطي." , ResultatsAttendu ="آلية مؤسساتية مساعدة على تتبع تحليل وفهم تطورات المشاركة السياسية والانتقال الديمقراطي" },
        new Mesure {Id = 4, IdAxe = 1, IdSousAxe = 1 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,  IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="4", Nom = "الإسراع بتفعيل هيئة المناصفة ومكافحة جميع أشكال التمييز. " , ResultatsAttendu ="هيئة المناصفة ومكافحة جميع أشكال التمييز مفعلة." },
        new Mesure {Id = 5, IdAxe = 1, IdSousAxe = 1 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,  IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="5", Nom = "تكريس مبدأ التشاور العمومي في إعداد السياسات العمومية وتنفيذها وتقييمها، وكذا تفعيل دور الجمعيات المهتمة بقضايا الشأن العام والمنظمات غير الحكومية في المساهمة في إعداد القرارات والمشاريع لدى المؤسسات المنتخبة والسلطات العمومية وتفعيلها وتقييمها." , ResultatsAttendu ="مقتضيات قانونية تعزز المشاركة المواطنة" },
        new Mesure {Id = 6, IdAxe = 1, IdSousAxe = 1 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,  IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="6", Nom = "  إغناء وإثراء الحوار العمومي الخاص بالمشاركة السياسية من خلال برامج تسهل وتضمن ولوج مختلف الفاعلين (أحزاب سياسية، نقابات، جمعيات...) للخدمات الإعلامية العمومية لتعزيز مساهمتهم في تأطير المواطنات والمواطنين وتطوير التعددية والحكامة السياسية." , ResultatsAttendu ="فضاء سمعي بصري داعم للمشاركة السياسية" },
        new Mesure {Id = 7, IdAxe = 1, IdSousAxe = 1 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,  IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="7", Nom = "تعزيز دور وسائل الإعلام في مجال التوعية والاتصال والحوار العمومي بشأن المشاركة السياسية." , ResultatsAttendu ="برامج داعمة للمشاركة السياسية" },
        new Mesure {Id = 8, IdAxe = 1, IdSousAxe = 1 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,  IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="8", Nom = "إطلاق برامج تواصلية لتعزيز الديمقراطية التشاركية." , ResultatsAttendu ="بيئة داعمة ومحفزة للديمقراطية التشاركية " },
        new Mesure {Id = 9, IdAxe = 1, IdSousAxe = 1 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,  IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="9", Nom = "دعم وتشجيع البرامج والأنشطة المتعلقة بالتنشئة السياسية والاجتماعية الهادفة إلى نشر قيم الديمقراطية والمساواة والتعدد والاختلاف والتسامح والعيش المشترك وعدم التمييز ونبذ الكراهية والعنف والتطرف." , ResultatsAttendu ="مجتمع داعم لقيم الديمقراطية" },
        new Mesure {Id = 10, IdAxe = 1, IdSousAxe = 1 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="10", Nom = " وضع برامج لتربية الأطفال على قيم المواطنة في الوسط التربوي ودعم برلمان الطفل وكافة أشكال تفعيل حقوق المشاركة لدى الأطفال." , ResultatsAttendu ="برامج داعمة لقيم المواطنة ومشاركة الأطفال " },
        new Mesure {Id = 11, IdAxe = 1, IdSousAxe = 1 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="11", Nom = " إحداث فضاءات لإثراء مشاركة اليافعين والشباب في الوسط التربوي والهيئات التمثيلية." , ResultatsAttendu ="برامج ومبادرات داعمة لمشاركة الشباب واليافعين" },
        new Mesure {Id = 12, IdAxe = 1, IdSousAxe = 1 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="12", Nom = " وضع برامج تدريبية وتكوينية فعالة تستهدف تطوير مهارات التواصل والرفع بمستوى الثقافة الحقوقية والسياسية في نطاق الدستور والتزامات المملكة المغربية في مجال حقوق الإنسان." , ResultatsAttendu ="" },
        new Mesure {Id = 13, IdAxe = 1, IdSousAxe = 1 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="13", Nom = " وضع برامج تكوينية على المواطنة وحقوق الإنسان وسيادة القانون لفائدة المنتخبين وموظفي الجماعات الترابية والمجتمع المدني." , ResultatsAttendu ="" },
        new Mesure {Id = 14, IdAxe = 1, IdSousAxe = 2 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="14", Nom = " تفعيل مقتضيات القانون التنظيمي لقانون المالية المتعلق بالإدماج العرضاني لمقاربة النوع في السياسات العمومية." , ResultatsAttendu ="" },
        new Mesure {Id = 15, IdAxe = 1, IdSousAxe = 2 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="15", Nom = " الإسراع بتفعيل هيئة المناصفة ومكافحة جميع أشكال التمييز كمدخل أساسي من مداخل تقوية قيم المساواة والإنصاف الموجهة للسياسات العمومية والاستراتيجيات والمخططات والبرامج الوطنية." , ResultatsAttendu ="" },
        new Mesure {Id = 16, IdAxe = 1, IdSousAxe = 2 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="16", Nom = "تفعيل مقاربة النوع في كافة المجالس المنتخبة وطنيا وجهويا ومحليا." , ResultatsAttendu ="" },
        new Mesure {Id = 17, IdAxe = 1, IdSousAxe = 2 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="17", Nom = " تجويد عمل آليات الحوار والتشاور الكفيلة بإعمال المساواة وتكافؤ الفرص على نحو أفضل في كافة دوائر اتخاذ القرار في القطاعات العمومية الوطنية والمحلية والقطاع الخاص والمنظمات غير الحكومية. " , ResultatsAttendu ="" },
        new Mesure {Id = 18, IdAxe = 1, IdSousAxe = 2 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="18", Nom = " وضع برامج فعالة للتوعية والتحسيس والتربية على قيم ومبادئ المساواة وتكافؤ الفرص والمناصفة لفائدة أطر وموظفي الإدارات والمؤسسات العمومية والجماعات الترابية." , ResultatsAttendu ="" },
        new Mesure {Id = 19, IdAxe = 1, IdSousAxe = 2 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="19", Nom = " تعزيز دور وسائل الإعلام في نشر قيم ومبادئ المساواة والمناصفة وتكافؤ الفرص ومحاربة التمييز." , ResultatsAttendu ="" },
        new Mesure {Id = 20, IdAxe = 1, IdSousAxe = 3 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="20", Nom = "-20- تسريع إصدار قانون خاص بإعداد التراب الوطني. " , ResultatsAttendu ="" },
        new Mesure {Id = 21, IdAxe = 1, IdSousAxe = 3 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="21", Nom = "-21- تنفيذ توصيات المجلس الأعلى لإعداد التراب الوطني واللجن المنبثقة عنه." , ResultatsAttendu ="" },
        new Mesure {Id = 22, IdAxe = 1, IdSousAxe = 3 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="22", Nom = " إدماج البعد الثقافي في التنظيم الجهوي على مستوى وسائل الإعلام والبرامج التربوية والتظاهرات الثقافية والفنية." , ResultatsAttendu ="" },
        new Mesure {Id = 23, IdAxe = 1, IdSousAxe = 3 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="23", Nom = " تقوية خدمات القرب وإلزامية تقييم السياسات العمومية وإحداث جهاز مؤسساتي متخصص في هذا المجال." , ResultatsAttendu ="" },
        new Mesure {Id = 24, IdAxe = 1, IdSousAxe = 3 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="24", Nom = " مواصلة دعم الجهات بمناسبة وضع التصاميم الجهوية المقترحة لإعداد التراب." , ResultatsAttendu ="" },
        new Mesure {Id = 25, IdAxe = 1, IdSousAxe = 3 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="25", Nom = "--" , ResultatsAttendu ="" },
        new Mesure {Id = 26, IdAxe = 1, IdSousAxe = 3 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="26", Nom = "الإسراع بوضع ميثاق اللاتمركز الإداري في إطار تنزيل الجهوية المتقدمة وتكريس الحكامة الترابية" , ResultatsAttendu ="" },
        new Mesure {Id = 27, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="27", Nom = " تقوية الإطار القانوني والتنظيمي لتعزيز النزاهة والشفافية من خلال ملاءمته مع الاتفاقيات الدولية لمكافحة الفساد كما صادقت عليها المملكة المغربية ليشمل ما يتعلق بالتنسيق وآليات التحري والوصول إلى المعلومات والتنفيذ الفعال والتتبع والإشراف." , ResultatsAttendu ="" },
        new Mesure {Id = 28, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="28", Nom = " الإسراع بالمصادقة على المقتضيات القانونية المؤطرة لتجريم الإثراء غير المشروع." , ResultatsAttendu ="" },
        new Mesure {Id = 29, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="29", Nom = "الإسراع بوضع ميثاق للمرافق العمومية يتضمن قواعد الحكامة الإدارية الجيدة." , ResultatsAttendu ="" },
        new Mesure {Id = 30, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="30", Nom = "الإسراع بوضع المقتضيات التنظيمية الخاصة بالتدابير المتعلقة بالوقاية من الفساد. " , ResultatsAttendu ="" },
        new Mesure {Id = 31, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="31", Nom = "  استكمال الإجراءات التشريعية المتعلقة بإصدار مشروع القانون رقم 13.31 المتعلق بالحق في الوصول إلى المعلومات." , ResultatsAttendu ="" },
        new Mesure {Id = 32, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="32", Nom = " اعتماد المقاربة التشاركية عند إعداد المقترحات المتعلقة بمجالات مكافحة الفساد. " , ResultatsAttendu ="" },
        new Mesure {Id = 33, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="33", Nom = "تفعيل مختلف أشكال الرقابة البرلمانية والإدارية والقضائية في مكافحة الفساد." , ResultatsAttendu ="" },
        new Mesure {Id = 34, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="34", Nom = " تفعيل أدوار مؤسسات الحكامة والديمقراطية التشاركية في اقتراح التدابير ذات الأثر المباشر على مكافحة الفساد ودعم عملها في كل ما يخص نشر قيم النزاهة والشفافية." , ResultatsAttendu ="" },
        new Mesure {Id = 35, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="35", Nom = " تعزيز الالتقائية بين البرامج والمبادرات الأفقية والقطاعية." , ResultatsAttendu ="" },
        new Mesure {Id = 36, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="36", Nom = "تعزيز المشاريع والإجراءات الرامية إلى مكافحة الفساد وتعزيز الحكامة الإدارية والنزاهة والشفافية." , ResultatsAttendu ="" },
        new Mesure {Id = 37, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="37", Nom = " تقوية الآليات المكلفة بتعزيز النزاهة والشفافية بالخبرة المطلوبة والدعم الفني اللازم." , ResultatsAttendu ="" },
        new Mesure {Id = 38, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="38", Nom = " تعميم الخدمات العمومية الإلكترونية في أفق الوصول إلى تحقيق الإدارة الرقمية الشاملة. " , ResultatsAttendu ="" },
        new Mesure {Id = 39, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="39", Nom = " تعزيز طرق وأشكال التبليغ عن حالات الفساد، بما في ذلك وضع خط أخضر وتيسير تقديم الشكايات." , ResultatsAttendu ="" },
        new Mesure {Id = 40, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="40", Nom = " وضع معايير مرجعية قابلة للتتبع وقياس مظاهر الفساد." , ResultatsAttendu ="" },
        new Mesure {Id = 41, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="41", Nom = " تقوية الحوار العمومي حول منجز مؤسسات الرقابة والحكامة." , ResultatsAttendu ="" },
        new Mesure {Id = 42, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="42", Nom = "وضع سياسة إعلامية وخطط تواصلية لبلوغ أهداف الاستراتيجية الوطنية لمكافحة الفساد وفق مقاربة تتأسس على سيادة القانون واحترام حقوق الإنسان." , ResultatsAttendu ="" },
        new Mesure {Id = 43, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="43", Nom = "توثيق ونشر الممارسات الفضلى في مجال مكافحة للفساد." , ResultatsAttendu ="" },
        new Mesure {Id = 44, IdAxe = 1, IdSousAxe = 4 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="44", Nom = "وضع برامج للتدريب والتكوين والتكوين المستمر لفائدة مختلف الفاعلين والمتدخلين في مجالات مكافحة الفساد وتعزيز النزاهة والشفافية وإشاعة أخلاقياتها." , ResultatsAttendu ="" },
        new Mesure {Id = 45, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="45", Nom = "مراجعة المقتضيات القانونية بما يسمح بمرافقة الدفاع للشخص المعتقل بمجرد وضعه تحت الحراسة النظرية لدى الضابطة القضائية، ومواصلة ملاءمة الإطار التشريعي المنظم للبحث التمهيدي والحراسة النظرية والتفتيش وكافة الإجراءات الضبطية وملاءمتها مع المعايير الدولية ذات الصلة." , ResultatsAttendu ="" },
        new Mesure {Id = 46, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="46", Nom = "مراجعة المقتضيات القانونية بما يضمن إلزامية إجراء الخبرة الطبية في حالة ادعاء التعرض للتعذيب واعتبار المحاضر المنجزة باطلة في حالة رفض إجراءها بعد طلبها من طرف المتهم أو دفاعه. " , ResultatsAttendu ="" },
        new Mesure {Id = 47, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="47", Nom = "الإسراع بإصدار قانون يتعلق بالتحقق من هوية الأشخاص بواسطة البصمات الجينية. " , ResultatsAttendu ="" },
        new Mesure {Id = 48, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="48", Nom = "استحضار البعد الأمني في وضع خطط التهيئة الحضرية وتصميم التجمعات السكنية الجديدة والأحياء بضواحي المدن بشكل يضمن أمن المواطنات والمواطنين." , ResultatsAttendu ="" },
        new Mesure {Id = 49, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="49", Nom = "إلزام المنظومة التعميرية والأمنية بنصب كاميرات يكون بإمكانها المساعدة على مكافحة الجريمة وحماية الأشخاص والممتلكات." , ResultatsAttendu ="" },
        new Mesure {Id = 50, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="50", Nom = "مراعاة الضرورة والتناسب أثناء استعمال القوة في فض التجمعات العمومية وفي التجمهرات والتظاهرات السلمية. " , ResultatsAttendu ="" },
        new Mesure {Id = 51, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="51", Nom = "-51-التوثيق السمعي البصري للتدخلات الأمنية لفض التجمعات العمومية." , ResultatsAttendu ="" },
        new Mesure {Id = 52, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="52", Nom = "تجهيز أماكن الحرمان من الحرية بوسائل التوثيق السمعية البصرية لتوثيق تصريحات المستجوبين من طرف الشرطة القضائية ووضعها رهن إشارة القضاء." , ResultatsAttendu ="" },
        new Mesure {Id = 53, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="53", Nom = "العمل على تأمين تغذية الأشخاص الموضوعين رهن الحراسة النظرية." , ResultatsAttendu ="" },
        new Mesure {Id = 54, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="54", Nom = "دعم المؤسسات الأمنية بالموارد البشرية والمالية والتقنية اللازمة." , ResultatsAttendu ="" },
        new Mesure {Id = 55, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="55", Nom = "تقوية أداء المؤسسة البرلمانية في مجال التقصي حول انتهاكات حقوق الإنسان مع إخضاع الأجهزة الأمنية للرقابة البرلمانية." , ResultatsAttendu ="" },
        new Mesure {Id = 56, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="56", Nom = " وضع خطط للإعلام والتواصل مع المواطنات والمواطنين ومهنيي الإعلام بخصوص الحالة الأمنية من خلال تقارير وبلاغات وندوات صحفية ومنشورات." , ResultatsAttendu ="" },
        new Mesure {Id = 57, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="57", Nom = "تبسيط وتيسير وتعميم نشر المذكرات والدوريات المتعلقة بحقوق الإنسان المعمول بها في المؤسسات الأمنية على كافة موظفيها المكلفين بتنفيذ القانون." , ResultatsAttendu ="" },
        new Mesure {Id = 58, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="58", Nom = "تقوية بنيات ووسائل وقنوات التواصل بين المؤسسات الأمنية والمواطنين (حسن الاستقبال والتوجيه وتقديم الإرشادات)." , ResultatsAttendu ="" },
        new Mesure {Id = 59, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="59", Nom = "إعداد ونشر دلائل ودعائم ديداكتيكية لتوعية وتحسيس المسؤولين وأعوان الأمن بقواعد الحكامة الجيدة على المستوى الأمني واحترام حقوق الإنسان." , ResultatsAttendu ="" },
        new Mesure {Id = 60, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="60", Nom = "تعميم تدريس مادة حقوق الإنسان وأحكام القانون الدولي الإنساني ضمن برامج التكوين الأساسي والمستمر الخاص بالموظفين المكلفين بتنفيذ القانون." , ResultatsAttendu ="" },
        new Mesure {Id = 61, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="61", Nom = " تعزيز برامج تكوين المكلفين بإنفاذ القانون في مجال استعمال القوة وتدبير فضاء الاحتجاج." , ResultatsAttendu ="" },
        new Mesure {Id = 62, IdAxe = 1, IdSousAxe = 5 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="62", Nom = " تقوية الخبرة الفنية فيما يخص عمل لجان تقصي الحقائق البرلمانية." , ResultatsAttendu ="" },
        new Mesure {Id = 63, IdAxe = 1, IdSousAxe = 6 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="63", Nom = "مواصلة ملاءمة الإطار القانوني المتعلق بحريات الاجتماع وتأسيس الجمعيات مع المعايير الدولية لحقوق الإنسان في نطاق الدستور وأحكامه." , ResultatsAttendu ="" },
        new Mesure {Id = 64, IdAxe = 1, IdSousAxe = 6 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="64", Nom = "مراجعة القوانين المنظمة للحريات العامة لضمان انسجامها مع الدستور من حيث القواعد القانونية الجوهرية والإجراءات الخاصة بفض التجمعات العمومية والتجمهر والتظاهر وذلك في إطار احترام المعايير الدولية والقواعد الديمقراطية المتعارف عليها." , ResultatsAttendu ="" },
        new Mesure {Id = 65, IdAxe = 1, IdSousAxe = 6 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="65", Nom = " تدقيق القواعد والإجراءات القانونية المتعلقة بمختلف أشكال وأصناف التظاهر (الوقفة، التجمع، التظاهر في الشارع العمومي، مسار التظاهرات...) من حيث السير والجولان والتوقيت." , ResultatsAttendu ="" },
        new Mesure {Id = 66, IdAxe = 1, IdSousAxe = 6 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="66", Nom = "تبسيط المساطر المتعلقة بالتصريح بالتجمعات العمومية من أجل تعزيز وضمان ممارسة الحريات العامة من طرف مختلف مكونات المجتمع (جمعيات، نقابات) والعمل على ضمان التطبيق السليم للمساطر المعمول بها في هذا المجال." , ResultatsAttendu ="" },
        new Mesure {Id = 67, IdAxe = 1, IdSousAxe = 6 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="67", Nom = "كفالة احترام المقتضيات القانونية المتعلقة بوصل إيداع ملفات تأسيس الجمعيات." , ResultatsAttendu ="" },
        new Mesure {Id = 68, IdAxe = 1, IdSousAxe = 6 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="68", Nom = "تعزيز الشراكة بين مؤسسات الدولة والجمعيات والرفع من مستوى حكامتها." , ResultatsAttendu ="" },
        new Mesure {Id = 69, IdAxe = 1, IdSousAxe = 6 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="69", Nom = "تيسير حريات الاجتماع والتجمهر والتظاهر السلمي من حيث تحديد الأماكن المخصصة لها والقيام بالوساطة والتفاوض." , ResultatsAttendu ="" },
        new Mesure {Id = 70, IdAxe = 1, IdSousAxe = 6 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="70", Nom = "تعزيز آليات الوساطة والتوفيق والتدخل الاستباقي المؤسساتي والمدني لتفادي حالات التوتر والحيلولة دون وقوع انتهاكات." , ResultatsAttendu ="" },
        new Mesure {Id = 71, IdAxe = 1, IdSousAxe = 7 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="71", Nom = "مواصلة تجريم كل الأفعال التي تمثل انتهاكا جسيما لحقوق الإنسان وفقا لأحكام الدستور." , ResultatsAttendu ="" },
        new Mesure {Id = 72, IdAxe = 1, IdSousAxe = 7 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="72", Nom = "تكريس مبدأ عدم الإفلات من العقاب في السياسة الجنائية وفي سائر التدابير العمومية." , ResultatsAttendu ="" },
        new Mesure {Id = 73, IdAxe = 1, IdSousAxe = 7 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="73", Nom = "تيسير التقاضي للضحايا من خلال توفير المساعدة القانونية والقضائية." , ResultatsAttendu ="" },
        new Mesure {Id = 74, IdAxe = 1, IdSousAxe = 7 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="74", Nom = "تعزيز المقتضيات القانونية المتعلقة بجبر ضرر ضحايا انتهاكات حقوق الإنسان." , ResultatsAttendu ="" },
        new Mesure {Id = 75, IdAxe = 1, IdSousAxe = 7 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="75", Nom = "حماية المشتكين والمبلغين والشهود والمدافعين عن حقوق الإنسان من أي سوء معاملة ومن أي ترهيب بسبب شكاويهم أو شهاداتهم أمام السلطات العمومية والقضائية." , ResultatsAttendu ="" },
        new Mesure {Id = 76, IdAxe = 1, IdSousAxe = 7 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="76", Nom = " وضع إطار تشريعي وتنظيمي مستقل لمأسسة الطب الشرعي." , ResultatsAttendu ="" },
        new Mesure {Id = 77, IdAxe = 1, IdSousAxe = 7 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="77", Nom = "إحالة نتائج البحث المتوصل إليها في إطار الطب الشرعي بخصوص حالات ادعاء التعذيب على النيابة العامة للتقرير فيها مالم تكن قد أمرت بها." , ResultatsAttendu ="" },
        new Mesure {Id = 78, IdAxe = 1, IdSousAxe = 7 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="78", Nom = " إحالة نتائج تحريات الآلية الوطنية للوقاية من التعذيب على القضاء." , ResultatsAttendu ="" },
        new Mesure {Id = 79, IdAxe = 1, IdSousAxe = 7 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="79", Nom = " تشجيع إمكانيات التظلم الإداري والقضائي صونا لمبدأ عدم الإفلات من العقاب وضمانا لوصول الضحايا إلى سبل الانتصاف المناسبة." , ResultatsAttendu ="" },
        new Mesure {Id = 80, IdAxe = 1, IdSousAxe = 7 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="80", Nom = "إعمال الحق في الوصول إلى المعلومة واستلامها ونشرها بما يضمن تفعيل مبدأ عدم الإفلات من العقاب" , ResultatsAttendu ="" },
        new Mesure {Id = 81, IdAxe = 1, IdSousAxe = 7 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="81", Nom = "تعزيز برامج التدريب والتكوين والتوعية بقيم حقوق الإنسان وآليات حمايتها والنهوض بها الموجهة للقضاة وللمكلفين بإنفاذ القوانين وموظفي السجون" , ResultatsAttendu ="" },
        new Mesure {Id = 82, IdAxe = 1, IdSousAxe = 8 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="82", Nom = "تفعيل الرؤية الاستراتيجية لإصلاح التعليم 2015-2030 من أجل مدرسة الجودة والارتقاء، وإصدار القانون الإطار الخاص بها" , ResultatsAttendu ="" },
        new Mesure {Id = 83, IdAxe = 1, IdSousAxe = 8 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="83", Nom = "تفعيل مقتضيات القانون رقم 00-04 المتعلق بإلزامية التعليم." , ResultatsAttendu ="" },
        new Mesure {Id = 84, IdAxe = 1, IdSousAxe = 8 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="84", Nom = " مراجعة المناهج والمقررات الدراسية وملاءمتها مع مبادئ وقيم الدستور وأحكامه والاتفاقيات الدولية ذات الصلة. " , ResultatsAttendu ="" },
        new Mesure {Id = 85, IdAxe = 1, IdSousAxe = 8 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="85", Nom = "--" , ResultatsAttendu ="" },
        new Mesure {Id = 86, IdAxe = 1, IdSousAxe = 8 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="86", Nom = "  اعتماد تدابير تحفيزية لتعميم تمدرس الفتيات في جميع المستويات التعليمية." , ResultatsAttendu ="" },
        new Mesure {Id = 87, IdAxe = 1, IdSousAxe = 8 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="87", Nom = "   إدماج المقاربة الحقوقية في جميع الأنشطة التربوية." , ResultatsAttendu ="" },
        new Mesure {Id = 88, IdAxe = 1, IdSousAxe = 8 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="88", Nom = "  بلورة سياسة لغوية تضمن العدالة اللغوية وتأخذ بعين الاعتبار حاجيات التلاميذ وتراعي الخصوصيات اللغوية والثقافية للأقاليم والجهات" , ResultatsAttendu ="" },
        new Mesure {Id = 89, IdAxe = 1, IdSousAxe = 8 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="89", Nom = "   إيجاد آليات لربط مخرجات المنظومة التربوية بالحاجيات الاقتصادية والاجتماعية والثقافية وبأهداف الخطط التنموية" , ResultatsAttendu ="" },
        new Mesure {Id = 90, IdAxe = 2, IdSousAxe = 8 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="90", Nom = "  مأسسة وتعميم الدعم المادي المقدم للمتمدرسين المعوزين والأطفال في وضعية إعاقة" , ResultatsAttendu ="" },
        new Mesure {Id = 91, IdAxe = 2, IdSousAxe = 8 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="91", Nom = "  إيجاد آليات إدارية تحفز المدرسين على المشاركة الفعالة في المشاريع المدرسية والتربوية وتسمح بتوسيع مشاركة التلاميذ فيها" , ResultatsAttendu ="" },
        new Mesure {Id = 92, IdAxe = 2, IdSousAxe = 8 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="92", Nom = "  تفعيل مجالس التدبير وتعزيز أدوارها باعتبارها أداة لتحقيق تدبير تشاركي للشأن التعليمي" , ResultatsAttendu ="" },
        new Mesure {Id = 93, IdAxe = 2, IdSousAxe = 8 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="93", Nom = "  اعتماد آلية المساعدة الاجتماعية في الوسط المدرسي" , ResultatsAttendu ="" },
        new Mesure {Id = 94, IdAxe = 2, IdSousAxe = 8 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="94", Nom = "  تيسير شروط ولوج التعليم العالي وتقوية وتثمين البحث العلمي والرفع من الميزانية المخصصة له" , ResultatsAttendu ="" },
        new Mesure {Id = 95, IdAxe = 2, IdSousAxe = 8 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="95", Nom = "  تقوية قيم التسامح والعيش المشترك واحترام حقوق الإنسان ونبذ الكراهية والعنف والتطرف في المناهج التربوية وفي الفضاء المدرسي." , ResultatsAttendu ="" },
        new Mesure {Id = 96, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="96", Nom = "  إرساء استراتيجية ثقافية وطنية" , ResultatsAttendu ="" },
        new Mesure {Id = 97, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="97", Nom = "  الإسراع بإصدار القانون التنظيمي المتعلق بإعمال الطابع الرسمي للغة الأمازيغية" , ResultatsAttendu ="" },
        new Mesure {Id = 98, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="98", Nom = "  الإسراع بإصدار القانون التنظيمي المتعلق بالمجلس الوطني للغات والثقافة المغربية" , ResultatsAttendu ="" },
        new Mesure {Id = 99, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) , IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="99", Nom = "  تنمية الأشكال والآليات والوسائل الكفيلة بالحفاظ على التنوع الثقافي وتطويره في السياسات العمومية والاستراتيجيات والمخططات والبرامج الوطنية التي تقتضي إعمال الحقوق الثقافية بما فيها الحق في المشاركة الثقافية " , ResultatsAttendu ="" },
        new Mesure {Id = 100, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="100", Nom = "تعزيز استعمال اللغة العربية في المرافق العمومية وباقي مناحي الحياة العامة" , ResultatsAttendu ="" },
        

        new Mesure {Id = 101, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="101", Nom = "تقوية مكانة اللغة العربية في البحث العلمي والتقني الجامعي والأكاديمي" , ResultatsAttendu ="برامج داعمة لتعزيز مكانة اللغة العربية في الجامعة" },
        new Mesure {Id = 102, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="102", Nom = "تعزيز مكانة اللغة والثقافة الأمازيغية في المجالات الثقافية والإدارية والقضائية وباقي مناحي الحياة العامة." , ResultatsAttendu ="ديناميات داعمة لتعزيز مكانة اللغة والثقافة الأمازيغية " },
        new Mesure {Id = 103, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="103", Nom = "الإدماج العرضاني للحقوق اللغوية والثقافية الأمازيغية في برامج التربية والتكوين وفي المحيط المدرسي والجامعي" , ResultatsAttendu ="بيئة تربوية مساعدة على إدماج الحقوق اللغوية والثقافية الأمازيغية" },
        new Mesure {Id = 104, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="104", Nom = "تعزيز مكانة الثقافة والموروث الحساني في النموذج التنموي الخاص بالأقاليم الجنوبية وضمن التطور المجتمعي الوطني" , ResultatsAttendu ="برامج معززة لمكانة الموروث الثقافي الحساني في النموذج التنموي" },
        new Mesure {Id = 105, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="105", Nom = "استثمار وحفظ الرصيد الحضاري العبري المغربي في إغناء التنوع الثقافي والتطور المجتمعي" , ResultatsAttendu ="مبادرات داعمة للتنوع الثقافي والتطور الاجتماعي " },
        new Mesure {Id = 106, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="106", Nom = "تعزيز وسائل التظلم والانتصاف المتعلقة بالتمييز في مجال الحقوق الثقافية" , ResultatsAttendu ="سائل التظلم والانتصاف المتعلقة بالتمييز في مجال الحقوق معززة جهويا ومركزيا" },
        new Mesure {Id = 107, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="107", Nom = "مواصلة تعزيز القناة التلفزية الأمازيغية وتمكينها من الموارد البشرية والكفاءات اللازمة للبث المتواصل" , ResultatsAttendu ="بث متواصل للقناة التلفزية الأمازيغية" },
        new Mesure {Id = 108, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="108", Nom = "مراجعة دفاتر تحملات شركات الاتصال السمعي البصري بما يسمح بتعزيز حصة البث بالأمازيغية" , ResultatsAttendu ="إطار تنظيمي معزز لحصة البث باللغة الأمازيغية" },
        new Mesure {Id = 109, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="109", Nom = "تشجيع إحداث محطات إذاعية تستخدم اللغات المتداولة وتلبي حاجيات المواطنين على مستوى الإعلام والتثقيف والتوعية والترفيه." , ResultatsAttendu ="محطات جهوية متفاعلة مع محيطها" },
        new Mesure {Id = 110, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="110", Nom = "تشجيع البحث الجامعي على مواصلة الجهود حول تاريخ المغرب المتعدد بعمقه الديني وبمكوناته البشرية والثقافية والمحلية" , ResultatsAttendu ="برامج داعمة للبحث الجامعي حول تاريخ المغرب المتعدد بعمقه الديني وبمكوناته البشرية والثقافية والمحلية" },
        new Mesure {Id = 111, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="111", Nom = "مواصلة تثمين الرموز الوطنية المغربية من خلال إطلاق أسمائها على المؤسسات والشوارع والساحات العمومية حفظا لها في ذاكرة الأجيال." , ResultatsAttendu ="فضاءات ومؤسسات عامة مساعدة على حفظ الذاكرة" },
        new Mesure {Id = 112, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="112", Nom = "تعزيز الشراكات بين المؤسسات الثقافية العمومية والقطاع الخاص ومنظمات الشباب والمجتمع المدني." , ResultatsAttendu ="شراكات داعمة لإبداعات الشباب " },
        new Mesure {Id = 113, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="113", Nom = "إحداث فضاءات للحوار والتشاور الدائمين بين منظمات المجتمع المدني والشباب على صعيد الجماعات الترابية فيما يخص الإنتاج الثقافي والأنشطة الداعمة للحياة الثقافية" , ResultatsAttendu ="جماعات ترابية داعمة لمبادرات الشباب والمجتمع المدني في المجال الثقافي " },
        new Mesure {Id = 114, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="114", Nom = "تشجيع مبادرات الشباب والمجتمع المدني فيما يخص التربية الثقافية والإنتاج الثقافي ودعم المشاريع المحفزة على الإبداع" , ResultatsAttendu ="مناخ داعم لمبادرات الشباب في المجال الثقافي " },
        new Mesure {Id = 115, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="115", Nom = "تعزيز القواعد المنظمة للسكن اللائق بإحداث مرافق تعزز الحياة والإبداع الثقافيين." , ResultatsAttendu ="برامج سكنية معززة للحياة الثقافية" },
        new Mesure {Id = 116, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="116", Nom = " توسيع شبكة المراكز والمركبات الثقافية لتشمل عموم المناطق الحضرية والقروية." , ResultatsAttendu ="مركبات ثقافية جهوية ومحلية مساهمة في الإشعاع الثقافي" },
        new Mesure {Id = 117, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="117", Nom = " تعميم المكتبات ومراكز التنشيط الثقافي والمسرحي والفني في المناطق التي تفتقر للبنيات التحتية الثقافية." , ResultatsAttendu ="بنيات مشجعة على الحياة الثقافية " },
        new Mesure {Id = 118, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="118", Nom = " وضع برامج تيسر مشاركة وتمتع الأشخاص المسنين وفي وضعية إعاقة بالحقوق الثقافية." , ResultatsAttendu ="بيئة داعمة لتمتع الأشخاص المسنين      وفي وضعية إعاقة بالحقوق الثقافية" },
        new Mesure {Id = 119, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="119", Nom = " إحداث متاحف موضوعاتية جهوية تبرز تراث كل منطقة وخصوصياتها الثقافية والفنية." , ResultatsAttendu ="بنيات حاضنة للتنوع الثقافي والتراثي " },
        new Mesure {Id = 120, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="120", Nom = " ترميم وصيانة المواقع الأثرية والصخرية وتأمين حراستها حفاظا على التراث الثقافي الوطني وتعزيز آليات حمايته من الإتلاف والحفاظ على الذاكرة في بعديها الوطني والمحلي." , ResultatsAttendu ="منظومة حافظة للمواقع الأثرية والصخرية " },
        new Mesure {Id = 121, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="121", Nom = " تشجيع وتثمين الدراسات البحثية في مجال التأصيل للتنوع الثقافي والحفاظ على الذاكرة والثقافة الشعبية وسائر الإبداعات المماثلة." , ResultatsAttendu ="مناخ مشجع على البحث " },
        new Mesure {Id = 122, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="122", Nom = "تشجيع إحداث محطات إعلامية جهوية" , ResultatsAttendu ="محطات جهوية متفاعلة مع محيطها" },
        new Mesure {Id = 123, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="123", Nom = "تمكين الشباب من المساهمة الفاعلة في تدبير الحياة الثقافية والتحفيز على الولوج إليها" , ResultatsAttendu ="مناخ داعم لمبادرات الشباب في المجال الثقافي " },
        new Mesure {Id = 124, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="124", Nom = "وضع ميثاق وطني في مجال التنوع الثقافي موجه إلى كافة المتدخلين والفاعلين." , ResultatsAttendu ="ميثاق وطني في مجال التنوع الثقافي معتمد" },
        new Mesure {Id = 125, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="125", Nom = "وضع برامج تواصلية للجمهور الواسع تستهدف التعريف والتحسيس بالحقوق الثقافية واللغوية ومختلف إبداعاتها" , ResultatsAttendu ="بيئة مشجعة للنهوض بالحقوق الثقافية " },
        new Mesure {Id = 126, IdAxe = 2, IdSousAxe = 9 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="126", Nom = "وضع برامج متخصصة بمساعدة المختصين في المهن الثقافية للنهوض بقدرات المنظمات غير الحكومية والجماعات الترابية وسائر المؤسسات العاملة في مجال الحقوق الثقافية" , ResultatsAttendu ="برامج داعمة لقدرات مختلف الفاعلين في مجال الحقوق الثقافية" },

        new Mesure {Id = 127, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="127", Nom = " الإسراع بالمصادقة على مشروع القانون المتعلق بمكافحة الاضطرابات العقلية وبحماية حقوق الأشخاص المصابين بها." , ResultatsAttendu ="إطار قانوني داعم لحماية الأشخاص المصابين بالاضطرابات العقلية " },
        new Mesure {Id = 128, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="128", Nom = "ضمان العدالة المجالية في الميدان الصحي من خلال خريطة صحية عادلة تغطي مكونات التراب الوطني." , ResultatsAttendu ="خريطة صحية داعمة للعدالة المجالية " },
        new Mesure {Id = 129, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="129", Nom = " دعم ولوج الفئات الأكثر هشاشة للخدمات الصحية." , ResultatsAttendu ="برامج داعمة لتعميم الخدمات الصحية." },
        new Mesure {Id = 130, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="130", Nom = " مواصلة توفير الموارد البشرية اللازمة من حيث عدد الأطر الطبية وشبه الطبية وتخصصاتها وتأمين توزيعها العادل على المجال الترابي وفق منظور يراعي حاجيات وخصوصيات كل منطقة." , ResultatsAttendu ="مواردبشريةكفيلةبتأمينالحاجياتمنالخدماتالصحية." },
        new Mesure {Id = 131, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="131", Nom = " دعم الموارد البشرية الطبية وشبه الطبية والإدارية ومواصلة تعزيز الكفاءات عن طريق التكوين والتكوين المستمر." , ResultatsAttendu ="برامج داعمة لتعزيز كفاءات القطاع الصحي   " },
        new Mesure {Id = 132, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="132", Nom = "  تأهيل أقسام المستعجلات لتعزيز الخدمات المتعلقة بالحالات الطارئة والخطيرة." , ResultatsAttendu ="برامج داعمة لتعزيز كفاءات القطاع الصحي/ أقسام المستعجلات مؤهلة لتقديم خدمات ذات جودة وتغطي الحاجيات" },
        new Mesure {Id = 133, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="133", Nom = " النهوض بصحة الأم والمواليد الجدد والعناية بطب التوليد." , ResultatsAttendu ="برامج صحية معززة لصحة الأم والطفل والمواليد الجدد" },
        new Mesure {Id = 134, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="134", Nom = " تعزيز مبدأي المساواة وعدم التمييز في التعامل مع المرضى داخل المؤسسات الاستشفائية. " , ResultatsAttendu ="بيئة صحية تكفل الولوج المتساوي للخدمات الصحية" },
        new Mesure {Id = 135, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="135", Nom = " ضمان حقوق المصابين بالأمراض المتنقلة جنسيا وحمايتهم من كل أشكال التمييز أو الإقصاء أو الوصم." , ResultatsAttendu ="برامج داعمة لحقوق المصابين بالأمراض المتنقلة جنسيا" },
        new Mesure {Id = 136, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="136", Nom = " مواصلة تحسين جودة الخدمات وتوسيع التغطية لتشمل باقي الفئات الأخرى وضمان التوزيع العادل للموارد على كافة التراب الوطني. " , ResultatsAttendu ="برامج داعمة لتعميم وتجويد الخدمات الصحية" },
        new Mesure {Id = 137, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="137", Nom = " دعم التحصيل والتحليل الممنهج والشمولي للمعطيات والمعلومات حسب النوع الاجتماعي في مجال الصحة وخصوصا ما تعلق بالأمراض المتنقلة جنسيا والعنف. " , ResultatsAttendu =" نظاممعلوماتي مندمج معد" },
        new Mesure {Id = 138, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="138", Nom = " إحداث خلايا تساعد الأطر الصحية على التواصل مع المرضى المتحدثين بالأمازيغية والحسانية." , ResultatsAttendu ="بنيات داعمة للتواصل مع المرضى المتحدثين باللغة الأمازيغية والحسانية" },
        new Mesure {Id = 139, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="139", Nom = " النهوض بالصحة النفسية والعقلية ومواصلة مأسستها وتعميم خدماتها." , ResultatsAttendu ="بنيات داعمة للنهوض بالصحةالنفسيةوالعقلية" },
        new Mesure {Id = 140, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="140", Nom = " دعم عمل الفرق الطبية المتنقلة في إطار تقريب الخدمات الصحية وتيسيرها." , ResultatsAttendu ="آليات داعمة لتقريب الخدمات الصحية وتيسيرها" },
        new Mesure {Id = 141, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="141", Nom = " دعم الخطة المتعلقة بتوفير الأدوية الأساسية الاستعجالية وتلك المتعلقة بالأمراض المزمنة." , ResultatsAttendu ="خطة داعمة لضمان تموين مستمر بالأدوية" },
        new Mesure {Id = 142, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="142", Nom = "تخليق المرفق الصحي وعقلنة طرق تدبير الأدوية والمستلزمات الطبية داخل المستشفيات." , ResultatsAttendu ="آليات مساعدة على التدبير المعقلن وداعمة لتخليق المرفق الصحي" },
        new Mesure {Id = 143, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="143", Nom = " ضمان التنسيق الفعال بين مختلف الإدارات الصحية على الصعيد الوطني وبين المستشفيات والمراكز الصحية، وإحداث آليات التتبع والمراقبة وتقييم الأداء وجودة الخدمات وفعاليتها." , ResultatsAttendu =".آليات مساعدة على التنسيق والتتبع والمراقبة " },
        new Mesure {Id = 144, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="144", Nom = " تطوير سبل التعاون والتنسيق بين القطاع العام والخاص بما يؤمن تجويد الخدمات الصحية والولوج العادل والمتكافئ إليها. " , ResultatsAttendu ="شراكات مساهمة في الارتقاء بالمنظومة الصحية" },
        new Mesure {Id = 145, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="145", Nom = " تشجيع وتحفيز طلبة الطب على التخصص في الطب الشرعي والطب النفسي والوظيفي وتوفير المناصب المالية اللازمة." , ResultatsAttendu ="تحفيزات مساعدة على تقليص الخصاص" },
        new Mesure {Id = 146, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="146", Nom = " مواصلة تعزيز الخدمات المتعلقة بمعالجة الشكايات والتظلمات والاقتراحات من طرف المرتفقين على الصعيد الجهوي، واعتماد استمارات توضع رهن إشارة المرتفقين لقياس مستوى رضاهم عن الخدمات. " , ResultatsAttendu ="منظومة داعمة لتحسين مستوى الخدمات" },
        new Mesure {Id = 147, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="147", Nom = "القيام بحملات للتوعية داخل المستشفيات والمراكز والمستوصفات الصحية (ملصقات ومنشورات وأشرطة سمعية بصرية...) من أجل توعية المواطنات والمواطنين بحقوقهم وواجباتهم باللغات المتداولة." , ResultatsAttendu ="مبادرات مساهمة في النهوض بثقافة الحق والواجب                  " },
        new Mesure {Id = 148, IdAxe = 2, IdSousAxe = 10 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="148", Nom = "تعزيز البرامج السمعية البصرية المتعلقة بالحق في الصحة" , ResultatsAttendu ="برامج سمعية بصرية داعمة للحق في الصحة" },
        new Mesure {Id = 149, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="149", Nom = " استكمال مسطرة المصادقة على اتفاقية منظمة العمل الدولية رقم 102 المتعلقة بالمعايير الدنيا للضمان الاجتماعي." , ResultatsAttendu ="المصادقة على تفاقية منظمةا لعمل الدولية رقم 102 المتعلقة بالمعاييرالدنيا للضمان الاجتماعي" },
        new Mesure {Id = 150, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="150", Nom = " النظر في المصادقة على اتفاقية منظمة العمل الدولية رقم 118 التي تهم المساواة في معاملة مواطني البلد والذين ليسوا من مواطني البلد في مجال الضمان الاجتماعي." , ResultatsAttendu ="بلورة تصور " },
        

        new Mesure {Id = 151, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="151", Nom = " مواصلة الحوار المجتمعي بشأن الانضمام إلى اتفاقية منظمة العمل الدولية رقم 87 بشأن الحرية النقابية وحماية حق التنظيم النقابي. " , ResultatsAttendu ="حوارمجتمعيواسع. " },
        new Mesure {Id = 152, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="152", Nom = "تشجيع وتقوية أدوار لجان الحوار والمصالحة الإقليمية والوطنية." , ResultatsAttendu ="اللجان الإقليمية للبحث والمصالحة مفعلة على مستوى العمالات والأقاليم." },
        new Mesure {Id = 153, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="153", Nom = " اعتماد المساواة وتكافؤ الفرص في برامج التكوين والتأهيل والإدماج في سوق الشغل." , ResultatsAttendu ="المساواة وتكافؤ الفرص فئويا ومجاليا مفعلة في برامج التكوين والتأهيل والإدماج في سوق الشغل" },
        new Mesure {Id = 154, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="154", Nom = " تعزيز دور الآليات الاستباقية للتقليص من النزاعات في مجال الشغل." , ResultatsAttendu ="قدرات جهاز تفتيش الشغل في مجال التدخل الإستباقي معززة" },
        new Mesure {Id = 155, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="155", Nom = " إعمال مبدأ الشفافية وتكافؤ الفرص في التشغيل ووضع آليات ومساطر إدارية تنظم الإعلان عن المناصب الشاغرة في جميع القطاعات وفي مرافق الإدارة العمومية ضمانا للشفافية." , ResultatsAttendu ="الشفافية   وتكافؤ الفرص في التوظيف معززة  " },
        new Mesure {Id = 156, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="156", Nom = " إعداد برامج لدعم وتنشيط المقاولات الصغرى والمتوسطة والتعاونيات ووضع شباك داخل الجماعات الترابية للتعريف بالمقاولات خصوصا النسائية منها." , ResultatsAttendu ="برامج داعمة للمقاولات الصغرى           والمتوسطة" },
        new Mesure {Id = 157, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="157", Nom = " تشجيع المشاريع المذرة للدخل." , ResultatsAttendu ="برامج داعمة للمقاولات الصغرى  والمتوسطة / أنشطة داعمة لتحسين الدخل والإدماج الاقتصادي" },
        new Mesure {Id = 158, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="158", Nom = "تعزيز الخدمات الاجتماعية الموجهة إلى العمال والأجراء." , ResultatsAttendu ="ارتفاع عدد المقاولات المحدثة للخدمات الاجتماعية " },
        new Mesure {Id = 159, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="159", Nom = " تقوية آلية التعويض عن فقدان الشغل." , ResultatsAttendu ="إطار قانوني داعم لحماية العمال      والأجراء عند فقدان الشغل" },
        new Mesure {Id = 160, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="160", Nom = " تقوية هيئة مفتشي الشغل." , ResultatsAttendu ="هيئة مفتشي الشغل معززة " },
        new Mesure {Id = 161, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="161", Nom = "وضع برامج وخطط كفيلة بتأهيل التكوين المهني وجعله يساهم بفعالية في تقليص معدلات البطالة. " , ResultatsAttendu ="برامج داعمة للنهوض بالتكوين المهني كرافعة للتشغيل" },
        new Mesure {Id = 162, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="162", Nom = "وضع برامج للتوعية والتحسيس بمقتضيات مدونة الشغل لفائدة العمال." , ResultatsAttendu ="برامج داعمةلاحترام مقتضيات مدونة الشغل" },
        new Mesure {Id = 163, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="163", Nom = "تنظيم دورات تدريبية لفائدة موظفي وأطر وزارة الشغل والأطر النقابية ومناديب المستخدمين وأرباب العمل بغية إشاعة ثقافة حقوق الإنسان في ميدان التشغيل." , ResultatsAttendu ="الرفع من قدرات أطر وزارة الشغل والإدماج المهني والأطر النقابية ومناديب المستخدمين وأرباب العمل في مجال حقوق الانسان" },
        new Mesure {Id = 164, IdAxe = 2, IdSousAxe = 11 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="164", Nom = " وضع برامج لتكوين قضاة متخصصين في قانون الشغل." , ResultatsAttendu ="برامج داعمة للتخصص القضائي في قانون الشغل" },
        new Mesure {Id = 165, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="165", Nom = "إرساء استراتيجية وطنية شمولية ومندمجة في مجال السكن." , ResultatsAttendu ="استراتيجية وطنية معتمدة داعمة للحق في السكن   " },
        new Mesure {Id = 166, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="166", Nom = " تعزيز المنظومة القانونية المتعلقة بالسكن والتعمير وملاءمتها مع متطلبات حقوق الإنسان." , ResultatsAttendu ="إطار قانوني داعم للحق في السكن" },
        new Mesure {Id = 167, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="167", Nom = "وضع مقتضيات قانونية وتنظيمية تخص المعايير الدنيا المطبقة على السكن الاجتماعي من حيث المواصفات العمرانية والمناطق الخضراء والسلامة الأمنية والولوجيات." , ResultatsAttendu ="منظومة قانونية داعمة للسكن الاجتماعي " },
        new Mesure {Id = 168, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="168", Nom = " الإسراع بإصدار مشاريع القوانين ذات الصلة بالتعمير وفق منظور يتوخى التنمية البشرية المستدامة ويراعي التنوع المجالي والخصوصيات المحلية والهوية المعمارية لمختلف الأقاليم." , ResultatsAttendu ="منظومة قانونية للتعمير داعمةللتنمية المستدامة" },
        new Mesure {Id = 169, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="169", Nom = " تفعيل القانون للحد من التجاوزات في ميدان التعمير والإسكان وزجر المخالفات وضمان سلامة البناء في الوسطين الحضري والقروي." , ResultatsAttendu ="منظومة قانونية داعمة للحد من التجاوزات في ميدان التعمير والإسكان" },
        new Mesure {Id = 170, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="170", Nom = " إسراع وتيرة إنجاز برامج القضاء على السكن غير اللائق." , ResultatsAttendu ="برامج مساهمة في القضاء على السكن غير اللائق" },

        new Mesure {Id = 171, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="171", Nom = " إسراع وتيرة إنجاز برامج القضاء على أحياء الصفيح للسعي إلى معالجة وضعيات 50 % من الأسر التي تعيش² في دور الصفيح في أفق 2021." , ResultatsAttendu ="برامج مساهمة في القضاء على أحياء الصفيح  " },
        new Mesure {Id = 172, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="172", Nom = " الإسراع باعتماد المرسوم المتعلق بتحديد النفوذ الترابي للوكالات الحضرية، طبقا للتقسيم الترابي الجديد." , ResultatsAttendu ="" },
        new Mesure {Id = 173, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="173", Nom = " التأهيل الحضري للأحياء غير القانونية لتحسين ظروف السكان القاطنين بها." , ResultatsAttendu ="برامج للتأهيل الحضري داعمة لتحسين ظروف عيش الساكنة" },
        new Mesure {Id = 174, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="174", Nom = "تنفيذ أولويات السكن الاجتماعي بمضاعفة العرض في مجال المنتوجات السكنية الملائمة لحاجيات وإمكانيات الفئات المحدودة الدخل في إطار مشروع تطوير المنتوج السكني البديل في أفق 2021." , ResultatsAttendu ="عرض سكني مستجيب لحاجيات الفئات المحدودة الدخل" },
        new Mesure {Id = 175, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="175", Nom = " حصر الاستفادة من برنامج السكن الاجتماعي في ذوي الدخل المحدود بالصرامة اللازمة" , ResultatsAttendu ="آليات داعمة لتعزيز الحكامة في تنفيذ برامج السكن الاجتماعي" },
        new Mesure {Id = 176, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="176", Nom = " مضاعفة الإمكانيات المالية لصناديق الضمان الموجهة للشرائح الاجتماعية ذات الدخل المحدود والضعيف وغير القار لتمكينها من ولوج القروض السكنية في ظروف ملائمة." , ResultatsAttendu ="آلية مالية داعمة لتمكين الشرائح الاجتماعية ذات الدخل المحدود والضعيف والقار من ولوج السكن" },
        new Mesure {Id = 177, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="177", Nom = "تفعيل القانون المتعلق بالمباني الآيلة للسقوط وتنظيم عمليات التجديد الحضري ووضع برامج متكاملة لمعالجة السكن المهدد بالانهيار لتشمل مجموع التراب الوطني." , ResultatsAttendu ="إطار مؤسساتي وتنظيمي داعم لمعالجة إشكالية السكن المهدد بالانهيار" },
        new Mesure {Id = 178, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="178", Nom = " جعل التدابير الجبائية التحفيزية لفائدة المنعشين العقاريين المنخرطين في إنجاز مشاريع السكن الاجتماعي تتلاءم وتوفير العرض السكني اللائق لمختلف فئات المجتمع." , ResultatsAttendu ="تدابير تحفيزية داعمة لتكثيف العرض السكني" },
        new Mesure {Id = 179, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="179", Nom = " تضمين دفاتر التحملات للمعايير الدنيا المطبقة على السكن الاجتماعي المحددة بصفة قانونية أو تنظيمية." , ResultatsAttendu ="" },
        new Mesure {Id = 180, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 2,   Code ="180", Nom = "وضع سياسة إعلامية تيسر التواصل الموجه في مجال تمتع الفئات الاجتماعية من الحق في السكن اللائق. " , ResultatsAttendu ="برامج إعلامية لتعزيز التواصل حول الحق في السكن اللائق" },
        new Mesure {Id = 181, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="181", Nom = " وضع برامج تدريب وتكوين في مجالات التمتع بالحق في السكن اللائق والمصاحبة الاجتماعية الموجهة للفئات ذات الدخل المحدود وغير القار." , ResultatsAttendu ="برامج داعمة للتحسيس بالحق في السكن" },
        new Mesure {Id = 182, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="182", Nom = "إعداد مواد مرجعية بيداغوجية حول ثقافة حقوق الإنسان وقيمتها الدستورية موجهة لطلبة الدراسات العليا في مجال الهندسة المعمارية." , ResultatsAttendu ="آليات داعمة لإدماج ثقافة حقوق الإنسان في منهاج التكوين" },
        new Mesure {Id = 183, IdAxe = 2, IdSousAxe = 12 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="183", Nom = " وضع برامج تدريب وتكوين المنشطين في ميدان المصاحبة الاجتماعية للمشاريع السكنية. " , ResultatsAttendu ="موارد بشرية مؤهلة، داعمة للمصاحبة الاجتماعية  " },
        new Mesure {Id = 184, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="184", Nom = " ملاءمة الإطار القانوني الوطني مع الاتفاقيات الدولية المتعلقة بحماية البيئة والتنمية المستدامة." , ResultatsAttendu ="إطار قانوني وطنيمتلائم" },
        new Mesure {Id = 185, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="185", Nom = " مراجعة النصوص التشريعية والتنظيمية مع المعايير ذات الصلة بالجودة البيئية الجاري بها العمل لاسيما التشريع المتعلق بالماء والطاقات المتجددة والتنوع البيولوجي ومحاربة تلوث الهواء والتغييرات المناخية وتدبير وتثمين النفايات والتقييم البيئي واستصلاح البيئة ووضع تدابير لردع وزجر المخالفات البيئية. " , ResultatsAttendu ="إطار قانوني متلائم" },
        new Mesure {Id = 186, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="186", Nom = " الإسراع بإصدار القانون المتعلق بالحصول على الموارد الجينية والتقاسم العادل والمنصف للمنافع الناشئة عن استخدامها إعمالا للاتفاقية المتعلقة بالتنوع البيولوجي وبروتوكول ناغويا." , ResultatsAttendu ="إطار قانوني معتمد وفق المعايير الدولية ذات الصلة " },
        new Mesure {Id = 187, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="187", Nom = " الإسراع بإصدار المرسوم المتعلق بإحداث نظام وطني لجرد الغازات الدفيئة تطبيقا لمقتضيات الاتفاقية الإطارية للأمم المتحدة المتعلق بتغير المناخ." , ResultatsAttendu ="" },
        new Mesure {Id = 188, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="188", Nom = "مراجعة اختصاصات وتنظيم المجلس الوطني للبيئة بهدف وضع الهياكل والمؤسسات والآليات والمساطر اللازمة للحكامة البيئية الجيدة وتحقيق التنمية المستدامة طبقا لمبادئ وأهداف القانون الإطار بمثابة ميثاق وطني للبيئة والتنمية المستدامة. " , ResultatsAttendu ="التأطير القانوني للمجالات البيئية معزز" },
        new Mesure {Id = 189, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="189", Nom = " تغطية المجالات البيئية غير المشمولة بالتشريع البيئي والتنمية المستدامة بغية استكمال التأطير القانوني لمختلف هذه المجالات. " , ResultatsAttendu ="إطار تشريعي معزز" },
        new Mesure {Id = 190, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="190", Nom = " النظر في تجميع القوانين القطاعية ذات الصلة بالبيئة في إطار مدونة واضحة ومحينة لأجل تعزيز الانسجام بينها وتسهيل الولوج إلى مضامينها من طرف الهيئات التي تسهر على تطبيقها ومن طرف المواطنات والمواطنين." , ResultatsAttendu ="مصنفات مساهمة في الولوج إلى القوانين ذات الصلة بالبيئة " },
        new Mesure {Id = 191, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="191", Nom = " دعم الصندوق الوطني للبيئة والتنمية المستدامة." , ResultatsAttendu ="آلية مساهمة في دعم المشاريع البيئية" },
        new Mesure {Id = 192, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="192", Nom = " تخصيص تحفيزات مالية وتقنية لدعم المشاريع في مجال البيئة والتنمية المستدامة." , ResultatsAttendu ="موارد مالية مساهمة في دعم المشاريع الصديقة للبيئة " },
        new Mesure {Id = 193, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="193", Nom = " تعزيز الجهود الرامية إلى تحسين التقييم الاستراتيجي البيئي." , ResultatsAttendu ="إطار مرجعي وطني للتقييم الاستراتيجي البيئي معزز" },
        new Mesure {Id = 194, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="194", Nom = " إعداد مخطط وطني في مجال مكافحة التغيرات المناخية ووضع سياسة وطنية لمكافحة الاحتباس الحراري وتعبئة جميع الفاعلين في مجال مكافحة تغير المناخ." , ResultatsAttendu ="مبادرات داعمة لمكافحة التغيرات المناخية " },
        new Mesure {Id = 195, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="195", Nom = "تأمين مشاركة ومساهمة مختلف الفاعلين وخاصة منظمات المجتمع المدني والهيئات السياسية والنقابية والإعلامية في النهوض بالثقافة البيئية ومختلف البرامج البيئية." , ResultatsAttendu ="برامج داعمة للنهوض بالثقافة البيئية" },
        new Mesure {Id = 196, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="196", Nom = " تفعيل سياسة القرب في مجال تدبير البيئة وتسريع وتيرة تنفيذها." , ResultatsAttendu ="إطار مؤسساتي داعم لسياسة القرب" },
        new Mesure {Id = 197, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="197", Nom = "تطوير تدبير المجال الغابوي بالشكل الذي يوفر حماية شاملة للمحميات ولحقوق السكان ونشاطهم الزراعي والفلاحي." , ResultatsAttendu ="ديناميات معززة للحماية القانونية للمجال الغابوي  وداعمة لتنمية مستدامة" },
        new Mesure {Id = 198, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="198", Nom = " تقنين الزراعات المستهلكة للمياه خاصة بالمناطق الهشة." , ResultatsAttendu ="برامج داعمةلتكريس تدبير يحافظ على الموارد المائية المحدودة ويضمن استدامتها" },
        new Mesure {Id = 199, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="199", Nom = " تيسير الولوج إلى المعلومة البيئية وتأمين مشاركة المواطنات والمواطنين في إعداد المشاريع والبرامج ذات الصلة بالبيئة والمشاركة في اتخاذ القرار." , ResultatsAttendu ="إطار مؤسساتي ضامن للحق في المعلومة ومؤمن للمشاركة" },
        new Mesure {Id = 200, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="200", Nom = " دعم البرنامج الوطني لتدبير وتثمين النفايات." , ResultatsAttendu ="البرنامج الوطني لتدبير وتثمين النفاياتمدعم" },



        new Mesure {Id = 201, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="201", Nom = "  الإسراع بتنفيذ المخطط الوطني لتطهير السائل لا سيما بالعالم القروي." , ResultatsAttendu ="مخطط وطني منجز" },
        new Mesure {Id = 202, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="202", Nom = " تعزيز آليات التنسيق بين القطاعات المعنية بالبيئة والتنمية المستدامة." , ResultatsAttendu ="آليات مؤسساتية داعمة لتنسيق تنفيذ برامج التنمية المستدامة" },
        new Mesure {Id = 203, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="203", Nom = " تيسير ولوج المواطنات المواطنين إلى القضاء عند التعرض للأضرار البيئية لأجل تحقيق عدالة بيئية." , ResultatsAttendu ="معرفة مساعدة على تيسير الحق في العدالة البيئية  " },
        new Mesure {Id = 204, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="204", Nom = " تشجيع التدريس والبحث العلمي في الجامعة ومعاهد التكوين ومراكز البحث العلمي حول البيئة والتنمية المستدامة." , ResultatsAttendu ="مبادرات داعمة للتدريس والبحث العلمي في مجال البيئة" },
        new Mesure {Id = 205, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="205", Nom = " إعمال مضامين الميثاق الوطني للإعلام والبيئة والتنمية المستدامة." , ResultatsAttendu ="الميثاق الوطني للإعلام والبيئة والتنمية المستدامة مفعل" },
        new Mesure {Id = 206, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="206", Nom = "تنظيم حملات تحسيسية بمتطلبات ترشيد وعقلنة تدبير الموارد الطبيعية وحماية البيئة عبر وسائل الإعلام المكتوبة والمسموعة والمرئية والإلكترونية." , ResultatsAttendu ="برامج إعلامية داعمة لحماية البيئة  " },
        new Mesure {Id = 207, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="207", Nom = " إدماج البعد البيئي في البرامج والمقررات الدراسية وفي الأنشطة التربوية بالوسط المدرسي." , ResultatsAttendu ="مناهج ومقرراتدراسية معززة للتربية البيئية" },
        new Mesure {Id = 208, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="208", Nom = " النهوض بثقافة حماية البيئة عبر التربية والتكوين والتكوين المستمر والتحسيس." , ResultatsAttendu ="برامج داعمة للنهوض بالثقافة البيئية " },
        new Mesure {Id = 209, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="209", Nom = " تعزيز برامج دعم القدرات في مجال البيئة والتنمية المستدامة." , ResultatsAttendu ="برامج مساعدة على رفع القدرات في مجال البيئة والتنمية المستدامة" },
        new Mesure {Id = 210, IdAxe = 2, IdSousAxe = 13 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="210", Nom = " تكوين القضاة والشرطة القضائية والبيئية في مجال الحقوق البيئية." , ResultatsAttendu ="قدرات متطورة في مجال التكوين القضائي التخصصي   " },
        new Mesure {Id = 211, IdAxe = 2, IdSousAxe = 14 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="211", Nom = " إعداد واعتماد خطة عمل وطنية في مجال المقاولة وحقوق الإنسان بإشراك كافة الفاعلين المعنيين (قطاعات حكومية والبرلمان والقطاع الخاص والنقابات وهيئات الحكامة والديمقراطية التشاركية وحقوق الإنسان ومنظمات المجتمع المدني...)." , ResultatsAttendu ="خطة معتمدة في مجال المقاولة وحقوق الإنسان " },
        new Mesure {Id = 212, IdAxe = 2, IdSousAxe = 14 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="212", Nom = "-212- تحفيز المقاولات على وضع ميثاق داخلي عام للسلوك في مجال حقوق الإنسان." , ResultatsAttendu ="بيئة داعمة للنهوض بحقوق الإنسان داخل المقاولة " },
        new Mesure {Id = 213, IdAxe = 2, IdSousAxe = 14 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="213", Nom = "إدماج بعد احترام حقوق الإنسان في المقاولة على مستوى القانون والممارسة والنهوض بأدوار المقاولة المتعلقة بحقوق الانسان وقيم المواطنة." , ResultatsAttendu ="بيئة داعمة للنهوض بحقوق الإنسان داخل المقاولة" },
        new Mesure {Id = 214, IdAxe = 2, IdSousAxe = 14 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="214", Nom = " النهوض بدور المقاولة في مجال تقييم أثر أنشطتها على حقوق الانسان." , ResultatsAttendu ="آليات داعمة للنهوض بحقوق الإنسان داخل المقاولة" },
        new Mesure {Id = 215, IdAxe = 2, IdSousAxe = 14 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="215", Nom = " تعزيز المشاركة الوطنية في اللقاءات الدولية والجهوية المتعلقة بالمقاولة وحقوق الإنسان." , ResultatsAttendu ="دينامية داعمة لترصيد وتملك وتبادل الخبرات والممارسات الفضلى في مجال المقاولة وحقوق الإنسان " },
        new Mesure {Id = 216, IdAxe = 2, IdSousAxe = 14 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="216", Nom = " تعزيز الوعي بموضوع المقاولة وحقوق الإنسان من خلال تنظيم لقاءات وطنية وجهوية بمشاركة الأطراف المعنية. " , ResultatsAttendu ="برامج داعمة للنهوض بمجال المقاولة وحقوق الإنسان " },
        new Mesure {Id = 217, IdAxe = 2, IdSousAxe = 14 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="217", Nom = " تشجيع تبادل التجارب والممارسات الفضلى بين المقاولات في مجال احترام حقوق الإنسان في المقاولة." , ResultatsAttendu ="مبادرات داعمة لترسيخ الممارسات الفضلى في مجال المقاولة وحقوق الإنسان " },
        new Mesure {Id = 218, IdAxe = 2, IdSousAxe = 14 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="218", Nom = "وضع برامج تكوينية في مجال حقوق الإنسان في المقاولة لفائدة كل المتدخلين وأصحاب المصلحة (مسؤولو المقاولة والأطر النقابية والفاعلون المدنيون والقضاة والمحامون ومفتشو الشغل)." , ResultatsAttendu ="برامج تكوينية مساعدة على الرفع من مستوى الوعي بحقوق الإنسان في المقاولة" },
        new Mesure {Id = 219, IdAxe = 2, IdSousAxe = 14 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="219", Nom = "تشجيع التدريس والبحث العلمي في الجامعة ومعاهد التكوين ومراكز البحث العلمي حول المقاولة وحقوق الإنسان" , ResultatsAttendu ="برامج داعمة للتدريس والبحث الجامعي حول المقاولة وحقوق الإنسان" },
        new Mesure {Id = 220, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="220", Nom = " إصدار القانون المتعلق بشروط فتح وإحداث وتدبير مؤسسات الرعاية الاجتماعية." , ResultatsAttendu ="" },
        new Mesure {Id = 221, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="221", Nom = " تكثيف البرامج التي تستهدف الفئات الهشة خاصة في وضعية التشرد، وضمان خدمات المواكبة والاستماع والتكفل والادماج الاقتصادي والاجتماعي والأسري." , ResultatsAttendu ="برامج داعمة للفئات الهشة" },
        new Mesure {Id = 222, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="222", Nom = " دعم الآليات والتدابير الكفيلة ببلورة وتيسير تتبع وتقييم السياسات العمومية والبرامج التي تستهدف الحماية والنهوض بالحقوق الفئوية." , ResultatsAttendu ="آليات كفيلة بتطوير نجاعة البرامج الخاصة بالحقوق الفئوية " },
        new Mesure {Id = 223, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="223", Nom = "مواصلة إدماج ثقافة حقوق الإنسان ذات الصلة بالحقوق الفئوية في برامج المعهد العالي للقضاء والمهن القضائية." , ResultatsAttendu ="قدرات متطورة في مجال التكوين القضائي التخصصي   " },
        new Mesure {Id = 224, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="224", Nom = "إدماج ثقافة حقوق الإنسان ذات الصلة في مؤسسات التكوين الأساسي والمستمر للعاملين في مجال حماية الحقوق الفئوية." , ResultatsAttendu ="إطار مرجعي وبرامج داعمة لإدماج ثقافة حقوق الإنسان في التكوين الأساسي والمستمر  " },
        new Mesure {Id = 225, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="225", Nom = "إدماج العمل التطوعي الاجتماعي في الوسطين التربوي والجامعي." , ResultatsAttendu ="دينامية داعمة لترسيخ العمل التطوعي في الوسطين التربوي والجامعي" },
        new Mesure {Id = 226, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="226", Nom = " اعتماد معايير الجودة في التدبير وفي خدمات التكفل بمؤسسات الرعاية الاجتماعية من أجل ضمان الحقوق الفئوية. " , ResultatsAttendu ="مؤسسات للرعاية الاجتماعية معتمدة لمعايير الجودة في التدبير وخدمات التكفل" },
        new Mesure {Id = 227, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="227", Nom = "تجميع ونشر القوانين والتشريعات المتعلقة بالفئات المعنية والتعريف بمقتضياتها." , ResultatsAttendu ="مصنفات منجزة" },
        new Mesure {Id = 228, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="228", Nom = " وضع أنظمة معلوماتية لتتبع الحقوق الفئوية." , ResultatsAttendu ="أنظمة معلوماتية مساعدة على تتبع الحقوق الفئوية" },
        new Mesure {Id = 229, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="229", Nom = " وضع الجماعات الترابية لبرامج في مجال الحقوق الفئوية." , ResultatsAttendu ="برامج داعمة للنهوض بالحقوق الفئوية" },
        new Mesure {Id = 230, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="230", Nom = "الرفع من الاعتمادات المخصصة للنهوض بالحقوق الفئوية في الميزانية العامة." , ResultatsAttendu ="اعتمادات مالية مساهمة في النهوض بالحقوق الفئوية" },
        new Mesure {Id = 231, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="231", Nom = " اعتماد الحكامة الجيدة في تتبع تنفيذ البرامج والاستراتيجيات الخاصة بالفئات في وضعية هشاشة. " , ResultatsAttendu ="آليات داعمة لضمان الحكامة الجيدة في تتبع البرامج الخاصة بالفئات في وضعية هشاشة" },
        new Mesure {Id = 232, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="232", Nom = "مراجعة الإطار القانوني المتعلق بالإحسان العمومي.           " , ResultatsAttendu ="إطار قانوني داعم لتجويد مبادرات الإحسان العمومي" },
        new Mesure {Id = 233, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="233", Nom = "تشجيع ودعم المبادرات التحسيسية الهادفة إلى حماية الفئات الاجتماعية في وضعية هشاشة" , ResultatsAttendu ="برامج داعمة لحماية الفئات الاجتماعية في وضعية هشاشة " },
        new Mesure {Id = 234, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="234", Nom = " تعزيز قدرات مختلف الفاعلين المعنيين، حكوميين وغير حكوميين، في مجال الحقوق الفئوية." , ResultatsAttendu ="برامج للتكوين والتكوين المستمر داعمة لتعزيز القدرات في مجال الحقوق الفئوية" },
        new Mesure {Id = 235, IdAxe = 3, IdSousAxe = 15 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="235", Nom = " تأهيل وتعزيز قدرات جمعية الهلال الأحمر المغربي والجمعيات الوطنية الأخرى المعنية بالفئات الاجتماعية في وضعية هشاشة." , ResultatsAttendu ="برنامج داعم لقدرات جمعيات المجتمع المدني" },
        new Mesure {Id = 236, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="236", Nom = " تفعيل المجلس الاستشاري للأسرة والطفولة وإصدار النصوص التشريعية والتنظيمية المتعلقة به." , ResultatsAttendu ="المجلس الاستشاري للأسرة والطفولة مفعل" },
        new Mesure {Id = 237, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="237", Nom = " الإسراع بإحداث وتفعيل الآلية الوطنية للتظلم الخاصة بالأطفال ضحايا انتهاكات حقوق الطفل." , ResultatsAttendu ="الآلية الوطنية للتظلم الخاصة بالأطفال ضحايا انتهاكات حقوق الطفل مفعلة" },
        new Mesure {Id = 238, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="238", Nom = " مواصلة تقوية الإطار القانوني المتعلق بحماية الأطفال وضمان فعاليته." , ResultatsAttendu ="إطار قانوني داعم لحماية حقوق  الأطفال" },
        new Mesure {Id = 239, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="239", Nom = " الإسراع بالمصادقة على مشروع قانون متعلق بمراكز حماية الطفولة." , ResultatsAttendu ="إطار قانوني مساعد على تجويد خدمات مراكز حماية الطفولة " },
        new Mesure {Id = 240, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="240", Nom = " مراجعة قانون الكفالة بما يتلاءم ومقتضيات الدستور." , ResultatsAttendu ="إطار تشريعي   وتنظيمي معتمد" },
        new Mesure {Id = 241, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="241", Nom = " الإسراع بإصدار القانون المتعلق بشروط فتح وتدبير مؤسسات الرعاية الاجتماعية والنصوص القانونية والتنظيمية ذات الصلة." , ResultatsAttendu =" إطار قانوني داعم تجويد خدمات مؤسسات الرعاية الاجتماعية" },
        new Mesure {Id = 242, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="242", Nom = " تفعيل المقتضيات القانونية ذات الصلة بالأطفال في المرحلة الانتقالية في القانون المتعلق بتشغيل العمال المنزليين." , ResultatsAttendu ="مناخ داعم لاحترام القانون المتعلق بتشغيل العاملات والعمال المنزليين " },
        new Mesure {Id = 243, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="243", Nom = " مواصلة الحوار المجتمعي حول مراجعة المادة 20 من مدونة الأسرة المتعلقة بالإذن بزواج القاصر." , ResultatsAttendu ="حوار مجتمعي منظم" },
        new Mesure {Id = 244, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="244", Nom = " تطوير وتفعيل المقتضيات القانونية الخاصة بتجريم الاستغلال الجنسي للأطفال والاتجار بهم مع تشديد العقوبات على الجناة." , ResultatsAttendu ="إطار قانوني داعم    لحماية حقوق الطفل " },
        new Mesure {Id = 245, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="245", Nom = " وضع مؤشرات التتبع والتقييم في مجال حماية الأطفال من سوء المعاملة ومن كل أشكال الاستغلال والعنف." , ResultatsAttendu =" منظومة المؤشرات الخاصة بتتبع وضعية حماية الأطفال وتقييمها معتمدة ومفعلة" },
        new Mesure {Id = 246, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="246", Nom = "تبسيط المساطر المتعلقة بتسجيل الأطفال في سجلات الحالة المدنية. " , ResultatsAttendu ="إطار قانوني داعم لتعزيز حق الطفل في الهوية " },
        new Mesure {Id = 247, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="247", Nom = "نقل جميع الاختصاصات المخولة للجنة العليا للحالة المدنية في موضوع الأسماء العائلية إلى القضاء." , ResultatsAttendu ="آليات وسبل إعمال الحق في الهوية معززة " },
        new Mesure {Id = 248, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="248", Nom = " تفعيل منشور رئيس الحكومة حول الحملة الوطنية لتسجيل الأطفال غير المسجلين في الحالة المدنية بشكل دوري ومستمر." , ResultatsAttendu ="آليات داعمة لحماية الأطفال في هويتهم المدنية وحقوقهم الأساسية " },
        new Mesure {Id = 249, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="249", Nom = " تعزيز وتقوية المساعدة الاجتماعية والقانونية للأطفال ضحايا الاعتداء والعنف والاستغلال أو في تماس مع القانون." , ResultatsAttendu ="المساعدة الاجتماعية والقانونية للأطفال ضحايا العنف والاستغلال معززة وشاملة" },
        new Mesure {Id = 250, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="250", Nom = " تعزيز حقوق الأطفال في المشاركة في إعداد وتتبع تفعيل السياسات والبرامج والمشاريع الوطنية." , ResultatsAttendu ="بيئة مشجعة على مشاركة الأطفال" },
        

        new Mesure {Id = 251, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="251", Nom = " مواصلة ودعم الجهود الرامية إلى الحد من تزويج القاصرات. " , ResultatsAttendu ="بيئة مساعدة على الحد من تزويج القاصرات " },
        new Mesure {Id = 252, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="252", Nom = "إيلاء أهمية قصوى للبرامج الاجتماعية المساهمة في النهوض بوضعية الفتاة وخاصة في مجالات التعليم والتكوين والوصول إلى الموارد." , ResultatsAttendu ="برامج داعمة للنهوض بوضعية الفتاة" },
        new Mesure {Id = 253, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="253", Nom = " العمل على ضمان المساواة بين الرجل والمرأة في التمتع بالجنسية المغربية إعمالا للمصلحة الفضلى للطفل." , ResultatsAttendu ="إطار قانوني ضامن للمصلحة الفضلى للأطفال والأسرة" },
        new Mesure {Id = 254, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="254", Nom = " حماية حقوق الأطفال في وسائل الإعلام بما في ذلك وسائل الاتصال الحديثة والنهوض بالتربية عليها." , ResultatsAttendu ="بيئة إعلامية داعمة لحقوق الطفل " },
        new Mesure {Id = 255, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="255", Nom = " تعزيز الولوج الآمن للأطفال إلى وسائل الإعلام والاتصال المعتمدة على التكنولوجية الحديثة عبر وضع برامج خاصة وحمايتهم من كافة أشكال الاستغلال." , ResultatsAttendu ="بيئة داعمة لولوج الأطفال الآمن   لوسائل الإعلام والاتصال المعتمدة على التكنولوجيا الحديثة" },
        new Mesure {Id = 256, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="256", Nom = " تفعيل دورية وزارة الداخلية المتعلقة باختيار الأسماء الشخصية. " , ResultatsAttendu ="آليات ميسرة لإعمال الدورية" },
        new Mesure {Id = 257, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="257", Nom = "مواصلة الجهود الرامية إلى الحد من ظاهرة تشغيل الأطفال." , ResultatsAttendu ="الجهود الرامية إلى الحد من ظاهرة تشغيل الأطفال متواصلة ومعززة" },
        new Mesure {Id = 258, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="258", Nom = " تشجيع ودعم الأسر التي يوجد أطفالها في وضعية صعبة لتفادي الرعاية المؤسساتية." , ResultatsAttendu ="تراجع ظاهرة إيداع الأطفال بمؤسسات الرعاية الاجتماعية" },
        new Mesure {Id = 259, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="259", Nom = " اعتماد معايير الجودة في خدمات التكفل بمؤسسات الرعاية الاجتماعية للأطفال." , ResultatsAttendu ="توفر مؤسسات الرعاية الاجتماعية على خدمات ذات جودة" },
        new Mesure {Id = 260, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="260", Nom = "وضع تصنيفات ودفاتر تحملات خاصة بأصناف مؤسسات الرعاية الاجتماعية المستقبلة للأطفال في حاجة للحماية." , ResultatsAttendu ="مؤسسات الرعاية الاجتماعية المستقبلة للأطفال مصنفة" },
        new Mesure {Id = 261, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="261", Nom = " تنظيم وتتبع أوضاع كفالة الأطفال خارج المغرب." , ResultatsAttendu ="آليات مساعدة على تتبع أوضاع كفالة الأطفال خارج المغرب  " },
        new Mesure {Id = 262, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="262", Nom = " الرفع من مستوى آليات تتبع أوضاع الأطفال المتكفل بهم." , ResultatsAttendu ="آليات داعمة لحماية حقوق الأطفال في وضعية كفالة " },
        new Mesure {Id = 263, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="263", Nom = " تفعيل البرنامج التنفيذي للسياسة العمومية المندمجة لحماية الطفولة بالمغرب محليا وجهويا." , ResultatsAttendu ="تدابير البرنامج الوطني للسياسة العمومية المندمجة لحماية الطفولة منفذة جهويا ومحليا" },
        new Mesure {Id = 264, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="264", Nom = " دعم عمل اللجنة بين الوزارية المكلفة بتتبع السياسات والبرامج في مجال النهوض بحقوق الطفل وحمايتها." , ResultatsAttendu ="آلية مؤسساتية داعمة لتنفيذ السياسات والبرامج في مجال النهوض بحقوق الطفل وحمايتها " },
        new Mesure {Id = 265, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="265", Nom = "اتخاذ تدابير خاصة بحماية الأطفال المهاجرين غير المرافقين وبولوجهم إلى الخدمات الأساسية لا سيما تلك المتعلقة بالصحة والتربية والتعليم." , ResultatsAttendu ="برامج داعمة لحماية الأطفال المهاجرين غير المرافقين " },
        new Mesure {Id = 266, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="266", Nom = " اتخاذ تدابير خاصة بحماية الأطفال المتخلى عنهم والعناية ببنيات استقبالهم وتبسيط مسطرة التكفل بهم." , ResultatsAttendu ="بنيات مؤسساتية كفيلة بحماية الأطفال المتخلى عنهم" },
        new Mesure {Id = 267, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="267", Nom = " العمل على تطوير شراكات مع دول الاستقبال لحماية الأطفال المغاربة من الاستغلال إعمالا لمصلحتهم الفضلى." , ResultatsAttendu ="الشراكات مع دول الاستقبال لحماية الأطفال المغاربة من الاستغلال مطورة" },
        new Mesure {Id = 268, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="268", Nom = "وضع آليات ترابية مندمجة لحماية الطفولة تضمن التنسيق واليقظة من حيث الإشعار والتبليغ وتتبع الخدمات الموجهة للأطفال ضحايا العنف." , ResultatsAttendu ="آليات ترابية مندمجة لحماية الطفولة مفعلة" },
        new Mesure {Id = 269, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="269", Nom = "تفعيل ميثاق السياحة المستدامة من أجل وضع برامج وقائية لحماية الأطفال من الأشخاص الذين يستغلون السياحة لأسباب جنسية." , ResultatsAttendu ="آليات داعمة لحماية الأطفال من الاستغلال الجنسي" },
        new Mesure {Id = 270, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="270", Nom = "إدماج الجماعات الترابية لانشغالات الأطفال في مخططات التنمية المحلية على مستوى التشخيص وتحديد الحاجيات والتخطيط والتنفيذ." , ResultatsAttendu ="مخططات للتنمية المحلية داعمة للنهوض بأوضاع الطفولة  من الاستغلال مطورة" },
        new Mesure {Id = 271, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="271", Nom = "تفعيل آليات المراقبة التربوية والبيداغوجية واللوجيستيكية بالأماكن التي تخصص لتعليم وتربية الأطفال." , ResultatsAttendu ="آليات معززة للمراقبة التربوية والبيداغوجية واللوجيستيكية" },
        new Mesure {Id = 272, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="272", Nom = "تعزيز إجراءات حماية محيط المؤسسات التعليمية لحماية الأطفال واليافعين من أخطار المخدرات ومروجيها." , ResultatsAttendu ="إجراءات أمنية معززة لحماية     الأطفال واليافعين من أخطار المخدرات ومروجيها" },
        new Mesure {Id = 273, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="273", Nom = " إشاعة ثقافة حقوق الطفل داخل مؤسسات الرعاية الاجتماعية المستقبلة للأطفال." , ResultatsAttendu ="ثقافة حقوق الطفل مشاعة داخل مؤسسات الرعاية الاجتماعية" },
        new Mesure {Id = 274, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="274", Nom = " التحسيس والتوعية بخطورة العقاب البدني والعنف في الوسط التربوي كبيئة آمنة." , ResultatsAttendu ="برامج مساعدة على الحد من العنف في الوسط التربوي " },
        new Mesure {Id = 275, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="275", Nom = "مواصلة تعزيز برامج وأنشطة حقوق المشاركة لدى الأطفال." , ResultatsAttendu ="بيئة مشجعة على مشاركة الأطفال" },
        new Mesure {Id = 276, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="276", Nom = " تقوية برامج الوقاية الموجهة للأطفال في وضعية صعبة ولأسرهم." , ResultatsAttendu ="برامج معززة لحماية الأطفال في وضعية صعبة ولأسرهم" },
        new Mesure {Id = 277, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="277", Nom = " الإبداع في أشكال وصيغ الأدوات البيداغوجية حول التربية الجنسية وفق مقاربة وقائية تراعي أعمار ومستوى نضج الأطفال والمخاطر التي قد تهددهم." , ResultatsAttendu =" بيئة داعمة للتربية الجنسية بالوسط المدرسي " },
        new Mesure {Id = 278, IdAxe = 3, IdSousAxe = 16 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="278", Nom = "مواصلة برامج وأنشطة التدريب والتكوين المستمر على اتفاقية الأمم المتحدة لحقوق الطفل والبروتوكولات الملحقة بها." , ResultatsAttendu ="قدرات الفاعلين متطورة " },
        new Mesure {Id = 279, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="279", Nom = " تفعيل المجلس الاستشاري للشباب والعمل الجمعوي وإصدار النصوص التشريعية والتنظيمية المتعلقة به." , ResultatsAttendu ="المجلس الاستشاري للشباب والعمل الجمعوي مفعل" },
        new Mesure {Id = 280, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="280", Nom = " وضع تدابير تشريعية وتنظيمية في مجال حماية الجمهور الناشئ ضد المخاطر المترتبة عن الاستعمال السيئ لوسائل التواصل المعتمدة على التكنولوجيات الحديثة. " , ResultatsAttendu ="إطار قانوني داعم لحماية الجمهور الناشئ  " },
        new Mesure {Id = 281, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="281", Nom = "مراجعة القانون التنظيمي للأحزاب بكيفية تمكن الشباب من المساهمة الفعالة في تدبير الشأن الحزبي. " , ResultatsAttendu ="مقتضيات قانونية داعمة للمشاركة السياسية للشباب" },
        new Mesure {Id = 282, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="282", Nom = "مراجعة القوانين التنظيمية للجماعات الترابية بكيفية تمكن الشباب من المساهمة الفعالة في تدبير الشأن المحلي." , ResultatsAttendu ="إطار قانوني تنظيمي داعم لمساهمة الشباب في تدبير الشأن المحلي" },
        new Mesure {Id = 283, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="283", Nom = "تقوية آليات التنسيق عبر القطاعية الخاصة بالشباب." , ResultatsAttendu ="سياسة وطنية للشباب معتمدة " },
        new Mesure {Id = 284, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="284", Nom = " تعزيز نقط ارتكاز خاصة بالشباب في القطاعات والمؤسسات المعنية مركزيا ومحليا." , ResultatsAttendu ="بيئة إدارية داعمة للتنسيق بين القطاعات" },
        new Mesure {Id = 285, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="285", Nom = " وضع برامج استعجالية لفائدة فئات الشباب الأكثر هشاشة (في وضعية إعاقة أو إقصاء...)." , ResultatsAttendu ="برامج مساعدة على إدماج الشباب الأكثر هشاشة " },
        new Mesure {Id = 286, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="286", Nom = " إعداد وتعميم تقارير دورية حول الشباب." , ResultatsAttendu ="تقارير مساعدة على تتبع وضعية الشباب" },
        new Mesure {Id = 287, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="287", Nom = " دعم الجمعيات التي تعنى بالشباب وبالترافع عن قضاياهم." , ResultatsAttendu =" قدرات متطورة في مجال الترافع " },
        new Mesure {Id = 288, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="288", Nom = "تقوية مشاركة الشباب في خدمات الإعلام والتواصل. " , ResultatsAttendu ="آليات داعمة لتمكين الشباب من التواصل والولوج إلى المعلومة " },
        new Mesure {Id = 289, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="289", Nom = " الرفع من عدد البرامج المعدة من الشباب والموجهة إليهم في دفاتر تحملات الشركات العمومية للاتصال السمعي البصري." , ResultatsAttendu ="برامج إعلامية محفزة على مشاركة الشباب " },
        new Mesure {Id = 290, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="290", Nom = " تعزيز دور الشباب في الحوارات الوطنية والجهوية المتعلقة بتدبير الشأن العام والنهوض بأوضاعهم." , ResultatsAttendu ="برامج داعمة لمشاركة الشباب في تدبير الشأن العام وتقييم السياسات العمومية" },
        new Mesure {Id = 291, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="291", Nom = " وضع قاعدة معلومات خاصة بالشباب. " , ResultatsAttendu ="قاعدة معلومات مساعدة على التخطيط     والبرمجة" },
        new Mesure {Id = 292, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="292", Nom = " وضع برامج لتعزيز قدرات المتدخلين في السياسة الوطنية المندمجة للشباب." , ResultatsAttendu ="قدرات متطورة لتفعيل السياسة الوطنية المندمجة للشباب" },
        new Mesure {Id = 293, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="293", Nom = "تعزيز مواكبة الشباب ودعمهم في مجالات الادماج الاقتصادي والمهني والاجتماعي." , ResultatsAttendu ="آليات داعمة لقدرات الشباب على الاندماج الاقتصادي والمهني والاجتماعي" },
        new Mesure {Id = 294, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="294", Nom = " تعزيز المقررات المدرسية والجامعية بمصوغات بيداغوجية تعنى بحقوق الانسان وبالتربية على المواطنة." , ResultatsAttendu ="بيئة تربوية داعمة لترسيخ ثقافة حقوق الإنسان" },
        new Mesure {Id = 295, IdAxe = 3, IdSousAxe = 17 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="295", Nom = "تعزيز برامج محو الأمية في أفق القضاء عليها وتأهيل الشباب." , ResultatsAttendu ="تقليص المعدل العام للأمية إلى20 % سنة 2021" },
        new Mesure {Id = 296, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="296", Nom = " المصادقة على معاهدة مراكش لتيسير النفاذ إلى المصنفات المنشورة لفائدة الأشخاص المكفوفين أو معاقي البصر أو ذوي إعاقات أخرى في قراءة المطبوعات لسنة 2013." , ResultatsAttendu ="المصادقة على المعاهدة" },
        new Mesure {Id = 297, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="297", Nom = "ملاءمة التشريع الوطني مع مقتضيات الاتفاقية الدولية للأشخاص في وضعية إعاقة، لا سيما ما يتعلق بالأهلية القانونية." , ResultatsAttendu ="إطار قانوني ملائم" },
        new Mesure {Id = 298, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="298", Nom = "  الإسراع بإصدار النصوص التنظيمية المنصوص عليها في القانون الإطار المتعلق بحماية حقوق الأشخاص في وضعية إعاقة والنهوض بها." , ResultatsAttendu ="مقتضيات تنظيمية داعمة لتفعيل القانون الإطار" },
        new Mesure {Id = 299, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="299", Nom = " الإسراع بإحداث الآلية الوطنية لحماية حقوق الأشخاص في وضعية إعاقة وفقا لمقتضيات اتفاقية حقوق الأشخاص ذوي الإعاقة." , ResultatsAttendu ="الآلية الوطنية لحماية حقوق الأشخاص في وضعية إعاقة مفعلة" },
        new Mesure {Id = 300, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="300", Nom = " دعم عمل آلية التنسيق الحكومية ذات الصلة بالمجال." , ResultatsAttendu ="آلية مؤسساتية داعمة لتنفيذ الاستراتيجية" },
        
        new Mesure {Id = 301, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="301", Nom = " إحداث مركز وطني للرصد والتوثيق والبحث في مجال الإعاقة." , ResultatsAttendu ="" },
        new Mesure {Id = 302, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="302", Nom = " تفعيل مقتضيات الرافعة الرابعة من الرؤية الاستراتيجية لإصلاح التربية والتعليم 2015-2030 من أجل مدرسة الانصاف والجودة والارتقاء لفائدة الأشخاص في وضعية إعاقة أو في وضعيات خاصة." , ResultatsAttendu ="مؤسسة تعليمية دامجة " },
        new Mesure {Id = 303, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="303", Nom = " إدماج التربية على الاختلاف في المناهج المدرسية للمساهمة في تغيير المواقف والتمثلات في أوساط الأطفال والشباب." , ResultatsAttendu ="كتب مدرسية معززة للتعايش وقبول الاختلاف" },
        new Mesure {Id = 304, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="304", Nom = " تعزيز التمدرس بالقسم الدراسي العادي مع توفير الترتيبات التيسيرية اللازمة وتوسيع شبكة الأقسام المدمجة لتشمل المستوى الإعدادي والثانوي وجعل المراكز المتخصصة جزء من المنظومة التعليمية الوطنية." , ResultatsAttendu ="تضاعف عدد الممدرسين من الأطفال في وضعية إعاقة" },
        new Mesure {Id = 305, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="305", Nom = "النهوض بالحق في الشغل للأشخاص في وضعية إعاقة من خلال تطبيق نسب التوظيف القانونية. " , ResultatsAttendu ="آليات ضامنة لتطبيق النسب القانونية " },
        new Mesure {Id = 306, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="306", Nom = "الإسراع بتحديد وإعمال النسبة المائوية للأشخاص في وضعية إعاقة الواجب تشغيلهم في إطار تعاقدي بين الدولة ومقاولات القطاع الخاص." , ResultatsAttendu =" إطار تعاقدي محفز لتشغيل الأشخاص في وضعية إعاقة" },
        new Mesure {Id = 307, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="307", Nom = "وضع برامج لدعم وتشجيع التشغيل الذاتي للأشخاص في وضعية إعاقة." , ResultatsAttendu ="برامج دعم وتشجيع التشغيل الذاتي للأشخاص في وضعية إعاقة مفعلة" },
        new Mesure {Id = 308, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="308", Nom = "تفعيل وتقوية آليات الإدماج المهني للأشخاص في وضعية إعاقة في أنظمة التكوين المهني والتشغيل الذاتي واستخدام آليات التمييز الإيجابي والنهوض بمراكز العمل المحمية." , ResultatsAttendu ="آليات داعمة للإدماج المهني للأشخاص في وضعية إعاقة " },
        new Mesure {Id = 309, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="309", Nom = "النهوض بالولوجية الشاملة سواء على المستوى العمراني والمعماري ووسائل النقل والاتصال." , ResultatsAttendu ="ولوجيات كفيلة بالمساهمة في تحسين ظروف عيش الأشخاص في وضعية إعاقة" },
        new Mesure {Id = 310, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="310", Nom = " اعتماد مقاربة التنمية الدامجة بشكل عرضاني في كل البرامج والسياسات المرتبطة بمجال الإعاقة." , ResultatsAttendu ="مقاربة التنمية الدامجة مفعلة" },
        new Mesure {Id = 311, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="311", Nom = " توفير الوسائل التيسيرية لولوج الأشخاص في وضعية إعاقة إلى منظومة العدالة." , ResultatsAttendu ="بنيات منظومة العدالة مساعدة على ولوجها" },
        new Mesure {Id = 312, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="312", Nom = " تفعيل المخطط الوطني للصحة والإعاقة." , ResultatsAttendu ="مخطط وطني للصحة والإعاقة      مفعل" },
        new Mesure {Id = 313, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="313", Nom = "الإسراع بتفعيل نظام الدعم الاجتماعي والتشجيع والمساندة لفائدة الأشخاص في وضعية إعاقة المنصوص عليه في المادة 6 من القانون الإطار رقم 97.13 المتعلق بحماية حقوق الاشخاص في وضعية إعاقة والنهوض بها." , ResultatsAttendu ="نظام الدعم الاجتماعي مشجع على النهوض بوضعية الأشخاص في وضعية إعاقة" },
        new Mesure {Id = 314, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="314", Nom = "تقنين وتأهيل خدمات مؤسسات الرعاية الاجتماعية.  " , ResultatsAttendu ="  توفر مؤسسات الرعاية الاجتماعية على خدمات ذات جودة" },
        new Mesure {Id = 315, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="315", Nom = " إحداث مؤسسات اجتماعية تعنى بإيواء الأشخاص في وضعية إعاقة المتخلى عنهم." , ResultatsAttendu ="بنيات داعمة للتكفل بالأشخاص في وضعية إعاقة المتخلى عنهم" },
        new Mesure {Id = 316, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="316", Nom = " تقوية موارد وخدمات صندوق دعم التماسك الاجتماعي الموجهة للأشخاص في وضعية إعاقة. " , ResultatsAttendu ="خدمات الصندوق مستجيبة لحاجيات الفئة المستفيدة" },
        new Mesure {Id = 317, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="317", Nom = " وضع نظام جديد لتقييم الإعاقة يتلاءم والمفهوم الطبي والنفسي والاجتماعي المعتمد بموجب الاتفاقية الدولية لحقوق الأشخاص ذوي الإعاقة." , ResultatsAttendu ="نظام جديد لتقييم الإعاقة معتمد" },
        new Mesure {Id = 318, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="318", Nom = " توحيد لغة الإشارة ووضع معايير لها." , ResultatsAttendu ="إطار معياري معد ومعتمد" },
        new Mesure {Id = 319, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="319", Nom = " البحث في سبل إشراك القطاع الخاص في إدماج الأشخاص في وضعية إعاقة في سوق الشغل." , ResultatsAttendu ="آلية مشتركة مساعدة على إدماج الأشخاص في وضعية إعاقة في سوق الشغل" },
        new Mesure {Id = 320, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="320", Nom = " دعم وتشجيع مبادرات المجتمع المدني العامل في مجال الإعاقة." , ResultatsAttendu ="مجتمع مدني متفاعل في مجال الإعاقة" },
        new Mesure {Id = 321, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="321", Nom = " تعميم ولوج الأشخاص في وضعية إعاقة إلى الخدمات الثقافية من خلال اعتماد الوسائل التقنية الحديثة سواء في المؤسسات التعليمية أو المكتبات والمركبات الثقافية والبنيات الرياضية." , ResultatsAttendu ="فضاءات مساعدة على ولوج الأشخاص في وضعية إعاقة إلى الخدمات الثقافية" },
        new Mesure {Id = 322, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="322", Nom = " دعم دور القطاع الخاص للمساهمة في مسلسل الإدماج الاجتماعي للأشخاص في وضعية إعاقة. " , ResultatsAttendu ="قطاع خاص منخرط في الإدماج الاجتماعي للأشخاص في وضعية إعاقة" },
        new Mesure {Id = 323, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="323", Nom = " تسهيل الولوج لإعادة تأهيل الأشخاص في وضعية إعاقة من خلال إحداث وتجهيز مراكز الترويض في مختلف الجهات والنهوض بأنظمة التكوين الطبي وشبه الطبي مصادق عليها ومستجيبة لمجموع الحاجيات." , ResultatsAttendu ="بنيات داعمة لإعادة تأهيل الأشخاص في وضعية إعاقة" },
        new Mesure {Id = 324, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="324", Nom = "تعزيز دور الإعلام في تطوير حملات للوقاية من الإعاقة وبرامج مكافحة التمييز والوصم تجاه الأشخاص ذوي الإعاقة." , ResultatsAttendu =" إعلام داعم لمكافحة التمييز والوصم تجاه الأشخاص ذوي الإعاقة " },
        new Mesure {Id = 325, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="325", Nom = "تمكين الأشخاص في وضعية إعاقة من خدمات الإعلام والتواصل عن طريق إدماج لغة الإشارة في البرامج الإعلامية." , ResultatsAttendu ="بيئة داعمة لولوج   الأشخاص في وضعية إعاقة للخدمات الإعلامية  " },
        new Mesure {Id = 326, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="326", Nom = " تطوير التكوين الأساسي والمستمر في مجال الإعاقة خصوصا في ميدان التربية والتكوين المهني والصحة ولاسيما ما يتعلق ببعض أنواع الإعاقة كالتوحد." , ResultatsAttendu ="برامج داعمة للنهوض بالتكوين الأساسي والمستمر في مجال الإعاقة في ميدان التربية والتكوين المهني" },
        new Mesure {Id = 327, IdAxe = 3, IdSousAxe = 18 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="327", Nom = " تعزيز دور المجتمع المدني في النهوض بحقوق الأشخاص في وضعية إعاقة. " , ResultatsAttendu ="مبادرات مثمنة وداعمة لأدوار المجتمع المدني في مجال النهوض بحقوق الأشخاص في وضعية إعاقة" },
        new Mesure {Id = 328, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="328", Nom = " وضع إطار استراتيجي للنهوض بحقوق الأشخاص المسنين وحمايتها." , ResultatsAttendu ="إطار استراتيجي معد ومعتمد" },
        new Mesure {Id = 329, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="329", Nom = " إحداث نظام أساسي لمهن المساعدة الاجتماعية لرعاية المسنين." , ResultatsAttendu ="مهن المساعدة الاجتماعية مقننة " },
        new Mesure {Id = 330, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="330", Nom = " حماية حقوق وكرامة الأشخاص المسنين بتجويد معايير وخدمات التكفل على مستوى البنيات والموارد البشرية." , ResultatsAttendu ="بنيات مهيكلة وفق معايير الجودة، مؤهلة لصيانة حقوق وكرامة الأشخاص المسنين" },
        new Mesure {Id = 331, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="331", Nom = "تحفيز البحث العلمي والدراسات الجامعية حول أوضاع الأشخاص المسنين وآثار الشيخوخة في مختلف المستويات الديمغرافية والاقتصادية والاجتماعية." , ResultatsAttendu ="بيئة داعمة للبحث العلمي حول أوضاع الأشخاص المسنين" },
        new Mesure {Id = 332, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="332", Nom = "حث الجماعات الترابية على إدماج احتياجات الأشخاص المسنين في برامج تفعيل مخططات التنمية." , ResultatsAttendu ="مخططات للتنمية المحلية داعمة للنهوض بأوضاع الأشخاص المسنين  " },
        new Mesure {Id = 333, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="333", Nom = " دعم وتشجيع مبادرات المجتمع المدني والقطاع الخاص لإحداث نوادي وفضاءات الترفيه الموجهة للأشخاص المسنين." , ResultatsAttendu ="دينامية داعمة لمبادرات المجتمع المدني والقطاع الخاص في مجال الترفيه لفائدة الأشخاص المسنين " },
        new Mesure {Id = 334, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="334", Nom = " تشجيع كل المبادرات العمومية والجمعوية الداعمة والحاضنة لرفاه الأشخاص المسنين ومشاركتهم." , ResultatsAttendu ="مبادرات عمومية داعمة لرفاه الأشخاص المسنين ومشاركتهم " },
        new Mesure {Id = 335, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="335", Nom = " التفكير في سبل تثمين خبرات ومهارات الأشخاص المسنين بوصفها جزءا من الرصيد الثقافي والقيمي للرأسمال اللامادي." , ResultatsAttendu ="بيئة داعمة لتثمين خبرات ومهارات الأشخاص المسنين" },
        new Mesure {Id = 336, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="336", Nom = " وضع مؤشرات وأنظمة معلوماتية لتتبع أوضاع الأشخاص المسنين لاسيما الموجودين في أوضاع صعبة محليا جهويا ووطنيا." , ResultatsAttendu ="منظومة معلوماتية ومؤشرات للتتبع مبلورة " },
        new Mesure {Id = 337, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="337", Nom = "دعم الأسر التي تحتضن أفرادا مسنين في وضعية صعبة." , ResultatsAttendu ="إطار داعم لخدمات التكفل بالأفراد المسنين في وضعية صعبة" },
        new Mesure {Id = 338, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="338", Nom = "ضمان التغطية الصحية الإجبارية للأشخاص المسنين غير المستفيدين منها " , ResultatsAttendu ="تغطية صحية شاملة لجميع الأشخاص المسنين" },
        new Mesure {Id = 339, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="339", Nom = "تشجيع النهوض بطب الشيخوخة في وزارة الصحة وإحداث شعب للتكوين الطبي المتخصص في هذا المجال." , ResultatsAttendu ="منظومة داعمة لطب الشيخوخة" },
        new Mesure {Id = 340, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="340", Nom = "تعزيز البرامج الإعلامية الموجهة للمسنين" , ResultatsAttendu ="برامج إعلامية مواكبة لحاجيات المسنين" },
        new Mesure {Id = 341, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="341", Nom = "تعزيز قدرات العاملين العموميين والمؤسساتيين لإدماج حاجيات الأشخاص المسنين في السياسات العمومية" , ResultatsAttendu ="قدرات معززة لإدماج حاجيات الأشخاص المسنين في السياسات العمومية" },
        new Mesure {Id = 342, IdAxe = 3, IdSousAxe = 19 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="342", Nom = "تعزيز العمل المؤسسي للجمعيات التي تعنى بأوضاع الأشخاص المسنين" , ResultatsAttendu ="العمل الجمعوي معزز في مجال النهوض بأوضاع الأشخاص المسنين" },
        new Mesure {Id = 343, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="343", Nom = " مواصلة التفكير في سبل تفعيل مقتضيات الدستور ذات الصلة بحقوق مغاربة العالم." , ResultatsAttendu ="تصورات حول تفعيل مقتضيات الدستور ذات الصلة بحقوق مغاربة العالم مبلورة" },
        new Mesure {Id = 344, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="344", Nom = " مواصلة تحيين الإطار التشريعي والمؤسساتي المتعلق بالهجرة واللجوء." , ResultatsAttendu ="الإطار التشريعي والمؤسساتي المتعلق بالهجرة واللجوء معزز ومحين" },
        new Mesure {Id = 345, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="345", Nom = " وضع المقتضيات التنظيمية الخاصة بقانون مكافحة الاتجار بالبشر." , ResultatsAttendu ="" },
        new Mesure {Id = 346, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="346", Nom = " مواصلة تطوير الاتفاقيات الخاصة بالحماية الاجتماعية المبرمة بين المغرب ودول الاستقبال وفق مقاربة حقوق الإنسان." , ResultatsAttendu ="الإطار الاتفاقي الثنائي في مجال الحماية الاجتماعية معزز وفق مقاربة حقوق الانسان" },
        new Mesure {Id = 347, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="347", Nom = " وضع اتفاقيات ثنائية مع البلدان الأصلية للمهاجرين المقيمين بالمغرب للتمتع بالحقوق الاجتماعية والاقتصادية والثقافية." , ResultatsAttendu ="اتفاقيات ثنائية مع الدول الأصلية للمهاجرين بالمغرب مبرمة" },
        new Mesure {Id = 348, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="348", Nom = "ضمان حماية النساء المغربيات المهاجرات وتعزيز الجهود الحكومية ذات الصلة." , ResultatsAttendu ="آلية لتعزيز حماية النساء المغربيات المهاجرات محدثة ومفعلة" },
        new Mesure {Id = 349, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="349", Nom = "حماية حقوق الأطفال المغاربة المهاجرين غير المرفقين في دول الاستقبال." , ResultatsAttendu ="برامج متخصصة مع جمعيات ومنظمات في مجال حماية حقوق الأطفال مبلورة ومنفذة" },
        new Mesure {Id = 350, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="350", Nom = " وضع آلية وطنية للرصد ومتابعة تطور الهجرة من وإلى المغرب وقياس آثارها المجتمعية والاقتصادية والثقافية." , ResultatsAttendu ="مرصد متخصص في متابعة تطور الهجرة محدث" },
        

        new Mesure {Id = 351, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="351", Nom = "مواصلة المجهودات المبذولة للرقي بالبرامج الموجهة لفائدة مغاربة العالم والاستجابة لانتظاراتهم الثقافية واللغوية والدينية والتربوية في بلدان الاستقبال وتعزيز التواصل بينهم وبين بلدهم الأصلي." , ResultatsAttendu ="برامج متنوعة تستجيب لإنتظارات مغاربة العالم" },
        new Mesure {Id = 352, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="352", Nom = "تفعيل الآليات الكفيلة بتتبع أوضاع السجناء المغاربة الذين يقضون عقوبتهم السجنية بالخارج ضمانا لحقوقهم واعتناء بأوضاعهم. " , ResultatsAttendu ="آليات داعمة لحماية حقوق السجناء المغاربة بالخارج" },
        new Mesure {Id = 353, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="353", Nom = " مواصلة التنسيق والالتقائية بين كافة المتدخلين في مجال الهجرة وتعزيز دور اللجنة بين الوزارية لمغاربة العالم وشؤون الهجرة في هذا المجال. " , ResultatsAttendu ="أداء اللجنة بين الوزارية معزز وفعال" },
        new Mesure {Id = 354, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="354", Nom = " تقوية نقط التواصل بالسفارات والقنصليات وتيسير الخدمات لفائدة المغاربة المقيمين بالخارج." , ResultatsAttendu ="الخدمات المقدمة من طرف نقط التواصل بالسفارات والقنصليات ميسرة" },
        new Mesure {Id = 355, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="355", Nom = " النهوض بإبداعات وابتكارات الباحثين المغاربة المقيمين بالخارج." , ResultatsAttendu ="إبداعات وابتكارات الباحثين المغاربة المقيمين بالخارج مثمنة" },
        new Mesure {Id = 356, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="356", Nom = " تعميم ونشر التقارير الوطنية عن الهجرة وبأوضاع المهاجرين." , ResultatsAttendu ="التقارير الوطنية عن الهجرة وأوضاع المهاجرين معممة ومنشورة " },
        new Mesure {Id = 357, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="357", Nom = " تعزيز البرامج الإعلامية الموجهة إلى المهاجرين." , ResultatsAttendu ="بيئة إعلامية داعمة لحقوق المهاجرين" },
        new Mesure {Id = 358, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="358", Nom = "مواصلة دعم وتعزيز قدرات فعاليات المجتمع المدني التي تهتم ميدانيا بأوضاع المهاجرين سواء في المغرب أو في بلدان الاستقبال." , ResultatsAttendu ="قدرات فعاليات المجتمع المدني معززة" },
        new Mesure {Id = 359, IdAxe = 3, IdSousAxe = 20 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="359", Nom = " إعداد برامج للتكوين والتكوين المستمر تستحضر البعد الحقوقي وتستهدف الجمعيات التي تعمل مع المغاربة في الخارج والمهاجرين بالمغرب." , ResultatsAttendu ="قدرات فعاليات المجتمع المدني معززة" },
        new Mesure {Id = 360, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="360", Nom = " مواصلة الانضمام والتفاعل مع الأنظمة الدولية والإقليمية لحقوق الإنسان." , ResultatsAttendu ="ممارسة اتفاقية في مجال حقوق الإنسان معززة " },
        new Mesure {Id = 361, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="361", Nom = " مواصلة الانخراط في اتفاقيات مجلس أوروبا المفتوحة للبلدان غير الأعضاء." , ResultatsAttendu ="ممارسة اتفاقية في مجال حقوق الإنسان معززة " },
        new Mesure {Id = 362, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="362", Nom = "الإسراع باعتماد مشروعي القانون الجنائي وقانون المسطرة الجنائية." , ResultatsAttendu ="منظومة جنائية معتمدة" },
        new Mesure {Id = 363, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="363", Nom = "الإسراع باعتماد قانون جديد منظم للسجون بما يضمن أنسنة المؤسسات السجنية وتحسين ظروف إقامة النزلاء وتغذيتهم وحماية باقي حقوقهم." , ResultatsAttendu ="إطار قانوني داعم لأنسنة المؤسسات السجنية  " },
        new Mesure {Id = 364, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="364", Nom = "الإسراع بإخراج المقتضيات القانونية الناظمة للعقوبات البديلة بهدف الحد من إشكالات الاعتقال الاحتياطي والاكتظاظ في السجون." , ResultatsAttendu ="مقتضيات قانونية داعمة لتجويد خدمات المؤسسة السجنية" },
        new Mesure {Id = 365, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="365", Nom = "مواصلة الحوار المجتمعي حول الانضمام إلى البروتوكول الاختياري الثاني الملحق بالعهد الدولي الخاص بالحقوق المدنية والسياسية المتعلق بإلغاء عقوبة الاعدام. " , ResultatsAttendu ="حوار مجتمعي منظم" },
        new Mesure {Id = 366, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="366", Nom = " مواصلة الحوار المجتمعي بشأن المصادقة على النظام الأساسي للمحكمة الجنائية الدولية." , ResultatsAttendu ="حوار مجتمعي منظم" },
        new Mesure {Id = 367, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="367", Nom = "مواصلة الحوار المجتمعي حول تعديل المادة 53 من مدونة الأسرة لأجل كفالة الحماية الفعلية للزوج أو الزوجة من طرف النيابة العامة عند الإرجاع إلى بيت الزوجية." , ResultatsAttendu ="حوار مجتمعي منظم" },
        new Mesure {Id = 368, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="368", Nom = "إحداث مرصد وطني للإجرام." , ResultatsAttendu ="آلية مؤسساتية مساعدة على تتبع تطور ظاهرة الإجرام" },
        new Mesure {Id = 369, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="369", Nom = "إحداث بنك وطني للبصمات الجينية." , ResultatsAttendu ="آلية داعمة للنجاعة الأمنية " },
        new Mesure {Id = 370, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="370", Nom = "عقد شراكات وعلاقات تعاون مع مؤسسات وطنية ودولية تعنى بحقوق الإنسان للمساهمة في تأطير وتكوين القضاة والمحامين في مجال تملك ثقافة حقوق الإنسان فكرا وسلوكا وعملا." , ResultatsAttendu ="شراكات وبرامج داعمة لتملك ثقافة حقوق الإنسان" },
        new Mesure {Id = 371, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="371", Nom = " وضع ميثاق النجاعة القضائية للتدبير الجيد للجلسات وآجال البت وتصفية المخلف والتواصل مع المواطنين والاستماع إلى شكاياتهم وغيرها من الإجراءات المماثلة." , ResultatsAttendu ="آليات داعمة لتجويد خدمات العدالة" },
        new Mesure {Id = 372, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="372", Nom = " تعزيز دور القضاء الإداري في ترسيخ دولة القانون وتكريس مبدأ سمو القانون واحترام حقوق الإنسان." , ResultatsAttendu ="إطار مؤسساتي معزز للقضاء الإداري" },
        new Mesure {Id = 373, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="373", Nom = "الإسراع بوضع منظومة مندمجة لمعالجة الشكايات المتعلقة بحقوق المرتفقين." , ResultatsAttendu ="منظومة مندمجة لمعالجة الشكايات مفعلة " },
        new Mesure {Id = 374, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="374", Nom = " وضع برنامج خاص بجمع وتصنيف وتقديم ونشر الاجتهادات القضائية الجنائية والإدارية المعززة لإعمال المعايير الدولية لحقوق الإنسان." , ResultatsAttendu ="منظومة داعمة لتثمين الاجتهادات القضائية واستثمارها" },
        new Mesure {Id = 375, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="375", Nom = "توثيق ونشر الأعمال البحثية المعززة لرصيد ثقافة حقوق الإنسان المنجزة بمناسبة الآراء والأعمال الاستشارية من قبل مؤسسات الديمقراطية التشاركية." , ResultatsAttendu ="برامج معززة لرصيد ثقافة حقوق الإنسان " },
        new Mesure {Id = 376, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="376", Nom = "ترصيد التواصل بين مهنيي ومساعدي العدالة والعمل على مأسسته على نحو أفضل." , ResultatsAttendu ="آلية داعمة للتواصل" },

        new Mesure {Id = 377, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="377", Nom = "وضع برامج للتدريب والتكوين المستمر على سيادة القانون واحترام حقوق الإنسان تتأسس على الدستور والرصيد الثري للاجتهاد القضائي المغربي والممارسات الفضلى ذات الصلة لفائدة مكونات العدالة ومساعديها." , ResultatsAttendu ="برامج للتكوين داعمة لتمكين الجهاز القضائي من ثقافة حقوق الانسان  " },
        new Mesure {Id = 378, IdAxe = 4, IdSousAxe = 21 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="378", Nom = "تعزيز برامج التكوين الأساسي والتكوين المستمر في المعاهد والمراكز المعنية بالمكلفين بإنفاذ القانون." , ResultatsAttendu ="" },
        new Mesure {Id = 379, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="379", Nom = " تفعيل الهيئة المكلفة بالمناصفة ومكافحة جميع أشكال التمييز." , ResultatsAttendu ="هيئة المناصفة ومكافحة جميع أشكال التمييز مفعلة." },
        new Mesure {Id = 380, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="380", Nom = " البحث في سبل مبادرات الحكومة وهيئات الديمقراطية التشاركية لتنظيم حوارات عمومية حول رصيد إعمال مدونة الأسرة على مستوى الاجتهاد القضائي والتطور المجتمعي." , ResultatsAttendu ="ديناميات داعمة لتطوير مدونة الأسرة " },
        new Mesure {Id = 381, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="381", Nom = " تعزيز الخطة الحكومية للمساواة في أفق المناصفة إكرام 2" , ResultatsAttendu ="الإعمال الناجع لخطة إكرام 2"  },
        new Mesure {Id = 382, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="382", Nom = " تعزيز حماية النساء ضد العنف على مستوى التشريع والسياسة الجنائية الوطنية." , ResultatsAttendu ="إطار قانوني داعم لحماية النساء ضحايا العنف" },
        new Mesure {Id = 383, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="383", Nom = "الإسراع بإصدار القانون المتعلق بمحاربة العنف ضد النساء." , ResultatsAttendu ="" },
        new Mesure {Id = 384, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="384", Nom = "مواصلة ترصيد المكتسبات المعرفية المتعلقة بالكد والسعاية في التشريع والعمل القضائي." , ResultatsAttendu ="دينامية داعمة لترصيد الاجتهادات العلمية/الفقهية والقضائية المتعلقة بالكد والسعاية  " },
        new Mesure {Id = 385, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="385", Nom = " تفعيل النصوص التنظيمية الخاصة بتنفيذ القانون المتعلق بتحديد شروط التشغيل والشغل الخاص بالعمال المنزليين." , ResultatsAttendu ="المقتضيات القانونية للقانون رقم 19.12 مفعلة" },
        new Mesure {Id = 386, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="386", Nom = "  تعزيز الضمانات القانونية المتعلقة بتجريم التحرش الجنسي." , ResultatsAttendu ="إطار قانوني داعم لحماية النساء ضحايا العنف" },
        new Mesure {Id = 387, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="387", Nom = " مواصلة الحوار المجتمعي حول بعض مقتضيات مدونة الأسرة، ويتعلق الأمر بإعادة صياغة المادة 49 بما يضمن استيعاب مفهوم الكد والسعاية ومراجعة المادة 175 بإقرار عدم سقوط الحضانة عن الأم رغم زواجها وتعديل المادتين 236 و238 من أجل كفالة المساواة بين الأب والأم في الولاية على الأبناء." , ResultatsAttendu ="حوار مجتمعي منظم" },
        new Mesure {Id = 388, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="388", Nom = " صيانة الكرامة الإنسانية للمرأة في وسائل الإعلام، ووضع تدابير زجرية في حالة انتهاكها. " , ResultatsAttendu ="إجراءات داعمة لصيانة كرامة المرأة في وسائل الاعلام" },
        new Mesure {Id = 389, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="389", Nom = " تعزيز آليات الرصد والتتبع لحماية النساء ضحايا العنف وطنيا جهويا ومحليا." , ResultatsAttendu ="آليات فعالة لحماية النساء ضحايا العنف" },
        new Mesure {Id = 390, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="390", Nom = " مواصلة تفعيل مقتضيات صندوق التكافل العائلي وتبسيط مساطره." , ResultatsAttendu ="مقتضيات داعمة لتوسيع دائرة المستفيدين" },
        new Mesure {Id = 391, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="391", Nom = " إدماج مقاربة النوع الاجتماعي في البرامج الاقتصادية الداعمة لإحداث المقاولات." , ResultatsAttendu ="آليات كفيلة بإدماج مقاربة النوع" },
        new Mesure {Id = 392, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="392", Nom = " التفعيل الحازم لمقتضيات قانون الاتجار بالبشر المتعلقة بحماية الأطفال والنساء الضحايا." , ResultatsAttendu ="إجراءات داعمة لحماية الأطفال والنساء ضحايا الاتجار بالبشر " },
        new Mesure {Id = 393, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="393", Nom = " تعزيز دور الجماعات الترابية في توفير بيئة آمنة تحمي الأطفال والنساء من كل أشكال العنف." , ResultatsAttendu ="بيئة آمنة تحمي الأطفال والنساء من كل أشكال العنف" },
        new Mesure {Id = 394, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="394", Nom = "إدماج بعد النوع الاجتماعي في السياسات والميزانيات ووضع آليات للمتابعة والتقييم." , ResultatsAttendu ="آليات داعمة لإدماج بعد النوع في السياسات والميزانيات" },
        new Mesure {Id = 395, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="395", Nom = " وضع الآليات الكفيلة بضمان ولوج النساء لمجال المقاولة." , ResultatsAttendu ="أليات كفيلة بتيسير ولوج النساء للمقاولة " },
        new Mesure {Id = 396, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="396", Nom = "تعزيز البرامج الخاصة بالقضاء على الفقر والتهميش والإقصاء الاجتماعي في أوساط النساء." , ResultatsAttendu ="البرامج الخاصة بالقضاء على الفقر والتهميش والإقصاء الاجتماعي في أوساط النساء معززة" },
        new Mesure {Id = 397, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="397", Nom = "توثيق ونشر الاجتهاد القضائي في مجال حماية حقوق المرأة كمصدر من مصادر التشريع." , ResultatsAttendu ="دينامية داعمة لترصيد الاجتهاد القضائي في مجال حماية حقوق المرأة" },
        new Mesure {Id = 398, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="398", Nom = "نشر الممارسات الفضلى المتعلقة بتطبيق مدونة الأسرة على مستوى عمل كتابة الضبط ومراكز الاستقبال." , ResultatsAttendu ="دينامية داعمة للتطبيق الناجع لمدونة الأسرة " },
        new Mesure {Id = 399, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="399", Nom = "توسيع شبكة الفضاءات متعددة الاختصاصات والوظائف الموجهة للنساء وتعزيزها وتقويتها." , ResultatsAttendu ="نسيج مؤسساتي داعم ومنصف للنساء" },
        new Mesure {Id = 400, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="400", Nom = "محاربة الصور النمطية والتمييزية ضد النساء في وسائل الإعلام وفي البرامج والمقررات المدرسية." , ResultatsAttendu ="بيئة داعمة لمكافحة الصور النمطية والتمييزية ضد النساء" },


        new Mesure {Id = 401, IdAxe = 4, IdSousAxe = 22 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="401", Nom = "مواصلة برامج التدريب وتطوير القدرات في مجال التكوين والتكوين المستمر على حقوق النساء لفائدة القضاة ومساعدي العدالة." , ResultatsAttendu ="برامج مساعدة على تقوية القدرات في مجال حقوق النساء" },
        new Mesure {Id = 402, IdAxe = 4, IdSousAxe = 23 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="402", Nom = "  التعجيل بإصدار القانون المتعلق بالحق في الحصول على المعلومات، انسجاما مع الدستور والاتفاقيات الدولية." , ResultatsAttendu ="" },
        new Mesure {Id = 403, IdAxe = 4, IdSousAxe = 23 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="403", Nom = "إصدار القرار الخاص بتحديد كيفيات سير وتنظيم مراحل انتخاب أعضاء المجلس الوطني للصحافة." , ResultatsAttendu ="" },
        new Mesure {Id = 404, IdAxe = 4, IdSousAxe = 23 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="404", Nom = " الإسراع بوضع ميثاق أخلاقيات مهنة الصحافة والإعلام بما في ذلك الصحافة الإلكترونية." , ResultatsAttendu ="ميثاق أخلاقيات مهنة الصحافة والإعلام معتمد" },
        new Mesure {Id = 405, IdAxe = 4, IdSousAxe = 23 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="405", Nom = " تعزيز الأخلاقيات المهنية في الممارسة الإعلامية." , ResultatsAttendu ="بيئة داعمة لممارسة إعلامية وفق الضوابط المهنية  " },
        new Mesure {Id = 406, IdAxe = 4, IdSousAxe = 23 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="406", Nom = " النهوض بمعاهد التكوين في مجال الإعلام." , ResultatsAttendu ="منظومة وطنية للتكوين في مجال الإعلام مستجيبة لحاجيات القطاع من الكفاءات كما وكيفا  " },
        new Mesure {Id = 407, IdAxe = 4, IdSousAxe = 23 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="407", Nom = "التنصيص على مبدأ المناصفة في دفاتر تحملات شركات الاتصال السمعي البصري." , ResultatsAttendu ="بيئة إعلامية معززة لمبدأ المناصفة في الفضاء السمعي البصري " },
        new Mesure {Id = 408, IdAxe = 4, IdSousAxe = 23 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="408", Nom = "تقوية المقتضيات القانونية المتعلقة بالاعتداء على الملكية الفكرية لتتلاءم مع الدستور." , ResultatsAttendu ="مقتضيات قانونية داعمة لحماية الملكية الفكرية  " },
        new Mesure {Id = 409, IdAxe = 4, IdSousAxe = 23 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="409", Nom = " تعزيز دور المكتب المغربي لحقوق المؤلفين ومراجعة قانونه ليصبح مؤسسة عمومية." , ResultatsAttendu ="إطار قانوني داعم لحقوق المؤلف" },
        new Mesure {Id = 410, IdAxe = 4, IdSousAxe = 23 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="410", Nom = "تعزيز برامج التوعية والتحسيس بشأن مكتسبات وتحديات ممارسة حريات التعبير والإعلام والصحافة والحق في المعلومة" , ResultatsAttendu ="عدد البرامج والشراكات والدعامات المنجزة" },
        new Mesure {Id = 411, IdAxe = 4, IdSousAxe = 23 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="411", Nom = "إدماج قيم حقوق الإنسان في برامج التكوين والتدريب الموجهة لمهنيي الإعلام والاتصال" , ResultatsAttendu ="برامج التكوين والتدريب معززة بقيم حقوق الانسان" },
        new Mesure {Id = 412, IdAxe = 4, IdSousAxe = 24 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="412", Nom = " التشجيع على الانضمام إلى الاتفاقيات الدولية المتعلقة بحماية التراث الثقافي والمحافظة عليه." , ResultatsAttendu ="تعزيز الممارسة الاتفاقية" },
        new Mesure {Id = 413, IdAxe = 4, IdSousAxe = 24 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="413", Nom = "وضع النصوص التطبيقية للقانون المنظم لحماية التراث الثقافي." , ResultatsAttendu ="نصوص تنظيمية داعمة لحماية التراث الثقافي." },
        new Mesure {Id = 414, IdAxe = 4, IdSousAxe = 24 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="414", Nom = " مراجعة النصوص المتعلقة بالتراث الثقافي." , ResultatsAttendu ="إطار قانوني معزز" },
        new Mesure {Id = 415, IdAxe = 4, IdSousAxe = 24 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="415", Nom = " جرد التراث الثقافي وتوثيقه وتصنيفه." , ResultatsAttendu =" تراث ثقافي موثق ومصنف" },
        new Mesure {Id = 416, IdAxe = 4, IdSousAxe = 24 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="416", Nom = "تأهيل آليات الحفاظ على التراث الثقافي المغربي بكل مكوناته وأبعاده المادية والرمزية والمحافظة عليها." , ResultatsAttendu ="آليات الحفاظ على التراث الثقافي المغربي مؤهلة" },
        new Mesure {Id = 417, IdAxe = 4, IdSousAxe = 24 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="417", Nom = " تعزيز تأهيل القصور والقصبات والحفاظ عليها." , ResultatsAttendu ="التراث العمراني مرمم ومحافظ عليه" },
        new Mesure {Id = 418, IdAxe = 4, IdSousAxe = 25 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="418", Nom = " مراجعة قانون الأرشيف طبقا للممارسات الفضلى المعمول بها في هذا المجال مع استكمال إصدار المراسيم التطبيقية لقانون الأرشيف." , ResultatsAttendu ="إطار قانوني داعم لثقافة الأرشيف " },
        new Mesure {Id = 419, IdAxe = 4, IdSousAxe = 25 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="419", Nom = "وضع تصور لتدبير الأرشيف في إطار الجهوية المتقدمة." , ResultatsAttendu ="خطة وطنية لتنظيم الأرشيفات الترابية معتمدة" },
        new Mesure {Id = 420, IdAxe = 4, IdSousAxe = 25 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="420", Nom = " رصد مصادر الأرشيف الخاصة بالمغرب والموجودة خارج الوطن ومواصلة استرجاعها ومعالجتها وحفظها وتيسير الاطلاع عليها من قبل المهتمين. " , ResultatsAttendu ="الأرصدة الوثائقية المتعلقة بالمغرب والموجودة بالخارج مرصودة ومعالجة وميسرة للاطلاع" },
        new Mesure {Id = 421, IdAxe = 4, IdSousAxe = 25 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="421", Nom = "تحسيس وتعبئة الخواص الذين بحوزتهم أرشيفات تراثية لإيداعها لدى مؤسسة أرشيف المغرب." , ResultatsAttendu ="دينامية مشجعة على تفاعل الخواص" },
        new Mesure {Id = 422, IdAxe = 4, IdSousAxe = 25 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="422", Nom = " تحسيس مصالح الإدارات العمومية بأهمية إيداع أرشيفها بانتظام لدى مصالح أرشيف المغرب طبقا للنصوص الجاري بها العمل." , ResultatsAttendu ="مصالح الإدارات العمومية منخرطة" },
        new Mesure {Id = 423, IdAxe = 4, IdSousAxe = 25 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="423", Nom = "تقوية قدرات مؤسسة أرشيف المغرب المادية والبشرية حتى تتمكن من الاضطلاع بالمهام المنوطة بها." , ResultatsAttendu ="قدرات مؤسسة أرشيف المغرب معززة " },
        new Mesure {Id = 424, IdAxe = 4, IdSousAxe = 25 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="424", Nom = "النهوض بالموارد البشرية المعنية بمعالجة وبحفظ وتنظيم الأرشيف باعتماد برامج منتظمة خاصة بالتكوين والتكوين المستمر موجهة لفائدة المهنيين." , ResultatsAttendu ="الموارد البشرية بمؤسسة أرشيف المغرب مكونة" },
        new Mesure {Id = 425, IdAxe = 4, IdSousAxe = 26 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="425", Nom = "  تأهيل الهياكل القضائية والإدارية بما يكرس النجاعة القضائية الضامنة للأجل المعقول. " , ResultatsAttendu ="آليات مؤسساتية داعمة للنجاعة القضائية" },
        new Mesure {Id = 426, IdAxe = 4, IdSousAxe = 26 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="426", Nom = "  تسهيل ولوج المتقاضين إلى المحاكم وتيسير التواصل اللغوي في عملها." , ResultatsAttendu ="آليات داعمة لتيسير الولوج لخدمات العدالة" },
        new Mesure {Id = 427, IdAxe = 4, IdSousAxe = 26 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="427", Nom = "الرفع من جودة الأحكام." , ResultatsAttendu ="آلية داعمة للرفع من جودة الاحكام" },
        new Mesure {Id = 428, IdAxe = 4, IdSousAxe = 26 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="428", Nom = "مواصلة تحسين الخدمات القضائية." , ResultatsAttendu ="إجراءات معززة للخدمات القضائية" },
        new Mesure {Id = 429, IdAxe = 4, IdSousAxe = 26 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="429", Nom = "مواصلة جهود تخليق العدالة." , ResultatsAttendu ="دينامية داعمة لتخليق العدالة" },
        new Mesure {Id = 430, IdAxe = 4, IdSousAxe = 26 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="430", Nom = " وضع سياسة فعالة تضمن تنفيذ الأحكام الصادرة ضد كافة مؤسسات الدولة والخواص." , ResultatsAttendu ="سياسة داعمة لتنفيذ الاحكام القضائية" },
        new Mesure {Id = 431, IdAxe = 4, IdSousAxe = 26 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 1,   Code ="431", Nom = " تفعيل المقتضيات الدستورية المتعلقة بتقوية الدور الرقابي للبرلمان على الحكومة والمؤسسات التابعة للدولة من خلال لجن التقصي وغيرها من الآليات المتوفرة." , ResultatsAttendu ="إطار قانوني داعم للدور الرقابي للبرلمان على الحكومة والمؤسسات التابعة للدولة " },
        new Mesure {Id = 432, IdAxe = 4, IdSousAxe = 26 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="432", Nom = "إشاعة ثقافة حقوق الإنسان وتنميتها في أوساط العدالة." , ResultatsAttendu ="شراكات وبرامج داعمة لتملك ثقافة حقوق الإنسان" },
        new Mesure {Id = 433, IdAxe = 4, IdSousAxe = 26 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="433", Nom = "تأهيل الموارد البشرية لإدارة العدالة وهيئات وجمعيات المهن القانونية من خلال وضع برامج في مجال التكوين والتكوين المستمر وتقويم الأداء." , ResultatsAttendu ="قدرات الموارد البشرية لمنظومة العدالة معززة " },
        new Mesure {Id = 434, IdAxe = 4, IdSousAxe = 26 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="434", Nom = " تعزيز إدماج مرجعية حقوق الإنسان والتربية على المواطنة ضمن برامج التكوين بالمعهد العالي للقضاء." , ResultatsAttendu ="قدرات متطورة في مجال التكوين القضائي التخصصي; برامج مساهمة في توسيع المعارف وتعزيز القدرات في مجال حقوق الإنسان" },
        new Mesure {Id = 435, IdAxe = 4, IdSousAxe = 26 , IdType = random.Next(1, 3), IdCycle = random.Next(1, 3) ,IdResponsable= random.Next(1, 34), IdNature = 3,   Code ="435", Nom = " وضع برامج للتكوين المستمر وتبادل الخبرات والممارسات الفضلى بشأن إدماج حقوق الإنسان في الاجتهاد القضائي، تفاعلا مع التزامات المغرب في مجال حقوق الإنسان وأحكام الدستور." , ResultatsAttendu ="آليات داعمة لاستحضار بعد حقوق الإنسان في الاحكام القضائية" },
        
        });
    return modelBuilder;

}

        
        public static ModelBuilder MesuresJihat(this ModelBuilder modelBuilder)
        {
            var id = 436;
            var list = new[]
            {
                " إرتفاع نسبة التسجيل والتصويت",
                "التعبير عن الرضا بخصوص تدبير العملية الإنتخابية من قبل عموم المعنيين والملاحظين ",
                "إرتفاع نسب التمثيلية",
                "النشر في الجريدة الرسمية",
                "تنصيب رئيس واعضاء الهيئة ",
                "عدد عمليات التشاور العمومي",
             };
            var faker = new Faker<Mesure>(SeedingData.lang)
                .CustomInstantiator(f => new Mesure { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 1} : تدابير عشوائية لغايات تجريبية فقط")
                .RuleFor(o => o.Code, f => "Code : {id - 1}")
                .RuleFor(o => o.IdType, f => f.Random.Number(1, 3))
                .RuleFor(o => o.IdResponsable, f => f.Random.Number(35, 46))
                .RuleFor(o => o.IdAxe, f => f.Random.Number(1, 4))
                .RuleFor(o => o.IdSousAxe, f => f.Random.Number(1, 26))
                .RuleFor(o => o.IdCycle, f => f.Random.Number(1, 3))
                .RuleFor(o => o.IdNature, f => f.Random.Number(1, 3))
                .RuleFor(o => o.ResultatsAttendu, f => $"بعد النتائج المرتقبة : {id - 1}")
                .RuleFor(o => o.ObjectifGlobal, f => $"بعد الأهداف العامة  : {id - 1}")
                .RuleFor(o => o.ObjectifSpeciaux, f => $"بعد الأهداف الخاصة : {id - 1}")
                // .RuleFor(o => o.IdMesure, f => null)
                ;

            modelBuilder.Entity<Mesure>().HasData(faker.Generate(50));

            return modelBuilder; 
        }

        public static ModelBuilder MesuresSociete(this ModelBuilder modelBuilder)
        {
            var id = 487;
            var list = new[]
            {
                " إرتفاع نسبة التسجيل والتصويت",
                "التعبير عن الرضا بخصوص تدبير العملية الإنتخابية من قبل عموم المعنيين والملاحظين ",
                "إرتفاع نسب التمثيلية",
                "النشر في الجريدة الرسمية",
                "تنصيب رئيس واعضاء الهيئة ",
                "عدد عمليات التشاور العمومي",
             };
            var faker = new Faker<Mesure>(SeedingData.lang)
                .CustomInstantiator(f => new Mesure { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 1} : تدابير عشوائية لغايات تجريبية فقط")
                .RuleFor(o => o.Code, f => "Code : {id - 1}")
                .RuleFor(o => o.IdType, f => f.Random.Number(1, 3))
                .RuleFor(o => o.IdResponsable, f => f.Random.Number(47, 50))
                .RuleFor(o => o.IdAxe, f => f.Random.Number(1, 4))
                .RuleFor(o => o.IdSousAxe, f => f.Random.Number(1, 26))
                .RuleFor(o => o.IdCycle, f => f.Random.Number(1, 3))
                .RuleFor(o => o.IdNature, f => f.Random.Number(1, 3))
                .RuleFor(o => o.ResultatsAttendu, f => $"بعد النتائج المرتقبة : {id - 1}")
                .RuleFor(o => o.ObjectifGlobal, f => $"بعد الأهداف العامة  : {id - 1}")
                .RuleFor(o => o.ObjectifSpeciaux, f => $"بعد الأهداف الخاصة : {id - 1}")
                // .RuleFor(o => o.IdMesure, f => null)
                ;

            modelBuilder.Entity<Mesure>().HasData(faker.Generate(50));

            return modelBuilder; 
        }


        public static ModelBuilder Activites(this ModelBuilder modelBuilder)
        {
            var id = 1;
            // var list = new[] {  "2018 - 2021", "2022 - 2025", "2026 - 2030" };
            var numberList = Enumerable.Range(2018, 12).ToList();
            var faker = new Faker<Activite>(SeedingData.lang)
                .CustomInstantiator(f => new Activite { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 2} بعد الأنشطة لبعض التدابير")
                .RuleFor(o => o.Duree, f =>
                {
                    var y = f.PickRandom(numberList);
                    return $"[\"{y++}\", \"{y++}\", \"{y++}\"]";
                })
                .RuleFor(o => o.IdMesure, f => f.Random.Number(1, 435 ))
                ;

            modelBuilder.Entity<Activite>().HasData(faker.Generate(50));

            return modelBuilder;
        }

        public static ModelBuilder ActivitesJihat(this ModelBuilder modelBuilder)
        {
            var id = 51;
            // var list = new[] {  "2018 - 2021", "2022 - 2025", "2026 - 2030" };
            var numberList = Enumerable.Range(2018, 12).ToList();
            var faker = new Faker<Activite>(SeedingData.lang)
                .CustomInstantiator(f => new Activite { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 2} بعد الأنشطة لبعض التدابير")
                .RuleFor(o => o.Duree, f =>
                {
                    var y = f.PickRandom(numberList);
                    return $"[\"{y++}\", \"{y++}\", \"{y++}\"]";
                })
                .RuleFor(o => o.IdMesure, f => f.Random.Number(436, 486 ))
                ;

            modelBuilder.Entity<Activite>().HasData(faker.Generate(50));

            return modelBuilder;
        }

        public static ModelBuilder ActivitesSociete(this ModelBuilder modelBuilder)
        {
            var id = 101;
            // var list = new[] {  "2018 - 2021", "2022 - 2025", "2026 - 2030" };
            var numberList = Enumerable.Range(2018, 12).ToList();
            var faker = new Faker<Activite>(SeedingData.lang)
                .CustomInstantiator(f => new Activite { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 2} بعد الأنشطة لبعض التدابير")
                .RuleFor(o => o.Duree, f =>
                {
                    var y = f.PickRandom(numberList);
                    return $"[\"{y++}\", \"{y++}\", \"{y++}\"]";
                })
                .RuleFor(o => o.IdMesure, f => f.Random.Number(487, 536 ))
                ;

            modelBuilder.Entity<Activite>().HasData(faker.Generate(50));

            return modelBuilder;
        }


        public static ModelBuilder Indicateurs(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var list = new[]
            {
                " إرتفاع نسبة التسجيل والتصويت",
                "التعبير عن الرضا بخصوص تدبير العملية الإنتخابية من قبل عموم المعنيين والملاحظين ",
                "إرتفاع نسب التمثيلية",
                "النشر في الجريدة الرسمية",
                "تنصيب رئيس واعضاء الهيئة ",
                "عدد عمليات التشاور العمومي",
             };
            var faker = new Faker<Indicateur>(SeedingData.lang)
                .CustomInstantiator(f => new Indicateur { Id = id++ })
                .RuleFor(o => o.Nom, f => list[id - 2])
                .RuleFor(o => o.Source, f => "غير معروف")
                // .RuleFor(o => o.IdMesure, f => null)
                ;

            modelBuilder.Entity<Indicateur>().HasData(faker.Generate(6));

            return modelBuilder;
        }

        public static ModelBuilder IndicateurMesures(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var isFirstRoundDone = false;
            var faker = new Faker<IndicateurMesure>(SeedingData.lang)
                // .CustomInstantiator(f => new IndicateurMesure { Id = id++ })
                .RuleFor(o => o.IdMesure, f =>
                {
                    if (id <= 50)
                    {
                        return id++;
                    }
                    else
                    {
                        id = 1;
                        isFirstRoundDone = true;
                        return id++;
                    }
                })
                .RuleFor(o => o.IdIndicateur, f => isFirstRoundDone ? f.Random.Number(1, 3) : f.Random.Number(4, 6))
                // .RuleFor(o => o.Value, f => $"{f.Random.Number(10, 100)}")
                // .RuleFor(o => o.Date, f => f.Date.Past())
                ;

            modelBuilder.Entity<IndicateurMesure>().HasData(faker.Generate(100));

            return modelBuilder;
        }

        public static ModelBuilder IndicateurMesureValues(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var isFirstRoundDone = false;
            var faker = new Faker<IndicateurMesureValue>(SeedingData.lang)
                .CustomInstantiator(f => new IndicateurMesureValue { Id = id++ })
                // .RuleFor(o => o.IdMesure, f =>
                // {
                //     if (id <= 50)
                //     {
                //         return id++;
                //     }
                //     else
                //     {
                //         id = 1;
                //         isFirstRoundDone = true;
                //         return id++;
                //     }
                // })
                // .RuleFor(o => o.IdIndicateur, f => isFirstRoundDone ? f.Random.Number(1, 3) : f.Random.Number(4, 6))
                .RuleFor(o => o.IdMesure, f => f.Random.Number(1, 435))
                .RuleFor(o => o.IdIndicateur, f => f.Random.Number(1, 6))
                .RuleFor(o => o.Value, f => $"{f.Random.Number(10, 100)}")
                .RuleFor(o => o.Date, f => f.Date.Past())
                ;

            modelBuilder.Entity<IndicateurMesureValue>().HasData(faker.Generate(200));

            return modelBuilder;
        }

        public static ModelBuilder Realisations(this ModelBuilder modelBuilder)
        {
            var id = 1;
            // var list = new[] {  "2018 - 2021", "2022 - 2025", "2026 - 2030" };
            var list = Enumerable.Range(2018, 12).ToList();
            var faker = new Faker<Realisation>(SeedingData.lang)
                .CustomInstantiator(f => new Realisation { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 2} بعد الإنجازات لبعض الأنشطة ")
                .RuleFor(o => o.Situation, f => $"{id - 2} وضعية التنفيد لهدا الإنجاز")
                .RuleFor(o => o.Annee, f => f.PickRandom(list))
                .RuleFor(o => o.Taux, f => $"{id - 2} معدل الإنجاز لهدا الإنجاز")
                .RuleFor(o => o.TauxRealisation, f => f.Random.Number(1, 99))
                .RuleFor(o => o.Effet, f => $"{id - 2} التأثير لهدا الإنجاز")
                .RuleFor(o => o.IdActivite, f => f.Random.Number(1, 50))
                ;

            modelBuilder.Entity<Realisation>().HasData(faker.Generate(50));

            var faker2 = new Faker<Realisation>(SeedingData.lang)
                .CustomInstantiator(f => new Realisation { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 2} بعد الإنجازات لبعض الأنشطة ")
                .RuleFor(o => o.Situation, f => $"{id - 2} وضعية التنفيد لهدا الإنجاز")
                .RuleFor(o => o.Annee, f => f.PickRandom(list))
                .RuleFor(o => o.Taux, f => $"{id - 2} معدل الإنجاز لهدا الإنجاز")
                .RuleFor(o => o.TauxRealisation, 100)
                .RuleFor(o => o.Effet, f => $"{id - 2} التأثير لهدا الإنجاز")
                .RuleFor(o => o.IdActivite, f => f.Random.Number(1, 50))
                ;

            modelBuilder.Entity<Realisation>().HasData(faker2.Generate(10));

            var faker3 = new Faker<Realisation>(SeedingData.lang)
                .CustomInstantiator(f => new Realisation { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 2} بعد الإنجازات لبعض الأنشطة ")
                .RuleFor(o => o.Situation, f => $"{id - 2} وضعية التنفيد لهدا الإنجاز")
                .RuleFor(o => o.Annee, f => f.PickRandom(list))
                .RuleFor(o => o.Taux, f => $"{id - 2} معدل الإنجاز لهدا الإنجاز")
                .RuleFor(o => o.TauxRealisation, 0)
                .RuleFor(o => o.Effet, f => $"{id - 2} التأثير لهدا الإنجاز")
                .RuleFor(o => o.IdActivite, f => f.Random.Number(1, 50))
                ;

            modelBuilder.Entity<Realisation>().HasData(faker3.Generate(10));


            return modelBuilder;
        }

        public static ModelBuilder RealisationsJihat(this ModelBuilder modelBuilder)
        {
            var id = 151;
            // var list = new[] {  "2018 - 2021", "2022 - 2025", "2026 - 2030" };
            var list = Enumerable.Range(2018, 12).ToList();
            var faker = new Faker<Realisation>(SeedingData.lang)
                .CustomInstantiator(f => new Realisation { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 2} بعد الإنجازات لبعض الأنشطة ")
                .RuleFor(o => o.Situation, f => $"{id - 2} وضعية التنفيد لهدا الإنجاز")
                .RuleFor(o => o.Annee, f => f.PickRandom(list))
                .RuleFor(o => o.Taux, f => $"{id - 2} معدل الإنجاز لهدا الإنجاز")
                .RuleFor(o => o.TauxRealisation, f => f.Random.Number(1, 99))
                .RuleFor(o => o.Effet, f => $"{id - 2} التأثير لهدا الإنجاز")
                .RuleFor(o => o.IdActivite, f => f.Random.Number(51, 100))
                ;

            modelBuilder.Entity<Realisation>().HasData(faker.Generate(50));

            var faker2 = new Faker<Realisation>(SeedingData.lang)
                .CustomInstantiator(f => new Realisation { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 2} بعد الإنجازات لبعض الأنشطة ")
                .RuleFor(o => o.Situation, f => $"{id - 2} وضعية التنفيد لهدا الإنجاز")
                .RuleFor(o => o.Annee, f => f.PickRandom(list))
                .RuleFor(o => o.Taux, f => $"{id - 2} معدل الإنجاز لهدا الإنجاز")
                .RuleFor(o => o.TauxRealisation, 100)
                .RuleFor(o => o.Effet, f => $"{id - 2} التأثير لهدا الإنجاز")
                .RuleFor(o => o.IdActivite, f => f.Random.Number(51, 100))

                ;

            modelBuilder.Entity<Realisation>().HasData(faker2.Generate(10));

            var faker3 = new Faker<Realisation>(SeedingData.lang)
                .CustomInstantiator(f => new Realisation { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 2} بعد الإنجازات لبعض الأنشطة ")
                .RuleFor(o => o.Situation, f => $"{id - 2} وضعية التنفيد لهدا الإنجاز")
                .RuleFor(o => o.Annee, f => f.PickRandom(list))
                .RuleFor(o => o.Taux, f => $"{id - 2} معدل الإنجاز لهدا الإنجاز")
                .RuleFor(o => o.TauxRealisation, 0)
                .RuleFor(o => o.Effet, f => $"{id - 2} التأثير لهدا الإنجاز")
                 .RuleFor(o => o.IdActivite, f => f.Random.Number(51, 100))

                ;

            modelBuilder.Entity<Realisation>().HasData(faker3.Generate(10));


            return modelBuilder;
        }

        public static ModelBuilder RealisationsSociete(this ModelBuilder modelBuilder)
        {
            var id = 221;
            // var list = new[] {  "2018 - 2021", "2022 - 2025", "2026 - 2030" };
            var list = Enumerable.Range(2018, 12).ToList();
            var faker = new Faker<Realisation>(SeedingData.lang)
                .CustomInstantiator(f => new Realisation { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 2} بعد الإنجازات لبعض الأنشطة ")
                .RuleFor(o => o.Situation, f => $"{id - 2} وضعية التنفيد لهدا الإنجاز")
                .RuleFor(o => o.Annee, f => f.PickRandom(list))
                .RuleFor(o => o.Taux, f => $"{id - 2} معدل الإنجاز لهدا الإنجاز")
                .RuleFor(o => o.TauxRealisation, f => f.Random.Number(1, 99))
                .RuleFor(o => o.Effet, f => $"{id - 2} التأثير لهدا الإنجاز")
                .RuleFor(o => o.IdActivite, f => f.Random.Number(101, 150))
                ;

            modelBuilder.Entity<Realisation>().HasData(faker.Generate(50));

            var faker2 = new Faker<Realisation>(SeedingData.lang)
                .CustomInstantiator(f => new Realisation { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 2} بعد الإنجازات لبعض الأنشطة ")
                .RuleFor(o => o.Situation, f => $"{id - 2} وضعية التنفيد لهدا الإنجاز")
                .RuleFor(o => o.Annee, f => f.PickRandom(list))
                .RuleFor(o => o.Taux, f => $"{id - 2} معدل الإنجاز لهدا الإنجاز")
                .RuleFor(o => o.TauxRealisation, 100)
                .RuleFor(o => o.Effet, f => $"{id - 2} التأثير لهدا الإنجاز")
                .RuleFor(o => o.IdActivite, f => f.Random.Number(101, 150))


                ;

            modelBuilder.Entity<Realisation>().HasData(faker2.Generate(10));

            var faker3 = new Faker<Realisation>(SeedingData.lang)
                .CustomInstantiator(f => new Realisation { Id = id++ })
                .RuleFor(o => o.Nom, f => $"{id - 2} بعد الإنجازات لبعض الأنشطة ")
                .RuleFor(o => o.Situation, f => $"{id - 2} وضعية التنفيد لهدا الإنجاز")
                .RuleFor(o => o.Annee, f => f.PickRandom(list))
                .RuleFor(o => o.Taux, f => $"{id - 2} معدل الإنجاز لهدا الإنجاز")
                .RuleFor(o => o.TauxRealisation, 0)
                .RuleFor(o => o.Effet, f => $"{id - 2} التأثير لهدا الإنجاز")
                .RuleFor(o => o.IdActivite, f => f.Random.Number(101, 150))


                ;

            modelBuilder.Entity<Realisation>().HasData(faker3.Generate(10));


            return modelBuilder;
        }




    }
}
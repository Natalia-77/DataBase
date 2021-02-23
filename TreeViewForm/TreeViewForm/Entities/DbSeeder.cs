using System.Linq;


namespace TreeViewForm.Entities
{
    public class DbSeeder
    {
        public static void SeedDatabase(MyContext context)
        {
            SeedBreed(context);
        }

        #region Add categories of products.
        private static void SeedBreed(MyContext context)
        {
            if (context.Cosmetics.Count() == 0)
            {
                string urlSlug = "shampoo";
                AddParent(context, urlSlug, "Шампунь");
                AddChild(context, urlSlug, "chistaya linia", "Чистая линия");
                AddChild(context, urlSlug, "krya-krya", "Кря-Кря");
                AddChild(context, urlSlug, "loreal", "Лореаль");

                urlSlug = "loreal";
                AddChild(context, urlSlug, "elseve", "Ельсев");
                AddChild(context, urlSlug, "morocan", "Moroccan");

                urlSlug = "soap";
                AddParent(context, urlSlug, "Мило");
                AddChild(context, urlSlug, "lavander", "Лавандове");
                AddChild(context, urlSlug, "honey", "Медове");

                urlSlug = "cream";
                AddParent(context, urlSlug, "Крем");
                AddChild(context, urlSlug, "hands", "Бархатні ручки");
                AddChild(context, urlSlug, "baby", "Дитячий крем");

                urlSlug = "hands";
                AddChild(context, urlSlug, "soft", "Для чутливої шкіри");
                AddChild(context, urlSlug, "avocado", "З авокадо");


            }
        }
        private static void AddParent(MyContext context, string urlSlug, string name)
        {
            context.Cosmetics.Add(new Cosmetic
            {
                Name = name,
                ParentId = null,
                UrlSlug = urlSlug
            });
            context.SaveChanges();
        }

        private static void AddChild(MyContext context, string parentSlug, string urlSlug, string name)
        {
            var parent = context.Cosmetics.SingleOrDefault(x => x.UrlSlug == parentSlug);
            context.Cosmetics.Add(new Cosmetic
            {
                Name = name,
                ParentId = parent.Id,
                UrlSlug = urlSlug
            });
            context.SaveChanges();
        }
        #endregion
    }
}

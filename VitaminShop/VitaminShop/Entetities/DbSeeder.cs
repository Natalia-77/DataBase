using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VitaminShop.Entetities
{
    public class DbSeeder
    {
        public static void SeedDatabase(MyContext context)
        {
            SeedFilters(context);
        }

        private static void SeedFilters(MyContext context)
        {
            #region Name of filters
            string[] filterNames = { "Бренди", "Форма випуску", "Смак" };
            foreach (var type in filterNames)
            {
                if (context.FilterNames.SingleOrDefault(f => f.Name == type) == null)
                {
                    context.FilterNames.Add(
                        new FilterName
                        {
                            Name = type
                        });
                    context.SaveChanges();
                }
            }
            #endregion

            #region Values of filters
            List<string[]> filterValues = new List<string[]> {
                new string [] { "Now Foods", "Solgar", "Life Extension","Nature's","Dragon Herbs" },
                new string [] { "таблетка", "капсула", "крем", "рідина" },
                new string [] { "малина", "фрукти", "без смаку","вишня","асорті","натуральна ягода" }
            };
            foreach (var items in filterValues)
            {
                foreach (var value in items)
                {
                    if (context.FilterValues
                        .SingleOrDefault(f => f.Name == value) == null)
                    {
                        context.FilterValues.Add(
                            new FilterValue
                            {
                                Name = value
                            });
                        context.SaveChanges();
                    }
                }
            }
            #endregion

            #region Group of filters

            for (int i = 0; i < filterNames.Length; i++)
            {
                foreach (var value in filterValues[i])
                {
                    var nId = context.FilterNames
                        .SingleOrDefault(fname => fname.Name == filterNames[i]).Id;
                    var vId = context.FilterValues
                        .SingleOrDefault(fvalue => fvalue.Name == value).Id;
                    if (context.FilterNameGroups
                        .SingleOrDefault(f => f.FilterValueId == vId &&
                        f.FilterNameId == nId) == null)
                    {
                        context.FilterNameGroups.Add(
                            new FilterNameGroup
                            {
                                FilterNameId = nId,
                                FilterValueId = vId
                            });
                        context.SaveChanges();
                    }
                }
            }

            #endregion

            #region Add products
            List<string> uniuqe = new List<string>()
            {"so25",
            "sol88",
            "nf77",
            "le85",
            "Dh11",
            "Hy33"
            };

           // var name_unique = new Faker("en");

           // var listname = Enumerable.Range(1, 6)
           //.Select(_ =>  name_unique.Lorem.Word())
           //.ToList();
            

            if (context.Products.SingleOrDefault(f => f.UniqueName == uniuqe[0]) == null)
                context.Products.Add(
                        new Product
                        {
                            UniqueName = uniuqe[0],
                            Price = 548,
                            Image = "https://s3.images-iherb.com/sol/sol01736/y/47.jpg",
                            Name = "Solgar, кожа, ногти и волосы, улучшенная формула с МСМ, 120 таблеток"
                        });

            if (context.Products.SingleOrDefault(f => f.UniqueName == uniuqe[1]) == null)
                context.Products.Add(
                        new Product
                        {
                            UniqueName = uniuqe[1],
                            Price = 425,
                            Image = "https://s3.images-iherb.com/sol/sol35872/y/116.jpg",
                            Name = "Solgar, витамин D3(холекальциферол), 250 мкг, 120 капсул "
                        });

            if (context.Products.SingleOrDefault(f => f.UniqueName == uniuqe[2]) == null)
                context.Products.Add(
                        new Product
                        {
                            UniqueName = uniuqe[2],
                            Price = 320,
                            Image = "https://s3.images-iherb.com/now/now00373/y/26.jpg",
                            Name = "Now Foods, высокоактивный витамин D3, 5000 МЕ, 240 капсул "
                        });

            if (context.Products.SingleOrDefault(f => f.UniqueName == uniuqe[3]) == null)
                context.Products.Add(
                        new Product
                        {
                            UniqueName = uniuqe[3],
                            Price = 1130,
                            Image = "https://s3.images-iherb.com/lex/lex80148/y/83.jpg",
                            Name = "Life Extension, Cosmesis Skin Care, подтягивающий и укрепляющий крем для шеи"
                        });
            if (context.Products.SingleOrDefault(f => f.UniqueName == uniuqe[4]) == null)
                context.Products.Add(
                        new Product
                        {
                            UniqueName = uniuqe[4],
                            Price = 1720,
                            Image = "https://s3.images-iherb.com/dra/dra00516/y/24.jpg",
                            Name = "Dragon Herbs, Плацента оленя, 500 мг, 60 капсул"
                        });
            if (context.Products.SingleOrDefault(f => f.UniqueName == uniuqe[5]) == null)
                context.Products.Add(
                        new Product
                        {
                            UniqueName = uniuqe[5],
                            Price = 520,
                            Image = "https://s3.images-iherb.com/nap/nap30841/y/4.jpg",
                            Name = "Nature's, Source of Life, жидкая добавка, со вкусом фруктов, 887,10 мл"
                        });
            context.SaveChanges();
            #endregion

            #region Filters
            Filter[] filters =
            {
                new Filter { FilterNameId =1,FilterValueId=2,ProductId=1},
                new Filter { FilterNameId =2,FilterValueId=6,ProductId=1},
                new Filter { FilterNameId =3,FilterValueId=12,ProductId=1},

                new Filter { FilterNameId =1,FilterValueId=2,ProductId=2},
                new Filter { FilterNameId =2,FilterValueId=7,ProductId=2},
                new Filter { FilterNameId =3,FilterValueId=12,ProductId=2},

                new Filter { FilterNameId =1,FilterValueId=1,ProductId=3},
                new Filter { FilterNameId =2,FilterValueId=7,ProductId=3},
                new Filter { FilterNameId =3,FilterValueId=14,ProductId=3},

                new Filter { FilterNameId =1,FilterValueId=3,ProductId=4},
                new Filter { FilterNameId =2,FilterValueId=8,ProductId=4},

                new Filter { FilterNameId =1,FilterValueId=5,ProductId=5},
                new Filter { FilterNameId =2,FilterValueId=7,ProductId=5},
                new Filter { FilterNameId =3,FilterValueId=12,ProductId=5},

                new Filter { FilterNameId =1,FilterValueId=4,ProductId=6},
                new Filter { FilterNameId =2,FilterValueId=9,ProductId=6},
                new Filter { FilterNameId =3,FilterValueId=11,ProductId=6}
            };
            foreach (var item in filters)
            {
                var f = context.Filters.SingleOrDefault(p => p == item);
                if (f == null)
                {
                    context.Filters.Add(new Filter { FilterNameId = item.FilterNameId, FilterValueId = item.FilterValueId, ProductId = item.ProductId });
                    context.SaveChanges();
                }
            }
            #endregion
        }

    }
}

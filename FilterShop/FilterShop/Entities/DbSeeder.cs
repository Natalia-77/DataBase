using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterShop.Entities
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
        }
    }
}

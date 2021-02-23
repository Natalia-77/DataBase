using System.Collections.Generic;
using System.Linq;
using TreeViewForm.Models;

namespace TreeViewForm.Helpers
{
    public static class CosmeticHelper
    {
        public static IList<CosmeticGroupVM> BuildTree(this IEnumerable<CosmeticGroupVM> source)
        {
            var groups = source.GroupBy(i => i.ParentId);

            var roots = groups.FirstOrDefault(g => g.Key.HasValue == false).ToList();

            if (roots.Count > 0)
            {
                var dict = groups.Where(g => g.Key.HasValue).ToDictionary(g => g.Key.Value, g => g.ToList());
                for (int i = 0; i < roots.Count; i++)
                    AddChildren(roots[i], dict);
            }

            return roots;
        }

        private static void AddChildren(CosmeticGroupVM node, IDictionary<int, List<CosmeticGroupVM>> source)
        {
            if (source.ContainsKey(node.Id))
            {
                node.Children = source[node.Id];
                for (int i = 0; i < node.Children.Count; i++)
                    AddChildren(node.Children[i], source);
            }
            else
            {
                node.Children = new List<CosmeticGroupVM>();
            }
        }

    }
}

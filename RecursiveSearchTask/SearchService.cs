using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveSearchTask
{
    public static class SearchService
    {
        public static string GetParentWithKeywords(int categoryId)
        {
            var categories = Category.GetTestData();
            var categoriesDic = categories.ToDictionary(x => x.Id);

            if (!categoriesDic.TryGetValue(categoryId, out var category))
                return string.Empty;

            var keyword = GetKeyword(category, categoriesDic)
                .Select(c => c.Keywords)
                .FirstOrDefault(k => !string.IsNullOrWhiteSpace(k))
                ?? string.Empty;

            return $"ParentCategoryID={category.ParentCategoryId}, Name={category.Name}, Keywords={keyword}";
        }

        public static string GetCategoryByNLvl(int lvl)
        {

            if (lvl < 1)
                throw new Exception("Level must be greater that 1");

            var categories = Category.GetTestData();

            //TODO: May be change to Lookup but I like a TryGetValue
            var categoriesDic = categories.GroupBy(c => c.ParentCategoryId)
                .ToDictionary(g => g.Key, g => g.Select(x => x.Id).ToList());

            if(!categoriesDic.TryGetValue(-1, out var currentLvl))
                return string.Empty;
            
            if (lvl == 1)
                return string.Join(",", currentLvl);

            for (int l = 2; l <= lvl; l++)
            {
                var next = new List<int>();

                foreach (var c in currentLvl)
                {
                    if (categoriesDic.TryGetValue(c, out var children))
                        next.AddRange(children);
                }

                currentLvl = next;
            }
            return string.Join(",", currentLvl);
        }

        public static string GetCategoryByNLvlOprimization(int lvl)
        {

        }


        private static IEnumerable<Category> GetKeyword(Category category, IReadOnlyDictionary<int, Category> categoriesDic)
        {

            while (category != null)
            {
                yield return category;

                if (category.ParentCategoryId == -1)
                    yield break;

                if (!categoriesDic.TryGetValue(category.ParentCategoryId, out category))
                    yield break;
            }
        }
    }
}

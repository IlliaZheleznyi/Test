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

        public static string GetCategoryByNLvl(int level)
        {
            if (level < 1)
                throw new Exception("Level must be greater than 1");

            var firstLevelId = -1;
            var categories = Category.GetTestData();

            var lookupCategories = categories.ToLookup(c => c.ParentCategoryId);

            var current = lookupCategories[firstLevelId];

            if (level != 1)
            {
                for (int l = 2; l <= level; l++)
                {
                    current = current.SelectMany(c => lookupCategories[c.Id]);
                }
            }

            return string.Join(",", current.Select(x => x.Id));
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

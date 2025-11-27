namespace RecursiveSearchTask
{
    public class Category
    {
        public int Id { get; set; }
        public int ParentCategoryId { get; set; } = -1;
        public string Name { get; set; }
        public string Keywords { get; set; }

        public static Category[] GetTestData()
        {
            return new[]
            {
                new Category { Id = 100, ParentCategoryId = -1, Name = "Business", Keywords = "Money" },
                new Category { Id = 200, ParentCategoryId = -1, Name = "Tutoring", Keywords = "Teaching" },
                new Category { Id = 101, ParentCategoryId = 100, Name = "Accounting", Keywords = "Taxes" },
                new Category { Id = 102, ParentCategoryId = 100, Name = "Taxation", Keywords = null },
                new Category { Id = 201, ParentCategoryId = 200, Name = "Computer", Keywords = null },
                new Category { Id = 103, ParentCategoryId = 101, Name = "Corporate Tax", Keywords = null },
                new Category { Id = 202, ParentCategoryId = 201, Name = "Operating System", Keywords = null },
                new Category { Id = 109, ParentCategoryId = 101, Name = "Small Business Tax", Keywords = null },
            };
        }
    }
}

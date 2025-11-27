// I don't have anought task information about source of data. I will provide 2 solutions for data from db and from memorry 

using RecursiveSearchTask;

Console.WriteLine("Task 1");
Console.WriteLine(SearchService.GetParentWithKeywords(201));
Console.WriteLine(SearchService.GetParentWithKeywords(202));

Console.WriteLine("_");
Console.WriteLine("Task 2");
//Validation check
//Console.WriteLine(SearchService.GetCategoryByNLvl(0));
Console.WriteLine(SearchService.GetCategoryByNLvl(1));
Console.WriteLine(SearchService.GetCategoryByNLvl(2));
Console.WriteLine(SearchService.GetCategoryByNLvl(3));
Console.WriteLine(SearchService.GetCategoryByNLvl(4));


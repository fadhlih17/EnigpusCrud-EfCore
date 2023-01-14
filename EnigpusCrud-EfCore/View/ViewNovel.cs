using EnigpusCrud_EfCore.Entities;
using EnigpusCrud_EfCore.Repositories;
using EnigpusCrud_EfCore.Services;

namespace EnigpusCrud_EfCore.View;

public class ViewNovel
{
    private static AppDbContext _appDbContext = new AppDbContext();
    private static IPersistance _persistance = new Persistance(_appDbContext);
    private static INovelRepository _novelRepository = new NovelRepository(_appDbContext);

    private INovelService _novelService = new NovelService(_novelRepository, _persistance);
    private Random _random = new Random();

    public void NovelMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("***** Novel Menu ****");
            Console.WriteLine(@"1. Get All Novels
2. Search Novel By Id
3. Search Novel By Name
4. Create New Novel
5. Update Novel
6. Delete Novel
7. Exit");
            try
            {
                Console.Write("Input your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1 : 
                        GetAllNovels();
                        break;
                    case 2 :
                        GetNovelById();
                        break;
                    case 3 :
                        GetNovelByTitle();
                        break;
                    case 4 :
                        CreateNovel();
                        break;
                    case 5 :
                        UpdateAllNovel();
                        break;
                    case 6 :
                        DeleteNovel();
                        break;
                    case 7 :
                        return;
                    default:
                        Console.WriteLine("No Choices");
                        Console.ReadKey();
                        break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Wrong Format Input");
                Console.ReadKey();
            }
        }
    }
    
    public void CreateNovel()
    {
        Console.WriteLine("===== Create New Novel =====");
        try
        {
            Console.Write("Input Title: ");
            string title = Console.ReadLine();
            Console.Write("Input Publisher: ");
            string publisher = Console.ReadLine();
            Console.Write("Input Publish Year: ");
            int publishYear = int.Parse(Console.ReadLine());
            Console.Write("Input Writer: ");
            string writer = Console.ReadLine();
            
            string id = $"{publishYear}-A-{_random.Next(10000, 99999)}";
            var createNovel = new Novel
            {
                Id = id,
                Title = title,
                Publisher = publisher,
                PublishYear = publishYear,
                Writer = writer
            };
            
            _novelService.CreateNovel(createNovel);
            Console.WriteLine("Success Create Data");
        }
        catch (Exception e)
        {
            //Ignore
        }

        Console.ReadKey();
    }

    public void GetAllNovels()
    {
        Console.WriteLine("===== All Novel Data =====");
        Console.WriteLine("Id\t\tTitle\t\tPublisher\t\tPublish Year\t\tWriter");
        var novels = _novelService.GetAllNovels();
        foreach (var novel in novels)
        {
            Console.WriteLine($"{novel.Id}\t{novel.Title}\t{novel.Publisher}\t\t{novel.PublishYear}\t\t{novel.Writer}");
        }

        Console.ReadKey();
    }

    public void GetNovelById()
    {
        Console.WriteLine("===== Search Novel By Id =====");
        Console.Write("Input Novel Id: ");
        string id = Console.ReadLine();
        
        try
        {
            var novel = _novelService.GetNovelById(id);
            Console.WriteLine($"Title: {novel.Title}");
            Console.WriteLine($"Publisher: {novel.Publisher}");
            Console.WriteLine($"Publish Year: {novel.PublishYear}");
            Console.WriteLine($"Writer: {novel.Writer}");
        }
        catch (Exception e)
        {
            //Ignore
        }

        Console.ReadKey();
    }

    public void GetNovelByTitle()
    {
        Console.WriteLine("===== Search Novel By Title =====");
        Console.Write("Input Title: ");
        string name = Console.ReadLine();

        try
        {
            var novel = _novelService.GetNovelByTitle(name);
            Console.WriteLine($"Id: {novel.Id}");
            Console.WriteLine($"Publisher: {novel.Publisher}");
            Console.WriteLine($"Publish Year: {novel.PublishYear}");
            Console.WriteLine($"Writer: {novel.Writer}");
        }
        catch (Exception e)
        {
            // Ignore
        }

        Console.ReadKey();
    }

    public void UpdateAllNovel()
    {
        Console.WriteLine("===== Update All Novel =====");
        Console.Write("Input Id to Update: ");
        string id = Console.ReadLine();

        try
        {
            _novelService.GetNovelById(id);
            
            Console.Write("Input Title: ");
            string title = Console.ReadLine();
            Console.Write("Input Publisher: ");
            string publisher = Console.ReadLine();
            Console.Write("Input Publish Year: ");
            int publishYear = int.Parse(Console.ReadLine());
            Console.Write("Input Writer: ");
            string writer = Console.ReadLine();

            var updateNovel = new Novel
            {
                Id = id,
                Title = title,
                Publisher = publisher,
                PublishYear = publishYear,
                Writer = writer
            };
            
            _novelService.UpdateNovel(updateNovel);
            Console.WriteLine("Success Update Data");
        }
        catch (Exception e)
        {
            //Ignore
        }

        Console.ReadKey();
    }
    public void DeleteNovel()
    {
        Console.WriteLine("===== Delete Novel =====");
        Console.Write("Input Id to Delete: ");
        string id = Console.ReadLine();
        try
        {
            _novelService.DeleteNovel(id);
            Console.WriteLine("Success Delete Data");
        }
        catch (Exception e)
        {
            //Ignore
        }

        Console.ReadKey();
    }
}
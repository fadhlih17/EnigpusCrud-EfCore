using EnigpusCrud_EfCore.Entities;
using EnigpusCrud_EfCore.Repositories;
using EnigpusCrud_EfCore.Services;

namespace EnigpusCrud_EfCore.View;

public class ViewMagazine
{
    private static AppDbContext _appDbContext = new AppDbContext();
    private static IPersistance _persistance = new Persistance(_appDbContext);
    private static IMagazineRepository _magazineRepository = new MagazineRepository(_appDbContext);

    private IMagazineService _magazineService = new MagazineService(_magazineRepository, _persistance);
    private Random _random = new Random();

    public void MagazineMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("***** Magazine Menu ****");
            Console.WriteLine(@"1. Get All Magazines
2. Search Magazine By Id
3. Search Magazine By Title
4. Create New Magazine
5. Update Magazine
6. Delete Magazine
7. Exit");
            try
            {
                Console.Write("Input your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1 : 
                        GetAllMagazines();
                        break;
                    case 2 :
                        GetMagazineById();
                        break;
                    case 3 :
                        GetMagazineByTitle();
                        break;
                    case 4 :
                        CreateMagazine();
                        break;
                    case 5 :
                        UpdateAllMagazine();
                        break;
                    case 6 :
                        DeleteMagazine();
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
    
    public void CreateMagazine()
    {
        Console.WriteLine("===== Create New Magazine =====");
        try
        {
            Console.Write("Input Title: ");
            string title = Console.ReadLine();
            Console.Write("Input Publish period: ");
            string PublishPeriode = Console.ReadLine();
            Console.Write("Input Publish Year: ");
            int yearPeriode = int.Parse(Console.ReadLine());

            string id = $"{yearPeriode}-B-{_random.Next(10000, 99999)}";

            var newMagazine = new Magazine
            {
                Id = id,
                Title = title,
                PublishPeriod = PublishPeriode,
                YearPeriod = yearPeriode
                
            };
            
            _magazineService.CreateNewMagazine(newMagazine);
            Console.WriteLine("Success Create Data");
        }
        catch (Exception e)
        {
            //Ignore
        }

        Console.ReadKey();
    }

    public void GetAllMagazines()
    {
        Console.WriteLine("===== All Magazine Data =====");
        Console.WriteLine("Id\t\tTitle\t\tPublish Periode\t\tYear Periode");
        var magazines = _magazineService.GetAllMagazines();
        foreach (var magazine in magazines)
        {
            Console.WriteLine($"{magazine.Id}\t{magazine.Title}\t\t{magazine.PublishPeriod}\t\t{magazine.YearPeriod}");
        }

        Console.ReadKey();
    }

    public void GetMagazineById()
    {
        Console.WriteLine("===== Search Magazine By Id =====");
        Console.Write("Input Magazine Id: ");
        string id = Console.ReadLine();
        
        try
        {
            var magazine = _magazineService.GetMagazineById(id);
            Console.WriteLine($"Title: {magazine.Title}");
            Console.WriteLine($"Publish Period: {magazine.PublishPeriod}");
            Console.WriteLine($"Year Publish: {magazine.YearPeriod}");
        }
        catch (Exception e)
        {
            //Ignore
        }

        Console.ReadKey();
    }

    public void GetMagazineByTitle()
    {
        Console.WriteLine("===== Search Magazine By Title =====");
        Console.Write("Input Name: ");
        string name = Console.ReadLine();

        try
        {
            var magazine = _magazineService.GetMagazineByTitle(name);
            Console.WriteLine($"Id: {magazine.Id}");
            Console.WriteLine($"Publish Period: {magazine.PublishPeriod}");
            Console.WriteLine($"Year Publish: {magazine.YearPeriod}");
        }
        catch (Exception e)
        {
            // Ignore
        }

        Console.ReadKey();
    }

    public void UpdateAllMagazine()
    {
        Console.WriteLine("===== Update All Magazine =====");
        Console.Write("Input Id to Update: ");
        string id = Console.ReadLine();

        try
        {
            _magazineService.GetMagazineById(id);
            
            Console.Write("Input Title: ");
            string title = Console.ReadLine();
            Console.Write("Input Publish Period: ");
            string PublishPeriode = Console.ReadLine();
            Console.Write("Input Year Publish: ");
            int yearPublish = int.Parse(Console.ReadLine());

            var updateMagazine = new Magazine
            {
                Id = id,
                Title = title,
                PublishPeriod = PublishPeriode,
                YearPeriod = yearPublish
            };
            
            _magazineService.UpdateMagazine(updateMagazine);
            Console.WriteLine("Success Update Data");
        }
        catch (Exception e)
        {
            //Ignore
        }

        Console.ReadKey();
    }
    public void DeleteMagazine()
    {
        Console.WriteLine("===== Delete Magazine =====");
        Console.Write("Input Id to Delete: ");
        string id = Console.ReadLine();
        try
        {
            _magazineService.DeleteMagazine(id);
            Console.WriteLine("Success Delete Data");
        }
        catch (Exception e)
        {
            //Ignore
        }

        Console.ReadKey();
    }
}
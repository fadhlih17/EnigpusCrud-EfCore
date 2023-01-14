namespace EnigpusCrud_EfCore.View;

public class ViewMain
{
    public void Menu()
    {
        ViewMagazine viewMagazine = new ViewMagazine();
        ViewNovel viewNovel = new ViewNovel();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Enigpus =====");
            Console.WriteLine("1. Choose Novel Menu");
            Console.WriteLine("2. Choose Magazine Menu");
            Console.WriteLine("3. Exit");
            
            try
            {
                Console.Write("Input Your Choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1 :
                        viewNovel.NovelMenu();
                        break;
                    case 2 :
                        viewMagazine.MagazineMenu();
                        break;
                    case 3 :
                        return;
                    default:
                        Console.WriteLine("There is no choices");
                        Console.ReadKey();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong input format");
                Console.ReadKey();
            }
        }
    }
}
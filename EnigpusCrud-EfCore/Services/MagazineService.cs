using EnigpusCrud_EfCore.Entities;
using EnigpusCrud_EfCore.Repositories;

namespace EnigpusCrud_EfCore.Services;

public class MagazineService : IMagazineService
{
    private IMagazineRepository _magazineRepository;
    private IPersistance _persistance;

    public MagazineService(IMagazineRepository magazineRepository, IPersistance persistance)
    {
        _magazineRepository = magazineRepository;
        _persistance = persistance;
    }
    
    public List<Magazine> GetAllMagazines()
    {
        return _magazineRepository.GetAll().ToList();
    }

    public Magazine? GetMagazineById(string id)
    {
        try
        {
            var magazine = _magazineRepository.GetById(id);
            if (magazine is null) throw new Exception("Data Not Found");
            return magazine;
        }
        catch (Exception e)
        {
            Console.WriteLine("Magazine Id Not Found");
            throw;
        }
    }

    public Magazine? GetMagazineByTitle(string name)
    {
        try
        {
            var magazine = _magazineRepository.GetByTitle(name);
            if (magazine is null) throw new Exception("Data Not Found");
            return magazine;
        }
        catch (Exception e)
        {
            Console.WriteLine("Magazine Title Not Found");
            throw;
        }
    }

    public void CreateNewMagazine(Magazine magazine)
    {
        try
        {
            _magazineRepository.Create(magazine);
            _persistance.SaveChanges();
            
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed Create Magazine");
        }
    }

    public void UpdateMagazine(Magazine magazine)
    {
        try
        {
            var currentMagazine = GetMagazineById(magazine.Id);
            currentMagazine.Title = magazine.Title is not null or "" ? magazine.Title : currentMagazine.Title;
            currentMagazine.PublishPeriod = magazine.PublishPeriod is not null or ""
                ? magazine.PublishPeriod
                : currentMagazine.PublishPeriod;
            currentMagazine.YearPeriod = magazine.YearPeriod != null ? magazine.YearPeriod : currentMagazine.YearPeriod;
            _persistance.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed Update Magazine");
        }
    }

    public void DeleteMagazine(string id)
    {
        try
        {
            var deleteId = GetMagazineById(id);
            _magazineRepository.Delete(deleteId);
            _persistance.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed Delete Magazine");
        }
    }
}
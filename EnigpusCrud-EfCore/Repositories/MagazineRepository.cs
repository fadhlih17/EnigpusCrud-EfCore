using EnigpusCrud_EfCore.Entities;

namespace EnigpusCrud_EfCore.Repositories;

public class MagazineRepository : IMagazineRepository
{
    private AppDbContext _appDbContext;

    public MagazineRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public List<Magazine> GetAll()
    {
        return _appDbContext.Magazines.ToList();
    }

    public Magazine? GetById(string id)
    {
        return _appDbContext.Magazines.FirstOrDefault(magazine => magazine.Id.Equals(id));
    }

    public Magazine? GetByTitle(string title)
    {
        return _appDbContext.Magazines.FirstOrDefault(magazine => magazine.Title.Equals(title));
    }

    public void Create(Magazine magazine)
    {
        _appDbContext.Magazines.Add(magazine);
    }

    public void Update(Magazine magazine)
    {
        _appDbContext.Magazines.Update(magazine);
    }

    public void Delete(Magazine magazine)
    {
        _appDbContext.Magazines.Remove(magazine);
    }
}
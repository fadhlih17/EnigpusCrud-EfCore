namespace EnigpusCrud_EfCore.Repositories;

public class Persistance : IPersistance
{
    private AppDbContext _appDbContext;

    public Persistance(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public void SaveChanges()
    {
        _appDbContext.SaveChanges();
    }
}
using EnigpusCrud_EfCore.Entities;

namespace EnigpusCrud_EfCore.Repositories;

public interface IMagazineRepository
{
    public List<Magazine> GetAll();
    public Magazine? GetById(string id);
    public Magazine? GetByTitle(string title);
    public void Create(Magazine magazine);
    public void Update(Magazine magazine);
    public void Delete(Magazine magazine);
}
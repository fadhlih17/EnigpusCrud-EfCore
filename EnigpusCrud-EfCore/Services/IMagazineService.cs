using EnigpusCrud_EfCore.Entities;
using EnigpusCrud_EfCore.Repositories;

namespace EnigpusCrud_EfCore.Services;

public interface IMagazineService
{
    public List<Magazine> GetAllMagazines();
    public Magazine? GetMagazineById(string id);
    public Magazine? GetMagazineByTitle(string name);
    public void CreateNewMagazine(Magazine magazine);
    public void UpdateMagazine(Magazine magazine);
    public void DeleteMagazine(string id);
}
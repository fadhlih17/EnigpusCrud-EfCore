using EnigpusCrud_EfCore.Entities;

namespace EnigpusCrud_EfCore.Repositories;

public interface INovelRepository
{
    public List<Novel> GetAll();
    public Novel? GetById(string id);
    public Novel? GetByTitle(string title);
    public void Create(Novel novel);
    public void Update(Novel novel);
    public void Delete(Novel novel);
}
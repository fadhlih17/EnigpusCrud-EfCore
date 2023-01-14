using EnigpusCrud_EfCore.Entities;

namespace EnigpusCrud_EfCore.Repositories;

public class NovelRepository : INovelRepository
{
    private AppDbContext _appDbContext;

    public NovelRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public List<Novel> GetAll()
    {
        return _appDbContext.Novels.ToList();
    }

    public Novel? GetById(string id)
    {
        return _appDbContext.Novels.FirstOrDefault(novel => novel.Id.Equals(id));
    }

    public Novel? GetByTitle(string title)
    {
        return _appDbContext.Novels.FirstOrDefault(novel => novel.Title.Equals(title));
    }

    public void Create(Novel novel)
    { 
        _appDbContext.Novels.Add(novel);
    }

    public void Update(Novel novel)
    {
        _appDbContext.Novels.Update(novel);
    }

    public void Delete(Novel novel)
    {
        _appDbContext.Novels.Remove(novel);
    }
}
using EnigpusCrud_EfCore.Entities;

namespace EnigpusCrud_EfCore.Services;

public interface INovelService
{
    public List<Novel> GetAllNovels();
    public Novel? GetNovelById(string id);
    public Novel? GetNovelByTitle(string title);
    public void CreateNovel(Novel novel);
    public void UpdateNovel(Novel novel);
    public void DeleteNovel(string id);
}
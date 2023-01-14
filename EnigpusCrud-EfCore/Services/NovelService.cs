using EnigpusCrud_EfCore.Entities;
using EnigpusCrud_EfCore.Repositories;

namespace EnigpusCrud_EfCore.Services;

public class NovelService : INovelService
{
    private INovelRepository _novelRepository;
    private IPersistance _persistance;

    public NovelService(INovelRepository novelRepository, IPersistance persistance)
    {
        _novelRepository = novelRepository;
        _persistance = persistance;
    }

    public List<Novel> GetAllNovels()
    {
        return _novelRepository.GetAll();
    }

    public Novel? GetNovelById(string id)
    {
        try
        {
            var novel = _novelRepository.GetById(id);
            if (novel is null) throw new Exception("Novel not found");
            return novel;
        }
        catch (Exception e)
        {
            Console.WriteLine("Data Not Found");
            throw;
        }
    }

    public Novel? GetNovelByTitle(string title)
    {
        try
        {
            var novel = _novelRepository.GetByTitle(title);
            if (novel is null) throw new Exception("Novel Not Found");
            return novel;
        }
        catch (Exception e)
        {
            Console.WriteLine("Data Not Found");
            throw;
        }
    }

    public void CreateNovel(Novel novel)
    {
        try
        {
            _novelRepository.Create(novel);
            _persistance.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed Create Novel");
            throw;
        }
    }

    public void UpdateNovel(Novel novel)
    {
        try
        {
            var currentNovel = GetNovelById(novel.Id);
            currentNovel.Title = novel.Title is not null or "" ? novel.Title : currentNovel.Title;
            currentNovel.Publisher = novel.Publisher is not null or "" ? novel.Publisher : currentNovel.Publisher;
            currentNovel.PublishYear = novel.PublishYear != null ? novel.PublishYear : currentNovel.PublishYear;
            currentNovel.Writer = novel.Writer is not null or ""? novel.Writer : currentNovel.Writer;
            _novelRepository.Update(currentNovel);
            _persistance.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed Save Novel");
            throw;
        }
    }

    public void DeleteNovel(string id)
    {
        try
        {
            var deleteNovel = GetNovelById(id);
            _novelRepository.Delete(deleteNovel);
            _persistance.SaveChanges();
            
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed Delete Novel");
            throw;
        }
    }
}
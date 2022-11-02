using BlogAPI.Models;

namespace BlogAPI.Utils.Repositories.Interfaces;

public interface IArtigoRepository
{
    public List<Artigo> Artigos { get; }

    Task<dynamic> FindById(int id);
}
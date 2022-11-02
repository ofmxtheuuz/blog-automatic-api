using BlogAPI.Database;
using BlogAPI.Models;
using BlogAPI.Utils.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Utils.Repositories;

public class ArtigoRepository : IArtigoRepository
{
    private readonly AplicationDbContext _aplicationDbContext;

    public ArtigoRepository(AplicationDbContext context)
    {
        this._aplicationDbContext = context;
    }

    public List<Artigo> Artigos => _aplicationDbContext.Artigos.ToList();
    
    public async Task<dynamic> FindById(int id)
    {
        Artigo artigo = await this._aplicationDbContext.Artigos.FirstOrDefaultAsync(art => art.ArtigoId == id);
        if (artigo == null) return false;
        return artigo;
    }
}
using BlogAPI.Http.Responses;
using BlogAPI.Models;
using BlogAPI.Utils.Repositories;
using BlogAPI.Utils.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

[ApiController]
[Route("v3")]
public class HomeController : ControllerBase
{
    private readonly IArtigoRepository _artigoRepository;

    public HomeController(IArtigoRepository artigoRepository)
    {
        _artigoRepository = artigoRepository;
    }
    
    [HttpGet("see")]
    public async Task<dynamic> See()
    {
        var artigos = _artigoRepository.Artigos;
        if (artigos.Count == 0) return NotFound();
        var seeResponses = new List<SeeResponse>();
        foreach (Artigo artigo in artigos)
        {
            seeResponses.Add(new()
            {
                ArtigoId = artigo.ArtigoId,
                Titulo = artigo.Titulo,
                Autor = artigo.Autor,
                DataDeEnvio = artigo.DataEnvio.ToString("F"),
                Link = $"https://localhost:7153/view/{artigo.ArtigoId}"
            });
        }

        return seeResponses;
    }
    
    [HttpGet("see/{id:int}")]
    public async Task<dynamic> See(int id)
    {
        var artigo = await _artigoRepository.FindById(id);
        if (!artigo) return BadRequest(); 
        return new SeeResponse()
        {
            ArtigoId = artigo.ArtigoId,
            Titulo = artigo.Titulo,
            Autor = artigo.Autor,
            DataDeEnvio = artigo.DataEnvio.ToString("F"),
            Link = $"https://localhost:7153/view/{artigo.ArtigoId}"
        };
    }
}

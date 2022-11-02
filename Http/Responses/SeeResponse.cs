namespace BlogAPI.Http.Responses;

public class SeeResponse
{
    public int ArtigoId { get; set; }
    public string Titulo { get; set; }
    public string Link { get; set; }
    public string Autor { get; set; }
    public string DataDeEnvio { get; set; }
}
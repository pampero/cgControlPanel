namespace Buscador.Domain
{
    public interface IKeywordsProvider
    {
        string GetParametersString(string parameters, string section);
    }
}
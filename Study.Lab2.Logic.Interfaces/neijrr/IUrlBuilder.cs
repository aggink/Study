namespace Study.Lab2.Logic.Interfaces.neijrr
{
    public interface IUrlBuilder
    {
        string BaseUrl { get; set; }
        string Url(List<object> path, string protocol = null, Dictionary<object, object> parameters = null);
    }
}

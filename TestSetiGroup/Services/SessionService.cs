using Newtonsoft.Json;

namespace TestSetiGroup.Services;

public sealed class SessionService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    private ISession Session => _httpContextAccessor.HttpContext.Session;

    
    public SessionService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public void Set(string key, object value)
    {
        Session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public T? Get<T>(string key)
    {
        var result = Session.GetString(key);
        
        return JsonConvert.DeserializeObject<T>(result ?? "");
    }
}
using Newtonsoft.Json;

namespace Application;

public class BaseCommand
{
    [JsonIgnore]
    public int Id { get; set; }
}
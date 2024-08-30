namespace Application.Stores.Queries;

public class StoreDto : BaseDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int Count { get; set; }		
}
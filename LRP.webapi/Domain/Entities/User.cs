namespace LRP.webapi.Domain.Entities;

public class User
{
    public int Id { get; set; }
        
    public string FirstName { get; set; }
        
    public string LastName { get; set; }
        
    public bool Active { get; set; }
}
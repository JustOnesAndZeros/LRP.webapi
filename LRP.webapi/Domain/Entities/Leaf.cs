namespace LRP.webapi.Domain.Entities;

public class Leaf
{
    public int Id { get; set; } //auto increment
        
    public User ModId { get; set; }
        
    public DateTime ModTime { get; set; }
        
    public int LeafId { get; set; }
        
    public bool Active { get; set; }
        
    public string DevSn { get; set; }
        
    public int NetAdd { get; set; }
        
    public int DevFwV { get; set; }
        
    public Patient PatientId { get; set; }
}
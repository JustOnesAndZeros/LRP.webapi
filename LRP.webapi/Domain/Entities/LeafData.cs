namespace LRP.webapi.Domain.Entities;

public class LeafData
{
    public int Id { get; set; }
        
    public User ModId { get; set; }
        
    public DateTime ModTime { get; set; }
        
    public Leaf LeafId { get; set; }

    public int MessageCount { get; set; }
        
    public int Ax { get; set; }
        
    public int Ay { get; set; }
        
    public int Az { get; set; }
        
    public int Capacita { get; set; }
        
    public bool Joined { get; set; }
}
namespace LRP.webapi.Domain.Entities;

public class Patient
{
    public int Id { get; set; } //auto increment
        
    public int PatientId { get; set; }
        
    public string FirstName { get; set; }
        
    public string LastName { get; set; }
        
    public decimal RollPercent { get; set; }
        
    public decimal TiltPercent { get; set; }
        
    public decimal UprightPercent { get; set; }
}
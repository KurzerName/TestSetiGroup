namespace TestSetiGroup.Models.Entity;

public class EntityModel
{
    public int Id { get; set; }
    
    public int ReportsTo { get; set; }
    
    public string Name { get; set; }
    
    public double Value { get; set; }
}
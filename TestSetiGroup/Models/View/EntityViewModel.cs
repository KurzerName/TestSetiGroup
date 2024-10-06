using System.ComponentModel.DataAnnotations;
using TestSetiGroup.Models.Entity;

namespace TestSetiGroup.Models;

public class EntityViewModel
{
    public EntityViewModel()
    {
        
    }
    
    public EntityViewModel(EntityModel entityModel)
    {
        Id = entityModel.Id;
        ReportsTo = entityModel.ReportsTo == 0 ? null : entityModel.ReportsTo;
        Value = entityModel.Value;
        ChildrenValues = entityModel.Value;
        Name = entityModel.Name;
    }

    
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    
    [ScaffoldColumn(false)]
    public int? ReportsTo { get; set; }
    
    [ScaffoldColumn(false)]

    public double Value { get; set; }

    [ScaffoldColumn(false)]
    public double ChildrenValues
    {
        get => _childrenValues;
        set => _childrenValues = Math.Round(value, 2);
    }

    [Required]
    public string Name { get; set; }

    private double _childrenValues = 0; 
}
using TestSetiGroup.Models;
using TestSetiGroup.Models.Entity;

namespace TestSetiGroup.Services;

public static class EntityService
{
    public static List<EntityViewModel> GetEntityViewModelList(List<EntityModel> entityList)
    {
        var entitiesViewModel = new List<EntityViewModel>();

        entityList.ForEach(entity =>
        {
            var vm = new EntityViewModel(entity);

            vm.ChildrenValues = vm.Value + GetChildrenValues(entityList, entity);
            
            entitiesViewModel.Add(vm);
        });

        return entitiesViewModel;
    }

    public static double GetChildrenValues(List<EntityModel> entityList, EntityModel entity)
    {
        double result = 0;

        var children = entityList.Where(e => e.ReportsTo == entity.Id);

        foreach (var child in children)
        {
            result += child.Value;

            if (entityList.Any(e => e.Id == child.Id))
            {
                result += GetChildrenValues(entityList, child);
            }
        }
        
        return result;
    }

    public static void RemoveChildren(List<EntityModel> entityList, int entityId)
    {
        var children = entityList.Where(e => e.ReportsTo == entityId).ToList();

        foreach (var child in children)
        {
            if (entityList.Any(e => e.ReportsTo == child.Id))
            {
                RemoveChildren(entityList, child.Id);
            }
            
            entityList.Remove(child);
        }
    }
}
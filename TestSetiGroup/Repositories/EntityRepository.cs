using TestSetiGroup.Constants;
using TestSetiGroup.Mock;
using TestSetiGroup.Models.Entity;
using TestSetiGroup.Services;

namespace TestSetiGroup.Repositories;

public class EntityRepository
{
    private readonly SessionService _sessionService;
    
    public EntityRepository(SessionService sessionService)
    {
        _sessionService = sessionService;
    }

    public List<EntityModel> GetAllFromSession()
    {
        var entityEnumerable = _sessionService.Get<List<EntityModel>>(SessionServiceConstants.ENTITY_LIST_KEY);

        if (entityEnumerable == null)
        {
            entityEnumerable = EntityMock.GetEntities();
            
            _sessionService.Set(SessionServiceConstants.ENTITY_LIST_KEY, entityEnumerable);
        }
        
        return entityEnumerable;
    }
    
    public void Add(EntityModel entity)
    {
        var all = GetAllFromSession();
        
        all.Add(entity);
        
        _sessionService.Set(SessionServiceConstants.ENTITY_LIST_KEY, all);
    }

    public void Update(int id, string name, double value)
    {
        var allEntities = GetAllFromSession();
        var entity = allEntities.FirstOrDefault(e => e.Id == id);

        if (entity == null)
        {
            throw new Exception("Не была найдена сущность");
        }
                
        entity.Name = name;
        entity.Value = value;
        
        _sessionService.Set(SessionServiceConstants.ENTITY_LIST_KEY, allEntities);
        
    }

    public void Delete(int id)
    {
        var all = GetAllFromSession();
        
        EntityService.RemoveChildren(all, id);
        
        all.RemoveAt(all.FindIndex(e => e.Id == id));
        
        _sessionService.Set(SessionServiceConstants.ENTITY_LIST_KEY, all);
    }
}
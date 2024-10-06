using TestSetiGroup.Models.Entity;

namespace TestSetiGroup.Mock;

public static class EntityMock
{
    private static int LastId = 16;
    
    public static int GetNewId()
    {
        LastId++;
        
        return LastId;
    }
    
    public static List<EntityModel> GetEntities()
    {
        return new List<EntityModel>
        {
            new (){ Id = 1, Name = "Сущность 1", ReportsTo = 0, Value = 100 },
            new (){ Id = 2, Name = "Сущность 2", ReportsTo = 1, Value = 20.5 },
            new (){ Id = 3, Name = "Сущность 3", ReportsTo = 1, Value = 31.0 },
            new (){ Id = 4, Name = "Сущность 4", ReportsTo = 2, Value = 41.5 },
            new (){ Id = 5, Name = "Сущность 5", ReportsTo = 2, Value = 52.0 },
            new (){ Id = 6, Name = "Сущность 6", ReportsTo = 3, Value = 62.5 },
            new (){ Id = 7, Name = "Сущность 7", ReportsTo = 3, Value = 73.0 },
            new (){ Id = 8, Name = "Сущность 8", ReportsTo = 4, Value = 83.5 },
            new (){ Id = 9, Name = "Сущность 9", ReportsTo = 4, Value = 94.0 },
            new (){ Id = 10, Name = "Сущность 10", ReportsTo = 0, Value = 104.5 },
            new (){ Id = 11, Name = "Сущность 11", ReportsTo = 5, Value = 115.0 },
            new (){ Id = 12, Name = "Сущность 12", ReportsTo = 6, Value = 125.5 },
            new (){ Id = 13, Name = "Сущность 13", ReportsTo = 6, Value = 136.0 },
            new (){ Id = 14, Name = "Сущность 14", ReportsTo = 7, Value = 146.5 },
            new (){ Id = 15, Name = "Сущность 15", ReportsTo = 0, Value = 157.0 },
            new (){ Id = 16, Name = "Сущность 16", ReportsTo = 8, Value = 167.5 },
        };
    }
}
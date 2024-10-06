using System.Globalization;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using TestSetiGroup.Mock;
using TestSetiGroup.Models.Entity;
using TestSetiGroup.Repositories;
using TestSetiGroup.Services;

namespace TestSetiGroup.Controllers.API;

/// <summary>
/// Entity потому что не было конкрентно указано, что это и для чего это, так что пусть будут "сущностями"
/// </summary>
[ApiController]
[Route("/api/entity")]
public class EntityController: Controller
{
    private EntityRepository _repository;

    public EntityController(EntityRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    [Route("getAll")]
    public JsonResult GetAll([DataSourceRequest] DataSourceRequest request)
    {
        var entityList = _repository.GetAllFromSession();
        var viewModels = EntityService.GetEntityViewModelList(entityList);
        
        return Json(
            viewModels.ToTreeDataSourceResult(request,
                e => e.Id,
                e => e.ReportsTo,
                e => e
            )
        );
    }

    [HttpPost]
    [Route("add")]
    public JsonResult Add([DataSourceRequest] DataSourceRequest request)
    {
        var formCollection = HttpContext.Request.Form;
        StringValues name = formCollection["Name"];
        int id = EntityMock.GetNewId();
        int reportsTo;
        double value;

        try
        {
            value = double.Parse(formCollection["Value"], CultureInfo.InvariantCulture);
            reportsTo = Convert.ToInt32(formCollection["ReportsTo"] == "" ? "0" : formCollection["ReportsTo"].ToString());
        }
        catch (FormatException exception)
        {
            return Json(new { Errors = exception.Message });
        }

        if (string.IsNullOrEmpty(name))
        {
            return Json(new { Errors = "Наименование - обязательное поле" });
        }
        
        var newEntity = new EntityModel()
        {
            Name = name,
            Value = value,
            ReportsTo = reportsTo,
            Id = id
        };
        
        _repository.Add(newEntity);
        
        return Json(Ok());
    }

    [HttpPut]
    [Route("update")]
    public async Task<JsonResult> Update([DataSourceRequest] DataSourceRequest request)
    {
        var formCollection = HttpContext.Request.Form;
        StringValues name = formCollection["Name"];

        try
        {
            var id = Convert.ToInt32(formCollection["Id"]);
            var value = double.Parse(formCollection["Value"], CultureInfo.InvariantCulture);

            _repository.Update(id, name, value);
        }
        catch (Exception exception)
        {
            return Json(new { Errors = exception.Message });
        }
        
        return Json(Ok());

    }
    
    [HttpDelete]
    [Route("delete")]
    public async Task<JsonResult> Delete([DataSourceRequest] DataSourceRequest request)
    {
        var formCollection = HttpContext.Request.Form;

        try
        {
            var id = Convert.ToInt32(formCollection["Id"]);

            _repository.Delete(id);
        }
        catch (Exception exception)
        {
            return Json(new { Errors = exception.Message });
        }
        
        return Json(Ok());
    }
}
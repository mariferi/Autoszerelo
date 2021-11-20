using Microsoft.AspNetCore.Mvc;
using WebApi_Common.Models;

namespace WebApi_Server.Controllers
{
    [ApiController]
    [Route("api/servicesheet")]
    public class ServiceSheetController : Controller
    {
        [HttpGet]
        public ActionResult <IEnumerable<ServiceSheet>> Get()//Test
        {
            return Ok(new[] {new ServiceSheet { Id=1,CustomerName="A",
                CarType="Honda",LicensePlate="1123",ErrorDescription="jajj",Date=new DateTime(2021,11,20,13,30,44) } });    
        }

        /*

        [HttpGet]
        public ActionResult<IEnumerable<ServiceSheet>> Getall()
        {
            var ServiceSheets = Repo.getServiceSheets();//WIP
            return Ok(ServiceSheets);
        }

        [HttpGet("{Id}")]
        public ActionResult<ServiceSheet> GetbyId(int Id)//Get
        {
            var ServiceSheets = Repo.getServiceSheets();//WIP
            
            var Sheet=ServiceSheets.FirstOrDefault(s => s.Id == Id);
            if (Sheet != null)
            {
                return Ok(Sheet);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody]ServiceSheet serviceSheet)//Add
        {
            var ServiceSheets = Repo.getServiceSheets();
            //serviceSheet.Id = randID(ServiceSheets);//random entity id lesz sztem ez nem kell majd?
            ServiceSheets.Add(serviceSheet);
            Repo.Store(ServiceSheets);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] ServiceSheet serviceSheet)//update
        {
            var ServiceSheets = Repo.getServiceSheets().toList();

            ServiceSheet SheetToUpdate = ServiceSheets.FirstOrDefault(s => s.Id == serviceSheet.Id);
            if (SheetToUpdate != null)
            {
                SheetToUpdate.CustomerName=serviceSheet.CustomerName;
                SheetToUpdate.CarType=serviceSheet.CarType;
                SheetToUpdate.ErrorDescription=serviceSheet.ErrorDescription;
                SheetToUpdate.WorkStatus=serviceSheet.WorkStatus;
                SheetToUpdate.LicensePlate=serviceSheet.LicensePlate;
                SheetToUpdate.WorkStatus=serviceSheet.WorkStatus;
                SheetToUpdate.Date=serviceSheet.Date;

                Repo.store(serviceSheet);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{Id}")]
        public ActionResult  Delete(int Id)//Delete
        {
            var ServiceSheets = Repo.getServiceSheets();//WIP

            var SheetToDelete = ServiceSheets.FirstOrDefault(s => s.Id == Id);
            if (SheetToDelete != null)
            {
                ServiceSheets.Remove(SheetToDelete);
                Repo.store(ServiceSheets);

                return Ok();
            }
            return NotFound();
        }
        */
    }
}

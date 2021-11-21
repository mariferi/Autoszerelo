using Microsoft.AspNetCore.Mvc;
using WebApi_Common.Models;
using WebApi_Server.Repositories;

namespace WebApi_Server.Controllers
{
    [ApiController]
    [Route("api/servicesheet")]
    public class ServiceSheetController : Controller
    {
            [HttpGet]
            public ActionResult<IEnumerable<ServiceSheet>> Get()
            {
                var serviceSheets = ServiceSheetRepository.GetServiceSheets();
                return Ok(serviceSheets);
            }

            [HttpGet("{id}")]
            public ActionResult<ServiceSheet> Get(long id)
            {
                var serviceSheet = ServiceSheetRepository.GetServiceSheet(id);

                if (serviceSheet != null)
                {
                    return Ok(serviceSheet);
                }
                else
                {
                    return NotFound();
                }
            }

            [HttpPost]
            public ActionResult Post(ServiceSheet serviceSheet)
            {
                ServiceSheetRepository.AddServiceSheet(serviceSheet);

                return Ok();
            }

            [HttpPut("{id}")]
            public ActionResult Put(ServiceSheet serviceSheet, long id)
            {
                var dbServiceSheet = ServiceSheetRepository.GetServiceSheet(id);

                if (dbServiceSheet != null)
                {
                    ServiceSheetRepository.UpdateServiceSheet(serviceSheet);
                    return Ok();
                }

                return NotFound();
            }

            [HttpDelete("{id}")]
            public ActionResult Delete(long id)
            {
                var serviceSheet = ServiceSheetRepository.GetServiceSheet(id);

                if (serviceSheet != null)
                {
                    ServiceSheetRepository.DeleteServiceSheet(serviceSheet);
                    return Ok();
                }

                return NotFound();
            }
        }
    }

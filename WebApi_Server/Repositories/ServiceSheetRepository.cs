using WebApi_Common.Models;

namespace WebApi_Server.Repositories
{
    public class ServiceSheetRepository
    {
        public static IList<ServiceSheet> GetServiceSheets()
        {
            using (var database = new ServiceSheetContext())
            {
                var serviceSheets = database.ServiceSheets.ToList();

                return serviceSheets;
            }
        }

        public static ServiceSheet GetServiceSheet(long id)
        {
            using (var database = new ServiceSheetContext())
            {
                var serviceSheet = database.ServiceSheets.Where(p => p.Id == id).FirstOrDefault();

                return serviceSheet;
            }
        }

        public static void AddServiceSheet(ServiceSheet serviceSheet)
        {
            using (var database = new ServiceSheetContext())
            {
                database.ServiceSheets.Add(serviceSheet);

                database.SaveChanges();
            }
        }

        public static void UpdateServiceSheet(ServiceSheet serviceSheet)
        {
            using (var database = new ServiceSheetContext())
            {
                database.ServiceSheets.Update(serviceSheet);

                database.SaveChanges();
            }
        }

        public static void DeleteServiceSheet(ServiceSheet serviceSheet)
        {
            using (var database = new ServiceSheetContext())
            {
                database.ServiceSheets.Remove(serviceSheet);

                database.SaveChanges();
            }
        }
    }
}

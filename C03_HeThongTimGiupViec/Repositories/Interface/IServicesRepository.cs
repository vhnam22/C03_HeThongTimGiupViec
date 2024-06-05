using C03_HeThongTimGiupViec.Models;

namespace C03_HeThongTimGiupViec.Repository.Interface
{
    public interface IServicesRepository
    {
        //Get all services
        public List<Service> GetServices();

        //Get service by id
        public Service GetServiceById(int id);

        //Add new service
        public bool AddService(Service service);

        //Update service info
        public bool UpdateService(Service service);


    }
}

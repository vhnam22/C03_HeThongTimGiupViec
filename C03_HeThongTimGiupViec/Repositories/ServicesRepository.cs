using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.Repository.Interface;

namespace C03_HeThongTimGiupViec.Repository
{
    public class ServicesRepository: IServicesRepository
    {
        C03_HeThongTimGiupViecContext _context;
        public ServicesRepository(C03_HeThongTimGiupViecContext context) {
            _context = context;
        }

        //Get all services
        public List<Service> GetServices()
        {
            try
            {
                List<Service> serviceLst = _context.Services.ToList();
                return serviceLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Add new service
        public bool AddService(Service service)
        {
            try
            {
                if(service!= null)
                {
                    _context.Services.Add(service);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        //Update service info
        public bool UpdateService(Service service)
        {
            try
            {
                if(service!= null)
                {
                    Service _service = _context.Services.FirstOrDefault(x => x.ServiceId == service.ServiceId);
                    if(_service!=null)
                    {
                        _service.ServiceName = service.ServiceName;
                        _service.Description = service.Description;
                        _service.Logo = service.Logo;
                        _context.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //
        
    }
}

using C03_HeThongTimGiupViec.Models;
using C03_HeThongTimGiupViec.Repositories.Interface;

namespace C03_HeThongTimGiupViec.Repositories
{
    public class SlideRepository: ISlideRepository
    {
        private readonly C03_HeThongTimGiupViecContext _context;

        public SlideRepository(C03_HeThongTimGiupViecContext context)
        {
            _context = context;
        }

        //Get all slides
        public List<Slide> GetAllSlides()
        {
            try
            {
                List<Slide> lst = _context.Slides.ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get active slides
        public List<Slide> GetActiveSlides()
        {
            try
            {
                List<Slide> lst = _context.Slides.Where(x => x.IsActive == true).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Add new slide
        public bool AddSlide(Slide slide)
        {
            try
            {
                _context.Slides.Add(slide);
                return true;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        //Update silde info
        public bool UpdateSlide(Slide slide)
        {
            try
            {
                Slide _slide = _context.Slides.FirstOrDefault(x => x.SlideId == slide.SlideId);
                if (_slide != null)
                {
                    _slide.IsActive = slide.IsActive;
                    _slide.ImageUrl = slide.ImageUrl;
                    _slide.Priority = slide.Priority;

                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Update priority for active slides
        public bool UpdatePrioritySlides(List<Slide> slides)
        {
            try
            {
                foreach (Slide s in slides)
                {
                    UpdateSlide(s);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Delete slide
        public bool DeleteSlide(int id)
        {
            try
            {
                Slide slide = _context.Slides.FirstOrDefault(x => x.SlideId == id);
                if (slide != null)
                {
                    _context.Slides.Remove(slide);
                    return true;
                }
                return false;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

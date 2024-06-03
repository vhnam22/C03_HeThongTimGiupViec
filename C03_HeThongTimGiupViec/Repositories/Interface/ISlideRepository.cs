using C03_HeThongTimGiupViec.Models;

namespace C03_HeThongTimGiupViec.Repositories.Interface
{
    public interface ISlideRepository
    {
        //Get all slides
        public List<Slide> GetAllSlides();

        //Get active slides
        public List<Slide> GetActiveSlides();

        //Add new slide
        public bool AddSlide(Slide slide);

        //Update silde info
        public bool UpdateSlide(Slide slide);

        //Update priority for active slides
        public bool UpdatePrioritySlides(List<Slide> slides);

        //Delete slide
        public bool DeleteSlide(int id);


    }
}

using System.Collections.Generic;


namespace Cucklist.Models.HomeViewModels
{
    public class IndexViewModel
    {

        public IEnumerable<Image> Images { get; set; }
        public IEnumerable<Video> Videos { get; set; }

        public IndexViewModel(IEnumerable<Image> images,IEnumerable<Video> videos)
        {

        Images = images;
        Videos = videos;
        }
    }
}

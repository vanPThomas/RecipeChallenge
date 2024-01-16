using Domain.Entity;

namespace RestApi.Models.Output
{
    public class ItemRESTOutputDTO
    {
        //public ItemRESTOutputDTO(List<PartRESTOutputDTO> parts, string title, List<string> photos)
        //{
        //    this.parts = parts;
        //    Title = title;
        //    Photos = photos;
        //}

        public ItemRESTOutputDTO(List<PartRESTOutputDTO> parts, int id, string title, List<string> photos)
        {
            this.parts = parts;
            Id = id;
            Title = title;
            Photos = photos;
        }

        public List<PartRESTOutputDTO> parts { get; set; }
        public int Id { get; set; }
        public string Title { get; private set; }
        public List<string> Photos { get; private set; }
    }
}

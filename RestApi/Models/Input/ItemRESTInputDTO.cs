using RestApi.Models.Output;

namespace RestApi.Models.Input
{
    public class ItemRESTInputDTO
    {
        public ItemRESTInputDTO(List<PartRESTInputDTO> parts, string title, List<string> photos)
        {
            this.parts = parts;
            
            Title = title;
            Photos = photos;
        }

        public List<PartRESTInputDTO> parts { get; set; }
        //public int Id { get; private set; }
        public string Title { get; set; }
        public List<string> Photos { get; set; }
    }
}

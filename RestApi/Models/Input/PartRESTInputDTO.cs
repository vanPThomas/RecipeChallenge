namespace RestApi.Models.Input
{
    public class PartRESTInputDTO
    {
        public PartRESTInputDTO(string name, string unitOfMeasurment)
        {
            Name = name;
            UnitOfMeasurment = unitOfMeasurment;
        }

        public string Name { get; set; }
        public string UnitOfMeasurment { get; set; }
    }
}

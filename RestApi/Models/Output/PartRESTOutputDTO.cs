namespace RestApi.Models.Output
{
    public class PartRESTOutputDTO
    {
        public PartRESTOutputDTO(string name, string unitOfMeasurment)
        {
            Name = name;
            UnitOfMeasurment = unitOfMeasurment;
        }

        public string Name { get; set; }
        public string UnitOfMeasurment { get; set; }
    }
}

namespace CarService
{
    internal class DetailsFactory
    {
        public List<Detail> GenerateDetails(DetailType type, int count)
        {
            List<Detail> details = new();

            for (int i = 0; i < count; i++)
                details.Add(new Detail(type));
            
            return details;
        }

        public List<Detail> GenerateCarDetails()
        {
            List<Detail> details = new();
            int detailsTypesCount = Enum.GetNames(typeof(DetailType)).Length;

            for (int i = 0; i < detailsTypesCount; i++)
                details.Add(new Detail((DetailType)i));

            return details;
        }
    }
}

namespace CarService
{
    internal class DetailsGroup
    {
        private List<Detail> _details;
        private DetailsFactory _detailsFactory;

        public DetailsGroup(DetailType type, int count)
        {
            _detailsFactory = new();
            _details = _detailsFactory.GenerateDetails(type, count);
            Type = type;
        }

        public DetailType Type { get; }

        public int Count =>
            _details.Count;

        public Detail? Take()
        {
            if (Count > 0)
            {
                Detail detail = _details[0];
                _details.RemoveAt(0);

                return detail;
            }
            else
            {
                return null;
            }
        }
    }
}

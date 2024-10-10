namespace CarService
{
    internal class Warehouse
    {
        private DetailsGroupsFactory _detailsGroupsFactory;
        private List<DetailsGroup> _detailsGroups;

        public Warehouse()
        {
            _detailsGroupsFactory = new DetailsGroupsFactory();
            _detailsGroups = _detailsGroupsFactory.GenerateDetailsGroups();
        }

        public void ShowDetails()
        {
            for (int i = 0; i < _detailsGroups.Count; i++)
            {
                DetailsGroup detailsGroup = _detailsGroups[i];
                string detailsGroupToString = $"{i + 1,2}. {_detailsGroups[i].Type,10} - {_detailsGroups[i].Count}pcs.";

                if (detailsGroup.Count > 0)
                    Console.WriteLine(detailsGroupToString);
                else
                    Colorizer.WriteWithColor(detailsGroupToString, ConsoleColor.Red);
            }
        }

        public Detail Take(int index)
        {
            return _detailsGroups[index].Take();
        }
    }
}

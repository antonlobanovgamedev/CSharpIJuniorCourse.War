namespace CarService
{
    internal class DetailsGroupsFactory
    {
        public List<DetailsGroup> GenerateDetailsGroups()
        {
            int minDetailsCount = 1;
            int maxDetailsCount = 4;

            List<DetailsGroup> detailsGroups = new();
            int detailsTypesCount = Enum.GetNames(typeof(DetailType)).Length;

            for (int i = 0; i < detailsTypesCount; i++)
            {
                int detailsCount = RandomUtil.GenerateInt(minDetailsCount, maxDetailsCount);
                DetailsGroup newDetailsGroup = new DetailsGroup((DetailType)i, detailsCount);
                detailsGroups.Add(newDetailsGroup);
            }

            return detailsGroups;
        }
    }
}

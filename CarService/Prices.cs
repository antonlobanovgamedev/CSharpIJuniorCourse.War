namespace CarService
{
    internal class Prices
    {
        private Dictionary<DetailType, int> _priceByDetailType;
        private Dictionary<PenaltyType, int> _penaltyByPenaltyType;
        private Dictionary<RewardType, int> _rewardByRewardType;

        public Prices()
        {
            _priceByDetailType = new Dictionary<DetailType, int>()
            {
                { DetailType.Engine, 3000},
                { DetailType.TailPipe, 100},
                { DetailType.Wheel, 200},
                { DetailType.Glass, 200},
                { DetailType.Bumper, 150},
                { DetailType.FrontDoor, 300},
                { DetailType.BackDoor, 300},
                { DetailType.Headlight, 50},
                { DetailType.Backlight, 100},
                { DetailType.Battery, 150},
                { DetailType.Carburetor, 1000},
            };

            _penaltyByPenaltyType = new Dictionary<PenaltyType, int>()
            {
                { PenaltyType.RefuseBeforeRepair, 250},
                { PenaltyType.RefuseDuringRepairForOneDetail, 200},
            };

            _rewardByRewardType = new Dictionary<RewardType, int>()
            {
                { RewardType.PaymentForDetailReplacement, 500 }
            };
        }

        public int GetDetailPrice(DetailType type) =>
            _priceByDetailType[type];

        public int GetPenalty(PenaltyType type) =>
            _penaltyByPenaltyType[type];

        public int GetReward(RewardType type) =>
            _rewardByRewardType[type];
    }
}

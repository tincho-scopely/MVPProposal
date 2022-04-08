namespace MVP_Proposal2.Scripts.Domain.Model
{
    public struct PurchaseBundleResult
    {
        public readonly int PlayerRollsAmount;

        public PurchaseBundleResult(int playerRollsAmount)
        {
            PlayerRollsAmount = playerRollsAmount;
        }
    }
}
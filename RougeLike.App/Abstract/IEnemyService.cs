namespace RougeLike.App.Abstract
{
    internal interface IEnemyService
    {
        void GenerateNewEnemy(int heroLevel);

        void ShowMonsterInfo();

        bool DealDamage(int heroDamage);

        int[] GetHiddenStats();
    }
}
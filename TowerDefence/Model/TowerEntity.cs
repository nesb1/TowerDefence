namespace TowerDefence.Model
{
    public class TowerEntity
    {
        TowerEntity(int gunPower)
        {
            GunPower = gunPower;
        }
        public int GunPower { get; }
        
    }
}
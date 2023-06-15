namespace JP_TS_15_MainConsoleProject.Shooter
{
    public abstract class ShootableWeapon : Weapon
    {
        public abstract int Bullets { get; set; }
        public abstract void Shoot(Player playerToShot, bool additionalFeature = false);
    }
}

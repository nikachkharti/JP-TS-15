namespace JP_TS_15_MainConsoleProject.Shooter.Weapons
{
    public class Ak47 : ShootableWeapon
    {
        public override string Name { get; set; } = "AK47";
        public override int Bullets { get; set; } = 30;
        public override int Damage { get; set; } = 60;
        public override double Price { get; set; } = 1500;

        public override void Shoot(Player playerToShot, bool additionalFeature = false)
        {
            if (Bullets != 0)
            {
                Bullets--;
                playerToShot.Health -= Damage;
            }
        }
    }
}

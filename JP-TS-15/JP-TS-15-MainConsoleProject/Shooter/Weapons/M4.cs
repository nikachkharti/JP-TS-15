namespace JP_TS_15_MainConsoleProject.Shooter.Weapons
{
    public class M4 : ShootableWeapon
    {
        public override string Name { get; set; } = "M4";
        public override int Bullets { get; set; } = 30;
        public override int Damage { get; set; } = 60;
        public override double Price { get; set; } = 1500;
        public bool IsMuted { get; set; }

        public override void Shoot(Player playerToShot, bool additionalFeature = false)
        {
            if (Bullets != 0)
            {
                if (additionalFeature)
                {
                    IsMuted = true;
                }
                Bullets--;
                playerToShot.Health -= Damage;
            }
        }
    }
}

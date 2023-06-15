namespace JP_TS_15_MainConsoleProject.Shooter
{
    public class Usp : ShootableWeapon
    {
        public override string Name { get; set; } = "Usp";
        public override int Bullets { get; set; } = 20;
        public override int Damage { get; set; } = 20;
        public override double Price { get; set; } = 200;
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

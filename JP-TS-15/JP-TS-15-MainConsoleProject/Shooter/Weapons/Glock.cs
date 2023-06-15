namespace JP_TS_15_MainConsoleProject.Shooter
{
    public class Glock : ShootableWeapon
    {
        public override string Name { get; set; } = "Glock";
        public override int Bullets { get; set; } = 20;
        public override int Damage { get; set; } = 20;
        public override double Price { get; set; } = 200;

        public override void Shoot(Player playerToShot, bool additionalFeature = false)
        {
            if (additionalFeature)
            {
                if (Bullets != 0)
                {
                    Bullets -= 3;
                    playerToShot.Health -= Damage * 3;
                }
            }
            else
            {
                Bullets--;
                playerToShot.Health -= Damage;
            }
        }
    }
}

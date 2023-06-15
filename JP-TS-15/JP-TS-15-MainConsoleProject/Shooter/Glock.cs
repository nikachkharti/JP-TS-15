namespace JP_TS_15_MainConsoleProject.Shooter
{
    public class Glock : ShootableWeapon
    {
        public override string Name { get; set; } = "Glock";
        public override int Bullets { get; set; } = 20;
        public override int Damage { get; set; } = 20;
        public override double Price { get; set; } = 200;
    }
}

namespace JP_TS_15_MainConsoleProject.Shooter
{
    public abstract class Weapon
    {
        public abstract string Name { get; set; }
        public abstract int Damage { get; set; }
        public abstract double Price { get; set; }
    }
}

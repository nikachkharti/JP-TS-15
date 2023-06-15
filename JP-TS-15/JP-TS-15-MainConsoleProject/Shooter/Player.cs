namespace JP_TS_15_MainConsoleProject.Shooter
{
    public class Player
    {
        public string Name { get; set; }
        public double Money { get; set; } = 800;
        public int Health { get; set; } = 100;
        public Weapon Weapon { get; set; } = new Knife();

        public void BuyWeapon(Weapon weaponToBuy)
        {
            if (Money >= weaponToBuy.Price)
            {
                Weapon = weaponToBuy;
                Money -= weaponToBuy.Price;
                Console.WriteLine($"{Name} purchased {weaponToBuy.Name}");
            }
        }

        public void DisplayYourself() => Console.WriteLine($"{Name} has health {Health} % has {Money} USD uses {Weapon.Name}");

    }
}

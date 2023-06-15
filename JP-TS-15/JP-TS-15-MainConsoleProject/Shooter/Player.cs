namespace JP_TS_15_MainConsoleProject.Shooter
{
    public class Player
    {
        public string Name { get; set; }
        public double Money { get; set; } = 800;
        public int Health { get; set; } = 100;
        public Weapon Weapon { get; set; } = new Knife();
        public ShootableWeapon ShootableWeapon { get; set; }
        public Status Status { get; set; }

        public Player()
        {
            if (Status == Status.Terorist)
            {
                ShootableWeapon = new Glock();
            }
            else
            {
                ShootableWeapon = new Usp();
            }
        }

        public void BuyWeapon(ShootableWeapon weaponToBuy)
        {
            if (Money >= weaponToBuy.Price)
            {
                ShootableWeapon = weaponToBuy;
                Money -= weaponToBuy.Price;
                Console.WriteLine($"{Name} purchased {weaponToBuy.Name}");
            }
        }

        public void DisplayYourself() => Console.WriteLine($"{Name} has health {Health} % has {Money} USD uses {Weapon.Name}");


        public void Shoot(Player target)
        {
            ShootableWeapon.Shoot(target);
            Console.WriteLine($"{Name} shot {target.Name}. {target.Name} health is {target.Health} %");
        }
    }
}

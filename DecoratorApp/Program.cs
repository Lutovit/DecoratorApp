using System;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace DecoratorApp
{

    public abstract  class Weapon
    {
        public string GunName { set; get; }
        public int MagazineCapacity { set; get; }
        public int Power { set; get; }

        public Weapon()
        {

        }

        public Weapon(string gunName, int magCap, int pow)
        {
            GunName = gunName;
            MagazineCapacity = magCap;
            Power = pow;
        }

        public abstract string Shot();
    }
    


    public class Gun : Weapon
    {
        public Gun() :base("Pistol", 12, 10)
        {

        }

        public Gun(string gunName, int magCap, int pow) : base(gunName, magCap, pow)
        {

        }


        public override  string Shot()
        {
            return GunName + ",  " + MagazineCapacity + "-round magazine, power: " + Power;
        }
    }



    public class Rifle : Weapon
    {
        public Rifle() : base("Rifle", 30, 50)
        {

        }

        public Rifle(string gunName, int magCap, int pow) : base(gunName, magCap, pow)
        {

        }


        public override string Shot()
        {
            return GunName + ",  " + MagazineCapacity + "-round magazine, power: " + Power;
        }
    }



    public abstract class WeaponDecorator : Weapon
    {
        public Weapon Weapon { set; get; }

        public WeaponDecorator(Weapon weapon) 
        {
            this.Weapon = weapon;
        }

        public override string Shot()
        {
            if (Weapon != null)
            {
               return Weapon.Shot();
            }

            return "Something goes wrong with WeaponDecorator.Shot(). We are very sorry.";
        }
    }



    public class Silencer : WeaponDecorator
    {
        public Silencer (Weapon weapon) : base(weapon)
        {

        }

        public override string Shot()
        {
            return base.Shot() + "  Silenser is instaled.";
        }
    }




    public class TacticalFlashlight : WeaponDecorator
    {
        public TacticalFlashlight(Weapon weapon) : base(weapon)
        {

        }

        public override string Shot()
        {
            return base.Shot() + "  Tactical flashlight  is instaled.";
        }
    }




    public class Colimator : WeaponDecorator
    {
        public Colimator(Weapon weapon) : base(weapon)
        {

        }

        public override string Shot()
        {
            return base.Shot() + "  Colimator  is instaled.";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            Weapon gun = new Gun( );
            Console.WriteLine(gun.Shot());

            gun = new Colimator(gun);
            Console.WriteLine(gun.Shot());

            gun = new Silencer(gun);
            Console.WriteLine(gun.Shot());

            gun = new TacticalFlashlight(gun);
            Console.WriteLine(gun.Shot());

            Console.WriteLine();

            Weapon rifle = new Silencer(new Colimator(new TacticalFlashlight(new Rifle())));
            Console.WriteLine(rifle.Shot());

        }
    }
}

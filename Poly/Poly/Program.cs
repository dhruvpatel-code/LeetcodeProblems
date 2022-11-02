using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poly 
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car> {
                new Audi("Blue", 200, "A4"),
                new BMW("Red", 180, "M3")
            };

            foreach (var car in cars)
            {
                car.Repair();
                car.GetDetails();
                Console.WriteLine("\n");
            }
        }
        
        public class Car 
        {
            public string Color { get; set; }
            public int HP { get; set; }
            
            public Car(string color, int hp)
            {
                this.Color = color;
                this.HP = hp;
            }
            
            public void GetDetails()
            {
                Console.WriteLine("Color: " + this.Color);
                Console.WriteLine("HP: " + this.HP);
            }

            public virtual void Repair()
            {
                Console.WriteLine("Car repaired");
            }
        
        }

        public class BMW : Car
        {
            public string Model { get; set; }
            private string _brand = "BMW";

            public BMW(string color, int hp, string model) : base(color, hp)
            {
                this.Model = model;
            }
            public new void GetDetails()
            {
                Console.WriteLine("Color: " + this.Color);
                Console.WriteLine("HP: " + this.HP);
                Console.WriteLine("Model: " + this.Model);
                Console.WriteLine("Brand: " + this._brand);
            }

            public override void Repair()
            {
                Console.WriteLine("BMW {0} repaired", Model);
            }
        }

        public class Audi : Car
        {
            public string Model
            {
                get; set;
            }
            private string _brand = "Audi";

            public Audi(string color, int hp,string model) : base(color, hp)
            {
                this.Model = model;
            }
            public new void GetDetails()
            {
                Console.WriteLine("Color: " + this.Color);
                Console.WriteLine("HP: " + this.HP);
                Console.WriteLine("Model: " + this.Model);
                Console.WriteLine("Brand: " + this._brand);
            }

            public override void Repair()
            {
                Console.WriteLine("Audi {0} repaired", Model);
            }
        }
    }
}
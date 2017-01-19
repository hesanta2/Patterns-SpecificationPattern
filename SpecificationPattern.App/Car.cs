using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern.App
{
    public class Car
    {
        [Flags]
        public enum CarType { Normal, Sport, Competition }

        public CarType Type { get; set; }
        public Color Color { get; set; }
        public int Doors { get; set; }
        public int MaxSpeed { get; set; }
        public string Name { get; private set; }

        public Car(string name) { this.Name = name; }

        public override string ToString()
        {
            return $"{this.Name}: [Type]{Type}, [Color]{Color}, [Doors]{Doors}, [MaxVelocity]{MaxSpeed}";
        }
    }
}

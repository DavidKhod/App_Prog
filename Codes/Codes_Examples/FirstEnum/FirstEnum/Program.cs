using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEnum
{
    class Program
    {
        enum ACMode { cold,heat,vent};
        static void Main(string[] args)
        {

        }

        class AirCondition
        {
            private ACMode mode;
            private int temp;
            private bool on;
            private const int MAX_TEMP = 32;
            private const int MIN_TEMP = 16;
            public AirCondition(ACMode mode,int temp,bool on)
            {
                this.mode = mode;
                this.temp = temp;
                this.on = on;
            }

            public void TurnOn()
            {
                this.on = true;
            }

            public void TurnOff()
            {
                this.on = false;
            }

            public bool IsOn()
            {
                return this.on;
            }

            public void SetMode(ACMode mode)
            {
                this.mode = mode;
            }

            public ACMode GetMode()
            {
                return this.mode;
            }

            public void IncreaseTemp()
            {
                if (this.temp < MAX_TEMP)
                    this.temp++;
            }

            public void DecreaseTemp()
            {
                if (this.temp > MIN_TEMP)
                    this.temp--;
            }
        }
    }
}

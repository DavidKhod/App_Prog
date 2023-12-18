namespace MakingButtonDoSomething
{
    public enum ACMode { cold, heat, vent };
    class AC
    {
        private ACMode mode;
        private int temp;
        private bool on;
        private const int MAX_TEMP = 32;
        private const int MIN_TEMP = 16;
        public AC(ACMode mode, int temp, bool on)
        {
            this.mode = mode;
            this.temp = temp;
            this.on = on;
        }

        public AC(ACMode mode, int temp)
        {
            this.mode = mode;
            this.temp = temp;
            this.on = false;
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

        public int GetTemp()
        {
            return this.temp;
        }

        public void DecreaseTemp()
        {
            if (this.temp > MIN_TEMP)
                this.temp--;
        }
    }
}
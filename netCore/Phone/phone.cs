namespace Phone 
{
    public abstract class Phone 
    {
        private string _versionNumber;
        private int _batteryPercentage;
        private string _carrier;
        private string _ringTone;

        public Phone (string versionNumber, int batterPercentage, string carrier, string ringTone)
        {
            _versionNumber = versionNumber;
            _batteryPercentage = batterPercentage;
            _carrier = carrier;
            _ringTone = ringTone;
        }

        public abstract void DisplayInfo();

    }

        public interface IRingable
        {
            string Ring();
            string Unlock();
        }

}
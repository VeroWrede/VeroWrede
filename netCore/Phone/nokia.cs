using System;

namespace Phone 
{
    public class Nokia : Phone, IRingable
    {
        public string versionNumber;
        public int batterPercentage;
        public string carrier;
        public string ringTone;
       public Nokia (string versionNumber, int batteryPercentage, string carrier, string ringTone) : base (versionNumber, batteryPercentage, carrier, ringTone)
       {}
           public string Ring()
           {
            return($"... {ringTone} ...");

           }
           public string Unlock()
           {
            return($"Nokia {versionNumber} is unlocked with passcode");
           }

           public override void DisplayInfo()
           {
                // Console.WriteLine("########################");
                // Console.WriteLine("Galaxy ", versionNumber);
                // Console.WriteLine("Battery Percentage ", batteryPercentage);
                // Console.WriteLine("CArrier ", carrier);
                // Console.WriteLine("Ring Tone ", ringTone);
                // Console.WriteLine("########################");
           }
       
    }
}
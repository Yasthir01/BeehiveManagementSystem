using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class HoneyVault
    {
        public const float NECTAR_CONVERSION_RATIO = .19f;
        public const float LOW_LEVEL_WARNING = 10f;
        private static float honey = 25f;
        private static float nectar = 100f;

        public static void CollectNectar(float amount)
        {
            // we want to add nectar to the hive
            if (amount > 0f) nectar += amount;
        }

        public static void ConvertNectarToHoney(float amount)
        {
            float nectarToConvert = amount;  // the amount of nectar to be converted to honey 
            // if the nectar that we need to convert is greater than the available nectar then just
            // set the available nectar to the nectar that needs to be converted
            if (nectarToConvert > nectar) nectarToConvert = nectar;
            // if it never reaches the above statement then just reduce available nectar by nectar we need to convert
            nectar -= nectarToConvert;
            honey += nectarToConvert * NECTAR_CONVERSION_RATIO;
        }

        public static bool ConsumeHoney(float amount)
        {
            // we need to see if there is enough available honey for the bee to do its job
            if (honey >= amount)  // if we have enough storage
            {
                honey -= amount;  // take out the necessary amount from the honey storage
                return true;
            }
            return false;  // if we never go into the above if statement then our answer is false
        }

        public static string StatusReport
        {
            get
            {
                string status = $"{honey:0.0} units of honey\n" + $"{nectar:0.0} units of nectar";
                string warnings = "";
                // if the honey is too low
                if (honey < LOW_LEVEL_WARNING) warnings += $"\nLOW HONEY - ADD A HONEY MANUFACTURER";
                // if nectar is low
                if (nectar < LOW_LEVEL_WARNING) warnings += $"\nLOW NECTAR - ADD A NECTAR COLLECTOR";
                return status + warnings;
            }
        }
    }
}

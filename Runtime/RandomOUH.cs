using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OpenUnityHelp
{
    public class RandomOUH
    {
        ///<summary>
        /// Returns a random float within a minimum and maximum range with a said amount of decimal spaces, 2 by default.
        /// Also can or cannot have 0 as a result, allowed by default.
        ///</summary>
        public static float GetRandomFloat(float minRange, float maxRange, int decimalSpaces = 2, bool allowZeroAsResult = true)
        {
            float tempRandomValue = 0;

            // If 0 is allowed then generate a random value, otherwise generate it until /= 0.
            if (allowZeroAsResult)
            {
                tempRandomValue = (float)System.Math.Round(UnityEngine.Random.Range(minRange, maxRange), decimalSpaces);
            }
            else
            {
                while (tempRandomValue == 0)
                {
                    tempRandomValue = (float)System.Math.Round(UnityEngine.Random.Range(minRange, maxRange), decimalSpaces);
                }
            }

            // Rounds the value again for cases when rounding didn't work properly.
            return (float)System.Math.Round(tempRandomValue, decimalSpaces);
        }


        ///<summary>
        /// Returns a random list of floats within minimum and maximum boundaries, with 2 decimal spaces by default.
        ///</summary>
        public static List<float> GetRandomFloats(float minRangeIncluded, float maxRangeIncluded, int numberOfFloats, int decimalSpaces = 2)
        {
            List<float> randomFloats = new List<float>();

            for (int i = 0; i < numberOfFloats; i++)
            {
                // Generates a random float within the parameters.
                float randFloat = UnityEngine.Random.Range(minRangeIncluded, maxRangeIncluded);

                // Rounds it up to desired decimal spaces and adds it to the return list.
                randomFloats.Add((float)System.Math.Round(randFloat, decimalSpaces));
            }

            return randomFloats;
        }


        ///<summary>
        /// Returns a random list of ints within minimum and maximum boundaries.
        /// Gives the possibility for the same number to be included multiple times or not, false by default.
        ///</summary>
        public static List<int> GetRandomInts(int minRangeIncluded, int maxRangeIncluded, int numberOfInts, bool sameNumberCanBeMultipleTimes = false)
        {
            List<int> randomInts = new List<int>();

            // If a numebr can be multiple times then just fill the list with as many random ints as user wants.
            if (sameNumberCanBeMultipleTimes)
            {
                for (int i = 0; i < numberOfInts; i++)
                {
                    randomInts.Add(UnityEngine.Random.Range(minRangeIncluded, maxRangeIncluded));
                }
                
            }
            else
            {
                // Creates a list of possible ints and fills it with all possible ints.
                List<int> possibleInts = new List<int>();

                for (int i = minRangeIncluded; i <= maxRangeIncluded; i++)
                {
                    possibleInts.Add(i);
                }

                
                for (int i = 0; i < numberOfInts; i++)
                {
                    // Generates a random index
                    int randIndex = UnityEngine.Random.Range(0, possibleInts.Count);

                    // Adds an int from the possible ints list to the one to be returned.
                    randomInts.Add(possibleInts[randIndex]);

                    // Removes the number at said index.
                    possibleInts.RemoveAt(randIndex);
                }
            }
            

            return randomInts;
        }


        ///<summary>
        /// Returns a random list of floats within minimum and maximum boundaries, with 2 decimal spaces by default.
        ///</summary>
        public static void ShuffleList()
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using OpenUnityHelp;

namespace OpenUnityHelp
{
    public static class RandomOUH
    {
		///<summary>
        /// Returns a random float within a minimum and maximum range with a said amount of decimal spaces, 2 by default.
        /// Also can or cannot have 0 as a result, allowed by default.
        ///</summary>
        public static float GetRandomNum(float minRange, float maxRange, int decimalSpaces = 2)
        {
            float tempRandomValue;

            tempRandomValue = (float)System.Math.Round(UnityEngine.Random.Range(minRange, maxRange), decimalSpaces);

            // Rounds the value again for cases when rounding didn't work properly.
            return (float)System.Math.Round(tempRandomValue, decimalSpaces);
        }


		/// <summary>
		/// Return a random float between two values which are stored in pairMinMax Vector2.
		/// Min value is pairMinMax.x and max value is pairMinMax.y, also can have a said amount of decimal spaces, 2 by default.
		/// </summary>
		public static float GetRandomNum(Vector2 pairMinMax, int decimalSpaces = 2)
		{
			return GetRandomNum(pairMinMax.x, pairMinMax.y, decimalSpaces);
		}


		///<summary>
		/// Returns a random list of floats within minimum and maximum boundaries, with 2 decimal spaces by default.
		///</summary>
		public static List<float> GetRandomNums(float minRangeIncluded, float maxRangeIncluded, int numberOfFloats, int decimalSpaces = 2)
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
		
		
		/// <summary>
		/// Returns a list of random floats between two values which are stored in pairMinMax Vector2.
		/// Min value is pairMinMax.x and max value is pairMinMax.y, also can have a said amount of decimal spaces, 2 by default.
		/// </summary>
		public static List<float> GetRandomNums(Vector2 pairMinMax, int numberOfFloats, int decimalSpaces = 2)
		{
			return GetRandomNums(pairMinMax.x, pairMinMax.y, numberOfFloats, decimalSpaces);
		}


		///<summary>
		/// Returns a random list of ints within minimum and maximum boundaries.
		/// Gives the possibility for the same number to be included multiple times or not, false by default.
		///</summary>
		public static List<int> GetRandomNums(int minRangeIncluded, int maxRangeIncluded, int numberOfInts, bool sameNumberCanBeMultipleTimes = false)
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


		/// <summary>
		/// Returns random bool value with 50/50 chance (true/false).
		/// </summary>
		public static bool RandomBool()
		{
			return UnityEngine.Random.Range(0, 2) == 0;
		}


		/// <summary>
		/// Get a chance with given percentage. If percentage is 25 it will return true each 4th time on an average.
		/// </summary>
		public static bool RandomBool(int percentage)
		{
			return UnityEngine.Random.Range(0, 100) + 1 <= percentage;
		}


		/// <summary>
		/// Gets a chance with given probability in %. If probability is 25% it will return true each 4th time on an average.
		/// </summary>
		public static bool RandomBool(float probability)
		{
			return UnityEngine.Random.Range(0f, 100f) < probability;
		}


		/// <summary>
		/// Returns random item from array.
		/// </summary>
		public static T RandomItem<T>(T[] array)
		{
			return array[UnityEngine.Random.Range(0, array.Length)];
		}


		/// <summary>
		/// Returns random item from list.
		/// </summary>
		public static T RandomItem<T>(List<T> list)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}

		/// <summary>
		/// Returns random enum item.
		/// </summary>
		public static T RandomItem<T>()
		{
			var values = Enum.GetValues(typeof(T));
			return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
		}


		/// <summary>
		/// Returns random index of passed list.
		/// </summary>
		public static int RandomIndex<T>(List<T> list)
        {
			return UnityEngine.Random.Range(0, list.Count);
        }


		/// <summary>
		/// Returns random index of passed array.
		/// </summary>
		public static int RandomIndex<T>(T[] array)
		{
			return UnityEngine.Random.Range(0, array.Length);
		}

		
		/// <summary>
		/// Return sub-list of random items from origin list without repeating.
		/// </summary>
		public static List<T> ReturnRandomItems<T>(IList<T> list, int count)
		{
			List<T> items = new List<T>();
			List<int> remainedIndexes = Enumerable.Range(0, list.Count).ToList();
			for (int i = 0; i < count; i++)
			{
				int selectedIndex = RandomItem(remainedIndexes);
				remainedIndexes.Remove(selectedIndex);
				items.Add(list[selectedIndex]);
			}
			return items;
		}


		/// <summary>
		/// Shuffles list of items.
		/// </summary>
		public static void ShuffleList<T>(this List<T> list)
		{
			for (int i = 1; i < list.Count; i++)
			{
				int randInt = UnityEngine.Random.Range(0, list.Count);
				T temp = list[i];
				list[i] = list[randInt];
				list[randInt] = temp;
			}
		}


		/// <summary>
		/// Returns a shuffled list of items from the passed list.
		/// </summary>
		public static List<T> GetShuffledList<T>(List<T> list)
        {
			List<T> shuffledList = list;

			for (int i = 1; i < list.Count; i++)
			{
				int randInt = UnityEngine.Random.Range(0, list.Count);
				T temp = shuffledList[i];
				shuffledList[i] = shuffledList[randInt];
				shuffledList[randInt] = temp;
			}

			return shuffledList;
		}


        /// <summary>
        /// Shuffles array of items.
        /// </summary>
        public static void ShuffleArray<T>(this T[] array)
		{
			for (int i = 1; i < array.Length; i++)
			{
				int indRnd = UnityEngine.Random.Range(0, array.Length);
				T temp = array[i];
				array[i] = array[indRnd];
				array[indRnd] = temp;
			}
		}


		/// <summary>
		/// Returnns a shuffled array of items from the passed array.
		/// </summary>
		public static T[] GetShuffledArray<T>(T[] array)
		{
			T[] shuffledArray = array;

			for (int i = 1; i < array.Length; i++)
			{
				int randInt = UnityEngine.Random.Range(0, array.Length);
				T temp = shuffledArray[i];
				shuffledArray[i] = shuffledArray[randInt];
				shuffledArray[randInt] = temp;
			}

			return shuffledArray;
		}


		/// <summary>
		/// Returns random point on line 2D.
		/// </summary>
		public static Vector2 RandomPointOnLine(Vector2 point1, Vector2 point2)
		{
			float t = UnityEngine.Random.Range(0f, 1f);
			return new Vector2(Mathf.Lerp(point1.x, point2.x, t), Mathf.Lerp(point1.y, point2.y, t));
		}


		/// <summary>
		/// Returns random point on line 3D.
		/// </summary>
		public static Vector3 RandomPointOnLine3D(Vector3 point1, Vector3 point2)
		{
			float t = UnityEngine.Random.Range(0f, 1f);
			return new Vector3(Mathf.Lerp(point1.x, point2.x, t), Mathf.Lerp(point1.y, point2.y, t), Mathf.Lerp(point1.z, point2.z, t));
		}


		/// <summary>
		/// Get random normalized 2D direction as Vector2.
		/// </summary>
		public static Vector2 RandomDirection2D()
		{
			return UnityEngine.Random.insideUnitCircle.normalized;
		}

		
		/// <summary>
		/// Return random point from rect bound (inside rect).
		/// </summary>
		public static Vector2 RandomPointInsideRect(Rect rect)
		{
			return new Vector2(UnityEngine.Random.Range(rect.xMin, rect.xMax), UnityEngine.Random.Range(rect.yMin, rect.yMax));
		}


		/// <summary>
		/// Return random point on rect border (perimeter of rect).
		/// </summary>
		public static Vector2 RandomPointOnRectBorder(Rect rect)
		{
			float perimeterLength = (rect.width + rect.height) * 2f;
			float pointOnPerimeter = UnityEngine.Random.Range(0f, perimeterLength);

			if (pointOnPerimeter < rect.width)//top border
				return new Vector2(rect.xMin + pointOnPerimeter, rect.yMax);

			pointOnPerimeter -= rect.width;

			if (pointOnPerimeter < rect.height)//right border
				return new Vector2(rect.xMax, rect.yMin + pointOnPerimeter);

			pointOnPerimeter -= rect.height;

			if (pointOnPerimeter < rect.width)//bottom border
				return new Vector2(rect.xMin + pointOnPerimeter, rect.yMin);

			pointOnPerimeter -= rect.width;

			//left border
			return new Vector2(rect.xMin, rect.yMin + pointOnPerimeter);
		}
	}
}

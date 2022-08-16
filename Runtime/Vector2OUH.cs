using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using OpenUnityHelp;

namespace OpenUnityHelp
{
    public static class Vector2OUH
    {
		///<summary>
		/// Returns a pixel perfect Vector2 by changing its coordinates to ints.
		///</summary>
		public static Vector2 GetPixelPerfect(Vector2 position)
		{
			return new Vector2((int)position.x, (int)position.y);
		}

		///<summary>
		/// Returns a rotated Vector2 by an angle.
		///</summary>
		public static Vector2 GetRotatedVector(Vector2 vector, float angle)
		{
			return Quaternion.AngleAxis(angle, Vector3.forward) * vector;
		}
	}
}


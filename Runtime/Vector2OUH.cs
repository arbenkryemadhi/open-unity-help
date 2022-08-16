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
		public static Vector2 GetPixelPerfect(Vector2 vector2)
		{
			return new Vector2((int)vector2.x, (int)vector2.y);
		}


		///<summary>
		/// Returns a rotated Vector2 by an angle.
		///</summary>
		public static Vector2 GetRotatedVector(Vector2 vector2, float angle)
		{
			return Quaternion.AngleAxis(angle, Vector3.forward) * vector2;
		}


		///<summary>
		/// Returns the angle of the Vector2.
		///</summary>
		public static float GetVectorAngle(Vector2 vector2)
		{
			return vector2.y > 0
					   ? Vector2.Angle(new Vector2(1, 0), vector2)
					   : -Vector2.Angle(new Vector2(1, 0), vector2);
		}
	}
}


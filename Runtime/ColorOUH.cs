using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using OpenUnityHelp;
using UnityEngine.UI;

namespace OpenUnityHelp
{
	public static class ColorOUH
    {
		/// <summary>
		/// Returns Color with desired alpha.
		/// </summary>
		public static Color GetColorWithSetAlpha(this Color color, float alpha)
		{
			return new Color(color.r, color.g, color.b, alpha);
		}


		/// <summary>
		/// Sets alpha of Graphic.
		/// </summary>
		public static void SetAlpha(this Graphic graphic, float alpha)
		{
			graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, alpha);
		}


		/// <summary>
		/// Sets alpha of SpriteRenderer.
		/// </summary>
		public static void SetAlpha(this SpriteRenderer spriteRenderer, float alpha)
		{
			spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
		}
	}
}


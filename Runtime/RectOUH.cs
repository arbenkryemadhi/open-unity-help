using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using OpenUnityHelp;


namespace OpenUnityHelp
{
	public static class RectOUH
    {
        #region RectTransform

		#region Left, Right, Top, Bottom

		public static void SetLeft(this RectTransform rectTransform, float left)
		{
			rectTransform.offsetMin = new Vector2(left, rectTransform.offsetMin.y);
		}

		public static float GetLeft(this RectTransform rectTransform)
		{
			return rectTransform.offsetMin.x;
		}
		
		public static void SetRight(this RectTransform rectTransform, float right)
		{
			rectTransform.offsetMax = new Vector2(-right, rectTransform.offsetMax.y);
		}

		public static float GetRight(this RectTransform rectTransform)
		{
			return -rectTransform.offsetMax.x;
		}

		public static void SetTop(this RectTransform rectTransform, float top)
		{
			rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -top);
		}

		public static float GetTop(this RectTransform rectTransform)
		{
			return -rectTransform.offsetMax.y;
		}

		public static void SetBottom(this RectTransform rectTransform, float bottom)
		{
			rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, bottom);
		}

		public static float GetBottom(this RectTransform rectTransform)
		{
			return rectTransform.offsetMin.y;
		}
		
		public static void SetLeftTopRightBottom(this RectTransform rectTransform, float left, float top, float right, float bottom)
		{
			rectTransform.offsetMin = new Vector2(left, bottom);
			rectTransform.offsetMax = new Vector2(-right, -top);
		}

		#endregion

		#region PosX, PosY, Width, Height

		public static void SetPosX(this RectTransform rectTransform, float posX)
		{
			rectTransform.anchoredPosition = new Vector2(posX, rectTransform.anchoredPosition.y);
		}

		public static void SetPosY(this RectTransform rectTransform, float posY)
		{
			rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, posY);
		}

		public static void SetPosXY(this RectTransform rectTransform, float posX, float posY)
		{
			rectTransform.anchoredPosition = new Vector2(posX, posY);
		}

		public static void SetWidth(this RectTransform rectTransform, float width)
		{
			rectTransform.sizeDelta = new Vector2(width, rectTransform.sizeDelta.y);
		}

		public static float GetWidth(this RectTransform rectTransform)
		{
			return rectTransform.rect.width;
		}

		public static void SetHeight(this RectTransform rectTransform, float height)
		{
			rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);
		}

		public static float GetHeight(this RectTransform rectTransform)
		{
			return rectTransform.rect.height;
		}

		public static void SetWidthHeight(this RectTransform rectTransform, float width, float height)
		{
			rectTransform.sizeDelta = new Vector2(width, height);
		}

		public static void SetPosAndSize(this RectTransform rectTransform, float posX, float posY, float width, float height)
		{
			rectTransform.anchoredPosition = new Vector2(posX, posY);
			rectTransform.sizeDelta = new Vector2(width, height);
		}

		#endregion
		
		#region Anchor Offset
		
		public static void SetLeftAnchorOffset(this RectTransform rectTransform, float leftPercent)
		{
			rectTransform.anchorMin = new Vector2(leftPercent, rectTransform.anchorMin.y);
		}

		public static void SetRightAnchorOffset(this RectTransform rectTransform, float rightPercent)
		{
			rectTransform.anchorMax = new Vector2(1f - rightPercent, rectTransform.anchorMax.y);
		}

		public static void SetTopAnchorOffset(this RectTransform rectTransform, float topPercent)
		{
			rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, 1f - topPercent);
		}

		public static void SetBottomAnchorOffset(this RectTransform rectTransform, float bottomPercent)
		{
			rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, bottomPercent);
		}

		public static void SetAnchorOffset(this RectTransform rectTransform, float left, float top, float right, float bottom)
		{
			rectTransform.anchorMin = new Vector2(left, bottom);
			rectTransform.anchorMax = new Vector2(1f - right, 1f - top);
		}

		#endregion

		#region World positions

		private static readonly Vector3[] _fourCorners = new Vector3[4];//start bottom left and clockwise

		public static Vector2 GetWorldCenter(this RectTransform rectTransform)
		{
			rectTransform.GetWorldCorners(_fourCorners);
			return new Vector2((_fourCorners[0].x + _fourCorners[3].x) / 2f, (_fourCorners[0].y + _fourCorners[1].y) / 2f);
		}

		public static float GetWorldLeft(this RectTransform rectTransform)
		{
			rectTransform.GetWorldCorners(_fourCorners);
			return _fourCorners[0].x;
		}

		public static float GetWorldRight(this RectTransform rectTransform)
		{
			rectTransform.GetWorldCorners(_fourCorners);
			return _fourCorners[2].x;
		}

		public static float GetWorldTop(this RectTransform rectTransform)
		{
			rectTransform.GetWorldCorners(_fourCorners);
			return _fourCorners[1].y;
		}

		public static float GetWorldBottom(this RectTransform rectTransform)
		{
			rectTransform.GetWorldCorners(_fourCorners);
			return _fourCorners[0].y;
		}

		public static Vector2 GetWorldTopLeft(this RectTransform rectTransform)
		{
			rectTransform.GetWorldCorners(_fourCorners);
			return new Vector2(_fourCorners[0].x, _fourCorners[1].y);
		}

		public static Vector2 GetWorldTopRight(this RectTransform rectTransform)
		{
			rectTransform.GetWorldCorners(_fourCorners);
			return new Vector2(_fourCorners[2].x, _fourCorners[1].y);
		}

		public static Vector2 GetWorldBottomLeft(this RectTransform rectTransform)
		{
			rectTransform.GetWorldCorners(_fourCorners);
			return new Vector2(_fourCorners[0].x, _fourCorners[0].y);
		}

		public static Vector2 GetWorldBottomRight(this RectTransform rectTransform)
		{
			rectTransform.GetWorldCorners(_fourCorners);
			return new Vector2(_fourCorners[2].x, _fourCorners[0].y);
		}

		public static Rect GetWorldRect(this RectTransform rectTransform)
		{
			rectTransform.GetWorldCorners(_fourCorners);
			return new Rect(_fourCorners[0].x, _fourCorners[0].y, Mathf.Abs(_fourCorners[3].x - _fourCorners[0].x), Mathf.Abs(_fourCorners[1].y - _fourCorners[0].y));
		}

		#endregion
		
		#endregion
    }
}


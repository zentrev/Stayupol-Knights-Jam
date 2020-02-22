using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StayupolKnights.ExtensionMethods
{
	public static class ExtensionMethods
	{
		public static Vector3 ConvertXYVectorToXZVector(this Vector2 xyVector, float yDefault = 0f)
		{
			return new Vector3(xyVector.x, yDefault, xyVector.y);
		}
	}
}

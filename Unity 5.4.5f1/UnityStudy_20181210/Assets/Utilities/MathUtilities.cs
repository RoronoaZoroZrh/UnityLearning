using UnityEngine;

namespace UNetStuty
{
    public class MathUtilities
    {
        public static float ClampAngle(float curAngle, float minAngle, float maxAngle)
        {
            while (curAngle <= -360) curAngle = curAngle + 360;
            while (curAngle >= +360) curAngle = curAngle - 360;
            return Mathf.Clamp(curAngle, minAngle, maxAngle);
        }
    }
}
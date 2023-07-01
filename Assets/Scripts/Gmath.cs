using UnityEngine;

namespace Gmath
{
    public static class Math
    {
        public static Vector2 Round(this Vector2 vector)
        {
            return new Vector2 (Mathf.Round(vector.x), Mathf.Round(vector.y));
        }
    }
}

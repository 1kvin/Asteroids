using UnityEngine;

namespace GameLogic.Utilities
{
    public static class ScreenUtilities
    {
        private const float saveZone = 2;
        private static int screenWidth;
        private static int screenHeight;
        private static Rect worldRect;

        public static Rect GetWorldRect()
        {
            if (ScreenSizeChanged())
            {
                ComputeWorldRectSize();
                SaveCurrentScreenSize();
            }

            return worldRect;
        }

        public static Vector3 GetRandomPointOuterScreen()
        {
            var rect = GetWorldRect();
            return new Vector3(RandomX(rect), RandomY(rect));
        }

        private static float RandomX(Rect rect)
        {
            return RandomOuterValue(rect.xMin, rect.xMax);
        }

        private static float RandomY(Rect rect)
        {
            return RandomOuterValue(rect.yMin, rect.yMax);
        }

        private static float RandomOuterValue(float min, float max)
        {
            return Random.Range(0, 2) == 0
                ? Random.Range(min - saveZone, min)
                : Random.Range(max, max + saveZone);
        }

        private static bool ScreenSizeChanged()
        {
            return (screenWidth != Screen.width || screenHeight != Screen.height);
        }

        private static void ComputeWorldRectSize()
        {
            var viewMin = Vector2.zero;
            var viewMax = Vector2.one;
            Vector2 worldMin = GetWorldPointFromViewport(viewMin);
            Vector2 worldMax = GetWorldPointFromViewport(viewMax);
            worldRect = Rect.MinMaxRect(worldMin.x, worldMin.y, worldMax.x, worldMax.y);
        }

        private static Vector2 GetWorldPointFromViewport(Vector3 viewportPoint)
        {
            return Camera.main.ViewportToWorldPoint(viewportPoint);
        }

        private static void SaveCurrentScreenSize()
        {
            screenWidth = Screen.width;
            screenHeight = Screen.height;
        }
    }
}
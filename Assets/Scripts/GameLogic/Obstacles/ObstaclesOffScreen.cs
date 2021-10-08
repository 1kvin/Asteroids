using GameLogic.Utilities;
using UnityEngine;

namespace GameLogic.Obstacles
{
    public class ObstaclesScreen
    {
        private readonly Renderer objectRenderer;
        private readonly Obstacle obstacle;
        private readonly Transform objectTransform;
        private Bounds objectBounds;
        
        public ObstaclesScreen(Obstacle obstacle, Renderer objectRenderer, Transform objectTransform)
        {
            this.obstacle = obstacle;
            this.objectRenderer = objectRenderer;
            this.objectTransform = objectTransform;
        }

        public void Check()
        {
            var worldRect = ScreenUtilities.GetWorldRect();
            objectBounds = objectRenderer.bounds;

            bool isOutOfBoundsRight = objectBounds.min.x > worldRect.xMax;
            bool isOutOfBoundsLeft = objectBounds.max.x < worldRect.xMin;
            bool isOutOfBoundsTop = objectBounds.min.y > worldRect.yMax;
            bool isOutOfBoundsBottom = objectBounds.max.y < worldRect.yMin;

            bool needToWrapHorizontally = isOutOfBoundsRight || isOutOfBoundsLeft;
            bool needToWrapVertically = isOutOfBoundsTop || isOutOfBoundsBottom;

            Vector3 newPosition = objectTransform.position;

            if (needToWrapHorizontally)
            {
                newPosition.x = isOutOfBoundsRight ? WrapRightToLeft(worldRect) : WrapLeftToRight(worldRect);
            }


            if (needToWrapVertically)
            {
                newPosition.y = isOutOfBoundsTop ? WrapTopToBottom(worldRect) : WrapBottomToTop(worldRect);
            }


            if (!newPosition.Equals(objectTransform.position))
            {
                obstacle.Position = newPosition;
            }
        }

        private float WrapRightToLeft(Rect worldRect)
        {
            return worldRect.xMin - objectBounds.extents.x;
        }

        private float WrapLeftToRight(Rect worldRect)
        {
            return worldRect.xMax + objectBounds.extents.x;
        }

        private float WrapTopToBottom(Rect worldRect)
        {
            return worldRect.yMin - objectBounds.extents.y;
        }

        private float WrapBottomToTop(Rect worldRect)
        {
            return worldRect.yMax + objectBounds.extents.y;
        }
    }
}
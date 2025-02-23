using UnityEngine;

namespace UsefulUnityScripts
{
	public abstract class SwipeControllerBase : MonoBehaviour
	{

        public delegate void SwipeDetected(SwipeDirection swipeDirection);
        public static event SwipeDetected OnSwipeDetected;

        [SerializeField] protected float minSwipeLength = 10f;
		[SerializeField] private float swipeTime = 0.5f;
        [SerializeField] private float diagonalSwipeAngle = 20;

        protected bool swipeInProgress;
        protected Vector2 swipeStartPosition;
        protected Vector2 swipeEndPosition;
        protected float swipeEndTime;

        protected void CheckSwipe()
        {
            if (!CheckSwipeLength())
                return;

            CalculateSwipeDirection(swipeStartPosition, swipeEndPosition);
        }

        protected void DetectSwipeStart()
        {
            swipeEndTime = Time.time + swipeTime;
            swipeInProgress = true;
        }

        protected void DetectSwipeEnd()
        {
            swipeInProgress = false;
        }

        private bool CheckSwipeLength()
        {
            return (swipeStartPosition - swipeEndPosition).magnitude > minSwipeLength;
        }

        private void CalculateSwipeDirection(Vector2 start, Vector2 end)
        {
            Vector2 direction = (end - start).normalized;
            float horizontalValue = Mathf.Abs(direction.x);
            float verticalValue = Mathf.Abs(direction.y);

            var horizontalSign = Mathf.Sign(direction.x);
            var verticalSign = Mathf.Sign(direction.y);

            SwipeDirection swipeDirection = SwipeDirection.None;
            if (horizontalValue >= verticalValue)
            {
                swipeDirection |= horizontalSign > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                // multiplying by sign to match horizontal direction and have angle be between 0 and 90
                if (Vector2.Angle(Vector2.right * horizontalSign, direction) > diagonalSwipeAngle)
                    swipeDirection |= verticalSign > 0 ? SwipeDirection.Up : SwipeDirection.Down;
            }
            else
            {
                swipeDirection |= verticalSign > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                if (Vector2.Angle(Vector2.up * verticalSign, direction) > diagonalSwipeAngle)
                    swipeDirection |= horizontalSign > 0 ? SwipeDirection.Right : SwipeDirection.Left;
            }

            DetectedSwipe(swipeDirection);
        }

        private void DetectedSwipe(SwipeDirection swipeDirection)
        {
            OnSwipeDetected?.Invoke(swipeDirection);
        }

    }
}

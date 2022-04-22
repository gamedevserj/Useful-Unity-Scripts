using UnityEngine;

namespace UsefulUnityScripts
{
	public abstract class SwipeControllerBase : MonoBehaviour
	{

		#region Serialized fields

		[SerializeField] protected float minSwipeLength = 10f;
		[SerializeField] protected float swipeTime = 0.5f;
		[SerializeField] protected float diagonalSwipeThreshold = 0.4f;

        #endregion


        #region Protected fields

        protected bool swipeInProgress;

        protected Vector2 swipeStartPosition;
        protected Vector2 swipeEndPosition;

        protected float swipeEndTime;

        #endregion


        #region Events

        public delegate void SwipeDetected(SwipeDirection swipeDirection);
        public static event SwipeDetected OnSwipeDetected;

        #endregion


        #region Protected methods

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

        #endregion


        #region Private methods

        private bool CheckSwipeLength()
        {
            float verticalSwipeLength = Mathf.Abs(swipeStartPosition.y - swipeEndPosition.y);
            float horizontalSwipeLength = Mathf.Abs(swipeStartPosition.x - swipeEndPosition.x);
            if (verticalSwipeLength > minSwipeLength || horizontalSwipeLength > minSwipeLength)
                return true;
            else
                return false;
        }

        private void CalculateSwipeDirection(Vector2 start, Vector2 end)
        {
            Vector2 direction = (end - start).normalized;
            float horizontalValue = Mathf.Abs(direction.x);
            float verticalValue = Mathf.Abs(direction.y);

            if (horizontalValue > verticalValue) // horizontal swipe
            {
                if (direction.x > 0) // swipe right
                {
                    if (direction.x - Mathf.Abs(direction.y) < diagonalSwipeThreshold) // checking for diagonal
                    {
                        if (direction.y > 0)
                        {
                            DetectedSwipe(SwipeDirection.UpRight);
                        }
                        else
                        {
                            DetectedSwipe(SwipeDirection.DownRight);
                        }
                    }
                    else
                    {
                        DetectedSwipe(SwipeDirection.Right);
                    }
                }
                else // swipe left
                {
                    if (Mathf.Abs(direction.x) - Mathf.Abs(direction.y) < diagonalSwipeThreshold) // checking for diagonal
                    {
                        if (direction.y > 0)
                        {
                            DetectedSwipe(SwipeDirection.UpLeft);
                        }
                        else
                        {
                            DetectedSwipe(SwipeDirection.DownLeft);
                        }
                    }
                    else
                    {
                        DetectedSwipe(SwipeDirection.Left);
                    }
                }
            }
            else if (horizontalValue < verticalValue) // vertical swipe
            {
                if (direction.y > 0) // swipe up
                {
                    if (direction.y - Mathf.Abs(direction.x) < diagonalSwipeThreshold) // checking for diagonal
                    {
                        if (direction.x > 0)
                        {
                            DetectedSwipe(SwipeDirection.UpRight);
                        }
                        else
                        {
                            DetectedSwipe(SwipeDirection.UpLeft);
                        }
                    }
                    else
                    {
                        DetectedSwipe(SwipeDirection.Up);
                    }
                }
                else // swipe down
                {
                    if (Mathf.Abs(direction.y) - Mathf.Abs(direction.x) < diagonalSwipeThreshold) // checking for diagonal
                    {
                        if (direction.x > 0)
                        {
                            DetectedSwipe(SwipeDirection.DownRight);
                        }
                        else
                        {
                            DetectedSwipe(SwipeDirection.DownLeft);
                        }
                    }
                    else
                    {
                        DetectedSwipe(SwipeDirection.Down);
                    }
                }
            }
            else // in case both x and y directions are equal
            {
                if (direction.y > 0) // diagonal up
                {
                    if (direction.x > 0)
                    {
                        DetectedSwipe(SwipeDirection.UpRight);
                    }
                    else
                    {
                        DetectedSwipe(SwipeDirection.UpLeft);
                    }
                }
                else // diagonal down
                {
                    if (direction.x > 0)
                    {
                        DetectedSwipe(SwipeDirection.DownRight);
                    }
                    else
                    {
                        DetectedSwipe(SwipeDirection.DownLeft);
                    }
                }
            }


        }
        private void DetectedSwipe(SwipeDirection swipeDirection)
        {
            OnSwipeDetected?.Invoke(swipeDirection);
        }

        #endregion

    }
}

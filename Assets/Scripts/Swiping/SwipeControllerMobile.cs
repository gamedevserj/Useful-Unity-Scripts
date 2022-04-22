using UnityEngine;

#if UNITY_ANDROID || UNITY_IOS
namespace UsefulUnityScripts
{
    public class SwipeControllerMobile : SwipeControllerBase
    {

        #region Unity methods

        private void Update()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    swipeStartPosition = touch.position;
                    swipeEndPosition = touch.position;
                    DetectSwipeStart();

                }
                if (swipeInProgress && (touch.phase == TouchPhase.Ended || swipeEndTime < Time.time))
                {
                    swipeEndPosition = touch.position;
                    DetectSwipeEnd();
                    CheckSwipe();
                }
            }
        }

        #endregion

    }
}
#endif
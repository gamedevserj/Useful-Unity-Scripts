using UnityEngine;

#if UNITY_EDITOR
namespace UsefulUnityScripts
{
    public class SwipeControllerPC : SwipeControllerBase
    {

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                swipeEndPosition = Input.mousePosition;
                swipeStartPosition = Input.mousePosition;
                DetectSwipeStart();
            }

            if (swipeInProgress && (Input.GetMouseButtonUp(0) || swipeEndTime < Time.time))
            {
                swipeEndPosition = Input.mousePosition;
                DetectSwipeEnd();
                CheckSwipe();
            }

            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                swipeStartPosition = Vector2.zero;
                swipeEndPosition = Vector2.up * minSwipeLength * 2;
                CheckSwipe();
            }
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                swipeStartPosition = Vector2.zero;
                swipeEndPosition = (Vector2.up + Vector2.right) * minSwipeLength * 2;
                CheckSwipe();
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                swipeStartPosition = Vector2.zero;
                swipeEndPosition = (Vector2.right) * minSwipeLength * 2;
                CheckSwipe();
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                swipeStartPosition = Vector2.zero;
                swipeEndPosition = (Vector2.down + Vector2.right) * minSwipeLength * 2;
                CheckSwipe();
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                swipeStartPosition = Vector2.zero;
                swipeEndPosition = (Vector2.down) * minSwipeLength * 2;
                CheckSwipe();
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                swipeStartPosition = Vector2.zero;
                swipeEndPosition = (Vector2.down + Vector2.left) * minSwipeLength * 2;
                CheckSwipe();
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                swipeStartPosition = Vector2.zero;
                swipeEndPosition = (Vector2.left) * minSwipeLength * 2;
                CheckSwipe();
            }
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                swipeStartPosition = Vector2.zero;
                swipeEndPosition = (Vector2.up + Vector2.left) * minSwipeLength * 2;
                CheckSwipe();
            }
        }
    }
}
#endif
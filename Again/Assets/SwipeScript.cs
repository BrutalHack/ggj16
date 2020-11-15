using UnityEngine;

//https://pfonseca.com/swipe-detection-on-unity
public class SwipeScript : MonoBehaviour
{
    private Vector2 fingerStartPos = Vector2.zero;

    private float fingerStartTime;
    private HallucinationSpawner halluSpawner;

    private bool isSwipe;
    private readonly float maxSwipeTime = 0.5f;
    private readonly float minSwipeDist = 50.0f;

    private void Awake()
    {
        halluSpawner = GetComponent<HallucinationSpawner>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
            foreach (var touch in Input.touches)
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        /* this is a new touch */
                        isSwipe = true;
                        fingerStartTime = Time.time;
                        fingerStartPos = touch.position;
                        break;

                    case TouchPhase.Canceled:
                        /* The touch is being canceled */
                        isSwipe = false;
                        break;

                    case TouchPhase.Ended:

                        var gestureTime = Time.time - fingerStartTime;
                        var gestureDist = (touch.position - fingerStartPos).magnitude;

                        if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                        {
                            var direction = touch.position - fingerStartPos;
                            var swipeType = Vector2.zero;

                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                                // the swipe is horizontal:
                                swipeType = Vector2.right * Mathf.Sign(direction.x);
                            else
                                // the swipe is vertical:
                                swipeType = Vector2.up * Mathf.Sign(direction.y);

                            RemoveHallucination(direction);
                        }

                        break;
                }
    }

    private void RemoveHallucination(Vector2 direction)
    {
        halluSpawner.killHallu(direction);
    }
}
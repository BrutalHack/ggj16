using UnityEngine;

[RequireComponent(typeof(Tilt))]
public class MoveWithInertia : MonoBehaviour
{
    public GameControl control;
    private float lastXpos;
    private float speed;
    private Transform target;
    private Tilt tilt;

    private void Awake()
    {
        tilt = GetComponent<Tilt>();
        target = GetComponent<Transform>();
        lastXpos = Input.mousePosition.x;
    }

    private void Update()
    {
        float delta = 0;
        if (GameControl.demo)
        {
            delta = Input.mousePosition.x - lastXpos;
            lastXpos = Input.mousePosition.x;
            delta *= 0.05f;
        }
        else
        {
            delta = Input.acceleration.x;
        }

        speed = speed + delta;
        target.Translate(speed * Time.deltaTime, 0, 0, Space.World);
        if (target.position.x > 3.25f)
        {
            target.position = new Vector3(0, target.position.y, target.position.z);
            speed = 0;
            control.Fail();
        }
        else if (target.position.x < -3.25f)
        {
            target.position = new Vector3(0, target.position.y, target.position.z);
            speed = 0;
            control.Fail();
        }

        tilt.angle = speed * 10;
    }
}
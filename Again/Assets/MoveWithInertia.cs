using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Tilt))]
public class MoveWithInertia : MonoBehaviour
{
    private Transform target;
    private Tilt tilt;
    private float speed = 0;
    private float lastXpos = 0;
    public GameControl control;

    void Awake()
    {
        tilt = GetComponent<Tilt>();
        target = GetComponent<Transform>();
        lastXpos = Input.mousePosition.x;
    }
	
    void Update()
    {   float delta=0;
        if (GameControl.demo) {
            delta=Input.mousePosition.x - lastXpos;
            lastXpos = Input.mousePosition.x;
            delta *= 0.05f;
        }
        else
        {
            delta=Input.acceleration.x;
        }
        speed = speed + delta;
        target.Translate(speed * Time.deltaTime, 0, 0,Space.World);
        if (target.position.x > 3.25f)
        {
            target.position = new Vector3(0, target.position.y, target.position.z);
            speed = 0;
            control.Fail();
        }else if(target.position.x < -3.25f){
            target.position = new Vector3(0, target.position.y, target.position.z);
            speed = 0;
            control.Fail();
        }
        tilt.angle = speed * 10;
    }
}

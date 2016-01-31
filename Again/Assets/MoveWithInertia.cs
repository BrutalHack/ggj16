using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Tilt))]
public class MoveWithInertia : MonoBehaviour
{
    private Transform target;
    private Tilt tilt;
    private float speed = 0;
    public GameControl control;
    void Awake()
    {
        tilt = GetComponent<Tilt>();
        target = GetComponent<Transform>();   
    }
	
    void Update()
    {
        speed = speed + Input.acceleration.x;
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

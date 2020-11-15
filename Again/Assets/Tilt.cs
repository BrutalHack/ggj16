using UnityEngine;

public class Tilt : MonoBehaviour
{
    public float angle;

    private Transform tiltee;

    // Use this for initialization
    private void Start()
    {
        tiltee = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        tiltee.rotation = Quaternion.Euler(0, 0, angle);
    }
}
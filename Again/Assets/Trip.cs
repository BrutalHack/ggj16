using UnityEngine;

public class Trip : MonoBehaviour
{
    public GameControl controller;

    private void OnTriggerEnter(Collider other)
    {
        controller.Fail();
    }
}
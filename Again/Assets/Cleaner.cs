using UnityEngine;
using System.Collections;

public class Cleaner : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.transform.parent.gameObject);
    }
}

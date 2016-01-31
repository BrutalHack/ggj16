using UnityEngine;
using System.Collections;

public class ScrollFloor : MonoBehaviour
{
    public float speed = 1;
    public Material floorMaterial;
    
    void Update()
    {   
        Vector2 oldOffset = floorMaterial.GetTextureOffset("_MainTex");

        floorMaterial.SetTextureOffset("_MainTex", new Vector2(0, oldOffset.y - Time.deltaTime * speed));
    }
}

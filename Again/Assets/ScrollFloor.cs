using UnityEngine;

public class ScrollFloor : MonoBehaviour
{
    public float speed = 1;
    public Material floorMaterial;

    private void Update()
    {
        var oldOffset = floorMaterial.GetTextureOffset("_MainTex");

        floorMaterial.SetTextureOffset("_MainTex", new Vector2(0, oldOffset.y - Time.deltaTime * speed));
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float Scroll_Speed = 0.1f;
    private MeshRenderer mesh_Renderer;
    void Start()   {

        mesh_Renderer = GetComponent<MeshRenderer>();
}
 
    // Update is called once per frame
    void Update()
    {
        float x = Time.time * Scroll_Speed;

        Vector2 offset = new Vector2(x, 0);

        mesh_Renderer. sharedMaterial.SetTextureOffset ("MainTex", offset);
    }
}

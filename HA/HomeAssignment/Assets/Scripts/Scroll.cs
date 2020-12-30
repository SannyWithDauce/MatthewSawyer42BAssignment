using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] float bgspeed = 5f;

    private MeshRenderer mesh_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame 
    void Update()
    {
        float y = Time.time * bgspeed;
        
        Vector2 offset = new Vector2(0, y);

        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}

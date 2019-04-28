using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPoint : MonoBehaviour
{
    public tileLogic tile;
    public int index;
    public Material endMaterial;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("PaintTile", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PaintTile()
    {
        tile.MeshRenderer.material = endMaterial;
    }
}

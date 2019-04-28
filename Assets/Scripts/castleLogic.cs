using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castleLogic : MonoBehaviour
{
    public int health;
    public Mesh[] stageMeshes;
    public MeshFilter mesh;
    public float pointsToNextHeart = 0f;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        mesh = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsToNextHeart >= 5f)
        {
            pointsToNextHeart -= 5f;
            health++;
        }

        if (health <= 5)
        {
            mesh.mesh = stageMeshes[0];
        }else if(health > 5 && health <= 10)
        {
            mesh.mesh = stageMeshes[1];
        }
        else if (health > 10 && health <= 15)
        {
            mesh.mesh = stageMeshes[2];
        }
    }
  
}

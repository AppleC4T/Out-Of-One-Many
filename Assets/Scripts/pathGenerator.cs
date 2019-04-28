using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathGenerator : MonoBehaviour
{
    public int startingPlace;
    public Vector3 startPos;
    public tileLogic currentTile;
    public makePath pather;
    public GameObject waypoint;
    public Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPlace = Random.Range(0, 6);
        startPos = new Vector3(-10f + (4f * startingPlace), 1f, -14f);
        transform.position = startPos;
        pather = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<makePath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTile.canBePath == true && currentTile.isPath == false && pather.pathPoints > 0)
        {
            currentTile.isPath = true;
            currentTile.MeshRenderer.material = currentTile.pathMaterial;
            Instantiate(waypoint, transform.position, Quaternion.identity);
            pather.pathPoints--;
        }

        newPos = transform.position;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            newPos += new Vector3(0f, 0f, 4f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            newPos -= new Vector3(0f, 0f, 4f);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            newPos += new Vector3(4f, 0f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            newPos -= new Vector3(4f, 0f, 0f);
        }

        newPos.x = Mathf.Clamp(newPos.x, -10f, 10f);
        newPos.z = Mathf.Clamp(newPos.z, -14f, 14f);
        transform.position = newPos;
    }

    void OnCollisionStay(Collision collision)
    {
        currentTile = collision.collider.GetComponent<tileLogic>();
        //currentTile.MeshRenderer.material = currentTile.pathHighlight;
    }
}

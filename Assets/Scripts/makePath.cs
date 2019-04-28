using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makePath : MonoBehaviour
{
    public bool isPathMade = false;
    public GameObject waypoint;
    public int pathPoints = 20;
    public Transform[] path;
    public GameObject searcher;
    public pathGenerator generator;
    public castleLogic castle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isPathMade == false && GameObject.FindGameObjectWithTag("Searcher") == null)
        {
            CheckPath();
        }
    }

    public void CheckPath()
    {
        Instantiate(searcher, generator.startPos, Quaternion.identity);
    }

    public void ResetPath()
    {
        isPathMade = false;
        pathPoints = 20;

        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].GetComponent<tileLogic>().isPath = false;
            tiles[i].GetComponent<tileLogic>().MeshRenderer.material = tiles[i].GetComponent<tileLogic>().startingMaterial;
        }
        tiles = null;
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        for (int i = 0; i < waypoints.Length; i++)
        {
            Destroy(waypoints[i]);
        }
        waypoints = null;
        generator.transform.position = generator.startPos;
    }
}

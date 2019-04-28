using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class searcherLogic : MonoBehaviour
{
    public float speed = 60f;
    private Transform target;
    private int waypointIndex = 0;
    public makePath master;
    public GameObject[] endpoints;
    public Waypoints waypointsG;
    public castleLogic castle;
    

    // Start is called before the first frame update
    void Start()
    {
        waypointsG = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        waypointsG.GetWaypoints();
        target = Waypoints.waypoints[0];
        endpoints = GameObject.FindGameObjectsWithTag("EndPoint");
        master = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<makePath>();
        castle = GameObject.FindGameObjectWithTag("Castle").GetComponent<castleLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            TargetAnotherWaypoint();
        }

       
    }

    void TargetAnotherWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {   
            if (Vector3.Distance(transform.position, endpoints[0].transform.position) <= 0.4f)
            {
                master.isPathMade = true;
                endpoints[1].GetComponent<endPoint>().tile.MeshRenderer.material = endpoints[1].GetComponent<endPoint>().tile.startingMaterial;
                GameObject.FindGameObjectWithTag("EnemySpawner").transform.position = GameObject.FindGameObjectWithTag("PathGenerator").GetComponent<pathGenerator>().startPos;
                Destroy(GameObject.FindGameObjectWithTag("PathGenerator"));
                castle.pointsToNextHeart += master.pathPoints;
                killEntity();
            }
            else if (Vector3.Distance(transform.position,endpoints[1].transform.position) <= 0.4f)
            {
                master.isPathMade = true;
                endpoints[0].GetComponent<endPoint>().tile.MeshRenderer.material = endpoints[0].GetComponent<endPoint>().tile.startingMaterial;
                GameObject.FindGameObjectWithTag("EnemySpawner").transform.position = GameObject.FindGameObjectWithTag("PathGenerator").GetComponent<pathGenerator>().startPos;
                Destroy(GameObject.FindGameObjectWithTag("PathGenerator"));
                castle.pointsToNextHeart += master.pathPoints;
                killEntity();
            }
            else
            {
                master.ResetPath();
            }
            killEntity();
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];

    }

    void killEntity()
    {
        Destroy(gameObject);
        return;
    }
}

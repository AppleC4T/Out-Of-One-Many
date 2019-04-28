using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{
    public float speed = 4f;
    private Transform target;
    private int waypointIndex = 0;
    public float health = 1f;
    public enemySpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.waypoints[0];
        if (spawner.waveIndex > 10)
        {
            health = 1.2f;
        }else if (spawner.waveIndex > 15)
        {
            health = 1.5f;
        }
        else if (spawner.waveIndex > 20)
        {
            health = 2.4f;
        }
        else if (spawner.waveIndex > 30)
        {
            health = 3f;
        }
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

        if (health <= 0f)
        {
            killEntity();
        }
    }

    void TargetAnotherWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            GameObject.FindGameObjectWithTag("Castle").GetComponent<castleLogic>().health -= 1;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowFollow : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, (transform.position - target.position), Time.deltaTime, 0f));
        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.1f);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            Destroy(gameObject);
        }
    }

}

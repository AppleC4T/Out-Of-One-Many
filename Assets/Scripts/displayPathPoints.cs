using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayPathPoints : MonoBehaviour
{
    public Text text;
    public makePath points;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (points.isPathMade == false)
        {
            text.text = "Path Length: " + (20 - points.pathPoints).ToString() + "/20";
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

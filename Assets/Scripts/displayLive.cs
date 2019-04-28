using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayLive : MonoBehaviour
{
    public Text text;
    public castleLogic castle;
    public int liveIvensted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        for (int i = 0; i < towers.Length; i++)
        {
            if (towers[i].GetComponent<towerLogic>().level == 1)
            {
                liveIvensted += 1;
            }
            else if (towers[i].GetComponent<towerLogic>().level == 2)
            {
                liveIvensted += 3;
            }
            else if (towers[i].GetComponent<towerLogic>().level == 3)
            {
                liveIvensted += 6;
            }
        }

        text.text = castle.health.ToString() + "/" + (liveIvensted + castle.health).ToString();
        liveIvensted = 0;
    }
}

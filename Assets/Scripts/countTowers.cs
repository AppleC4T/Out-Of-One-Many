using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countTowers : MonoBehaviour
{
    public int selectedLevel;
    public int towerNum;
    public Text text;
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
            if (towers[i].GetComponent<towerLogic>().level == selectedLevel)
            {
                towerNum++;
            }
        }

        text.text = "x" + towerNum.ToString();
        towerNum = 0;
    }
}

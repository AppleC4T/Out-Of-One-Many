using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayWave : MonoBehaviour
{
    public enemySpawner waveSpawner;
    public Text text;
    public makePath master;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Wave " + (waveSpawner.waveIndex +1).ToString();

        if (waveSpawner.isWaveFinished == true && master.isPathMade == true)
        {
            text.text += "\n Get ready for the next wave, press space when you're ready!";
        }
    }
}

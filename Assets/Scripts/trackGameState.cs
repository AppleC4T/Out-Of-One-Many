using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class trackGameState : MonoBehaviour
{
    public castleLogic castle;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (castle.health <= 0)
        {
            gameOver.SetActive(true);
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}

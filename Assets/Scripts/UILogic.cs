﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILogic : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

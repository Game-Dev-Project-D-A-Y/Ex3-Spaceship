﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
    Script for restart button
*/
public class RestartButton : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene("PartC");
        Time.timeScale = 1;
    }

}
using UnityEngine;
using System.Collections;
using System;

public class MenuActions : MonoBehaviour {
    public string backScene;

    public void Play()
    {
        Application.LoadLevel("Game");
    }
    public void About()
    {
        Application.LoadLevel("About");
    }
    public void Menu()
    {
        Application.LoadLevel("Menu");
    }
    public void Exit()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (string.IsNullOrEmpty(backScene))
                Exit();
            else
                Application.LoadLevel(backScene);
        }
    }
}

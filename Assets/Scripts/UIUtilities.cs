﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUtilities : MonoBehaviour
{
    public UnityEngine.UI.Button VRMode;

    private void Start()
    {
        if (CheckScreenSize() >= 7f)
        {
            if (VRMode)
            {
                VRMode.gameObject.SetActive(false);
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 0)
            {
                ChangeScenes("MainMenu");
            }
            else
            {
                ExitApp();
            }
        }
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void ChangeScenes(string aScanaName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(aScanaName);
    }

    public float CheckScreenSize()
    {
        float height = Screen.height;
        float width = Screen.width;
        float dpi = Screen.dpi;

        height *= height;
        width *= width;

        float diag = Mathf.Sqrt(width + height) / dpi;

        return diag;
    }

    public void DisableGameobject(GameObject aObject)
    {
        aObject.SetActive(false);
    }

    public void OpenUrl(string url)
    {
        Application.OpenURL(url);
    }
}

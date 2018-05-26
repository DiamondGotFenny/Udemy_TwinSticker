using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;
    private bool isPaused = false;

    float intialFixedDeltaTime;

    private void Start()
    {
        PlayerPrefsManager.UnlockLevel(2);
        print(PlayerPrefsManager.IsLevelUnlock(2));
        print(PlayerPrefsManager.IsLevelUnlock(0));

        intialFixedDeltaTime = Time.fixedDeltaTime;
        Debug.Log(intialFixedDeltaTime + " intialFixedDeltaTime");
    }

    // Update is called once per frame
    void Update () {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale==1)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
            
        }
	}

    void PauseGame()
    {
        Time.timeScale = 0 ;
        Time.fixedDeltaTime = 0;
        isPaused = true;
        Debug.Log("Pause " + Time.fixedDeltaTime);
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = intialFixedDeltaTime;
        isPaused = false;
        Debug.Log("resume " + Time.fixedDeltaTime);
    }

    private void OnApplicationPause(bool pause)
    {
       isPaused=pause;
    }

    private void OnApplicationFocus(bool focus)
    {
        isPaused = !focus;
    }
}

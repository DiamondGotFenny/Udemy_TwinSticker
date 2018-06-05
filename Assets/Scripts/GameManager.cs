using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class GameManager : MonoBehaviour {

    public bool recording = true;
    private bool isPaused = false;

    float intialFixedDeltaTime;

    #region Singleton
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        #region SingletonRun
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
            {
                Destroy(this.gameObject);
            }
        }
        #endregion
    }

    private void Start()
    {
        PlayerPrefsManager.UnlockLevel(2);


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

    private void LoadNextLevel()
    {
        int sceneNum = SceneManager.sceneCountInBuildSettings;
        int currentSceneIndext = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndext<sceneNum)
        {
            SceneManager.LoadScene(currentSceneIndext + 1);
        }
        else
        {
            return;
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}

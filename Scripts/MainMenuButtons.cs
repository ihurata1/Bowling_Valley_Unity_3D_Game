using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject mainMenuCamera;
    public Button[] levelButton;
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("level1", 1);
        mainMenuCamera = GameObject.Find("MainCamera");
        for (int i = 0; i < levelButton.Length; i++)
        {
            //Debug.Log(levelReached);
            if(i+1 > levelReached)
                levelButton[i].interactable = false;
        }
    }
    // Start is called before the first frame update
    public void play(){
        mainMenuCamera.transform.position = new Vector3(mainMenuCamera.transform.position.x, 1000f, mainMenuCamera.transform.position.z );
    }
    public void levelsText(){
        mainMenuCamera.transform.position = new Vector3(mainMenuCamera.transform.position.x, 0f, mainMenuCamera.transform.position.z);
    }
    public void quit(){
        Application.Quit();
    }
    public void loadScene (string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}

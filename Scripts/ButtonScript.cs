
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private GameManager gm;
    public GameObject panel;
    public GameObject trollText;
    public Button resButton;

    private void Start()
    {
        
        gm = GameObject.Find("LevelManager").GetComponent<GameManager>();
        //levels = gm.scenes;
        resButton.image.enabled = false;
        Time.timeScale = 0;
        
    }
    
    public void restrat(){
        trollText.SetActive(false);
        panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void play (){
        trollText.SetActive(false);
        Time.timeScale = 1;
        resButton.image.enabled = true;
        panel.SetActive(false);
        
    }
    public void nextLevel(){
        Debug.Log(gm.scenes.Length + "is the length");
        SceneManager.LoadScene(gm.scenes[PlayerPrefs.GetInt("level1")-1].ToString());
    }
    public void levelScene (){
        SceneManager.LoadScene("MainMenu");
    }

}

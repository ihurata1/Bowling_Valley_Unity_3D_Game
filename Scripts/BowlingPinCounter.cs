using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BowlingPinCounter : MonoBehaviour
{
    private GameObject levelBarr;
    private Image fill;
    private Image bar;
    private Image circle1;
    private Image circle2;
    private Text text1;
    private Text text2;
    private GameManager gm;
    private Text score;
    public GameObject cam;
    private Button nextLevel;
    public GameObject StrikeText;
    private GameObject endPanel;
    public Animator anim;
    private int sceneID;
    private bool truee = true;
    public float timeCounter = 0.0f;
    public bool one = true;
    private bool increase;
    public static int droppedPins;
    private static Coroutine lastCoroutine;
    public AudioSource sfx;
    public AudioSource sfxSpare;
    public AudioSource sfxStrike;
    void Awake()
    {
        levelBarr = GameObject.Find("LevelBarr");
        fill = GameObject.Find("fill").GetComponent<Image>();
        circle1 = GameObject.Find("circle1").GetComponent<Image>();
        bar = GameObject.Find("bar").GetComponent<Image>();
        circle2 = GameObject.Find("circle2").GetComponent<Image>();
        text1 = GameObject.Find("Text1").GetComponent<Text>();
        text2 = GameObject.Find("Text2").GetComponent<Text>();
        fill.fillAmount = 0;
        endPanel = GameObject.Find("endPanel");
        droppedPins = 0;
        
        
        
    }
    private void Start()
    {
        
        sceneID = int.Parse(SceneManager.GetActiveScene().name);
        text1.text = sceneID.ToString();
        text2.text = (sceneID + 1).ToString();
        increase = true;
        score = GameObject.Find("Score").GetComponent<Text>();
        nextLevel = GameObject.Find("NextLevel").GetComponent<Button>();
        nextLevel.interactable = false;
        endPanel.SetActive(false);
        levelBarr.SetActive(false);
        bar.color = Color.yellow;
        circle1.color = Color.yellow;
        circle2.color = Color.yellow;
        fill.color = Color.yellow;
    }
    private void Update()
    {   
        if(droppedPins >=1)
        timeCounter += Time.deltaTime;
        if (timeCounter > 10.0f)
        {
            Time.timeScale = 0;
        if(score!= null){
            if(droppedPins == 10)
                score.text = (droppedPins * 200).ToString();
            else
                score.text = (droppedPins * 100).ToString();
            if(droppedPins>=5){
                if(increase){
                    if(sceneID>=PlayerPrefs.GetInt("level1"))
                    PlayerPrefs.SetInt("level1", sceneID+1);
                    
                }
                
                increase = false;
                nextLevel.interactable=true;
                if (PlayerPrefs.GetInt("level1") == 25)
                    {
                        nextLevel.interactable = false;
                    }
                fill.fillAmount=1;
            }
            else{
                bar.color = Color.red;
                circle1.color = Color.red;
                circle2.color = Color.red;
                fill.color = Color.red;
            }
                
            endPanel.SetActive(true);
            }
            
            
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        
        Destroy(GameObject.FindGameObjectWithTag("snowPS"));
        sfx.Stop();
        //sfxSpare.Stop();
        sfx.Play();
        //gameOver.GetComponent<BoxCollider>().enabled=false;
        if (lastCoroutine != null)
        {
            StopCoroutine(lastCoroutine);
        }
        lastCoroutine = StartCoroutine(GameOverAfterSeconds(5));
        StopCoroutine(lastCoroutine);
        other.enabled = false;
        //bowlingCamera.SetActive(true);
        //score.PinDownScore();
        cam.SetActive(true);
        if(fill.fillAmount<=1){
            fill.fillAmount = (float)(fill.fillAmount) + 0.2f;
           
        }
        if(fill.fillAmount==1){
            circle1.color = Color.green;
            bar.color = Color.green;
            fill.color = Color.green;
            circle2.color = Color.green;
        }
            

        anim.speed = 0;
        droppedPins++;
        Debug.Log(droppedPins);
        if (droppedPins == 5)
        {

            sfx.Stop();
            sfxSpare.Play();
        }
        if (droppedPins == 10)
        {
            StrikeText.SetActive(true);
            sfx.Stop();
            sfxSpare.Stop();
            sfxStrike.Play();
            //strike.countStrike();
        }

        if (truee==true){
             GameObject.Find("Floating Joystick").SetActive(false);
             levelBarr.SetActive(true);
            truee = false;
        }


    }

    IEnumerator GameOverAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        //gameOver.GameOverScreen();
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
   public GameObject trollText;
   public GameObject character;
   public int seconds = 0;
   public ParticleSystem firePs;
   public ParticleSystem explPs;
   public AudioSource expSFX;
   private float firstClickTime, timeBetweenClicks;
   private bool coroutineAllowed;
   private int clickCounter;
   public Rigidbody rb;
   public Animator animator;
   private CarMove carMove; // CarMove Class'ına erişim
   public float speedx;
   public float timeCounter = 0.0f;
   public GameObject analog;
   public ParticleSystem snowPs;
   private int zero = 0;
public AudioSource sfx;
   
    void Start()
   {
    firePs.Stop();
    explPs.Stop();
    GameObject skate = GameObject.Find("Skatee"); 
    carMove = skate.GetComponent<CarMove>();    // Skate objesindeki CarMove Class'ına erişim
    speedx = carMove.speed;     // Car Move Class'ındaki speed değerine erişim
    snowPs.Stop();
    firstClickTime = 0f;
    timeBetweenClicks = 0.35f;
    clickCounter = 0;
    
    coroutineAllowed = true;   
   }
    void Update()
   {
    
    //explPs.transform.position = character.transform.position;
    timeCounter += Time.deltaTime;
    seconds = (int)timeCounter % 60;
    if(BowlingPinCounter.droppedPins == 0){
    if(seconds == 14)
        firePs.Play();
    if(seconds == 17){
        explPs.Play();
        expSFX.Play();
        firePs.Stop();
        trollText.SetActive(true);
        character.SetActive(false);
        } 
    }    
    speedx = carMove.speed;
    if(Input.GetMouseButtonUp(0) && !IsPointerOverUIObject()){
        clickCounter+=1;
    }   
    if(clickCounter == 1 && coroutineAllowed)
    {
        firstClickTime = Time.time;
        StartCoroutine(DoubleClickDetection());
    }
   }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
   
   private IEnumerator DoubleClickDetection()
   {
       coroutineAllowed = false;
       while(Time.time <firstClickTime+timeBetweenClicks)
       {
           if(clickCounter==2){
               Debug.Log("Double Click");
               
               snowPs.Play();
               rb.AddForce (transform.up * Time.deltaTime * speedx*1500);
               rb.AddForce(transform.forward * Time.deltaTime * speedx*10000);
               rb.useGravity = true;
               animator.Play("Flying");
               carMove.speed = 0;
               analog.SetActive(true);
               if (zero == 0)
                sfx.Play();
               zero++; 
               break;
           }
           yield return new WaitForEndOfFrame();
       }
        clickCounter = 0;
        firstClickTime = 0f;
        coroutineAllowed = true;
   }
}
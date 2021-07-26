using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skateHitEngel : MonoBehaviour
{   
    public GameObject trollText;
    private CarMove carMove;
    public ParticleSystem ps;
    public ParticleSystem smokePS;
    public AudioSource sfx;
    private void Awake()
    {
        smokePS.Stop();
    }
    private void Start()
    {
        ps.Stop();
        
        GameObject skate = GameObject.Find("Skatee");
        carMove = skate.GetComponent<CarMove>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "engel")
        {
            
            carMove.speed=0;
            sfx.Play();

            GameObject.Find("Skatee").SetActive(false);
            GameObject.Find("tnt").SetActive(false);
            ps.Play();
            smokePS.Play();
            trollText.SetActive(true);
            
            //Time.timeScale = 0;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bowlAreaAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator[] bowlAreaAnim;
    private GameManager gM;
    public Animator animator;
    private int index = 0 ;
    void Start()
    {
        gM = GameObject.Find("LevelManager").GetComponent<GameManager>();
        index = gM.scenes[int.Parse(SceneManager.GetActiveScene().name)-1] ;
        Debug.Log(index + " index");
        animator.runtimeAnimatorController = bowlAreaAnim[index-1].runtimeAnimatorController;
        
    }
  

    // Update is called once per frame

}

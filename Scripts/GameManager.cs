using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int[] scenes;
    // Start is called before the first frame update
    void Start()
    {
        scenes = new int [24];
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i] = (i+1);
            
        }
    }
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlAreaSpawner : MonoBehaviour
{
    public GameObject prefab;
    //public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
       
        Instantiate(prefab, new Vector3(-1.8878f,66.1f,484.3f), Quaternion.identity);
    }

    // Update is called once per frame
}

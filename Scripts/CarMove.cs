using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarMove : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
      
           if (speed > 1)
            {
                if (Input.GetMouseButton(0) && !IsPointerOverUIObject())
                {
                    if (speed < 75)
                        speed += 0.3f;
                }
                else
                {
                    if (speed > 4)
                        speed -= 0.1f;

                }
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            //Debug.Log(speed);
       
            
        
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

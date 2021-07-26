using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FollowCamera : MonoBehaviour
{
    private CarMove carMove;

    public Camera mainCam ;

    public Transform PlayerTransform;

    public Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    private bool isTrue = true;
    // Start is called before the first frame update
    void Start()
    {
        GameObject skate = GameObject.Find("Skatee");
        GameObject cam = GameObject.Find("Main Camera");
        carMove = skate.GetComponent<CarMove>();
        mainCam = cam.GetComponent<Camera>();
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameObject.Find("bowlingman") != null)
        {
           // Debug.Log(carMove.speed);
            if (carMove.speed > 1)
            {
                if (Input.GetMouseButton(0) && !IsPointerOverUIObject())
                {
                    _cameraOffset.z -= 0.04f;
                    if (_cameraOffset.z > -15.0f)
                        _cameraOffset.z -= 0.04f;
                }
                if (_cameraOffset.z <= -12.0)
                    _cameraOffset.z += 0.04f;
            }
            else if (carMove.speed == 0 )
            {
                
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, 90f , 0.5f);
                _cameraOffset.z = Mathf.Lerp(_cameraOffset.z,-26.0f, 0.5f);
                _cameraOffset.y = Mathf.Lerp(_cameraOffset.y, 19.0f, 0.5f);
                /*or (int i = 0; i < 12; i++)
                {
                    //-26
                    _cameraOffset.z -= 1f;
                }
                for (int i = 0; i < 7; i++)
                {   //19
                    _cameraOffset.y += 1f;
                }*/
                //isTrue = false;
            }


            Vector3 newPos = PlayerTransform.position + _cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
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

}

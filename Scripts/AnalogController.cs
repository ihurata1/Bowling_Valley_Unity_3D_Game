
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogController : MonoBehaviour
{
    Quaternion right;
    Quaternion left;
    Quaternion normal;
    public GameObject player;
    public Vector3 playerTransform;
    Joystick joystick;
    public float xSensivity;
    public float ySensivity;
    public Rigidbody rbPlayer;

    void Start()
    {
        player = GameObject.Find("bowlingman");
        xSensivity = 250f;
        ySensivity = 250f;
        joystick = FindObjectOfType<Joystick>();
        playerTransform = player.transform.localRotation.eulerAngles;
        right = Quaternion.Euler(playerTransform.x, playerTransform.y, 350f);
        left = Quaternion.Euler(playerTransform.x, playerTransform.y, 10f);
        normal = Quaternion.Euler(playerTransform.x, playerTransform.y, playerTransform.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("bowlingman") != null)
        {
            rbPlayer.AddForce(transform.right * joystick.Horizontal * xSensivity * Time.deltaTime * rbPlayer.velocity.z * 0.1f);
            Debug.Log("horiz = " + joystick.Horizontal);
            rbPlayer.AddForce(transform.up * joystick.Vertical * ySensivity * Time.deltaTime * rbPlayer.velocity.z * 0.1f);
            if (joystick.Horizontal > 0.3f)
            {
                player.transform.rotation = Quaternion.Lerp(normal, right, Time.time * Mathf.Abs(joystick.Horizontal));
            }
            else if (joystick.Horizontal < -0.3f)
            {
                player.transform.rotation = Quaternion.Lerp(normal, left, Time.time * Mathf.Abs(joystick.Horizontal));
            }
            else
            {

                player.transform.rotation = Quaternion.Lerp(player.transform.rotation, normal, Time.time * Mathf.Abs(joystick.Horizontal));
            }
        }
    }
}

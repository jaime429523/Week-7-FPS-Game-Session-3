using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{

    public float speed;

    public float upRotation;
    public float downRotation;

    CharacterController characterControl;
    public Transform playerCam;

    Vector3 Vel;

    public float lookSensitivity;
    float xRotation = 0;
    public TMP_Text itemText;
    public string lookingAt = "nothing";
    

    public bool hasKey = false;
    
    PlayerControl playerScript;


    // Start is called before the first frame update
    void Start()
    {   
        characterControl = GetComponent<CharacterController>();
        itemText.text = lookingAt;

        Cursor.lockState = CursorLockMode.Locked;
        characterControl = GetComponent<CharacterController>();

        playerScript = GameObject.Find("Player").GetComponent<PlayerControl>();

    }

    // Update is called once per frame
    void Update()

    {
        Vector3 newPos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            newPos.z = newPos.z + speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPos.z = newPos.z - speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPos.x = newPos.x - speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPos.x = newPos.x + speed * Time.deltaTime;
        }
        transform.position = newPos;           
    
        transform.Rotate(0,Input.GetAxis("Mouse X") * lookSensitivity,0);
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, - upRotation, downRotation);
        playerCam.localRotation = Quaternion.Euler(xRotation,0,0);

        Vel.z = Input.GetAxis("Vertical") * speed;
        Vel.x = Input.GetAxis("Horizontal") * speed;

        Vel = transform.TransformDirection(Vel);
        characterControl.Move(Vel * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collect")
        {
            Destroy(other.gameObject);
        }
    }

     void OnMouseDown()
    {
        playerScript.hasKey = true;
        Destroy(gameObject);
    }
}

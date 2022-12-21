using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float speed = 20f;

    float horizontalInput;
    float verticalInput;
    float rotationSpeed = 35f;

    public GameObject cube;
    public Transform cubeTransform;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        cubeTransform = cube.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(direction * speed * Time.deltaTime);

        cameraMovement();        
    }

    void cameraMovement(){     
        
        Quaternion currentRotation = cube.transform.rotation;
        Quaternion wantedRotation;

        float zRot = 0f;
        float xRot = 0f;

        //Left and Right Movement
        if(horizontalInput > 0){
            zRot = -5f;
        } else if(horizontalInput < 0){
            zRot = 5f;
        } else{
            zRot = 0f;
        }

        //Forwards and Backwards Movement
        if(verticalInput > 0){
            xRot = 10f;
        } else if(verticalInput < 0){
            xRot = -10f;
        } else{
            xRot = 0f;
        }

        wantedRotation = Quaternion.Euler(xRot,0f, zRot );
        cube.transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
    }
}

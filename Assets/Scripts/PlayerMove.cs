using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    public float speed = 10.0f;
    void Update()
    {
      Operation();
    }
 
    void Operation()
    {
        CharacterController characterController = GetComponent<CharacterController>();
      Vector3 up = new Vector3(speed,0,0);
      Vector3 down  = new Vector3(-speed,0,0);
      Vector3 left = new Vector3(0,0,speed);
      Vector3 right = new Vector3(0,0,-speed);
 
      //if (Input.GetKey (KeyCode.UpArrow)) 
          //transform.position += transform.up * speed * Time.deltaTime;
 
      //if (Input.GetKey (KeyCode.DownArrow)) 
          //transform.position -= transform.up * speed * Time.deltaTime;
 
      if (Input.GetKey(KeyCode.UpArrow)) 
          //transform.position += transform.right * speed * Time.deltaTime;
          characterController.SimpleMove(up);
 
      if (Input.GetKey (KeyCode.DownArrow)) 
          //transform.position -= transform.right * speed * Time.deltaTime;
          characterController.SimpleMove(down);
 
      if (Input.GetKey (KeyCode.LeftArrow)) 
          //transform.position += transform.forward * speed * Time.deltaTime;
          characterController.SimpleMove(left);
 
      if (Input.GetKey (KeyCode.RightArrow)) 
          //transform.position -= transform.forward * speed * Time.deltaTime;
          characterController.SimpleMove(right);
    }
}
    
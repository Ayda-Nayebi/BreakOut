using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
   // private Camera mainCamera;
    private Transform maxMarker;
    private Transform minMarker;
    private float MovmentHorizontal;
 

    [SerializeField] private float speed = 20;
   

  
    private void Update()
    {
        GetInputs();

        //if(ballController.rigidbody2D.simulated == false)
        //    isActive = false;

        //if (MovmentHorizontal != 0) { }

        //if (isActive == false)
        //    return;

        MovePaddle();
    }

    private void GetInputs() 
    {
       // mainCamera = GetComponent<Camera>();

        MovmentHorizontal = Input.GetAxis("Horizontal");

        maxMarker = GameObject.FindGameObjectWithTag("Max Marker").GetComponent<Transform>();
        minMarker = GameObject.FindGameObjectWithTag("Min Marker").GetComponent<Transform>();
        
    }

   // private void ActivateBall() 
   // {
      //  BallController.Instance.GetComponent<Rigidbody2D>().simulated = true;
  //  }

    private void MovePaddle()
    {
        if (MovmentHorizontal == 0)
            return;
      // float mouseMovment = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , 0, 0)).x;
        transform.position += MovmentHorizontal * speed * Time.deltaTime * Vector3.right;

        LimitPaddleToBounds();
    }

    private void LimitPaddleToBounds()
    {
        if (transform.position.x > maxMarker.position.x)
        {
            // set position to max
            transform.position = maxMarker.position;
        }

        if (transform.position.x < minMarker.position.x)
        {
            // set position to - max
            transform.position = minMarker.position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempCameraMovement : WarzoneElement {

    public tempCameraMovement instace;

    public float speed = 10f;
    public ComandCentre CC;

    private Vector3 startingPosition;
    public float MIN_X;
    public float MAX_X;
    public float MIN_Y;
    public float MAX_Y;
    public float MIN_Z;
    public float MAX_Z;

    // Use this for initialization
    void Start () {
        startingPosition = transform.position;
        
	}

    void Update()
    {
        if (GameManager.gameOver)
        {
            return;
        }

        //Camera Boundaries
        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, MIN_X, MAX_X),
          Mathf.Clamp(transform.position.y, MIN_Y, MAX_Y),
          Mathf.Clamp(transform.position.z, MIN_Z, MAX_Z));

        if (Input.GetKey(KeyCode.S))
        {
            
            transform.Translate(new Vector3(speed * Time.deltaTime,0), Space.World);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (CC.isUiActive())
            {
                return;
            }
            transform.Translate(new Vector3(-speed * Time.deltaTime,0), Space.World);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            
            App.Controller.BuildingViewReset();
            transform.localPosition = new Vector3(7.67f, 31.2f, 26.8f);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            App.Controller.CC_Controller.ShowUI();
            transform.position = startingPosition;
        }
        if (Input.GetKey(KeyCode.R))
        {
            MAX_Y +=1;
            MIN_Y +=1;
            transform.localPosition = transform.localPosition + new Vector3(0, 1, 0); 
        }
        if (Input.GetKey(KeyCode.F))
        {
            MAX_Y -= 1;
            MIN_Y -= 1;
            transform.localPosition = transform.localPosition + new Vector3(0, -1, 0);
        }


    }
}

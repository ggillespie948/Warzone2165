using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrel_Click : MonoBehaviour {

    public Text oilText;
    private float barrelTimer = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(barrelTimer <= 0f)
        {
            Destroy(gameObject);
        }
        barrelTimer -= Time.deltaTime;
		
	}

    void OnMouseDown()
    {
        PlayerVariables.Oil++;
        Destroy(gameObject);
        
    }
}

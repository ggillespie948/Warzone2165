using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pylon_Controller : MonoBehaviour {

    public float pylonRadius = 0f;

    public Node TargetNode;

    // Use this for initialization
    void Start () {
        Debug.Log("Boom");
        Collider[] affectedNodes = Physics.OverlapSphere(transform.position, pylonRadius);
        foreach (Collider col in affectedNodes)
        {
            if (col.tag == "Node")
            {
                TargetNode = col.GetComponent<Node>();
                TargetNode.ActivateNode();
            }
        }

    }

    void Awake()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
       

    }


}

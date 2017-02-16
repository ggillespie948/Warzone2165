using UnityEngine;

public class Waypoints : MonoBehaviour {

    //static so we don't need a reference to script and can access anywhere
    public static Transform[] waypoints;        //Transform is used for an array of gameobjects

    void Awake()
    {
        waypoints = new Transform[transform.childCount];

        for (int i = 0; i<waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
	
}

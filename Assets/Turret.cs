using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    public float range = 10f;
    public string enemyTag = "Enemy";

    public Transform rotationPart;
    public float rotationSpeed = 10f;

    public float fireRate = 1f;
    private float fireCount = 1f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("FindTarget", 0f, 0.5f);
	}

    void FindTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject nearestEnemy = null;
        float closestEnemyDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(enemyDistance < closestEnemyDistance)
            {
                nearestEnemy = enemy;
                closestEnemyDistance = enemyDistance;
            }
        }

        if(nearestEnemy != null && (closestEnemyDistance <= range) )
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    

    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            return;
        }

        //Lock on to target
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotationPart.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;    //eular angles = xyz
        rotationPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);


		
	}

    //Function that always draws sphere displaying turret range
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}

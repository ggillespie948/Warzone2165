using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    private Enemy targetEnemyComp;

    public bool upgraded;

    public GameObject bulletPrefab;

    public Transform firePosition;
    public Transform altFirePosition;

    public GameObject RangeIndicator;

    [Header("Turret Attributes")]
    public float range = 10f;
    public float fireRate = 1f;
    private float fireCount = 0f;
    public float rotationSpeed = 10f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public float damageOverTime = 35;
    public float slowRate = 99f;
    public ParticleSystem impactEffect;
    public ParticleSystem fireEffect;

    [Header("Use Flame")]
    public bool useFlame = false;
    public GameObject FLAME_FX;
    public float burnDamageOverTime = 70;

    [Header("Msc")]
    public string enemyTag = "Enemy";
    public Transform rotationPart;

    
    

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
            targetEnemyComp = target.GetComponent<Enemy>();
        } else
        {
            target = null;
        }
    

    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    
                }
            } else if (useFlame)
            {
                FLAME_FX.SetActive(false);
            }
            return;
        }

        TargetLockOn();
                
        if (useLaser)
        {
            Laser();
        } else if (useFlame)
        {
            Flame();

        } else
        {
            if (fireCount <= 0f)
            {
                if (!upgraded)
                {
                    Shoot(firePosition);

                    if (altFirePosition != null)
                        Shoot(altFirePosition);

                } else
                {


                }
                


                fireCount = (1f / fireRate);
            }

            fireCount -= Time.deltaTime;
        }

        
		
	}

    void TargetLockOn()
    {
        //Lock on to target
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotationPart.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;    //eular angles = xyz
        rotationPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                
    }

    void Shoot(Transform _firePosition)
    {
        GameObject bulletInst = Instantiate(bulletPrefab, _firePosition.position, firePosition.rotation);
        bullet bullet = bulletInst.GetComponent<bullet>();

        bullet.Fire(target);

    }

    void Laser()
    {
        targetEnemyComp.Damage(damageOverTime * Time.deltaTime);
        targetEnemyComp.Slow(slowRate);

        if (this.tag == "Laser")
        {
            if (!lineRenderer.enabled)
            {
                lineRenderer.enabled = true;
                //fireEffect.Play();
                impactEffect.Play();

            }

            lineRenderer.SetPosition(0, firePosition.position);
            lineRenderer.SetPosition(1, target.position);

            Vector3 dir = firePosition.position - target.position;

            //fireEffect.transform.position = firePosition.position;
            impactEffect.transform.position = target.position;// + dir.normalized * .75f;
            impactEffect.transform.rotation = Quaternion.LookRotation(dir);
        }

    }

    void Flame()
    {
        targetEnemyComp.Damage(burnDamageOverTime * Time.deltaTime);
        targetEnemyComp.Burn(2f);
        FLAME_FX.SetActive(true);

    }

    //Function that always draws sphere displaying turret range
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}

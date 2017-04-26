using UnityEngine;

public class bullet : MonoBehaviour {

    private Transform target;

    public float speed = 50f;
    public int damage = 20;
    public float explosionRadius = 0f;
    public GameObject bulletSpark;
    public bool sniper;
    
    public void Fire (Transform btarget)
    {
        target = btarget;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float currentDistance = speed * Time.deltaTime;

        if(dir.magnitude <= currentDistance)    //dir.magnitude = current distance to target
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * currentDistance, Space.World); //normalize so speed is constant
        transform.LookAt(target);
	}

    void HitTarget()
    {
        GameObject sparkIns = Instantiate(bulletSpark, transform.position, transform.rotation);
        Destroy(sparkIns, 1f);

        if (explosionRadius > 0f)
        {
            Explode();

        } else
        {
            Damage(target);

        }

        
        Destroy(gameObject);
    }

    void Damage(Transform target)
    {
        Enemy eTarget = target.GetComponent<Enemy>();

        if (eTarget!= null){
            eTarget.Damage(damage);

        }
        
    }

    void Explode()
    {
        Collider[] affectedColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider col in affectedColliders)
        {
            if(col.tag == "Enemy")
            {
                Damage(col.transform);
            }
        }


    }
}

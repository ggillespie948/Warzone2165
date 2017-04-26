using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : WarzoneElement {

    public GameObject oil_barrel;

    //Move To Enemy Model
    public float startSpeed = 10f;
    public float speed = 10f;
    public float startHealth = 150;
    private float health;
    public int bounty = 10;

    //Tempt before conversion to MVC
    public GameObject visuals;

    private bool reachedBase = false;

    public bool onFire = false;
    private float burnTime;

    public GameObject burn_FX;
    public Animation BountyAnimation;

    private Transform target;
    private GameObject targetBuildingController;

    private int waypointIndex = 0;
    private Transform[] walkPath;

    [Header("Unity Stuff")]
    public Image HPbar;

    void Start()
    {
        walkPath = Waypoints.waypoints;
        target = walkPath[0];
        transform.LookAt(target);
        speed = startSpeed;
        health = startHealth;
        onFire = false;
        burn_FX.SetActive(false);
        BountyAnimation = GetComponentInChildren<Animation>();

    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);    //normalized to make sure it always has same fixed sped so speed var is only thing controlling speed

        if (Vector3.Distance(transform.position, target.position) <= 2f)
        {
            transform.LookAt(target);
            //HPbar.transform.LookAt(App.View.CC_View.transform);
            //HPbar.transform.parent.gameObject.transform.rotation = this.transform.rotation *=  Quaternion.Euler(0,90,0);
        }

        if (Vector3.Distance(transform.position, target.position) <= 10f)
        {
            GetNextWaypoint();
        }

        speed = startSpeed;

        if (onFire)
        {
            if(burnTime <= 0f)
            {
                burn_FX.SetActive(false);
                onFire = false;
            }
            burnTime -= Time.deltaTime;
            Damage(0.1f);

        }


    }

    public void Damage(float dmgAmount)
    {
        health = health - dmgAmount;
        HPbar.fillAmount = health / startHealth;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow(float slowPercent)
    {
        speed = startSpeed * (1f - slowPercent);
        if (speed < 1f)
            speed = 3f;
    }

    public void Burn(float duration)
    {
        onFire = true;
        burn_FX.SetActive(true);
        burnTime = duration;
        

    }

    void Die()
    {
        PlayerVariables.Cash += bounty;
        Text bountytext = GetComponentInChildren<Text>();
        bountytext.text = "+" + bounty.ToString();
        int rnd = Random.Range(1, 15);
        if (rnd == 2)
        {
            SpawnBarrel();
        }


        BountyAnimation.Play();
        Destroy(visuals);
        HPbar.transform.parent.position = new Vector3(0, 0, 0); //temporarily move HP bar background as it cannot be destoryed yet
        Destroy(gameObject, 0.7f);
    }

    void GetNextWaypoint()
    {
        if(waypointIndex >= walkPath.Length - 1 && reachedBase == false)
        {
            
            //Destory enemy if reaches last waypoint
            reachedBase = true;
            waypointIndex = 0;
            HPbar.transform.parent.gameObject.SetActive(false);
            bool selected = false;
            while(selected == false)
            {
                int buildingSelector = Random.Range(0, 7);
                //buildingSelector = 3;
                Debug.Log("BS: " + buildingSelector);
                switch (buildingSelector)
                {
                    case 0:
                        Debug.Log("CC");
                            walkPath = App.Model.CC_Model.waypoints;
                            target = walkPath[waypointIndex];
                            App.Controller.CC_Controller.DamageBuilding(1);
                            selected = true;
                        break;

                    case 1:
                        Debug.Log("AR");
                        if (PlayerVariables.hasAR)
                        {
                            walkPath = App.Model.AR_Model.waypoints;
                            target = walkPath[waypointIndex];
                            App.Controller.AR_Controller.DamageBuilding(1);
                            selected = true;
                        }
                        break;

                    case 2:
                        Debug.Log("ADV");
                        if (PlayerVariables.hasADV)
                        {
                            walkPath = App.Model.Advanced_Model.waypoints;
                            target = walkPath[waypointIndex];
                            App.Controller.Advanced_Controller.DamageBuilding(1);
                            selected = true;
                        }
                        break;

                    case 3:
                        Debug.Log("SNP");
                        if (PlayerVariables.hasSniperAcademy)
                        {
                            walkPath = App.Model.SniperAcad_Model.waypoints;
                            target = walkPath[waypointIndex];
                            target = walkPath[waypointIndex];
                            selected = true;
                        }
                        break;

                    case 4:
                        Debug.Log("MSL");
                        if (PlayerVariables.hasMissileFactory)
                        {
                            walkPath = App.Model.MissileFactory_Model.waypoints;
                            target = walkPath[waypointIndex];
                            selected = true;
                        }
                        break;

                    case 5:
                        Debug.Log("LSR");
                        if (PlayerVariables.hasLSR)
                        {
                            walkPath = App.Model.Laser_Building_Model.waypoints;
                            target = walkPath[waypointIndex];
                            selected = true;
                        }
                        break;

                    case 6:
                        Debug.Log("FLM");
                        if (PlayerVariables.hasFLM)
                        {
                            walkPath = App.Model.Flame_Building_Model.waypoints;
                            target = walkPath[waypointIndex];
                            selected = true;
                        }
                        break;

                }

            }

            //walkPath = App.Model.SniperAcad_Model.waypoints;
            return;
        }

        if (waypointIndex >= walkPath.Length - 1 && reachedBase == true)
        {
            //Destory enemy if reaches last waypoint
            PlayerVariables.Lives--;
            //Reduce Building Health

            Destroy(gameObject);
            return;
        } else if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            waypointIndex++;
            target = walkPath[waypointIndex];
            transform.LookAt(target);
            return;
        }
        
        Transform lookTarget = walkPath[waypointIndex + 1];

    }

    void SpawnBarrel()
    {
        //Direction Offsets
        Vector3 offRight = new Vector3(-1, 1, 1);
        Vector3 offDown = new Vector3(1, 1, 1);
        Vector3 offLeft = new Vector3(1, 1, -1);
        Vector3 offUp = new Vector3(1, -1, 1);

        Vector3 offsetDir = new Vector3();

        int offsetInt = Random.Range(1, 5);

        switch (offsetInt)
        {
            case 1:
                offsetDir = offDown;
                break;

            case 2:
                offsetDir = offUp;
                break;

            case 3:
                offsetDir = offLeft;
                break;

            case 4:
                offsetDir = offRight;
                break;

        }


        GameObject barrel = Instantiate(oil_barrel, transform.position, transform.rotation);
        //float thrust = 50f;

        //barrel.GetComponent<Rigidbody>().AddForce((Vector3.up + offsetDir ) * thrust);
        

    }

}

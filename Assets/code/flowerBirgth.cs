using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class flowerBirgth : MonoBehaviour
{

    public ParticleSystem part;
    public GameObject flower;
    public List<ParticleCollisionEvent> collisionEvents;
    public flowerManager myMan;
    public int myNum;
    public int maxFlow;



    public GameObject stebel;
    public GameObject flowerTop;

    //eatingGO
    public GameObject eater;
    public GameObject food;

    //mutation 
    public float life;
    public int productivity = 2;
    public float str = 1;
    public int leavesNumm = 5;
    public float livingTime;
    //mutColor
    private float stebelR = 0f;
    private float stebelG = 1f;
    private float stebelB = 0f;
    private float flowerTopR = 1f;
    private float flowerTopG = 0f;
    private float flowerTopB = 0f;
    //
    public int Generation;
    public float iLive;
    
    //taking from soil
    public foodMult fmObj;
    private float deltaForFood;
    private float timeForFood;
    private float mult;


    public bool iAmFood = false;

    void Start()
    {
        stebelR = Mathf.Clamp(stebelR, 0f, 1f);
        stebelG = Mathf.Clamp(stebelG, 0f, 1f);
        stebelB = Mathf.Clamp(stebelB, 0f, 1f);
        flowerTopR = Mathf.Clamp(flowerTopR, 0f, 1f);
        flowerTopG = Mathf.Clamp(flowerTopG, 0f, 1f);
        flowerTopB = Mathf.Clamp(flowerTopB, 0f, 1f);

        stebel.GetComponent<Renderer>().material.SetColor("_Color", new Color(stebelR, stebelG, stebelB));
        flowerTop.GetComponent<Renderer>().material.SetColor("_SpecColor", new Color(flowerTopR, flowerTopG, flowerTopB));

        part = GetComponent<ParticleSystem>();
        var emit = part.emission;
        emit.rateOverTime = productivity;

        collisionEvents = new List<ParticleCollisionEvent>();

        if (myMan != null)
        { 
            myNum = myMan.flowerInScene;
            maxFlow = myMan.maxFlowers;
            myMan.flowerInScene++;
            iLive = Time.time;
        }

    }
    void FixedUpdate()
    {

        livingTime += Time.deltaTime;
        life -= livingTime;

        if (life <= 0.1f)
        {
            myMan.flowerInScene--;

            myMan.food = this.gameObject;
            Destroy(this.gameObject);
        }

        if(fmObj != null && fmObj.mult > 0.1f) //some black magic lol (working somehow!!!!)
        {
            timeForFood += Time.deltaTime;
            deltaForFood -= timeForFood/10;
            
            fmObj.mult += deltaForFood/fmObj.speedOfDrain;
            
            life += fmObj.mult/fmObj.speedOfDrain;
        }


    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "flower")
        {
            eater = collision.gameObject;

            flowerBirgth foreinStr = eater.GetComponent<flowerBirgth>();

            if (str < foreinStr.str && eater != null && !iAmFood)
            {
                food = this.gameObject;
               
                if (eater != null && food != null)
                {
                    iAmFood = true;
                    myMan.flowerInScene--;
                    Destroy(this.gameObject);

                }
            }
        }
        if (collision.gameObject.tag == "foodLayer")
        {
            fmObj = collision.gameObject.GetComponent<foodMult>();

        }

    }


    void OnParticleCollision(GameObject other)
    {
        int avalibleNum = myMan.flowerInScene;
        maxFlow = myMan.maxFlowers;

        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        int i = 0;
        if (avalibleNum >= maxFlow)
        {
            // Destroy(part);
        }
        else
        {
            Vector3 pos = collisionEvents[i].intersection;
            Vector3 normal = collisionEvents[i].normal;
            var instance = Instantiate(flower, pos, Quaternion.LookRotation(normal));
            flowerBirgth futurB = instance.GetComponent<flowerBirgth>();
            futurB.Generation = Generation + 1;
            futurB.life = life * Random.Range(0.5f, 2f);
            futurB.str = str * Random.Range(0.5f, 1.5f);
           
            futurB.stebelR = stebelR - Random.Range(0f, 1f) + Random.Range(0f, 1f);
            futurB.stebelG = stebelG - Random.Range(0f, 1f) + Random.Range(0f, 1f);
            futurB.stebelB = stebelB - Random.Range(0f, 1f) + Random.Range(0f, 1f);
            futurB.flowerTopR = flowerTopR - Random.Range(0f, 1f) + Random.Range(0f, 1f);
            futurB.flowerTopG = flowerTopG - Random.Range(0f, 1f) + Random.Range(0f, 1f);
            futurB.flowerTopB = flowerTopB - Random.Range(0f, 1f) + Random.Range(0f, 1f);
        }

    }


}

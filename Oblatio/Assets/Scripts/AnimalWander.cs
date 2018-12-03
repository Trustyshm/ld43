using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalWander : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject Gateway;

    public int levelTwo;
    public int levelThree;
    

    private Animator anim;
    public gm gm;
    private int randomSpot;
    public float wanderRadius;
    public float wanderTimer;

    public SpriteRenderer sr;


    public Transform wanderSpot;
    [SerializeField]
    private float timer;


    private ParticleSystem ps;
    private TrailRenderer trail;

    public bool beingFed;

    private bool animalMoving;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private int growth;

    private bool doOnce = true;
    private bool doOnceTwo = true;
    private bool doOnceThree = true;

    public float fullAmount;
    private float lastMeal;

    // Use this for initialization
    void OnEnable()
    {
        timer = wanderTimer;
    }

    private void Start()
    {
        wanderSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        lastMeal = fullAmount;
       ps = GetComponentInChildren<ParticleSystem>();
       trail = GetComponentInChildren<TrailRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (beingFed == false)
        {
          //  Debug.Log("Test");
            timer += Time.deltaTime;
        }

        if (beingFed == true)
        {
            timer = 0;
            MakeFalse();
           // lastMeal = fullAmount;
           // growth += 1;

        }
       // timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
       
            //move to determined location
            if (wanderSpot.position.x < transform.position.x)
            {
                sr.flipX = false;
            }

            if (wanderSpot.position.x > transform.position.x)
            {
                sr.flipX = true;
            }

            transform.position = Vector2.MoveTowards (transform.position, wanderSpot.position, gm.animalSpeed * Time.deltaTime);
            animalMoving = true;

            //if at destination or being fed
            if (Vector2.Distance(transform.position, wanderSpot.position) < 0.2f || beingFed == true)
            {
                //select a new wander spot
                wanderSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                animalMoving = false;
                timer = 0;
                MakeFalse();
            }
            
        }

        //Debug.Log(AnimalWander.beingFed);

       // if (beingFed == true)
        //{
          //  lastMeal = fullAmount;
           // Debug.Log("this is happening");
           // growth += 1;


       // }

        if (!beingFed)
        {
            lastMeal -= Time.deltaTime;
        }

        if (lastMeal <= 0)
        {
            if (doOnce)
            {
                AnimalDeath();
            }

        }

        if (lastMeal < -20)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0f;
        }

        if (growth == levelTwo && doOnceTwo)
        {
            GrowToLevelTwo();

        }

        if (growth == levelThree && doOnceThree)
        {
            GrowToLevelThree();
        }





          anim.SetBool("animalMoving", animalMoving);
    }

    public void WasFed()
    {
        lastMeal = fullAmount;
    }

    public void Growing()
    {
        growth += 1;
    }

    public void MakeFalse()
    {
        beingFed = false;
    }

    public void AnimalDeath()
    {
        Debug.Log("This kills the rabbit");
        doOnce = false;
        //play death sound
        //do death animation
    }

    public void GrowToLevelTwo()
    {
        doOnceTwo = false;
        Debug.Log("Reached growth 1!");
        this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x * 2f, this.gameObject.transform.localScale.y * 2f, 1);
        //play growing noise
        //growing particles
    }

    public void GrowToLevelThree()
    {
        doOnceThree = false;
        Debug.Log("Reached growth2!");
        ps.enableEmission = true;
        trail.enabled = true;
        gm.numberAtMax += 1;
        //Gateway.GetComponent<DoorController>().OpenGateway();
        
    }

    public void AnimalExploded()
    {
        ps.enableEmission = false;
        trail.enabled = false;
    }


}


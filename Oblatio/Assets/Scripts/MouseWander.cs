using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWander : MonoBehaviour {

    private Animator anim;
    public gm gm;
    private int randomSpot;
    public float wanderRadius;
    public float wanderTimer;

    public Transform wanderSpot;

    private float timer;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        timer = wanderTimer;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

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

            transform.position = Vector2.MoveTowards(transform.position, wanderSpot.position, gm.animalSpeed * Time.deltaTime);


            if (Vector2.Distance(transform.position, wanderSpot.position) < 0.2f)
            {
                wanderSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

                timer = 0;
            }

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatExplode : MonoBehaviour {

    public AnimationClip explode;
    public ParticleSystem animalExplode;
    public GameObject cat;

    private float destroyTimer = 0.7f;
    private bool toDestroy = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (toDestroy)
        {
            destroyTimer -= Time.deltaTime;
        }

        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void ExplodingCat()
    {
        this.GetComponent<AnimalWander>().beingFed = true;
        gameObject.GetComponent<Animator>().Play("RabbitExplode");
        Instantiate(animalExplode, cat.transform.position, Quaternion.identity);
        toDestroy = true;
    }
}

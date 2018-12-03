using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class gm : MonoBehaviour {

    public float moveSpeed;
    public float animalSpeed;

    private bool allAtMax = false;

    public int numberAtMax = 0;
    public int numberOfAnimals = 0;
    private GameObject[] rabbitsInScene;
    private GameObject[] catsInScene;
    private GameObject[] sheepInScene;

    public GameObject Gateway;



    // Use this for initialization
    void Start () {
        moveSpeed = 10f;
        animalSpeed = 6f;
	}
	
	// Update is called once per frame
	void Update () {
        rabbitsInScene = GameObject.FindGameObjectsWithTag("Rabbit");
        catsInScene = GameObject.FindGameObjectsWithTag("Cat");
        sheepInScene = GameObject.FindGameObjectsWithTag("Sheep");

        numberOfAnimals = rabbitsInScene.Length + catsInScene.Length + sheepInScene.Length;

        if (numberOfAnimals == numberAtMax)
        {
            AllAnimalsMaximum();
        }

    }

    private void AllAnimalsMaximum()
    {
        Gateway.GetComponent<DoorController>().OpenGateway();
    }

    public void ExplodeAnimals()
    {
        if (rabbitsInScene.Length >= 1)
        {
            foreach (GameObject rabbit in rabbitsInScene)
            {
                rabbit.GetComponent<RabbitExplode>().ExplodingRabbit();
            }
        }

        if (catsInScene.Length >= 1)
        {
            foreach (GameObject cat in catsInScene)
            {
                cat.GetComponent<CatExplode>().ExplodingCat();
            }
        }

        if (sheepInScene.Length >= 1)
        {
            foreach (GameObject sheep in sheepInScene)
            {
                sheep.GetComponent<SheepExplode>().ExplodingSheep();
            }
        }
    }
}

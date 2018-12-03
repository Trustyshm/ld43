using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;

    public GameObject carrotEat;
    public GameObject hayEat;
    public GameObject lettuceEat;
    public GameObject mouseEat;


    public GameObject[] rabbits;
    public GameObject[] cats;
    public GameObject[] dogs;
    public GameObject[] sheeps;
    public GameObject[] cows;
    public GameObject[] horses;
    public GameObject[] tigers;
    public Transform player;

    public bool animalFood;
    public bool feedToRabbit;
    public bool feedToCat;
    public bool feedToDog;
    public bool feedToSheep;
    public bool feedToCow;
    public bool feedToHorse;
    public bool feedToTiger;

    public bool isLettuce;
    public bool isCarrot;
    public bool isHay;
    public bool isMouse;

    private GameObject[] eatingEffect;



    public virtual void Use()
    {
        //Use the item
        Debug.Log("Used" + " " + name);
        if (animalFood)
        {
            eatingEffect = GameObject.FindGameObjectsWithTag("EatingEffect");

            if (eatingEffect.Length == 0)
            {



                //Feed Rabbit
                if (feedToRabbit)
                {
                    rabbits = GameObject.FindGameObjectsWithTag("Rabbit");
                    player = GameObject.FindWithTag("Player").transform;

                    foreach (GameObject rabbit in rabbits)
                    {
                        float distances = Vector3.Distance(player.position, rabbit.transform.position);
                        if (distances <= 2)
                        {
                            rabbit.GetComponent<AnimalWander>().beingFed = true;
                            Debug.Log("Feeding Rabbit");

                            if (isLettuce)
                            {
                                Instantiate(lettuceEat, rabbit.transform.position, Quaternion.identity);
                                rabbit.GetComponent<AnimalWander>().Growing();
                                rabbit.GetComponent<AnimalWander>().WasFed();
                            }
                            if (isCarrot)
                            {
                                Instantiate(carrotEat, rabbit.transform.position, Quaternion.identity);
                                rabbit.GetComponent<AnimalWander>().Growing();
                                rabbit.GetComponent<AnimalWander>().WasFed();
                            }
                            if (isHay)
                            {
                                Instantiate(hayEat, rabbit.transform.position, Quaternion.identity);
                                rabbit.GetComponent<AnimalWander>().Growing();
                                rabbit.GetComponent<AnimalWander>().WasFed();
                            }

                            RemoveFromInventory();
                        }
                        else
                        {
                            Debug.Log("No Rabbit in Range");
                        }
                    }

                    if (rabbits.Length == 0)
                    {
                        Debug.Log("No animals to feed!");
                    }
                }

                //Feed Cat
                if (feedToCat)
                {
                    cats = GameObject.FindGameObjectsWithTag("Cat");
                    player = GameObject.FindWithTag("Player").transform;

                    foreach (GameObject cat in cats)
                    {
                        float distances = Vector3.Distance(player.position, cat.transform.position);
                        if (distances <= 2)
                        {
                            cat.GetComponent<AnimalWander>().beingFed = true;
                            Debug.Log("Feeding Cat");

                            if (isMouse)
                            {
                                Instantiate(mouseEat, cat.transform.position, Quaternion.identity);
                                cat.GetComponent<AnimalWander>().Growing();
                                cat.GetComponent<AnimalWander>().WasFed();
                            }

                            RemoveFromInventory();
                        }
                    }
                }

             

                //Feed Sheep
                if (feedToSheep)
                {
                    sheeps = GameObject.FindGameObjectsWithTag("Sheep");
                    player = GameObject.FindWithTag("Player").transform;

                    foreach (GameObject sheep in sheeps)
                    {
                        float distances = Vector3.Distance(player.position, sheep.transform.position);
                        if (distances <= 2)
                        {
                            sheep.GetComponent<AnimalWander>().beingFed = true;
                            Debug.Log("Feeding Sheep");

                            if (isCarrot)
                            {
                                Instantiate(carrotEat, sheep.transform.position, Quaternion.identity);
                                sheep.GetComponent<AnimalWander>().Growing();
                                sheep.GetComponent<AnimalWander>().WasFed();
                            }
                            if (isHay)
                            {
                                Instantiate(hayEat, sheep.transform.position, Quaternion.identity);
                                sheep.GetComponent<AnimalWander>().Growing();
                                sheep.GetComponent<AnimalWander>().WasFed();
                            }

                            RemoveFromInventory();
                        }
                    }
                }

                //Feed Cow
                if (feedToCow)
                {
                    cows = GameObject.FindGameObjectsWithTag("Cow");
                    player = GameObject.FindWithTag("Player").transform;

                    foreach (GameObject cow in cows)
                    {
                        float distances = Vector3.Distance(player.position, cow.transform.position);
                        if (distances <= 2)
                        {
                            Debug.Log("Feeding Cow");
                        }
                    }
                }

                //Feed Horse
                if (feedToHorse)
                {
                    horses = GameObject.FindGameObjectsWithTag("Horse");
                    player = GameObject.FindWithTag("Player").transform;

                    foreach (GameObject horse in horses)
                    {
                        float distances = Vector3.Distance(player.position, horse.transform.position);
                        if (distances <= 2)
                        {
                            Debug.Log("Feeding Horse");
                        }
                    }
                }

                //Feed Tiger
                if (feedToTiger)
                {
                    tigers = GameObject.FindGameObjectsWithTag("Tiger");
                    player = GameObject.FindWithTag("Player").transform;

                    foreach (GameObject tiger in tigers)
                    {
                        float distances = Vector3.Distance(player.position, tiger.transform.position);
                        if (distances <= 2)
                        {
                            Debug.Log("Feeding Tiger");
                        }
                    }
                }

            }

            

        }
    }

    public void RemoveFromInventory()
    {
        InventoryManager.instance.Remove(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    // variables involved in feeding the pet
    public Image hungerBar;
    public int maxHunger;
    public int feed;
    public float fillAmountHunger;

    // variables involved in the hapiness of pet
    public Image happinessBar;
    public int maxHappiness;
    public int affection;
    public float fillAmountHappy;

    // put models for pet here
    public GameObject pet;
    public GameObject evolvedPet;

    // models of food
    public GameObject foodFull;
    public GameObject foodHalf;
    public GameObject foodEmpty;

    public bool startFeed;

    // how many times the pet has grown
    public int growth;

    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        hungerBar.fillAmount = 0f;
        feed = 0;

        happinessBar.fillAmount = 0f;
        affection = 0;

        evolvedPet.SetActive(false);
        growth = 0;

        foodFull.SetActive(false);
        foodHalf.SetActive(false);
        startFeed = false;


    }

    // Update is called once per frame
    void Update()
    {
        Grow();
    }

    public void Feed()
    {
        // every time the button is pressed, pet will be fed and bar will increase
        // controls the food models --> when they appear relative to now much pet ate
        if (startFeed)
        {
            // when they can start feeding bar will fill up and corresponding models will be set
            hungerBar.fillAmount += fillAmountHunger;
            feed++;

            if (feed < 5)
            {
                foodEmpty.SetActive(false);
                foodFull.SetActive(true);

            } else if (feed >= maxHunger)
            {
                foodHalf.SetActive(false);
                foodEmpty.SetActive(true);
                startFeed = false;

            } else
            {
                foodFull.SetActive(false);
                foodHalf.SetActive(true);
            }
        } else if (!startFeed && feed <=5)
        {
           // the first time they press feed (and if the hunger meter if half or less than half)
           // the bowl will fill with food and they can start feeding
            startFeed = true;
            foodEmpty.SetActive(false);
            foodFull.SetActive(true);
            feed = 0;
        }
       
    }

    public void Play()
    {
        // every time the button is pressed, play with pet and bar will increase
        happinessBar.fillAmount += fillAmountHappy;
        affection++;

        ps.Play();
    }

    public void Sleep()
    {
        // if the time is 9:00 PM or past 9:00 PM, then pet will go to sleep
        // else the pet will not go to sleep

        if (System.DateTime.Now.Hour >= 21)
        {
            Debug.Log("Yes I sleep now");
        } else
        {
            Debug.Log("NO I DONT WANNA SLEEP");
        }
    }

    
    public void Grow()
    {
        // the pet grows in size here
        if (feed >= maxHunger && affection >= maxHappiness)
        {
            if (pet.activeSelf == true)
            {
                Vector3 objectScale = pet.transform.localScale;
                pet.transform.localScale = new Vector3(objectScale.x * 1.3f, objectScale.y * 1.3f, objectScale.z * 1.3f);
            } else
            {
                Vector3 objectScale = evolvedPet.transform.localScale;
                evolvedPet.transform.localScale = new Vector3(objectScale.x * 1.3f, objectScale.y * 1.3f, objectScale.z * 1.3f);
            }
            

            hungerBar.fillAmount = 0f;
            feed = 0;

            happinessBar.fillAmount = 0f;
            affection = 0;

            growth++;
        }

        // once the pet has grown 3 times it will evolve
        if (growth == 3)
        {
            pet.SetActive(false);
            evolvedPet.SetActive(true);
        }
    }
 
}

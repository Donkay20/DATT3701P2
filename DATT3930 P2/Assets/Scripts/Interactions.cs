using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    public Image hungerBar;
    public int maxHunger;
    public int feed;
    public float fillAmountHunger;

    public Image happinessBar;
    public int maxHappiness;
    public int affection;
    public float fillAmountHappy;

    public Image cleanlinessBar;
    public int maxCleanliness;
    public float fillAmountClean;

    public GameObject pet;

    // Start is called before the first frame update
    void Start()
    {
        hungerBar.fillAmount = 0.5f;
        feed = maxHunger / 2;

        happinessBar.fillAmount = 0f;
        affection = 0;

        cleanlinessBar.fillAmount = 1;

    }

    // Update is called once per frame
    void Update()
    {
        Grow();
    }

    public void Feed()
    {
        hungerBar.fillAmount += fillAmountHunger;
        feed++;
    }

    public void Play()
    {
        happinessBar.fillAmount += fillAmountHappy;
        affection++;
    }

    public void Shower()
    {
        cleanlinessBar.fillAmount += fillAmountClean;
    }

    
    public void Grow()
    {
        if (feed >= maxHunger && affection >= maxHappiness)
        {
            Vector3 objectScale = pet.transform.localScale;
            pet.transform.localScale = new Vector3(objectScale.x * 1.3f, objectScale.y * 1.3f, objectScale.z * 1.3f);

            hungerBar.fillAmount = 0f;
            feed = 0;

            happinessBar.fillAmount = 0f;
            affection = 0;
        }
    }
 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time : MonoBehaviour
{
    public GameObject display;

    public int hour;
    public int minutes;
    public int seconds;
    public int counter;

    public Interactions interactionsScript;

    void Start()
    {
        interactionsScript = FindObjectOfType<Interactions>();

        counter = 0;
        
        // calls method Count every second
        InvokeRepeating("Count", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        seconds = System.DateTime.Now.Second;

        display.GetComponent<Text>().text = "" + hour + ":" + minutes + ":" + seconds;

    }

    public void Count()
    {
        counter++;

        // every 60 seconds, each bar will deplete
        if (counter % 60 == 0)
        {
            interactionsScript.hungerBar.fillAmount -= interactionsScript.fillAmountHunger;
            interactionsScript.happinessBar.fillAmount -= interactionsScript.fillAmountHappy;
         //   interactionsScript.cleanlinessBar.fillAmount -= interactionsScript.fillAmountClean;
        }
    }
}

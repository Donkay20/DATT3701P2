using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class VoiceMovement : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public GameObject startSpeechRec;
    public GameObject stopSpeechRec;

    public Interactions interactionsScript;

    private Animation anim;

    void Start()
    {
        stopSpeechRec.SetActive(false);

        //keywords for speech recognition --> words you want objects to respond to
        actions.Add("i love you", love);
        actions.Add("jump", Jump);
        actions.Add("up", Up);
        actions.Add("down", Down);
        actions.Add("right", Right);
        actions.Add("left", Left);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;

        interactionsScript = FindObjectOfType<Interactions>();

    }


    //methods to control object when using speech recognition
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void love()
    {
        interactionsScript.happinessBar.fillAmount += interactionsScript.fillAmountHappy;
    }

    private void Jump()
    {

    }

    private void Up()
    {
        transform.Translate(0, 1, 0);
    }

    private void Down()
    {
        transform.Translate(0, -1, 0);
    }

    private void Right()
    {
        transform.Translate(1, 0, 0);
    }

    private void Left()
    {
        transform.Translate(-1, 0, 0);
    }


    //methods for the buttons
    public void StartSpeechRec()
    {
        keywordRecognizer.Start();
        startSpeechRec.SetActive(false);
        stopSpeechRec.SetActive(true);
    }

    public void StopSpeechRec()
    {
        keywordRecognizer.Stop();
        stopSpeechRec.SetActive(false);
        startSpeechRec.SetActive(true);
    }
}

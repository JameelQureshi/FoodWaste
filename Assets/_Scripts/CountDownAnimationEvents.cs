using NatSuite.Examples;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownAnimationEvents : MonoBehaviour
{
    public GameObject[] numbers;
    public GameObject CountDownPanel;
    public ReplayCam replayCam;
    public GameObject RecImage;

    private void Start()
    {
        
    }
    public void OnFiveGone()
    {
        Destroy(numbers[4]);
    }
    public void OnFourGone()
    {
        Destroy(numbers[3]);
    }
    public void OnThreeGone()
    {
        Destroy(numbers[2]);
    }
    public void OnTwoGone()
    {
        Destroy(numbers[1]);

    }
    public void OnOneGone()
    {
        Destroy(numbers[0]);
        CountDownPanel.GetComponent<Image>().enabled = false;
        replayCam.StartRecording();
        RecImage.SetActive(true);
        StartCoroutine(stop());
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(10.0f);
        RecImage.SetActive(false);
        replayCam.StopRecording();
    }

    
}

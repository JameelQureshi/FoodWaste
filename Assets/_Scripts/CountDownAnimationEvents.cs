using NatSuite.Examples;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class CountDownAnimationEvents : MonoBehaviour
{
    public GameObject[] numbers;
    public GameObject CountDownPanel;
    public ReplayCam replayCam;
    public GameObject RecImage;
    public VideoPlayer videoPlayer;


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
        videoPlayer.Play();
        RecImage.SetActive(true);
        StartCoroutine(stop());
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(15.0f);
        RecImage.SetActive(false);
        videoPlayer.Pause();
        replayCam.StopRecording();
    }

    
}

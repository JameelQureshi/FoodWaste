using NatSuite.Examples;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CountDownAnimationEvents : MonoBehaviour
{
    public GameObject[] numbers;
    public GameObject CountDownPanel;
    public ReplayCam replayCam;
    public GameObject RecImage;
    public VideoPlayer videoPlayer;
    public GameObject Quad;

    
    private void Start()
    {
        videoPlayer.Prepare();
    }
   
    public void Destroyer(int getindex)
    {
        Destroy(numbers[getindex]);

    }
    public void OnOneGone()
    {
        Destroy(numbers[0]);
       
        replayCam.StartRecording();
        Quad.GetComponent<MeshRenderer>().enabled = true;
        videoPlayer.Play();
        RecImage.SetActive(true);
        StartCoroutine(stop());
    }

    IEnumerator stop()
    {
        yield return new WaitForSeconds(16.0f);
        RecImage.SetActive(false);
        videoPlayer.Pause();
        replayCam.StopRecording();
        SceneManager.LoadScene(2);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ScreenManager : MonoBehaviour
{

    public GameObject savePanel;
    public GameObject SendEmailPanel;
    public GameObject SendSmsPanel;
    public GameObject ThankyouPanel;
    public GameObject popUpPanel;
    public VideoPlayer VideoPlayer;
    public GameObject Quad;

    public static bool isEmail;


    // Start is called before the first frame update
    void Start()
    {
        savePanel.SetActive(true);
        VideoPlayer.Prepare();
    }

    public void SendEmailbutton()
    {
        savePanel.SetActive(false);
        SendEmailPanel.SetActive(true);
        isEmail = true;
    }
    public void SendSmSButton() 
    {
        savePanel.SetActive(false);
        SendSmsPanel.SetActive(true);
        isEmail = false;
    }
    public void BackFromEmail()
    {
        savePanel.SetActive(true);
        SendEmailPanel.SetActive(false);
    }
    public void BackFromSmS()
    {
        savePanel.SetActive(true);
        SendSmsPanel.SetActive(false);
    }
    
    public void EmailSubmit()
    {
        SendEmailPanel.SetActive(false);
        popUpPanel.SetActive(true);
    }
    public void submit()
    {
        popUpPanel.SetActive(false);
        SendSmsPanel.SetActive(false);
        PlayCharacterAnim();
        StartCoroutine(OnvideoFinished());
        
    }
    private void PlayCharacterAnim()
    {
        Quad.GetComponent<MeshRenderer>().enabled = true;
        VideoPlayer.Play();
    }

    public void Nothanks()
    {
        savePanel.SetActive(false);
        StartCoroutine(OnvideoFinished());
        PlayCharacterAnim();
    }
    IEnumerator Thankyou()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(0);
    }
    IEnumerator OnvideoFinished()
    {
        yield return new WaitForSeconds(6.0f);
        Quad.SetActive(false);
        VideoPlayer.Pause();
        ThankyouPanel.SetActive(true);
        StartCoroutine(Thankyou());

    }
    
}

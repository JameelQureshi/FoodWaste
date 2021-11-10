using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject ContinuePanel;
    public GameObject savePanel;
    public GameObject SendEmailPanel;
    public GameObject SendSmsPanel;
    // Start is called before the first frame update
    void Start()
    {
        StartPanel.SetActive(true);  
    }
   public void startbutton()
    {
        StartPanel.SetActive(false);
        ContinuePanel.SetActive(true);
    }
    public void continuebutton()
    {
        ContinuePanel.SetActive(false);
        savePanel.SetActive(true);
    }
    public void SendEmailbutton()
    {
        savePanel.SetActive(false);
        SendEmailPanel.SetActive(true);
    }
    public void SendSmSButton()
    {
        ContinuePanel.SetActive(false);
        SendSmsPanel.SetActive(true);
    }
    public void SubmitButton()
    {
        SceneManager.LoadScene(1);
    }
    /*  IEnumerator Loading()
      {
          yield return new WaitForSeconds(2.0f);
          StartPanel.SetActive(false);
          ContinuePanel.SetActive(true);

      }*/
}

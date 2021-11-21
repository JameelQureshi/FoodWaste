using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject ContinuePanel;

    // Start is called before the first frame update
    void Start()
    {
        StartPanel.SetActive(true);
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                Permission.RequestUserPermission(Permission.Camera);
            }
            if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
            {
                Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            }
            if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
            {
                Permission.RequestUserPermission(Permission.Microphone);
            }
        }
       
    }
   public void startbutton()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                Permission.RequestUserPermission(Permission.Camera);
            }
            if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
            {
                Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            }
            if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
            {
                Permission.RequestUserPermission(Permission.Microphone);
            }
        }

        StartPanel.SetActive(false);
        ContinuePanel.SetActive(true);
    }
    public void continuebutton()
    {
        SceneManager.LoadScene(1);
    }
    
    public void SubmitButton()
    {
       
    }
    /*  IEnumerator Loading()
      {
          yield return new WaitForSeconds(2.0f);
          StartPanel.SetActive(false);
          ContinuePanel.SetActive(true);

      }*/
}

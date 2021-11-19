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
    IEnumerator Start()
    {
        StartPanel.SetActive(true);
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                Permission.RequestUserPermission(Permission.Camera);
                yield return new WaitUntil(() => Permission.HasUserAuthorizedPermission(Permission.Camera));
            }
        }
        else
        {
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
                yield break;
        }
    }
   public void startbutton()
    {
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

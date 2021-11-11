using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject ContinuePanel;
    
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

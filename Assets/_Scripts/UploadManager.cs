using System.Collections;
using System.Collections.Generic;
using System.IO;
using NatSuite.Examples;
using UnityEngine;
using UnityEngine.Networking;

public class UploadManager : MonoBehaviour
{
    public GameObject loading;
    public ScreenManager screenManager;

    private void Start()
    {
       // Upload();
        //Debug.Log("Start Function");
    }



    public void Upload(string targetAddress)
    {
        loading.SetActive(true);
        StartCoroutine(UploadVideo(targetAddress));
    }



    IEnumerator UploadVideo(string targetAddress)
    {
       

        WWWForm form = new WWWForm();
        string destination = Application.persistentDataPath + "capture" + ".mp4";
        Debug.Log("Uploading");
        byte[] bytes = File.ReadAllBytes(destination);

        if (ScreenManager.isEmail)
        {
            form.AddField("email", targetAddress);
            form.AddBinaryData("video", bytes, "video" + ".mp4"); ;
        }
        else
        {
            form.AddField("number", targetAddress);
            form.AddBinaryData("video", bytes, "video" + ".mp4"); ;
        }
       
        UnityWebRequest webRequest = UnityWebRequest.Post("https://foodwaste.aimfit.io/api/v1/videos", form);

        webRequest.SendWebRequest();

        while (!webRequest.isDone)
        {
            yield return null;

            // Progress is always set to 1 on android
            //m_statusMessage.GetComponent<Text>().text = webRequest.uploadProgress * 100 + "%";
            //m_statusMessage.GetComponent<Text>().text = "Uploading...";
        }


        if (webRequest.isHttpError || webRequest.isNetworkError)
        {
            Debug.Log(webRequest.error);
            loading.SetActive(false);
            screenManager.submit();
        }
        else
        {
            Debug.Log("Request Done!:" + webRequest.downloadHandler.text);
            //UploadFileManager.RemoveDoneFileName(fileName);
            loading.SetActive(false);
            screenManager.submit();
        }



    }
}

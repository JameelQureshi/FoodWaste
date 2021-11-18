using System.Collections;
using System.Collections.Generic;
using System.IO;
using NatSuite.Examples;
using UnityEngine;
using UnityEngine.Networking;

public class UploadManager : MonoBehaviour
{

    private void Start()
    {
        Upload();
        Debug.Log("Start Function");
    }



    public void Upload()
    {
        StartCoroutine(UploadVideo());
    }



    IEnumerator UploadVideo()
    {
       

        WWWForm form = new WWWForm();
        Debug.Log("Uploading");
        byte[] bytes = File.ReadAllBytes(ReplayCam.path);
        form.AddField("email", "jameelqureshi2013@gmail.com");
        form.AddBinaryData("video", bytes, "video"+ ".mp4"); ;
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
        }
        else
        {
            Debug.Log("Request Done!:" + webRequest.downloadHandler.text);
            //UploadFileManager.RemoveDoneFileName(fileName);

        }



    }
}

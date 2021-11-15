using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;


public class MessageManager : MonoBehaviour
{
    public InputField Email;
    public InputField phonenumber;
    public Button EmailSubmit;
    public Button SmsSubmit;
    private int lenghtchecker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checker();
    }
    private void checker()
    {
        if (Regex.IsMatch(Email.text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
        {
            EmailSubmit.interactable = true;
           
        }
        lenghtchecker = phonenumber.text.Length;
      //  print(phonenumber.text.Length);
        if(lenghtchecker >= 9)
        {
            SmsSubmit.interactable = true;
        }
    }
   
}

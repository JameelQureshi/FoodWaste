using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARScreenLoading : MonoBehaviour
{

    public GameObject loading;
    public GameObject counterPanel;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(TurnOffLoading),3.5f);
    }

    private void TurnOffLoading()
    {
        loading.SetActive(false);
        counterPanel.SetActive(true);
    }
}

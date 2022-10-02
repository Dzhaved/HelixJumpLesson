using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseAdButton : MonoBehaviour
{
    public Button Button;
    

    private void OnEnable()
    {
        Invoke("CloseButton", 3f);
    }
    public void CloseButton()
    {
        Button.interactable = true;
    }

}

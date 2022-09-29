using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Text dogruTxt, yanlisTxt;

    public void SonuclariYazdir(int dogru, int yanlis)
    {
        dogruTxt.text=dogru.ToString();
        yanlisTxt.text=yanlis.ToString();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using System.Linq; // liste ile ilgili çalışmaları yapabilmek için
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public Question[] sorular;
    private static List<Question> cevaplanmayanQuestion;

    private Question gecerliSoru;

    [SerializeField]
    private Text soruText;

    [SerializeField]
    private Text dogruCevapText, yanlisCevapText;

    [SerializeField]
    private GameObject dogruButon, yanlisButon;

    [SerializeField]
    private GameObject sonucPaneli;

    SonucManager sonucManager;

    int dogruAdet, yanlisAdet;

    void Start()
    {
        if (cevaplanmayanQuestion==null || cevaplanmayanQuestion.Count==0)
        {
            cevaplanmayanQuestion=sorular.ToList<Question>();
        }
        
        yanlisAdet=0;
        dogruAdet=0;

        RastGeleSoruSec();
    
    }

    void RastGeleSoruSec()
    {
        yanlisButon.GetComponent<RectTransform>().DOLocalMoveX(-124.39f, 0.5f);
        dogruButon.GetComponent<RectTransform>().DOLocalMoveX(123.39f, 0.5f);

        int randomSoruIndex=Random.Range(0,cevaplanmayanQuestion.Count);
        gecerliSoru=cevaplanmayanQuestion[randomSoruIndex];

        soruText.text=gecerliSoru.question;

        if(gecerliSoru.dogrumu)
        {
            dogruCevapText.text="Dogru cevapladiniz";
            yanlisCevapText.text="Yanlis cevapladiniz";
        }else
        {
            dogruCevapText.text="Yanlis cevapladiniz";
            yanlisCevapText.text="Dogru cevapladiniz";
        }
    }

    IEnumerator SorularArasiBekleRoutine()
    {
        cevaplanmayanQuestion.Remove(gecerliSoru);
        yield return new WaitForSeconds(1f);
        
        if(cevaplanmayanQuestion.Count<=0)
        {
           sonucPaneli.SetActive(true);

           sonucManager=Object.FindObjectOfType<SonucManager>();
           sonucManager.SonuclariYazdir(dogruAdet,yanlisAdet);

        }else 
        {
            RastGeleSoruSec();
        }

    }

   public void dogruButonaBasildi()
   {
        if(gecerliSoru.dogrumu)
        {
            dogruAdet++;
        }else
        {
            yanlisAdet++;
        }
        
        yanlisButon.GetComponent<RectTransform>().DOLocalMoveX(1000f,0.5f);
        StartCoroutine(SorularArasiBekleRoutine());
   }

   public void yanlisButonaBasildi()
   {
        if(!gecerliSoru.dogrumu)
        {
            dogruAdet++;
        }else
        {
            yanlisAdet++;
        }
        dogruButon.GetComponent<RectTransform>().DOLocalMoveX(-1000f,0.5f);
        StartCoroutine(SorularArasiBekleRoutine());
   }
}

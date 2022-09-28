using System.Collections;
using System.Collections.Generic;
using System.Linq; // liste ile ilgili çalışmaları yapabilmek için
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Question[] sorular;
    private static List<Question> cevaplanmayanQuestion;

    private Question gecerliSoru;

    [SerializeField]
    private Text soruText;

    void Start()
    {
        if (cevaplanmayanQuestion==null || cevaplanmayanQuestion.Count==0)
        {
            cevaplanmayanQuestion=sorular.ToList<Question>();
        }

        RastGeleSoruSec();
    
    }

    void RastGeleSoruSec()
    {
        int randomSoruIndex=Random.Range(0,cevaplanmayanQuestion.Count);
        gecerliSoru=cevaplanmayanQuestion[randomSoruIndex];

        soruText.text=gecerliSoru.question;
    }

   
}

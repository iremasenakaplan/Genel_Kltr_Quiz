using System.Collections;
using System.Collections.Generic;
using System.Linq; // liste ile ilgili çalışmaları yapabilmek için
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    IEnumerator SorularArasiBekleRoutine()
    {
        cevaplanmayanQuestion.Remove(gecerliSoru);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

   public void dogruButonaBasildi()
   {
        if(gecerliSoru.dogrumu)
        {
            Debug.Log("true answer");
        }else
        {
            Debug.Log("false answer");
        }

        StartCoroutine(SorularArasiBekleRoutine());
   }

   public void yanlisButonaBasildi()
   {
        if(!gecerliSoru.dogrumu)
        {
            Debug.Log("true answer");
        }else
        {
            Debug.Log("false answer");
        }

        StartCoroutine(SorularArasiBekleRoutine());
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FinishTrigger : MonoBehaviour
{
    public GameObject spawner;
    public GameObject finishPanel;

    private GameObject nesne;

    private void OnTriggerEnter2D(Collider2D other)
    {
        nesne = other.gameObject;

        if (other.name[0].Equals('F')) //BENZİNİ KAÇIRDIĞINDA OYUN BİTER
        {
            finishPanel.gameObject.SetActive(true);

            Destroy(spawner);
            Time.timeScale = 0;
            Debug.Log("Bitti");

        }
        else
        {
            Destroy(nesne);
        }

        /* 
        nesne = other.gameObject;
        Debug.Log(other.name[0]);

        if (other.name[0].Equals('F'))  //benzin aldıysa
        {
            Debug.Log("AAAAAAAAA");
            Destroy(nesne);
        }
        else if (other.name[0].Equals('Z')) //zombi degdiyse
        {
            Debug.Log("BBBBBBBBBB");
            Destroy(spawner);
            Time.timeScale=0;
            Debug.Log("GAME OVER SKOR=" + levelScore.text);
        }
        else                            //bir şeye degmediyse
        {
            Debug.Log("CCCCCCCCCCCCC");
            Destroy(spawner);
            Time.timeScale = 0;
            Debug.Log("GAME OVER SKOR=" + levelScore.text);
        }
        */

    }

    public void RestartGame(){
        Application.LoadLevel (Application.loadedLevel);
        Time.timeScale=1;
        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerScript : MonoBehaviour
{
    public GameObject spawner;
    public Slider slider;

    public GameObject level;
    private int levelInt;

    // Start is called before the first frame update
    void Start()
    {
        levelInt = 1;
    }

    // Update is called once per frame
    private float score;

    void Update()
    {

    }

    private GameObject nesne;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
        nesne = other.gameObject;

        if (other.name[0].Equals('F'))  //benzin aldıysa
        {
            Destroy(nesne);
        }
        else if (other.name[0].Equals('Z')) //zombi degdiyse
        {
            Destroy(nesne);
            //Time.timeScale=0;
        }
        else                            //bir şeye degmediyse
        {
            Destroy(spawner);
            //Time.timeScale = 0;
            score = (int)(slider.value * levelInt * 100);
            //Debug.Log("GAME OVER SKOR=" + score);
        }


    }
}

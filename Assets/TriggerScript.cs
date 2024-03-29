﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerScript : MonoBehaviour
{
    public GameObject spawner;

    public GameObject levelText;
    Text levelScore;

    public GameObject finishPanel;

    // Start is called before the first frame update
    void Start()
    {
        levelScore = levelText.GetComponent<Text>();
        finishPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private float score;

    void Update()
    {

    }

    private GameObject nesne;

    private void OnTriggerEnter2D(Collider2D other)
    {
        nesne = other.gameObject;

        if (other.name[0].Equals('F'))  //benzin aldıysa
        {
            Destroy(nesne);
        }
        else if (other.name[0].Equals('Z')) //zombi degdiyse
        {
            Destroy(spawner);
            Time.timeScale=0;
            Debug.Log("GAME OVER SKOR=" + levelScore.text);
            finishPanel.gameObject.SetActive(true);


        }
        else                            //bir şeye degmediyse
        {
            Destroy(spawner);
            Time.timeScale = 0;
            Debug.Log("GAME OVER SKOR=" + levelScore.text);
            finishPanel.gameObject.SetActive(true);
           //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }


    }
}

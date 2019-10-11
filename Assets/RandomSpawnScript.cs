using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawnScript : MonoBehaviour
{
    public GameObject prefabZombie, prefabFuel;
    private GameObject leftObj, rightObj;

    public Slider slider;

    //TODO levelInt 'in oyun bittiğinde sıfırlanması lazım.
    private float spawnRate = 10f;  //iki nesne dogma arasındaki süre
    private float speed = 0.1f;
    float nextSpawn = 0f;
    int whatToSpawnLeft, whatToSpawnRight;

    float yMesafe = 2.0f;   // aynı anda gelenleri hizalamamak için
    float yMesafeLeft, yMesafeRight;

    private int levelInt = 1;
    private float levelEndTime = 0f;

    public GameObject levelText;
    Text txt;

    void Start()
    {
        txt = levelText.GetComponent<Text>();
    }

    void Update()
    {

        if(!leftObj && !rightObj) //if (Time.time > nextSpawn)
        {
            createObjects();
        }

        checkLevel();

        autoMovement();
    }

    void createObjects()
    {
        whatToSpawnLeft = Random.Range(1, 5);
        whatToSpawnRight = Random.Range(1, 5);

        //nesneler arasında mesafeyi belirlemek için
        if (whatToSpawnLeft > whatToSpawnRight)
        {
            yMesafeLeft = yMesafe;
            yMesafeRight = 0;
        }
        else
        {
            yMesafeRight = yMesafe;
            yMesafeLeft = 0;
        }

        switch (whatToSpawnLeft)
        {
            case 1:
                leftObj = Instantiate(prefabZombie, new Vector3(-2.3f, 7.5f + yMesafeLeft, -5), Quaternion.identity);

                break;
            case 2:
                leftObj = Instantiate(prefabFuel, new Vector3(-0.9f, 7.5f + yMesafeLeft, -5), Quaternion.identity);

                break;
            case 3:
                leftObj = Instantiate(prefabFuel, new Vector3(-2.3f, 7.5f + yMesafeLeft, -5), Quaternion.identity);

                break;
            case 4:
                leftObj = Instantiate(prefabZombie, new Vector3(-0.9f, 7.5f + yMesafeLeft, -5), Quaternion.identity);

                break;
        }

        switch (whatToSpawnRight)
        {
            case 1:
                rightObj = Instantiate(prefabZombie, new Vector3(0.9f, 7.5f + yMesafeRight, -5), Quaternion.identity);

                break;
            case 2:
                rightObj = Instantiate(prefabFuel, new Vector3(2.3f, 7.5f + yMesafeRight, -5), Quaternion.identity);
                break;
            case 3:
                rightObj = Instantiate(prefabFuel, new Vector3(0.9f, 7.5f + yMesafeRight, -5), Quaternion.identity);

                break;
            case 4:
                rightObj = Instantiate(prefabZombie, new Vector3(2.3f, 7.5f + yMesafeRight, -5), Quaternion.identity);
                break;
        }

        //Destroy(leftObj, spawnRate);
        //Destroy(rightObj, spawnRate);
        // = Time.time + spawnRate;
    }


    void autoMovement()
    {
        if (leftObj)
        {

            BoxCollider2D boxCollider = leftObj.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;

            float x = leftObj.transform.position.x;
            float y = leftObj.transform.position.y;
            float z = leftObj.transform.position.z;
            leftObj.transform.position = new Vector3(x, y - speed, z);
        }

        if (rightObj)
        {

            BoxCollider2D boxCollider2 = rightObj.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
            float x = rightObj.transform.position.x;
            float y = rightObj.transform.position.y;
            float z = rightObj.transform.position.z;
            rightObj.transform.position = new Vector3(x, y - speed, z);
        }



    }

    void checkLevel()
    {
        if (slider.value >= 1.0f)
        {
            levelInt = levelInt + 1;
            txt.text = levelInt.ToString();
            slider.value = 0f;
            levelEndTime = Time.time;
            Debug.Log(levelInt + ".Bölüme geçtin Süren:" + levelEndTime);
            if(levelInt % 2 == 0) speed=speed+0.01f;
        }
        if (slider.value < 1.0f)
        {
            //levelInt = int.Parse(level.GetComponent<Text>().text);
            slider.value = (Time.time - levelEndTime) / (4 * levelInt); //Yeni levelde slider value 0.saniyeyi hesaba katması için     

        }
        /* 
        else
        {
            //slider.value=Time.time/125; //10.seviye
            levelInt = int.Parse(level.GetComponent<Text>().text);
            slider.value = Time.time / 10 * levelInt;
            Debug.Log(levelInt);
            //Debug.Log(slider.value);
        }
        */
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawnScript : MonoBehaviour
{
    public GameObject prefabZombie, prefabFuel;
    private GameObject leftObj, rightObj;

    public Slider slider;


    private float spawnRate = 2.5f;  //iki nesne dogma arasındaki süre
    private float speed = 0.1f;
    float nextSpawn = 0f;
    int whatToSpawnLeft, whatToSpawnRight;

    float yMesafe = 2.0f;
    float yMesafeLeft, yMesafeRight;

    public GameObject level;
    private int levelInt=1;
    void Start()
    {
    }

    void Update()
    {

        if (Time.time > nextSpawn)
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

        Destroy(leftObj, spawnRate);
        Destroy(rightObj, spawnRate);
        nextSpawn = Time.time + spawnRate;
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

    void checkLevel()  //////PROBLEM VAR BURADA !!!!!!!!!!!!! SLIDER SIFIRLANMIYOR
    { 
        //int x=(int)(slider.value*10);
        Debug.Log("AAA:" + slider.value);
        if (slider.value >= 0.2f)
        {
            //Debug.Log(levelInt + ".Bölüm bitti" + slider.value);
            Debug.Log("BBB:" + slider.value);
            //levelInt = levelInt + 1;
            slider.value = 0f;
            //Time.timeScale = 0;
        }
        if (slider.value < 0.2f)
        {
            Debug.Log("CCC:" + slider.value +" time: "+  Time.time+" level: "+levelInt);
            //levelInt = int.Parse(level.GetComponent<Text>().text);
            slider.value = Time.time / 10 * levelInt;
            Debug.Log("DDD:" + slider.value);

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

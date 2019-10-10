using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarScript : MonoBehaviour
{

    public GameObject leftCar, rightCar;
    private float speed = 0.08f;
    private bool carLeftEnable, carRightEnable = false;
    private Vector3 target;
    float xLeft;
    float yLeft;
    float zLeft;

    float xRight;
    float yRight;
    float zRight;

    string leftCarRotate,rightCarRotate;
    void Start()
    {
        xLeft = leftCar.transform.position.x;
        yLeft = leftCar.transform.position.y;
        zLeft = leftCar.transform.position.z;
        xRight = rightCar.transform.position.x;
        yRight = rightCar.transform.position.y;
        zRight = rightCar.transform.position.z;
        leftCarRotate = "left";
        rightCarRotate = "right";
    }
    void Update()
    {
        xLeft = leftCar.transform.position.x;
        xRight=rightCar.transform.position.x;
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (target.x < 0) //sol araba hareket ettir
            {
                carLeftEnable = true;
            }
            else            //sağ araba hareket ettir
            {
                carRightEnable = true;
            }


        }

        if (carLeftEnable == true)
        {
            // Debug.Log("Sol araba harekette:"+xLeft);


            if (xLeft > -2.3f && leftCarRotate == "left")
            {
                //Debug.Log("HAREKET EDİYOR_SOL");
                leftCar.transform.position = new Vector3(xLeft - speed, yLeft, zLeft);
            }
            else if (xLeft <= -0.9f && leftCarRotate == "right")
            {
                //Debug.Log("HAREKET EDİYOR_SAG"+xLeft);
                leftCar.transform.position = new Vector3(xLeft + speed, yLeft, zLeft);

            }
            else
            {
                //Debug.Log("HAREKET DURDU");
                carLeftEnable = false;
                if (leftCarRotate == "left") leftCarRotate = "right";
                else leftCarRotate = "left";
            }


        }
        else if (carRightEnable == true)
        {
          
            if (xRight > 0.9f && rightCarRotate == "left")
            {
                 rightCar.transform.position = new Vector3(xRight - speed, yRight, zRight);
            }
            else if (xRight <= 2.3f && rightCarRotate == "right")
            {  rightCar.transform.position = new Vector3(xRight + speed, yRight, zRight);

            }
            else
            {
                carRightEnable = false;
                if (rightCarRotate == "left") rightCarRotate = "right";
                else rightCarRotate = "left";
            }
        }


    }
}

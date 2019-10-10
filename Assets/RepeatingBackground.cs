using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D m_backgroundCollider;
    private float m_backgroundSize;

    void Start()
    {
        m_backgroundCollider=GetComponent<BoxCollider2D>();
        m_backgroundSize=m_backgroundCollider.size.y;
        //Debug.Log("TAG" + m_backgroundSize);
    }

    void Update()
    {
        if(transform.position.y <  -m_backgroundSize)
        {
            //Debug.Log("TAG" + transform.position.y);
            RepeateBackground();
        }
    }

    void RepeateBackground()
    {
        Vector2 BGoffset=new Vector2(0,m_backgroundSize*3f);
        transform.position=(Vector2)transform.position + BGoffset;
        //Debug.Log("TAG" + transform.position + " >>>> " + BGoffset);
    }
}

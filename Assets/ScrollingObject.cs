using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

    private Rigidbody2D RIGIDBODY;
    private float m_Speed=-2.0f;
    [SerializeField]private bool m_StopScrolling=false;

    void Start()
    {
     RIGIDBODY = GetComponent<Rigidbody2D>();   
     RIGIDBODY.velocity=new Vector2(0,m_Speed);
    }


    void Update()
    {
        if(m_StopScrolling)
            RIGIDBODY.velocity=Vector2.zero;
        else
            RIGIDBODY.velocity=new Vector2(0,m_Speed);
    }
}

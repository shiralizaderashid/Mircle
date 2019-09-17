using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    Transform rotationCenter;

    [SerializeField]
    Transform circleTransform;


    private Vector2 originalPos;

    private Vector2 targetposition = Vector2.zero;

    void Start()
    {
        originalPos = gameObject.transform.position;
        targetposition = rotationCenter.position;
   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if ((Vector2)transform.position != targetposition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetposition, 0.5f * Time.deltaTime);
        }
        else
        {
            targetposition = rotationCenter.position;
        }
       
    }

   /* void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag=="circle")
        {
            Debug.Log("deydi");
            targetposition = originalPos;
           // transform.position = Vector2.MoveTowards(transform.position, originalPos, 0.5f * Time.deltaTime);
        }
    }
    */
     void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.gameObject.tag == "center")
        {
            targetposition = originalPos;
        }
    }

}

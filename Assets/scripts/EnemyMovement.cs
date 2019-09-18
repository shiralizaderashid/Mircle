using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    Transform rotationCenter;

    [SerializeField]
    Transform circleTransform;


    private Vector2 originalPos;

    private Vector2 targetposition = Vector2.zero;
    private float speed;

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
            speed = Random.Range(0.1f, 1.5f);
           
            transform.position = Vector2.MoveTowards(transform.position, targetposition,speed * Time.deltaTime);

            if ((Vector2)transform.position==originalPos)
            {
                transform.position = Vector2.MoveTowards(transform.position, transform.position, speed * Time.deltaTime);
            }

        }
        else
        {
            targetposition = rotationCenter.position;
        }
       
    }

     void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.gameObject.tag == "center")
        {
            targetposition = originalPos;
        }

        
    }


}

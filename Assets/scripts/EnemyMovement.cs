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
        originalPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Debug.Log("original " + gameObject.transform.position.x + "y="+gameObject.name + gameObject.transform.position.y);
        targetposition = new Vector2(rotationCenter.position.x + 0.1f, rotationCenter.position.y + 0.1f);
        Debug.Log("pozsiya"+ targetposition.x + "y="+targetposition.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if ((Vector2)transform.position != targetposition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetposition, 0.5f * Time.deltaTime);
        }
       
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag=="circle")
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPos, 0.5f * Time.deltaTime);
        }
    }
    
}

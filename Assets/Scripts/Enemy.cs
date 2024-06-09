using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //====================================
    //PUBLIC VARIABLES

    //speed of enemy
    public float speed;

    //direction and distance it will move
    public Vector3 moveOffset;
    //====================================

    //=====================================================
    //PRIVATE VARIABLES

    //target position the enemy is currently moving towards
    private Vector3 targetPos;

    //target position the enemy is currently moving towards
    private Vector3 startPos;
    //=====================================================

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + moveOffset);
        Gizmos.DrawWireCube(transform.position + moveOffset, transform.lossyScale);
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos; //giving the target a default value
    }

    // Update is called once per frame
    void Update()
    {
        //============================================================================================
        //ENEMY MOVEMENT

        //moves towards a target
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);

        //if where we want to go is where we are
        if(transform.position == targetPos)
        {
            //if where we want to go is the start
            if(targetPos == startPos)
            {
                targetPos = startPos + moveOffset; //go to the offset
            }
            else //if its not the start
            {
                targetPos = startPos; //go to the start
            }
        }
        //============================================================================================
    }

    //checks when 2 colliders are overlapping each other
    private void OnTriggerEnter(Collider other)
    {
        //=============================================================================
        //IS OVERLAPPING
        
        //if enemy collider is touching player collider
        if(other.CompareTag("Player"))
        {
            //get the component of the player of name PlayerController and run GameOver
            other.GetComponent<PlayerController>().GameOver(); 
        }
        //=============================================================================
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float _rotateSpeed = 180.0f;

    // Update is called once per frame
    void Update()
    {
        //=========================================================
        //ROTATE COIN
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
        //=========================================================
    }

    private void OnTriggerEnter(Collider other)
    {
        //=================================================================================
        //SCORE IF TOUCH

        //if it overlaps with tag player
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().AddScore(1); //increases the score by 1
            Destroy(gameObject); //destroys the coin afterwards
        }
        //=================================================================================
    }
}

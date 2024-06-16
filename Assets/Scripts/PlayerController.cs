using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //==========================
    //PUBLIC VARIABLES
    public TextMeshProUGUI scoreText;
    public Rigidbody rig;
    public float movementSpeed;
    public float jumpForce;

    //for the score
    public int score;

    public string scoreSaver = "Score";
    //==========================

    //==========================
    //PRIVATE VARIABLES
    private bool isGrounded;
    //==========================

    void Start()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1"))
        {
            SetInt(scoreSaver, 0);
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            score = GetInt(scoreSaver);
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int GetInt(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }

    // Update is called once per frame
    void Update()
    {
        //==============================================================================
        //PLAYER MOVEMENT

        //sets up x and z axis for movement
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //calls rig velocity and sets it to the movement * speed
        rig.velocity = new Vector3(x*movementSpeed, rig.velocity.y, z*movementSpeed);

        Vector3 vel = rig.velocity;
        vel.y = 0;

        //sets where player is looking to the direction it's moving
        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        //jumping
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
        }
        //==============================================================================


        if(Input.GetKeyDown(KeyCode.F5))
        {
            if(jumpForce >= 15)
            {
                jumpForce -= 15;
                movementSpeed /= 2;
            }
            else
            {
                jumpForce += 15;
                movementSpeed *= 2;
            }
        }

        //============================
        //GAME OVER

        if(transform.position.y < -5)
        {
            GameOver();
        }
        //============================
    }

    //checks when 2 colliders are touching
    private void OnCollisionEnter(Collision collision)
    {
        //=========================================================================
        //isGrounded CHECK

        //.normal is the direction x thing is facing, so a floor would be facing up
        if(Vector3.Angle(collision.GetContact(0).normal, Vector3.up) < 60.0f)
        {
            isGrounded = true;
        }
        //=========================================================================
    }

    public void GameOver()
    {
        //reloads scene when game is over
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amoumt)
    {
        score += amoumt;
        scoreText.text = "Score: " + score.ToString();
    }

    //subscribe!!!!
}

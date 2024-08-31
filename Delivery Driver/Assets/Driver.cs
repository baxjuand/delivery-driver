using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
   [SerializeField] float turnSpeed = 1f;
   [SerializeField] float defaultSpeed = 10f;
   [SerializeField] float moveSpeed = 10f;
   [SerializeField] float reducedSpeed = 6f;
   [SerializeField] float increasedSpeed = 16f;
   [SerializeField] float slowDownDuration = 3f;
   [SerializeField] float boostDuration = 10f;
   float slowDownTimer = 0f;
   float speedUpTimer = 0f;
   bool isSlowedDown;
   bool isSpedUp;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, speedAmount, 0);

        if (isSlowedDown)
        {
            slowDownTimer += Time.deltaTime;

            if (slowDownTimer >= slowDownDuration)
            {
                moveSpeed = defaultSpeed;
                isSlowedDown = false;
                slowDownTimer = 0f;

            }
        }

        if (isSpedUp)
        {
            speedUpTimer += Time.deltaTime;

            if (speedUpTimer >= boostDuration)
            {
                moveSpeed = defaultSpeed;
                isSpedUp = false;
                speedUpTimer = 0f;
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Unmovable")
        {
            moveSpeed = reducedSpeed;
            isSlowedDown = true;

        }   
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Booster")
        {
           moveSpeed = increasedSpeed;
           isSpedUp = true; 
        }
    }
}


   
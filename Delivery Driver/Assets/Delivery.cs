using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
   
   bool hasPackage;
   [SerializeField] float destroyDelay = 0.5f;
   SpriteRenderer spriteRenderer;
   [SerializeField] Sprite packagePickedUp;
   [SerializeField] Sprite noPackage;

   void Start() 
   {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
   }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Hit!");  
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.sprite = packagePickedUp;  
            Destroy(other.gameObject, destroyDelay);
            
        }   

        if (other.tag == "Delivery Point" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.sprite = noPackage;
        }
    }


}

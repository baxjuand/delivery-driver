using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    
    // The camera will follow the car's movement.

    [SerializeField] GameObject objectToFollow;
    
    void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + new Vector3 (0,0,-10);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    // position of camera should be the same as car

    [SerializeField] GameObject thingToFollow;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10); // add an offset to lift up camera a bit
    }
}

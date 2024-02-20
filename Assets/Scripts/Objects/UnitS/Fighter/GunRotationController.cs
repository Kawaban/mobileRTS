using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotationController : MonoBehaviour
{
    public void RotateGun(Vector3 target)
    {
        Vector3 direction = target - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 target;
    public float moveSpeed;

     void Start()
    {
            target = transform.position;
    }

    public void Move(Vector3 direction)
    {
        target += direction;
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }
}

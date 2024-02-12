using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    
    private Vector2 startPos;
    private bool fingerDown=false;
    public float resolutionMultiplyer;
    public int pixelsDistToDetect;
    [SerializeField] private CameraMovement cameraMovement;

  
    void Update()
    {
        //MOBILE ACTUAL VERSION

        /* if (!fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
         {
             startPos = Input.touches[0].position;
             fingerDown = true;
         }

         if (fingerDown)
         {
             if( Vector2.Distance(startPos, new Vector2(Input.touches[0].position.x, Input.touches[0].position.y)) > pixelsDistToDetect)
             {
                 fingerDown = false;
                 Vector2 direction = startPos - new Vector2(Input.touches[0].position.x , Input.touches[0].position.y );
                 cameraMovement.Move(new Vector3(direction.x * resolutionMultiplyer, 0,direction.y * resolutionMultiplyer));
             }
         }*/

        //PC TEST



        if (!fingerDown && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            fingerDown = true;
        }

        if (fingerDown)
        {
           if( Vector2.Distance(startPos, new Vector2(Input.mousePosition.x, Input.mousePosition.y)) > pixelsDistToDetect)
            {
                fingerDown = false;
                Vector2 direction = startPos - new Vector2(Input.mousePosition.x , Input.mousePosition.y );
                cameraMovement.Move(new Vector3(direction.x * resolutionMultiplyer, 0,direction.y * resolutionMultiplyer));
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Commander commander;

    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Camera camera;

    private bool onCreateMode = false;
    private PointType createType;

    private Ray ray;
    private RaycastHit hitInfo;

    void Update()
    {
        text.text = "Minerals: " + commander.Minerals;   

        if(onCreateMode && Input.GetMouseButtonDown(0) )
        {
            switch (createType)
            {
                case PointType.FACTORY:
                    commander.createFactory(calculatePoint());
                    break;
                case PointType.MINING_COMPLEX:
                    commander.createMiningComplex(calculatePoint());
                    break;
            }
            onCreateMode = false;
        }
    }

    public void onButtonCreateFactory()
    {
        onCreateMode = true;
        createType = PointType.FACTORY;
    }

    public void onButtonCreateMining()
    {
        onCreateMode = true;
        createType = PointType.MINING_COMPLEX;
    }

    public Vector3 calculatePoint()
    {
        ray.origin = camera.transform.position;
        Debug.Log(camera.transform.position.ToString());
        Debug.Log(camera.transform.forward.ToString());
        ray.direction = camera.transform.forward;

        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.Log("HIT");
            return hitInfo.point;
        }

        Debug.Log("MISS");
        return Vector3.one;
    }


}

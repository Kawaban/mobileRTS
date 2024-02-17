using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Commander commander;

    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Camera camera;

    public GameObject templateObject;

    public float xconst = 0.0005f;
    public float yconst = 0.0005f;

    public float forwconst = 1f;

    private bool onCreateMode = false;
    private BuildingType createType;

    private Ray ray;
    private RaycastHit hitInfo;

    private TemplateCollider templateCollider;

    void Start()
    {
        templateCollider = templateObject.GetComponent<TemplateCollider>();
    }

    void Update()
    {
        text.text = "Minerals: " + commander.Minerals;   

        if(onCreateMode)
        {
            templateObject.transform.position = calculatePoint();

            if(templateCollider.IsColliding)
            {
                templateObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else
            {
                templateObject.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }

        if(onCreateMode && Input.GetMouseButtonDown(0) && !templateCollider.IsColliding)
        {
            commander.createBuilding(createType,calculatePoint());
            onCreateMode = false;
        }

        
    }

    public void onButtonCreateFactory()
    {
        onCreateMode = true;
        createType = BuildingType.FACTORY;
        templateObject.transform.localScale = new Vector3(commander.CommanderData.Factory.GetComponent<Factory>().BuildingData.Length,
            commander.CommanderData.Factory.GetComponent<Factory>().BuildingData.Height,
            commander.CommanderData.Factory.GetComponent<Factory>().BuildingData.Width);
    }

    public void onButtonCreateMining()
    {
        onCreateMode = true;
        createType = BuildingType.MINING_COMPLEX;
        templateObject.transform.localScale = new Vector3(commander.CommanderData.MiningComplex.GetComponent<Factory>().BuildingData.Length,
           commander.CommanderData.MiningComplex.GetComponent<Factory>().BuildingData.Height,
           commander.CommanderData.MiningComplex.GetComponent<Factory>().BuildingData.Width);
    }

    public Vector3 calculatePoint()
    {
        Vector3 additional = new Vector3(Input.mousePosition.x * xconst, Input.mousePosition.y * yconst * Mathf.Sin(Mathf.PI/4), Input.mousePosition.y * yconst* Mathf.Sin(Mathf.PI / 4));

        ray.origin = camera.transform.position;
        
        ray.direction = camera.transform.forward * forwconst + additional;


        if (Physics.Raycast(ray, out hitInfo))
        {
          
            return hitInfo.point;
        }

        
        return Vector3.one;
    }


}

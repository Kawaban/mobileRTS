using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICommanderStrategy : MonoBehaviour
{
    [SerializeField] private Commander commander;

    [SerializeField] private Transform DebugFactoryPoint;
    [SerializeField] private Transform DebugMiningComplexPoint;

    bool isFactoryCreated = false;

    void Update()
    {
        if(!isFactoryCreated)
        {
            commander.createBuilding(BuildingType.FACTORY, DebugFactoryPoint.position);
            commander.createBuilding(BuildingType.MINING_COMPLEX, DebugMiningComplexPoint.position);
            isFactoryCreated = true;
        }
     
    }

    
}

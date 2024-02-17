using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiningComplex : Factory
{
   
    public void Extraction(float value)
    {
        Commander.mineralIncome(value);
    }

    public override PriorityInfo getPriorityInofrmation()
    {
        PriorityInfo priorityInfo = new PriorityInfo();
        priorityInfo.position = gameObject.transform.position;
        priorityInfo.type = PointType.MINING_COMPLEX;
        return priorityInfo;
    }
}

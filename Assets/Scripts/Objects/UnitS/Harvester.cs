using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : Unit
{
    [System.NonSerialized] public bool isFull = false;
    [SerializeField] private HarvesterData data;
    [System.NonSerialized] public float mineralValue=0;

    public HarvesterData Data { get => data; }

    public override PriorityInfo getPriorityInofrmation()
    {
        PriorityInfo priorityInfo = new PriorityInfo();
        priorityInfo.position = gameObject.transform.position;
        priorityInfo.type = PointType.HARVESTER;
        return priorityInfo;
    }

    public override List<PointOfInterest> GetPointOfInterests()
    {
        List<PointOfInterest> points = new List<PointOfInterest>();

        if (isFull)
        {
            foreach (PointOfInterest pointOfInterest in base.OurCommander.getPointsOfInterest())
                if (pointOfInterest is MiningComplex)
                    points.Add(pointOfInterest);
        }
        else
        {
            foreach (NeutralObject neutralObject in base.NeutralObjectManager.objects)
                if (neutralObject is Mineral)
                    points.Add(neutralObject);
        }

        return points;
    }

    public void MineCooldown(UnitMine unitMine)
    {
        StartCoroutine(unitMine.MineCooldown(data.TimeToMine));
    }

    public void ExtractCooldown(UnitExtract unitExtract)
    {
        StartCoroutine(unitExtract.ExtractCooldown(data.TimeToExtract));
    }

    public override void onStart()
    {
        base.onStart();
        startegyOverseer = new HarvesterStrategyOverseer(this);
    }


}

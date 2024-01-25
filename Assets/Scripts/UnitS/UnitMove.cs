using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : UnitStrategy
{

    private Unit unit;
    public UnitMove(Unit unit)
    {
        this.unit = unit;
    }

    public void Execute()
    {
        CalculateDestination();
        SetPath();
    }

    private void SetPath()
    {
        unit.Agent.SetDestination(unit.DestinationPoint);
        unit.Agent.stoppingDistance = unit.UnitData.TargetOffset;
    }

    private void CalculateDestination()
    {
        float maxMark = float.MinValue;
        PointOfInterest best = null;
        foreach (PointOfInterest point in unit.EnemyObserver.PointsOfInterest)
        {
            float mark = PriorityCalculator.calculate(unit.getPriorityInofrmation(), point.getPriorityInofrmation());
            if (maxMark < mark)
            {
                maxMark = mark;
                best = point;
            }
        }

        if (best != null)
        {
            unit.DestinationPoint = best.getPriorityInofrmation().position;
        }

    }
}

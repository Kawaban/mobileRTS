using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : UnitStrategy
{
    public void Execute(Unit unit)
    {
        SetPath(unit);
        Shoot(unit);
    }

    private void Shoot(Unit unit)
    {
        if (((Damagable)unit.TargetObject).damageTaken(unit.UnitData.Damage))
        {
            unit.EnemyObserver.PointsOfInterest.Remove(unit.TargetObject);
            unit.TargetObject = null;
        }
    }

    private void SetPath(Unit unit)
    {
        unit.DestinationPoint = unit.TargetObject.getPriorityInofrmation().position;
        unit.Agent.SetDestination(unit.DestinationPoint);
        unit.Agent.stoppingDistance = unit.UnitData.TargetOffset;
    }

}

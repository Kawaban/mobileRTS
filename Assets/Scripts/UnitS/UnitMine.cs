using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMine : UnitStrategy
{
    private float isMining = 0;
    public void Execute(Unit unit)
    {
        SetPath(unit);
        if (isMining == 0)
            ((Harvester)unit).MineCooldown(this);
        if (isMining == 2)
            Mine((Harvester)unit);
    }

    private void Mine(Harvester unit)
    {
        unit.mineralValue=((Mineral)unit.TargetObject).extractMinerals(unit.Data.MineValue);
        unit.isFull = true;
        isMining = 0;
    }


    public IEnumerator MineCooldown(float reloadTime)
    {
        isMining = 1;
        yield return new WaitForSeconds(reloadTime);
        isMining = 2;
    }

    private void SetPath(Unit unit)
    {
        unit.DestinationPoint = unit.getPriorityInofrmation().position;

        unit.Agent.SetDestination(unit.DestinationPoint);
        unit.Agent.stoppingDistance = unit.UnitData.TargetOffset;
    }
}

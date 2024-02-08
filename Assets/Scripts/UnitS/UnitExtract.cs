using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitExtract : UnitStrategy
{
    private float isExtracting = 0;
    public void Execute(Unit unit)
    {
        SetPath(unit);
        if (isExtracting == 0)
            ((Harvester)unit).ExtractCooldown(this);
        if (isExtracting == 2)
            Extract((Harvester)unit);
    }

    private void Extract(Harvester unit)
    {
        ((MiningComplex)unit.TargetObject).Extraction(unit.mineralValue);
        unit.isFull = false;
        unit.mineralValue = 0;
        isExtracting = 0;
    }

    

    public IEnumerator ExtractCooldown(float reloadTime)
    {
        isExtracting = 1;
        yield return new WaitForSeconds(reloadTime);
        isExtracting = 2;
    }

    private void SetPath(Unit unit)
    {
        unit.DestinationPoint = unit.getPriorityInofrmation().position;

        unit.Agent.SetDestination(unit.DestinationPoint);
        unit.Agent.stoppingDistance = unit.UnitData.TargetOffset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvesterStrategyOverseer : UnitStartegyOverseer
{
    public HarvesterStrategyOverseer(Harvester unit) : base(unit)
    {
        strategies.Add(UnitStrategyType.MINE, new UnitMine());
        strategies.Add(UnitStrategyType.EXCTRACT, new UnitExtract());
    }

    public override void reconsiderStrategy()
    {
        if(mineIsPossible()) 
        {
            strategyType = UnitStrategyType.MINE;
            strategy = strategies[strategyType];
        }
        else if(extractIsPossible()) 
        {
            strategyType = UnitStrategyType.EXCTRACT;
            strategy = strategies[strategyType];
        }
        else 
        {
            strategyType = UnitStrategyType.MOVE;
            strategy = strategies[strategyType];
        }
        
    }

    private bool mineIsPossible()
    {
        if(!((Harvester)unit).isFull)
         if (unit.TargetObject != null)
            if (unit.TargetObject is Mineral)
                /*if (CheckTarget())*/
                    if (Vector3.Distance(unit.getPriorityInofrmation().position, unit.TargetObject.getPriorityInofrmation().position) <= ((Harvester)unit).Data.MineRange)
                        return true;

        return false;
    }

    private bool extractIsPossible()
    {
        if (((Harvester)unit).isFull)
            if (unit.TargetObject != null)
                if (unit.TargetObject is MiningComplex)
                   /*if (CheckTarget())*/
                     if (Vector3.Distance(unit.getPriorityInofrmation().position, unit.TargetObject.getPriorityInofrmation().position) <= ((Harvester)unit).Data.ExtractRange)
                        return true;

        return false;
    }

    /*private bool CheckTarget()
    {
        if (((Damagable)unit.TargetObject).isDead())
        {
            unit.TargetObject = null;
            return false;
        }
        return true;
    }*/



}

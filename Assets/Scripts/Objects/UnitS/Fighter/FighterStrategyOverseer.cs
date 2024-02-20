using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStrategyOverseer : UnitStartegyOverseer
{
    public FighterStrategyOverseer(Unit unit) : base(unit)
    {
        strategies.Add(UnitStrategyType.ATTACK, new UnitAttack());
    }

    public override void reconsiderStrategy()
    {
        if (attackIsPossible())
        {
            strategyType = UnitStrategyType.ATTACK;
            strategy = strategies[strategyType];
        }
        else
        {
            strategyType = UnitStrategyType.MOVE;
            strategy = strategies[strategyType];
        }
    }

    

    private bool attackIsPossible()
    {
        if (unit.TargetObject != null)
            if (unit.TargetObject is Damagable)
                if (CheckTarget())
                    if (Vector3.Distance(unit.getPriorityInofrmation().position, unit.TargetObject.getPriorityInofrmation().position) <= ((Fighter)unit).FighterData.AttackRange)
                        return true;

        return false;
    }

    private bool CheckTarget()
    {
        if (((Damagable)unit.TargetObject).isDead())
        {
            unit.TargetObject = null;
            return false;
        }
        return true;
    }
}   


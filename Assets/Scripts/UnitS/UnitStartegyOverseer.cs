using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStartegyOverseer 
{
    private Unit unit;
    private Dictionary<UnitStrategyType, UnitStrategy> strategies;
    private UnitStrategy strategy;
    private UnitStrategyType strategyType;

    public UnitStartegyOverseer(Unit unit)
    {
        this.unit = unit;
        strategies = new Dictionary<UnitStrategyType, UnitStrategy>
        {
            { UnitStrategyType.PASSIVE, new UnitPassive() },
            { UnitStrategyType.MOVE, new UnitMove() },
            { UnitStrategyType.ATTACK, new UnitAttack() }
        };

    }

    public void reconsiderStrategy()
    {
        if(attackIsPossible())
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
        if(unit.TargetObject != null)
            if (unit.TargetObject is Damagable)
                if (Vector3.Distance(unit.getPriorityInofrmation().position,unit.TargetObject.getPriorityInofrmation().position) <= unit.UnitData.AttackRange)
                    return true;

        return false;
    }

    public void MoveStrategyOn()
    {
        strategyType = UnitStrategyType.MOVE;
        strategy = strategies[strategyType];
    }

    public void MoveStrategyOff()
    {
        strategyType = UnitStrategyType.PASSIVE;
        strategy = strategies[strategyType];
    }

    public void setDefaultStrategy()
    {
        strategyType = UnitStrategyType.PASSIVE;
        strategy = strategies[strategyType];
    }

    public void ExecuteStrategy()
    {
        strategy.Execute(unit);
    }
}
using System.Collections.Generic;
using UnityEngine;

public class UnitStartegyOverseer
{
    protected Unit unit;
    protected Dictionary<UnitStrategyType, UnitStrategy> strategies;
    protected UnitStrategy strategy;
    protected UnitStrategyType strategyType;

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

    public virtual void reconsiderStrategy()
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
                    if (Vector3.Distance(unit.getPriorityInofrmation().position, unit.TargetObject.getPriorityInofrmation().position) <= unit.UnitData.AttackRange)
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

using System.Collections.Generic;
using UnityEngine;

public abstract class UnitStartegyOverseer
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
        };

    }

    public abstract void reconsiderStrategy();
  

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

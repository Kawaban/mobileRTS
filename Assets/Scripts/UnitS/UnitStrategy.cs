using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitStrategyType
{
    ATTACK,
    MOVE,
    PASSIVE
}

public interface UnitStrategy
{
    public void Execute();
}

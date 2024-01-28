public enum UnitStrategyType
{
    ATTACK,
    MOVE,
    PASSIVE
}

public interface UnitStrategy
{
    public void Execute(Unit unit);
}

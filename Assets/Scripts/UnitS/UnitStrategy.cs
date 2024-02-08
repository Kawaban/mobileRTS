public enum UnitStrategyType
{
    ATTACK,
    MOVE,
    PASSIVE,
    MINE,
    EXCTRACT
}

public interface UnitStrategy
{
    public void Execute(Unit unit);
}

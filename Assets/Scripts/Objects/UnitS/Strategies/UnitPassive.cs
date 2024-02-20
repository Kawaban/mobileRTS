public class UnitPassive : UnitStrategy
{

    public void Execute(Unit unit)
    {
        unit.DestinationPoint = unit.getPriorityInofrmation().position;
        SetPath(unit);
    }

    private void SetPath(Unit unit)
    {
        unit.Agent.SetDestination(unit.DestinationPoint);
        unit.Agent.stoppingDistance = 0;
        unit.TargetObject = null;
    }

}

public class UnitMove : UnitStrategy
{



    public void Execute(Unit unit)
    {
        CalculateDestination(unit);
        SetPath(unit);
    }

    private void SetPath(Unit unit)
    {
        unit.Agent.SetDestination(unit.DestinationPoint);
        unit.Agent.stoppingDistance = unit.UnitData.TargetOffset;
    }

    private void CalculateDestination(Unit unit)
    {
        float maxMark = float.MinValue;
        PointOfInterest best = null;
        foreach (PointOfInterest point in unit.GetPointOfInterests())
        {
            float mark = PriorityCalculator.calculate(unit.getPriorityInofrmation(), point.getPriorityInofrmation());
            if (maxMark < mark)
            {
                maxMark = mark;
                best = point;
            }
        }

        if (best != null)
        {
            unit.TargetObject = best;
            unit.DestinationPoint = best.getPriorityInofrmation().position;
        }

    }
}

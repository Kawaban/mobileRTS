public class ControlPoint : NeutralObject
{

    public override PriorityInfo getPriorityInofrmation()
    {
        PriorityInfo priority = new PriorityInfo();
        priority.position = gameObject.transform.position;
        priority.type = PointType.CONTROL_POINT;
        return priority;
    }



}

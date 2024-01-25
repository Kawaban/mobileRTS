using UnityEngine;

public enum PointType
{
    UNIT,
    FACTORY
}

public struct PriorityInfo
{
    public Vector3 position;
    public PointType type;
}

public interface PointOfInterest
{
    public PriorityInfo getPriorityInofrmation();
}

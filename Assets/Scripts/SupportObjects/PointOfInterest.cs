using UnityEngine;

public enum PointType
{
    UNIT,
    FACTORY,
    CONTROL_POINT,
    MINERAL,
    HARVESTER,
    MINING_COMPLEX
}

public enum BuildingType
{
   
    FACTORY,
    MINING_COMPLEX
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

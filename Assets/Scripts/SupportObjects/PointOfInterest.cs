using UnityEngine;

public enum PointType
{
    UNIT,
    FACTORY,
    CONTROL_POINT,
    MINERAL,
    HARVESTER,
    MINING_COMPLEX,
    TOYOTA,
    TURRET
}

public enum BuildingType
{
   
    FACTORY,
    MINING_COMPLEX,
    TURRET
}

public enum UnitType
{
    AIR_UNIT,
    GROUND_UNIT
}

public enum AttackRule
{
   CLOSEST,
   STRONGEST,
   WEAKEST
}

public enum AttackType
{
    AIR,
    GROUND,
    BOTH
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


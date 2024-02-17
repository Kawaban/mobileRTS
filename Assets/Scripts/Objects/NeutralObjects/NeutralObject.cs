using UnityEngine;

public abstract class NeutralObject : MonoBehaviour, PointOfInterest
{
    public abstract PriorityInfo getPriorityInofrmation();
}

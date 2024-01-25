using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/PriorityObserver")]
public class PriorityObserver : ScriptableObject
{
    private List<PointOfInterest> pointsOfInterest = new List<PointOfInterest>();

    public List<PointOfInterest> PointsOfInterest { get => pointsOfInterest; }

}

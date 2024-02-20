using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/HarvesterData")]
public class HarvesterData : ScriptableObject
{
    [SerializeField] private float timeToMine;
    [SerializeField] private float timeToExtract;
    [SerializeField] private float mineRange;
    [SerializeField] private float extractRange;
    [SerializeField] private float mineValue;

    public float TimeToMine { get => timeToMine;  }
    public float TimeToExtract { get => timeToExtract;  }
    public float MineRange { get => mineRange;  }
    public float ExtractRange { get => extractRange;  }
    public float MineValue { get => mineValue; }
}

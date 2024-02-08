using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/MineralData")]
public class MineralData : ScriptableObject
{
    [SerializeField] private float mineralQuality;
    [SerializeField] private float startMineralValue;

    public float MineralQuality { get => mineralQuality; }
    public float StartMineralValue { get => startMineralValue;  }
}

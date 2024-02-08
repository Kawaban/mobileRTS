using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Factory : Building
{
    [SerializeField] List<FactoryData> factoryDataLevels;
    [SerializeField] private Transform spawnPoint;
    private int level;
    private int levelMax;
    private bool readyToGenearate;
    private UnityEvent<Unit> unitEvent;
    private Commander commander;

    public UnityEvent<Unit> UnitEvent { get => unitEvent; }
    public Commander Commander { get => commander; set => commander = value; }

    void Awake()
    {
        base.baseAwake();
        if (unitEvent == null)
            unitEvent = new UnityEvent<Unit>();
    }


    void Start()
    {
        base.baseStart();
        level = 0;
        levelMax = factoryDataLevels.Count;
        /* StartCoroutine(GenerationCooldown(factoryDataLevels[level].SecondsToGenerate));*/
        readyToGenearate = true;
    }

    void Update()
    {
        if (readyToGenearate)
            GenerateUnit();
    }

    private void GenerateUnit()
    {
        GameObject generatedUnit = Instantiate(factoryDataLevels[level].GeneratedUnit, spawnPoint.position, Quaternion.identity);
        unitEvent.Invoke(generatedUnit.GetComponent<Unit>());

        StartCoroutine(GenerationCooldown(factoryDataLevels[level].SecondsToGenerate));

    }

    public IEnumerator GenerationCooldown(float seconds)
    {
        readyToGenearate = false;
        yield return new WaitForSeconds(seconds);
        readyToGenearate = true;
    }

    public void levelUP()
    {
        level++;
    }

    public bool checkToLevelUp()
    {
        if (level < levelMax) return true;
        return false;

    }

    public override PriorityInfo getPriorityInofrmation()
    {
        PriorityInfo priorityInfo = new PriorityInfo();
        priorityInfo.position = gameObject.transform.position;
        priorityInfo.type = PointType.FACTORY;
        return priorityInfo;
    }
}

using UnityEngine;
using System.Collections.Generic;

public class UnitTraining : MonoBehaviour
{
    public List<Unit> trainedUnits = new List<Unit>();
    public Transform barracks;
    
    public void TrainUnit(UnitType type, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            Unit newUnit = new Unit(type, barracks.position);
            trainedUnits.Add(newUnit);
            Debug.Log("Trained " + type);
        }
        
        ResourceManager.Instance?.SpendCurrency(quantity * GetUnitCost(type));
    }
    
    int GetUnitCost(UnitType type)
    {
        switch (type)
        {
            case UnitType.Infantry: return 100;
            case UnitType.Archer: return 150;
            case UnitType.Cavalry: return 200;
            default: return 100;
        }
    }
}

[System.Serializable]
public class Unit
{
    public UnitType type;
    public Vector3 position;
    public int hp = 50;
    public int attack = 10;
    
    public Unit(UnitType type, Vector3 position)
    {
        this.type = type;
        this.position = position;
    }
}

public enum UnitType
{
    Infantry,
    Archer,
    Cavalry
}

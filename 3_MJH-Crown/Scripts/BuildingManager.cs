using UnityEngine;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }
    
    public List<Building> buildings = new List<Building>();
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void BuildBuilding(BuildingType type, Vector3 position)
    {
        Building newBuilding = new Building(type, position);
        buildings.Add(newBuilding);
        Debug.Log("Built " + type + " at " + position);
        AudioManager.Instance?.PlaySFX("Building_Complete");
    }
    
    public void UpgradeBuilding(Building building)
    {
        building.level++;
        Debug.Log("Upgraded " + building.type + " to level " + building.level);
    }
}

[System.Serializable]
public class Building
{
    public BuildingType type;
    public Vector3 position;
    public int level = 1;
    public bool isCompleted;
    
    public Building(BuildingType type, Vector3 position)
    {
        this.type = type;
        this.position = position;
    }
}

public enum BuildingType
{
    Castle,
    Farm,
    Barracks,
    Wall
}

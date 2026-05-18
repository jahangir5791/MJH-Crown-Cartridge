using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    
    public int gold = 500;
    public int wood = 300;
    public int food = 400;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public bool SpendCurrency(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            Debug.Log("Spent " + amount + " gold. Remaining: " + gold);
            return true;
        }
        return false;
    }
    
    public void AddResource(ResourceType type, int amount)
    {
        switch (type)
        {
            case ResourceType.Gold: gold += amount; break;
            case ResourceType.Wood: wood += amount; break;
            case ResourceType.Food: food += amount; break;
        }
        Debug.Log("Added " + amount + " " + type);
    }
}

public enum ResourceType
{
    Gold,
    Wood,
    Food
}

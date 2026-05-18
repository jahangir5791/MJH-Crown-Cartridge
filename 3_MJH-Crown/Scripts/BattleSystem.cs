using UnityEngine;
using System.Collections.Generic;

public class BattleSystem : MonoBehaviour
{
    public List<Unit> playerUnits = new List<Unit>();
    public List<Unit> enemyUnits = new List<Unit>();
    
    public void StartBattle()
    {
        Debug.Log("Battle started!");
        ResourceManager.Instance?.SpendCurrency(50);
    }
    
    public void ResolveBattle()
    {
        foreach (var playerUnit in playerUnits)
        {
            var target = GetNearestEnemy(playerUnit);
            if (target != null)
            {
                Attack(playerUnit, target);
            }
        }
    }
    
    Unit GetNearestEnemy(Unit unit)
    {
        Unit nearest = null;
        float minDistance = float.MaxValue;
        
        foreach (var enemy in enemyUnits)
        {
            float distance = Vector3.Distance(unit.position, enemy.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = enemy;
            }
        }
        
        return nearest;
    }
    
    void Attack(Unit attacker, Unit target)
    {
        target.hp -= attacker.attack;
        AudioManager.Instance?.PlaySFX("Sword_Swing");
        
        if (target.hp <= 0)
        {
            Debug.Log(target.type + " defeated!");
            GameManager.Instance?.AddScore(20);
        }
    }
}

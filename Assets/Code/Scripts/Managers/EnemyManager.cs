using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField]
    private List<EnemyInformation> enemyInformation = new List<EnemyInformation>();

    public GameObject SpawnEnemy(EnemyType type)
    {
        EnemyInformation enemyInfo = enemyInformation.Find(x => x.Type == type);
        if (enemyInfo != null)
        {
            switch (type)
            {
                case EnemyType.Skeleton:
                    return Instantiate(enemyInfo.Prefab) as GameObject;
                default:
                    return null;
            }
        }
        else
        {
            Debug.LogWarning("No enemy of type " + type + " was registered.");

            return null;
        }
    }
}
using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField]
    private List<EnemyInformation> enemyInformation = new List<EnemyInformation>();

    public GameObject SpawnEnemy(Enemy enemy, WorldRoom worldRoom, Vector3 position)
    {
        EnemyInformation enemyInfo = enemyInformation.Find(x => x.Type == enemy.Type);
        if (enemyInfo != null)
        {
            GameObject obj = Instantiate(enemyInfo.Prefab) as GameObject;
            obj.transform.position = position;
            obj.transform.SetParent(worldRoom.transform);

            WorldEnemy worldEnemy = obj.GetComponent<WorldEnemy>();
            worldEnemy.Enemy = enemy;

            return obj;
        }
        else
        {
            Debug.LogWarning("No enemy of type " + enemy.Type + " was registered.");

            return null;
        }
    }
}
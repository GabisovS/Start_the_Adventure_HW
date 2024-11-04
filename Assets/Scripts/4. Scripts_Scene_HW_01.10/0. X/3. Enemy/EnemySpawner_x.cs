using UnityEngine;

public class EnemySpawner_x : MonoBehaviour
{
    [SerializeField] private Enemy_x _typeOnePrefab;
    [SerializeField] private Enemy_x _typeTwoPrefab;
    [SerializeField] private Enemy_x _typeThreePrefab;

    public Enemy_x EnemySpawnTo(Vector3 position, EnemyTypes_x enemyType)
    {
        switch (enemyType)
        {
            case EnemyTypes_x.TypeOne:
               return Instantiate(_typeOnePrefab, position, Quaternion.identity, null);
                break;

            case EnemyTypes_x.TypeTwo:
                return Instantiate(_typeTwoPrefab, position, Quaternion.identity, null);
                break;

            case EnemyTypes_x.TypeThree:
                return Instantiate(_typeThreePrefab, position, Quaternion.identity, null);
                break;

            default:
                Debug.LogError("Not right type of enemy");
                break;
        }
        return null;
    }
}

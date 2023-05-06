using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text EnemyRemained;
    public Text txtResult;

    public TankEnemy enemyPrefab;
    public float spawnTime;
    public int EnemyCount;          // Contains all enemy

    private int EnemyInStack;       // How many enemy remained out
    private int EnemyInLevel;       // How many enemy are there in the level
    private List<TankEnemy> enemyList;
    private IEnumerator coroutine1;
    private IEnumerator coroutine2;

    private void Awake()
    {
        // Making a singleton
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    private void Start ()
    {
        enemyList = new List<TankEnemy>();
        EnemyInLevel = 0;
        EnemyInStack = EnemyCount;
        SpawnEnemy();
    }

    private IEnumerator SpawnEnemyCoroutine(float waitTime)
    {
        // Spawn more enemy tanks if too few are in field
        while (EnemyInStack>0 && EnemyInLevel<5)
        {
            EnemyRemained.text = "Enemy Remained: " + EnemyInStack;
            yield return new WaitForSeconds(waitTime);
            TankEnemy enTank = Instantiate(enemyPrefab, RandomVector(), Quaternion.identity);
            enemyList.Add(enTank);
            EnemyInLevel++;
            EnemyInStack--;
            EnemyRemained.text = "Enemy Remained: " + EnemyInStack;
        }
    }

    private IEnumerator EndGameCoroutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("MainMenu");
    }


    public void RemoveEnemy()
    {
        enemyList.RemoveAt(0);
        EnemyInLevel--;
    }

    public void SpawnEnemy()
    {
        coroutine1 = SpawnEnemyCoroutine(spawnTime);
        StartCoroutine(coroutine1);
    }

    public int GetEnemyRemained()
    {
        return EnemyInStack;
    }

    public void EndTheGame()
    {
        BaseObject[] allObjs = FindObjectsOfType<BaseObject>();
        for (int i = 0; i< allObjs.Length; i++)
        {
            Destroy(allObjs[i].gameObject);
        }
        coroutine2 = EndGameCoroutine(5);
        StartCoroutine(coroutine2);
    }

    // Making a random place to spawn enemy tanks
    Vector3 RandomVector()
    {
        Vector3 retVec;
        int point =(int) Random.Range(0, 4);
        switch (point)
        {
            case 0:
                retVec = new Vector3(-9, 14, 0);
                break;
            case 1:
                retVec = new Vector3(-4, 18, 0);
                break;
            case 2:
                retVec = new Vector3(3, 17, 0);
                break;
            case 3:
                retVec = new Vector3(7, 14, 0);
                break;
            case 4:
                retVec = new Vector3(-9, 18, 0);
                break;
            default:
                retVec = new Vector3(-9, 18, 0);
                break;
        }
        return retVec;
    }
}

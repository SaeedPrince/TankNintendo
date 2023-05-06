using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseObject : MonoBehaviour
{
    // Most of the game objects are from this class
    public float Health;
    public string Type;     // like: Enemy, Player, Eagle, ...
    private void LateUpdate()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            // Handling win / lose condition
            if (Type == "Eagle" || Type == "Player")
            {
                GameManager.instance.txtResult.text = "Sorry, you lost the game!";
                GameManager.instance.EndTheGame();
            }
            if (Type == "Enemy")
            {
                if (GameManager.instance.GetEnemyRemained() <= 0)
                {
                    GameManager.instance.txtResult.text = "Congratulations you won!";
                    GameManager.instance.EndTheGame();
                }
                else
                {
                    GameManager.instance.RemoveEnemy();
                    GameManager.instance.SpawnEnemy();
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int brickCount = 0;
    public GameObject Ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (brickCount == 0 && Ball.transform.position.y <= 0) {
            BrickPlacer.PlaceBlocks();
        }
    }

    public void GameOver() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

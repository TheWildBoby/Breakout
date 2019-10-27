using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPlacer : MonoBehaviour
{
    private static BrickPlacer _instance;
    

    // Start is called before the first frame update
    public Object Brick;
    public Object Brick2;
    public float BrickRatio; //0 - 100; Higher numbers mean more percent blue bricks

    void Awake()
    {
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void PlaceBlocks() {
        for (float i = -9f; i <= 9; i = i + 1.5f)
        {
            for (float j = 0.5f; j < 4.5f; j = j + .5f)
            {
                if (Random.value > (_instance.BrickRatio / 100f))
                {
                    Instantiate(_instance.Brick, new Vector3(i, j, 0), Quaternion.identity);
                    GameManager.brickCount++;
                }
                else
                {
                    Instantiate(_instance.Brick2, new Vector3(i, j, 0), Quaternion.identity);
                    GameManager.brickCount++;
                }
            }
        }
    }
}
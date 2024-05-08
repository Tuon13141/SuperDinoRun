using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Environment
{
    public List<Sprite> backgroundList;
    public List<GameObject> obstacles;
    public GameController GameController { get; set; }
    protected Environment(List<Sprite> backgroundList, List<GameObject> obstacles)
    {
        this.backgroundList = backgroundList;
        this.obstacles = obstacles;
    }

    public void SetGameController(GameController gameController)
    {
        GameController = gameController;
    }
    public void SetBackground(GameObject background)
    {
        int index = Random.Range(0, backgroundList.Count);
        background.GetComponent<SpriteRenderer>().sprite = backgroundList[index];
    }
    public abstract GameObject SetObstacle();
   
}

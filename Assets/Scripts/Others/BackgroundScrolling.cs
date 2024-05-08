using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField]
    public GameController gameController;

    private MovingObject movingObject;
    // Start is called before the first frame update
    void Start()
    {
        movingObject = new MovingToTheLeftObject(SpeedSetting.movingToLeftSpeed, this.gameObject);
        gameController.Environment.SetBackground(this.gameObject);
        StartCoroutine(ResetBackground());
    }

    private void Update()
    {
        movingObject.Move();
    }
    IEnumerator ResetBackground()
    {
        yield return new WaitUntil(() => transform.position.x < -11);
        transform.position = new Vector2(11, transform.position.y);
        gameController.Environment.SetBackground(this.gameObject);

        StartCoroutine(ResetBackground());    
    }
}

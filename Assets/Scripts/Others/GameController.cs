using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Camera mainCamera;
    private bool ChangeCameraSize = false;

    public GameObject DinoPlayer;
    private bool ChangeDinoPosition = false;
    public Environment Environment { get; set; }

    public List<Sprite> backgroundList_Desert;
    public List<Sprite> backgroundList_Jungle;
    public List<Sprite> backgroundList_Lava;
    public List<Sprite> backgroundList_Boss;

    public List<GameObject> obstacles_Desert;
    public List<GameObject> obstacles_Jungle;
    public List<GameObject> obstacles_Lava;    
    public List<GameObject> obstacles_Boss;
    public List<GameObject> obstacles_Common;


    private List<Environment> environmentList;
    private int randomRange = 2;

    [SerializeField]
    private int maxObstacle;
    private int obstacleCount;

    [SerializeField]
    private int maxEnvironmentState;
    private int environtmentStateCount;

    public Text textScore;
    private int Score = 0;
    private int nextScore = 20;

    public GameObject tutorialForBossBattleText;

    public void ChangeEnvironment(Environment environment)
    {
        Environment = environment;
        Environment.SetGameController(this);
    }

    private void Start()
    {
        mainCamera.orthographicSize = 2.6f;
        environmentList = new List<Environment>() { new Desert(backgroundList_Desert, obstacles_Desert),  
                                                    new Jungle(backgroundList_Jungle, obstacles_Jungle), 
                                                    new Lava(backgroundList_Lava, obstacles_Lava)};
        ChangeEnvironment(randomEnvironment());
        StartCoroutine(DelayFromStart());
        StartCoroutine(Scoring());
        SpeedSetting.movingLoopSpeed = SpeedSettingDefault.movingLoopSpeed;
        SpeedSetting.movingToLeftSpeed = SpeedSettingDefault.movingToLeftSpeed;
    }

    private void Update()
    {
        textScore.text = Score.ToString();
        ZoomCamera();
        RepositionDinoForBossBattle();
    }

    IEnumerator SpawnObstacles()
    {
        float cooldownSpawnTime = 2f;
        if (Environment.GetType() == typeof(BossBattle))
        {
            yield return new WaitForSeconds(cooldownSpawnTime);
            ChangeCameraSize = true;
            ChangeDinoPosition = true;
            yield return new WaitUntil(() => mainCamera.orthographicSize == 3f);
            yield return new WaitForSeconds(cooldownSpawnTime);
            cooldownSpawnTime = 5f;
            GameObject obstacle = Environment.SetObstacle();
            GameObject boss = Instantiate(obstacle);
            boss.GetComponent<Obstacle>().SetMovingObject(obstacle.GetComponent<Obstacle>().MovingObject);

            yield return new WaitUntil(() => boss.GetComponent<CommonObstacle>().cooldown);

            ChangeDinoPosition = false;
            yield return new WaitForSeconds(cooldownSpawnTime);
            ChangeEnvironment(randomEnvironment());
            StartCoroutine(SpawnObstacles());
        }
        else
        {
            tutorialForBossBattleText.SetActive(false);
            ChangeCameraSize = false;

            int random = Random.Range(0, randomRange);
            if (random > 0)
            {
                GameObject commonObstical = Instantiate(obstacles_Common[Random.Range(0, obstacles_Common.Count)]);

                yield return new WaitUntil(() => commonObstical.GetComponent<CommonObstacle>().cooldown);

                yield return new WaitForSeconds(cooldownSpawnTime);
                randomRange = 2;
                StartCoroutine(SpawnObstacles());
            }
            else
            {
                GameObject obstacle = Environment.SetObstacle();
                GameObject spawnedObstacle = Instantiate(obstacle);

                spawnedObstacle.GetComponent<Obstacle>().SetMovingObject(obstacle.GetComponent<Obstacle>().MovingObject);


                if (spawnedObstacle.GetComponent<Obstacle>().GetType() == typeof(AdjacentObstacle) ||
                   spawnedObstacle.GetComponent<Obstacle>().GetType() == typeof(AdjacentObstacleHasOneTrap))
                {
                    cooldownSpawnTime = 4f;
                }

                obstacleCount++;
                if (obstacleCount > maxObstacle)
                {
                    StopCoroutine(SpawnObstacles());
                    ReachMaxObstacleToChangeEnvironment();                
                }
                yield return new WaitForSeconds(cooldownSpawnTime);
                randomRange = 1;
                StartCoroutine(SpawnObstacles());
            }
        }
    }

    private void ReachMaxObstacleToChangeEnvironment()
    {
        obstacleCount = 0;
        environtmentStateCount++;
        if(environtmentStateCount == maxEnvironmentState)
        {
            environtmentStateCount = 0;
            ChangeEnvironment(new BossBattle(backgroundList_Boss, obstacles_Boss));
        }
        else 
        {
            ChangeEnvironment(randomEnvironment());
        }
       
    }

    private Environment randomEnvironment()
    {

        Environment randomEnvironment = environmentList[Random.Range(0, environmentList.Count)];

        if (Environment != null)
        {
            while (randomEnvironment.GetType() == Environment.GetType())
            {
                randomEnvironment = environmentList[Random.Range(0, environmentList.Count)];
            }
        }


        return randomEnvironment;

    }

    private void ZoomCamera()
    {
        if (ChangeCameraSize)
        {
            if (mainCamera.orthographicSize < 3f)
            {
                mainCamera.orthographicSize += 1f * Time.deltaTime;
            }
            else
            {
                mainCamera.orthographicSize = 3f;
            }
        }
        else
        {
            if (mainCamera.orthographicSize > 2.6f)
            {
                mainCamera.orthographicSize -= 1f * Time.deltaTime;
            }
            else
            {
                mainCamera.orthographicSize = 2.6f;
            }
        }
    }

    private void RepositionDinoForBossBattle()
    {
        if(DinoPlayer == null)
        {
            if(SpeedSettingDefault.highScore < Score) 
            { 
                SpeedSettingDefault.highScore = Score;
                PlayerPrefs.SetInt("highscore", SpeedSettingDefault.highScore);
                PlayerPrefs.Save();
            }
            return;
        }

        if(ChangeDinoPosition)
        {
            if(DinoPlayer.transform.position.x < 0 && DinoPlayer.GetComponent<Dino>().CanMoveHorizontal == false)
                DinoPlayer.transform.Translate(Vector2.right * 3f * Time.deltaTime);
            else
            {
                DinoPlayer.GetComponent<Dino>().CanMoveHorizontal = true;
                tutorialForBossBattleText.SetActive(true);
            }
        }
        else
        {
            DinoPlayer.GetComponent<Dino>().CanMoveHorizontal = false;
            //if (DinoPlayer.transform.position.x > -4 && DinoPlayer.GetComponent<Dino>().CanMoveHorizontal == false)
            //DinoPlayer.transform.Translate(Vector2.left * 3f * Time.deltaTime);
            //else
            //{
            // DinoPlayer.transform.position = new Vector2(-4, DinoPlayer.transform.position.y);
            //}

            DinoPlayer.transform.position = Vector2.MoveTowards(DinoPlayer.transform.position, new Vector2(-4, DinoPlayer.transform.position.y), 4f * Time.deltaTime);
        }
    }

    private IEnumerator DelayFromStart()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator Scoring()
    {
        yield return new WaitForSeconds(0.5f);
        Score++;
        StartCoroutine(Scoring());  
        if(Score >= nextScore && SpeedSetting.movingToLeftSpeed <= SpeedSettingDefault.maxSpeed)
        {
            nextScore += nextScore / 2;
            SpeedSetting.movingLoopSpeed += SpeedSettingDefault.acceleration;
            SpeedSetting.movingToLeftSpeed += SpeedSettingDefault.acceleration;
            //Debug.Log(SpeedSetting.movingLoopSpeed);
        }
    }
}

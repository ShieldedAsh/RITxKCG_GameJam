using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*ObjectManager.cs
The purpose of this script is to handle spawning of new objects, score updates, and user input when objects are clicked
Note: This file might need to undergo separation of responsibilities because there is a lot going on here.
*/
public class ObjectManager : MonoBehaviour
{
    [SerializeField]
    private GameData gameData; //reference to the game data scriptable object

    [SerializeField]
    private GameObject moveArea; //reference to the move area object

    [SerializeField]
    private List<GameObject> badObject; //reference to bad objects

    [SerializeField]
    private List<GameObject> goodObject; //reference to good objects

    //list of all the objects currently in the scene
    public static List<GameObject> objects;

    private int currentTargetMaxNum;
    private float timer = 0;

    //total score the player has obtained
    public static int totalScore = 0;

    //SpawnData
    private Vector2 spawnAreaLT;
    private Vector2 spawnAreaRB;

    private void Start()
    {
        objects = new List<GameObject>();
        currentTargetMaxNum = gameData.StartTargetNum;
        timer = 0.0f;

        Vector2 harfScale = moveArea.transform.localScale * 0.5f;
        spawnAreaLT = new(moveArea.transform.position.x - harfScale.x, moveArea.transform.position.y + harfScale.y);
        spawnAreaRB = new(moveArea.transform.position.x + harfScale.x, moveArea.transform.position.y - harfScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (objects.Count < currentTargetMaxNum)
        {
            SpawnNewObject();
        }

        //Increase the number of targets as time goes on
        //éûä‘Ç™åoâﬂÇµÇΩÇÁìIÇÃêîÇëùÇ‚Ç∑
        if (timer >= gameData.TargetNumIncreaseInterval)
        {
            currentTargetMaxNum += gameData.TargetNumIncreaseAmount;
            timer = 0.0f;
        }
        timer += Time.deltaTime;
    }

    /// <summary>
    /// Instantiates a new object on screen
    /// </summary>
    void SpawnNewObject()
    {
        //choose between good or bad object 1Å`100
        int coinflip = Random.Range(1, 101);

        //choose direction
        //0 is From Left To Right, 1 is From Right to Left, 2 is From Top to Bottom, 3 is from Bottom to Top
        int randomDir = Random.Range(0, 4);

        int objectListSize = coinflip <= gameData.GoodTargetSpawnRate ? goodObject.Count : badObject.Count;

        int createObjectIndex = Random.Range(0, objectListSize);

        Vector3 spawnPos = Vector3.zero;


        switch (randomDir)
        {
            case 0:
                spawnPos = new Vector3(spawnAreaLT.x - 0.5f, Random.Range(spawnAreaRB.y, spawnAreaLT.y), 0f);
                break;
            case 1:
                spawnPos = new Vector3(spawnAreaRB.x + 0.5f, Random.Range(spawnAreaRB.y, spawnAreaLT.y), 0f);
                break;
            case 2:
                spawnPos = new Vector3(Random.Range(spawnAreaLT.x, spawnAreaRB.x), spawnAreaLT.y + 0.5f, 0f);
                break;
            case 3:
                spawnPos = new Vector3(Random.Range(spawnAreaLT.x, spawnAreaRB.x), spawnAreaRB.y - 0.5f, 0f);
                break;
        }

        GameObject tempObj = coinflip <= gameData.GoodTargetSpawnRate ?
            Instantiate(goodObject[createObjectIndex], spawnPos, Quaternion.identity) :
            Instantiate(badObject[createObjectIndex], spawnPos, Quaternion.identity);
        tempObj.GetComponent<ObjectMover>().Initialize(moveArea, gameData);
        var objBase = tempObj.GetComponent<ObjectBase>();
        int score = gameData.TargetScores.Find(x => x.Kind == objBase.Kind).Score;
        objBase.Initialize(score);
        objects.Add(tempObj);
    }
}

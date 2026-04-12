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
    private GameObject badObject; //reference to bad objects

    [SerializeField]
    private GameObject goodObject; //reference to good objects

    //list of all the objects currently in the scene
    public static List<GameObject> objects;

    //total score the player has obtained
    public static int totalScore = 0;

    private void Start()
    {
        objects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objects.Count == 0)
        {
            SpawnNewObject();
        }
    }

    /// <summary>
    /// Instantiates a new object on screen
    /// </summary>
    void SpawnNewObject()
    {
        //choose between good or bad object
        int coinflip = Random.Range(0, 2);

        //choose direction
        //0 is From Left To Right, 1 is From Right to Left, 2 is From Top to Bottom, 3 is from Bottom to Top
        int randomDir = Random.Range(0, 4);

        switch (coinflip)
        {
            //good object
            case 0:
                switch (randomDir)
                {
                    case 0:
                        GameObject tempGoodLR = Instantiate(goodObject, new Vector3(-4f, Random.Range(-4, 0) + 0.5f, 0f), Quaternion.identity); //spawns a new good obj at a random Y value between (-4, 4)
                        objects.Add(tempGoodLR);
                        break;
                    case 1:
                        GameObject tempGoodRL = Instantiate(goodObject, new Vector3(4f, Random.Range(-4, 0) + 0.5f, 0f), Quaternion.identity); //spawns a new good obj at a random Y value between (-4, 4)
                        objects.Add(tempGoodRL);
                        break;
                    case 2:
                        GameObject tempGoodTB = Instantiate(goodObject, new Vector3(Random.Range(-8, 8), 0f, 0f), Quaternion.identity);
                        objects.Add(tempGoodTB);
                        break;
                    case 3:
                        GameObject tempGoodBT = Instantiate(goodObject, new Vector3(Random.Range(-8, 8), -5f, 0f), Quaternion.identity);
                        objects.Add(tempGoodBT);
                        break;
                }
                break;
            //bad object
            case 1:
                switch (randomDir)
                {
                    case 0:
                        GameObject tempBadLR = Instantiate(badObject, new Vector3(-6f, Random.Range(-4, 0) + 0.5f, 0f), Quaternion.identity); //spawns a new bad obj at a random Y value between (-4, 4)
                        objects.Add(tempBadLR);
                        break;
                    case 1:
                        GameObject tempBadRL = Instantiate(badObject, new Vector3(6f, Random.Range(-4, 0) + 0.5f, 0f), Quaternion.identity); //spawns a new good obj at a random Y value between (-4, 4)
                        objects.Add(tempBadRL);
                        break;
                    case 2:
                        GameObject tempBadTB = Instantiate(badObject, new Vector3(Random.Range(-8, 8), 0f, 0f), Quaternion.identity);
                        objects.Add(tempBadTB);
                        break;
                    case 3:
                        GameObject tempBadBT = Instantiate(badObject, new Vector3(Random.Range(-8, 8), -5f, 0f), Quaternion.identity);
                        objects.Add(tempBadBT);
                        break;
                }
                break;
        }
    }
}

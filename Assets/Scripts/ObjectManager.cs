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

        switch (coinflip)
        {
            //good object
            case 0:
                GameObject tempGood = Instantiate(goodObject, new Vector3(-12f, Random.Range(-4, 4), 0f), Quaternion.identity); //spawns a new good obj at a random Y value between (-4, 4)
                objects.Add(tempGood);
                break;
            //bad object
            case 1:
                GameObject tempBad = Instantiate(badObject, new Vector3(-12f, Random.Range(-4, 4), 0f), Quaternion.identity); //spawns a new bad obj at a random Y value between (-4, 4)
                objects.Add(tempBad);
                break;
        }
    }
}

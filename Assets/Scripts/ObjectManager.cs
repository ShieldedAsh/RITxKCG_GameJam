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

    //total score the player has obtained
    public static int totalScore = 0;

    // Update is called once per frame
    void Update()
    {

    }
}

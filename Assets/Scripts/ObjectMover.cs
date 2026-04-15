using UnityEngine;

/*ObjectMover.cs
The purpose of this script is to move the objects behind the Shoji screen.
*/

enum Movement
{
    LeftRight,
    RightLeft,
    TopBottom,
    BottomTop
};

public class ObjectMover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb; //rigidbody ref

    private float movementSpeed;

    //The direction this object will be moving
    private Movement moveDir;

    //SpawnData
    private Vector2 spawnAreaLT;
    private Vector2 spawnAreaRB;

    public void Initialize(GameObject moveArea, GameData gameData)
    {
        Vector2 harfScale = moveArea.transform.localScale * 0.5f;
        spawnAreaLT = new(moveArea.transform.position.x - harfScale.x, moveArea.transform.position.y + harfScale.y);
        spawnAreaRB = new(moveArea.transform.position.x + harfScale.x, moveArea.transform.position.y - harfScale.y);

        if (transform.position.x <= spawnAreaLT.x)
        {
            moveDir = Movement.LeftRight;
        }
        else if (transform.position.x >= spawnAreaRB.x)
        {
            moveDir = Movement.RightLeft;
        }
        else if (transform.position.y >= spawnAreaLT.y)
        {
            moveDir = Movement.TopBottom;
        }
        else if (transform.position.y <= spawnAreaRB.y)
        {
            moveDir = Movement.BottomTop;
        }


        movementSpeed = Random.Range(gameData.TargetMinSpeed, gameData.TargetMaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        switch (moveDir)
        {
            case Movement.LeftRight:
                //destroy object if it is past despawn threshold
                if (transform.position.x >= spawnAreaRB.x + 0.5f)
                {
                    Destroy(this.gameObject);
                    ObjectManager.objects.Remove(this.gameObject);
                }

                //Move the object at a fixed rate
                rb.linearVelocityX = movementSpeed;
                break;
            case Movement.RightLeft:
                //destroy object if it is past despawn threshold
                if (transform.position.x <= spawnAreaLT.x - 0.5f)
                {
                    Destroy(this.gameObject);
                    ObjectManager.objects.Remove(this.gameObject);
                }

                //Move the object at a fixed rate
                rb.linearVelocityX = -movementSpeed;
                break;
            case Movement.TopBottom:
                //destroy object if it is past despawn threshold
                if (transform.position.y <= spawnAreaRB.y - 0.5f)
                {
                    Destroy(this.gameObject);
                    ObjectManager.objects.Remove(this.gameObject);
                }

                //Move the object at a fixed rate
                rb.linearVelocityY = -movementSpeed;
                break;
            case Movement.BottomTop:
                //destroy object if it is past despawn threshold
                if (transform.position.y >= spawnAreaLT.y + 0.5f)
                {
                    Destroy(this.gameObject);
                    ObjectManager.objects.Remove(this.gameObject);
                }

                //Move the object at a fixed rate
                rb.linearVelocityY = movementSpeed;
                break;
        }
    }
}

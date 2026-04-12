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

    [SerializeField]
    //value at which the object will despawn moving from Left to Right
    private int despawnThresholdLR = 4;

    [SerializeField]
    //value at which the object will despawn moving from Right to Left
    private int despawnThresholdRL = -4;

    [SerializeField]
    //value at which the object will despawn moving from Top to Bottom
    private int despawnThresholdTB = -5;

    [SerializeField]
    //value at which the object will despawn moving from Bottom to Top
    private int despawnThresholdBT = 0;

    [SerializeField]
    //the speed at which the object moves
    private float movementSpeed = 3f;

    //The direction this object will be moving
    private Movement moveDir;

    private void Start()
    {
        //sometimes objects spawn at y=5, i do not know why so i am forcing them to delete themselves
        if (transform.position.y == -5f)
        {
            ObjectManager.objects.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        
        if (transform.position.x <= -3.25f)
        {
            moveDir = Movement.LeftRight;
        }
        else if (transform.position.x >= 3.25f)
        {
            moveDir = Movement.RightLeft;
        }
        else if (transform.position.y >= -0.5f)
        {
            moveDir = Movement.TopBottom;
        }
        else if (transform.position.y <= -4.5)
        {
            moveDir = Movement.BottomTop;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (moveDir)
        {
            case Movement.LeftRight:
                //destroy object if it is past despawn threshold
                if (transform.position.x >= despawnThresholdLR)
                {
                    Destroy(this.gameObject);
                    ObjectManager.objects.Remove(this.gameObject);
                }

                //Move the object at a fixed rate
                rb.linearVelocityX = movementSpeed;
                break;
            case Movement.RightLeft:
                //destroy object if it is past despawn threshold
                if (transform.position.x <= despawnThresholdRL)
                {
                    Destroy(this.gameObject);
                    ObjectManager.objects.Remove(this.gameObject);
                }

                //Move the object at a fixed rate
                rb.linearVelocityX = -movementSpeed;
                break;
            case Movement.TopBottom:
                //destroy object if it is past despawn threshold
                if (transform.position.y <= despawnThresholdTB)
                {
                    Destroy(this.gameObject);
                    ObjectManager.objects.Remove(this.gameObject);
                }

                //Move the object at a fixed rate
                rb.linearVelocityY = -movementSpeed;
                break;
            case Movement.BottomTop:
                //destroy object if it is past despawn threshold
                if (transform.position.y >= despawnThresholdTB)
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

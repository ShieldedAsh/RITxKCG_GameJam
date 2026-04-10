using UnityEngine;

/*ObjectMover.cs
The purpose of this script is to move the objects behind the Shoji screen.
*/
public class ObjectMover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb; //rigidbody ref

    [SerializeField]
    //value at which the object will despawn
    //Note: this implementation assumes objects can only move from left to right, could potentially be refactored later
    //to allow for right to left movement.
    private int despawnThreshold = 20;

    [SerializeField]
    //the speed at which the object moves
    private float movementSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        //destroy object if it is past despawn threshold
        if (transform.position.x >= despawnThreshold)
        {
            Destroy(this.gameObject);
            ObjectManager.objects.Remove(this.gameObject);
        }

        //Move the object at a fixed rate
        rb.linearVelocityX = movementSpeed;
    }
}

using UnityEngine;


//INHERITANCE
public class Onion : Target
{
    private int numOfClicks;

// POLYMORPHISM
    protected override void OnEnable()
    {
        transform.localScale = new Vector3 (0.4f, 0.4f, 1);
        numOfClicks = 3;
        base.OnEnable();
    }
//POLYMORPHISM
    protected override void OnMouseDown()
    {
        numOfClicks--;
        if (numOfClicks > 0)
        {
        targetRb.velocity = new Vector2(targetRb.velocity.x * -0.9f, 5f);
        transform.localScale *= 0.8f;
        }
        else
        {
            base.OnMouseDown();
        }
    }

}

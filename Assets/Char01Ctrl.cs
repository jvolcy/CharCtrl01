using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is an example of the simplest of character controllers.  This controller
 * uses 3 keys: the left, right and up arrows.  The left arrow causes the
 * character to rotate 90 degrees CCW.  The right arrow causes the character
 * to rotate 90 degrees CW.  The up arrow is used to move the player forward
 * in whatever direction it is currently pointing.
 * The controller contains only 3 animations: turn left, turn right and walk.
 * Note that the root animation for the walk animation must be enabled.
 */
public class Char01Ctrl : MonoBehaviour
{
    //create a variable to reference the animator component
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //get a reference to the Animator component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //if the user presses the right arrow, trigger the "right turn" (cw) animation
            animator.SetTrigger("TurnRight");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //if the user presses the left arrow, trigger the "left turn" (ccw) animation
            animator.SetTrigger("TurnLeft");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //if the user presses the up arrow, set the Animator's "Walking" boolean parameter to true
            animator.SetBool("Walking", true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            //when the user releases the up arrow, set the Animator's "Walking" boolean parameter to false
            animator.SetBool("Walking", false);
        }

    }
}

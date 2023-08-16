using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMovement : MonoBehaviour
{
    [SerializeField] private ConfigurableJoint CraneArmExtend;
    [SerializeField] private Rigidbody CraneArmExtendRB;
    [SerializeField] private Transform CraneArmExtendTransform;
    [SerializeField] private float ExtendForceUp;
    [SerializeField] private float ExtendForceDown;
    [SerializeField] private float MinDistanceToUpPosition_CraneArmExtend;
    [Space(20)]
    [SerializeField] private Animator ClawAnimator;

    private bool isUp;
    private bool craneArmExtendHasReachedUp;
    private Vector3 craneArmExtendUpPosition;
    // Start is called before the first frame update
    void Start()
    {
        isUp = true;
        craneArmExtendHasReachedUp = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) == true)
        {
            if(isUp == true)
            {
                Start_CraneArmExtend_GoDown();
            }
            else
            {
                Start_CraneArmExtend_GoUp();
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            /*
            if(ClawAnimator.GetBool("CurrentOpenStatus") == true)
            {
                ClawAnimator.SetBool("CurrentOpenStatus", false);
            }
            else
            {
                ClawAnimator.SetBool("CurrentOpenStatus", true);
            }
            */

            if(ClawAnimator.GetBool("NewOpenStatus") == true)
            {
                ClawAnimator.SetBool("NewOpenStatus", false);
            }
            else
            {
                ClawAnimator.SetBool("NewOpenStatus", true);
            }


        }
    }

    private void Start_CraneArmExtend_GoUp()
    {
        //Enable movement on crane arm extend
        CraneArmExtend.yMotion = ConfigurableJointMotion.Free;
        //Set crane arm extend reached up status
        craneArmExtendHasReachedUp = false;
        //Arm is going up
        isUp = true;
    }

    private void Start_CraneArmExtend_GoDown()
    {
        //Enable movement on crane arm extend
        CraneArmExtend.yMotion = ConfigurableJointMotion.Free;
        //Record up position of crane arm extend
        craneArmExtendUpPosition = CraneArmExtendRB.transform.position;
        //Arm is going down
        isUp = false;
    }

    private void FixedUpdate()
    {
        if(isUp == false)
        {
            //Send crane arm extend down
            CraneArmExtendRB.AddForce(Vector3.down * ExtendForceDown);
        }
        else if(isUp == true && craneArmExtendHasReachedUp == false)
        {
            //Send crane arm extend back up until it reaches the up position
            float craneArmExtendYDistance = Mathf.Abs(CraneArmExtendTransform.position.y - craneArmExtendUpPosition.y);
            if(craneArmExtendYDistance > MinDistanceToUpPosition_CraneArmExtend)
            {
                Debug.LogWarning("Not reached up yet. Current Y distance: " + craneArmExtendYDistance);
                CraneArmExtendRB.AddForce(Vector3.up * ExtendForceUp);
            }
            else
            {
                //CraneArmExtend has reached the up position
                Debug.LogWarning("Crane arm extend has reached up pos");
                craneArmExtendHasReachedUp = true;
                Disable_CraneArmExtend_Movement();
            }
        }


    }

    private void Disable_CraneArmExtend_Movement()
    {
        //Enable movement on crane arm extend
        CraneArmExtend.yMotion = ConfigurableJointMotion.Limited;
    }
}

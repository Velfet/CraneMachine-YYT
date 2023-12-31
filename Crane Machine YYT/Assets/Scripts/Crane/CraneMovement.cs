using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CraneMovement : MonoBehaviour
{
    [SerializeField] private CongratulationsPanel CongratulationsPanel;
    [Space(20)]
    [SerializeField] private FoodItemSpawner FoodItemSpawner;
    [Space(20)]
    [SerializeField] private CameraShift CameraShift;
    [SerializeField] private MyEnum.CameraPositionStatus CurrentCameraPositionStatus;
    [Space(20)]
    [SerializeField] private MyEnum.CraneClawState CurrentCraneClawState;
    [SerializeField] private MyEnum.CraneExtendStatus CurrentCraneExtendStatus;
    [Space(20)]
    [SerializeField] private float CraneMoveForce;
    [SerializeField] private Transform CraneBaseTransform;
    [SerializeField] private Rigidbody CraneBaseRB;
    [SerializeField] private float CraneXMoveLimit;
    [SerializeField] private float CraneZMoveLimit;
    [Space(20)]
    [SerializeField] private ConfigurableJoint CraneArmExtendJoint;
    [SerializeField] private Rigidbody CraneGrabberBaseRB;
    [SerializeField] private Rigidbody CraneArmExtendRB;
    [SerializeField] private Transform CraneArmExtendTransform;
    [SerializeField] private float ExtendForceUp;
    [SerializeField] private float ExtendForceDown;
    [SerializeField] private float MaxExtendDistance;
    [SerializeField] private float MinDistanceToUpPosition_CraneArmExtend;
    [Space(20)]
    [SerializeField] private float CraneClawCloseDuration;
    [SerializeField] private float CraneClawOpenDuration;
    [Space(20)]
    [SerializeField] private Animator ClawAnimator;
    [Space(20)]
    [SerializeField] private List<GameObject> FoodObjects;

    //private bool isUp;
    //private bool craneArmExtendHasReachedUp;
    private GameStatusManager gameStatusManager;
    public AudioManager audioManager;
    private Vector3 craneArmExtendUpPosition;
    private float craneArmExtendYDistance;

    private CraneControls CraneControls;
    private Vector3 CraneMoveVector;
    private Vector3 NewCraneBasePos;
    private Vector3 NewCraneBaseVelocity;

    private IEnumerator CraneClawCloseRoutine;
    private IEnumerator CraneClawOpenRoutine;

    private void Awake()
    {
        CraneControls = new CraneControls();
        CraneControls.Crane_Actions.Enable();

        CraneControls.Crane_Actions.Drop_Crane.performed += DropCraneArm;
        CraneControls.Crane_Actions.Move_Camera_Left.performed += ShiftCameraLeft;
        CraneControls.Crane_Actions.Move_Camera_Right.performed += ShiftCameraRight;
        CraneControls.Crane_Actions.Respawn_FoodItems.performed += RespawnFoodItems;
        CraneControls.Crane_Actions.ExitGame.performed += ExitGame;
    }

    // Start is called before the first frame update
    private void Start()
    {
        GetReferences();
        CurrentCraneClawState = MyEnum.CraneClawState.Open;
        CurrentCraneExtendStatus = MyEnum.CraneExtendStatus.Up;
        //craneArmExtendHasReachedUp = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if(CurrentCraneClawState == MyEnum.CraneClawState.Open && CurrentCraneExtendStatus == MyEnum.CraneExtendStatus.Up)
        {
            //Crane can accept player input
            CraneMoveVector = CraneControls.Crane_Actions.Movement.ReadValue<Vector2>();
            CraneMoveVector.z = CraneMoveVector.y;
            CraneMoveVector.y = 0f;

            //Rotate move vector depending on the camera's position
            if(CurrentCameraPositionStatus == MyEnum.CameraPositionStatus.Left)
            {
                CraneMoveVector = Quaternion.AngleAxis(90f, Vector3.up) * CraneMoveVector;
            }
            else if(CurrentCameraPositionStatus == MyEnum.CameraPositionStatus.Right)
            {
                CraneMoveVector = Quaternion.AngleAxis(-90f, Vector3.up) * CraneMoveVector;
            }
        }
        else
        {
            CraneMoveVector = Vector3.zero;
        }

        /*
        if(Input.GetKeyDown(KeyCode.Space) == true)
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
        */
        /*
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            
            //if(ClawAnimator.GetBool("CurrentOpenStatus") == true)
            //{
            //    ClawAnimator.SetBool("CurrentOpenStatus", false);
            //}
            //else
            //{
            //    ClawAnimator.SetBool("CurrentOpenStatus", true);
            //}
            

            if(ClawAnimator.GetBool("NewOpenStatus") == true)
            {
                ClawAnimator.SetBool("NewOpenStatus", false);
            }
            else
            {
                ClawAnimator.SetBool("NewOpenStatus", true);
            }


        }
        */
    }

    private void FixedUpdate()
    {
        if(CurrentCraneClawState == MyEnum.CraneClawState.Open && CurrentCraneExtendStatus == MyEnum.CraneExtendStatus.Up)
        {
            //Crane can move
            if(CraneMoveVector != Vector3.zero)
            {
                //Move the crane
                CraneBaseTransform.Translate(CraneMoveVector * CraneMoveForce * Time.deltaTime);

                //Play crane move SFX
                audioManager.PlaySFX_Loop(MyEnum.Sound_SFX.CraneMove);

                //Check if crane has moved beyond the limits of the crane machine
                NewCraneBasePos =  CraneBaseTransform.position;
                if(CraneBaseTransform.position.x > CraneXMoveLimit)
                {
                    NewCraneBasePos.x = CraneXMoveLimit;
                }
                else if(CraneBaseTransform.position.x < -CraneXMoveLimit)
                {
                    NewCraneBasePos.x = -CraneXMoveLimit;
                }

                if(CraneBaseTransform.position.z > CraneZMoveLimit)
                {
                    NewCraneBasePos.z = CraneZMoveLimit;
                }
                else if(CraneBaseTransform.position.z < -CraneZMoveLimit)
                {
                    NewCraneBasePos.z = -CraneZMoveLimit;
                }

                //Move the crane if it has moved beyond the movement limits
                if(NewCraneBasePos != CraneBaseTransform.position)
                {
                    //Debug.LogWarning("Correcting position");
                    CraneBaseTransform.position = NewCraneBasePos;

                }
            }
            else
            {
                //Stop crane move SFX
                audioManager.StopSFX_Loop();
            }
        }
        
        if(CurrentCraneExtendStatus == MyEnum.CraneExtendStatus.Going_Down)
        {
            //Send crane arm extend down
            CraneArmExtendRB.AddForce(Vector3.down * ExtendForceDown);

            if(Mathf.Abs(CraneArmExtendTransform.position.y) > MaxExtendDistance)
            {
                //Crane arm has extended down all the way
                CraneExtendFinished();
            }
        }
        //old ver: else if(CurrentCraneExtendStatus == MyEnum.CraneExtendStatus.Going_Up && craneArmExtendHasReachedUp == false)
        else if(CurrentCraneExtendStatus == MyEnum.CraneExtendStatus.Going_Up)
        {   
            //To be deleted
            CraneArmExtendRB.constraints = RigidbodyConstraints.None;
            CraneGrabberBaseRB.useGravity = true;

            //Send crane arm extend back up until it reaches the up position
            craneArmExtendYDistance = Mathf.Abs(CraneArmExtendTransform.position.y - craneArmExtendUpPosition.y);
            if(craneArmExtendYDistance > MinDistanceToUpPosition_CraneArmExtend)
            {
                //Debug.LogWarning("Not reached up yet. Current Y distance: " + craneArmExtendYDistance);
                //CraneArmExtendRB.AddForce(Vector3.up * ExtendForceUp);
                CraneArmExtendRB.velocity = Vector3.up * ExtendForceUp;
            }
            else
            {
                //CraneArmExtend has reached the up position
                //Stop crane unextend sfx
                audioManager.StopSFX_Loop();
                //Debug.LogWarning("Crane arm extend has reached up position");
                CurrentCraneExtendStatus = MyEnum.CraneExtendStatus.Up;
                Disable_CraneArmExtend_Movement();
                CheckCraneClawItems();
            }
        }
        else if(CurrentCraneExtendStatus == MyEnum.CraneExtendStatus.Down && CurrentCraneClawState != MyEnum.CraneClawState.Closing)
        {
            //CraneArmExtendRB.constraints = RigidbodyConstraints.FreezePositionY;
            //CraneGrabberBaseRB.constraints = RigidbodyConstraints.None;
            //CraneArmExtendRB.velocity = Vector3.zero;
            //CraneGrabberBaseRB.velocity = Vector3.zero;

            //Crane has been extended, begin to close the claw
            Start_CraneClaw_Close();
        }
        


    }

    private void CraneExtendFinished()
    {
        //Crane arm has finished extending down
        //Stop crane extend sfx
        audioManager.StopSFX_Loop();
        //Debug.LogWarning("Y pos: " + CraneArmExtendTransform.position.y);
        CurrentCraneExtendStatus = MyEnum.CraneExtendStatus.Down;
        CraneArmExtendRB.constraints = RigidbodyConstraints.FreezePositionY;
        CraneGrabberBaseRB.useGravity = false;
        //craneArmExtendHasReachedUp = false;
    }

    private void DropCraneArm(InputAction.CallbackContext context)
    {
        if(CurrentCraneClawState == MyEnum.CraneClawState.Open && CurrentCraneExtendStatus == MyEnum.CraneExtendStatus.Up)
        {
            //Stop crane move sfx
            audioManager.StopSFX_Loop();
            //Play crane extend sfx
            audioManager.PlaySFX_Loop(MyEnum.Sound_SFX.CraneExtendOrUnextend);
            //Crane is in open state and is not extended, can drop the crane arm
            Start_CraneArmExtend_GoDown();
        }
    }


    /*
    private void Start_CraneArmExtend_GoUp()
    {
        //Enable movement on crane arm extend
        CraneArmExtendJoint.yMotion = ConfigurableJointMotion.Free;
        //Set crane arm extend reached up status
        //craneArmExtendHasReachedUp = false;
        //Arm is going up
        CurrentCraneExtendStatus = MyEnum.CraneExtendStatus.Going_Up;
    }
    */

    private void Start_CraneArmExtend_GoDown()
    {
        //Enable movement on crane arm extend
        CraneArmExtendJoint.yMotion = ConfigurableJointMotion.Free;
        //Record up position of crane arm extend
        craneArmExtendUpPosition = CraneArmExtendTransform.position;
        //Arm is going down
        CurrentCraneExtendStatus = MyEnum.CraneExtendStatus.Going_Down;
    }

    private void Start_CraneClaw_Close()
    {
        //Play close claw sfx
        audioManager.PlayOneShot(MyEnum.Sound_SFX.ClawOpenOrClose);
        //Close the claw
        if(CraneClawCloseRoutine != null)
        {
            CraneClawCloseRoutine = null;
        }
        CraneClawCloseRoutine = CloseCraneClaw();
        StartCoroutine(CraneClawCloseRoutine);
    }

    private void Start_CraneClaw_Open()
    {
        //Play open claw sfx
        audioManager.PlayOneShot(MyEnum.Sound_SFX.ClawOpenOrClose);
        //Open the claw
        if(CraneClawOpenRoutine != null)
        {
            CraneClawOpenRoutine = null;
        }
        CraneClawOpenRoutine = OpenCraneClaw();
        StartCoroutine(CraneClawOpenRoutine);
    }

    private IEnumerator CloseCraneClaw()
    {
        //Close the claw
        CurrentCraneClawState = MyEnum.CraneClawState.Closing;
        ClawAnimator.SetBool("NewOpenStatus", false);

        float time = 0f;

        while(time < CraneClawCloseDuration)
        {
            yield return null;
            time += Time.deltaTime;
        }

        //Claw has been closed, send the crane up
        CurrentCraneClawState = MyEnum.CraneClawState.Close;
        CurrentCraneExtendStatus = MyEnum.CraneExtendStatus.Going_Up;
        //Play crane unextend sfx
        audioManager.PlaySFX_Loop(MyEnum.Sound_SFX.CraneExtendOrUnextend);
    }

    private IEnumerator OpenCraneClaw()
    {
        //Open the claw
        CurrentCraneClawState = MyEnum.CraneClawState.Opening;
        ClawAnimator.SetBool("NewOpenStatus", true);

        float time = 0f;

        while(time < CraneClawOpenDuration)
        {
            yield return null;
            time += Time.deltaTime;
        }

        //Claw has been opened
        CurrentCraneClawState = MyEnum.CraneClawState.Open;
    }

    private void Disable_CraneArmExtend_Movement()
    {
        //Disable movement on crane arm extend
        CraneArmExtendJoint.yMotion = ConfigurableJointMotion.Limited;
    }

    private void CheckCraneClawItems()
    {
        //Check if the claw has grabbed any items
        if(FoodObjects.Count > 0)
        {
            //Claw has grabbed at least 1 item
            for(int i = 0; i < FoodObjects.Count; i++)
            {
                //Add score from food iem to score
                FoodItem foodItem = FoodObjects[i].GetComponent<FoodItem>();
                gameStatusManager.UpdateScore(foodItem.GetFoodScoreValue());
                //Remove food item
                RemoveFoodObject(FoodObjects[i]);
                //Return food item to pooler
                foodItem.ReturnFoodItem();
            }

            //Do some kind of UI celebration here
            //Play congratulations sfx
            audioManager.PlayOneShot(MyEnum.Sound_SFX.Congratulations);
            CongratulationsPanel.BeginCongratulation_Start();
        }
        
        //Open the claw after checking (probably only temporary)
        Start_CraneClaw_Open();
    }

    public void AddFoodObject(GameObject theFood)
    {
        //Add the food if it is not already on the list
        if(FoodObjects.Contains(theFood) == false)
        {
            FoodObjects.Add(theFood);            
        }
    }

    public void RemoveFoodObject(GameObject theFood)
    {
        //Remove the food if it is on the list
        if(FoodObjects.Contains(theFood) == true)
        {
            FoodObjects.Remove(theFood);
        }
    }

    public void CraneExtendFinishedMidway()
    {
        //Crane extension was interrupted
        if(CurrentCraneExtendStatus == MyEnum.CraneExtendStatus.Going_Down)
        {
            CraneExtendFinished();
        }
    }

    private void ShiftCameraLeft(InputAction.CallbackContext context)
    {
        if(CurrentCameraPositionStatus == MyEnum.CameraPositionStatus.Middle)
        {
            CameraShift.ShiftCameraToLeft();
            CurrentCameraPositionStatus = MyEnum.CameraPositionStatus.Left;
        }
        else if(CurrentCameraPositionStatus == MyEnum.CameraPositionStatus.Right)
        {
            CameraShift.ShiftCameraToMiddle();
            CurrentCameraPositionStatus = MyEnum.CameraPositionStatus.Middle;
        }
    }

    private void ShiftCameraRight(InputAction.CallbackContext context)
    {
        if(CurrentCameraPositionStatus == MyEnum.CameraPositionStatus.Middle)
        {
            CameraShift.ShiftCameraToRight();
            CurrentCameraPositionStatus = MyEnum.CameraPositionStatus.Right;
        }
        else if(CurrentCameraPositionStatus == MyEnum.CameraPositionStatus.Left)
        {
            CameraShift.ShiftCameraToMiddle();
            CurrentCameraPositionStatus = MyEnum.CameraPositionStatus.Middle;
        }
    }

    private void RespawnFoodItems(InputAction.CallbackContext context)
    {
        //Empty the food objects list
        FoodObjects.Clear();
        //Note: for longer lists, if you want to empty them, use .Clear() and then use .TrimExcess() because if you don't use TrimExcess(), the capacity of the list
        //will remain the same as the capacity of the list before you cleared it. Because this list will only have around 1-3 elements, it should be fine not to use TrimExcess()

        //Respawn the food items
        FoodItemSpawner.RespawnFoodItems();
    }

    private void ExitGame(InputAction.CallbackContext context)
    {
        gameStatusManager.ExitGame();
    }

    private void GetReferences()
    {
        if(gameStatusManager == null)
        {
            gameStatusManager = GameStatusManager.GetInstance();
        }

        if(audioManager == null)
        {
            audioManager = AudioManager.audioManager;
        }
    }
}

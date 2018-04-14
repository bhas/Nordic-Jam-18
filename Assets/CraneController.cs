using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour {

    public GameObject Arm;
    public GameObject ArmExtension;
    public GameObject Base;
    public SpringJoint Joint;
    public AnchorPointAligner AnchorPointAligner;

    [Header("Arm control")]
    public float ArmRiseSpeed;
    public float ArmExtendSpeed;

    [Header("Crane control")]
    public float CraneTurnSpeed;
    public float CraneSpeed;

    [Header("Base control")]
    public float BaseTurnSpeed;
    public float CableSpeed;

    void Start () {
		
	}
	
	void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            TurnCrane(false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            TurnCrane(true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            TurnBase(false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            TurnBase(true);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Accelerate();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Decelerate();
        }

        if (Input.GetKey(KeyCode.W))
        {
            RiseArm();
        }

        if (Input.GetKey(KeyCode.S))
        {
            LowerArm();
        }

        if (Input.GetKey(KeyCode.E))
        {
            ExtendArm();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            RetractArm();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            RetractArm();
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            ExtendCable();
        }

        if (Input.GetKey(KeyCode.Minus))
        {
            RetractCable();
        }
    }

    #region Arm

    private void ExtendArm()
    {
        if(ArmExtension.transform.localPosition.z < 4.8)
            ArmExtension.transform.Translate(Vector3.forward * ArmExtendSpeed);
    }

    private void RetractArm()
    {
        if (ArmExtension.transform.localPosition.z > 0)
            ArmExtension.transform.Translate(Vector3.back * ArmExtendSpeed);
    }

    private void RiseArm()
    {
        if(Arm.transform.localRotation.eulerAngles.x > 30)
            Arm.transform.Rotate(Vector3.left, ArmRiseSpeed);
    }

    private void LowerArm()
    {
        if (Arm.transform.localRotation.eulerAngles.x < 70)
            Arm.transform.Rotate(Vector3.left, -ArmRiseSpeed);
    }

    private void TurnBase(bool clockwise)
    {
        Base.transform.Rotate(Vector3.forward, BaseTurnSpeed * (clockwise ? 1 : -1));
    }

    #endregion

    private void ExtendCable()
    {
        if (AnchorPointAligner.Distance < 6.5)
        {
            AnchorPointAligner.Distance += CableSpeed;
        }
    }

    private void RetractCable()
    {
        if(AnchorPointAligner.Distance > 1)
        {
            AnchorPointAligner.Distance -= CableSpeed;
        }
    }

    private void TurnCrane(bool clockwise)
    {
        gameObject.transform.Rotate(Vector3.up, CraneTurnSpeed * (clockwise ? 1 : -1));
    }

    private void Accelerate()
    {
        gameObject.transform.Translate(Vector3.forward * CraneSpeed);
    }

    private void Decelerate()
    {
        gameObject.transform.Translate(Vector3.back * CraneSpeed);
    }
}

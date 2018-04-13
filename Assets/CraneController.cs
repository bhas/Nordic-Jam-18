using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour {

    public GameObject Arm;
    public GameObject ArmExtension;
    public GameObject Base;
    public GameObject Crane;

    [Header("Arm control")]
    public float ArmRiseSpeed;
    public float ArmExtendSpeed;

    [Header("Crane control")]
    public float CraneTurnSpeed;
    public float CraneSpeed;

    [Header("Base control")]
    public float BaseTurnSpeed;

    void Start () {
		
	}
	
	void Update ()
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
            Decelerate();
        }
    }

    #region Arm

    private void ExtendArm()
    {
        ArmExtension.transform.Translate(Vector3.forward);
    }

    private void RetractArm()
    {
        ArmExtension.transform.Translate(Vector3.back);
    }

    private void RiseArm()
    {
        Arm.transform.Rotate(Vector3.left, ArmRiseSpeed);
    }

    private void LowerArm()
    {
        Arm.transform.Rotate(Vector3.left, -ArmRiseSpeed);
    }

    private void TurnBase(bool clockwise)
    {
        Base.transform.Rotate(Vector3.forward, BaseTurnSpeed * (clockwise ? 1 : -1));
    }

    #endregion

    private void ExtendCable()
    {

    }

    private void RetractCable()
    {

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

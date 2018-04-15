using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{

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


    public ParticleSystem PSFrontRight;
    public ParticleSystem PSFrontLeft;
    public ParticleSystem PSBackRight;
    public ParticleSystem PSBackLeft;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            TurnCrane(false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            TurnCrane(true);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Accelerate();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Decelerate();
        }

        if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            print("Stopping");
            SoundController.Instance.TrunkPitch(1);
        }



        if (Input.GetKey(KeyCode.A))
        {
            TurnBase(false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            TurnBase(true);
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
        if (ArmExtension.transform.localPosition.z < 4.8)
            ArmExtension.transform.Translate(Vector3.forward * ArmExtendSpeed * Time.timeScale);
    }

    private void RetractArm()
    {
        if (ArmExtension.transform.localPosition.z > 0)
            ArmExtension.transform.Translate(Vector3.back * ArmExtendSpeed * Time.timeScale);
    }

    private void RiseArm()
    {
        if (Arm.transform.localRotation.eulerAngles.x > 30)
            Arm.transform.Rotate(Vector3.left, ArmRiseSpeed * Time.timeScale);
    }

    private void LowerArm()
    {
        if (Arm.transform.localRotation.eulerAngles.x < 70)
            Arm.transform.Rotate(Vector3.left, -ArmRiseSpeed * Time.timeScale);
    }

    private void TurnBase(bool clockwise)
    {
        Base.transform.Rotate(Vector3.forward, BaseTurnSpeed * (clockwise ? 1 : -1) * Time.timeScale);
    }

    #endregion

    private void ExtendCable()
    {
        if (AnchorPointAligner.Distance < 12)
        {
            AnchorPointAligner.Distance += CableSpeed;
        }
    }

    private void RetractCable()
    {
        if (AnchorPointAligner.Distance > 4)
        {
            AnchorPointAligner.Distance -= CableSpeed;
        }
    }

    private void TurnCrane(bool clockwise)
    {
        //if (clockwise)
        //{
        //    PSFrontRight.Play();
        //    PSBackLeft.Play();
        //    PSBackRight.Stop();
        //    PSFrontLeft.Stop();
        //}
        //else
        //{
        //    PSFrontRight.Stop();
        //    PSBackLeft.Stop();
        //    PSBackRight.Play();
        //    PSFrontLeft.Play();
        //}

        gameObject.transform.Rotate(Vector3.up, CraneTurnSpeed * (clockwise ? 1 : -1) * Time.timeScale);
    }

    private void Accelerate()
    {
        //PSBackRight.Play();
        //PSBackLeft.Play();

        //PSFrontRight.Stop();
        //PSFrontLeft.Stop();
        SoundController.Instance.TrunkPitch(1.5);
        //gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.forward * CraneSpeed, ForceMode.VelocityChange);
        gameObject.transform.Translate(Vector3.forward * CraneSpeed * Time.timeScale);
    }

    private void Decelerate()
    {
        //PSBackRight.Stop();
        //PSBackLeft.Stop();

        //PSFrontRight.Play();
        //PSFrontLeft.Play();

        SoundController.Instance.TrunkPitch(1.5);

        //gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.back * CraneSpeed, ForceMode.VelocityChange);
        gameObject.transform.Translate(Vector3.back * CraneSpeed * Time.timeScale);
    }
}

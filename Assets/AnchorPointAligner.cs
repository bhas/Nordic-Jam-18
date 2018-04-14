using UnityEngine;

public class AnchorPointAligner : MonoBehaviour
{
    public Transform AnchorLocator;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.transform.position = AnchorLocator.position;
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, AnchorLocator.rotation.eulerAngles.y, 0));
    }
}

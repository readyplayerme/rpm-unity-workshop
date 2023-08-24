using UnityEngine;

public class DisguiseConnector : MonoBehaviour
{
    private void OnEnable()
    {
        Transform t = transform;
        Transform headTop = GameObject.Find("HeadTop_End").transform.parent;
        t.SetParent(headTop);
        t.localPosition = new Vector3(0, 0.1f, 0.12f);
        t.localRotation = Quaternion.identity;
    }
}

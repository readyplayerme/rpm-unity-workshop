using UnityEngine;
using System.Collections;

public class DisguiseConnector : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(EnableGlasses());
    }

    private IEnumerator EnableGlasses()
    {
        GameObject headEnd = GameObject.Find("HeadTop_End");
        
        if (headEnd != null)
        {
            Transform t = transform;
            Transform head = headEnd.transform.parent;
            t.SetParent(head);
            t.localPosition = new Vector3(0, 0.1f, 0.12f);
            t.localRotation = Quaternion.identity;
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            
            StartCoroutine(EnableGlasses());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("EndLevelTrigger"))
        {
            GameObject.Destroy(other.transform.parent.gameObject);
        }
    }
}

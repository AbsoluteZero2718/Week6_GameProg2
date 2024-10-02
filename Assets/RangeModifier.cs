using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class RangeModifier : MonoBehaviour
{
    public Transform enemyPos;
    public float distance;
    public float rangeRadius;
    public float raycastLength;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public async void SendMessage()
    {
        await Task.Delay(5000);
        Debug.Log("HEWWO (OwO)");
    }
    void Update()
    {
        distance = Vector3.Distance(transform.position, enemyPos.position);
        if (distance <= rangeRadius)
        {
            transform.LookAt(enemyPos);
        }
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLength, layer))
        {
            Debug.Log("[WALL DETECTED]");
        }
        else
        {
            Debug.Log("[WALL MISSING]");
        }
        Debug.DrawRay(transform.position, transform.forward * raycastLength, Color.yellow);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
       
    }
}

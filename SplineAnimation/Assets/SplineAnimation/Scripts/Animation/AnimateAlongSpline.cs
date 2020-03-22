using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateAlongSpline : MonoBehaviour
{

    public Transform[] _electrodes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FooBob()
    {
        Debug.Log("Bob");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for(int i=0; i<_electrodes.Length-1; i++)
        {
            Gizmos.DrawLine(_electrodes[i].position, _electrodes[i + 1].position);
        }
    }
}

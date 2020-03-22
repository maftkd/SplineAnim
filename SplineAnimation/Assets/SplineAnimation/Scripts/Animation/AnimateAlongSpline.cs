using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateAlongSpline : MonoBehaviour
{

    public Transform[] _electrodes;
    public float _curveScale = 1f;
    public int _segmentResolution = 5;
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

        Vector3[] midpoints = new Vector3[_electrodes.Length - 1];
        Vector3[] controlPoints = new Vector3[_electrodes.Length - 1];
        for(int i=0; i<_electrodes.Length-1; i++)
        {
            Gizmos.color = Color.red;
            //Gizmos.DrawLine(_electrodes[i].position, _electrodes[i + 1].position);

            midpoints[i] = Vector3.Lerp(_electrodes[i].position, _electrodes[i + 1].position, .5f);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(midpoints[i], .125f);

            
            if(i < _electrodes.Length -1)
            {
                //calc and draw control points
                if(i<_electrodes.Length -2)
                    controlPoints[i] = midpoints[i] - (_electrodes[i + 2].position - _electrodes[i + 1].position - (_electrodes[i + 1].position - _electrodes[i].position)) * _curveScale;
                else
                    controlPoints[i] = midpoints[i];
                Gizmos.color = Color.white;
                Gizmos.DrawSphere(controlPoints[i], .0625f);

                //calc and draw spline points
                Gizmos.color = Color.black;
                for (int j = 0; j < _segmentResolution; j++)
                {
                    float lerpVal = (float)j / (float)_segmentResolution;
                    Vector3 pointA = Vector3.Lerp(_electrodes[i].position, controlPoints[i], lerpVal);
                    Vector3 pointB = Vector3.Lerp(controlPoints[i], _electrodes[i + 1].position, lerpVal);
                    Gizmos.DrawSphere(Vector3.Lerp(pointA, pointB, lerpVal), .03125f);
                }
            }          


            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(_electrodes[i].position, .015625f);           

            
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_electrodes[_electrodes.Length - 1].position, .015625f);
    }
}

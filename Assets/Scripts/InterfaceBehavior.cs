using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceBehavior : MonoBehaviour
{

    public GameObject pointer;
    private LineRenderer lineRenderer;
    public GameObject dot;
    // Use this for initialization
    void Start()
    {
        //pointer.AddComponent(LineRenderer);
        //pointer.GetComponent<LineRenderer>().SerVertexCount(0);
        lineRenderer = pointer.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.startColor = Color.red;
        lineRenderer.widthMultiplier = 0.02f;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, pointer.transform.position);
        lineRenderer.SetPosition(1, pointer.transform.position + pointer.transform.forward * 10.0f);
    }

    // Update is called once per frame
    //void Update () {

    //}
    public float distance = 500.0f;
    //replace Update method in your class with this one
    void Update()
    {
        lineRenderer.SetPosition(0, pointer.transform.position);
        lineRenderer.SetPosition(1, pointer.transform.position + pointer.transform.forward * 10.0f);
        //if mouse button (left hand side) pressed instantiate a raycast
        //if (Input.GetMouseButtonDown(0))
        {
            //create a ray cast and set it to the mouses cursor position in game
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(pointer.transform.position, pointer.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance))
            {
                //draw invisible ray cast/vector
                //Debug.DrawLine(ray.origin, hit.point, Color.red, 2);
                //log hit area to the console
                Debug.Log("world" + hit.point);
                vertexMover(hit.collider.gameObject, hit.point);
                lineRenderer.SetPosition(1, hit.point);
                dot.SetActive(true);
                float distance = hit.distance;
                dot.transform.position = hit.point;
                float scaleY = (distance - 0.1f) > 0 ? 0.0f : -1.0f * (distance - 0.1f);
                dot.transform.localScale = new Vector3(dot.transform.localScale.x, scaleY, dot.transform.localScale.z);
                //Debug.Log(hit.collider.gameObject.Name);

            }
            else
            {
                dot.SetActive(false);
            }
        }
    }

    void vertexMover(GameObject obj, Vector3 point)
    {
        Vector3 objRelative = obj.transform.InverseTransformPoint(point);
        Debug.Log("local" + objRelative);

    }
}

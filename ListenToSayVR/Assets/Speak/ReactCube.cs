using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Rotate());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetScale(float scale)
    {
        transform.localScale = new Vector3(1, 1, 1) * (scale + 0.3f);
    }

    IEnumerator Rotate()
    {
        Vector3 rot = new Vector3(
            Random.Range(3, 7),
            Random.Range(3, 7),
            Random.Range(3, 7));

        while (true)
        {
            transform.Rotate(rot);
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugKey : MonoBehaviour
{

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            SceneReset();
	}

    void SceneReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

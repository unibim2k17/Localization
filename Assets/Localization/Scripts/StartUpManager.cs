using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUpManager : MonoBehaviour {

	private IEnumerator Start () {
        while (!LocalizationManager.instance.GetISReady())
        {
            yield return null;
        }

        SceneManager.LoadScene("Menu");
	}
	
	
}

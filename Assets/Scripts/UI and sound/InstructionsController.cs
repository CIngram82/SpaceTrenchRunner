using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsController : MonoBehaviour {

    public GameObject instructPanel;
    public GameObject instructPanel2;

    void Start()
    {
        instructPanel.gameObject.SetActive(false);
        instructPanel2.gameObject.SetActive(false);
    }

    public void OnClickInstructButton()
    {
        instructPanel.gameObject.SetActive(true);
    }

    public void OnClickMenuButton()
    {
        instructPanel.gameObject.SetActive(false);
        instructPanel2.gameObject.SetActive(false);
    }

    public void OnClickNextButton()
    {
        instructPanel.gameObject.SetActive(false);
        instructPanel2.gameObject.SetActive(true);
    }


	// Update is called once per frame
	void Update () {
		
	}
}

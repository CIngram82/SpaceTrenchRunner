using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleController : MonoBehaviour
{
    public GameObject subPanel;
    public GameObject shipPanel;

    public Text subText;
    public Text shipText;


    public AudioSource audioSource;
    public MusicManager volControl;



    // Start is called before the first frame update
    void Start()
    {
        volControl = GameObject.Find("MusicManager").GetComponent<MusicManager>();

        subPanel.gameObject.SetActive(false);
        shipPanel.gameObject.SetActive(false);
        
        StartCoroutine(RadioSequence1());
    }

    // Update is called once per frame
    void Update()
    {
        //CheckForSub();
    }

    void CheckForSub()
    {
        //script to check if/what active audio track.
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void SubtitleByName(string name)
    {
        switch (name)
        {
            case "Boost":
                StartCoroutine(RadioSequenceBoost());
                break;
            case "Brake":
                StartCoroutine(RadioSequenceBrake());
                break;
            case "ShipCollision":
                StartCoroutine(ShipSequenceCollision());
                break;
            case "ShipBrake":
                StartCoroutine(ShipSequenceBrake());
                break;
            case "ShipPlasma":
                StartCoroutine(ShipSequencePlasma());
                break;
            case "ShipBoost":
                StartCoroutine(ShipSequenceBoost());
                break;
            case "ShipDamage":
                StartCoroutine(ShipSequenceDamage());
                break;
            default:
                Debug.Log ("Invalid sub name: " + name);
                break;
        }
    }

    IEnumerator RadioSequence1()
    {
        
        //these second values ARE tuned
        yield return new WaitForSeconds(0);
        subPanel.gameObject.SetActive(true);
        volControl.SetVol(.1f);
        subText.GetComponent<Text>().text = "OK Rookie, the simulation is running.";
        yield return new WaitForSeconds(2.4f);
        subText.GetComponent<Text>().text = "Remember, the experimental plasma recharge coils are in use.";
        yield return new WaitForSeconds(2.7f);
        subText.GetComponent<Text>().text = "Boosting will recharge the weapon system, braking requires vast amounts of plasma.";
        yield return new WaitForSeconds(4.2f);
        subText.GetComponent<Text>().text = "Improper use WILL result in damage.";
        yield return new WaitForSeconds(2.5f);
        volControl.SetVol(.5f);
        subPanel.gameObject.SetActive(false);
        
    }

    IEnumerator RadioSequenceBoost()
    {

        //these second values ARE NOT tuned
        yield return new WaitForSeconds(0);
        subPanel.gameObject.SetActive(true);
        volControl.SetVol(.1f);
        subText.GetComponent<Text>().text = "Remember, this is a test of the plasma coils.";
        yield return new WaitForSeconds(2.4f);
        subText.GetComponent<Text>().text = "Boost to recharge your weapons.";
        yield return new WaitForSeconds(2.5f);
        volControl.SetVol(.5f);
        subPanel.gameObject.SetActive(false);
        
    }

    IEnumerator RadioSequenceBrake()
    {

        //these second values ARE NOT tuned
        yield return new WaitForSeconds(0);
        subPanel.gameObject.SetActive(true);
        volControl.SetVol(.1f);
        subText.GetComponent<Text>().text = "Remember, this is a test of the plasma coils";
        yield return new WaitForSeconds(2.4f);
        subText.GetComponent<Text>().text = "Braking is a new feature in this version.";
        yield return new WaitForSeconds(2.9f);
        volControl.SetVol(.5f);
        subPanel.gameObject.SetActive(false);
        
    }

    IEnumerator ShipSequenceCollision()
    {

        //these second values ARE NOT tuned
        yield return new WaitForSeconds(0);
        shipPanel.gameObject.SetActive(true);
        volControl.SetVol(.1f);
        shipText.GetComponent<Text>().text = "Collision detected";
        yield return new WaitForSeconds(2.2f);
        volControl.SetVol(.5f);
        shipPanel.gameObject.SetActive(false);
        
    }

    IEnumerator ShipSequenceBrake()
    {

        //these second values ARE NOT tuned
        yield return new WaitForSeconds(0);
        shipPanel.gameObject.SetActive(true);
        volControl.SetVol(.1f);
        shipText.GetComponent<Text>().text = "Insufficient plasma";
        yield return new WaitForSeconds(1.5f);
        shipText.GetComponent<Text>().text = "for braking maneuver";
        yield return new WaitForSeconds(2.2f);
        volControl.SetVol(.5f);
        shipPanel.gameObject.SetActive(false);
        
    }

    IEnumerator ShipSequencePlasma()
    {

        //these second values ARE NOT tuned
        yield return new WaitForSeconds(0);
        shipPanel.gameObject.SetActive(true);
        volControl.SetVol(.1f);
        shipText.GetComponent<Text>().text = "Insufficient plasma";
        yield return new WaitForSeconds(2.2f);
        volControl.SetVol(.5f);
        shipPanel.gameObject.SetActive(false);
        
    }

    IEnumerator ShipSequenceBoost()
    {

        //these second values ARE NOT tuned
        yield return new WaitForSeconds(0);
        shipPanel.gameObject.SetActive(true);
        volControl.SetVol(.1f);
        shipText.GetComponent<Text>().text = "Boosting routes power";
        yield return new WaitForSeconds(1.5f);
        shipText.GetComponent<Text>().text = "to weapon system";
        yield return new WaitForSeconds(2.2f);
        volControl.SetVol(.5f);
        shipPanel.gameObject.SetActive(false);

    }

    IEnumerator ShipSequenceDamage()
    {

        //these second values ARE NOT tuned
        yield return new WaitForSeconds(0);
        shipPanel.gameObject.SetActive(true);
        volControl.SetVol(.1f);
        shipText.GetComponent<Text>().text = "Insufficient plasma";
        yield return new WaitForSeconds(1.5f);
        shipText.GetComponent<Text>().text = "Damage Sustained";
        yield return new WaitForSeconds(2.2f);
        volControl.SetVol(.5f);
        shipPanel.gameObject.SetActive(false);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerTriggers : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI objTextLost;
    [SerializeField] private string textLost;
    [SerializeField] private ParticleSystem particleLost;
    [SerializeField] private TextMeshProUGUI objTextWin;
    [SerializeField] private string textWin;
    [SerializeField] private ParticleSystem particleWin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeadZone")
        {
            StartCoroutine(Death());
        }
        if (other.gameObject.tag == "Finish")
        {
            particleWin.Play();
            objTextWin.text = textWin;
            objTextWin.gameObject.SetActive(true);
           // Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
           // rigidbody.useGravity = false;
           // rigidbody.AddForce(Vector3.up * 1f, ForceMode.Impulse);
        }
    }


    IEnumerator Death()
    {   
        particleLost.Play();
        objTextLost.text = textLost;
        objTextLost.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

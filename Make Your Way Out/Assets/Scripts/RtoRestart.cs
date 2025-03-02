using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RtoRestart : MonoBehaviour
{
    [SerializeField] Image rFillImage;
    [SerializeField] Image qFillImage;
    bool rHeld = false;
    bool qHeld = false;
    float holdTimer = 0f;
    float requiredHoldTime = 3f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            rHeld = true;
            qHeld = false;
            holdTimer = 0f;
            qFillImage.fillAmount = 0f;
        }
        if (Input.GetKeyUp(KeyCode.R))
            rHeld = false;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            qHeld = true;
            rHeld = false;
            holdTimer = 0f;
            rFillImage.fillAmount = 0f;
        }
        if (Input.GetKeyUp(KeyCode.Q))
            qHeld = false;

        if (!rHeld && !qHeld)
        {
            holdTimer = 0f;
            rFillImage.fillAmount = 0f;
            qFillImage.fillAmount = 0f;
            return;
        }

        holdTimer += Time.deltaTime;

        if (rHeld)
        {
            rFillImage.fillAmount = holdTimer / requiredHoldTime;
            if (holdTimer >= requiredHoldTime)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (qHeld)
        {
            qFillImage.fillAmount = holdTimer / requiredHoldTime;
            if (holdTimer >= requiredHoldTime)
                SceneManager.LoadScene("MainMenu");
        }
    }
}

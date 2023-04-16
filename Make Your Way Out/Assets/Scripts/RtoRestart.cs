using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RtoRestart : MonoBehaviour
{
    [SerializeField] Image fillImage;
    bool rHeld = false;
    float holdTimer = 0f;
    float requiredHoldTime = 3f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            rHeld = true;
        if (Input.GetKeyUp(KeyCode.R))
        {
            rHeld = false;
            holdTimer = 0f;
            fillImage.fillAmount = 0f;
        }


        if(rHeld == true)
        {
            holdTimer += Time.deltaTime;
            if(holdTimer >= requiredHoldTime)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            fillImage.fillAmount = holdTimer / requiredHoldTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipControl : MonoBehaviour
{
    private Text queueSize, lambda, miu;
    public float vQueueSize, vLambda, vMiu;

    // Start is called before the first frame update
    void Start()
    {
        SetTextAttributes();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateValues();   
    }

    public void IncreaseCount() {
        this.vQueueSize += 1f;
    }

    public void DecreaseCount() {
        this.vQueueSize -= 1f;
    } 

    private void UpdateValues() {
        this.queueSize.text = "Count: " + this.vQueueSize;;
        this.lambda.text = "λ: " + this.vLambda;
        this.miu.text = "μ: " + this.vMiu;
    }

    private void SetTextAttributes() {
        GameObject blackTooltip, canvas;

        blackTooltip = transform.GetChild(0).gameObject;
        canvas = blackTooltip.transform.GetChild(0).gameObject;

        this.queueSize = canvas.transform.GetChild(0).gameObject.GetComponent<Text>();
        this.lambda = canvas.transform.GetChild(1).gameObject.GetComponent<Text>();
        this.miu = canvas.transform.GetChild(2).gameObject.GetComponent<Text>();

    }
}

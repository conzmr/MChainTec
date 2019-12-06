using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipControl : MonoBehaviour
{
    private Text queueSize, lambda, miu;
    public float vQueueSize, vLambda, vMiu;
    private bool recalculate = true;

    // Start is called before the first frame update
    void Start()
    {
        SetTextAttributes();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateValues();   

        if (this.recalculate)
        {
            StartCoroutine(RecalculateLambda(10));
            this.vLambda = this.vQueueSize;
        }
    }

    // 10 seconds as unit of time
    // Refresh lambda every unit of time
    IEnumerator RecalculateLambda(int seconds) {
        this.recalculate = false;
        int counter = seconds;
        while (counter > 0) {
            yield return new WaitForSeconds(1);
            counter--;
        }
        this.recalculate = true;
    }

    public bool isOverloaded() {
        return this.vLambda > this.vMiu;
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

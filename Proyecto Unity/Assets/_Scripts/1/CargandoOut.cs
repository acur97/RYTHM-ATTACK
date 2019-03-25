using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargandoOut : MonoBehaviour {

    public Image fondo;
    public Text testo;
    public Image sliderFill;
    public Slider sliderV;
    public GameObject UI;

    private float speed = 0;

    private void Awake()
    {
        UI.SetActive(true);
        sliderV.value = 1;
    }

    private void Start()
    {
        StartCoroutine(ChangeSpeed(1, 0, 0.5f));
    }

    public IEnumerator ChangeSpeed(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            speed = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        speed = v_end;
        Destroy(UI);
        enabled = false;
    }

    private void Update()
    {
        fondo.color = new Color(0, 0, 0, speed);
        testo.color = new Color(1, 1, 1, speed);
        sliderFill.color = new Color(1, 0, 0, speed);
    }
}
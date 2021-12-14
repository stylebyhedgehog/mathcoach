using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatPanel : MonoBehaviour
{
    [SerializeField] private Button backBtn;

    void Start()
    {
        Actions();
    }


    private void Actions()
    {
        backBtn.onClick.AddListener(() => gameObject.SetActive(false));
    }
}

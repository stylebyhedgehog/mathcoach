using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockButtonUi : MonoBehaviour
{
    [SerializeField] private Text btnText;
    [SerializeField] private Button btn;
    private TaskUI taskUI;
    public void InitButtonData(Block b, TaskUI taskUIinp)
    {
        btnText.text = b.Description;
        taskUI = taskUIinp;
        btn.onClick.AddListener(() => ClickEvent(b));
    }

    private void ClickEvent(Block block)
    {
        taskUI.gameObject.SetActive(true);
        taskUI.InitTaskUI(block);
    }
}

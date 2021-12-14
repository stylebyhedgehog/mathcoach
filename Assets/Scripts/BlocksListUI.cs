using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlocksListUI : MonoBehaviour
{
    [SerializeField] private GameObject blockBtnPrefab;
    [SerializeField] private Transform parent;

    [SerializeField] private TaskUI taskUI;
    [SerializeField] private Button back;


    void Start()
    {
        addListeners();
        getBlocksData();
    }

    private void getBlocksData()
    {
        BlockRepository.Instance.getAllBlocks(initButton);

    }

    private void initButton(Block block)
    {
        BlockButtonUi bloackButtonUI = Instantiate(blockBtnPrefab, parent).GetComponent<BlockButtonUi>();
        bloackButtonUI.InitButtonData(block, taskUI);
    }



    private void addListeners()
    {
        back.onClick.AddListener(() => gameObject.SetActive(false));
    }

}

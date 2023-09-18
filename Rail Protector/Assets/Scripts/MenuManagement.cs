using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform canvasContainer;
    public float transTime = 1.0f;
    private int screenWidth;



    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
    }

    public void LevelClick()
    {
        MenuSelect(MenuType.LevelMenu);
    }

    public void BackToMain()
    {
        MenuSelect(MenuType.MainMenu);
    }

    private void MenuSelect(MenuType menuType)
    {
        Vector3 newPos;
        if (menuType == MenuType.LevelMenu)
        {
            newPos = new Vector3(-screenWidth, 0f, 0f);
        }
        else
        {
            newPos = Vector3.zero;
        }

        StopAllCoroutines();
        StartCoroutine(ChangeMenuLocation(newPos));
    }

    private IEnumerator ChangeMenuLocation(Vector3 newPos)
    {
        float elapsed = 0f;
        Vector3 oldPos = canvasContainer.anchoredPosition3D;

        while (elapsed <= transTime)
        {
            elapsed += Time.deltaTime;
            Vector3 currentPos = Vector3.Lerp(oldPos, newPos, elapsed / transTime);
            canvasContainer.anchoredPosition3D = currentPos;
            yield return null;
        }
    }

    private enum MenuType
    {
        MainMenu,
        LevelMenu
    }
}

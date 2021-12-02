using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // ReSharper disable HeapView.ObjectAllocation.Evident
public static class CustomVoids
{
    #region cv




    // public static Color illuminationColor = new Color(0f, 0.19f, 0.19f);
    // public static Color lockedColor = new Color(0.57f, 0f, 0.01f);
    // public static Color unLockedColor = new Color(0f, 0.74f, 0.04f);
    // public static Color uiHighlightedButton = new Color(0.74f, 0.04f, 0f);
    // public static Color uiSelectedButton = new Color(0.74f, 0.04f, 0f);
    // public static Color uiPressedButton = new Color(0f, 0.66f, 0.74f);
    // public static Color uiUnSelectedButton = new Color(0f, 0.13f, 0.16f);
    public static bool LockMouse;
    public static bool canUseLateralGuns;

    public static bool pcControlsActive;

    public static GameObject HoveredButton;



    private static readonly int EmissiveColor = Shader.PropertyToID("_EmissiveColor");

    //Set active one GameObject in List
    public static void SetActiveOne(List<GameObject> gameObjectsList, int selectedGameObject)
    {
        foreach (var go in gameObjectsList)
        {
            go.SetActive(false);
        }

        gameObjectsList[selectedGameObject].SetActive(true);

    }

    //Set active one GameObject in GameObject Array
    public static void SetActiveOne(GameObject[] gameObjectsArray, int selectedGameObject)
    {
        foreach (var go in gameObjectsArray)
        {
            go.SetActive(false);
        }

        gameObjectsArray[selectedGameObject].SetActive(true);

    }

    //Get List from the children in transform
    public static void GetListFromHierarchyGO(bool getActive, Transform transform, List<GameObject> desiredList)
    {
        foreach (Transform child in transform)
        {
            if (getActive)
            {
                if (child.gameObject.activeSelf)
                {
                    desiredList.Add(child.gameObject);
                }
            }
            else
            {
                desiredList.Add(child.gameObject);
            }
        }
    }

    public static void GetListFromHierarchyBTN(bool getActive, Transform transform, List<Button> desiredList)
    {
        foreach (Transform child in transform)
        {
            if (getActive)
            {
                if (child.gameObject.activeSelf)
                {
                    desiredList.Add(child.gameObject.GetComponent<Button>());
                }
            }
            else
            {
                desiredList.Add(child.gameObject.GetComponent<Button>());
            }
        }
    }

    public static void GetListFromHierarchyTR(bool getActive, Transform transform, List<Transform> desiredList)
    {
        foreach (Transform child in transform)
        {
            if (getActive)
            {
                if (child.gameObject.activeSelf)
                {
                    desiredList.Add(child);
                }
            }
            else
            {
                desiredList.Add(child);
            }
        }
    }

    public static void GetListFromHierarchyTMP(bool getActive, Transform transform,
        List<TextMeshProUGUI> desiredList)
    {
        foreach (TextMeshProUGUI child in transform)
        {
            if (getActive)
            {
                if (child.gameObject.activeSelf)
                {
                    desiredList.Add(child);
                }
            }
            else
            {
                desiredList.Add(child);
            }
        }
    }

    //Get Keyboard Sprites from resources folder
    public static Sprite GetKeyboardSpriteFromResources(string objectNeeded)
    {
        Sprite sprite =
            Resources.Load<Sprite>("Keyboard/" + objectNeeded);

        return sprite;
    }

    //Give the possibility to apply a desired color and intensity to a material
    public static void SetCustomMaterialEmissionIntensity(Material material, float intensity, Color color)
    {
        float adjustedIntensity = intensity - (0.4169F);
        color *= Mathf.Pow(2.0F, adjustedIntensity);
        material.SetColor(EmissiveColor, color);

    }

    //Lets set lock Mouse
    public static void SetLockMouseInScreen(bool lockMouse, bool mouseVisible)
    {
        switch (lockMouse)
        {
            case true:
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.lockState = CursorLockMode.Locked;
                //Cursor.visible = false;
                break;
            case false:
                Cursor.lockState = CursorLockMode.None;
                //Cursor.visible = true;
                break;

        }

        switch (mouseVisible)
        {
            case true:
                Cursor.visible = true;
                break;
            case false:
                Cursor.visible = false;
                break;
        }



    }



    public static void ChangeParentInHierarchy(GameObject goToMove, GameObject parentGO)
    {
        goToMove.transform.parent = parentGO.transform;
    }

    //Lets Change he image color of a LIST
    public static void ChangeImageColor(int id, List<GameObject> selectedList)
    {
        foreach (var t in selectedList)
        {
            var currentImage = t.GetComponent<Image>();
            currentImage.color = CustomColor.uiUnSelectedButton;
        }

        selectedList[id].GetComponent<Image>().color = CustomColor.uiSelectedButton;
    }

    public static void ChangeButtonColorState(bool selected, Image image)
    {
        image.GetComponent<Image>().color = selected ? CustomColor.uiSelectedButton : CustomColor.uiUnSelectedButton;
    }

    public static void UnSelectedButtonInL(List<Button> selectedList)
    {
        foreach (var t in selectedList)
        {
            Image currentImage = t.GetComponent<Image>();
            currentImage.color = CustomColor.uiUnSelectedButton;
        }
    }
    #endregion

}

public static class CustomColor
{
    public static Color illuminationColor = new Color(0f, 0.19f, 0.19f);
    public static Color lockedColor = new Color(0.57f, 0f, 0.01f);
    public static Color unLockedColor = new Color(0f, 0.74f, 0.04f);
    public static Color uiHighlightedButton = new Color(0.74f, 0.04f, 0f);
    public static Color uiSelectedButton = new Color(0.74f, 0.04f, 0f);
    public static Color uiPressedButton = new Color(0f, 0.66f, 0.74f);
    public static Color uiUnSelectedButton = new Color(0f, 0.13f, 0.16f);
}
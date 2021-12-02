using System.Collections.Generic;
using UnityEngine;
// ReSharper disable HeapView.ObjectAllocation.Evident
public static class CustomVoids
{
    #region cv

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

    #endregion
}


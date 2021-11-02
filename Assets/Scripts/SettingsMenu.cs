using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
        [Header("space between menu items")]
        [SerializeField] Vector2 spacing;

        Button mainButton;
        SettingsMenuItem[] menuItems;
        bool isExpanded = false;

        Vector2 mainButtonPosition;
        int itemsCount;

        private void Start()
        {
            itemsCount = transform.childCount - 1;
            menuItems = new SettingsMenuItem[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingsMenuItem>();
            }

            mainButton = transform.GetChild(0).GetComponent<Button>();
            mainButton.onClick.AddListener(ToggleMenu);
            mainButton.transform.SetAsLastSibling();

            mainButtonPosition = mainButton.transform.position;

            ResetPositions();
        }

        void ResetPositions()
        {
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].trans.position = mainButtonPosition;
            }
        }

        void ToggleMenu()
        {
            isExpanded = !isExpanded;

            if (isExpanded)
            {
                for (int i = 0; i < itemsCount; i++)
                {
                    menuItems[i].trans.position = mainButtonPosition + spacing * (i + 1);
                }
            }
            else
            {
                for (int i = 0; i < itemsCount; i++)
                {
                    menuItems[i].trans.position = mainButtonPosition;
                }
            }
        }

         void OnDestroy()
        {
            mainButton.onClick.RemoveListener(ToggleMenu);
        }
    }

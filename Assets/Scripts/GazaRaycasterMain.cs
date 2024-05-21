using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazaRaycasterMain : MonoBehaviour
{
    public float maxDistance = 10f;
    public LayerMask interactableLayer; // ������ LayerMask �� �� �� ���������� Raycast-��
    private Restart currentGazeButton;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, interactableLayer)) // ��������� LayerMask
        {
            Restart gazeButton = hit.collider.GetComponent<Restart>();
            if (gazeButton != null)
            {
                Debug.Log("Looking at: " + hit.collider.name); // �������� �� ����� ���
                if (gazeButton != currentGazeButton)
                {
                    if (currentGazeButton != null)
                    {
                        currentGazeButton.OnPointerExit();
                    }
                    currentGazeButton = gazeButton;
                    currentGazeButton.OnPointerEnter();
                }
            }
            else
            {
                if (currentGazeButton != null)
                {
                    currentGazeButton.OnPointerExit();
                    currentGazeButton = null;
                }
            }
        }
        else
        {
            if (currentGazeButton != null)
            {
                currentGazeButton.OnPointerExit();
                currentGazeButton = null;
            }
        }
    }
}

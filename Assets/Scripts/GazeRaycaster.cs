using UnityEngine;

public class GazeRaycaster : MonoBehaviour
{
    public float maxDistance = 10f;
    public LayerMask interactableLayer; // ������ LayerMask �� �� �� ���������� Raycast-��
    private GazeButton currentGazeButton;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, interactableLayer)) // ��������� LayerMask
        {
            GazeButton gazeButton = hit.collider.GetComponent<GazeButton>();
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

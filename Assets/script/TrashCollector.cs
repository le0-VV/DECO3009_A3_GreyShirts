using UnityEngine;
using UnityEngine.UI;

public class TrashCollector : MonoBehaviour
{
    public Animator sewageAnimator;  // Animator for the sewage discharge animation
    public Text pollutionStatusText;  // UI Text to display the status of the pollution source
    public Text trashCountText;  // UI Text to display the amount of trash collected
    public Text completionText;  // UI Text to display the completion message

    private int trashCount = 0;  // Current number of trash collected
    private int totalTrash;  // Total amount of trash
    private bool isPollutionActive = true;  // Whether the pollution source is still active

    private void Start()
    {
        totalTrash = GameObject.FindGameObjectsWithTag("Trash").Length;  // Get the total amount of trash
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            Destroy(other.gameObject);  // Delete the trash object
            trashCount++;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        trashCountText.text = $"Trash Collected: {trashCount}/{totalTrash}";

        if (!isPollutionActive)
        {
            pollutionStatusText.text = "Pollution Source: Inactive";
        }

        if (trashCount == totalTrash && !isPollutionActive)
        {
            completionText.text = "Congratulations! You have cleaned up all the trash and stopped the pollution. This greatly helps in protecting the animals!";
            completionText.gameObject.SetActive(true);  // Display the completion message
        }
    }

    public void StopPollution()
    {
        isPollutionActive = false;
        sewageAnimator.enabled = false;
        UpdateUI();
    }
}

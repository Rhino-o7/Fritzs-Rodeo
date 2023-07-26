using TMPro;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject Light;
    [SerializeField] TMP_Text batteryText;
    [SerializeField] float maxBattery;

    //float battery;
    //float fakeBattery = 2;

    void Start() {
        /*battery = maxBattery;
        batteryText.gameObject.SetActive(Light.activeSelf);*/ // Flashlight should have infinite battery, making it have a battery meter would make it too unfair. -Adri
    }

    void Update() {
        FlashLightManger();
    }

    void FlashLightManger() {
        //batteryText.text = "Battery : " + battery + "%";

        if (Input.GetKeyDown(KeyCode.F) /*&& battery > 0*/) {
            Light.SetActive(!Light.activeSelf);
            //batteryText.gameObject.SetActive(Light.activeSelf);
        }

        /*if (Light.activeInHierarchy) {
            fakeBattery -= 1 * Time.deltaTime;
        }

        if (fakeBattery <= 0) {
            fakeBattery = 10;
            battery -= 1;
        }

        if (battery <= 0) {
            Light.SetActive(false);
            batteryText.gameObject.SetActive(false);
        }*/
    }
}

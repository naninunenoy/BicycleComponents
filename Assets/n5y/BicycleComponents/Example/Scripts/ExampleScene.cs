using UnityEngine;
using UnityEngine.UI;

namespace n5y.BicycleComponents.Example {
    public class ExampleScene : MonoBehaviour {
        [SerializeField] Slider speedSlider = default;
        [SerializeField] Text speedText = default;
        [SerializeField] Slider handleSlider = default;
        [SerializeField] Text handleText = default;

        void Start() {
            handleSlider
                .onValueChanged
                .AddListener(value => {
                    handleText.text = $"{value:F0} deg";
                });
            speedSlider
                .onValueChanged
                .AddListener(value => {
                    speedText.text = $"{value:F0} deg/frame";
                });
        }
    }
}

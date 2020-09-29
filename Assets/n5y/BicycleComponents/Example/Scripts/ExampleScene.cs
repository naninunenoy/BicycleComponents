using System;
using UnityEngine;
using UnityEngine.UI;

namespace n5y.BicycleComponents.Example {
    public class ExampleScene : MonoBehaviour {
        [SerializeField] BicycleParts bicycle = default;
        [SerializeField] Slider speedSlider = default;
        [SerializeField] Text speedText = default;
        [SerializeField] Slider handleSlider = default;
        [SerializeField] Text handleText = default;

        float omega = 0.0F;

        void Start() {
            handleSlider
                .onValueChanged
                .AddListener(value => {
                    handleText.text = $"{value:F0} deg";
                    bicycle.SteerHandle(value);
                });
            speedSlider
                .onValueChanged
                .AddListener(value => {
                    omega = value;
                    speedText.text = $"{omega:F1} deg/frame";
                });
            omega = speedSlider.value;
            speedText.text = $"{omega:F1} deg/frame";
        }

        void Update() {
            bicycle.PushPedal(omega);
        }
    }
}

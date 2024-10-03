using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Image _mainImage;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Button _changeCollorButton;

        private Material _customMaterial;

        private void Start()
        {
            _changeCollorButton.onClick.AddListener(ChangeShaderColor);
        }
        public void Initial(Sprite sprite, string price)
        {
            _mainImage.sprite = sprite;
            _priceText.text = price;

            Shader customShader = Shader.Find(AppConstants.ShaderName);

            if (customShader != null)
            {
                _customMaterial = new Material(customShader);
                _mainImage.material = _customMaterial;
            }
            else
            {
                Debug.LogError("Шейдер не найден: " + AppConstants.ShaderName);
            }
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        public void Show()
        {
            gameObject.SetActive(true);
        }
        private void ChangeShaderColor()
        {
            Color color = Random.ColorHSV();
            _customMaterial.SetColor("_Color", color);
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}

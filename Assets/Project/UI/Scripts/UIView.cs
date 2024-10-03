using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System.Collections.Generic;

namespace TestProject
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _distanceInputField;
        [SerializeField] private CardView _cardViewPrefab;
        [SerializeField] private RectTransform _cardContentHolder;

        private List<CardView> _cards = new List<CardView>();
        public bool IsCardHide { get; private set; }
        public void CreateCards(int minPrice, int maxPrice, params Sprite[] cardImages)
        {
            foreach (var cardImage in cardImages)
            {
                var card = Instantiate(_cardViewPrefab, _cardContentHolder);
                card.Initial(cardImage, Random.Range(minPrice, maxPrice).ToString());
                _cards.Add(card);
            }
        }
        public void HideCards()
        {
            foreach (var card in _cards)
            {
                card.Hide();
            }
            IsCardHide = true;
        }
        public void ShowCards()
        {
            foreach (var card in _cards)
            {
                card.Show();
            }
            IsCardHide = false;
        }
        public void SubscribeInputField(UnityAction<string> action)
        {
            _distanceInputField.onEndEdit.AddListener(action);
        }
        public void SetTextView(string text)
        {
            _distanceInputField.text = text;
        }
    }
}

using System;
using UnityEngine;
using VContainer;

namespace TestProject
{
    public class UIPresenter 
    {
        [Inject] private EventBase _eventBase;
        [Inject] private UIModel _model;
        [Inject] private ImageLoader _imageLoader;

        private UIView _view;

        private readonly int _maxCardPrice = 10000;
        private readonly int _minCardPrice = 10;

        public void Init()
        {
            _eventBase?.Subscribe<CreateUIEvent>(CreateView);
            _eventBase?.Subscribe<CubeClickEvent>(ChangeCardStatus);
        }
        private void CreateView(CreateUIEvent uIEvent)
        {
            GameObject prefab = Resources.Load<GameObject>(AppConstants.UIPrefabName);
            _view = GameObject.Instantiate(prefab).GetComponent<UIView>();
            _view.SubscribeInputField(AcceptInputFromUser);
            _view.CreateCards(_minCardPrice, _maxCardPrice,
                _imageLoader.FirstSprite,
                _imageLoader.SecondSprite,
                _imageLoader.ThirdSprite,
                _imageLoader.FortedSprite,
                _imageLoader.FiftedSprite);
            _view.HideCards();

            _model.OnFieldTextChange += _view.SetTextView;

            _eventBase?.Invoke(new CanvasCreatedEvent(ChangeDistance));
        }
        private void ChangeDistance(float distance)
        {
            var shortValue = Math.Round(distance, 2);
            ChangeInputFieldValue(shortValue.ToString());
        }
        private void ChangeCardStatus(CubeClickEvent cubeClickEvent)
        {
            if (_view.IsCardHide)
            {
                _view.ShowCards();
            }
            else
            {
                _view.HideCards();
            }
        }
        private void AcceptInputFromUser(string value)
        {
            if (float.TryParse(value, out float result))
            {
                _eventBase?.Invoke(new UserFieldInputEvent(result));
            }
        }
        private void ChangeInputFieldValue(string newValue)
        {
            _model.SetTextModel(newValue);
        }
    }
}

using UnityEngine.Events;

namespace TestProject
{
    public class UIModel 
    {
        public UnityAction<string> OnFieldTextChange;

        private string _fieldText;
        public string FieldText
        {
            get { return _fieldText; }
            private set 
            { 
                _fieldText = value;
                OnFieldTextChange?.Invoke(_fieldText);
            }
        }
        public void SetTextModel(string text)
        {
            FieldText = text;
        }
    }
}

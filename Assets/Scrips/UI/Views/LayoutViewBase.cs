using System.Collections.Generic;
using System.Linq;
using Scrips.UI.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace Scrips.UI.Views
{
    [RequireComponent(typeof(UIDocument))]
    public abstract class LayoutViewBase : MonoBehaviour, ILayoutView
    {
        protected VisualElement _root;
        protected UIDocument _uiDocument;
        public bool IsActive => _root.visible;
        public bool Visible
        {
            get => _root.style.display == DisplayStyle.Flex;
            set => _root.style.display = value ? DisplayStyle.Flex : DisplayStyle.None;
        }
        public VisualElement GetRoot() => _root;
        public virtual void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();
            _root = _uiDocument.rootVisualElement;
            Hide();
        }
        
        public void Hide()
        {
            Visible = false;
        }

        public void Show()
        {
            Visible = true;
        }
    }
}
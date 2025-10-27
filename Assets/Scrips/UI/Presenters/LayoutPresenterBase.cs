using System;
using Scrips.UI.Interfaces;
using VContainer;
using VContainer.Unity;

namespace Scrips.UI.Presenters
{
    public abstract class LayoutPresenterBase<TView> : ILayoutPresenter, IInitializable, IDisposable 
        where TView : ILayoutView
    {
        [Inject] protected readonly TView LayoutView;
        
        public bool IsActive => LayoutView.IsActive;
        public void Activate() => LayoutView.Show();
        public void Deactivate() => LayoutView.Hide();
        public abstract void Initialize();

        public abstract void Dispose();
    }
}
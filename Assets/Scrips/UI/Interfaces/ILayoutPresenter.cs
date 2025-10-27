namespace Scrips.UI.Interfaces
{
    public interface ILayoutPresenter
    {
        public bool IsActive { get; }
        public void Activate();
        public void Deactivate();
    }
}
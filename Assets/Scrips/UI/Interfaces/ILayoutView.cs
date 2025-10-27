namespace Scrips.UI.Interfaces
{
    public interface ILayoutView
    {
        /// <summary>
        /// Отрисовывается ли окно в данный момент
        /// </summary>
        bool IsActive { get; }
        
        /// <summary>
        /// Видимость окна
        /// </summary>
        bool Visible { get; set; }

        void Hide();

        void Show();
    }
}
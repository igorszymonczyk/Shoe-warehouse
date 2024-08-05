namespace MagazynButow.ViewModel
{
    using System.Windows.Input;

    public partial class MagazynButowViewModel
    {
        public ICommand AddShoeCommand { get; }
        public ICommand AddToCennikCommand { get; }
        public ICommand ModifyToCennikCommand { get; }
        public ICommand UsunFromCennikCommand { get; }
        public ICommand ResetFilterringCommand { get; }
        public ICommand ShoesFilterringCommand { get; }
        public ICommand DeleteShoeCommand { get; }

    }
}

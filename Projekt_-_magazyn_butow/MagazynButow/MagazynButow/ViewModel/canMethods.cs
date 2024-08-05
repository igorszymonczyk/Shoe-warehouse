namespace MagazynButow.ViewModel
{
    using MySql.Data.MySqlClient;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Windows;
    using Model;

    public partial class MagazynButowViewModel
    {
        private bool CanAddShoe(object parameter)
        {
            return !string.IsNullOrEmpty(SKU) &&
                !string.IsNullOrEmpty(Kolorystyka) &&
                !string.IsNullOrEmpty(Model) &&
                !string.IsNullOrEmpty(Styl) &&
                !string.IsNullOrEmpty(Marka) &&
                KoloryButow.Values.Any(value => value);
        }

        private bool CanAddToCennik(object parameter)
        {
            decimal cena;
            return !string.IsNullOrEmpty(SelectedKolorystyka) &&
                !string.IsNullOrEmpty(SelectedRozmiar) &&
                !string.IsNullOrEmpty(SelectedSKU) &&
                !string.IsNullOrEmpty(SelectedModel) &&
                CanAdd == true &&
                CanModify == false &&
                decimal.TryParse(Cena, out cena) &&
                cena > 0;
        }

        private bool CanModifyToCennik(object parameter)
        {
            decimal cena;
            return !string.IsNullOrEmpty(SelectedKolorystyka) &&
                !string.IsNullOrEmpty(SelectedRozmiar) &&
                !string.IsNullOrEmpty(SelectedSKU) &&
                !string.IsNullOrEmpty(SelectedModel) &&
                CanAdd == false &&
                CanModify == true &&
                decimal.TryParse(Cena, out cena) &&
                cena > 0;
        }

        private bool CanDeleteFromCennik(object parameter)
        {
            return !string.IsNullOrEmpty(SelectedKolorystyka) &&
                !string.IsNullOrEmpty(SelectedRozmiar) &&
                !string.IsNullOrEmpty(SelectedSKU) &&
                !string.IsNullOrEmpty(SelectedModel) &&
                CanAdd == false &&
                CanModify == true;
        }

        private bool CanResetFilterring(object parameter)
        {
            return true;
        }

        private bool CanFilterShoes(object parameter)
        {
            return !string.IsNullOrEmpty(Marka) ||
                !string.IsNullOrEmpty(Kolor) ||
                !string.IsNullOrEmpty(Model) ||
                !string.IsNullOrEmpty(Styl);
        }

        private bool CanDeleteShoe(object parameter)
        {
            return !string.IsNullOrEmpty(SelectedModel) &&
                !string.IsNullOrEmpty(SelectedKolorystyka) &&
                !string.IsNullOrEmpty(SelectedSKU);
        }
    }
}

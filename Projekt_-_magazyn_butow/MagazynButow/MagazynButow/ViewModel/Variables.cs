namespace MagazynButow.ViewModel
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using MagazynButow.Model;

    public partial class MagazynButowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string dbconnection;
        public bool CanAdd = false;
        public bool CanModify = false;

        public ObservableCollection<string> Tables { get; set; }
        public ObservableCollection<string> Style { get; set; }
        public ObservableCollection<string> Marki { get; set; }
        public ObservableCollection<string> Lista_SKU { get; set; }
        public ObservableCollection<string> Lista_Kolorystyk { get; set; }
        public ObservableCollection<string> Lista_Modeli { get; set; }
        public ObservableCollection<string> Lista_Rozmiarow { get; set; }
        public ObservableCollection<string> Lista_Kolorow { get; set; }


        private Dictionary<string, bool> koloryButowChecked = new Dictionary<string, bool>
        {
            { "niebieski", false },
            { "czerwony", false },
            { "żółty", false },
            { "szary", false },
            { "biały", false },
            { "czarny", false },
            { "fioletowy", false },
            { "zielony", false },
            { "różowy", false },
            { "pomarańczowy", false },
            { "brązowy", false }
        };

        public Dictionary<string, bool> KoloryButow
        {
            get => koloryButowChecked;
            set
            {
                koloryButowChecked = value;
                OnPropertyChanged();
            }
        }


        private string selectedTable;
        public string SelectedTable
        {
            get => selectedTable;
            set
            {
                selectedTable = value;
                OnPropertyChanged();
                LoadTableData();
            }
        }

        private DataTable tableData;
        public DataTable TableData
        {
            get => tableData;
            set
            {
                tableData = value;
                OnPropertyChanged();
            }
        }

        private DataTable tableFiltr;
        public DataTable TableFiltr
        {
            get => tableFiltr;
            set
            {
                tableFiltr = value;
                OnPropertyChanged();
            }
        }

        private string marka = new Marki().marka;
        public string Marka
        {
            get => marka;
            set
            {
                marka = value;
                OnPropertyChanged();
            }
        }

        private string styl = new Model.Style().styl;
        public string Styl
        {
            get => styl;
            set
            {
                styl = value;
                OnPropertyChanged();
            }
        }

        private string sku = new Buty().sku;
        public string SKU
        {
            get => sku;
            set
            {
                sku = value;
                OnPropertyChanged();
            }
        }
        private string kolorystyka = new Buty().kolorystyka;
        public string Kolorystyka
        {
            get => kolorystyka;
            set
            {
                kolorystyka = value;
                OnPropertyChanged();
            }
        }
        private string kolor = new Kolory().kolor;
        public string Kolor
        {
            get => kolor;
            set
            {
                kolor = value;
                OnPropertyChanged();
            }
        }
        private string model = new Buty().model;
        public string Model
        {
            get => model;
            set
            {
                model = value;
                OnPropertyChanged();
            }
        }

        private string rozmiar_eu = new Rozmiary().rozmiar_eu;
        public string Rozmiar_EU
        {
            get => rozmiar_eu;
            set
            {
                rozmiar_eu = value;
                OnPropertyChanged();
            }
        }

        private int id_marki = new Marki().id_marki;
        public int Id_Marki
        {
            get => id_marki;
            set
            {
                id_marki = value;
                OnPropertyChanged();
            }
        }

        private int id_stylu = new Model.Style().id_stylu;
        public int Id_Stylu
        {
            get => id_stylu;
            set
            {
                id_stylu = value;
                OnPropertyChanged();
            }
        }

        private long id_buta = new Buty().id_buta;
        public long Id_Buta
        {
            get => id_buta;
            set
            {
                id_buta = value;
                OnPropertyChanged();
            }
        }

        private int id_rozmiaru = new Rozmiary().id_rozmiaru;
        public int Id_Rozmiaru
        {
            get => id_rozmiaru;
            set
            {
                id_rozmiaru = value;
                OnPropertyChanged();
            }
        }

        private int id_koloru = new Kolory().id_koloru;
        public int Id_Koloru
        {
            get => id_koloru;
            set
            {
                id_koloru = value;
                OnPropertyChanged();
            }
        }

        private string selectedModel = new Buty().model;
        public string SelectedModel
        {
            get => selectedModel;
            set
            {
                if (selectedModel != value)
                {
                    selectedModel = value;
                    OnPropertyChanged(nameof(SelectedModel));
                    Lista_Kolorystyk.Clear();
                    Lista_SKU.Clear();
                    Lista_Rozmiarow.Clear();
                    Cena = "0";
                    if (!string.IsNullOrEmpty(selectedModel))
                    {
                        LoadKolorystyki(selectedModel);
                    }
                }
            }
        }

        private string selectedKolorystyka = new Buty().kolorystyka;
        public string SelectedKolorystyka
        {
            get => selectedKolorystyka;
            set
            {
                if (selectedKolorystyka != value)
                {
                    selectedKolorystyka = value;
                    OnPropertyChanged(nameof(SelectedKolorystyka));
                    Lista_SKU.Clear();
                    Lista_Rozmiarow.Clear();
                    Cena = "0";
                    if (!string.IsNullOrEmpty(selectedKolorystyka) && !string.IsNullOrEmpty(SelectedModel))
                    {
                        LoadSKU(selectedKolorystyka, SelectedModel);
                    }
                }
            }
        }

        private string selectedSKU = new Buty().sku;
        public string SelectedSKU
        {
            get => selectedSKU;
            set
            {
                if (selectedSKU != value)
                {
                    selectedSKU = value;
                    OnPropertyChanged(nameof(SelectedSKU));
                    Lista_Rozmiarow.Clear();
                    Cena = "0";
                    if (!string.IsNullOrEmpty(selectedSKU) && !string.IsNullOrEmpty(SelectedKolorystyka) && !string.IsNullOrEmpty(SelectedModel))
                    {
                        LoadRozmiary(SelectedKolorystyka, SelectedModel, selectedSKU);
                    }
                }
            }
        }

        private string selectedRozmiar = new Rozmiary().rozmiar_eu;
        public string SelectedRozmiar
        {
            get => selectedRozmiar;
            set
            {
                if (selectedRozmiar != value)
                {
                    selectedRozmiar = value;
                    OnPropertyChanged(nameof(SelectedRozmiar));
                    if (!string.IsNullOrEmpty(selectedRozmiar) && !string.IsNullOrEmpty(SelectedSKU) && !string.IsNullOrEmpty(SelectedKolorystyka) && !string.IsNullOrEmpty(SelectedModel))
                    {
                        LoadCena(selectedRozmiar);
                    }
                    else
                    {
                        Cena = "0";
                    }
                }

            }
        }

        private string _cena;
        public string Cena
        {
            get => _cena;
            set
            {
                if (_cena != value)
                {
                    _cena = value;
                    OnPropertyChanged(nameof(Cena));
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            CommandManager.InvalidateRequerySuggested();
        }
    }
}

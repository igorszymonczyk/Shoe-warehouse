namespace MagazynButow.ViewModel
{
    using MySql.Data.MySqlClient;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Windows;
    using Model;

    public partial class MagazynButowViewModel
    {
        public MagazynButowViewModel()
        {
            dbconnection = new DBConnection().mysql_connection_string;
            Tables = new ObservableCollection<string>();
            Style = new ObservableCollection<string>();
            Marki = new ObservableCollection<string>();
            Lista_SKU = new ObservableCollection<string>();
            Lista_Kolorystyk = new ObservableCollection<string>();
            Lista_Modeli = new ObservableCollection<string>();
            Lista_Rozmiarow = new ObservableCollection<string>();
            Lista_Kolorow = new ObservableCollection<string>();


            AddShoeCommand = new RelayCommand(AddShoe, CanAddShoe);
            AddToCennikCommand = new RelayCommand(AddToCennik, CanAddToCennik);
            ModifyToCennikCommand = new RelayCommand(ModifyToCennik, CanModifyToCennik);
            UsunFromCennikCommand = new RelayCommand(DeleteFromCennik, CanDeleteFromCennik);
            ResetFilterringCommand = new RelayCommand(ResetFilterring, CanResetFilterring);
            ShoesFilterringCommand = new RelayCommand(ShoesFilterring, CanFilterShoes);
            DeleteShoeCommand = new RelayCommand(DeleteShoe, CanDeleteShoe);

            LoadTables();
            LoadMarki();
            LoadStyle();
            LoadModele();
            LoadKolory();
            ResetFilterring(TableFiltr);
        }

        private void LoadTables()
        {
            Tables.Clear();

            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                string sql = "SHOW TABLES";
                using (var command = new MySqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tables.Add(reader.GetString(0));
                        }
                    }
                }
                connection.Close();
            }
        }

        private void LoadTableData()
        {
            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                string sql = $"SELECT * FROM {SelectedTable}";
                using (var command = new MySqlCommand(sql, connection))
                {
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        TableData = dataTable;
                    }
                }
                connection.Close();
            }
        }

        private void LoadStyle()
        {
            Style.Clear();

            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                string sql = "SELECT * FROM style";
                using (var command = new MySqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Style.Add(reader.GetString("styl"));
                        }
                    }
                }
                connection.Close();
            }
        }

        private void LoadMarki()
        {
            Marki.Clear();

            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                string sql = "SELECT * FROM marki";
                using (var command = new MySqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Marki.Add(reader.GetString("marka"));
                        }
                    }
                }
                connection.Close();
            }
        }

        private void LoadSKU(string kolorystyka, string model)
        {
            Lista_SKU.Clear();

            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                string sql = "SELECT sku FROM buty WHERE model = @model AND kolorystyka = @kolorystyka";
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@model", model);
                    command.Parameters.AddWithValue("@kolorystyka", kolorystyka);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SKU = reader.GetString("sku");
                            Lista_SKU.Add(SKU);
                        }
                    }
                }
                connection.Close();
            }
        }

        private void LoadKolorystyki(string model)
        {
            Lista_Kolorystyk.Clear();

            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                string sql = "SELECT kolorystyka FROM buty WHERE model = @model";
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@model", model);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kolorystyka = reader.GetString("kolorystyka");
                            Lista_Kolorystyk.Add(Kolorystyka);
                        }
                    }
                }
                connection.Close();
            }
        }

        private void LoadKolory()
        {
            Lista_Kolorow.Clear();

            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                string sql = "SELECT kolor FROM kolory";
                using (var command = new MySqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kolor = reader.GetString("kolor");
                            Lista_Kolorow.Add(Kolor);
                        }
                    }
                }
                connection.Close();
                Kolor = "";
            }
        }

        private void LoadModele()
        {
            Lista_Modeli.Clear();

            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                string sql = "SELECT DISTINCT model FROM buty";
                using (var command = new MySqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Model = reader.GetString("model");
                            Lista_Modeli.Add(Model);
                        }
                    }
                }
                Model = "";
                connection.Close();
            }
        }

        private void LoadRozmiary(string kolorystyka, string model, string sku)
        {
            Lista_Rozmiarow.Clear();

            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                string sql = "SELECT id_buta, marka FROM buty WHERE model = @model AND kolorystyka = @kolorystyka AND sku = @sku";
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@model", model);
                    command.Parameters.AddWithValue("@kolorystyka", kolorystyka);
                    command.Parameters.AddWithValue("@sku", sku);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Id_Buta = reader.GetInt32("id_buta");
                            Id_Marki = reader.GetInt32("marka");
                        }
                    }
                }
                sql = $"SELECT id_rozmiaru, rozmiar_eu FROM rozmiary JOIN rozmiary_marek ON rozmiary.id_rozmiaru = rozmiary_marek.rozmiar JOIN marki ON marki.id_marki = rozmiary_marek.marka WHERE marki.id_marki = {Id_Marki};";
                using (var command = new MySqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rozmiar_EU = reader.GetString("rozmiar_eu");
                            Lista_Rozmiarow.Add(Rozmiar_EU);
                        }
                    }
                }
                connection.Close();

            }
        }



        private void LoadCena(string rozmiar)
        {
            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                string sql = $"SELECT id_rozmiaru FROM rozmiary JOIN rozmiary_marek ON rozmiary.id_rozmiaru = rozmiary_marek.rozmiar JOIN marki ON marki.id_marki = rozmiary_marek.marka WHERE marki.id_marki = {Id_Marki} AND rozmiary.rozmiar_eu = '{rozmiar}';";
                using (var command = new MySqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Id_Rozmiaru = reader.GetInt32("id_rozmiaru");
                        }
                    }
                }

                sql = $"SELECT cena FROM cennik WHERE but = {Id_Buta} AND rozmiar = {Id_Rozmiaru};";
                using (var command = new MySqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Cena = reader.GetDecimal("cena").ToString();
                            CanAdd = false;
                            CanModify = true;
                        }
                        else
                        {
                            Cena = "0";
                            CanAdd = true;
                            CanModify = false;
                        }
                    }
                }
                connection.Close();
            }
        }

        private void AddShoe(object parameter)
        {
            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();

                string checkSql = "SELECT COUNT(*) FROM buty WHERE sku = @sku AND model = @model AND kolorystyka = @kolorystyka";
                using (var checkCommand = new MySqlCommand(checkSql, connection))
                {
                    checkCommand.Parameters.AddWithValue("@sku", SKU);
                    checkCommand.Parameters.AddWithValue("@model", Model);
                    checkCommand.Parameters.AddWithValue("@kolorystyka", Kolorystyka);

                    var count = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("But już istnieje w bazie danych.");
                        return;
                    }
                }

                string sql_idmarki = "SELECT id_marki FROM marki WHERE marka = @marka";
                using (var command = new MySqlCommand(sql_idmarki, connection))
                {
                    command.Parameters.AddWithValue("@marka", Marka);
                    var result = command.ExecuteScalar();
                    Id_Marki = Convert.ToInt32(result);
                }

                string sql_idstylu = "SELECT id_stylu FROM style WHERE styl = @styl";
                using (var command = new MySqlCommand(sql_idstylu, connection))
                {
                    command.Parameters.AddWithValue("@styl", Styl);
                    var result = command.ExecuteScalar();
                    Id_Stylu = Convert.ToInt32(result);
                }


                string sql_insertbut = "INSERT INTO buty (sku, model, kolorystyka, marka, styl) VALUES (@sku, @model, @kolorystyka, @marka, @styl)";
                using (var insertBut = new MySqlCommand(sql_insertbut, connection))
                {
                    insertBut.Parameters.AddWithValue("@sku", SKU);
                    insertBut.Parameters.AddWithValue("@model", Model);
                    insertBut.Parameters.AddWithValue("@kolorystyka", Kolorystyka);
                    insertBut.Parameters.AddWithValue("@marka", Id_Marki);
                    insertBut.Parameters.AddWithValue("@styl", Id_Stylu);
                    insertBut.ExecuteNonQuery();
                    Id_Buta = insertBut.LastInsertedId;
                }


                foreach (var kolor in KoloryButow)
                {
                    if (kolor.Value)
                    {
                        var kolor_nazwa = kolor.Key;
                        string sql_selectkolor = "SELECT id_koloru FROM kolory WHERE kolor = @kolor";
                        using (var command = new MySqlCommand(sql_selectkolor, connection))
                        {
                            command.Parameters.AddWithValue("@kolor", kolor_nazwa);
                            var id_koloru = command.ExecuteScalar();
                            Id_Koloru = Convert.ToInt32(id_koloru);
                        }

                        string sql_insertKolor = "INSERT INTO kolory_buta (but, kolor) VALUES (@id_buta, @id_koloru)";
                        using (var insertKolor = new MySqlCommand(sql_insertKolor, connection))
                        {
                            insertKolor.Parameters.AddWithValue("@id_buta", Id_Buta);
                            insertKolor.Parameters.AddWithValue("@id_koloru", Id_Koloru);
                            insertKolor.ExecuteNonQuery();
                        }
                    }

                }
                connection.Close();
                MessageBox.Show("Pomyślnie dodano buta do bazy danych!");
            }
            LoadModele();
            ResetFilterring(TableFiltr);
            Styl = null;
            Marka = null;
            SKU = "";
            Model = "";
            Kolorystyka = "";
            KoloryButow.Clear();
            Id_Buta = 0;
        }

        private void DeleteShoe(object parameter)
        {
            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();

                string sql_getid = "SELECT id_buta FROM buty WHERE model = @model AND kolorystyka = @kolorystyka AND SKU = @sku";
                using (var getid = new MySqlCommand(sql_getid, connection))
                {
                    getid.Parameters.AddWithValue("@sku", SelectedSKU);
                    getid.Parameters.AddWithValue("@model", SelectedModel);
                    getid.Parameters.AddWithValue("@kolorystyka", SelectedKolorystyka);
                    var result = getid.ExecuteScalar();
                    Id_Buta = Convert.ToInt32(id_buta);
                }
                string sql_deleteshoe = "DELETE FROM buty WHERE id_buta = @id_buta";
                using (var deleteshoe = new MySqlCommand(sql_deleteshoe, connection))
                {
                    deleteshoe.Parameters.AddWithValue("@id_buta", Id_Buta);
                    deleteshoe.ExecuteNonQuery();
                }
                connection.Close();
                MessageBox.Show("Pomyślnie usunięto buta z bazy danych!");
            }
            LoadModele();
            ResetFilterring(TableFiltr);
            SelectedKolorystyka = null;
            SelectedModel = null;
            SelectedKolorystyka = null;
            Id_Buta = 0;
        }

        private void AddToCennik(object parameter)
        {
            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                decimal cena;
                if (decimal.TryParse(Cena, out cena))
                {
                    string sql_addtocennik = $"INSERT INTO cennik (but, rozmiar, cena) VALUES ({Id_Buta}, {Id_Rozmiaru}, {cena})";
                    using (var addtocennik = new MySqlCommand(sql_addtocennik, connection))
                    {
                        addtocennik.ExecuteNonQuery();
                    }
                    MessageBox.Show("Pomyślnie dodano buta, wraz z rozmiarem i ceną do cennika!");
                }
                else
                {
                    MessageBox.Show("Podana cena nie jest poprawną liczbą dziesiętną.");
                }
                connection.Close();
            }
            Lista_Kolorystyk.Clear();
            Lista_Rozmiarow.Clear();
            Lista_SKU.Clear();
            SelectedKolorystyka = null;
            SelectedModel = null;
            SelectedRozmiar = null;
            SelectedSKU = null;
            Cena = "0";
            CanModify = false;
            CanAdd = false;
            //LoadTables();
            ResetFilterring(TableFiltr);
        }

        private void ModifyToCennik(object parameter)
        {
            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                decimal cena;
                if (decimal.TryParse(Cena, out cena))
                {
                    string sql_modifytocennik = $"UPDATE cennik SET cena = {Cena} WHERE but = {Id_Buta} AND rozmiar = {Id_Rozmiaru}";
                    using (var modifytocennik = new MySqlCommand(sql_modifytocennik, connection))
                    {
                        modifytocennik.ExecuteNonQuery();
                    }
                    MessageBox.Show("Pomyślnie zaktualizowano cenę buta!");
                }
                else
                {
                    MessageBox.Show("Podana cena nie jest poprawną liczbą dziesiętną.");
                }
                connection.Close();
            }
            Lista_Kolorystyk.Clear();
            Lista_Rozmiarow.Clear();
            Lista_SKU.Clear();
            SelectedKolorystyka = null;
            SelectedModel = null;
            SelectedRozmiar = null;
            SelectedSKU = null;
            Cena = "0";
            CanModify = false;
            CanAdd = false;
            //LoadTables();
            ResetFilterring(TableFiltr);
        }

        private void DeleteFromCennik(object parameter)
        {
            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                string sql_deletefromcennik = $"DELETE FROM cennik WHERE but = {Id_Buta} AND rozmiar = {Id_Rozmiaru}";
                using (var deletefromcennik = new MySqlCommand(sql_deletefromcennik, connection))
                {
                    deletefromcennik.ExecuteNonQuery();
                }
                connection.Close();
            }
            MessageBox.Show("Pomyślnie usunięto cenę z cennika!");
            Lista_Kolorystyk.Clear();
            Lista_Rozmiarow.Clear();
            Lista_SKU.Clear();
            SelectedKolorystyka = null;
            SelectedModel = null;
            SelectedRozmiar = null;
            SelectedSKU = null;
            Cena = "0";
            CanModify = false;
            CanAdd = false;
            //LoadTables();
            ResetFilterring(TableFiltr);
        }

        private void ResetFilterring(object parameter)
        {
            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                string sql = "SELECT buty.model, buty.kolorystyka, marki.marka, style.styl, rozmiary.rozmiar_eu, cennik.cena    FROM buty JOIN marki ON buty.marka = marki.id_marki    JOIN style ON buty.styl = style.id_stylu   JOIN cennik ON buty.id_buta = cennik.but  JOIN rozmiary ON rozmiary.id_rozmiaru = cennik.rozmiar;";
                using (var command = new MySqlCommand(sql, connection))
                {
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        TableFiltr = dataTable;
                    }
                }
                connection.Close();
            }
            Model = null;
            Kolor = null;
            Marka = null;
            Styl = null;
        }

        private void ShoesFilterring(object parameter)
        {
            using (var connection = new MySqlConnection(dbconnection))
            {
                connection.Open();
                string sql = "CALL FiltrowanieButow(@Marka, @Styl, @Model, @Kolor)";
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Marka", string.IsNullOrEmpty(Marka) ? DBNull.Value : Marka);
                    command.Parameters.AddWithValue("@Styl", string.IsNullOrEmpty(Styl) ? DBNull.Value : Styl);
                    command.Parameters.AddWithValue("@Model", string.IsNullOrEmpty(Model) ? DBNull.Value : Model);
                    command.Parameters.AddWithValue("@Kolor", string.IsNullOrEmpty(Kolor) ? DBNull.Value : Kolor);

                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        TableFiltr = dataTable;
                    }
                }
                connection.Close();
            }
            Model = null;
            Kolor = null;
            Marka = null;
            Styl = null;
        }
    }
}

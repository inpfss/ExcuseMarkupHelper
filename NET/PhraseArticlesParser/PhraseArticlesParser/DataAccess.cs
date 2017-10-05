using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOX;

namespace PhraseArticlesParser
{
    public class DataAccess
    {
        string ConnStringTemplate = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Jet OLEDB:Engine Type=5;";

        private string _connString;
        private CatalogClass _db;

        public void CreateDb(string dbPath)
        {
            _connString = string.Format(ConnStringTemplate, dbPath);
            _db = new CatalogClass();
            _db.Create(_connString);

            CreateZaholovokTable();
            CreateHnizdoTable();
            CreatePrypovidkaTable();

            _db = null;
        }

        public void InsertData(IEnumerable<Zaholovok> data)
        {
            OleDbConnection myconn = new OleDbConnection(_connString);
            myconn.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = myconn;
            cmd.CommandType = CommandType.Text;


            foreach (Zaholovok zaholovok in data)
            {
                //INSERT INTO Zaholovok
                cmd.CommandText =
                    @"insert into Zaholovok (HeadWordID, HeadWordText) values (@HeadWordID, @HeadWordText)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@HeadWordID", zaholovok.HeadWordId);
                cmd.Parameters.AddWithValue("@HeadWordText", zaholovok.HeadWordText);
                cmd.ExecuteNonQuery();

                foreach (Hnizdo hnizdo in zaholovok.Idioms)
                {

                    try
                    {
                        //INSERT INTO Hnizdo
                        cmd.CommandText =
                        @"insert into Hnizdo (HeadWordID, NestNumber, Remark) values (@HeadWordID, @NestNumber, @Remark)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@HeadWordID", zaholovok.HeadWordId);
                    cmd.Parameters.AddWithValue("@NestNumber", hnizdo.NestNumber);
                    cmd.Parameters.AddWithValue("@Remark", hnizdo.Remark);
                    cmd.ExecuteNonQuery();

                    //Get latest NestID
                    cmd.Parameters.Clear();
                    cmd.CommandText = "Select @@Identity";
                    int nestId = (int)cmd.ExecuteScalar();

                  
                        //INSERT INTO Prypovidka
                        cmd.CommandText =
                            @"insert into Prypovidka (NestID, ProverbText, ProverbSource) values (@NestID, @ProverbText, @ProverbSource)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@NestID", nestId);
                        cmd.Parameters.AddWithValue("@ProverbText", hnizdo.Prypovidka.ProverbText);
                        cmd.Parameters.AddWithValue("@ProverbSource", hnizdo.Prypovidka.ProverbSource ?? String.Empty);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }


            myconn.Close();
        }

        void CreateZaholovokTable()
        {
            Table table = new Table { Name = "Zaholovok" };
            _db.Tables.Append(table);

            Column col = AddColumToTable(table, DataTypeEnum.adInteger, "HeadWordID");
            CreateIndex("PK_Zaholovok", col, table);

            AddColumToTable(table, DataTypeEnum.adVarWChar, "HeadWordText");
        }

        void CreateHnizdoTable()
        {
            Table table = new Table { Name = "Hnizdo" };
            _db.Tables.Append(table);

            Column col = AddColumToTable(table, DataTypeEnum.adInteger, "NestID", autoIncrement: true);
            CreateIndex("PK_Hnizdo", col, table);

            AddColumToTable(table, DataTypeEnum.adInteger, "HeadWordID");
            AddColumToTable(table, DataTypeEnum.adInteger, "NestNumber");
            AddColumToTable(table, DataTypeEnum.adVarWChar, "Remark");
        }

        void CreatePrypovidkaTable()
        {
            Table table = new Table { Name = "Prypovidka" };
            _db.Tables.Append(table);

            Column col = AddColumToTable(table, DataTypeEnum.adInteger, "ProverbID", autoIncrement: true);
            CreateIndex("PK_Prypovidka", col, table);

            AddColumToTable(table, DataTypeEnum.adInteger, "NestID");
            AddColumToTable(table, DataTypeEnum.adVarWChar, "ProverbText");
            AddColumToTable(table, DataTypeEnum.adVarWChar, "ProverbSource", allowNull: true);
        }

        private static void CreateIndex(string indexName, Column col, Table table)
        {
            Index index = new Index
            {
                PrimaryKey = true,
                Name = indexName
            };
            index.Columns.Append(col.Name, col.Type, col.DefinedSize);
            table.Indexes.Append(index);
        }

        private Column AddColumToTable(
            Table table,
            DataTypeEnum type,
            string name,
            bool allowNull = false,
            bool autoIncrement = false)
        {
            Column col = new Column
            {
                Name = name,
                ParentCatalog = _db,
                Type = type
            };
            col.Properties["AutoIncrement"].Value = autoIncrement;
            col.Properties["Nullable"].Value = allowNull;

            table.Columns.Append(col);
            return col;
        }
    }
}

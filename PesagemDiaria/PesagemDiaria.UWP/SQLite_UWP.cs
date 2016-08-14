using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Windows.Storage;
using Xamarin.Forms;
using PesagemDiaria.UWP;
using System.IO;

[assembly: Dependency(typeof(SQLite_UWP))]

namespace PesagemDiaria.UWP
{
    class SQLite_UWP : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "DBPesagem.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}

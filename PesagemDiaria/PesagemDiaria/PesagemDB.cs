using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PesagemDiaria
{
    public class PesagemDB
    {
        static object locker = new object();

        SQLiteConnection database;

        public PesagemDB() {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Pesagem>(); 
        }

        public bool existeLancamento()
        {
            var qry = database.Query<Pesagem>("SELECT * FROM [Pesagem]");
            if (qry.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Pesagem> listagem() {
            var qry = database.Query<Pesagem>("SELECT * FROM [Pesagem] ORDER BY id desc");
            return qry;
        }

        public Pesagem retornaUltima()
        {
            var qry = database.Query<Pesagem>("SELECT * FROM [Pesagem] ORDER BY id desc");
            if (qry.Count > 0)
            {
                return qry[0];
            }
            else
            {
                return null;
            }

        }

        public Pesagem retornaPrimeira()
        {
            var qry = database.Query<Pesagem>("SELECT * FROM [Pesagem] ORDER BY id");
            if (qry.Count > 0)
            {
                return qry[0];
            }
            else
            {
                return null;
            }

        }

        public Pesagem retornaLancamento(int qtdDias)
        {
            var qry = database.Query<Pesagem>("SELECT * FROM [Pesagem] ORDER BY id desc");
            if (qry.Count > (qtdDias-1))
            {
                return qry[qtdDias-1];
            }
            else
            {
                if (qtdDias > 0)
                {
                    return App.Database.retornaLancamento(qtdDias - 1);
                }
                else {
                    Pesagem pesoZero = new Pesagem();
                    pesoZero.peso = 0; 
                    return pesoZero;
                }
            }

        }

        public Pesagem GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<Pesagem>().FirstOrDefault(x => x.id == id);
            }
        }

        public int SaveItem(Pesagem item)
        {
            lock (locker)
            {
                if (item.id != 0)
                {
                    database.Update(item);
                    return item.id;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Pesagem>(id);
            }
        }

    }
}

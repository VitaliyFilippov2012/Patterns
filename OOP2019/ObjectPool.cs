using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool
{
    public class Connection
    {
        public ConnectionPool Pool { get; }
        public bool IsInUse { get; set; }
        public static List<string> History { get => history; set => history = value; }

        public string info = "";
        public int numberconnection;
        public static int countConnection = 1;
        private static List<string> history = new List<string>();
        public Connection(ConnectionPool pool)
        {
            Pool = pool;
            numberconnection = countConnection;
            info += $" Connection {countConnection} is opened";
            History.Add(info);
            countConnection++;
        }
    }

    public class ConnectionPool
    {
        private readonly int _maxSize;
        private readonly List<Connection> _connections;
        public ConnectionPool(int minSize, int maxSize)
        { // здесь необходимы проверки на корректность параметров!
            _maxSize = maxSize;
            _connections = new List<Connection>(minSize);
            for (var i = 0; i < minSize; i++)
            {
                var connection = new Connection(this);
                _connections.Add(connection);
            }
        }
        public Connection GetConnection()
        {
            var connection = _connections.FirstOrDefault(x => !x.IsInUse);
            if (connection == null)
                connection = CreateConnection();
            connection.IsInUse = true;
            return connection;
        }
        public void ReleaseConnection(Connection connection)
        {
            // это соединение из нашего пула?
            if (connection.Pool != this)
            { throw new InvalidOperationException(); }
            // да, из нашего =>
            // сделаем его доступным для использования
            Connection.History.Add($" Connection {connection.numberconnection} not use");
            connection.IsInUse = false;
        }
        private Connection CreateConnection()
        {
            if (_connections.Count == _maxSize)
            { throw new InvalidOperationException(); }
            var connection = new Connection(this);
            _connections.Add(connection);
            return connection;
        }
    }
}

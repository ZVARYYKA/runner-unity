using System.Collections.Generic;
using System.Data;
using Mono.Data.SqliteClient;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    private string connectionString;

    private void Awake()
    {
        connectionString = "URI=file:" + Application.dataPath + "/Database/PlayersSQLite.db";
    }

    public void InsertScore(string name, int score)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sql = "INSERT INTO Leaderboard (player_name, score) VALUES (@name, @score)";
                dbCommand.CommandText = sql;

                IDbDataParameter nameParameter = dbCommand.CreateParameter();
                nameParameter.ParameterName = "@name";
                nameParameter.Value = name;
                dbCommand.Parameters.Add(nameParameter);

                IDbDataParameter scoreParameter = dbCommand.CreateParameter();
                scoreParameter.ParameterName = "@score";
                scoreParameter.Value = score;
                dbCommand.Parameters.Add(scoreParameter);

                dbCommand.ExecuteNonQuery();
            }

            dbConnection.Close();
        }
    }

    public List<LeaderboardEntry> GetLeaderboard()
    {
        List<LeaderboardEntry> entries = new List<LeaderboardEntry>();

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sql = "SELECT * FROM Leaderboard ORDER BY score DESC LIMIT 10";
                dbCommand.CommandText = sql;

                using (IDataReader dataReader = dbCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string name = dataReader.GetString(1);
                        int score = dataReader.GetInt32(2);
                        entries.Add(new LeaderboardEntry(name, score));
                    }
                }
            }
        }

        return entries;
    }
}

public struct LeaderboardEntry
{
    public string name;
    public int score;

    public LeaderboardEntry(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}

using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Data;
using Mono.Data.SqliteClient;

public class LeaderboardUI : MonoBehaviour
{
    public TextMeshProUGUI leaderboardText;
    public GameObject panelScore;

    private string connectionString;

    private void Start()
    {
        connectionString = "URI=file:" + Application.dataPath + "/Database/PlayersSQLite.db";
    }

    public void LoadLeaderboard()
    {
        panelScore.SetActive(true);

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

        leaderboardText.text = "";
        int rank = 1;
        foreach (LeaderboardEntry entry in entries)
        {
            leaderboardText.text += rank + ". " + entry.name + ": " + entry.score + "\n";
            rank++;
        }
    }
    public void Exit()
    {
        panelScore.SetActive(false);
    }
}

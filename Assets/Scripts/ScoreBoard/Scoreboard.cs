using System.IO;
using UnityEngine;

namespace StellarByteStudios.Scoreboards
{
    public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardEntries = 10;
        [SerializeField] private Transform highscoresHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;

        [Header("Test")]
        [SerializeField] private string testEntryName = "New Name";
        [SerializeField] private int testEntryScore = 0;

        private string SavePath => $"{Application.persistentDataPath}/highscores(Release 1.0).json";

        private void Start()
        {
            //Alter Spielstand löschen
            File.Delete($"{Application.persistentDataPath}/highscores.json");

            
            ScoreboardSaveData savedScores = GetSavedScores();

            Debug.Log(Application.persistentDataPath);

            UpdateUI(savedScores);

            SaveScores(savedScores);

            if(ScoreData.getName() != null)
            {
                //AddScore(ScoreData.getName(), ScoreData.getScore());
                testEntryName = ScoreData.getName();
                testEntryScore = ScoreData.getScore();
                AddTestEntry();
                ScoreData.setName(null);
                ScoreData.setScore(0);
            }

            //AddScore("Eigener Adder 3", 700);
            //AddTestEntry();

        }

        [ContextMenu("Add Test Entry")]
        public void AddTestEntry()
        {
            AddEntry(new ScoreboardEntryData()
            {
                entryName = testEntryName,
                entryScore = testEntryScore
            });
        }

        //* * * Mein Eigener Adder * * *//
        public void AddScore(string name, int score)
        {
            AddEntry(new ScoreboardEntryData()
            {
                entryName = name,
                entryScore = score
            });
        }

        public void AddEntry(ScoreboardEntryData scoreboardEntryData)
        {
            ScoreboardSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            //Check if the score is high enough to be added.
            for (int i = 0; i < savedScores.highscores.Count; i++)
            {
                if (testEntryScore > savedScores.highscores[i].entryScore)
                {
                    savedScores.highscores.Insert(i, scoreboardEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            //Check if the score can be added to the end of the list.
            if (!scoreAdded && savedScores.highscores.Count < maxScoreboardEntries)
            {
                savedScores.highscores.Add(scoreboardEntryData);
            }

            //Remove any scores past the limit.
            if (savedScores.highscores.Count > maxScoreboardEntries)
            {
                savedScores.highscores.RemoveRange(maxScoreboardEntries, savedScores.highscores.Count - maxScoreboardEntries);
            }

            UpdateUI(savedScores);

            SaveScores(savedScores);
        }

        private void UpdateUI(ScoreboardSaveData savedScores)
        {
            foreach (Transform child in highscoresHolderTransform)
            {
                Destroy(child.gameObject);
            }

            foreach (ScoreboardEntryData highscore in savedScores.highscores)
            {
                Instantiate(scoreboardEntryObject, highscoresHolderTransform).GetComponent<ScoreboardEntryUI>().Initialise(highscore);
            }
        }

        private ScoreboardSaveData GetSavedScores()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreboardSaveData();
            }

            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<ScoreboardSaveData>(json);
            }
        }

        private void SaveScores(ScoreboardSaveData scoreboardSaveData)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreboardSaveData, true);
                stream.Write(json);
            }
        }
    }
}

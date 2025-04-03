public class Score
{
    private int _currentScore;
    private readonly ISaver _saver;

    public Score(ISaver saver)
    {
        _saver = saver;
        _currentScore = 0;
    }

    public void AddScore()
    {
        _currentScore++;
    }

    public void Save()
    {
        _saver.SaveScore(_currentScore);
    }

    public int GetScore() => _currentScore;
}
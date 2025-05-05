namespace oddOrEven;

public class Dice
{
    private int numberOfDices;
    private int eyes;
    private List<int> shownEyes = new List<int>();
    private int sum;
    private bool even;

    public Dice(int numberOfDices, int eyes)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        if (numberOfDices < 1)
            throw new ArgumentOutOfRangeException("Es muss mindestens einen Würfel geben!");
        else
            this.numberOfDices = numberOfDices;
        if (eyes < 2)
            throw new ArgumentOutOfRangeException("Hääää. Welcher Würfel hat nur 1 Seite oder weniger!?  Bist du dumm?");
        else
            this.eyes = eyes;
        Console.ResetColor();
    }

    public int NumberOfDices
    {
        set { numberOfDices = value; }
        get { return numberOfDices; }
    }
    
    public int Eyes
    {
        set { eyes = value; }
        get { return eyes; }
    }

    public List<int> ShownEyes { 
        get { return shownEyes; }
    }

    public int Sum
    {
        get { return sum; }
    }

    public bool Even
    {
        get { return even; }
    }

    private Random rndThrow = new Random();
    public void Roll()
    {
        shownEyes.Clear();
        sum = 0;
        for (int i = 0; i < numberOfDices; i++)
        {
            shownEyes.Add(rndThrow.Next(1, eyes+1));
            sum += shownEyes[i];
        }

        if (sum % 2 == 0)
            even = true;
        else
            even = false;
    }
}
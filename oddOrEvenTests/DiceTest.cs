using oddOrEven;

namespace oddOrEvenTests;

[TestFixture]
[TestOf(typeof(Dice))]
public class DiceTest
{

    [Test]
    public void Dice_ErstellenAnzahl()
    {
        // arrange
        int anzahlDice = 9;

        // act
        Dice diceTest = new Dice(anzahlDice, 6);

        // assert
        Assert.Equals(diceTest.NumberOfDices, anzahlDice);
    }
}
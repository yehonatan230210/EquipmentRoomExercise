using System;
using System.Reflection.Metadata;

// <summary>
//Todo: צרו מחלקת חריגים המטפלת במקרים בהם אין מספיק מחשבים זמינים להשאלה.
//שם המחלקה צריך להיות EquipmentUnavailableException.
class EquipmentUnavailableException : Exception
{
    private int numToBorrow;
    private int theDiffBetweenAmountAndAvailable;

    public int NumToBorrow
    {
        get 
        {
             return numToBorrow; 
        }
        set 
        {
            numToBorrow = value;
        }
    }
    public int TheDiffBetweenAmountAndAvailable
    {
        get 
        {
            return theDiffBetweenAmountAndAvailable; 
        }
        set 
        {
            theDiffBetweenAmountAndAvailable = value;
        }
    }
    public EquipmentUnavailableException(int numToBorrow, int theDiffBetweenAmountAndAvailable, String message) 
        : base(message)
    {
        this.NumToBorrow = numToBorrow;
        this.TheDiffBetweenAmountAndAvailable = theDiffBetweenAmountAndAvailable;

    }


}



class EquipmentRoom
{
    private int availableComputers;

    public int AvailableComputers
    {
        get
        {
            return availableComputers;
        }
        set
        {
            // TODO: יש לבדוק שמספר המחשבים אינו שלילי.
            // אם כן, יש לזרוק חריגה מתאימה.
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Availabe Computers can't be negetive.");
            }
            availableComputers = value;
        }
    }

    public EquipmentRoom(int amount)
    {
        AvailableComputers = amount;
    }

    public void Borrow(int amount)
    {
       
            // TODO: יש לזרוק חריגה מתאימה כאשר אין מספיק מחשבים זמינים.
            if(amount > AvailableComputers)
            {
                throw new EquipmentUnavailableException(amount,AvailableComputers - amount,"Not enough computers available.");
            }
        



        AvailableComputers -= amount;
        Console.WriteLine($"Borrowed successfully {amount} computers.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        int initialComputers = 10;
        try
        {
            EquipmentRoom room = new EquipmentRoom(initialComputers);

            // יצירת חדר מחשבים עם מספר מחשבים שלילי:
            // לאחר מימוש הבדיקה ב-set, יש לוודא שמצב כזה מטופל כראוי.
            // TODO: יש להוסיף try-catch מתאימים סביב הקריאות שעלולות לזרוק חריגה.
            // int negativeComputers = -5;
            // EquipmentRoom invalidRoom = new EquipmentRoom(negativeComputers);


            room.Borrow(4);
            Console.WriteLine("continue on...");
            
            room.Borrow(8);


            Console.WriteLine("availble computers " + room.AvailableComputers);
        }
        catch (EquipmentUnavailableException ex)
        {
            Console.WriteLine($"Exeption messege:  {ex.Message}, NumToBorrow: {ex.NumToBorrow}, TheDiff: {ex.TheDiffBetweenAmountAndAvailable}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

        
}

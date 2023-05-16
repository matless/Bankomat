using System;
public class CardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    Double balance;

    public CardHolder(String cardNum, int pin, String firstName, String lastName, Double balance)
    {

        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()

    {
        return pin;

    }
    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()

    {
        return lastName;
    }

    public Double getBalance()

    {
        return balance;


    }

    public void setNum(String newCardNum)

    {
        cardNum = newCardNum;

    }


    public void setPin(int newPin)

    {
        pin = newPin;
    }


    public void setFirstName(String newFirstName)

    {

        firstName = newFirstName;
    }


    public void setLastName(String newLastName)

    {

        lastName = newLastName;
    }



    public void setBalance(Double newBalance)

    {
        balance = newBalance;

    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Proszę wybrać jedną z opcji...");
            Console.WriteLine("1. Wpłać");
            Console.WriteLine("2. wypłać");
            Console.WriteLine("3. Pokaż stan konta");
            Console.WriteLine("4. Zakończ");

        }

        void wpłać(CardHolder currentUser)

        {
            Console.WriteLine("Ile pieniędzy chciałbyś/chciałabyś wpłacić? ");
            Double wpłać = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + wpłać);
            Console.WriteLine("Dziękuję za wpłatę. Twój obecny stan konta to:" + currentUser.getBalance());
        }

        void wypłać(CardHolder currentUser)

        {
            Console.WriteLine("Ile pieniędzy chciałbyś wypłacić? ");
            Double wypłać = Double.Parse(Console.ReadLine());
            if (currentUser.getBalance() < wypłać)

            {
                Console.WriteLine("Niewystarczająca ilość środków na koncie");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - wypłać);
                Console.WriteLine("Środki zostały wypłacone. Miłego dnia :) ");

            }
        }

        void psk(CardHolder currentUser)
        {
            Console.WriteLine("Stan konta to:" + currentUser.getBalance());


        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("1234567890", 1234, "Mateusz", "Nowak", 1345.45));
        cardHolders.Add(new CardHolder("0987654321", 4321, "Aleksandra", "Pasz", 2132.22));
        cardHolders.Add(new CardHolder("2543876568", 6534, "Tomasz", "Fijas", 1289.95));
        cardHolders.Add(new CardHolder("4937605839", 0045, "Aneta", "Skok", 3456.32));
        cardHolders.Add(new CardHolder("9946582345", 5524, "Albert", "Werner", 10023.77));

        //

        Console.WriteLine("Witamy w naszym Bankomacie :)");
        Console.WriteLine("Proszę włożyć karte: ");
        String debitCardNum = "";
        CardHolder currentUser;

        while (true)

        {
            try
            {

                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Karta nierozpoznana. Spróbuj jeszcze raz."); }
            }
            catch { Console.WriteLine("Karta nierozpoznana. Spróbuj jeszcze raz."); }

        }


        Console.WriteLine("Proszę wprowadzić pin: ");
        int userPin = 0;
        while (true)

        {
            try
            {

                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Karta nierozpoznana. Spróbuj jeszcze raz."); }
            }
            catch { Console.WriteLine("Karta nierozpoznana. Spróbuj jeszcze raz."); }

        }
        Console.WriteLine("Witaj " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { wpłać(currentUser); }
            else if (option == 2) { wypłać(currentUser); }
            else if (option == 3) { psk(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }

        }
        while (option != 4);
        Console.WriteLine("Dziękujemy i życzymy miłego dnia :)");
    }

}   


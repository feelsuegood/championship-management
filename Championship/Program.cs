using System;
using static System.Console;
namespace Championship
{
    class Athlete
    {
        //fields
        public static readonly char[] code_array = { 'T', 'B', 'S', 'R', 'G' };
        public static readonly string[] description_array = { "Tennis", "Badminton", "Swimming", "Running", "Gymnastics" };
        private char code;
        private string description;
        //properties
        public string Name { get; set; }
        public char Code
        {
            get { return code; }
            set
            {
                const char CODE_INVALID = 'I';
                int x;
                bool codeFound = false;
                for (x = 0; x < code_array.Length; ++x)
                {
                    if (value == code_array[x])
                    {
                        code = value;
                        codeFound = true;
                    }
                }
                if (codeFound == false)
                {
                    code = CODE_INVALID;
                }
                SetDescription();//call method to set description
            }
        }
        public string Description
        {
            get { return description; }//no set because it is read-only
        }
        //constructors
        public Athlete()
        {

        }
        public Athlete(string aname, char acode)
        {
            aname = Name;
            acode = Code;
        }
        public Athlete(string bname, char bcode, string bdescription)
        {
            bname = Name;
            bcode = Code;
            bdescription = Description;
        }
        //methods
        protected virtual void SetDescription()
        {
            const string DES_INVALID = "INVALID";
            int x;
            bool desFound = false;
            for (x = 0; x < code_array.Length; ++x)
            {
                if (Code == code_array[x])
                {
                    description = description_array[x];
                    desFound = true;
                }
            }
            if (desFound == false)
            {
                description = DES_INVALID;
            }
        }//method ends
    }//end of class

    class Championship
    {
        public static void Main()
        {
            int x;
            int participants = GetParticipants();//call method to set the number of participants
                                                 //Athlete[] athletesArray = new Athlete[participants];
                                                 //RevenueCal(participants);//call method to display revenue
                                                 //for (x = 0; x < athletesArray.Length; x++)
                                                 //{
                                                 //athletesArray[x].Name = GetName(x);//call method to set the name of participants
                                                 //athletesArray[x].Code = GetCodeCategories(x);//call method to set the code of participants
                                                 //}
                                                 //DisplayAll(participants);
                                                 //char index_code = FindCode();



        }

        public static int GetParticipants()
        {
            const int MIN_PAR = 0, MAX_PAR = 30;
            int par;
            Write("Please enter the number of participant(s) in this year's championship>> ");
            while (!(int.TryParse(ReadLine(), out par)))//check integer
            {
                Write("Invaild value. Please input **number** between 0 and 30>> ");
            }
            while (!(par >= MIN_PAR && par <= MAX_PAR))
            {
                Write("Invaild value. Please input number between **0 and 30**.");
                while (!(int.TryParse(ReadLine(), out par)))//check integer
                {
                    Write("Invaild value. Please input **number** between 0 and 30>> ");
                }
            }
            return par;
        }

        public static void RevenueCal(int participants)
        {
            const int COST = 20;
            participants = 0;
            int rev = participants * COST;
            WriteLine("The total revenue is {0:C}.", rev);
        }
        public static string GetName(int x)
        {
            Write("Please enter the name of the no.{0} participant>> ", x + 1);
            return ReadLine();
        }
        public static char GetCodeCategories(int x)
        {
            const char CODE_INVALID = 'I';
            int n;
            char inputchar;
            Write("Please enter the code of the no.{0} participant>> ", x + 1);
            for (n = 0; n < Athlete.code_array.Length; n++)
            {
                WriteLine("The Event Code {0}: " + Athlete.code_array[n] + " The Category {0}: " + Athlete.description_array[n], n + 1 + ".");
            }

            while (!char.TryParse(ReadLine(), out inputchar))//check char
            {
                WriteLine("Invaild value. Please input one character and a valid code.");
                Write("Please enter the code of the no.{0} participant>> ", x + 1);
                for (n = 0; n < Athlete.code_array.Length; n++)
                {
                    WriteLine("The Event Code {0}: " + Athlete.code_array[n] + " The Category {0}: " + Athlete.description_array[n], n + 1 + ".");
                }
                char.TryParse(ReadLine(), out inputchar);
            }
            return inputchar;
        }
        public static void DisplayAll(int par)
        {
            int x, y;

            Athlete[] athletesArray = new Athlete[par];
            char inputchar;
            string inputstring;
            const char CODE_INVALID = 'I';
            const string DES_INVALID = "INVALID";
            for (x = 0; x < par; x++)
            {
                WriteLine("no.{0} participant name: {1}, code: {2}, names of events: {3}.",
                    x + 1, athletesArray[x].Name, athletesArray[x].Code, athletesArray[x].Description);
            }
        }
        public static char FindCode()
        {
            const char CODE_INVALID = 'I';
            int n, m, l;
            char inputchar;
            char code = 'o';
            bool codeFound = false;

            for (n = 0; n < Athlete.code_array.Length; n++)
            {
                WriteLine("The Event Code {0}: " + Athlete.code_array[n] + " The Category {0}: " + Athlete.description_array[n], n + 1 + ".");
            }//display valid event categories
            Write("Please enter the code you want to know>> ");
            while (!char.TryParse(ReadLine(), out inputchar))//check char
            {
                WriteLine("Invaild value. Please input one character and a valid code.");
                for (n = 0; n < Athlete.code_array.Length; n++)
                {
                    WriteLine("The Event Code {0}: " + Athlete.code_array[n] + " The Category {0}: " + Athlete.description_array[n], n + 1 + ".");
                }
                Write("Please enter the code you want to know>> ");//check invalid
                char.TryParse(ReadLine(), out inputchar);
            }

            for (m = 0; m < Athlete.code_array.Length && !codeFound; m++)
            {
                if (inputchar == Athlete.code_array[m])
                {
                    inputchar = Athlete.code_array[m];
                    codeFound = true;
                }
            }
            while (!codeFound)
            {
                WriteLine("Invaild value. Please input one character and a valid code.");
                for (n = 0; n < Athlete.code_array.Length; n++)
                {
                    WriteLine("The Event Code {0}: " + Athlete.code_array[n] + " The Category {0}: " + Athlete.description_array[n], n + 1 + ".");
                }
                Write("Please enter the code you want to know>> ");//check invalid
                char.TryParse(ReadLine(), out inputchar);
                for (m = 0; m < Athlete.code_array.Length && !codeFound; m++)
                {
                    if (inputchar == Athlete.code_array[m])
                    {
                        inputchar = Athlete.code_array[m];
                        codeFound = true;
                    }
                }
            }
            return inputchar;
        }
        public static void DisplayCategory(string n)
        {

        }
        //end of class
    }
}

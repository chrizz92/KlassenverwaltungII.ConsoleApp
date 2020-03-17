/**************************************************************************************************************************
 *  
 *  Übungsnr.:		25
 *	Programmname:	KlassenverwaltungII
 *	Autor:			Christian SCHADLER
 *	Klasse:			4ABIF
 *	Datum:			17.03.2020
 *	
 *	-----------------------------------------------------------------------------------------------------------------------
 *	Verbesserungsmoeglichkeit/en:	
 *  -----------------------------------------------------------------------------------------------------------------------
 *  Kurzbeschreibung:
 *	
 *	Eine einfache Schulklassenverwaltung. Die Daten eines einzelnen Schülers sind in einer eigenen Klasse Pupil mit den
 *	Feldern _catalogNr, _firstName, _lastName, _zipCode gespeichert.
 *  Die Schüler sind in einem Array vom Typ der Klasse Pupil mit der maximalen Anzahl von 40 gespeichert.
 *  Über ein Menü in der Main-Methode können mehrere Funktionen zur Bearbeitung oder persistenten Speicherung des Arrays
 *  aufgerufen werden. Ist beim Programmstart im Programmverzeichnis eine Datei namens pupils.csv enthalten werden diese
 *  Daten in das pupils-Array geladen.
 *  
 **************************************************************************************************************************
 */


using System;
using System.IO;
using System.Text;

namespace KlassenverwaltungII
{
    class Program
    {
        /// <summary>
        /// A private method that waits for users keypress before the programm goes on 
        /// </summary>
        private static void Acknowledge()
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.Write("Bitte beliebige Taste zum Fortfahren drücken . . .");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Takes a reference of an array of pupil and an index where a new pupil should be inserted.
        /// Calls a private method to create a new pupil and inserts the reference of the object at the given index of the array.
        /// </summary>
        /// <param name="pupils"></param>
        /// <param name="pupilsIndex"></param>
        public static void AddNewPupilToPupilsArray(ref Pupil[] pupils, ref int pupilsIndex)
        {
            pupils[pupilsIndex] = CreateNewPupil();
            pupilsIndex++;
            Acknowledge();
        }

        /// <summary>
        /// A private method that creates a new instances of the class pupil and calls the 4 Set-Methods of the created object. 
        /// </summary>
        /// <returns>The created pupil object</returns>
        private static Pupil CreateNewPupil()
        {
            Console.Clear();
            Pupil pupil = new Pupil();
            Console.Write("Bitte Katalog-Nr. eingeben:{0,16}", " ");
            pupil.SetCatalogNr(Convert.ToInt32(Console.ReadLine()));
            Console.Write("Bitte Vornamen eingeben:{0,19}", " ");
            pupil.SetFirstName(Console.ReadLine());
            Console.Write("Bitte Nachnamen eingeben:{0,18}", " ");
            pupil.SetLastName(Console.ReadLine());
            Console.Write("Bitte Postleitzahl des Wohnortes eingeben:{0,1}", " ");
            pupil.SetZipCode(Convert.ToInt32(Console.ReadLine()));
            return pupil;
        }

        /// <summary>
        /// A private method that takes an array of pupil and checks how many indices are actually filled with a object reference.
        /// </summary>
        /// <param name="pupils"></param>
        /// <returns>The number of pupil references</returns>
        private static int GetLengthOfPupilArrayWithoutNull(ref Pupil[] pupils)
        {
            int length = 0;
            for (int i = 0; i < pupils.Length; i++)
            {
                if (pupils[i] != null)
                {
                    length++;
                }
            }
        
            return length;
        }

        /// <summary>
        /// Takes the reference of an array of pupil and sorts the pupil objects in the array by their "_catalogNr"-field in ascending order
        /// </summary>
        /// <param name="pupils"></param>
        public static void BubbleSortPupilsArrayByCatalogNr(ref Pupil[] pupils)
        {
            Console.Clear();
            bool aPupilHasSwapped;
            Pupil temp;
            int length = GetLengthOfPupilArrayWithoutNull(ref pupils);

            do
            {
                aPupilHasSwapped = false;
                for (int i = 0; i < length - 1; i++)
                {
                    if (pupils[i].GetCatalogNr() > pupils[i + 1].GetCatalogNr())
                    {
                        temp = pupils[i];
                        pupils[i] = pupils[i + 1];
                        pupils[i + 1] = temp;
                        aPupilHasSwapped = true;
                    }
                }
                length = length - 1;

            } while (aPupilHasSwapped);

            Console.WriteLine("Sortierung nach KatalogNr abgeschlossen.");
            Acknowledge();
        }

        /// <summary>
        /// Takes the reference of an array of pupil and sorts the pupil objects in the array by their "_lastName"-field in ascending order.
        /// </summary>
        /// <param name="pupils"></param>
        public static void BubbleSortPupilsArrayByLastName(ref Pupil[] pupils)
        {
            Console.Clear();
            bool aPupilHasSwapped;
            Pupil temp;
            int length = GetLengthOfPupilArrayWithoutNull(ref pupils);
            int stringComparisonResult;


            do
            {
                aPupilHasSwapped = false;
                for (int i = 0; i < length - 1; i++)
                {
                    stringComparisonResult = String.Compare(pupils[i].GetLastName(), pupils[i + 1].GetLastName());
                    if (stringComparisonResult == 1)
                    {
                        temp = pupils[i];
                        pupils[i] = pupils[i + 1];
                        pupils[i + 1] = temp;
                        aPupilHasSwapped = true;
                    }
                }
                length = length - 1;

            } while (aPupilHasSwapped);

            Console.WriteLine("Sortierung nach Nachnamen abgeschlossen.");
            Acknowledge();
        }

        /// <summary>
        /// A private method that prints out a table header for a table of pupil objects
        /// </summary>
        private static void PrintOutTableHeader()
        {
            string tableHeader = string.Format("{0,10} | {1,-20} | {2,-20} | {3,5}", "Katalog-Nr", "Vorname", "Nachname", "Plz");
            Console.Clear();
            Console.WriteLine(tableHeader);
            for (int i = 0; i < tableHeader.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Takes the reference of an array of pupil and prints out a table of all included pupil objects
        /// </summary>
        /// <param name="pupils"></param>
        public static void PrintOutPupilsArray(ref Pupil[] pupils)
        {
            int length = GetLengthOfPupilArrayWithoutNull(ref pupils);
            PrintOutTableHeader();
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("{0,10} | {1,-20} | {2,-20} | {3,5}", pupils[i].GetCatalogNr(), pupils[i].GetFirstName(), pupils[i].GetLastName(), pupils[i].GetZipCode());
            }

            Acknowledge();
        }

        /// <summary>
        /// Takes the reference of an array of pupil and prints out a table of all pupil objects where the "_lastName"-field equals an asked lastname
        /// </summary>
        /// <param name="pupils"></param>
        public static void PrintOutPupilIfLastNameMatches(ref Pupil[] pupils)
        {
            int length = GetLengthOfPupilArrayWithoutNull(ref pupils);
            string lastName;
            Console.Write("Welcher Nachname?: ");
            lastName = Console.ReadLine().ToLower().Trim();

            PrintOutTableHeader();
            for (int i = 0; i < length; i++)
            {
                if (lastName == pupils[i].GetLastName().ToLower().Trim())
                {
                    Console.WriteLine("{0,10} | {1,-20} | {2,-20} | {3,5}", pupils[i].GetCatalogNr(), pupils[i].GetFirstName(), pupils[i].GetLastName(), pupils[i].GetZipCode());
                }
            }

            Acknowledge();
        }

        /// <summary>
        /// A private method that takes a reference of an integer array with zipcodes and an integer with a zipcode and checks if the given integer is in the array or not.
        /// </summary>
        /// <param name="usedZipCodes"></param>
        /// <param name="zipCodeToCheck"></param>
        /// <returns>true if the zipCodeToCheck is in the array, else the method returns false</returns>
        private static bool HasZipCodeUsedBefore(ref int[] usedZipCodes, int zipCodeToCheck)
        {
            bool hasZipCodeUsedBefore = false;
            for (int i = 0; i < usedZipCodes.Length; i++)
            {
                if (zipCodeToCheck == usedZipCodes[i])
                {
                    hasZipCodeUsedBefore = true;
                }
            }
            return hasZipCodeUsedBefore;
        }

        /// <summary>
        /// Takes the reference of an array of pupil and prints for every "_zipCode"-field-value of the pupil objects out how often it occures  
        /// </summary>
        /// <param name="pupils"></param>
        public static void PrintOutZipCodeStatistic(ref Pupil[] pupils)
        {
            Console.Clear();
            int length = GetLengthOfPupilArrayWithoutNull(ref pupils);
            int zipCode;
            int counter;
            int[] usedZipCodes = new int[length];
            for (int i = 0; i < length; i++)
            {
                counter = 0;
                zipCode = pupils[i].GetZipCode();

                if (HasZipCodeUsedBefore(ref usedZipCodes, zipCode))
                {

                }
                else
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (zipCode == pupils[j].GetZipCode())
                        {
                            counter++;
                        }
                    }
                    Console.WriteLine("In PLZ {0} wohnen {1,3} Schüler!", zipCode, counter);
                    usedZipCodes[i] = zipCode;
                }
            }

            Acknowledge();
        }


        /// <summary>
        /// Takes the reference of an array of pupil and writes the containing data into the File pupils.csv in the programm directory
        /// </summary>
        /// <param name="pupils"></param>
        public static void WritePupilsToFile(ref Pupil[] pupils)
        {
            Console.Clear();
            string[] textToWrite = new string[GetLengthOfPupilArrayWithoutNull(ref pupils)];
            
            for (int i = 0; i < textToWrite.Length; i++)
            {
                    textToWrite[i] = $"{pupils[i].GetCatalogNr()};{pupils[i].GetFirstName()};{pupils[i].GetLastName()};{pupils[i].GetZipCode()}";             
            }

            File.WriteAllLines("pupils.csv",textToWrite, Encoding.UTF8);

            Console.WriteLine("Die Daten wurden in die Datei pupils.csv geschrieben");
            Acknowledge();

            /* ALTERNATIVE
             
            for (int j = 0; j < GetLengthOfPupilArrayWithoutNull(ref pupils); j++)
            {
                File.AppendAllText("pupils.csv", $"{pupils[j].GetCatalogNr()};{pupils[j].GetFirstName()};{pupils[j].GetLastName()};{pupils[j].GetZipCode()}\n", Encoding.UTF8);
            } 
            
            */
        }

        /// <summary>
        /// Takes the reference of an array of pupil and the reference of pupilsIndex. The Method asks for a catalognumber and searches in the pupils-Array for it.
        /// If a pupil with the given catalognumber is found, all following pupils will move left by one step, so the found pupil will be overwritten.
        /// Then the pupilsIndex will be decreased by one.
        /// </summary>
        /// <param name="pupils"></param>
        /// <param name="pupilsIndex"></param>
        public static void DeletePupilFromPupilsArray(ref Pupil[] pupils, ref int pupilsIndex)
        {
            int arrayLength = pupilsIndex;
            int arrayLengthBeforeDeleting = arrayLength;
            int catalogNr;
            Console.Clear();
            Console.Write("Bitte Katalog-Nr eingeben: ");
            catalogNr = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < arrayLength; i++)
            {
                if(pupils[i].GetCatalogNr() == catalogNr)
                {
                    for (int j = i; j < arrayLength; j++)
                    {
                        if (j != arrayLength - 1)
                        {
                            pupils[j] = pupils[j + 1];
                        }
                        else
                        {
                            pupils[j] = null;
                        }
                    }
                    arrayLength--;
                    pupilsIndex--;
                }
            }

            if (arrayLengthBeforeDeleting == arrayLength)
            {
                Console.WriteLine("Es gibt keinen Schüler mit dieser Katalog-Nr");
            }
            else
            {
                Console.WriteLine("Der Schüler wurde aus der Liste gelöscht");
            }

            Acknowledge();

        }



        static void Main(string[] args)
        {
            int menuNr;
            int pupilsIndex = 0;
            int maxPupils = 40;
            Pupil[] pupils = new Pupil[maxPupils];

            if (File.Exists("pupils.csv"))
            {
                string[] fileContent = File.ReadAllLines("pupils.csv");
                string[] lineContent;
                pupilsIndex = fileContent.Length;
                for (int i = 0; i < pupilsIndex; i++)
                {
                    lineContent = fileContent[i].Split(';');
                    pupils[i] = new Pupil();
                    pupils[i].SetCatalogNr(Convert.ToInt32(lineContent[0]));
                    pupils[i].SetFirstName(lineContent[1]);
                    pupils[i].SetLastName(lineContent[2]);
                    pupils[i].SetZipCode(Convert.ToInt32(lineContent[3]));
                }
            }


            do
            {
                Console.WriteLine("MENÜ:");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("1: Neuen Schüler anlegen");
                Console.WriteLine("2: Liste nach Katalognummer sortieren");
                Console.WriteLine("3: Liste nach Nachnamen sortieren");
                Console.WriteLine("4: Ausgabe der Liste");
                Console.WriteLine("5: Schüler nach Nachnamen suchen");
                Console.WriteLine("6: Schüler je Postleitzahl ausgeben");
                Console.WriteLine("7: Schüler in person.csv speichern");
                Console.WriteLine("8: Schüler aus Liste löschen");
                Console.WriteLine("0: ENDE");
                Console.WriteLine("-------------------------------------");
                Console.Write("Menüpunkt auswählen: ");
                menuNr = Convert.ToInt32(Console.ReadLine());

                switch (menuNr)
                {
                    case 1:
                        if (pupilsIndex < pupils.Length)
                        {                   
                            AddNewPupilToPupilsArray(ref pupils, ref pupilsIndex);
                        }
                        else
                        {
                            Console.WriteLine("Die Klasse hat das Maximum von 40 Schülern erreicht!");
                            Acknowledge();
                            Console.Clear();
                        }
                        break;
                    case 2:
                        BubbleSortPupilsArrayByCatalogNr(ref pupils);
                        break;
                    case 3:
                        BubbleSortPupilsArrayByLastName(ref pupils);
                        break;
                    case 4:
                        PrintOutPupilsArray(ref pupils);
                        break;
                    case 5:
                        PrintOutPupilIfLastNameMatches(ref pupils);
                        break;
                    case 6:
                        PrintOutZipCodeStatistic(ref pupils);
                        break;
                    case 7:
                        WritePupilsToFile(ref pupils);
                        break;
                    case 8:
                        DeletePupilFromPupilsArray(ref pupils, ref pupilsIndex);
                        break;
                    case 0:
                        //EXIT PROGRAM
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe! Bitte nur Zahlen zwischen 0 und 8 eingeben.");
                        Console.Write("Bitte beliebige Taste zum Fortfahren drücken . . .");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            } while (menuNr != 0);
        }
    }
}

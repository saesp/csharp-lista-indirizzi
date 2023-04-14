//In questo esercizio dovrete leggere un file CSV e salvare tutti gli indirizzi contenuti al sul interno all’interno di una lista di oggetti istanziati a partire dalla classe Indirizzo.
//Attenzione: gli ultimi 3 indirizzi presentano dei possibili “casi particolari” che possono accadere a questo genere di file: vi chiedo di pensarci e di gestire come meglio crediate queste casistiche.

using csharp_lista_indirizzi;

List <Address> addresses = new List<Address> ();
void OpenFile()
{
    var textFile = File.OpenText("addresses.csv");

    Console.WriteLine("ADDRESSES");

    // !textFile.EndOfStream  (finchè non finisce il testo del file)
    for (int i = 0; i < textFile.BaseStream.Length; i++ )
    { 
        string line = textFile.ReadLine();

        if (line != null && i != 0 && i <= 4)
        {
            string[] data = line.Split(','); //Split() si usa per suddividere una stringa in più pezzi in base al 'separatore' che si sceglie (in questo caso la virgola)

            Console.WriteLine($"{data[2]}, {data[3]}, {data[4]}, {data[5]}");
            addresses.Add(new Address(data[2], data[3], data[4], data[5]));

        }

        else if (i == 5)
        {
            string[] data = line.Split(',');

            Console.WriteLine($"{data[3]}, {data[4]}, {data[5]}, {data[6]}");
            addresses.Add(new Address(data[3], data[4], data[5], data[6]));

        }

        else if (i == 6)
        {
            string[] data = line.Split(',');
            for (int index = 0; index<data.Length; index++)
            {
                if (string.IsNullOrWhiteSpace(data[index])) //string.IsNullOrWhiteSpace() si usa per gestire le variabili null, vuote ("") o con solo spazi ("   ")
                {
                    data[index] = "/";
                }
            }

            Console.WriteLine($"{data[2]}, {data[3]}, {data[4]}, {data[5]}");
            addresses.Add(new Address(data[2], data[3], data[4], data[5]));
        }

        //7
        else if (i == 7)
        {
            string[] data = line.Split(',');

            for (int index = 0; index < data.Length; index++)
                data[index] = data[index].Trim(); //Trim() si usa per la conversione delle stringhe con cifre e spazi ("  jjj ") in stringhe con cifre senza spazi ("jjj")

            Console.WriteLine($"{data[0]}, {data[1]}, {data[2]}, {data[3]}");
            addresses.Add(new Address(data[0], data[1], data[2], data[3]));
        }
    }

    textFile.Close();

}

OpenFile();












//addresses.Add(new Address(""));


//if (!File.Exists("dati\\utenti.txt"))
//    Console.WriteLine("File non trovato!");
//else
//{
//    try
//    {
//        StreamReader readFile = File.OpenText("dati\\utenti.txt");  //apro il file in lettura (nella stessa cartella dell'eseguibile)

//        while (!readFile.EndOfStream)      //finché ci sono dati da leggere
//        {
//            string? line = readFile.ReadLine();   //leggo una riga dal file
//            if (line != null)
//            {
//                string[] campi = line.Split(' ');   //suddividi la stringa in più pezzi usando lo spazio come separatore
//                Console.WriteLine("UTENTE:");
//                Console.WriteLine($"\tNome: {campi[0]}");
//                Console.WriteLine($"\tCognome: {campi[1]}");
//                Console.WriteLine($"\tData di nascita: {campi[2]}");
//                addresses.Add(new Address(campi[0], campi[1], DateOnly.ParseExact(campi[2], "d")));
//            }

//        }
//        readFile.Close();     //chiudo il file
//    }
//    catch (UnauthorizedAccessException)
//    {
//        Console.WriteLine("Non hai i diritti di accesso al file");
//    }
//    catch (Exception e)
//    {

//        Console.WriteLine("Si è verificato un problema: " + e.Message);
//    }
//}

//StreamWriter sw = File.CreateText("output.txt");
//sw.WriteLine("prova1");
//sw.WriteLine("prova2");
//sw.Close();
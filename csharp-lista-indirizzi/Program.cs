//In questo esercizio dovrete leggere un file CSV e salvare tutti gli indirizzi contenuti al sul interno all’interno di una lista di oggetti istanziati a partire dalla classe Indirizzo.
//Attenzione: gli ultimi 3 indirizzi presentano dei possibili “casi particolari” che possono accadere a questo genere di file: vi chiedo di pensarci e di gestire come meglio crediate queste casistiche.


using csharp_lista_indirizzi;

List <Address> addresses = new List<Address> ();
void OpenFile()
{
    try { 
        var textFile = File.OpenText("addresses.csv");

        Console.WriteLine("ADDRESSES");
    
        //!textFile.EndOfStream  (finchè non finisce il testo del file)
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
            
            else if (i == 7)
            {
                string[] data = line.Split(',');

                for (int index = 0; index < data.Length; index++)
                    data[index] = data[index].Trim(); //Trim() si usa per la conversione delle stringhe con cifre e spazi ("  jjj ") in stringhe con cifre senza spazi ("jjj")

                Console.WriteLine($"{data[0]}, {data[1]}, {data[2]}, {data[3]}");
                addresses.Add(new Address(data[0], data[1], data[2], data[3]));
            }
        }

        textFile.Close(); //Close() chiude il file
    }

    catch (NullReferenceException e)
    {
        Console.WriteLine("Si è verificato un problema specifico: " + e.Message);
    }

    catch (Exception e)
    { 
        Console.WriteLine("Errore generico: " + e.Message);
    }
}

OpenFile();
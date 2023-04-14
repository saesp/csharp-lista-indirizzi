//In questo esercizio dovrete leggere un file CSV e salvare tutti gli indirizzi contenuti al sul interno all’interno di una lista di oggetti istanziati a partire dalla classe Indirizzo.
//Attenzione: gli ultimi 3 indirizzi presentano dei possibili “casi particolari” che possono accadere a questo genere di file: vi chiedo di pensarci e di gestire come meglio crediate queste casistiche.

using csharp_lista_indirizzi;

List <Address> addresses = new List<Address> ();
void OpenFile()
{
    var textFile = File.OpenText("addresses.csv");

    Console.WriteLine("ADDRESSES");

    while (!textFile.EndOfStream)
    {
        string line = textFile.ReadLine();

        if (line != null)
        {
            string[] data = line.Split(','); //suddividi la stringa in più pezzi usando la virgola come separatore
            Console.WriteLine($"{data[2]}, {data[3]}, {data[4]}, {data[5]}");
            addresses.Add(new Address(data[2], data[3], data[4], data[5]));
        }
    }

    textFile.Close();
}

OpenFile();


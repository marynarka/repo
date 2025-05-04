StreamReader reader1 = new StreamReader("klucz.txt");
string[] klucz = reader1.ReadLine().Split();
int[] pomoc1 = new int[klucz.Length];
for(int i = 0; i < klucz.Length; i++)
{
    pomoc1[i] = int.Parse(klucz[i]);
}
reader1.Close();
StreamReader reader = new StreamReader("odpowiedzi.txt");
StreamWriter writer = new StreamWriter("wyniki.txt");
Random random = new Random();
int losowanie = random.Next(0, File.ReadAllLines("odpowiedzi.txt").Length);
int linijka = 0;
string wylosowanaLinia = null;
while (!reader.EndOfStream)
{
    string[] line = reader.ReadLine().Split();
    int[] pomoc = new int[line.Length - 2];
    for (int i = 2; i < line.Length; i++)
    {
        pomoc[i - 2] = int.Parse(line[i]);
    }
    float dobra = 0;
    for (int i = 0; i < pomoc.Length; i++)
    {
        if (pomoc[i] == pomoc1[i])
        {
            dobra++;
        }
    }
    float wynik = dobra / pomoc.Length * 100;
    if(linijka == losowanie)
    {
        if (wynik + 5 != 100)
        {
            wynik += 5;
            wylosowanaLinia = line[0];
        }
    }
        string nazwisko_rodo = line[1][0] + new string('-', line[1].Length - 4) + line[1].Substring(line[1].Length - 3);
    writer.WriteLine($"{line[0][0]} {nazwisko_rodo} {(int)wynik}%");
    linijka++;
}
Console.WriteLine($"Wylosowana osoba:{wylosowanaLinia}");
reader.Close();
writer.Close();
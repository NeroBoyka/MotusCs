using System.Text;

namespace Motus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> listeMots = ChargerMots("mots.txt");
            bool replay = true;
            string replayAnswer = "";

            while (replay)
            {
                Console.WriteLine("Bienvenue dans Motus\n");
                string motCache = ChoisirMot(listeMots).ToUpper();
                int tailleMotCache = motCache.Length;

                //Console.WriteLine(motCache); // pour test

                Console.WriteLine($"Le mot caché contient {tailleMotCache} caractères et commence par {motCache[0]}\n");

                for (int i = 6; i >= 1; i--)
                {
                    Console.WriteLine($"Il vous reste {i} coups a jouer");
                    string motSaisie = GetMot(tailleMotCache);
                    
                    TestMot(motCache, motSaisie);

                    if (motCache == motSaisie)
                    {
                        Console.WriteLine($"\nBravo vous avez gagné, le mot caché était: {motCache}\n");
                        break;
                    }
                    else if(motCache != motSaisie)
                    {
                        if (i == 1)
                        {
                            Console.WriteLine($"Désole vous avez perdu ! Le mot caché était : {motCache}");
                        }
                    }

                    Console.WriteLine();
                }

                // boucle pour verifier que la replayAnswer donnee est valable
                while (true)
                {
                    Console.WriteLine("Voulez vous rejouer? (o / n)");
                    replayAnswer = Console.ReadLine().ToLower();
                    if(replayAnswer == "oui" || replayAnswer == "o")
                    {
                        replay = true;
                        Console.WriteLine();
                        break;
                    }
                    else if (replayAnswer == "non" || replayAnswer == "n")
                    {
                        replay = false;
                        Console.WriteLine();
                        break;
                    }
                }
            }
        }

        static void AfficherCouleur(char texte, ConsoleColor couleur)
        {
            Console.ForegroundColor = couleur;
            Console.Write(texte);

            Console.ForegroundColor = ConsoleColor.White;
        }

        static String GetMot(int lenMot)
        {
            string inputWord = "";

            while (inputWord.Length != lenMot)
            {
                Console.WriteLine("Entrez un mot de " + lenMot + " caractères: ");
                inputWord = Console.ReadLine().ToUpper();
            }

            return inputWord;
        }

        static int GetNombreAleatoire(int min, int max)
        {
            Random rand = new Random();
            int randomValue = rand.Next(min, max);

            return randomValue;
        }

        static List<string> ChargerMots(String fileName)
        {
            string mots = File.ReadAllText(fileName);
            List<string> listeMots = mots.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Where(mot => mot.Length >= 6 && mot.Length <= 8).ToList();

            return listeMots;
        }

        static String ChoisirMot(List<String> mots)
        {
            return mots[GetNombreAleatoire(0, mots.Count)];
        }

        static void TestMot(String motCache, String motSaisie)
        {
            Console.Write ("Votre mot contient: ");

            for (int i = 0; i < motCache.Length; i++)
            {
                if (motSaisie[i] == motCache[i])
                {
                    AfficherCouleur(motSaisie[i], ConsoleColor.Red);
                }
                else
                {
                    if (motCache.Contains(motSaisie[i]))
                    {
                        AfficherCouleur(motSaisie[i], ConsoleColor.Yellow);
                    }
                    else
                    {
                        Console.Write(motSaisie[i]);
                    }
                }
            }
            Console.WriteLine();
        }


    }
}

using System.Text;

namespace Motus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(GetMot(5));
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
                Console.WriteLine("Entrez un mot de " + lenMot + " caracteres: ");
                inputWord = Console.ReadLine().ToLower();
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

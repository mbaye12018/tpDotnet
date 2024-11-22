using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("👋 Bienvenue dans le convertisseur entier -> hexadécimal !");
        List<(int entier, string hex)> historique = new List<(int, string)>();
        bool continuer = true;

        while (continuer)
        {
            try
            {
                // Demander un entier
                Console.Write("\nEntrez un entier positif à convertir en hexadécimal (ou tapez 'q' pour quitter) : ");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    continuer = false;
                    break;
                }

                // Vérification de la saisie
                if (!int.TryParse(input, out int nombre) || nombre < 0)
                    throw new ArgumentException("⚠️ Veuillez entrer un entier positif valide.");

                // Conversion en hexadécimal
                string hexValue = ConvertirEnHexadecimal(nombre);

                // Afficher le résultat
                Console.WriteLine($"✔️ La valeur hexadécimale de {nombre} est : {hexValue}");

                // Ajouter à l'historique
                historique.Add((nombre, hexValue));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"😅 Oups : {ex.Message}");
            }
        }

        // Afficher l'historique des conversions
        AfficherHistorique(historique);

        Console.WriteLine("\nMerci d'avoir utilisé le convertisseur. À bientôt ! 😊");
    }

    // Méthode pour convertir un entier en hexadécimal
    static string ConvertirEnHexadecimal(int nombre)
    {
        if (nombre == 0) return "0";

        string hex = "";
        string hexChars = "0123456789ABCDEF";

        while (nombre > 0)
        {
            int reste = nombre % 16;
            hex = hexChars[reste] + hex; // Ajouter le caractère correspondant au début
            nombre /= 16;
        }

        return hex;
    }

    // Méthode pour afficher l'historique des conversions
    static void AfficherHistorique(List<(int entier, string hex)> historique)
    {
        Console.WriteLine("\n📝 Historique des conversions :");

        if (historique.Count == 0)
        {
            Console.WriteLine("Aucune conversion effectuée.");
        }
        else
        {
            Console.WriteLine("\nVoici la liste de toutes les conversions :");
            foreach (var item in historique)
            {
                Console.WriteLine($"- Entier : {item.entier} => Hexadécimal : {item.hex}");
            }
        }
    }
}

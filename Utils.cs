using System;

namespace Calculator
{
    public static class Utils
    {
        public static int LerInteiro(string msg){
            Console.Write(msg);
            
            int numero;
            while (!int.TryParse(Console.ReadLine(), out numero)){
                Console.Write("Entrada inválida, digite novamente: ");
            }
            return numero;
        }

        public static double LerDouble(string msg){
            Console.Write(msg);
            
            double numero;
            while (!double.TryParse(Console.ReadLine(), out numero)){
                Console.Write("Entrada inválida, digite novamente: ");
            }
            return numero;
        }

        public static (string, int, int, int) EquacaoSegundoGrau(int a, int b, int c){
            int delta = b * b - 4 * a * c; // Calcula o valor de delta
            if (delta < 0){
                Console.WriteLine("Delta negativo, raizes inexistentes.");
            }
            
            int raiz1 = (int)Math.Round(( - b + Convert.ToSingle(Math.Sqrt(delta))) / (2.0 * a)); // Calcula a primeira raiz
            int raiz2 = (int)Math.Round(( - b - Convert.ToSingle(Math.Sqrt(delta))) / (2.0 * a)); // Calcula a segunda raiz
            string operacao = "\nDelta: " + b + "^2-4*" + a + "*" + c +"" +
                                "\nRaiz1: (-" + b + "+Sqrt(" + delta + "))/2*" + a + ""+
                                "\nRaiz2: (-" + b + "-Sqrt(" + delta + "))/2*" + a + "";
            return (operacao, delta, raiz1, raiz2);
        }
    }
}
using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {         
            bool continuar = true;
            
            Console.WriteLine("-------Bem Vindo a Calculator-------");
            do{
                double resultado = 0; // armazena o resultado
                string operacao; // armazena a operacao feita
                int raiz1 = 0, raiz2 = 0, delta = 0;
                int operacaoOption;
                
                Console.WriteLine("\n-------Operações-------");
                Console.WriteLine("1- Soma\n2- Subtração\n3- Multiplicação\n4- Divisão\n"+
                            "5- Exponenciação\n6- Raiz Quadrada\n7- Equação do Segundo Grau\n");
                operacaoOption = Utils.LerInteiro("Qual operação deseja fazer: ");
                
                if (operacaoOption == 7){
                    int aCoeficiente, bCoeficiente, cCoeficiente;

                    Console.Write("Digite o coeficiente 'a' (a != 0): ");
                    while (!int.TryParse(Console.ReadLine(), out aCoeficiente) || aCoeficiente == 0){
                        Console.Write("Entrada inválida, digite novamente: ");
                    }
                    
                    bCoeficiente = Utils.LerInteiro("Digite o coeficiente 'b': ");
                    cCoeficiente = Utils.LerInteiro("Digite o coeficiente 'c': ");

                    (operacao, delta, raiz1, raiz2) = Utils.EquacaoSegundoGrau(aCoeficiente, bCoeficiente, cCoeficiente);
                    if (delta < 0){
                        operacao = "\nDelta negativo, raizes inexistentes" + operacao;
                    }
                }else{
                    double n1;

                    n1 = Utils.LerDouble("Digite um número: ");

                    if (operacaoOption == 6){
                        operacao = "Sqrt(" + n1 + ")";
                        resultado = Convert.ToSingle(Math.Sqrt(n1));
                    }else if (operacaoOption == 5){
                        int nExpoente;

                        nExpoente = Utils.LerInteiro("Digite o expoente: ");
                        operacao = n1 + "^" + nExpoente; resultado = Math.Pow(n1, nExpoente);
                    }else{
                        double n2;
                        n2 = Utils.LerDouble("Digite o próximo número: ");

                        switch (operacaoOption){
                            case 1: operacao = n1 + "+" + n2; resultado = n1 + n2; break;
                            case 2: operacao = n1 + "-" + n2; resultado = n1 - n2; break;
                            case 3: operacao = n1 + "*" + n2; resultado = n1 * n2; break;
                            case 4: 
                                if (n2 != 0){
                                    operacao = n1 + "/" + n2; resultado = n1 / n2; break;
                                }else{
                                    Console.WriteLine("Divisão por zero não permitida, tente novamente"); continue;
                                }
                            default: Console.WriteLine("Opção inválida, tente novamente"); continue;
                        }
                    }
                } 
                Console.WriteLine("\n-------Resultado-------");
                Console.WriteLine("Operações: " + operacao);
                if (operacaoOption != 7){
                    Console.WriteLine("Resultado: " + resultado);
                }else{
                    Console.WriteLine("Resultado: (" + raiz1 + "," + raiz2 + ")");
                }

                string? continuarOption;
                do{
                    Console.Write("\nDeseja continuar (s/n): ");
                    continuarOption = Console.ReadLine();
                }while(continuarOption != "s" && continuarOption != "n");            

                switch (continuarOption){
                    case "s": continuar = true; Console.Clear(); break;
                    case "n": continuar = false; Console.WriteLine("Fim do programa!"); break;
                    default: Console.WriteLine("Opção inválida, tente novamente"); continue;
                }      
            }while(continuar); 
        }
    }
}
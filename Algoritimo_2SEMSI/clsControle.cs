using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritimo_2SEMSI
{
    public static class ClsControle
    {
        public static bool ValidarMatriz(string tam, out int eixoX, out int eixoY)
        {
            // Remove o x que o usuario digitou e valida posição por posição. exemplo 3x3
            string[] tm = tam.Split('x');
            eixoX = 0; eixoY = 0;
            if(tm.Length != 2)
            {
                Console.WriteLine("Matriz Invalida! por favor tente novamente!");
                return false;
            }
            else
            {
                //Errou? digita de novo
                return int.TryParse(tm[0], out eixoX) && int.TryParse(tm[1], out eixoY);
            }
        }

        // Calculo triangular, calcula os valores de X', X'' e X''';
        public static void Calcular(double[,] matriz)
        {
            double b = matriz[matriz.GetLength(0) - 1, matriz.GetLength(1) - 1];
            double a = matriz[matriz.GetLength(0) - 1, matriz.GetLength(1) - 2];
            double resultado = b / a;

            double[] resultados = new double[matriz.GetLength(0)];
            resultados[matriz.GetLength(0) - 1] = resultado;
            for (int i = matriz.GetLength(0) -1; i > 0; i--)
            {
                double soma = 0;

                for(int j = i+1; j < matriz.GetLength(1); j++)
                {
                    soma = soma + resultados[j - 1] * matriz[i - 1, j - 1];
                }
                resultados[i - 1] = (matriz[i - 1, matriz.GetLength(1) - 1] - soma) / matriz[i - 1, i - 1];
            }

            for(int i = 0; i < resultados.Length; i++)
            {
                Console.WriteLine($"    x{i + 1}={resultados[i]}");
            }
            Console.WriteLine("\n\n");
        }

        public static void CalculoEliminatorio(double[,] matriz)
        {
            // Para evitar conflitos entre as variaveis, os contadores de cada for["para"], foram
            // nomeados de "i", "j", "k")
            Console.WriteLine("\n");
            DesenharMatriz(matriz);
            for(int k = 0; k < matriz.GetLength(0)-1; k++)
            {
                for (int i = k + 1; i < matriz.GetLength(1) - 1; i++)
                {
                    double pivo = matriz[i, k] / matriz[k, k]; 
                    matriz[i, k] = 0;
                    for(int j = k+1; j < matriz.GetLength(1); j++)
                    {
                        // Encontra o valor referente a posição
                        matriz[i, j] = matriz[i, j] - pivo * matriz[k, j];
                    }
                }
                // Desenha a matriz completa, e o processo de eliminação das linhas
                DesenharMatriz(matriz);
                Console.WriteLine("\n");
            }
            // Zerando os valores fazendo a triangulação de "0" ele executa o calculo triangular
            Calcular(matriz);
        }
        public static void DesenharMatriz(double[,] matriz)
        {
            if(matriz.Length > 0)
            {
                //Apresenta a matriz
                string desenhoMatriz = null;
                for(int i = 0; i < matriz.GetLength(0); i++)
                {
                    for(int j = 0; j < matriz.GetLength(1); j++)
                    {
                        string valor = matriz[i, j].ToString();
                        bool negativo = matriz[i, j] < 0;

                        if (valor.Replace("-", String.Empty).Length == 1)
                            if (negativo)
                                desenhoMatriz += $"  -00{valor.Replace("-", String.Empty)}";
                            else
                                desenhoMatriz += $"   00{valor.Replace("-", String.Empty)}";

                        if (valor.Replace("-", String.Empty).Length == 2)
                            if (negativo)
                                desenhoMatriz += $"  -0{valor.Replace("-", String.Empty)}";
                            else
                                desenhoMatriz += $"   0{valor.Replace("-", String.Empty)}";

                        if (valor.Replace("-", String.Empty).Length >= 3)
                            if (negativo)
                                desenhoMatriz += $"  -{valor.Replace("-", String.Empty)}";
                            else
                                desenhoMatriz += $"   {valor.Replace("-", String.Empty)}";
                    }
                    desenhoMatriz += "\n";                    
                }
                Console.WriteLine(desenhoMatriz);
            }
        }
    }
}

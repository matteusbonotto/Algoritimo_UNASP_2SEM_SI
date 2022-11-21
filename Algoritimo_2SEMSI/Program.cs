using System;

namespace Algoritimo_2SEMSI
{
    class Program
    {
        ///////////////////////   UNASP   ///////////////////////////
        //                                                         //
        //  Aluno: Matheus ALves Bonotto Santos | 2º Semetre       //
        //  Professora: Thais Michelli Stori da Silva              //
        //  Curso: Calculo computacional em Sistemas de informação //
        //                                                         //
        ///////////////////////   2022   ////////////////////////////
        
        
        // Sistema baseado nos arquivo disponibilizado pela professora no portal AVA UNASP
        // sobre algoritimo para sistemas lineares   
        private static void Inicio()
        {
            Console.WriteLine("##############################################################################################################");
            Console.WriteLine("#                                            Inicio do Algoritimo                                            #");
            Console.WriteLine("# (!) Os processos seram todo aqui pelo terminal, por favor siga o passo a passo para realizar as operações. #");
            Console.WriteLine("##############################################################################################################\n");

            Console.WriteLine("##############################################################################");
            Console.WriteLine("#                                  (!) Dica                                  #");
            Console.WriteLine("# DIgite primeiro o numero de colunas, depois o de linhas.[colunas]x[linhas] #");
            Console.WriteLine("# Exemplo: 3x3, 5x4,10x10, etc.                                              #");
            Console.WriteLine("##############################################################################\n");
        }

        static void Main(string[] args)
        {
            //Inicia o processamento dos dados
            ProcessarDados();
        }
        private static void ProcessarDados()
        {
            // Apresenta como deve ser executado os processos no console e pergunta qual o tamanho da matriz
            Inicio();

            // O usuario deve escrever a matriz, se passar na validação é exibido na tela qual será a matriz calculada
            // e iniciamos o calculo dela.
            Console.WriteLine("Digite o numero de colunas, e de linhas da matriz [Colunas]x[linhas]: ");
            var tamanhoMatriz = Console.ReadLine();

            bool continuar = true;
            while (continuar)
            {
                // Valida se o usuario digitou a matriz corretamente

                if(ClsControle.ValidarMatriz(tamanhoMatriz.ToLower(), out int eixoX, out int eixoY))
                {
                    // E Lê os numeros digitados formando a matriz para os calculos
                    double[,] matriz = new double[eixoY, eixoX];
                    Console.WriteLine($"# A matriz digitada foi {eixoX} colunas e {eixoY} Linhas\n");

                    Console.WriteLine("##########################################################################################");
                    Console.WriteLine("#                                       (!) Dica                                         #");
                    Console.WriteLine("# Digite linha a linha da matriz separando os valores por virgula                        #");
                    Console.WriteLine("# Se os valores forem decimais digite com ponto ao invés de virgula (\",\") --> (\".\")  #");
                    Console.WriteLine("##########################################################################################\n");

                    for(int i =0; i < eixoY; i++)
                    {
                        bool ValidarLinha = true;
                        while (ValidarLinha)
                        {
                            // Pergunta qual os valores das respectivas linhas da matriz
                            Console.WriteLine($"{i +1}ª linha: ");
                            var linha = Console.ReadLine();
                            var linhas = linha.Split(",");

                            if (linhas.Length == eixoX)
                            {
                                bool ValidarValores = false;

                                for (int j = 0; j < linhas.Length; j++)
                                {
                                    ValidarValores = double.TryParse(linhas[j], out matriz[i, j]);
                                    if (!ValidarValores)
                                        break;
                                }
                                ValidarLinha = !ValidarValores;
                            }
                            else
                            {
                                // Digitando um valor invalido o aviso aparece.
                                Console.WriteLine("#################################################################################");
                                Console.WriteLine("# (X) Valores invalidos, por favor digite corretamente os valores solicitados... #");
                                Console.WriteLine("#################################################################################\n");
                            }
                        }
                    }
                    // Chama o calculo por eliminação de Gauss
                    ClsControle.CalculoEliminatorio(matriz);
                    continuar = false;
                }
                else
                {
                    //Retorna para o inicio
                    Console.WriteLine("##############################################################################");
                    Console.WriteLine("#                                  (!) Dica                                  #");
                    Console.WriteLine("# DIgite primeiro o numero de colunas, depois o de linhas.[colunas]x[linhas] #");
                    Console.WriteLine("# Exemplo: 3x3, 5x4,10x10, etc.                                              #");
                    Console.WriteLine("##############################################################################\n");
                    tamanhoMatriz = Console.ReadLine();
                }
            }
        }
    }
}

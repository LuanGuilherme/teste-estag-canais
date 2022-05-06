using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using teste_estag_canais.Classes;

namespace teste_estag_canais {

    class Program {

        static void Main(string[] args){

            IEnumerable<string> linhas = File.ReadLines(@"./my_program/entrada.txt").Skip(2).Take(7);

            foreach (string linha in linhas) {

                string[] entradas = linha.Split('|');

                Transferencia NovaTransferencia = new Transferencia(
                    int.Parse(entradas[0]),
                    double.Parse(entradas[1]),
                    entradas[2]
                    );

                Conta Emissor = new Conta(entradas[3], entradas[4], entradas[5], entradas[6], 500);

                Conta Receptor = new Conta(entradas[7], entradas[8], entradas[9], entradas[10], 0);

                NovaTransferencia.FazTransferencia(Emissor, Receptor);

                Console.WriteLine();

            }

        }

    }

}

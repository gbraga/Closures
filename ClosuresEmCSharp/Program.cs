using System;

namespace ClosuresEmCSharp
{
    class Program
    {
        /*
         *  O método Main() chama o método DefineClosure() para inicializar a closure antes de executá-la.
         *  A variável inteira é criada e inicializada e então usada dentro da closure.
         *  Após a conclusão do método DefineClosure, esta variável inteira sai do escopo.
         *  No entanto, ainda estamos invocando o delegate depois que isso acontecer.
         *  Isso é o CLOSURE em ação.
         *  A VARIAVEL naoLocal foi capturada (capturou a variavel e não o seu valor) pelo código do delegate,
         *  fazendo com que ela permaneça no escopo além dos limites normais.
         *  Na verdade ela permanecerá disponível até que as outras referências ao delegate permaneçam.
         *  
         *  Funcionou, mas na verdade os Closures não tem um suporte no .NET Framework.
         *  O que realmente acontece é que nos bastidores ocorre o trabalho do compilador.
         *  Quando você constrói o seu projeto, o compilador gera uma nova classe oculta, 
         *  que encapsula as variáveis não locais e o código que você inclui no método ou expressão lambda anônimo.
         *  Este novo método da classe é chamado quando o delegate for executado.
         *  
         * */

        static Action closure;

        static void Main(string[] args)
        {
            Console.WriteLine("Estudando o uso de 'closures' para melhor entender e resolver o DRY.\n\n\tClosures eh um conceito geralmente associado com as linguagens de programação funcionais que vinculam uma funcao ao seu ambiente de referencia, permitindo o acesso a variaveis fora do escopo da funcao, ou seja, eh uma funcao que tem acesso a variaveis de uma funcao exterior.");
            Console.WriteLine("\tNa linguagem C# podemos usar Closures usando delegates a partir de metodos anonimos ou expressoes lambdas. Isso tras grande flexibilidade quando usamos delegates.");

            DefineClosure();
            closure();
            closure();
            closure();
            closure();
            closure();

            Console.ReadKey();
        }

        private static void DefineClosure()
        {
            int naoLocal = 1;
            closure = () =>
            {
                Console.WriteLine("\n{0} + 1 = {1}\n", naoLocal, naoLocal++);
            };
        }

        /*
         * Os exemplos abaixo são outros usos idênticos de como fazer em C#.
         * 
         * public Person FindById(int id)
         * {
         *  return this.Find(delegate(Person p)
         *  {
         *   return p.id == id;
         *  }
         * }
         * 
         * public Person FindById(int id) => this.Find(p => p.Id == id);
         * 
         * 
         * */
    }
}

using PDapperONGAdocoes.Models;
using PDapperONGAdocoes.Service;
using System;
using System.Data.SqlClient;
using System.Threading;

namespace PDapperONGAdocoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int op = 0;
            int opc = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu Principal:");
                Console.WriteLine("1 - Menu Manter Pessoas");
                Console.WriteLine("2 - Menu Manter Animais");
                Console.WriteLine("3 - Menu de Adoções");
                Console.WriteLine("0 - Sair do Programa");

                Console.Write("Opção: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        Console.WriteLine("Você saiu do Menu Principal!");
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.Clear();
                        opc = 0;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Menu Pessoas:");
                            Console.WriteLine("1 - Cadastrar Pessoa");
                            Console.WriteLine("2 - Atualizar Cadastro de Pessoa");
                            Console.WriteLine("3 - Mostrar Pessoas Cadastradas");
                            Console.WriteLine("4 - Remover Pessoa Cadastrada");
                            Console.WriteLine("0 - Voltar Menu Principal");
                            Console.Write("Opção: ");
                            opc = int.Parse(Console.ReadLine());

                            switch (opc)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.Clear();
                                    Console.Write("Informe o Nome: ");
                                    string nome = Console.ReadLine();
                                    Console.Write("Informe o CPF: ");
                                    string cpf = Console.ReadLine();

                                    bool verifSexo = true;
                                    char sexo;
                                    do
                                    {
                                        Console.Write("Informe o Sexo. M / F : ");
                                        sexo = char.Parse(Console.ReadLine().ToUpper());

                                        if (sexo != 'M' && sexo != 'F')
                                        {
                                            Console.WriteLine("Voce inseriu um sexo inválido!");
                                            verifSexo = false;
                                        }
                                        else
                                            verifSexo = true;

                                    } while (verifSexo == false);

                                    Console.Write("Informe a Data de Nascimento: ");
                                    DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
                                    dataNascimento.ToShortDateString();
                                    Console.Write("Informe Telefone para Contato: ");
                                    string telefone = Console.ReadLine();

                                    Pessoa pessoa = new Pessoa(nome, cpf, sexo, dataNascimento, telefone);

                                    new PessoaService().Add(pessoa);

                                    Console.WriteLine("Pessoa adicionada com Sucesso!");
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.Write("Informe o CPF da Pessoa que deseja alterar o Cadastro: ");
                                    string atualizarCPF = Console.ReadLine();

                                    pessoa = new PessoaService().GetOne(atualizarCPF);

                                    if (pessoa != null)
                                    {
                                        op = 0;
                                        do
                                        {
                                            Console.WriteLine(pessoa.ToString());
                                            Console.WriteLine("\nInforme a opcao que deseja alterar: ");
                                            Console.WriteLine(" 1 - Nome");
                                            Console.WriteLine(" 2 - Sexo");
                                            Console.WriteLine(" 3 - Data de Nascimento");
                                            Console.WriteLine(" 4 - Telefone");
                                            Console.WriteLine(" 0 - Sair");
                                            Console.Write(" Informe a opcao: ");
                                            op = int.Parse(Console.ReadLine());


                                            switch (op)
                                            {
                                                case 1:
                                                    string parametroNome = "Nome";
                                                    Console.Write("Informe o novo nome: ");
                                                    string novoNome = Console.ReadLine();

                                                    new PessoaService().Update(atualizarCPF, parametroNome, novoNome);

                                                    Console.WriteLine("Nome alterado com secesso!");
                                                    Console.ReadKey();
                                                    break;

                                                case 2:
                                                    string parametroSexo = "Sexo";
                                                    verifSexo = true;
                                                    char novosexo;
                                                    do
                                                    {
                                                        Console.Write("Informe o Sexo. M / F : ");
                                                        novosexo = char.Parse(Console.ReadLine().ToUpper());

                                                        if (novosexo != 'M' && novosexo != 'F')
                                                        {
                                                            Console.WriteLine("Voce inseriu um sexo inválido!");
                                                            verifSexo = false;
                                                        }
                                                        else
                                                            verifSexo = true;

                                                    } while (verifSexo == false);

                                                    new PessoaService().Update(atualizarCPF, parametroSexo, novosexo.ToString());

                                                    Console.WriteLine("Sexo alterado com secesso");
                                                    Console.ReadKey();
                                                    break;

                                                case 3:
                                                    string parametroData = "DataNascimento";
                                                    Console.Write("Informe a nova data de nascimento: ");
                                                    DateTime novaData = DateTime.Parse(Console.ReadLine());

                                                    new PessoaService().Update(atualizarCPF, parametroData, novaData.ToString());

                                                    Console.WriteLine("Data de nascimento alterada com secesso!");
                                                    Console.ReadKey();
                                                    break;

                                                case 4:
                                                    string parametroTelefone = "Telefone";
                                                    Console.Write("Informe o novo telefone: ");
                                                    string novoTelefone = Console.ReadLine();

                                                    new PessoaService().Update(atualizarCPF, parametroTelefone, novoTelefone);

                                                    Console.WriteLine("Telefone alterado com secesso!");
                                                    Console.ReadKey();
                                                    break;
                                                default:
                                                    Console.Write("\n Opcao Inválida! Aperte ENTER para executar novamente.");
                                                    Console.ReadKey();
                                                    break;
                                                case 0:
                                                    break;
                                            }
                                            Console.Clear();
                                        } while (op != 0);
                                    }

                                    else
                                        Console.WriteLine("Não foi encontrado cadastro com o CPF informado!");
                                    break;
                                case 3:
                                    Console.Clear();
                                    foreach (var item in new PessoaService().GetAll())
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Clear();
                                    foreach (var item in new PessoaService().GetAll())
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.Write("\nInforme o CPF da Pessoa que será removida: ");
                                    string cpfRemove = Console.ReadLine();

                                    if (new PessoaService().Delete(cpfRemove))
                                        Console.WriteLine("Pessoa removida com Sucesso!");
                                    else
                                        Console.WriteLine("CPF da Pessoa não foi encontrado!");
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opção Inválida!");
                                    Thread.Sleep(2000);
                                    break;
                            }

                        } while (opc != 0);
                        break;

                    case 2:
                        Console.Clear();
                        opc = 0;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Menu Animais:");
                            Console.WriteLine("1 - Cadastrar Animal");
                            Console.WriteLine("2 - Atualizar Cadastro de Animal");
                            Console.WriteLine("3 - Mostrar Animais Cadastrados");
                            Console.WriteLine("4 - Remover Animal Cadastrado");
                            Console.WriteLine("0 - Voltar Menu Principal");
                            Console.Write("Opção: ");
                            opc = int.Parse(Console.ReadLine());

                            switch (opc)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.Clear();
                                    Console.Write("Informe a Familia do Animal: ");
                                    string familia = Console.ReadLine();
                                    Console.Write("Informe a Raça do Animal: ");
                                    string raca = Console.ReadLine();

                                    bool verifSexo = true;
                                    char sexo;
                                    do
                                    {
                                        Console.Write("Informe o Sexo do Animal. M / F : ");
                                        sexo = char.Parse(Console.ReadLine().ToUpper());

                                        if (sexo != 'M' && sexo != 'F')
                                        {
                                            Console.WriteLine("Voce inseriu um sexo inválido!");
                                            verifSexo = false;
                                        }
                                        else
                                            verifSexo = true;

                                    } while (verifSexo == false);

                                    Console.Write("Informe o Nome do Animal: ");
                                    string nomeAnimal = Console.ReadLine();

                                    Animal animal = new Animal(familia, raca, sexo, nomeAnimal);


                                    new AnimalService().Add(animal);

                                    Console.WriteLine("Animal adicionado com Sucesso!");
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.Write("Informe o Número do CHIP do animal que irá ser atualizado: ");
                                    int atualizarChip = int.Parse(Console.ReadLine());

                                    animal = new AnimalService().GetOne(atualizarChip);

                                    if (animal != null)
                                    {
                                        op = 0;
                                        do
                                        {
                                            Console.WriteLine(animal.ToString());

                                            Console.WriteLine("\nInforme a opcao que deseja alterar: ");
                                            Console.WriteLine(" 1 - Familia");
                                            Console.WriteLine(" 2 - Raça");
                                            Console.WriteLine(" 3 - Sexo");
                                            Console.WriteLine(" 4 - Nome do animal");
                                            Console.WriteLine(" 0 - Sair");
                                            Console.Write(" Informe a opcao: ");
                                            op = int.Parse(Console.ReadLine());

                                            switch (op)
                                            {
                                                case 1:
                                                    string parametro = "Familia";
                                                    Console.Write("Informe a nova familia: ");
                                                    string novaFamilia = Console.ReadLine();

                                                    new AnimalService().Update(atualizarChip, parametro, novaFamilia);

                                                    Console.WriteLine("Familia alterada com secesso!");
                                                    Console.ReadKey();
                                                    break;

                                                case 2:
                                                    parametro = "Raca";
                                                    Console.Write("Informe a nova raça: ");
                                                    string novaRaca = Console.ReadLine();

                                                    new AnimalService().Update(atualizarChip, parametro, novaRaca);

                                                    Console.WriteLine("Raça alterado com secesso!");
                                                    Console.ReadKey();
                                                    break;

                                                case 3:
                                                    parametro = "Sexo";
                                                    verifSexo = true;
                                                    char novosexo;
                                                    do
                                                    {
                                                        Console.Write("Informe o Sexo do Animal. M / F : ");
                                                        novosexo = char.Parse(Console.ReadLine().ToUpper());

                                                        if (novosexo != 'M' && novosexo != 'F')
                                                        {
                                                            Console.WriteLine("Voce inseriu um sexo inválido!");
                                                            verifSexo = false;
                                                        }
                                                        else
                                                            verifSexo = true;

                                                    } while (verifSexo == false);

                                                    new AnimalService().Update(atualizarChip, parametro, novosexo.ToString());

                                                    Console.WriteLine("Sexo alterado com secesso!");
                                                    Console.ReadKey();
                                                    break;

                                                case 4:
                                                    parametro = "Nome";
                                                    Console.Write("Informe o novo nome: ");
                                                    string novoNome = Console.ReadLine();

                                                    new AnimalService().Update(atualizarChip, parametro, novoNome);

                                                    Console.WriteLine("Nome alterado com secesso!");
                                                    Console.ReadKey();
                                                    break;

                                                default:
                                                    Console.Write("\n Opcao Inválida! Aperte ENTER para executar novamente.");
                                                    Console.ReadKey();
                                                    break;
                                                case 0:
                                                    break;
                                            }
                                            Console.Clear();
                                        } while (op != 0);
                                    }
                                    else
                                        Console.WriteLine("Não foi encontrado nenhum Animal com este CHIP!");
                                    break;
                                case 3:
                                    Console.Clear();
                                    foreach (var item in new AnimalService().GetAll())
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Clear();
                                    foreach (var item in new AnimalService().GetAll())
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.Write("\nInforme o Chip do Animal que será removido: ");
                                    int chipRemove = int.Parse(Console.ReadLine());

                                    if (new AnimalService().Delete(chipRemove))
                                        Console.WriteLine("Animal removido com Sucesso!");
                                    else
                                        Console.WriteLine("Chip do animal não foi encontrado!");
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opção Inválida!");
                                    Thread.Sleep(2000);
                                    break;
                            }

                        } while (opc != 0);
                        break;
                    case 3:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Menu Adoções");
                            Console.WriteLine("1 - Cadastrar Adoção");
                            Console.WriteLine("2 - Mostrar Adoções de Animais");
                            Console.WriteLine("3 - Remover Adoção de Animal");
                            Console.WriteLine("0 - Voltar Menu Principal");
                            Console.Write("Opção: ");
                            opc = int.Parse(Console.ReadLine());
                            switch (opc)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.Clear();
                                    foreach (var item in new PessoaService().GetAll())
                                    {
                                        Console.WriteLine(item);
                                    }

                                    Console.Write("\nInforme o CPF do Adotante: ");
                                    string cpf = Console.ReadLine();

                                    Pessoa pessoa = new PessoaService().GetOne(cpf);

                                    if (pessoa != null)
                                    {
                                        foreach (var item in new AnimalService().GetAll())
                                        {
                                            Console.WriteLine(item);
                                        }

                                        Console.Write("\nInforme o Chip do Animal que será Adotado: ");
                                        int chip = int.Parse(Console.ReadLine());

                                        Animal animal = new AnimalService().GetOne(chip);

                                        if (animal != null)
                                        {
                                            Adocoes adocoes = new Adocoes(cpf, chip);

                                            new AdocoesService().Add(adocoes);

                                            Console.WriteLine("Adoção cadastrada com Sucesso!");
                                        }
                                        else
                                            Console.WriteLine("Não foi encontrado nenhum animal com este Chip!");
                                    }
                                    else
                                        Console.WriteLine("Não foi encontrado nenhum cadastro com este CPF!");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Clear();
                                    foreach (var item in new AdocoesService().GetAll())
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Clear();
                                    foreach (var item in new AdocoesService().GetAll())
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.Write("\nInforme o ID da adoção que será removida: ");
                                    int idRemove = int.Parse(Console.ReadLine());

                                    if (new AdocoesService().Delete(idRemove))
                                        Console.WriteLine("Adoção removida com Sucesso!");
                                    else
                                        Console.WriteLine("ID da adoção não foi encontrado!");
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.Clear();
                                    break;
                            }
                        } while (opc != 0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção Inválida!");
                        Thread.Sleep(2000);
                        break;
                }
            } while (true);
        }
    }
}

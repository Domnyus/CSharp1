using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person
            string[] Full_Name = { "", "" };
            int Age = -1;
            string ID_Document = "", Address = "";
            //Account
            double Money_Savings = 0, Transaction = 0;
            bool Allow_Deposit = true;
            string Password = "admin";


            //Menu
            int Menu_Option = -1;
            int Menu_Language = 0;

            //
            string[] Menu_Options = 
            {
                "Menu\n1 - Criar Usuário\n2 - Ler Usuário\n3 - Excluir Usuário\n4 - Depositar\n5 - Mudar Senha\n6 - Desabilitar\\Habilitar Depósito\n7 - Mudar Língua/Change Language\n8 - Limpar console\n-1 - Sair",
                "Menu\n1 - Create User\n2 - Read User\n3 - Delete User\n4 - Deposit\n5 - Change Password\n6 - Disable\\Enable Deposit\n7 - Mudar Língua/Change Language\n8 - Clear console\n-1 - Quit"
            };
            //
            string[,] Menu_Feedback = { { "Opção Inválida", "Invalid Option" }, { "Senha Incorreta", "Wrong Password" }, { "Tentativas excedidas, desabilitando depósitos.", "Attempts exceeded, disabling deposits." }, { "Nenhum usuário cadastrado corretamente", "No user registered correctly" } };

            //
            string[,] Language_Create_User =
            {
                { "Digite o nome do usuário\n" , "Digite o sobrenome do usuário\n", "Digite a idade do usuário\n", "Digite número do documento do usuário\n", "Digite o endereço do usuário\n", "Digite o saldo inicial do usuário\n", "Digite o valor da transação (digite \"-valor\" para saque)\n", "Digite a senha\n" },
                { "Enter user's name\n" , "Enter user's last name\n", "Enter user's age\n", "Enter user's document number\n", "Enter user's address\n ", "Enter the user's initial balance\n", "Enter the transaction amount (type \"-value\" for withdrawal)\n", "Enter the password\n" }
            };
            //
            string[,] Language_Delete_User = { { "Certeza em excluir o usuário? Digite y para sim e n para não.", "Sure to delete the user? Type y for yes and n for no." }, { "Digite a senha para excluir.", "Type the password to delete." } };
            //
            string[,] Language_Change_Password = { { "Certeza em mudar a senha do usuário? Digite y para sim e n para não.", "Sure to change the user's password? Type y for yes and n for no." }, { "Digite a senha antiga.", "Enter the old password." }, { "Digite a senha nova.", "Enter the new password." } };
            //
            string[,] Language_Deposit =
            {
                    { "Certeza em mudar a capacidade do usuário de depositar? Digite y para sim e n para não.", "Sure to change the user's ability to deposit?? Type y for yes and n for no." },
                    { "Digite a senha.", "Enter the password." },
                    { "Depósitos habilitados.", "Enabled deposits." },
                    { "Depósitos desabilitados", "Unabled deposits." },
                    { "Digite o valor do depósito. (digite -valor para saque).", "Enter the deposit amount. (type -value for withdrawal)." }
            };
            //
            string[,] System_Feedback = { { "Fechando aplicação", "Closing application" }, { "Operação cancelada.", "Operation cancelled." }, { "Sucesso!", "Success!" } };
            //
            string[,] Language_Options = { { "A sua língua atual é PORTUGUÊS, deseja alterar para INGLÊS? Digite y para sim e n para não.", "Your current language is ENGLISH, would you like to change to PORTUGUESE? Type y for yes and n for no." } };
            //
            string[,] Deposit_Feedback = { { "Saque maior que o saldo. Favor tente novamente.", "Withdraw greater than the balance. Please try again." }, { "Saques desabilitados. Favor, habilite os depósitos na opção menu de número 6.", "Withdrawals disabled. Please enable deposits in menu option number 6." } };

            do
            {
                Menu_Option = -1;
                Console.WriteLine(Menu_Options[Menu_Language]);
                Menu_Option = Convert.ToInt32(Console.ReadLine()) | 0;


                switch (Menu_Option)
                {
                    /**
                     * Read person and account data
                     */
                    case 1:
                        //
                        Console.WriteLine(Language_Create_User[Menu_Language, 0]);
                        Full_Name[0] = Console.ReadLine();
                        Console.WriteLine(Language_Create_User[Menu_Language, 1]);
                        Full_Name[1] = Console.ReadLine();

                        //
                        Console.WriteLine(Language_Create_User[Menu_Language, 2]);
                        Age = Convert.ToInt32(Console.ReadLine());

                        //
                        Console.WriteLine(Language_Create_User[Menu_Language, 3]);
                        ID_Document = Console.ReadLine();
                        Console.WriteLine(Language_Create_User[Menu_Language, 4]);
                        Address = Console.ReadLine();

                        //
                        Console.WriteLine(Language_Create_User[Menu_Language, 5]);
                        Money_Savings = Convert.ToDouble(Console.ReadLine());
                        if (Allow_Deposit)
                        {
                            Console.WriteLine(Language_Create_User[Menu_Language, 6]);
                            Transaction = Convert.ToDouble(Console.ReadLine());
                        }

                        int Attempts = 3;

                        //Check password
                        do
                        {
                            Console.WriteLine(Language_Create_User[Menu_Language, 7]);
                            string Pass = Console.ReadLine();


                            if (Pass == Password)
                            {
                                //Not negative savings
                                if (Money_Savings + Transaction >= 0)
                                {
                                    Money_Savings += Transaction;
                                    Transaction = 0;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine(Deposit_Feedback[0, Menu_Language]);
                                    Attempts++;
                                    Transaction = 0;

                                    Console.WriteLine(Language_Create_User[Menu_Language, 6]);
                                    Transaction = Convert.ToDouble(Console.ReadLine());
                                    Console.Clear();
                                }
                            }
                            else
                            {
                                Attempts--;
                                Console.WriteLine(Menu_Feedback[1, Menu_Language]);
                            }
                        } while (Attempts > 0);

                        if (Attempts <= 0)
                        {
                            Allow_Deposit = false;
                            Console.WriteLine(Menu_Feedback[2, Menu_Language]);
                            Transaction = 0;
                        }

                        Menu_Option = 0;
                        Console.Clear();
                        break;

                        /**
                         * Read the user data
                         */
                    case 2:
                        Console.Clear();
                        if (Full_Name[0] != "" && Full_Name[1] != "" && Age != -1 && ID_Document != "" && Address != "")
                        {
                            Console.WriteLine($"{Full_Name[0]} {Full_Name[1]} {Age} {ID_Document} {Address} {Money_Savings}");
                        }
                        else
                        {
                            Console.WriteLine(Menu_Feedback[3, Menu_Language]);
                        }
                        break;

                        /**
                         * Delete user's data
                         */
                    case 3:

                        Console.Clear();
                        Attempts = 3;
                        do
                        {
                            Console.WriteLine(Language_Delete_User[0, Menu_Language]);
                            string Confirmation = Console.ReadLine().ToLower().Trim();
                            if (Confirmation == "y")
                            {
                                Console.WriteLine(Language_Delete_User[1, Menu_Language]);
                                string Pass = Console.ReadLine();

                                if (Pass == Password)
                                {
                                    Full_Name[0] = "";
                                    Full_Name[1] = "";
                                    Age = -1;
                                    ID_Document = "";
                                    Address = "";
                                    Money_Savings = 0;
                                    Allow_Deposit = false;
                                    Password = "admin";
                                    Transaction = 0;
                                    Console.WriteLine(System_Feedback[2, Menu_Language]);
                                    break;
                                }
                                else
                                {
                                    Attempts--;
                                    Console.WriteLine(Menu_Feedback[1, Menu_Language]);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(System_Feedback[1, Menu_Language]);
                                break;
                            }
                        } while (Attempts > 0);

                        if (Attempts <= 0)
                        {
                            Allow_Deposit = false;
                            Console.WriteLine(Menu_Feedback[2, Menu_Language]);
                            Transaction = 0;
                        }

                        break;

                        /**
                         * Make a transaction
                         */
                    case 4:
                        Attempts = 3;
                        
                        if (Full_Name[0] == "" || Full_Name[1] == "" || Age == -1 && ID_Document == "" || Address == "")
                        {
                            Console.Clear();
                            Console.WriteLine(Menu_Feedback[3, Menu_Language]);
                            break;
                        }


                        do
                        {
                            if (!Allow_Deposit)
                            {
                                Console.Clear();
                                Console.WriteLine(Language_Deposit[3, Menu_Language]);
                            }
                            else
                            {
                                Console.WriteLine(Language_Deposit[1, Menu_Language]);
                                string Pass = Console.ReadLine();
                                if (Pass == Password)
                                {
                                    Console.WriteLine(Language_Deposit[4, Menu_Language]);
                                    Transaction = Convert.ToDouble(Console.ReadLine());

                                    if (Money_Savings + Transaction >= 0)
                                    {
                                        Money_Savings += Transaction;
                                        Transaction = 0;
                                        Console.Clear();
                                        Console.WriteLine(System_Feedback[2, Menu_Language]);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine(Deposit_Feedback[0, Menu_Language]);
                                        Attempts++;
                                        Transaction = 0;

                                        Console.WriteLine(Language_Create_User[Menu_Language, 6]);
                                    }
                                }
                                else
                                {
                                    Attempts--;
                                    Console.WriteLine(Menu_Feedback[1, Menu_Language]);
                                }
                            }
                        }while (Attempts > 0);

                        break;

                        /**
                         * Change the password
                         */
                    case 5:

                        if (Full_Name[0] == "" || Full_Name[1] == "" || Age == -1 && ID_Document == "" || Address == "")
                        {
                            Console.Clear();
                            Console.WriteLine(Menu_Feedback[3, Menu_Language]);
                            break;
                        }

                        Console.Clear();
                        Attempts = 3;
                        do
                        {
                            Console.WriteLine(Language_Change_Password[0, Menu_Language]);
                            string Confirmation = Console.ReadLine().ToLower().Trim();
                            if (Confirmation == "y")
                            {
                                Console.WriteLine(Language_Change_Password[1, Menu_Language]);
                                string Pass = Console.ReadLine();

                                if (Pass == Password)
                                {
                                    Console.WriteLine(Language_Change_Password[2, Menu_Language]);
                                    Password = Console.ReadLine();
                                    Console.WriteLine(System_Feedback[2, Menu_Language]);
                                    break;
                                }
                                else
                                {
                                    Attempts--;
                                    Console.WriteLine(Menu_Feedback[1, Menu_Language]);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(System_Feedback[1, Menu_Language]);
                                break;
                            }
                        } while (Attempts > 0);

                        if (Attempts <= 0)
                        {
                            Allow_Deposit = false;
                            Console.WriteLine(Menu_Feedback[2, Menu_Language]);
                            Transaction = 0;
                        }
                        break;

                        //Allow deposits
                    case 6:

                        if (Full_Name[0] == "" || Full_Name[1] == "" || Age == -1 && ID_Document == "" || Address == "")
                        {
                            Console.Clear();
                            Console.WriteLine(Menu_Feedback[3, Menu_Language]);
                            break;
                        }

                        Console.Clear();
                        Attempts = 3;
                        do
                        {
                            Console.WriteLine(Language_Deposit[0, Menu_Language]);
                            string Confirmation = Console.ReadLine().ToLower().Trim();
                            if (Confirmation == "y")
                            {
                                Console.WriteLine(Language_Deposit[1, Menu_Language]);
                                string Pass = Console.ReadLine();

                                if (Pass == Password)
                                {
                                    if (Allow_Deposit)
                                        Console.WriteLine(Language_Deposit[3, Menu_Language]);
                                    else
                                        Console.WriteLine(Language_Deposit[2, Menu_Language]);
                                    Allow_Deposit = !Allow_Deposit;
                                    break;
                                }
                                else
                                {
                                    Attempts--;
                                    Console.WriteLine(Menu_Feedback[1, Menu_Language]);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(System_Feedback[1, Menu_Language]);
                                break;
                            }
                        } while (Attempts > 0);

                        if (Attempts <= 0)
                        {
                            Allow_Deposit = false;
                            Console.WriteLine(Menu_Feedback[2, Menu_Language]);
                            Transaction = 0;
                        }
                        break;
                        //Change Language
                    case 7:
                        Console.WriteLine(Language_Options[0, Menu_Language]);
                        Menu_Language = Console.ReadLine().ToLower().Trim() == "y" ? Menu_Language == 0 ? 1 : 0 : Menu_Language;
                        Console.Clear();
                        break;
                        //Clear console
                    case 8:
                        Console.Clear();
                        break;
                        //Miss option
                    default:
                        Console.Clear();
                        Console.WriteLine(Menu_Feedback[0, Menu_Language]);
                        break;

                }
            } while (Menu_Option != -1);
            Console.WriteLine(System_Feedback[0, Menu_Language]);
        }
    }
}

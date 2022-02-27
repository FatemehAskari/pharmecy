using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace DsProject
{
    class Program
    {
        public struct Drug_tadakhol
        {
            public string name { get; set; }
            public string Effect { get; set; }
        }

        //for dis for examle dis+
        public struct Dis_effect
        {
            public string name { get; set; }
            public string asar { get; set; }
        }

        //for drug for example Drug+
        public struct Drug_effect
        {
            public string name { get; set; }
            public string asar { get; set; }
        }

        public class Drug_info
        {
            public int price { get; set; }
            public List<Drug_tadakhol> tadakhol = new List<Drug_tadakhol>();
            public List<Dis_effect> diseaseasar = new List<Dis_effect>();

            public void Add(Drug_tadakhol name_Drug)
            {
                tadakhol.Add(name_Drug);
            }
            public void delete(string name_Drug)
            {
                for (int i = 0; i < tadakhol.Count; i++)
                {
                    if (tadakhol[i].name == name_Drug)
                    {
                        tadakhol.Remove(tadakhol[i]);
                        break;
                    }
                }
            }
            public void Adddis(Dis_effect dis)
            {
                diseaseasar.Add(dis);
            }
            public void deletedis(string dis)
            {
                for (int i = 0; i < diseaseasar.Count; i++)
                {
                    if (diseaseasar[i].name == dis)
                    {
                        diseaseasar.Remove(diseaseasar[i]);
                        break;
                    }
                }
            }
        }
        public class Diseases_info
        {
            public List<Drug_effect> alergic = new List<Drug_effect>();
            public void Addtalergic(Drug_effect alergicdrug)
            {
                alergic.Add(alergicdrug);

            }
            public void deletealergic(string alergicdrug)
            {
                for (int i = 0; i < alergic.Count; i++)
                {
                    if (alergic[i].name == alergicdrug)
                    {
                        alergic.Remove(alergic[i]);
                        break;
                    }
                }
            }
        }
        public static void jodasazidrug(Dictionary<string, Drug_info> DrugInfo, string[] tadakhol, string drugbase)
        {
            for (int i = 0; i < tadakhol.Length; i++)
            {
                tadakhol[i] = tadakhol[i].Replace("(", "");
                tadakhol[i] = tadakhol[i].Replace(")", "");
                string[] s = tadakhol[i].Split(",");
                Drug_tadakhol b = new Drug_tadakhol();
                b.name = s[0];
                b.Effect = s[1];

                DrugInfo[drugbase].Add(b);
            }
        }
        public static void jodasazialergic(Dictionary<string, Drug_info> DrugInfo, Dictionary<string, Diseases_info> diseasesInfo, string[] alergic, string basedis)
        {
            for (int i = 0; i < alergic.Length; i++)
            {
                alergic[i] = alergic[i].Replace("(", "");
                alergic[i] = alergic[i].Replace(")", "");
                string[] s = alergic[i].Split(",");
                Dis_effect h = new Dis_effect();
                h.name = basedis;
                h.asar = s[1];
                DrugInfo[s[0]].Adddis(h);
                Drug_effect g = new Drug_effect();
                g.name = s[0];
                g.asar = s[1];

                diseasesInfo[basedis].Addtalergic(g);
            }
        }
        //1,2,5,8
        public static void createDrug(Dictionary<string, Drug_info> DrugInfo, Dictionary<string, Diseases_info> diseasesInfo, Stopwatch sw, List<string> log)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Create drug\nPlease enter the name:");
            string namedrug = Console.ReadLine();
            log.Add("Create drug\nPlease enter the name: " + namedrug);

            Stopwatch sw2 = Stopwatch.StartNew();
            sw.Start();

            if (DrugInfo.ContainsKey(namedrug))
            {
                sw.Stop();
                sw2.Stop();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The drug has already existed!!");
                log.Add("The drug has already existed!!");

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nTime = " + sw2.Elapsed.Milliseconds * 1000);
                log.Add("Time = " + sw2.Elapsed.Milliseconds * 1000);
                log.Add("#");
            }
            else
            {
                sw.Stop();
                sw2.Stop();
                Console.WriteLine("Please enter the cost:");

                int price;
                while (true)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        price = int.Parse(Console.ReadLine());

                        if (price < 0)
                            throw new Exception();

                        break;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input is wrong !! Please enter again");
                    }
                }
                sw.Start();
                sw2.Start();
                Drug_info a = new Drug_info();
                a.price = price;
                DrugInfo.Add(namedrug, a);
                log.Add("Please enter the cost: " + price);

                //drug
                Random rnd = new Random();
                int x1 = rnd.Next(0, 9000);
                int x2 = rnd.Next(0, 9000);
                string eff1 = "Eff_" + tasadofi();
                string eff2 = "Eff_" + tasadofi();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Interacts randomly with the following drugs:");
                log.Add("\nInteracts randomly with the following drugs:");

                Console.WriteLine(DrugInfo.ElementAt(x1).Key + " " + eff1);
                Console.WriteLine(DrugInfo.ElementAt(x2).Key + " " + eff2);
                log.Add(DrugInfo.ElementAt(x1).Key + " " + eff1 + "\n" + DrugInfo.ElementAt(x2).Key + " " + eff2);

                Drug_tadakhol rand1 = new Drug_tadakhol();
                rand1.name = DrugInfo.ElementAt(x1).Key;
                rand1.Effect = eff1;

                Drug_tadakhol rand2 = new Drug_tadakhol();
                rand2.name = DrugInfo.ElementAt(x2).Key;
                rand2.Effect = eff2;

                Drug_tadakhol asli1 = new Drug_tadakhol();
                asli1.name = namedrug;
                asli1.Effect = eff1;

                Drug_tadakhol asli2 = new Drug_tadakhol();
                asli2.name = namedrug;
                asli2.Effect = eff2;

                DrugInfo[namedrug].Add(rand1);
                DrugInfo[namedrug].Add(rand2);

                string key1 = DrugInfo.ElementAt(x1).Key;
                string key2 = DrugInfo.ElementAt(x2).Key;
                Console.WriteLine(key1 + " " + key2);
                log.Add(key1 + " " + key2);

                DrugInfo[key1].Add(asli1);
                DrugInfo[key2].Add(asli2);

                //disease

                Dis_effect rand3 = new Dis_effect();
                rand3.name = diseasesInfo.ElementAt(x1).Key;
                rand3.name = "+";

                Dis_effect rand4 = new Dis_effect();
                rand4.name = diseasesInfo.ElementAt(x2).Key;
                rand4.name = "+";

                Console.WriteLine("\nRandomly affects the following diseases:");
                log.Add("\nRandomly affects the following diseases:");

                Console.WriteLine(diseasesInfo.ElementAt(x1).Key + " " + "+");
                Console.WriteLine(diseasesInfo.ElementAt(x2).Key + " " + "+");
                log.Add(diseasesInfo.ElementAt(x1).Key + " " + "+\n" + diseasesInfo.ElementAt(x2).Key + " " + "+");

                DrugInfo[namedrug].Adddis(rand3);
                DrugInfo[namedrug].Adddis(rand4);

                Drug_effect ff1 = new Drug_effect();
                ff1.name = namedrug;
                ff1.asar = "+";

                diseasesInfo[diseasesInfo.ElementAt(x1).Key].Addtalergic(ff1);
                diseasesInfo[diseasesInfo.ElementAt(x2).Key].Addtalergic(ff1);

                sw.Stop();
                sw2.Stop();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSuccessfully added!!");
                log.Add("\nSuccessfully added!!");

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nTime = " + sw2.Elapsed.Milliseconds * 1000);
                log.Add("Time = " + sw2.Elapsed.Milliseconds * 1000);
                log.Add("#");
            }
        }
        public static string tasadofi()
        {
            Random rand = new Random();
            string word = "";
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            for (int j = 1; j <= 10; j++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);

                word += letters[letter_num];
            }
            return word;
        }
        public static void readDrug(Dictionary<string, Drug_info> DrugInfo, Stopwatch sw, List<string> log)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Search drug\nPlease enter the name:");
            string namedrug = Console.ReadLine();
            log.Add("Search drug\nPlease enter the name: " + namedrug);

            Stopwatch sw2 = Stopwatch.StartNew();
            sw.Start();

            if (DrugInfo.ContainsKey(namedrug))
            {
                var b = (Drug_info)DrugInfo[namedrug];
                Console.WriteLine("\nCost = " + " " + b.price);
                log.Add("Cost = " + " " + b.price);

                if (b.tadakhol.Count != 0)
                {
                    Console.WriteLine("\nDrug interactions:");
                    log.Add("\nDrug interactions:");


                    for (int i = 0; i < b.tadakhol.Count; i++)
                    {
                        Console.WriteLine(b.tadakhol[i].name + " " + b.tadakhol[i].Effect);
                        log.Add(b.tadakhol[i].name + " " + b.tadakhol[i].Effect);
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This drug does not exist.");
                log.Add("This drug does not exist.");
            }

            sw.Stop();
            sw2.Stop();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nTime = " + sw2.Elapsed.Milliseconds * 1000);
            log.Add("Time = " + sw2.Elapsed.Milliseconds * 1000);
            log.Add("#");
        }
        public static void deleteDrug(Dictionary<string, Drug_info> DrugInfo, Dictionary<string, Diseases_info> diseasesInfo, Stopwatch sw, List<string> log)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Delete drug\nPlease enter the name:");

            string drugdel = Console.ReadLine();
            log.Add("Delete drug\nPlease enter the name: " + drugdel);

            Stopwatch sw2 = Stopwatch.StartNew();
            sw.Start();

            if (DrugInfo.ContainsKey(drugdel))
            {
                for (int i = 0; i < DrugInfo[drugdel].tadakhol.Count; i++)
                {
                    DrugInfo[DrugInfo[drugdel].tadakhol[i].name].delete(drugdel);
                }
                for (int i = 0; i < DrugInfo[drugdel].diseaseasar.Count; i++)
                {
                    diseasesInfo[DrugInfo[drugdel].diseaseasar[i].name].deletealergic(drugdel);
                }

                DrugInfo.Remove(drugdel);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully removed!!");
                log.Add("Successfully removed!!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This drug does not exist.");
                log.Add("This drug does not exist.");
            }

            sw.Stop();
            sw2.Stop();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nTime = " + sw2.Elapsed.Milliseconds * 1000);
            log.Add("Time = " + sw2.Elapsed.Milliseconds * 1000);
            log.Add("#");
        }
        //3,4,5
        public static void createDisease(Dictionary<string, Diseases_info> diseasesInfo, Dictionary<string, Drug_info> DrugInfo, Stopwatch sw, List<string> log)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Create disease\nPlease enter the name:");
            string newdis = Console.ReadLine();
            log.Add("Create disease\nPlease enter the name: " + newdis);

            Stopwatch sw2 = Stopwatch.StartNew();
            sw.Start();

            if (diseasesInfo.ContainsKey(newdis))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The disease has already existed!!");
                log.Add("The disease has already existed!!");

                sw.Stop();
                sw2.Stop();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nTime = " + sw2.Elapsed.Milliseconds * 1000);
                log.Add("Time = " + sw2.Elapsed.Milliseconds * 1000);
                log.Add("#");
            }
            else
            {
                Diseases_info a = new Diseases_info();
                diseasesInfo.Add(newdis, a);

                Random rnd = new Random();
                int x1 = rnd.Next(0, 9000);
                int x2 = rnd.Next(0, 9000);
                int x3 = rnd.Next(0, 2);

                string key1 = DrugInfo.ElementAt(x1).Key;
                string key2 = DrugInfo.ElementAt(x2).Key;

                Drug_effect ff1 = new Drug_effect();
                ff1.name = key1;

                if (x3 == 1)
                    ff1.asar = "+";
                else
                    ff1.asar = "-";

                Drug_effect ff2 = new Drug_effect();
                ff2.name = key2;

                x3 = rnd.Next(0, 2);

                if (x3 == 1)
                    ff2.asar = "+";
                else
                    ff2.asar = "-";

                diseasesInfo[newdis].Addtalergic(ff1);
                diseasesInfo[newdis].Addtalergic(ff2);

                Dis_effect g1 = new Dis_effect();
                g1.name = newdis;
                g1.asar = ff1.asar;

                Dis_effect g2 = new Dis_effect();
                g2.name = newdis;
                g2.asar = ff2.asar;

                DrugInfo[DrugInfo.ElementAt(x1).Key].Adddis(g1);
                DrugInfo[DrugInfo.ElementAt(x2).Key].Adddis(g2);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nRandomly the effect of drugs:");
                log.Add("\nRandomly the effect of drugs:");

                Console.WriteLine(key1 + " " + ff1.asar);
                Console.WriteLine(key2 + " " + ff2.asar);
                log.Add(key1 + " " + ff1.asar);
                log.Add(key2 + " " + ff2.asar);

                sw.Stop();
                sw2.Stop();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSuccessfully added!!");
                log.Add("\nSuccessfully added!!");

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nTime = " + sw2.Elapsed.Milliseconds * 1000);
                log.Add("Time = " + sw2.Elapsed.Milliseconds * 1000);
                log.Add("#");
            }
        }
        public static void readDisease(Dictionary<string, Diseases_info> diseasesInfo, Stopwatch sw, List<string> log)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Search disease\nPlease enter the name:");
            string diseas = Console.ReadLine();
            log.Add("Search disease\nPlease enter the name: " + diseas);

            Stopwatch sw2 = Stopwatch.StartNew();
            sw.Start();

            if (diseasesInfo.ContainsKey(diseas))
            {
                Console.WriteLine("Drugs");
                log.Add("Drugs");

                var b = (Diseases_info)diseasesInfo[diseas];

                if (b.alergic.Count != 0)
                {
                    for (int i = 0; i < b.alergic.Count; i++)
                    {
                        Console.WriteLine(b.alergic[i].name + " " + b.alergic[i].asar);
                        log.Add(b.alergic[i].name + " " + b.alergic[i].asar);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no information.");
                    log.Add("There is no information.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This disease does not exist.");
                log.Add("This disease does not exist.");
            }
            sw.Stop();
            sw2.Stop();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nTime = " + sw2.Elapsed.Milliseconds * 1000);
            log.Add("Time = " + sw2.Elapsed.Milliseconds * 1000);
            log.Add("#");
        }

        public static void deleteDisease(Dictionary<string, Diseases_info> diseasesInfo, Dictionary<string, Drug_info> DrugInfo, Stopwatch sw, List<string> log)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Delete disease\nPlease enter the name:");
            string diseas = Console.ReadLine();
            log.Add("Delete disease\nPlease enter the name: " + diseas);

            Stopwatch sw2 = Stopwatch.StartNew();
            sw.Start();

            if (diseasesInfo.ContainsKey(diseas))
            {
                for (int i = 0; i < diseasesInfo[diseas].alergic.Count; i++)
                {
                    DrugInfo[diseasesInfo[diseas].alergic[i].name].deletedis(diseas);
                }
                diseasesInfo.Remove(diseas);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully removed!!");
                log.Add("Successfully removed!!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This disease does not exist.");
                log.Add("This disease does not exist.");
            }
            sw.Stop();
            sw2.Stop();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nTime = " + sw2.Elapsed.Milliseconds * 1000);
            log.Add("Time = " + sw2.Elapsed.Milliseconds * 1000);
            log.Add("#");
        }
        //6
        static void showeffectdrug(Dictionary<string, Drug_info> DrugInfo, Stopwatch sw, List<string> log)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Effect of drug\nPlease enter the name of the drug:");
            string infodrug = Console.ReadLine();
            log.Add("Effect of drug\nPlease enter the name of the drug: " + infodrug);

            Stopwatch sw2 = Stopwatch.StartNew();
            sw.Start();

            if (DrugInfo.ContainsKey(infodrug))
            {
                Console.WriteLine("\nEffect on other drugs:");
                log.Add("\nEffect on other drugs:");

                if (DrugInfo[infodrug].tadakhol.Count != 0)
                {
                    for (int i = 0; i < DrugInfo[infodrug].tadakhol.Count; i++)
                    {
                        Console.WriteLine(DrugInfo[infodrug].tadakhol[i].name + " " + DrugInfo[infodrug].tadakhol[i].Effect);
                        log.Add(DrugInfo[infodrug].tadakhol[i].name + " " + DrugInfo[infodrug].tadakhol[i].Effect);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no drug interaction.");
                    log.Add("There is no drug interaction.");
                }
                Console.WriteLine("\nEffect on diseases:");
                log.Add("\nEffect on diseases:");

                if (DrugInfo[infodrug].diseaseasar.Count != 0)
                {
                    for (int i = 0; i < DrugInfo[infodrug].diseaseasar.Count; i++)
                    {
                        Console.WriteLine(DrugInfo[infodrug].diseaseasar[i].name + " " + DrugInfo[infodrug].diseaseasar[i].asar);
                        log.Add(DrugInfo[infodrug].diseaseasar[i].name + " " + DrugInfo[infodrug].diseaseasar[i].asar);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no information.");
                    log.Add("There is no information.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This drug does not exist.");
                log.Add("This drug does not exist.");
            }
            sw.Stop();
            sw2.Stop();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nTime = " + sw2.Elapsed.Milliseconds * 1000);
            log.Add("Time = " + sw2.Elapsed.Milliseconds * 1000);
            log.Add("#");
        }
        //7
        static void showdisinfo(Dictionary<string, Diseases_info> diseasesInfo, Stopwatch sw, List<string> log)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please enter the name of the disease:");
            string disinfo = Console.ReadLine();
            int exist = 0;
            log.Add("Please enter the name of the disease: " + disinfo);

            Stopwatch sw2 = Stopwatch.StartNew();
            sw.Start();

            if (diseasesInfo.ContainsKey(disinfo))
            {
                for (int i = 0; i < diseasesInfo[disinfo].alergic.Count; i++)
                {
                    if (diseasesInfo[disinfo].alergic[i].asar == "+")
                    {
                        if (exist == 0)
                        {
                            Console.WriteLine("\nUseful drugs");
                            log.Add("\nUseful drugs");
                        }
                        Console.WriteLine(diseasesInfo[disinfo].alergic[i].name);
                        log.Add(diseasesInfo[disinfo].alergic[i].name);
                        exist = 1;
                    }
                }
                if (exist == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no useful drug");
                    log.Add("There is no useful drug");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This disease does not exist.");
                log.Add("This disease does not exist.");
            }
            sw.Stop();
            sw2.Stop();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nTime = " + sw2.Elapsed.Milliseconds * 1000);
            log.Add("Time = " + sw2.Elapsed.Milliseconds * 1000);
            log.Add("#");
        }

        //total cost of Drug
        static void totalcost(Dictionary<string, Drug_info> DrugInfo, List<string> log, Stopwatch sw)
        {
            int totalprice = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("How many drugs do you have?");
            int n;
            while (true)
            {
                try
                {
                    n = int.Parse(Console.ReadLine());

                    if (n < 0)
                        throw new Exception();

                    break;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input is wrong !! Please enter again");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;

            Stopwatch sw2 = Stopwatch.StartNew();
            sw.Start();

            if (n != 0)
                Console.WriteLine("Please enter the name of the drugs:");

            for (int i = 0; i < n; i++)
            {
                string x = Console.ReadLine();

                if (DrugInfo.ContainsKey(x))
                {
                    totalprice = DrugInfo[x].price + totalprice;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This drug does not exist.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nTotal Price = " + totalprice);
            log.Add("\nTotal Price = " + totalprice);

            sw.Stop();
            sw2.Stop();
            Console.WriteLine("\nTime = " + sw2.Elapsed.Milliseconds * 1000);
            log.Add("#");
        }

        //Drug interactions
        static void interaction(Dictionary<string, Drug_info> DrugInfo, List<string> log, Stopwatch sw)
        {
            Console.ForegroundColor = ConsoleColor.White;
            log.Add("Drug interaction");
            Console.WriteLine("How many drugs do you have in the prescription?");
            int n;
            while (true)
            {
                try
                {
                    n = int.Parse(Console.ReadLine());

                    if (n < 0)
                        throw new Exception();

                    break;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input is wrong !! Please enter again");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Stopwatch sw2 = Stopwatch.StartNew();
            sw.Start();

            if (n != 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please enter the name of the drugs");
                List<string> drugs = new List<string>();

                for (int i = 0; i < n; i++)
                {
                    string x = Console.ReadLine();
                    drugs.Add(x);
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                bool c1 = false;

                for (int i = 0; i < drugs.Count; i++)
                {
                    for (int j = i + 1; j < drugs.Count; j++)
                    {
                        if (DrugInfo.ContainsKey(drugs[i]))
                        {
                            if (check(DrugInfo[drugs[i]].tadakhol, drugs[j]) != "")
                            {
                                c1 = true;
                                Console.WriteLine(drugs[i] + " " + "has a drug interaction with " + drugs[j] + "with effect " + check(DrugInfo[drugs[i]].tadakhol, drugs[j]));
                                log.Add(drugs[i] + " " + "has a drug interaction with " + drugs[j] + "with effect " + check(DrugInfo[drugs[i]].tadakhol, drugs[j]));
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("There is no information.");
                            log.Add("There is no information.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                if (c1 == false)
                {
                    if (n == 1)
                    {
                        if (DrugInfo.ContainsKey(drugs[0]))
                        {
                            Console.WriteLine("There is no drug interaction!!");
                            log.Add("There is no drug interaction!!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("There is no information.");
                            log.Add("There is no information.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nThere is no drug interaction!!");
                        log.Add("\nThere is no drug interaction!!");
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no prescription!!");
                log.Add("There is no prescription!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            sw.Stop();
            sw2.Stop();
            Console.WriteLine("\nTime = " + sw2.Elapsed.Milliseconds * 1000);
            log.Add("#");
        }
        //check
        static string check(List<Drug_tadakhol> tadakol, string name)
        {
            for (int i = 0; i < tadakol.Count; i++)
            {
                if (tadakol[i].name == name)
                {
                    return tadakol[i].Effect;
                }
            }
            return "";
        }

        //save to file text Drug and Effect
        static void saveDrug_Effect(Dictionary<string, Drug_info> DrugInfo, Stopwatch sw)
        {
            sw.Start();

            StreamWriter writedrugs = new StreamWriter(@"drugs.txt");
            foreach (var a in DrugInfo)
            {
                writedrugs.WriteLine(a.Key + " " + ":" + " " + a.Value.price);
            }
            writedrugs.Close();

            StreamWriter writeeffect = new StreamWriter(@"effects.txt");
            int i = 0;
            foreach (var a in DrugInfo)
            {
                if (DrugInfo[a.Key].tadakhol.Count >= 1)
                {
                    writeeffect.Write(a.Key + " " + ":" + " ");
                    for (i = 0; i < DrugInfo[a.Key].tadakhol.Count - 1; i++)
                    {
                        writeeffect.Write("(" + DrugInfo[a.Key].tadakhol[i].name + "," + DrugInfo[a.Key].tadakhol[i].Effect + ")" + " " + ";" + " ");
                    }
                    writeeffect.Write("(" + DrugInfo[a.Key].tadakhol[i].name + "," + DrugInfo[a.Key].tadakhol[i].Effect + ")");
                    writeeffect.WriteLine();
                }
            }

            writeeffect.Close();
            sw.Stop();
        }
        //save to file text Diseases and Alergies
        static void savedisease_alergic(Dictionary<string, Diseases_info> diseasesInfo, Stopwatch sw)
        {
            sw.Start();

            StreamWriter writedisease = new StreamWriter(@"diseases.txt");
            foreach (var a in diseasesInfo)
            {
                writedisease.WriteLine(a.Key);
            }
            writedisease.Close();

            StreamWriter writealergic = new StreamWriter(@"alergies.txt");
            int i = 0;
            foreach (var a in diseasesInfo)
            {
                if (diseasesInfo[a.Key].alergic.Count >= 1)
                {
                    writealergic.Write(a.Key + " " + ":" + " ");
                    for (i = 0; i < diseasesInfo[a.Key].alergic.Count - 1; i++)
                    {
                        writealergic.Write("(" + diseasesInfo[a.Key].alergic[i].name + "," + diseasesInfo[a.Key].alergic[i].asar + ")" + " " + ";" + " ");
                    }
                    writealergic.Write("(" + diseasesInfo[a.Key].alergic[i].name + "," + diseasesInfo[a.Key].alergic[i].asar + ")");
                    writealergic.WriteLine();
                }
            }
            writealergic.Close();
            sw.Stop();
        }
        static void Main()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Dictionary<string, Drug_info> DrugInfo = new Dictionary<string, Drug_info>();
            List<string> Log = new List<string>();

            //drug
            foreach (string b in File.ReadLines(@"drugs.txt"))
            {
                string lines1 = b;
                lines1 = lines1.Replace(" ", "");
                string[] info = lines1.Split(":");
                string nameDrug = info[0];
                int price = int.Parse(info[1]);
                Drug_info a = new Drug_info();
                a.price = price;
                DrugInfo.Add(nameDrug, a);
            }
            //effect
            foreach (string b in File.ReadLines(@"effects.txt"))
            {
                string lines2 = b;
                lines2 = lines2.Replace(" ", "");
                string[] info = lines2.Split(":");
                string drugbase = info[0];
                string[] tadakhol = info[1].Split(";");
                jodasazidrug(DrugInfo, tadakhol, drugbase);
            }
            //disease
            Dictionary<string, Diseases_info> diseasesInfo = new Dictionary<string, Diseases_info>();
            foreach (string b in File.ReadLines(@"diseases.txt"))
            {
                string lines3 = b;
                Diseases_info a = new Diseases_info();
                diseasesInfo.Add(lines3, a);
            }
            //alergic
            foreach (string b in File.ReadLines(@"alergies.txt"))
            {
                string lines4 = b;
                lines4 = lines4.Replace(" ", "");
                string[] info = lines4.Split(":");
                string deasesbase = info[0];
                string[] alergic = info[1].Split(";");
                jodasazialergic(DrugInfo, diseasesInfo, alergic, deasesbase);
            }
            sw.Stop();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Hash time:\n" + sw.Elapsed.Milliseconds * 1000 + "\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Which one?\n" +
                  "1)Add Drug\n" +
                  "2)Delete Drug\n" +
                  "3)Search Drug\n" +
                  "4)Add Disease\n" +
                  "5)Delete Disease\n" +
                  "6)Search Disease\n" +
                  "7)Effect of drug in disease and drug interactions\n" +
                  "8)Useful drugs for the disease\n" +
                  "9)Total price\n" +
                  "10)Drug interaction\n" +
                  "11)Inflation\n" +
                  "12)Log\n" +
                  "13)Exit");

                string dastoor = Console.ReadLine();
                if (dastoor == "1")
                {
                    createDrug(DrugInfo, diseasesInfo, sw, Log);
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (dastoor == "2")
                {
                    deleteDrug(DrugInfo, diseasesInfo, sw, Log);
                    Console.ReadKey();
                    Console.Clear();
                }

                else if (dastoor == "3")
                {
                    readDrug(DrugInfo, sw, Log);
                    Console.ReadKey();
                    Console.Clear();
                }

                else if (dastoor == "4")
                {
                    createDisease(diseasesInfo, DrugInfo, sw, Log);
                    Console.ReadKey();
                    Console.Clear();
                }

                else if (dastoor == "5")
                {
                    deleteDisease(diseasesInfo, DrugInfo, sw, Log);
                    Console.ReadKey();
                    Console.Clear();
                }

                else if (dastoor == "6")
                {
                    readDisease(diseasesInfo, sw, Log);
                    Console.ReadKey();
                    Console.Clear();
                }

                else if (dastoor == "7")
                {
                    showeffectdrug(DrugInfo, sw, Log);
                    Console.ReadKey();
                    Console.Clear();
                }

                else if (dastoor == "8")
                {
                    showdisinfo(diseasesInfo, sw, Log);
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (dastoor == "9")
                {
                    totalcost(DrugInfo, Log, sw);
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (dastoor == "10")
                {
                    interaction(DrugInfo, Log, sw);
                    Console.ReadKey();
                    Console.Clear();
                }

                else if (dastoor == "11")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Change Cost\nPlease enter the inflation rate:");
                    double Inflation;

                    while (true)
                    {
                        try
                        {
                            Inflation = double.Parse(Console.ReadLine());

                            if (Inflation < -100)
                                throw new Exception();

                            if (Inflation != 0)
                            {
                                Log.Add("Change Cost\nPlease enter the inflation rate: " + Inflation);

                                Stopwatch sw2 = Stopwatch.StartNew();
                                sw.Start();

                                foreach (var i in DrugInfo)
                                {
                                    DrugInfo[i.Key].price = Convert.ToInt32(((Inflation + 100) * DrugInfo[i.Key].price) / 100);
                                }
                                sw.Stop();
                                sw2.Stop();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Costs changed successfully!!");
                                Log.Add("Costs changed successfully!!");

                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("\nTime = " + sw2.Elapsed.Milliseconds * 1000);
                                Log.Add("Time = " + sw2.Elapsed.Milliseconds * 1000);
                                Log.Add("#");
                            }
                            else
                            {
                                Log.Add("Change Cost\nPlease enter the inflation rate: " + Inflation);
                                Log.Add("Costs changed successfully!!");

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Costs changed successfully!!");
                            }
                            break;
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Input is wrong !! Please enter again");
                        }
                    }
                    Log.Add("#");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (dastoor == "12")
                {
                    Console.WriteLine("Log");

                    Stopwatch sw2 = Stopwatch.StartNew();
                    sw.Start();

                    ConsoleColor color = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                    if (Log.Count != 0)
                    {
                        foreach (var l in Log)
                        {
                            if (String.Compare("#", l) == 0)
                            {
                                Console.WriteLine();

                                if (color == ConsoleColor.DarkRed)
                                    color = ConsoleColor.DarkYellow;

                                else
                                    color = ConsoleColor.DarkRed;

                                Console.ForegroundColor = color;
                            }
                            else
                            {
                                Console.WriteLine(l);
                            }
                        }
                    }
                    else
                        Console.WriteLine("No command has been given!!");

                    sw.Stop();
                    sw2.Stop();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Time = " + sw2.Elapsed.Milliseconds * 1000);

                    Console.ReadKey();
                    Console.Clear();
                }

                else if (dastoor == "13")
                {
                    try
                    {
                        saveDrug_Effect(DrugInfo, sw);
                        savedisease_alergic(diseasesInfo, sw);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\nTotal Time = " + sw.Elapsed.Milliseconds * 1000);
                        Console.WriteLine("Total Memory = " + (GC.GetTotalMemory(true)) / 1000000);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (FileNotFoundException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("File does not exist.");
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("error!!");
                    }
                    break;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input is incorrect!! Please enter 1 to 13");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}